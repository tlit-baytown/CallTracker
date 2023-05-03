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
    public class Contact : IDBWrapper
    {
        private static readonly NLog.Logger Logger = logging.LogManager<Contact>.GetLogger();

        [Browsable(false)]
        public int ID { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string MobilePhone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string SecondaryEmail { get; set; } = string.Empty;
        public bool IsDecisionMaker { get; set; } = false;

        public bool IsEmpty
        {
            get
            {
                return FirstName.Equals(string.Empty) || LastName.Equals(string.Empty) || 
                    Title.Equals(string.Empty) || PhoneNumber.Equals(string.Empty) || 
                    Email.Equals(string.Empty);
            }
        }

        public DatabaseError Delete()
        {
            return SQLiteConnector.DeleteContact(this) ? DatabaseError.NoError : DatabaseError.ContactDelete;
        }

        public DatabaseError Insert()
        {
            DatabaseError e;
            if (!IsEmpty)
            {
                if (ID == 0)
                {
                    ID = SQLiteConnector.InsertContact(this);
                    e = ID != 0 ? DatabaseError.NoError : DatabaseError.ContactInsert;
                }
                else
                    e = SQLiteConnector.UpdateContact(this) ? DatabaseError.NoError : DatabaseError.ContactUpdate;
                return e;
            }
            return DatabaseError.ContactIncomplete;
        }

        public DatabaseError Update()
        {
            return Insert();
        }
    }
}
