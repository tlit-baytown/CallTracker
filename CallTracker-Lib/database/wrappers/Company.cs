using CallTracker_Lib.interfaces;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CallTracker_Lib.Enums;

namespace CallTracker_Lib.database.wrappers
{
    public class Company : IDbWrapper
    {
        private static readonly NLog.Logger Logger = logging.LogManager<Company>.GetLogger();

        [Browsable(false)]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string BusinessPhone { get; set; } = string.Empty;
        public int PrimaryContactId { get; set; }
        public Contact? PrimaryContact { get; set; } = null;
        public string AdditionalContacts { get; set; } = "NA";
        public Address? CompanyAddress { get; set; } = null;
        public string WebsiteUrl { get; set; } = string.Empty;
        public string Base64Logo { get; set; } = string.Empty;
        public string LinkedInUrl { get; set; } = string.Empty;
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

                if (PrimaryContact.Id == 0)
                    e = PrimaryContact.Insert();
                else
                    e = PrimaryContact.Update();

                if (e != DatabaseError.NoError)
                    return e;

                PrimaryContactId = PrimaryContact.Id;
                #endregion
                if (Id == 0)
                {
                    
                    Id = SqLiteConnector.InsertCompany(this);
                    e = Id != 0 ? DatabaseError.NoError : DatabaseError.CompanyInsert;
                }
                else
                    e = SqLiteConnector.UpdateCompany(this) ? DatabaseError.NoError : DatabaseError.CompanyUpdate;
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
            return SqLiteConnector.DeleteCompany(this) ? DatabaseError.NoError : DatabaseError.CompanyDelete;
        }
    }
}
