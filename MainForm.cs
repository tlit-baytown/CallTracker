using CallTracker_GUI.Properties;
using CallTracker_GUI.subforms;
using CallTracker_Lib.database;
using System.Diagnostics;

namespace CallTracker
{
    public partial class MainForm : Form
    {
        private DBConnection? _connectionObj = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            dbWorker.RunWorkerAsync(); //Attempt to open the last database connection
        }

        private void DbWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            _connectionObj = new DBConnection(Settings.Default.ConnectionString);
            dbWorker.ReportProgress(100);
        }

        private void DbWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (_connectionObj == null || !_connectionObj.IsConnected())
            {
                MessageBox.Show("The database could not be opened. The application settings will now open so you can set the database up.");
                new SettingsForm().ShowDialog();
            }
        }

        #region Menu Strip Buttons
        private void btnSettings_Click(object sender, EventArgs e)
        {
            new SettingsForm().ShowDialog();
        }

        private void OpenLogFolderBtn_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", CallTracker_Lib.logging.LogInitializer.GetDefaultCurrentLog(false));
        }
        #endregion
    }
}