using NLog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CallTracker_Lib.utility.Enums;

namespace CallTracker_Lib.database
{
    /// <summary>
    /// This is a class responsible for building dynamic SQL queries using one static method: <see cref="BuildQuery(QType, string, ArrayList, ArrayList, string)"/>
    /// </summary>
    public class Queries
    {
        private static readonly NLog.Logger Logger = logging.LogManager<Queries>.GetLogger();

        /// <summary>
        /// Builds a query string based on the supplied arguments.
        /// </summary>
        /// <param name="qtype">The type of query to build. See <see cref="QType"/> for valid options.</param>
        /// <param name="tableName">The table name this query is for.</param>
        /// <param name="values">A <see cref="ArrayList"/> of values for Inserting or Updating.</param>
        /// <param name="columnNames">A <see cref="ArrayList"/> of column names that should be considered.</param>
        /// <param name="condition">The condition, if any, the query should include.</param>
        /// <returns>A new string that represents the query and can be passed to a DB connection for execution.</returns>
        public static string BuildQuery(QType qtype, string tableName, ArrayList? values = null, ArrayList? columnNames = null, string? condition = null)
        {
            StringBuilder s = new StringBuilder();

            switch (qtype)
            {
                case QType.INSERT:
                    {
                        if (columnNames != null)
                        {
                            s.Append("INSERT INTO ");
                            s.Append($"{tableName} (");

                            for (int i = 0; i <= columnNames.Count - 2; i++)
                                s.Append($"{columnNames[i]}, ");
                            s.Append($"{columnNames[columnNames.Count - 1]}) ");

                            s.Append("VALUES (");

                            for (int i = 0; i <= columnNames.Count - 2; i++)
                                s.Append("@").Append($"{i}, ");
                            s.Append("@").Append($"{columnNames.Count - 1});");

                            return s.ToString();
                        }
                        else
                            return "NOTHING";
                    }
                case QType.UPDATE:
                    {
                        if (values != null && columnNames != null && condition != null)
                        {
                            s.Append($"UPDATE {tableName} SET ");

                            for (int i = 0; i <= columnNames.Count - 2; i++)
                                s.Append($"{columnNames[i]} = {values[i]}, ");
                            s.Append($"{columnNames[columnNames.Count - 1]} = {values[values.Count - 1]} ");

                            s.Append($"WHERE ({condition});");
                            return s.ToString();
                        }
                        else if (columnNames != null && condition != null)
                        {
                            s.Append($"UPDATE {tableName} SET ");

                            for (int i = 0; i < columnNames.Count - 1; i++)
                            {
                                s.Append($"{columnNames[i]} = @{i}, ");
                            }
                            s.Append($"{columnNames[columnNames.Count - 1]} = @{columnNames.Count - 1} ");

                            s.Append($"WHERE ({condition});");
                            return s.ToString();
                        }
                        else
                        {
                            return "NOTHING";
                        }
                    }
                case QType.DELETE:
                    {
                        if (condition != null)
                        {
                            s.Append($"DELETE FROM {tableName} WHERE ({condition});");
                            return s.ToString();
                        }
                        else
                        {
                            return "NOTHING";
                        }
                    }
                case QType.SELECT:
                    {
                        if (columnNames != null)
                        {
                            if (condition != null)
                            {
                                s.Append("SELECT ");
                                for (int i = 0; i < columnNames.Count - 1; i++)
                                    s.Append($"{columnNames[i]}, ");
                                s.Append($"{columnNames[columnNames.Count - 1]} FROM {tableName} WHERE ({condition});");
                            }
                            else
                            {
                                s.Append("SELECT ");
                                for (int i = 0; i < columnNames.Count - 1; i++)
                                    s.Append($"{columnNames[i]}, ");
                                s.Append($"{columnNames[columnNames.Count - 1]} FROM {tableName};");
                            }
                        }
                        else if (condition != null)
                        {
                            s.Append($"SELECT * FROM {tableName} WHERE ({condition});");
                        }
                        else
                        {
                            s.Append($"SELECT * FROM {tableName};");
                        }
                        return s.ToString();
                    }
                default:
                    {
                        return "NOTHING";
                    }
            }
        }
    }
}
