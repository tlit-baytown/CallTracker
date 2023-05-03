﻿using CallTracker_GUI.Properties;
using CallTracker_Lib.database;
using CallTracker_Lib.interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        public bool SettingsChanged { get; set; } = false;

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
            }
            else
            {
                _dbPath = Settings.Default.DBPath;
                lblDBPath.Text = _dbPath;
                _connectionSuccessful = DBConnection.TouchFile(Settings.Default.ConnectionString);

                if (!_connectionSuccessful)
                    MessageBox.Show(this, "The database file could not be opened or read from.", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            SetButtons();
        }

        public void ResetSettings()
        {
            lblDBPath.Text = "No Database Found";
            _dbPath = string.Empty;
            _connectString = string.Empty;
            _connectionSuccessful = false;
            SetButtons();
        }

        public void SaveSettings()
        {
            Settings.Default.DBPath = _dbPath;
            Settings.Default.ConnectionString = _connectString;
            Settings.Default.Save();
            SettingsChanged = false;
        }

        private void CreateDBBtn_Click(object sender, EventArgs e)
        {
            if (FileDlgSaveDB.ShowDialog() == DialogResult.OK)
            {
                _dbPath = FileDlgSaveDB.FileName;
                _connectionSuccessful = DBConnection.TouchFileWithPath(_dbPath);

                if (!_connectionSuccessful)
                    MessageBox.Show(this, "The database file could not be saved.", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    lblDBPath.Text = _dbPath;
                    _connectString = DBConnection.CreateConnectionString(_dbPath);
                    SettingsChanged = true;

                    //TODO: Actually create the db schema in the empty file.
                }
            }
            SetButtons();
        }

        private void OpenDBBtn_Click(object sender, EventArgs e)
        {
            if (FileDlgOpenDB.ShowDialog() == DialogResult.OK)
            {
                _dbPath = FileDlgOpenDB.FileName;
                _connectionSuccessful = DBConnection.TouchFileWithPath(_dbPath);

                if (!_connectionSuccessful)
                    MessageBox.Show(this, "The database file could not be opened or read from.", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    lblDBPath.Text = _dbPath;
                    _connectString = DBConnection.CreateConnectionString(_dbPath);
                    Settings.Default.ConnectionString = _connectString;
                    SettingsChanged = true;
                }
            }
            SetButtons();
        }

        private void CloseDBBtn_Click(object sender, EventArgs e)
        {
            if (_dbPath.Equals(string.Empty))
                MessageBox.Show(this, "There is no database open that can be closed.", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                _dbPath = string.Empty;
                _connectString = string.Empty;
                lblDBPath.Text = "No Database Found.";
                _connectionSuccessful = false;
                SettingsChanged = true;
            }
            SetButtons();
        }

        private void OpenFolderBtn_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", _dbPath[.._dbPath.LastIndexOf('\\')]);
        }

        private void SetButtons()
        {
            CreateDBBtn.Enabled = !_connectionSuccessful;
            OpenDBBtn.Enabled = !_connectionSuccessful;
            CloseDBBtn.Enabled = !CreateDBBtn.Enabled;
        }
    }
}
