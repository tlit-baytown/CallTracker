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
            this.tlpSettingsButtons = new System.Windows.Forms.TableLayoutPanel();
            this.SaveSettingsBtn = new System.Windows.Forms.Button();
            this.CancelChangesBtn = new System.Windows.Forms.Button();
            this.tlpSettingsButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpSettingsButtons
            // 
            this.tlpSettingsButtons.ColumnCount = 2;
            this.tlpSettingsButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 82.73615F));
            this.tlpSettingsButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.26384F));
            this.tlpSettingsButtons.Controls.Add(this.SaveSettingsBtn, 0, 0);
            this.tlpSettingsButtons.Controls.Add(this.CancelChangesBtn, 1, 0);
            this.tlpSettingsButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlpSettingsButtons.Location = new System.Drawing.Point(0, 191);
            this.tlpSettingsButtons.Name = "tlpSettingsButtons";
            this.tlpSettingsButtons.RowCount = 1;
            this.tlpSettingsButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSettingsButtons.Size = new System.Drawing.Size(603, 40);
            this.tlpSettingsButtons.TabIndex = 1;
            // 
            // SaveSettingsBtn
            // 
            this.SaveSettingsBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SaveSettingsBtn.Location = new System.Drawing.Point(3, 3);
            this.SaveSettingsBtn.Name = "SaveSettingsBtn";
            this.SaveSettingsBtn.Size = new System.Drawing.Size(492, 34);
            this.SaveSettingsBtn.TabIndex = 0;
            this.SaveSettingsBtn.Text = "Save Settings";
            this.SaveSettingsBtn.UseVisualStyleBackColor = true;
            this.SaveSettingsBtn.Click += new System.EventHandler(this.SaveSettingsBtn_Click);
            // 
            // CancelChangesBtn
            // 
            this.CancelChangesBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CancelChangesBtn.Location = new System.Drawing.Point(501, 3);
            this.CancelChangesBtn.Name = "CancelChangesBtn";
            this.CancelChangesBtn.Size = new System.Drawing.Size(99, 34);
            this.CancelChangesBtn.TabIndex = 1;
            this.CancelChangesBtn.Text = "Cancel";
            this.CancelChangesBtn.UseVisualStyleBackColor = true;
            this.CancelChangesBtn.Click += new System.EventHandler(this.CancelChangesBtn_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 231);
            this.Controls.Add(this.tlpSettingsButtons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.tlpSettingsButtons.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    #endregion
    private TableLayoutPanel tlpSettingsButtons;
    private Button SaveSettingsBtn;
        private Button CancelChangesBtn;
    }
}