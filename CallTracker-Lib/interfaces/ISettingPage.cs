using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallTracker_Lib.interfaces
{
    /// <summary>
    /// Defines an interface for a Settings User Control.
    /// <para>A settings page should define methods for saving, loading, and resetting settings pertinent to that page.</para>
    /// </summary>
    public interface ISettingPage
    {
        /// <summary>
        /// The unique name of the settings page.
        /// </summary>
        public string UniqueName { get; }

        /// <summary>
        /// Indicates if the settings have been unchanged and thus do not need saving.
        /// </summary>
        public bool SettingsChanged { get; set; }

        /// <summary>
        /// Defines behavior for saving settings either to disk or to the Settings.resx file.
        /// </summary>
        public void SaveSettings();

        /// <summary>
        /// Defines behavior for loading settings either from disk or from the Settings.resx file.
        /// </summary>
        public void LoadSettings();

        /// <summary>
        /// Defines behavior for resetting settings back to their defaults.
        /// </summary>
        public void ResetSettings();
    }
}
