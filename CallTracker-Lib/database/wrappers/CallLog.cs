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
    public class CallLog : IDbWrapper
    {
        private static readonly NLog.Logger Logger = logging.LogManager<CallLog>.GetLogger();

        [Browsable(false)]
        public int Id { get; set; }

        [Browsable(false)]
        public int CompanyId { get; set; }

        public NoteManager? NoteManager { get; set; } = null;

        public DateTime NextCallDate { get; set; }
        public DateTime LastCallDate { get; set; }
        public DateTime LastContactDate { get; set; }

        public bool IsEmpty => false;

        public DatabaseError Delete()
        {
            return SqLiteConnector.DeleteCallLog(this) ? DatabaseError.NoError : DatabaseError.CallLogDelete;
        }

        public DatabaseError Insert()
        {
            DatabaseError e;
            if (!IsEmpty)
            {
                if (Id == 0)
                {
                    Id = SqLiteConnector.InsertCallLog(this);
                    e = Id != 0 ? DatabaseError.NoError : DatabaseError.CallLogInsert;
                }
                else
                    e = SqLiteConnector.UpdateCallLog(this) ? DatabaseError.NoError : DatabaseError.CallLogUpdate;
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
