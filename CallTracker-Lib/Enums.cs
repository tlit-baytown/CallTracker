using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallTracker_Lib
{
    public class Enums
    {
        /// <summary>
        /// Enum representing the different SQLite Query types that can be built
        /// </summary>
        public enum QType
        {
            /// <summary>
            /// Represents an Insert SQLite Query
            /// </summary>
            INSERT,
            /// <summary>
            /// Represents a Select SQLite Query
            /// </summary>
            SELECT,
            /// <summary>
            /// Represents an Update SQLite Query
            /// </summary>
            UPDATE,
            /// <summary>
            /// Represents a Delete SQLite Query
            /// </summary>
            DELETE
        }
    }
}
