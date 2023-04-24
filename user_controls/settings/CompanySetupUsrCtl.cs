﻿using CallTracker_Lib.interfaces;
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
    public partial class CompanySetupUsrCtl : UserControl, ISettingPage
    {
        public CompanySetupUsrCtl()
        {
            InitializeComponent();
        }

        public string UniqueName { get => "comp_settings"; }

        public bool SettingsUnchanged { get; set; }

        public void LoadSettings()
        {
            
        }

        public void ResetSettings()
        {
            
        }

        public void SaveSettings()
        {
            
        }
    }
}
