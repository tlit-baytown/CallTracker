using CallTracker_Lib.interfaces;
using CallTracker_Lib.utility;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallTracker_Lib.database.wrappers
{
    public class CallLog : IDBWrapper
    {
        private static readonly NLog.Logger Logger = logging.LogManager<CallLog>.GetLogger();

        [Browsable(false)]
        public int ID { get; set; }

        public int CompanyID { get; set; }

        public string Notes { get; set; } = string.Empty;
        public DateTime NextCallDate { get; set; }
        public DateTime LastCallDate { get; set; }
        public DateTime LastContactDate { get; set; }

        public bool IsEmpty => throw new NotImplementedException();

        public Enums.DatabaseError Delete()
        {
            throw new NotImplementedException();
        }

        public Enums.DatabaseError Insert()
        {
            throw new NotImplementedException();
        }

        public Enums.DatabaseError Update()
        {
            throw new NotImplementedException();
        }
    }
}
