using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallTracker_GUI
{
    public class Utility
    {
        private static readonly NLog.Logger Logger = CallTracker_Lib.logging.LogManager<Utility>.GetLogger();

        /// <summary>
        /// Convert the BASE64 representation of an image into a usable <see cref="Image"/> object for displaying.
        /// </summary>
        /// <param name="base64">The image as a base64 string.</param>
        /// <returns>An image or <c>null</c> if <paramref name="base64"/> is an invalid string.</returns>
        public static Image? FromBase64String(string base64)
        {
            try
            {
                using MemoryStream ms = new MemoryStream(Convert.FromBase64String(base64));
                return Image.FromStream(ms);
            } catch (Exception ex)
            {
                Logger.Error(ex, "Error converting BASE64 string to image. Perhaps it's not the correct format?");
                return null;
            }
        }

    }
}
