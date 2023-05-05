using System.Data;
using CallTracker_Lib.Properties;
using System.Data.SQLite;
using CallTracker_Lib.logging;
using System.Text;

namespace CallTracker_Lib.database
{
    public class DbConnection
    {
        private static readonly NLog.Logger Logger = LogManager<DbConnection>.GetLogger();

        private static SQLiteConnection? _sqlite = null;
        private static string? _connectionString;
        private static bool _lastConnectionSuccessful = false;

        private DbConnection() { }

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

        /// <summary>
        /// Creates the database schema for a new SQLite database.
        /// <returns><c>True</c> if the schema was created successfully; <c>False</c>, otherwise.</returns>
        /// <exception cref="InvalidOperationException">Thrown if a database connection has not been previously established before calling
        /// <see cref="CreateSchema"/></exception>
        /// </summary>
        public static bool CreateSchema()
        {
            //If the last connection to a database has not been established, we cannot continue creating the schema for the DB.
            if (!_lastConnectionSuccessful)
            {
                InvalidOperationException ex = new("The DBConnection has not been initialized with a connection!");
                Logger.Error(ex, "There is not a valid database connection for CreateSchema().");
                throw ex;
            }
            
            try
            {
                var affectedRows = 0;
                var sql = Resources.DBSchemaString;
                using var conn = new SQLiteConnection(_connectionString);
                conn.Open();
                using SQLiteCommand cmd = new(sql, conn);
                cmd.CommandType = CommandType.Text;
                affectedRows = cmd.ExecuteNonQuery();
                Logger.Info($"Schema created successfully on database: {_connectionString} -> " +
                            $"{affectedRows} rows updated/inserted.");
                
                conn.Close();
                return true;
            }
            catch (Exception e)
            {
                Logger.Error(e, $"Could not create the database schema on database: {_connectionString}");
                return false;
            }
        }

        public static string? GetConnectionString()
        {
            return _connectionString;
        }
    }
}