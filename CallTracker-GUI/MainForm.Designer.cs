namespace CallTracker
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.btnFile = new System.Windows.Forms.ToolStripMenuItem();
            this.btnImport = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExport = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCut = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenLogFolderBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.openDBWorker = new System.ComponentModel.BackgroundWorker();
            this.mainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFile,
            this.btnEdit,
            this.btnSettings,
            this.OpenLogFolderBtn});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(1131, 24);
            this.mainMenuStrip.TabIndex = 0;
            // 
            // btnFile
            // 
            this.btnFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnImport,
            this.btnExport,
            this.btnPrint,
            this.toolStripSeparator2,
            this.btnExit});
            this.btnFile.Name = "btnFile";
            this.btnFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F)));
            this.btnFile.Size = new System.Drawing.Size(37, 20);
            this.btnFile.Text = "File";
            // 
            // btnImport
            // 
            this.btnImport.Name = "btnImport";
            this.btnImport.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.btnImport.Size = new System.Drawing.Size(188, 22);
            this.btnImport.Text = "Import...";
            // 
            // btnExport
            // 
            this.btnExport.Name = "btnExport";
            this.btnExport.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.E)));
            this.btnExport.Size = new System.Drawing.Size(188, 22);
            this.btnExport.Text = "Export...";
            // 
            // btnPrint
            // 
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.btnPrint.Size = new System.Drawing.Size(188, 22);
            this.btnPrint.Text = "Print";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(185, 6);
            // 
            // btnExit
            // 
            this.btnExit.Name = "btnExit";
            this.btnExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.btnExit.Size = new System.Drawing.Size(188, 22);
            this.btnExit.Text = "Exit";
            // 
            // btnEdit
            // 
            this.btnEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCut,
            this.btnCopy,
            this.btnPaste});
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.E)));
            this.btnEdit.Size = new System.Drawing.Size(39, 20);
            this.btnEdit.Text = "Edit";
            // 
            // btnCut
            // 
            this.btnCut.Name = "btnCut";
            this.btnCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.btnCut.Size = new System.Drawing.Size(142, 22);
            this.btnCut.Text = "Cut";
            // 
            // btnCopy
            // 
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.btnCopy.Size = new System.Drawing.Size(142, 22);
            this.btnCopy.Text = "Copy";
            // 
            // btnPaste
            // 
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.btnPaste.Size = new System.Drawing.Size(142, 22);
            this.btnPaste.Text = "Paste";
            // 
            // btnSettings
            // 
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(61, 20);
            this.btnSettings.Text = "Settings";
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // OpenLogFolderBtn
            // 
            this.OpenLogFolderBtn.Name = "OpenLogFolderBtn";
            this.OpenLogFolderBtn.Size = new System.Drawing.Size(107, 20);
            this.OpenLogFolderBtn.Text = "Open Log Folder";
            this.OpenLogFolderBtn.Click += new System.EventHandler(this.OpenLogFolderBtn_Click);
            // 
            // openDBWorker
            // 
            this.openDBWorker.WorkerReportsProgress = true;
            this.openDBWorker.WorkerSupportsCancellation = true;
            this.openDBWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.openDBWorker_DoWork);
            this.openDBWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.openDBWorker_RunWorkerCompleted);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1131, 586);
            this.Controls.Add(this.mainMenuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "MainForm";
            this.Text = "Call Tracker";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip mainMenuStrip;
        private ToolStripMenuItem btnFile;
        private ToolStripMenuItem btnImport;
        private ToolStripMenuItem btnExport;
        private ToolStripMenuItem btnPrint;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem btnExit;
        private ToolStripMenuItem btnEdit;
        private ToolStripMenuItem btnCut;
        private ToolStripMenuItem btnCopy;
        private ToolStripMenuItem btnPaste;
        private ToolStripMenuItem btnSettings;
        private System.ComponentModel.BackgroundWorker openDBWorker;
        private ToolStripMenuItem OpenLogFolderBtn;
    }
}