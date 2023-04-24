using NLog;
using NLog.Config;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallTracker_Lib.logging
{
    public class LogInitializer
    {
        private static bool _isInitialized = false;

        /// <summary>
        /// Initialize the application logger with the specified log file.
        /// This method should only be called once.
        /// </summary>
        /// <param name="logFilePath">The path to the file that should be used for logging.</param>
        public static void Initialize(string logFilePath)
        {
            if (_isInitialized) return; //Don't initialize logging more than once!

            var config = new LoggingConfiguration();

            //Targets for logging
            var logFile = new FileTarget("logFile") { FileName = logFilePath };
            var memoryTarget = new MemoryTarget("memoryLog")
            {
                Layout = "${longdate} | ${level:uppercase=true}: ${message}",
                MaxLogsCount = 1000
            };

            //Rules for mapping loggers to targets
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logFile);
            config.AddRuleForOneLevel(LogLevel.Info, memoryTarget);

            //Apply config
            LogManager.Configuration = config;

            _isInitialized = true;
        }

        /// <summary>
        /// Get the default log file full path with filename. This method has a side-effect wherein it will create
        /// the log directory if it does not exist.
        /// </summary>
        /// <param name="includeFileName">Should the path include the current log file name?</param>
        /// <returns>The full path (with filename) to the current log file.</returns>
        public static string GetDefaultCurrentLog(bool includeFileName = true)
        {
            string logPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CallTracker");
            Directory.CreateDirectory(logPath);
            string fileName = $"{DateTime.Now:MM-dd-yyyy}.log";

            return includeFileName ? Path.Combine(logPath, fileName) : logPath;
        }

        /// <summary>
        /// Get the logger for this class.
        /// </summary>
        /// <returns>The <see cref="Logger"/> for the <see cref="LogInitializer"/> class.</returns>
        public static Logger GetLogger()
        {
            return LogManager.GetCurrentClassLogger();
        }

        /// <summary>
        /// Get the last log message written to the Application logger. Useful for displaying in a 
        /// MessageBox or Status Label.
        /// </summary>
        /// <returns>The last log message recorded by the application -or- <see cref="string.Empty"/> if the memory log could not be found.</returns>
        public static string GetLastLogMessage()
        {
            var target = LogManager.Configuration.FindTargetByName<MemoryTarget>("memoryLog");
            if (target == null)
                return string.Empty;

            var logEvents = target?.Logs;

            if (logEvents == null)
                return string.Empty;

            return logEvents.Last();
        }
    }
}
