﻿
namespace FriishProduce
{
    partial class UpdaterForm
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
            this.bottomPanel2 = new System.Windows.Forms.Panel();
            this.bottomPanel1 = new System.Windows.Forms.Panel();
            this.desc2 = new System.Windows.Forms.Label();
            this.b_no = new System.Windows.Forms.Button();
            this.b_yes = new System.Windows.Forms.Button();
            this.Progress = new System.Windows.Forms.ProgressBar();
            this.htmlPanel1 = new TheArtOfDev.HtmlRenderer.WinForms.HtmlPanel();
            this.desc1 = new System.Windows.Forms.Label();
            this.bottomPanel2.SuspendLayout();
            this.bottomPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bottomPanel2
            // 
            this.bottomPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.bottomPanel2.Controls.Add(this.bottomPanel1);
            this.bottomPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel2.Location = new System.Drawing.Point(0, 279);
            this.bottomPanel2.Name = "bottomPanel2";
            this.bottomPanel2.Size = new System.Drawing.Size(468, 42);
            this.bottomPanel2.TabIndex = 38;
            // 
            // bottomPanel1
            // 
            this.bottomPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.bottomPanel1.Controls.Add(this.desc2);
            this.bottomPanel1.Controls.Add(this.b_no);
            this.bottomPanel1.Controls.Add(this.b_yes);
            this.bottomPanel1.Controls.Add(this.Progress);
            this.bottomPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel1.Location = new System.Drawing.Point(0, 1);
            this.bottomPanel1.Name = "bottomPanel1";
            this.bottomPanel1.Size = new System.Drawing.Size(468, 41);
            this.bottomPanel1.TabIndex = 12;
            // 
            // desc2
            // 
            this.desc2.AutoSize = true;
            this.desc2.Location = new System.Drawing.Point(9, 14);
            this.desc2.Name = "desc2";
            this.desc2.Size = new System.Drawing.Size(35, 13);
            this.desc2.TabIndex = 40;
            this.desc2.Tag = "desc2";
            this.desc2.Text = "desc2";
            // 
            // b_no
            // 
            this.b_no.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.b_no.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.b_no.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.b_no.Location = new System.Drawing.Point(356, 9);
            this.b_no.Name = "b_no";
            this.b_no.Size = new System.Drawing.Size(100, 23);
            this.b_no.TabIndex = 4;
            this.b_no.Tag = "b_no";
            this.b_no.Text = "&No";
            this.b_no.UseVisualStyleBackColor = true;
            // 
            // b_yes
            // 
            this.b_yes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.b_yes.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.b_yes.Location = new System.Drawing.Point(250, 9);
            this.b_yes.Name = "b_yes";
            this.b_yes.Size = new System.Drawing.Size(100, 23);
            this.b_yes.TabIndex = 3;
            this.b_yes.Tag = "b_yes";
            this.b_yes.Text = "&Yes";
            this.b_yes.UseVisualStyleBackColor = true;
            this.b_yes.Click += new System.EventHandler(this.Yes_Click);
            // 
            // Progress
            // 
            this.Progress.Location = new System.Drawing.Point(12, 12);
            this.Progress.Name = "Progress";
            this.Progress.Size = new System.Drawing.Size(444, 17);
            this.Progress.TabIndex = 5;
            this.Progress.Visible = false;
            // 
            // htmlPanel1
            // 
            this.htmlPanel1.AutoScroll = true;
            this.htmlPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.htmlPanel1.BaseStylesheet = "";
            this.htmlPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.htmlPanel1.Location = new System.Drawing.Point(12, 46);
            this.htmlPanel1.Name = "htmlPanel1";
            this.htmlPanel1.Size = new System.Drawing.Size(444, 218);
            this.htmlPanel1.TabIndex = 39;
            this.htmlPanel1.Text = null;
            // 
            // desc1
            // 
            this.desc1.AutoSize = true;
            this.desc1.Location = new System.Drawing.Point(9, 9);
            this.desc1.Name = "desc1";
            this.desc1.Size = new System.Drawing.Size(23, 26);
            this.desc1.TabIndex = 40;
            this.desc1.Tag = "desc1";
            this.desc1.Text = "{0}\r\n{1}";
            // 
            // UpdaterForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(468, 321);
            this.Controls.Add(this.desc1);
            this.Controls.Add(this.htmlPanel1);
            this.Controls.Add(this.bottomPanel2);
            this.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdaterForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "updaterform";
            this.Text = "title";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Updater_FormClosing);
            this.bottomPanel2.ResumeLayout(false);
            this.bottomPanel1.ResumeLayout(false);
            this.bottomPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel bottomPanel2;
        protected System.Windows.Forms.Panel bottomPanel1;
        protected System.Windows.Forms.Button b_no;
        protected System.Windows.Forms.Button b_yes;
        private TheArtOfDev.HtmlRenderer.WinForms.HtmlPanel htmlPanel1;
        private System.Windows.Forms.ProgressBar Progress;
        private System.Windows.Forms.Label desc2;
        private System.Windows.Forms.Label desc1;
    }
}