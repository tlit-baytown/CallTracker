using CallTracker_Lib.interfaces;
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
    public class AppOwner : IDBWrapper
    {

        [Browsable(false)]
        public int ID { get; set; }

        /// <summary>
        /// The name for the application's owner.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The logo (in base64 text format) for the application's owner.
        /// </summary>
        public string Base64Logo { get; set; } = string.Empty;

        /// <summary>
        /// The phone number for the application's owner.
        /// </summary>
        public string PhoneNumber { get; set; } = string.Empty;

        public bool IsEmpty
        {
            get
            {
                return Name.Equals(string.Empty) || PhoneNumber.Equals(string.Empty);
            }
        }

        public List<IDBWrapper> AssociatedObjects => new List<IDBWrapper>();

        public AppOwner() { }

        public AppOwner(int id, string name, string base64Logo, string phoneNumber)
        {
            ID = id;
            Name = name;
            Base64Logo = base64Logo;
        }

        public AppOwner(int id, string name, string phoneNumber) : this(id, name, string.Empty, phoneNumber) { }
        public AppOwner(int id, string name) : this(id, name, string.Empty, string.Empty) { }

        public override string ToString()
        {
            if (!IsEmpty)
                return $"{Name}: {PhoneNumber}";
            return "Invalid Application Owner (...)";
        }

        public static AppOwner? GetObject(int id)
        {
            throw new NotImplementedException();
        }

        public DatabaseError Delete()
        {
            return SQLiteConnector.DeleteAppOwner(this) ? DatabaseError.NoError : DatabaseError.AppOwnerDelete;
        }

        public DatabaseError Insert()
        {
            DatabaseError e;
            if (!IsEmpty)
            {
                if (ID == 0)
                {
                    ID = SQLiteConnector.InsertAppOwner(this);
                    e = ID != 0 ? DatabaseError.NoError : DatabaseError.AppOwnerInsert;
                }
                else
                    e = SQLiteConnector.UpdateAppOwner(this) ? DatabaseError.NoError : DatabaseError.AppOwnerUpdate;
                return e;
            }
            else
                return DatabaseError.AppOwnerIncomplete;
        }

        public DatabaseError Update()
        {
            return Insert();
        }
    }
}
