using CallTracker_Lib.database.wrappers;
using NLog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CallTracker_Lib.utility.Enums;

namespace CallTracker_Lib.database
{
    public class SQLiteConnector
    {
        private static readonly NLog.Logger Logger = logging.LogManager<SQLiteConnector>.GetLogger();

        private SQLiteConnector() { }

        /// <summary>
        /// Retrieve a list of column names from the specified table.
        /// </summary>
        /// <param name="tableName">The table to get the columns of</param>
        /// <returns>An <see cref="ArrayList"/> of type <see cref="string"/> containing the column names or <c>null</c> if an error occured reading table.</returns>
        public static ArrayList? GetColumns(string tableName)
        {
            SQLiteConnection conn;
            ArrayList columns = new ArrayList();
            string q = $"SELECT GROUP_CONCAT(NAME,',') FROM PRAGMA_TABLE_INFO('{tableName}')";

            using (conn = new SQLiteConnection(DBConnection.GetConnectionString()))
            {
                if (conn == null)
                    return null;

                conn.Open();
                using (SQLiteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = q;
                    using SQLiteDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        string columnlist = reader.GetString(0);
                        string[] tokens = columnlist.Split(',');
                        foreach (string str in tokens)
                            columns.Add(str);
                    }
                }
                conn.Close();
                return columns;
            }
        }

        public static int GetLastRowIDInserted(string tableName)
        {
            SQLiteConnection conn;

            int lastRowID = 0;
            ArrayList? columns = GetColumns(tableName);
            string q = $"SELECT seq FROM sqlite_sequence WHERE name='{tableName}'";
            if (columns == null)
                return 0;

            using (conn = new SQLiteConnection(DBConnection.GetConnectionString()))
            {
                if (conn == null)
                    return -1;
                conn.Open();
                using (SQLiteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = q;
                    using SQLiteDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        lastRowID = reader.GetInt32(0);
                    }
                }
                conn.Close();
            }

