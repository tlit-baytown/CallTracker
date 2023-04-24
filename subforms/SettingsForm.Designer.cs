namespace CallTracker_GUI.subforms
{
    partial class SettingsForm
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

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.SettingTabs = new System.Windows.Forms.TabControl();
            this.TabPageDBSettings = new System.Windows.Forms.TabPage();
            this.TabPageCompanySettings = new System.Windows.Forms.TabPage();
            this.TabPageApplicationSettings = new System.Windows.Forms.TabPage();
            this.tlpSettingsButtons = new System.Windows.Forms.TableLayoutPanel();
            this.CancelChangesBtn = new System.Windows.Forms.Button();
            this.SaveSettingsBtn = new System.Windows.Forms.Button();
            this.ResetToDefaultBtn = new System.Windows.Forms.Button();
            this.SettingTabs.SuspendLayout();
            this.tlpSettingsButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // SettingTabs
            // 
            this.SettingTabs.Controls.Add(this.TabPageDBSettings);
            this.SettingTabs.Controls.Add(this.TabPageCompanySettings);
            this.SettingTabs.Controls.Add(this.TabPageApplicationSettings);
            this.SettingTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SettingTabs.Location = new System.Drawing.Point(0, 0);
            this.SettingTabs.Name = "SettingTabs";
            this.SettingTabs.SelectedIndex = 0;
            this.SettingTabs.Size = new System.Drawing.Size(800, 410);
            this.SettingTabs.TabIndex = 0;
            // 
            // TabPageDBSettings
            // 
            this.TabPageDBSettings.Location = new System.Drawing.Point(4, 25);
            this.TabPageDBSettings.Name = "TabPageDBSettings";
            this.TabPageDBSettings.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageDBSettings.Size = new System.Drawing.Size(792, 381);
            this.TabPageDBSettings.TabIndex = 0;
            this.TabPageDBSettings.Text = "Database Setup";
            this.TabPageDBSettings.UseVisualStyleBackColor = true;
            // 
            // TabPageCompanySettings
            // 
            this.TabPageCompanySettings.Location = new System.Drawing.Point(4, 25);
            this.TabPageCompanySettings.Name = "TabPageCompanySettings";
            this.TabPageCompanySettings.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageCompanySettings.Size = new System.Drawing.Size(792, 381);
            this.TabPageCompanySettings.TabIndex = 1;
            this.TabPageCompanySettings.Text = "Company Setup";
            this.TabPageCompanySettings.UseVisualStyleBackColor = true;
            // 
            // TabPageApplicationSettings
            // 
            this.TabPageApplicationSettings.Location = new System.Drawing.Point(4, 25);
            this.TabPageApplicationSettings.Name = "TabPageApplicationSettings";
            this.TabPageApplicationSettings.Size = new System.Drawing.Size(792, 381);
            this.TabPageApplicationSettings.TabIndex = 2;
            this.TabPageApplicationSettings.Text = "Application Setup";
            this.TabPageApplicationSettings.UseVisualStyleBackColor = true;
            // 
            // tlpSettingsButtons
            // 
            this.tlpSettingsButtons.ColumnCount = 3;
            this.tlpSettingsButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 81.375F));
            this.tlpSettingsButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.625F));
            this.tlpSettingsButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            this.tlpSettingsButtons.Controls.Add(this.CancelChangesBtn, 2, 0);
            this.tlpSettingsButtons.Controls.Add(this.ResetToDefaultBtn, 1, 0);
            this.tlpSettingsButtons.Controls.Add(this.SaveSettingsBtn, 0, 0);
            this.tlpSettingsButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlpSettingsButtons.Location = new System.Drawing.Point(0, 410);
            this.tlpSettingsButtons.Name = "tlpSettingsButtons";
            this.tlpSettingsButtons.RowCount = 1;
            this.tlpSettingsButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSettingsButtons.Size = new System.Drawing.Size(800, 40);
            this.tlpSettingsButtons.TabIndex = 1;
            // 
            // CancelChangesBtn
            // 
            this.CancelChangesBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CancelChangesBtn.Location = new System.Drawing.Point(690, 3);
            this.CancelChangesBtn.Name = "CancelChangesBtn";
            this.CancelChangesBtn.Size = new System.Drawing.Size(107, 34);
            this.CancelChangesBtn.TabIndex = 1;
            this.CancelChangesBtn.Text = "Cancel Changes";
            this.CancelChangesBtn.UseVisualStyleBackColor = true;
            this.CancelChangesBtn.Click += new System.EventHandler(this.CancelChangesBtn_Click);
            // 
            // SaveSettingsBtn
            // 
            this.SaveSettingsBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SaveSettingsBtn.Location = new System.Drawing.Point(3, 3);
            this.SaveSettingsBtn.Name = "SaveSettingsBtn";
            this.SaveSettingsBtn.Size = new System.Drawing.Size(553, 34);
            this.SaveSettingsBtn.TabIndex = 0;
            this.SaveSettingsBtn.Text = "Save Settings";
            this.SaveSettingsBtn.UseVisualStyleBackColor = true;
            this.SaveSettingsBtn.Click += new System.EventHandler(this.SaveSettingsBtn_Click);
            // 
            // ResetToDefaultBtn
            // 
            this.ResetToDefaultBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResetToDefaultBtn.Location = new System.Drawing.Point(562, 3);
            this.ResetToDefaultBtn.Name = "ResetToDefaultBtn";
            this.ResetToDefaultBtn.Size = new System.Drawing.Size(122, 34);
            this.ResetToDefaultBtn.TabIndex = 2;
            this.ResetToDefaultBtn.Text = "Reset to Default";
            this.ResetToDefaultBtn.UseVisualStyleBackColor = true;
            this.ResetToDefaultBtn.Click += new System.EventHandler(this.ResetToDefaultBtn_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SettingTabs);
            this.Controls.Add(this.tlpSettingsButtons);
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.SettingTabs.ResumeLayout(false);
            this.tlpSettingsButtons.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    #endregion

    private TabControl SettingTabs;
    private TabPage TabPageDBSettings;
    private TabPage TabPageCompanySettings;
    private TabPage TabPageApplicationSettings;
    private TableLayoutPanel tlpSettingsButtons;
    private Button CancelChangesBtn;
    private Button SaveSettingsBtn;
        private Button ResetToDefaultBtn;
    }
}