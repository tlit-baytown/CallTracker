using CallTracker_Lib.interfaces;
using CallTracker_Lib.utility;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CallTracker_Lib.utility.Enums;

namespace CallTracker_Lib.database.wrappers
{
    public class Company : IDBWrapper
    {
        private static readonly NLog.Logger Logger = logging.LogManager<Company>.GetLogger();

        [Browsable(false)]
        public int ID { get; set; }

        public string Name { get; set; } = string.Empty;
        public string BusinessPhone { get; set; } = string.Empty;
        public int PrimaryContactID { get; set; }
        public Contact? PrimaryContact { get; set; } = null;
        public string AdditionalContacts { get; set; } = "NA";
        public Address? CompanyAddress { get; set; } = null;
        public string WebsiteURL { get; set; } = string.Empty;
        public string Base64Logo { get; set; } = string.Empty;
        public string LinkedInURL { get; set; } = string.Empty;
        public string Industry { get; set; } = string.Empty;
        public int WorkforceSize { get; set; }

        public bool IsEmpty
        {
            get
            {
                return Name.Equals(string.Empty) || BusinessPhone.Equals(string.Empty) || CompanyAddress == null;
            }
        }

        public DatabaseError Insert()
        {
            DatabaseError e;
            if (!IsEmpty)
            {
                //Take care of the contact insert and update first
                #region Contact Insert/Update
                if (PrimaryContact == null)
                    return DatabaseError.CompanyContactNull;

                if (PrimaryContact.ID == 0)
                    e = PrimaryContact.Insert();
                else
                    e = PrimaryContact.Update();

                if (e != DatabaseError.NoError)
                    return e;

                PrimaryContactID = PrimaryContact.ID;
                #endregion
                if (ID == 0)
                {
                    
                    ID = SQLiteConnector.InsertCompany(this);
                    e = ID != 0 ? DatabaseError.NoError : DatabaseError.CompanyInsert;
                }
                else
                    e = SQLiteConnector.UpdateCompany(this) ? DatabaseError.NoError : DatabaseError.CompanyUpdate;
                return e;
            }
            return DatabaseError.CompanyIncomplete;
        }

        public DatabaseError Update()
        {
            return Insert();
        }

        public DatabaseError Delete()
        {
            return SQLiteConnector.DeleteCompany(this) ? DatabaseError.NoError : DatabaseError.CompanyDelete;
        }
    }
}
