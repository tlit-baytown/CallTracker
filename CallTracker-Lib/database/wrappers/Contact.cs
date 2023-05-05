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
    public class Contact : IDbWrapper
    {
        private static readonly NLog.Logger Logger = logging.LogManager<Contact>.GetLogger();

        [Browsable(false)]
        public int Id { get; set; }
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
            return SqLiteConnector.DeleteContact(this) ? DatabaseError.NoError : DatabaseError.ContactDelete;
        }

        public DatabaseError Insert()
        {
            DatabaseError e;
            if (!IsEmpty)
            {
                if (Id == 0)
                {
                    Id = SqLiteConnector.InsertContact(this);
                    e = Id != 0 ? DatabaseError.NoError : DatabaseError.ContactInsert;
                }
                else
                    e = SqLiteConnector.UpdateContact(this) ? DatabaseError.NoError : DatabaseError.ContactUpdate;
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
