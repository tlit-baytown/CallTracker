using CallTracker_GUI;
using CallTracker_GUI.Properties;
using CallTracker_GUI.subforms;
using CallTracker_Lib.database;
using CallTracker_Lib.logging;
using System.Diagnostics;

namespace CallTracker
{
    public partial class MainForm : Form
    {
        private readonly NLog.Logger Logger = LogManager<MainForm>.GetLogger();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadBackgroundImage();
            openDBWorker.RunWorkerAsync(); //Attempt to open the last database connection
        }

        private void openDBWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            bool result = DBConnection.TouchFile(Settings.Default.ConnectionString);
            openDBWorker.ReportProgress(100, result);
        }

        private void openDBWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null && e.Result is bool)
            {
                bool connected = (bool)e.Result;
                if (!connected)
                {
                    MessageBox.Show("The database could not be opened. The application settings will now open so you can set the database up.");
                    new SettingsForm().ShowDialog();
                }
            }
        }

        private void LoadBackgroundImage()
        {
            Image? i = Utility.FromBase64String(Settings.Default.CompLogo_Base64);
            if (i == null)
                return;

            BackgroundImage = i;
            BackgroundImageLayout = ImageLayout.Center;
        }

        #region Menu Strip Buttons
        private void btnSettings_Click(object sender, EventArgs e)
        {
            SettingsForm? f = Application.OpenForms.OfType<SettingsForm>().FirstOrDefault();
            if (f != null)
            {
                f.Activate();
                Logger.Warn("MainForm attempted to open another settings window. Only one window can be open at a time.");
            }
            else
                new SettingsForm().Show();
        }

        private void OpenLogFolderBtn_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", CallTracker_Lib.logging.LogInitializer.GetDefaultCurrentLog(false));
        }
        #endregion
    }
}