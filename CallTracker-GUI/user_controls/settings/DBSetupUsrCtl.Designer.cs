namespace CallTracker_GUI.user_controls
{
    partial class DBSetupUsrCtl
{
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.grpDBSetup = new System.Windows.Forms.GroupBox();
            this.OpenDBBtn = new System.Windows.Forms.Button();
            this.CloseDBBtn = new System.Windows.Forms.Button();
            this.CreateDBBtn = new System.Windows.Forms.Button();
            this.lblDBPath = new System.Windows.Forms.Label();
            this.FileDlgOpenDB = new System.Windows.Forms.OpenFileDialog();
            this.ClearDBBtn = new System.Windows.Forms.Button();
            this.grpDBMaintenance = new System.Windows.Forms.GroupBox();
            this.FileDlgSaveDB = new System.Windows.Forms.SaveFileDialog();
            this.OpenFolderBtn = new System.Windows.Forms.Button();
            this.grpDBSetup.SuspendLayout();
            this.grpDBMaintenance.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpDBSetup
            // 
            this.grpDBSetup.Controls.Add(this.OpenFolderBtn);
            this.grpDBSetup.Controls.Add(this.OpenDBBtn);
            this.grpDBSetup.Controls.Add(this.CloseDBBtn);
            this.grpDBSetup.Controls.Add(this.CreateDBBtn);
            this.grpDBSetup.Controls.Add(this.lblDBPath);
            this.grpDBSetup.Location = new System.Drawing.Point(3, 3);
            this.grpDBSetup.Name = "grpDBSetup";
            this.grpDBSetup.Size = new System.Drawing.Size(594, 109);
            this.grpDBSetup.TabIndex = 0;
            this.grpDBSetup.TabStop = false;
            this.grpDBSetup.Text = "Database Setup";
            // 
            // OpenDBBtn
            // 
            this.OpenDBBtn.Location = new System.Drawing.Point(217, 21);
            this.OpenDBBtn.Name = "OpenDBBtn";
            this.OpenDBBtn.Size = new System.Drawing.Size(145, 23);
            this.OpenDBBtn.TabIndex = 5;
            this.OpenDBBtn.Text = "Open Database...";
            this.OpenDBBtn.UseVisualStyleBackColor = true;
            this.OpenDBBtn.Click += new System.EventHandler(this.OpenDBBtn_Click);
            // 
            // CloseDBBtn
            // 
            this.CloseDBBtn.Enabled = false;
            this.CloseDBBtn.Location = new System.Drawing.Point(368, 21);
            this.CloseDBBtn.Name = "CloseDBBtn";
            this.CloseDBBtn.Size = new System.Drawing.Size(145, 23);
            this.CloseDBBtn.TabIndex = 4;
            this.CloseDBBtn.Text = "Close Database";
            this.CloseDBBtn.UseVisualStyleBackColor = true;
            this.CloseDBBtn.Click += new System.EventHandler(this.CloseDBBtn_Click);
            // 
            // CreateDBBtn
            // 
            this.CreateDBBtn.Location = new System.Drawing.Point(6, 21);
            this.CreateDBBtn.Name = "CreateDBBtn";
            this.CreateDBBtn.Size = new System.Drawing.Size(205, 23);
            this.CreateDBBtn.TabIndex = 2;
            this.CreateDBBtn.Text = "Create Database...";
            this.CreateDBBtn.UseVisualStyleBackColor = true;
            this.CreateDBBtn.Click += new System.EventHandler(this.CreateDBBtn_Click);
            // 
            // lblDBPath
            // 
            this.lblDBPath.AutoEllipsis = true;
            this.lblDBPath.AutoSize = true;
            this.lblDBPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblDBPath.Location = new System.Drawing.Point(6, 47);
            this.lblDBPath.Name = "lblDBPath";
            this.lblDBPath.Size = new System.Drawing.Size(47, 16);
            this.lblDBPath.TabIndex = 1;
            this.lblDBPath.Text = "<Path>";
            // 
            // FileDlgOpenDB
            // 
            this.FileDlgOpenDB.DefaultExt = "sqlite";
            this.FileDlgOpenDB.FileName = "calls.sqlite";
            this.FileDlgOpenDB.Filter = "SQLite Database (*.sqlite) | *.sqlite";
            // 
            // ClearDBBtn
            // 
            this.ClearDBBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ClearDBBtn.Enabled = false;
            this.ClearDBBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearDBBtn.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ClearDBBtn.ForeColor = System.Drawing.Color.Black;
            this.ClearDBBtn.Location = new System.Drawing.Point(6, 22);
            this.ClearDBBtn.Name = "ClearDBBtn";
            this.ClearDBBtn.Size = new System.Drawing.Size(138, 23);
            this.ClearDBBtn.TabIndex = 3;
            this.ClearDBBtn.Text = "Clear Database";
            this.ClearDBBtn.UseVisualStyleBackColor = false;
            // 
            // grpDBMaintenance
            // 
            this.grpDBMaintenance.Controls.Add(this.ClearDBBtn);
            this.grpDBMaintenance.Location = new System.Drawing.Point(3, 118);
            this.grpDBMaintenance.Name = "grpDBMaintenance";
            this.grpDBMaintenance.Size = new System.Drawing.Size(594, 57);
            this.grpDBMaintenance.TabIndex = 1;
            this.grpDBMaintenance.TabStop = false;
            this.grpDBMaintenance.Text = "Database Maintenance";
            // 
            // FileDlgSaveDB
            // 
            this.FileDlgSaveDB.CreatePrompt = true;
            this.FileDlgSaveDB.DefaultExt = "sqlite";
            this.FileDlgSaveDB.FileName = "calls.sqlite";
            this.FileDlgSaveDB.Filter = "SQLite Database (*.sqlite) | *.sqlite";
            // 
            // OpenFolderBtn
            // 
            this.OpenFolderBtn.Location = new System.Drawing.Point(383, 78);
            this.OpenFolderBtn.Name = "OpenFolderBtn";
            this.OpenFolderBtn.Size = new System.Drawing.Size(205, 25);
            this.OpenFolderBtn.TabIndex = 6;
            this.OpenFolderBtn.Text = "Open Containing Folder";
            this.OpenFolderBtn.UseVisualStyleBackColor = true;
            this.OpenFolderBtn.Click += new System.EventHandler(this.OpenFolderBtn_Click);
            // 
            // DBSetupUsrCtl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpDBMaintenance);
            this.Controls.Add(this.grpDBSetup);
            this.Name = "DBSetupUsrCtl";
            this.Size = new System.Drawing.Size(600, 400);
            this.Load += new System.EventHandler(this.DBSetupUsrCtl_Load);
            this.grpDBSetup.ResumeLayout(false);
            this.grpDBSetup.PerformLayout();
            this.grpDBMaintenance.ResumeLayout(false);
            this.ResumeLayout(false);

    }

        #endregion

        private GroupBox grpDBSetup;
        private Button CreateDBBtn;
        private Label lblDBPath;
        private OpenFileDialog FileDlgOpenDB;
        private Button ClearDBBtn;
        private GroupBox grpDBMaintenance;
        private Button CloseDBBtn;
        private SaveFileDialog FileDlgSaveDB;
        private Button OpenDBBtn;
        private Button OpenFolderBtn;
    }
}
