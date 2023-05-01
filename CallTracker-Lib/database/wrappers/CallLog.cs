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
    public class CallLog : IDBWrapper
    {
        private static readonly NLog.Logger Logger = logging.LogManager<CallLog>.GetLogger();

        [Browsable(false)]
        public int ID { get; set; }

        [Browsable(false)]
        public int CompanyID { get; set; }

        public NoteManager? NoteManager { get; set; } = null;

        public DateTime NextCallDate { get; set; }
        public DateTime LastCallDate { get; set; }
        public DateTime LastContactDate { get; set; }

        public bool IsEmpty => false;

        public DatabaseError Delete()
        {
            return SQLiteConnector.DeleteCallLog(this) ? DatabaseError.NoError : DatabaseError.CallLogDelete;
        }

        public DatabaseError Insert()
        {
            DatabaseError e;
            if (!IsEmpty)
            {
                if (ID == 0)
                {
                    ID = SQLiteConnector.InsertCallLog(this);
                    e = ID != 0 ? DatabaseError.NoError : DatabaseError.CallLogInsert;
                }
                else
                    e = SQLiteConnector.UpdateCallLog(this) ? DatabaseError.NoError : DatabaseError.CallLogUpdate;
                return e;
            }
            return DatabaseError.CallLogIncomplete;
        }

        public DatabaseError Update()
        {
            return Insert();
        }
    }
}
