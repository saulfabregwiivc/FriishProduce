﻿using System;
using System.Collections.Generic;

namespace FriishProduce
{
    public partial class Options_VC_SNES : ContentOptions
    {
        public Options_VC_SNES() : base()
        {
            InitializeComponent();
            ClearOptions();
            controllerForm = new Controller_SNES();

            // Cosmetic
            // *******
            if (!DesignMode)
            {
                Program.Lang.Control(this);

                controller_cb.Text = Program.Lang.String("controller", "projectform");
                b_controller.Text = Program.Lang.String("controller_mapping", "projectform");
            }
        }

        // ---------------------------------------------------------------------------------------------------------------

        protected override void ClearOptions()
        {
            Options = new Dictionary<string, string>
            {
                { "patch_volume",       Program.Config.snes.patch_volume.ToString() },
                { "patch_nodark",       Program.Config.snes.patch_nodark.ToString() },
                { "patch_nocc",         Program.Config.snes.patch_nocc.ToString() },
                { "patch_nosuspend",    Program.Config.snes.patch_nosuspend.ToString() },
                { "patch_nosave",       Program.Config.snes.patch_nosave.ToString() },
                { "patch_widescreen",   Program.Config.snes.patch_widescreen.ToString() },
                { "patch_nocheck",      Program.Config.snes.patch_nocheck.ToString() },
                { "patch_wiimote",      Program.Config.snes.patch_wiimote.ToString() }
            };
        }

        protected override void ResetOptions()
        {
            // Form control
            // *******
            if (Options != null)
            {
                patch_volume.Checked                = bool.Parse(Options["patch_volume"]);
                patch_nodark.Checked                = bool.Parse(Options["patch_nodark"]);
                patch_nocc.Checked                  = bool.Parse(Options["patch_nocc"]);
                patch_nosuspend.Checked             = bool.Parse(Options["patch_nosuspend"]);
                patch_nosave.Checked                = bool.Parse(Options["patch_nosave"]);
                patch_widescreen.Checked            = bool.Parse(Options["patch_widescreen"]);
                patch_nocheck.Checked               = bool.Parse(Options["patch_nocheck"]);
                patch_wiimote.Checked               = bool.Parse(Options["patch_wiimote"]);

                UsesKeymap = patch_wiimote.Checked;
            }
            // *******
        }

        protected override void SaveOptions()
        {
            Options["patch_volume"] = patch_volume.Checked.ToString();
            Options["patch_nodark"] = patch_nodark.Checked.ToString();
            Options["patch_nocc"] = patch_nocc.Checked.ToString();
            Options["patch_nosuspend"] = patch_nosuspend.Checked.ToString();
            Options["patch_nosave"] = patch_nosave.Checked.ToString();
            Options["patch_widescreen"] = patch_widescreen.Checked.ToString();
            Options["patch_nocheck"] = patch_nocheck.Checked.ToString();
            Options["patch_wiimote"] = patch_wiimote.Checked.ToString();

            UsesKeymap = patch_wiimote.Checked;
        }

        // ---------------------------------------------------------------------------------------------------------------

        #region Functions
        private void patch_wiimote_CheckedChanged(object sender, EventArgs e)
        {
            b_controller.Enabled = controller_cb.Checked = patch_wiimote.Checked;
        }
        #endregion
    }
}
