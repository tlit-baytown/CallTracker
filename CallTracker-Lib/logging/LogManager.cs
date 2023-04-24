using NLog;
using CallTracker_Lib.extensions;

namespace CallTracker_Lib.logging
{
    public class LogManager<T>
    {
        public static Logger GetLogger()
        {
            return LogManager.GetLogger(typeof(T).GetFriendlyName());
        }
    }
}
