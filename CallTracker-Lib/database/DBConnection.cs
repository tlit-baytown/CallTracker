using CallTracker_Lib.Properties;
using System.Data.SQLite;
using CallTracker_Lib.logging;
using System.Text;

namespace CallTracker_Lib.database
{
    public class DBConnection
    {
        private static readonly NLog.Logger Logger = LogManager<DBConnection>.GetLogger();

        private static SQLiteConnection? _sqlite = null;
        private static string? _connectionString;
        private static bool _lastConnectionSuccessful = false;

        private DBConnection() { }

        public static SQLiteConnection? CreateConnection(string connectionString)
        {
            _connectionString = connectionString;

            _sqlite = new SQLiteConnection(_connectionString);
            try
            {
                _sqlite.Open();
                _lastConnectionSuccessful = true;
            }
            catch (Exception)
            {
                Logger.Log(NLog.LogLevel.Fatal, "The SQLite connection could not be opened. Check the file path and try again.");
                _lastConnectionSuccessful = false;
                return null;
            }
            finally
            {
                _sqlite.Close();
            }

            return _sqlite;
        }

        public static bool IsConnected() { return _lastConnectionSuccessful; }

        public static string CreateConnectionString(string filePath)
        {
            StringBuilder bldr = new();
            bldr = bldr.Append("Data Source=").Append(filePath).Append(";Version=3;Pooling=True;Max Pool Size=100;DateTimeFormat=Ticks;");
            return bldr.ToString();
        }

        /// <summary>
        /// Opens and then immediatly closes a connection on the given connection string. 
        /// This allows the file to be created if it doesn't already exist or verified that it can be opened.
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns>True: the file was created or already existed. False: the file could not be created or did not exist.</returns>
        public static bool TouchFile(string connectionString)
        {
            CreateConnection(connectionString);
            return _lastConnectionSuccessful;
        }

        /// <summary>
        /// Opens and then immediatly closes a connection on the given connection string. 
        /// This allows the file to be created if it doesn't already exist or verified that it can be opened.
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns>True: the file was created or already existed. False: the file could not be created or did not exist.</returns>
        public static bool TouchFileWithPath(string filePath)
        {
            string connectionString = CreateConnectionString(filePath);
            return TouchFile(connectionString);
        }

        public static string? GetConnectionString()
        {
            return _connectionString;
        }
    }
}