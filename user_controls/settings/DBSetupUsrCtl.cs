using CallTracker_GUI.Properties;
using CallTracker_Lib.database;
using CallTracker_Lib.interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CallTracker_GUI.user_controls
{
    public partial class DBSetupUsrCtl : UserControl, ISettingPage
    {
        public string UniqueName { get => "db_setup"; }
        public bool SettingsUnchanged { get; set; }

        private string _dbPath = string.Empty;
        private string _connectString = string.Empty;
        private bool _connectionSuccessful = false;

        public DBSetupUsrCtl()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
        }

        private void DBSetupUsrCtl_Load(object sender, EventArgs e)
        {
            LoadSettings();
        }

        public void LoadSettings()
        {
            if (Settings.Default.DBPath.Equals(string.Empty))
            {
                lblDBPath.Text = "No Database Found.";
                LoadTablesBtn.Enabled = false;
                CreateDBBtn.Enabled = true;
                CloseDatabaseBtn.Enabled = false;
            }
            else
            {
                lblDBPath.Text = Settings.Default.DBPath;
                CreateDBBtn.Enabled = false;
                LoadTablesBtn.Enabled = true;
                CloseDatabaseBtn.Enabled = true;

                _connectionSuccessful = DBConnection.TouchFile(Settings.Default.ConnectionString);
            }
        }

        public void ResetSettings()
        {
            throw new NotImplementedException();
        }

        public void SaveSettings()
        {
            Settings.Default.DBPath = _dbPath;
            Settings.Default.ConnectionString = _connectString;
            Settings.Default.Save();
        }

        private void CreateDBBtn_Click(object sender, EventArgs e)
        {
            if (FileDlgSaveDB.ShowDialog() == DialogResult.OK)
            {
                bool success = CreateOpenDB(FileDlgSaveDB.FileName);
                if (!success)
                    MessageBox.Show(this, "The database file could not be saved.", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenDBBtn_Click(object sender, EventArgs e)
        {
            if (FileDlgOpenDB.ShowDialog() == DialogResult.OK)
            {
                bool success = CreateOpenDB(FileDlgOpenDB.FileName);
                if (!success)
                    MessageBox.Show(this, "The database file could not be opened or read from.", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CreateOpenDB(string fileName)
        {
            _dbPath = fileName;
            _connectString = DBConnection.CreateConnectionString(fileName);
            lblDBPath.Text = _dbPath;
            return DBConnection.TouchFile(_connectString); //test and make sure the connection could be created.
        }

        private void LoadTablesBtn_Click(object sender, EventArgs e)
        {

        }

        private void CloseDatabaseBtn_Click(object sender, EventArgs e)
        {
            if (_dbPath.Equals(string.Empty))
            {
                MessageBox.Show(this, "There is no database open that can be closed.", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                _dbPath = string.Empty;
                _connectString = string.Empty;
                lblDBPath.Text = "No Database Found.";
                SetButtons();
            }
        }

        private void SetButtons()
        {
            if (_connectionSuccessful)
            {
                CreateDBBtn.Enabled = false;
                LoadTablesBtn.Enabled = false;
                OpenDBBtn.Enabled = false;
                CloseDatabaseBtn.Enabled = true;
            }
            else
            {

            }
        }
    }
}
