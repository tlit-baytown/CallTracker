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
        /*
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
            }
            catch (Exception)
            {
                return false;
            }
            return affectedRows != 0;
        }
        */
        #endregion
    }
}
