﻿
namespace FriishProduce
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.panel = new System.Windows.Forms.Panel();
            this.OK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.Application = new System.Windows.Forms.TabPage();
            this.Theme = new System.Windows.Forms.ComboBox();
            this.Settings_Theme = new System.Windows.Forms.Label();
            this.Language = new System.Windows.Forms.ComboBox();
            this.Settings_Language = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.panel.SuspendLayout();
            this.Application.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.panel.Controls.Add(this.OK);
            this.panel.Controls.Add(this.Cancel);
            resources.ApplyResources(this.panel, "panel");
            this.panel.Name = "panel";
            // 
            // OK
            // 
            this.OK.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.OK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.OK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            resources.ApplyResources(this.OK, "OK");
            this.OK.Name = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // Cancel
            // 
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.Cancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.Cancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            resources.ApplyResources(this.Cancel, "Cancel");
            this.Cancel.Name = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // Application
            // 
            this.Application.BackColor = System.Drawing.SystemColors.Window;
            this.Application.Controls.Add(this.Theme);
            this.Application.Controls.Add(this.Settings_Theme);
            this.Application.Controls.Add(this.Language);
            this.Application.Controls.Add(this.Settings_Language);
            this.Application.ForeColor = System.Drawing.SystemColors.ControlText;
            resources.ApplyResources(this.Application, "Application");
            this.Application.Name = "Application";
            // 
            // Theme
            // 
            this.Theme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Theme.FormattingEnabled = true;
            this.Theme.Items.AddRange(new object[] {
            resources.GetString("Theme.Items")});
            resources.ApplyResources(this.Theme, "Theme");
            this.Theme.Name = "Theme";
            // 
            // Settings_Theme
            // 
            resources.ApplyResources(this.Settings_Theme, "Settings_Theme");
            this.Settings_Theme.Name = "Settings_Theme";
            // 
            // Language
            // 
            this.Language.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Language.FormattingEnabled = true;
            resources.ApplyResources(this.Language, "Language");
            this.Language.Name = "Language";
            // 
            // Settings_Language
            // 
            resources.ApplyResources(this.Settings_Language, "Settings_Language");
            this.Settings_Language.Name = "Settings_Language";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Application);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // Settings
            // 
            this.AcceptButton = this.OK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.CancelButton = this.Cancel;
            this.Controls.Add(this.panel);
            this.Controls.Add(this.tabControl1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Load += new System.EventHandler(this.Settings_Load);
            this.panel.ResumeLayout(false);
            this.Application.ResumeLayout(false);
            this.Application.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.TabPage Application;
        private System.Windows.Forms.ComboBox Language;
        private System.Windows.Forms.Label Settings_Language;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ComboBox Theme;
        private System.Windows.Forms.Label Settings_Theme;
    }
}