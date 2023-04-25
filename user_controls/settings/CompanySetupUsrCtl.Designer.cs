namespace CallTracker_GUI.user_controls
{
    partial class CompanySetupUsrCtl
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
            this.grpCompInfo = new System.Windows.Forms.GroupBox();
            this.lblCompName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.txtPhoneNumber = new System.Windows.Forms.MaskedTextBox();
            this.lblLogo = new System.Windows.Forms.Label();
            this.btnUploadLogo = new System.Windows.Forms.Button();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.grpLogoBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grpCompInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.grpLogoBox.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpCompInfo
            // 
            this.grpCompInfo.Controls.Add(this.btnUploadLogo);
            this.grpCompInfo.Controls.Add(this.lblLogo);
            this.grpCompInfo.Controls.Add(this.txtPhoneNumber);
            this.grpCompInfo.Controls.Add(this.txtCompanyName);
            this.grpCompInfo.Controls.Add(this.label1);
            this.grpCompInfo.Controls.Add(this.lblCompName);
            this.grpCompInfo.Location = new System.Drawing.Point(3, 3);
            this.grpCompInfo.Name = "grpCompInfo";
            this.grpCompInfo.Size = new System.Drawing.Size(594, 123);
            this.grpCompInfo.TabIndex = 0;
            this.grpCompInfo.TabStop = false;
            this.grpCompInfo.Text = "Company Information";
            // 
            // lblCompName
            // 
            this.lblCompName.AutoSize = true;
            this.lblCompName.Location = new System.Drawing.Point(6, 28);
            this.lblCompName.Name = "lblCompName";
            this.lblCompName.Size = new System.Drawing.Size(97, 16);
            this.lblCompName.TabIndex = 0;
            this.lblCompName.Text = "Company Name: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Office Phone Number: ";
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Location = new System.Drawing.Point(140, 25);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(448, 23);
            this.txtCompanyName.TabIndex = 2;
            this.txtCompanyName.TextChanged += new System.EventHandler(this.txtCompanyName_TextChanged);
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Location = new System.Drawing.Point(140, 53);
            this.txtPhoneNumber.Mask = "(999) 000-0000";
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(84, 23);
            this.txtPhoneNumber.TabIndex = 4;
            this.txtPhoneNumber.TextChanged += new System.EventHandler(this.txtPhoneNumber_TextChanged);
            // 
            // lblLogo
            // 
            this.lblLogo.AutoSize = true;
            this.lblLogo.Location = new System.Drawing.Point(6, 95);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(40, 16);
            this.lblLogo.TabIndex = 5;
            this.lblLogo.Text = "Logo: ";
            // 
            // btnUploadLogo
            // 
            this.btnUploadLogo.Location = new System.Drawing.Point(52, 89);
            this.btnUploadLogo.Name = "btnUploadLogo";
            this.btnUploadLogo.Size = new System.Drawing.Size(92, 29);
            this.btnUploadLogo.TabIndex = 6;
            this.btnUploadLogo.Text = "Upload";
            this.btnUploadLogo.UseVisualStyleBackColor = true;
            this.btnUploadLogo.Click += new System.EventHandler(this.btnUploadLogo_Click);
            // 
            // picLogo
            // 
            this.picLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.picLogo.Location = new System.Drawing.Point(179, 3);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(230, 237);
            this.picLogo.TabIndex = 1;
            this.picLogo.TabStop = false;
            // 
            // grpLogoBox
            // 
            this.grpLogoBox.Controls.Add(this.tableLayoutPanel1);
            this.grpLogoBox.Location = new System.Drawing.Point(3, 132);
            this.grpLogoBox.Name = "grpLogoBox";
            this.grpLogoBox.Size = new System.Drawing.Size(594, 265);
            this.grpLogoBox.TabIndex = 1;
            this.grpLogoBox.TabStop = false;
            this.grpLogoBox.Text = "Company Logo";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.picLogo, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(588, 243);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // CompanySetupUsrCtl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpLogoBox);
            this.Controls.Add(this.grpCompInfo);
            this.Name = "CompanySetupUsrCtl";
            this.Size = new System.Drawing.Size(600, 400);
            this.grpCompInfo.ResumeLayout(false);
            this.grpCompInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.grpLogoBox.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

    }

        #endregion

        private GroupBox grpCompInfo;
        private Button btnUploadLogo;
        private Label lblLogo;
        private MaskedTextBox txtPhoneNumber;
        private TextBox txtCompanyName;
        private Label label1;
        private Label lblCompName;
        private PictureBox picLogo;
        private GroupBox grpLogoBox;
        private TableLayoutPanel tableLayoutPanel1;
    }
}
