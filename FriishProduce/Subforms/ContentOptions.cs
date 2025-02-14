﻿using FriishProduce.Properties;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FriishProduce
{
    public partial class ContentOptions : Form
    {
        protected TheArtOfDev.HtmlRenderer.WinForms.HtmlToolTip tip;

        public ContentOptions()
        {
            InitializeComponent();
            ClearOptions();

            // Cosmetic
            // *******
            if (!DesignMode)
            {
                // Remove this code when creating a new copy
                // *****************************************
                b_ok.Click += OK_Click;
                b_cancel.Click += Cancel_Click;
                controller_cb.Click += Controller_Toggle;
                b_controller.Click += OpenControllerMapping;
                Load += Form_Load;
                Shown += SetupLayout;
                // *****************************************

                // Program.Lang.Control(this);
                // tip = HTML.CreateToolTip();
            }
        }

        // ---------------------------------------------------------------------------------------------------------------

        protected virtual void ClearOptions()
        {
            // Add options that can be changed in string format
            // ************************************************
            Options = new Dictionary<string, string>
            {
            };
            // ************************************************
        }

        protected virtual void ResetOptions()
        {
            // Form control
            // *******
            if (Options != null)
            {
                // Code logic in derived Form
            }
            // *******
        }

        protected virtual void SaveOptions()
        {
            // Code logic in derived Form
        }

        // ---------------------------------------------------------------------------------------------------------------

        #region Variables

        // Variables to be changed go here. They should not be copied!

        #endregion

        // ---------------------------------------------------------------------------------------------------------------

        #region Functions

        // Additional functions for Form go here.

        #endregion

        // ---------------------------------------------------------------------------------------------------------------
        // /!\ REMAINING FUNCTIONS AND VALUES NEEDED FOR THE FORM BELOW. THERE IS NO NEED TO COPY THEM. /!\
        // ---------------------------------------------------------------------------------------------------------------

        public IDictionary<string, string> Options { get; set; }
        public int EmuType { get; set; }

        protected ControllerMapping controllerForm { get; set; }

        public bool UsesKeymap { get; set; }

        private IDictionary<Buttons, string> _Keymap;
        private IDictionary<Buttons, string> _oldKeymap;
        public IDictionary<Buttons, string> Keymap
        {
            get
            {
                if (controllerForm != null)
                {
                    controllerForm.Keymap = _Keymap;
                    return _Keymap;
                }

                else return null;
            }
            set
            {
                _Keymap = value;

                if (controllerForm != null)
                {
                    controllerForm.Keymap = value;
                }
            }
        }

        protected void OK_Click(object sender, EventArgs e)
        {
            if (DesignMode) return;

            if (controllerForm?.Keymap != null)
            {
                _Keymap = controllerForm.Keymap;
                if (_oldKeymap != _Keymap)
                    _oldKeymap = new Dictionary<Buttons, string>(_Keymap);
                UsesKeymap = controller_cb.Checked;
            }

            try { SaveOptions(); } catch { ClearOptions(); SaveOptions(); }
            DialogResult = DialogResult.OK;
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            if (DesignMode) return;

            if (_oldKeymap != null)
                controllerForm.Keymap = _Keymap = new Dictionary<Buttons, string>(_oldKeymap);

            DialogResult = DialogResult.Cancel;
        }

        protected void Form_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;

            if (_oldKeymap == null && _Keymap != null)
                _oldKeymap = controllerForm.Keymap = new Dictionary<Buttons, string>(_Keymap);

            try { ResetOptions(); } catch { ClearOptions(); ResetOptions(); }
            CenterToParent();

            controller_box.Visible = controllerForm != null;
            b_controller.Enabled = controller_cb.Checked = UsesKeymap && controllerForm != null;

            SetupLayout(null, new EventArgs());
        }

        private void SetupLayout(object sender, EventArgs e)
        {
            Theme.ChangeColors(this, false);
            Theme.BtnSizes(b_ok, b_cancel);
            Theme.BtnLayout(this, b_ok, b_cancel);
        }

        protected void OpenControllerMapping(object sender, EventArgs e)
        {
            if (DesignMode) return;

            controllerForm.Font = Program.MainForm.Font;
            controllerForm.Text = b_controller.Text.Replace("&", null).TrimEnd('.', '。').Trim();
            controllerForm.ShowDialog();
        }

        private void Controller_Toggle(object sender, EventArgs e)
        {
            b_controller.Enabled = controller_cb.Checked;
        }
    }
}