            return lastRowID;
        }

        #region AppOwner
        public static int InsertAppOwner(AppOwner owner)
        {
            int affectedRows = 0;
            ArrayList? columns = GetColumns("app_owner");
            if (columns == null)
                return -1;
            columns.RemoveAt(0); //remove the id column
            columns.TrimToSize();

            string q = Queries.BuildQuery(QType.INSERT, "app_owner", null, columns);

            using SQLiteConnection conn = new SQLiteConnection(DBConnection.GetConnectionString());
            if (conn == null)
                return -1;
            conn.Open();

            using (SQLiteTransaction tr = conn.BeginTransaction())
            {
                using SQLiteCommand cmd = new(q, conn, tr);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@0", owner.Name);
                cmd.Parameters.AddWithValue("@1", owner.Base64Logo);
                cmd.Parameters.AddWithValue("@2", owner.PhoneNumber);
                affectedRows = cmd.ExecuteNonQuery();

                if (affectedRows > 0)
                    tr.Commit();
                else
                    tr.Rollback();
            }

            conn.Close();
            return affectedRows != 0 ? GetLastRowIDInserted("app_owner") : -1;
        }

        public static bool UpdateAppOwner(AppOwner owner)
        {
            int affectedRows = 0;
            ArrayList? columns = GetColumns("app_owner");
            if (columns == null)
                return false;
            string q = Queries.BuildQuery(QType.UPDATE, "app_owner", null, columns, $"id={owner.ID}");

            using SQLiteConnection conn = new(DBConnection.GetConnectionString());
            if (conn == null)
                return false;
            conn.Open();

            using (SQLiteTransaction tr = conn.BeginTransaction())
            {
                using SQLiteCommand cmd = new(q, conn, tr);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@0", owner.ID);
                cmd.Parameters.AddWithValue("@1", owner.Name);
                cmd.Parameters.AddWithValue("@2", owner.Base64Logo);
                cmd.Parameters.AddWithValue("@3", owner.PhoneNumber);
                affectedRows = cmd.ExecuteNonQuery();

                if (affectedRows > 0)
                    tr.Commit();
                else
                    tr.Rollback();
            }

            conn.Close();
            return affectedRows != 0;
        }

        public static AppOwner? GetAppOwner(int id)
        {
            AppOwner? owner = null;
            string q = Queries.BuildQuery(QType.SELECT, "app_owner", null, null, $"id={id}");

            using SQLiteConnection conn = new(DBConnection.GetConnectionString());
            conn.Open();

            using SQLiteCommand cmd = new(q, conn);
            using SQLiteDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                owner = new AppOwner
                {
                    ID = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Base64Logo = reader.GetString(2),
                    PhoneNumber = reader.GetString(3)
                };
            }

            conn.Close();
            return owner;
        }

        public static List<AppOwner> GetAppOwners()
        {
            List<AppOwner> appOwners = new List<AppOwner>();
            string q = Queries.BuildQuery(QType.SELECT, "app_owner");

            using SQLiteConnection conn = new(DBConnection.GetConnectionString());
            conn.Open();

            using SQLiteCommand cmd = new(q, conn);
            using SQLiteDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    AppOwner owner = new AppOwner
                    {
                        ID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Base64Logo = reader.GetString(2),
                        PhoneNumber = reader.GetString(3)
                    };
                    appOwners.Add(owner);
                }
            }

            conn.Close();
            return appOwners;
        }

        public static bool DeleteAppOwner(AppOwner owner)
        {
            int affectedRows = 0;
            string q = Queries.BuildQuery(QType.DELETE, "app_owner", null, null, $"id={owner.ID}");

            try
            {
                using SQLiteConnection conn = new(DBConnection.GetConnectionString());
                conn.Open();
                using (SQLiteTransaction tr = conn.BeginTransaction())
                {
                    using SQLiteCommand cmd = new(q, conn, tr);
                    affectedRows = cmd.ExecuteNonQuery();
                    if (affectedRows > 0)
                        tr.Commit();
                    else
                        tr.Rollback();
                }
                conn.Close();
            } catch (Exception)
            {
                return false;
            }
            return affectedRows != 0;
        }
        #endregion

        #region Call Log
        public static int InsertCallLog(CallLog log)
        {
            int affectedRows = 0;
            ArrayList? columns = GetColumns("call_log");
            if (columns == null)
                return -1;
            columns.RemoveAt(0); //remove the id column
            columns.TrimToSize();

            string q = Queries.BuildQuery(QType.INSERT, "call_log", null, columns);

            using SQLiteConnection conn = new SQLiteConnection(DBConnection.GetConnectionString());
            if (conn == null)
                return -1;
            conn.Open();

            using (SQLiteTransaction tr = conn.BeginTransaction())
            {
                using SQLiteCommand cmd = new(q, conn, tr);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@0", log.CompanyID);
                cmd.Parameters.AddWithValue("@1", log.NoteManager == null ? string.Empty : log.NoteManager.ToString());
                cmd.Parameters.AddWithValue("@2", log.NextCallDate.Ticks);
                cmd.Parameters.AddWithValue("@3", log.LastCallDate.Ticks);
                cmd.Parameters.AddWithValue("@4", log.LastContactDate.Ticks);
                affectedRows = cmd.ExecuteNonQuery();

                if (affectedRows > 0)
                    tr.Commit();
                else
                    tr.Rollback();
            }

            conn.Close();
            return affectedRows != 0 ? GetLastRowIDInserted("call_log") : -1;
        }

        public static bool UpdateCallLog(CallLog log)
        {
            int affectedRows = 0;
            ArrayList? columns = GetColumns("call_log");
            if (columns == null)
                return false;
            string q = Queries.BuildQuery(QType.UPDATE, "call_log", null, columns, $"id={log.ID}");

            using SQLiteConnection conn = new(DBConnection.GetConnectionString());
            if (conn == null)
                return false;
            conn.Open();

            using (SQLiteTransaction tr = conn.BeginTransaction())
            {
                using SQLiteCommand cmd = new(q, conn, tr);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@0", log.ID);
                cmd.Parameters.AddWithValue("@1", log.CompanyID);
                cmd.Parameters.AddWithValue("@2", log.NoteManager == null ? string.Empty : log.NoteManager.ToString());
                cmd.Parameters.AddWithValue("@3", log.NextCallDate.Ticks);
                cmd.Parameters.AddWithValue("@4", log.LastCallDate.Ticks);
                cmd.Parameters.AddWithValue("@5", log.LastContactDate.Ticks);
                affectedRows = cmd.ExecuteNonQuery();

                if (affectedRows > 0)
                    tr.Commit();
                else
                    tr.Rollback();
            }

            conn.Close();
            return affectedRows != 0;
        }

        public static CallLog? GetCallLog(int id)
        {
            CallLog? log = null;
            string q = Queries.BuildQuery(QType.SELECT, "call_log", null, null, $"id={id}");

            using SQLiteConnection conn = new(DBConnection.GetConnectionString());
            conn.Open();

            using SQLiteCommand cmd = new(q, conn);
            using SQLiteDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                log = new CallLog
                {
                    ID = reader.GetInt32(0),
                    CompanyID = reader.GetInt32(1),
                    NoteManager = new NoteManager(reader.GetString(2)),
                    NextCallDate = new DateTime(int.Parse(reader.GetString(3))),
                    LastCallDate = new DateTime(int.Parse(reader.GetString(4))),
                    LastContactDate = new DateTime(int.Parse(reader.GetString(5)))
                };
            }

            conn.Close();
            return log;
        }

        public static List<CallLog> GetCallLogs()
        {
            List<CallLog> logs = new List<CallLog>();
            string q = Queries.BuildQuery(QType.SELECT, "call_log");

            using SQLiteConnection conn = new(DBConnection.GetConnectionString());
            conn.Open();

            using SQLiteCommand cmd = new(q, conn);
            using SQLiteDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    CallLog log = new CallLog
                        {
                            ID = reader.GetInt32(0),
                            CompanyID = reader.GetInt32(1),
                            NoteManager = new NoteManager(reader.GetString(2)),
                            NextCallDate = new DateTime(int.Parse(reader.GetString(3))),
                            LastCallDate = new DateTime(int.Parse(reader.GetString(4))),
                            LastContactDate = new DateTime(int.Parse(reader.GetString(5)))
                        };
                    logs.Add(log);
                }
            }

            conn.Close();
            return logs;
        }

        public static bool DeleteCallLog(CallLog log)
        {
            int affectedRows = 0;
            string q = Queries.BuildQuery(QType.DELETE, "call_log", null, null, $"id={log.ID}");

            try
            {
                using SQLiteConnection conn = new(DBConnection.GetConnectionString());
                conn.Open();
                using (SQLiteTransaction tr = conn.BeginTransaction())
                {
                    using SQLiteCommand cmd = new(q, conn, tr);
                    affectedRows = cmd.ExecuteNonQuery();
                    if (affectedRows > 0)
                        tr.Commit();
                    else
                        tr.Rollback();
                }
                conn.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return affectedRows != 0;
        }
        #endregion

        #region Company
        public static int InsertCompany(Company c)
        {
            int affectedRows = 0;
            ArrayList? columns = GetColumns("company");
            if (columns == null)
                return -1;
            columns.RemoveAt(0); //remove the id column
            columns.TrimToSize();

            string q = Queries.BuildQuery(QType.INSERT, "company", null, columns);

            using SQLiteConnection conn = new SQLiteConnection(DBConnection.GetConnectionString());
            if (conn == null)
                return -1;
            conn.Open();

            using (SQLiteTransaction tr = conn.BeginTransaction())
            {
                using SQLiteCommand cmd = new(q, conn, tr);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@0", c.Name);
                cmd.Parameters.AddWithValue("@1", c.BusinessPhone);
                cmd.Parameters.AddWithValue("@2", c.PrimaryContactID);
                cmd.Parameters.AddWithValue("@3", c.AdditionalContacts);
                cmd.Parameters.AddWithValue("@4", c.CompanyAddress?.ToDBString());
                cmd.Parameters.AddWithValue("@5", c.WebsiteURL);
                cmd.Parameters.AddWithValue("@6", c.Base64Logo);
                cmd.Parameters.AddWithValue("@7", c.LinkedInURL);
                cmd.Parameters.AddWithValue("@8", c.Industry);
                cmd.Parameters.AddWithValue("@9", c.WorkforceSize);
                affectedRows = cmd.ExecuteNonQuery();

                if (affectedRows > 0)
                    tr.Commit();
                else
                    tr.Rollback();
            }

            conn.Close();
            return affectedRows != 0 ? GetLastRowIDInserted("company") : -1;
        }

        public static bool UpdateCompany(Company c)
        {
            int affectedRows = 0;
            ArrayList? columns = GetColumns("company");
            if (columns == null)
                return false;
            string q = Queries.BuildQuery(QType.UPDATE, "company", null, columns, $"id={c.ID}");

            using SQLiteConnection conn = new(DBConnection.GetConnectionString());
            if (conn == null)
                return false;
            conn.Open();

            using (SQLiteTransaction tr = conn.BeginTransaction())
            {
                using SQLiteCommand cmd = new(q, conn, tr);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@0", c.ID);
                cmd.Parameters.AddWithValue("@1", c.Name);
                cmd.Parameters.AddWithValue("@2", c.BusinessPhone);
                cmd.Parameters.AddWithValue("@3", c.PrimaryContactID);
                cmd.Parameters.AddWithValue("@4", c.AdditionalContacts);
                cmd.Parameters.AddWithValue("@5", c.CompanyAddress?.ToDBString());
                cmd.Parameters.AddWithValue("@6", c.WebsiteURL);
                cmd.Parameters.AddWithValue("@7", c.Base64Logo);
                cmd.Parameters.AddWithValue("@8", c.LinkedInURL);
                cmd.Parameters.AddWithValue("@9", c.Industry);
                cmd.Parameters.AddWithValue("@10", c.WorkforceSize);
                affectedRows = cmd.ExecuteNonQuery();

                if (affectedRows > 0)
                    tr.Commit();
                else
                    tr.Rollback();
            }

            conn.Close();
            return affectedRows != 0;
        }

        public static Company? GetCompany(int id)
        {
            Company? c = null;
            string q = Queries.BuildQuery(QType.SELECT, "company", null, null, $"id={id}");

            using SQLiteConnection conn = new(DBConnection.GetConnectionString());
            conn.Open();

            using SQLiteCommand cmd = new(q, conn);
            using SQLiteDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                c = new Company
                {
                    ID = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    BusinessPhone = reader.GetString(2),
                    PrimaryContactID = reader.GetInt32(3),
                    AdditionalContacts = reader.GetString(4),
                    CompanyAddress = new Address(reader.GetString(5)),
                    WebsiteURL = reader.GetString(6),
                    Base64Logo = reader.GetString(7),
                    LinkedInURL = reader.GetString(8),
                    Industry = reader.GetString(9),
                    WorkforceSize = reader.GetInt32(10)
                };
                if (c.PrimaryContactID != 0)
                    c.PrimaryContact = GetContact(c.PrimaryContactID);
            }

            conn.Close();
            return c;
        }

        public static List<Company> GetCompanies()
        {
            List<Company> companies = new List<Company>();
            string q = Queries.BuildQuery(QType.SELECT, "company");

            using SQLiteConnection conn = new(DBConnection.GetConnectionString());
            conn.Open();

            using SQLiteCommand cmd = new(q, conn);
            using SQLiteDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Company c = new Company
                    {
                        ID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        BusinessPhone = reader.GetString(2),
                        PrimaryContactID = reader.GetInt32(3),
                        AdditionalContacts = reader.GetString(4),
                        CompanyAddress = new Address(reader.GetString(5)),
                        WebsiteURL = reader.GetString(6),
                        Base64Logo = reader.GetString(7),
                        LinkedInURL = reader.GetString(8),
                        Industry = reader.GetString(9),
                        WorkforceSize = reader.GetInt32(10)
                    };
                    if (c.PrimaryContactID != 0)
                        c.PrimaryContact = GetContact(c.PrimaryContactID);
                    companies.Add(c);
                }
            }

            conn.Close();
            return companies;
        }

        public static bool DeleteCompany(Company c)
        {
            int affectedRows = 0;
            string q = Queries.BuildQuery(QType.DELETE, "company", null, null, $"id={c.ID}");

            try
            {
                using SQLiteConnection conn = new(DBConnection.GetConnectionString());
                conn.Open();
                using (SQLiteTransaction tr = conn.BeginTransaction())
                {
                    using SQLiteCommand cmd = new(q, conn, tr);
                    affectedRows = cmd.ExecuteNonQuery();
                    if (affectedRows > 0)
                        tr.Commit();
                    else
                        tr.Rollback();
                }
                conn.Close();

                bool contactDeleteSuccess = DeleteContact(c.PrimaryContact);
                if (!contactDeleteSuccess)
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
            return affectedRows != 0;
        }
        #endregion

        #region Contact
        public static int InsertContact(Contact c)
        {
            int affectedRows = 0;
            ArrayList? columns = GetColumns("contact");
            if (columns == null)
                return -1;
            columns.RemoveAt(0); //remove the id column
            columns.TrimToSize();

            string q = Queries.BuildQuery(QType.INSERT, "contact", null, columns);

            using SQLiteConnection conn = new SQLiteConnection(DBConnection.GetConnectionString());
            if (conn == null)
                return -1;
            conn.Open();

            using (SQLiteTransaction tr = conn.BeginTransaction())
            {
                using SQLiteCommand cmd = new(q, conn, tr);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@0", c.FirstName);
                cmd.Parameters.AddWithValue("@1", c.LastName);
                cmd.Parameters.AddWithValue("@2", c.Title);
                cmd.Parameters.AddWithValue("@3", c.PhoneNumber);
                cmd.Parameters.AddWithValue("@4", c.MobilePhone);
                cmd.Parameters.AddWithValue("@5", c.Email);
                cmd.Parameters.AddWithValue("@6", c.SecondaryEmail);
                cmd.Parameters.AddWithValue("@7", c.IsDecisionMaker);
                affectedRows = cmd.ExecuteNonQuery();

                if (affectedRows > 0)
                    tr.Commit();
                else
                    tr.Rollback();
            }

            conn.Close();
            return affectedRows != 0 ? GetLastRowIDInserted("contact") : -1;
        }

        public static bool UpdateContact(Contact c)
        {
            int affectedRows = 0;
            ArrayList? columns = GetColumns("contact");
            if (columns == null)
                return false;
            string q = Queries.BuildQuery(QType.UPDATE, "contact", null, columns, $"id={c.ID}");

            using SQLiteConnection conn = new(DBConnection.GetConnectionString());
            if (conn == null)
                return false;
            conn.Open();

            using (SQLiteTransaction tr = conn.BeginTransaction())
            {
                using SQLiteCommand cmd = new(q, conn, tr);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@0", c.ID);
                cmd.Parameters.AddWithValue("@1", c.FirstName);
                cmd.Parameters.AddWithValue("@2", c.LastName);
                cmd.Parameters.AddWithValue("@3", c.Title);
                cmd.Parameters.AddWithValue("@4", c.PhoneNumber);
                cmd.Parameters.AddWithValue("@5", c.MobilePhone);
                cmd.Parameters.AddWithValue("@6", c.Email);
                cmd.Parameters.AddWithValue("@7", c.SecondaryEmail);
                cmd.Parameters.AddWithValue("@8", c.IsDecisionMaker);
                affectedRows = cmd.ExecuteNonQuery();

                if (affectedRows > 0)
                    tr.Commit();
                else
                    tr.Rollback();
            }

            conn.Close();
            return affectedRows != 0;
        }

        public static Contact? GetContact(int id)
        {
            Contact? c = null;
            string q = Queries.BuildQuery(QType.SELECT, "contact", null, null, $"id={id}");

            using SQLiteConnection conn = new(DBConnection.GetConnectionString());
            conn.Open();

            using SQLiteCommand cmd = new(q, conn);
            using SQLiteDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                c = new Contact
                {
                    ID = reader.GetInt32(0),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2),
                    Title = reader.GetString(3),
                    PhoneNumber = reader.GetString(4),
                    MobilePhone = reader.GetString(5),
                    Email = reader.GetString(6),
                    SecondaryEmail = reader.GetString(7),
                    IsDecisionMaker = reader.GetBoolean(8)
                };
            }

            conn.Close();
            return c;
        }

        public static List<Contact> GetContactsForCompany(int companyID)
        {
            throw new NotImplementedException();
            //List<Company> companies = new List<Company>();
            //string q = Queries.BuildQuery(QType.SELECT, "company");

            //using SQLiteConnection conn = new(DBConnection.GetConnectionString());
            //conn.Open();

            //using SQLiteCommand cmd = new(q, conn);
            //using SQLiteDataReader reader = cmd.ExecuteReader();
            //if (reader.HasRows)
            //{
            //    while (reader.Read())
            //    {
            //        Company c = new Company
            //        {
            //            ID = reader.GetInt32(0),
            //            Name = reader.GetString(1),
            //            BusinessPhone = reader.GetString(2),
            //            PrimaryContactID = reader.GetInt32(3),
            //            AdditionalContacts = reader.GetString(4),
            //            CompanyAddress = new Address(reader.GetString(5)),
            //            WebsiteURL = reader.GetString(6),
            //            Base64Logo = reader.GetString(7),
            //            LinkedInURL = reader.GetString(8),
            //            Industry = reader.GetString(9),
            //            WorkforceSize = reader.GetInt32(10)
            //        };
            //        if (c.PrimaryContactID != 0)
            //            c.PrimaryContact = GetContact(c.PrimaryContactID);
            //        companies.Add(c);
            //    }
            //}

            //conn.Close();
            //return companies;
        }

        public static bool DeleteContact(Contact c)
        {
            int affectedRows = 0;
            string q = Queries.BuildQuery(QType.DELETE, "contact", null, null, $"id={c.ID}");

            try
            {
                using SQLiteConnection conn = new(DBConnection.GetConnectionString());
                conn.Open();
                using (SQLiteTransaction tr = conn.BeginTransaction())
                {
                    using SQLiteCommand cmd = new(q, conn, tr);
                    affectedRows = cmd.ExecuteNonQuery();
                    if (affectedRows > 0)
                        tr.Commit();
                    else
                        tr.Rollback();
                }
                conn.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return affectedRows != 0;
        }
        #endregion
    }
}
