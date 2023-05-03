using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallTracker_Lib.extensions
{
    /// <summary>
    /// Extension class used for enums to get a description string.
    /// </summary>
    public static class EnumExtensions
    {
        public static string ToDescriptionString<T>(this T val) where T : Enum
        {
            if (val == null)
                return string.Empty;
            try
            {
                DescriptionAttribute[] attributes = (DescriptionAttribute[])val
                .GetType()
                .GetField(val.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false);
                return attributes.Length > 0 ? attributes[0].Description : string.Empty;
            }
            catch (Exception) { return string.Empty; }
        }
    }
}
