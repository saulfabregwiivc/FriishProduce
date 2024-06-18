﻿using Ookii.Dialogs.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FriishProduce
{
    public partial class MainForm : Form
    {
        private readonly SettingsForm s = new SettingsForm();

        public readonly IDictionary<Platform, Bitmap> Icons = new Dictionary<Platform, Bitmap>
        {
            { Platform.NES, new Icon(Properties.Resources.nintendo_nes, 16, 16).ToBitmap() },
            { Platform.SNES, new Icon(Properties.Resources.nintendo_super_nes, 16, 16).ToBitmap() },
            { Platform.N64, new Icon(Properties.Resources.nintendo_nintendo64, 16, 16).ToBitmap() },
            { Platform.SMS, new Icon(Properties.Resources.sega_master_system, 16, 16).ToBitmap() },
            { Platform.SMD, new Icon(Properties.Resources.sega_genesis, 16, 16).ToBitmap() },
            { Platform.PCE, new Icon(Properties.Resources.nec_turbografx_16, 16, 16).ToBitmap() },
            { Platform.NEO, new Icon(Properties.Resources.snk_neo_geo_aes, 16, 16).ToBitmap() },
            { Platform.MSX, Properties.Resources.msx },
            { Platform.PSX, new Icon(Properties.Resources.sony_playstation, 16, 16).ToBitmap() },
            { Platform.Flash, Properties.Resources.flash },
            { Platform.RPGM, new Icon(Properties.Resources.rpg2003, 16, 16).ToBitmap() }
        };

        private ToolStripItem[] PlatformsList()
        {
            var list = new ToolStripItem[]
                {
                    /*new ToolStripMenuItem(
                        Language.Get("Group0", "Platforms"), null,
                        new ToolStripItem[]
                        {*/
                            new ToolStripMenuItem(null, Icons[Platform.NES], addProject, Platform.NES.ToString()),
                            new ToolStripMenuItem(null, Icons[Platform.SNES], addProject, Platform.SNES.ToString()),
                            new ToolStripMenuItem(null, Icons[Platform.N64], addProject, Platform.N64.ToString()),
                            new ToolStripSeparator(),
                        /*}),

                    new ToolStripMenuItem(
                        Language.Get("Group1", "Platforms"), null,
                        new ToolStripItem[]
                        {*/
                            new ToolStripMenuItem(null, Icons[Platform.SMS], addProject, Platform.SMS.ToString()),
                            new ToolStripMenuItem(null, Icons[Platform.SMD], addProject, Platform.SMD.ToString()),
                            new ToolStripSeparator(),
                        /*}),

                    new ToolStripMenuItem(
                        Language.Get("Other"), null,
                        new ToolStripItem[]
                        {*/
                            new ToolStripMenuItem(null, Icons[Platform.PCE], addProject, Platform.PCE.ToString()),
                            new ToolStripMenuItem(null, Icons[Platform.NEO], addProject, Platform.NEO.ToString()),
                            new ToolStripMenuItem(null, Icons[Platform.MSX], addProject, Platform.MSX.ToString()),
                            new ToolStripSeparator(),
                            new ToolStripMenuItem(null, Icons[Platform.PSX], addProject, Platform.PSX.ToString()),
                            new ToolStripSeparator(),
                            new ToolStripMenuItem(null, Icons[Platform.Flash], addProject, Platform.Flash.ToString()),
                            new ToolStripMenuItem(null, Icons[Platform.RPGM], addProject, Platform.RPGM.ToString())
                        //})
                };

            /* foreach (ToolStripMenuItem section in Consoles.OfType<ToolStripMenuItem>())
                foreach (ToolStripMenuItem item in section.DropDownItems.OfType<ToolStripMenuItem>())
                    item.Text = string.Format(Language.Get("ProjectType"), Language.Get(item.Name, "Platforms")); */

            foreach (ToolStripMenuItem item in list.OfType<ToolStripMenuItem>())
                item.Text = string.Format(Program.Lang.String("project_type", Name), Program.Lang.Console((Platform)Enum.Parse(typeof(Platform), item.Name)));

            return list;
        }

        private void AutoSetStrip()
        {
            foreach (ToolStripMenuItem section in MenuStrip.Items.OfType<ToolStripMenuItem>())
                foreach (ToolStripItem item in section.DropDownItems.OfType<ToolStripItem>())
                    if (Program.Lang.StringCheck(item.Tag?.ToString().ToLower(), Name)) item.Text = Program.Lang.String(item.Tag?.ToString().ToLower(), Name);

            menu_new_project.DropDownItems.Clear();
            menu_new_project.DropDownItems.AddRange(PlatformsList());
            toolbarNewProject.DropDownItems.Clear();
            toolbarNewProject.DropDownItems.AddRange(PlatformsList());
        }

        /// <summary>
        /// Changes language of this form and all tab pages
        /// </summary>
        private void RefreshForm()
        {
            AutoSetStrip();

            #region Localization
            Program.Lang.Control(this);
            menu_file.Text = Program.Lang.String("file", Name);
            menu_project.Text = Program.Lang.String("project", Name);
            menu_help.Text = Program.Lang.String("help", Name);
            menu_about_app.Text = string.Format(Program.Lang.String("about_app"), Program.Lang.ApplicationTitle);
            Text = Program.Lang.ApplicationTitle;

            toolbarNewProject.Text = menu_new_project.Text;
            toolbarOpenProject.Text = menu_open_project.Text;
            toolbarSaveAs.Text = menu_save_project_as.Text;
            toolbarSaveAsWAD.Text = menu_save_as_wad.Text;
            toolbarOpenROM.Text = menu_open_gamefile.Text;
            toolbarOpenImage.Text = menu_open_image.Text;
            toolbarCloseProject.Text = menu_close_project.Text;
            toolbarUseLibRetro.Text = menu_retrieve_gamedata_online.Text;
            ToolStrip_Settings.Text = menu_settings.Text;
            BrowseROM.Title = menu_open_gamefile.Text;
            BrowseImage.Title = menu_open_image.Text;
            SaveProject.Title = menu_save_project_as.Text;
            SaveWAD.Title = menu_save_as_wad.Text;

            try
            {
                BrowseImage.Filter = Program.Lang.String("filter.img");
                BrowseProject.Filter = SaveProject.Filter = Program.Lang.String("filter.project");
                SaveWAD.Filter = Program.Lang.String("filter.wad");
            }
            catch
            {
                MessageBox.Show("Warning!\nThe language strings have not been loaded correctly.\n\nSeveral items may show up as 'undefined'.\n\nOther exceptions related to strings or filters can also occur!", MessageBox.Buttons.Ok, MessageBox.Icons.Warning, false);
            }
            #endregion

            foreach (MdiTabControl.TabPage tabPage in tabControl.TabPages)
            {
                if (tabPage.Form.GetType() == typeof(ProjectForm))
                    (tabPage.Form as ProjectForm).RefreshForm();
            }

            MenuStrip.Font = ToolStrip.Font;

            if (Logo.Location.X == 0 || Logo.Location.Y == 0) Logo.Location = new Point((MainPanel.Width / 2) - (Logo.Width / 2), (MainPanel.Height / 2) - (Logo.Height / 2));

            if (MaximumSize.IsEmpty)
            {
                MaximumSize = new Size
                (
                    MainPanel.Width + (ToolStrip.Dock == DockStyle.Right || ToolStrip.Dock == DockStyle.Left ? ToolStrip.Width - 8 : 16),
                    MainPanel.Location.Y + MainPanel.Height + excessHeight
                );
                MinimumSize = Size = MaximumSize;
            }

            tabControl.Size = new Size(MainPanel.Width, 1000);
        }

        private int excessHeight = 40;

        public MainForm()
        {
            InitializeComponent();
            Program.Handle = Handle;

            MaximumSize = new Size(0, 0);
            tabControl.Location = MainPanel.Location;
            MainPanel.Height += excessHeight + 5;
            RefreshForm();
            CenterToScreen();

            // Automatically set defined initial directory for save file dialog
            // ********
            // SaveWAD.InitialDirectory = Paths.Out;

            if (Properties.Settings.Default.auto_update_check) { _ = Updater.GetLatest(); }
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            // string lang = Properties.Settings.Default.language;

            s.Font = Font;
            s.ShowDialog(this);

            // if (lang != Properties.Settings.Default.language) RefreshForm();
        }

        public void TabChanged(object sender, EventArgs e)
        {
            // Toggle visibility of Open ROM/Image buttons
            // ********
            if (sender != tabControl.TabPages[0]) menu_open_gamefile.Enabled = tabControl.TabPages.Count > 1;
            else menu_open_gamefile.Enabled = true;

            // Toggle visibility of Export WAD button
            // Toggle visibility of Download LibRetro data button
            // ********
            if (!menu_open_gamefile.Enabled)
            {
                toolbarUseLibRetro.Enabled = menu_retrieve_gamedata_online.Enabled = false;
                toolbarOpenImage.Enabled = menu_open_image.Enabled = false;
                menu_save_project_as.Enabled = false;
                toolbarSaveAsWAD.Enabled = menu_save_as_wad.Enabled = false;

                tabControl.Visible = false;
                MainPanel.Visible = true;
            }

            else
            {
                toolbarUseLibRetro.Enabled = menu_retrieve_gamedata_online.Enabled = (tabControl.SelectedForm as ProjectForm).ToolbarButtons[0];
                toolbarOpenImage.Enabled = menu_open_image.Enabled = !(tabControl.SelectedForm as ProjectForm).IsEmpty;
                toolbarSaveAsWAD.Enabled = menu_save_as_wad.Enabled = (tabControl.SelectedForm as ProjectForm).IsExportable;
            }

            toolbarCloseProject.Enabled = menu_close_project.Enabled
            = toolbarOpenROM.Enabled = menu_open_gamefile.Enabled;

            // Context menu
            // ********
            if (tabControl.TabPages.Count >= 1)
                if (sender == tabControl.TabPages[0])
                {
                    menu_retrieve_gamedata_online.Enabled = (tabControl.SelectedForm as ProjectForm).ToolbarButtons[0];
                    menu_save_project_as.Enabled = (tabControl.SelectedForm as ProjectForm).Tag?.ToString().ToLower() == "dirty";
                }

            toolbarSaveAs.Enabled = menu_save_project_as.Enabled;
            toolbarUseLibRetro.Enabled = menu_retrieve_gamedata_online.Enabled;
        }

        private void MainForm_Closing(object sender, FormClosingEventArgs e)
        {
            var collection = tabControl.TabPages;

            for (int i = 0; i < collection.Count; i++)
            {
                var p = tabControl.TabPages[i];
                var f = p.Form as ProjectForm;

                if (f.IsModified)
                {
                    tabControl.TabPages[tabControl.TabPages.get_IndexOf(p)].Select();

                    if (!f.CheckUnsaved())
                    {
                        e.Cancel = true;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Adds a new project to the Main Form.
        /// </summary>
        private void addProject(object sender, EventArgs e)
        {
            var source = sender as ToolStripMenuItem;

            if (Enum.TryParse(source.Name.ToString(), out Platform console))
            {
                addTab(console);
            }
        }

        private void addTab(Platform platform, Project x = null)
        {
            ProjectForm p = new(platform, null, x);
            p.FormClosed += TabChanged;
            tabControl.TabPages.Add(p);

            tabControl.Visible = true;
            MainPanel.Visible = false;

            // BrowseROMDialog(console, p);
        }

        private void OpenROM_Click(object sender, EventArgs e) => BrowseROMDialog((tabControl.SelectedForm as ProjectForm).Platform);

        private void BrowseROMDialog(Platform platform)
        {
            switch (platform)
            {
                default:
                    BrowseROM.Filter = Program.Lang.String("filter.disc") + "|" + Program.Lang.String("filter.zip") + Program.Lang.String("filter");
                    break;

                case Platform.NES:
                case Platform.SNES:
                case Platform.N64:
                case Platform.SMS:
                case Platform.SMD:
                case Platform.PCE:
                case Platform.C64:
                case Platform.MSX:
                    BrowseROM.Filter = Program.Lang.String($"filter.rom_{platform.ToString().ToLower()}");
                    break;

                case Platform.NEO:
                    BrowseROM.Filter = Program.Lang.String("filter.zip");
                    break;

                case Platform.Flash:
                    BrowseROM.Filter = Program.Lang.String("filter.swf");
                    break;

                case Platform.RPGM:
                    BrowseROM.Filter = Program.Lang.String("filter.rpgm");
                    break;
            }

            if (BrowseROM.ShowDialog() == DialogResult.OK && tabControl.SelectedForm != null)
            {
                var p = tabControl.SelectedForm as ProjectForm;
                p.LoadROM(BrowseROM.FileName, Properties.Settings.Default.auto_retrieve_game_data);

                toolbarUseLibRetro.Enabled = menu_retrieve_gamedata_online.Enabled = p.ToolbarButtons[0];
            }
        }

        private void UseLibRetro_Click(object sender, EventArgs e) => (tabControl.SelectedForm as ProjectForm).LoadGameData();

        private void ExportWAD_Click(object sender, EventArgs e)
        {
            var currentForm = tabControl.SelectedForm as ProjectForm;

            SaveWAD.FileName = currentForm.GetName();
            if (SaveWAD.ShowDialog() == DialogResult.OK) currentForm.SaveToWAD(SaveProject.FileName);
        }

        private void OpenImage_Click(object sender, EventArgs e)
        {
            if (BrowseImage.ShowDialog() == DialogResult.OK)
            {
                var currentForm = tabControl.SelectedForm as ProjectForm;
                currentForm.LoadImage(BrowseImage.FileName);
            }
        }

        public void CleanTemp()
        {
            try
            {
                foreach (var item in Directory.GetFiles(Paths.WorkingFolder, "*.*", SearchOption.AllDirectories))
                    if (!Path.GetFileName(item).ToLower().Contains("readme.md")) File.Delete(item);
                foreach (var item in Directory.GetDirectories(Paths.WorkingFolder))
                    Directory.Delete(item, true);
            }
            catch { }
        }

        private void TabContextMenu_Opening(object sender, CancelEventArgs e)
        {
            var page = (sender as ContextMenuStrip).SourceControl;
            var index = tabControl.TabPages.get_IndexOf(page as MdiTabControl.TabPage);
            if (index != -1) tabControl.TabPages[index].Select();
        }

        private void CloseTab_Click(object sender, EventArgs e) { var tab = tabControl.SelectedForm as Form; tab.Close(); }

        private void About_Click(object sender, EventArgs e) { using var about = new About() { Font = Font }; about.ShowDialog(); }

        private void MenuItem_Exit_Click(object sender, EventArgs e) => Application.Exit();

        private void SaveAs_Click(object sender, EventArgs e) => SaveAs_Trigger();

        public bool SaveAs_Trigger()
        {
            try
            {
                if (tabControl.SelectedForm is not ProjectForm currentForm) throw new Exception("No project found!");

                SaveProject.FileName = currentForm.Text;
                foreach (var item in new char[] { '\\', '/', ':', '*', '?', '"', '<', '>', '|' })
                    SaveProject.FileName = SaveProject.FileName.Replace(item, '_');

                if (SaveProject.ShowDialog() == DialogResult.OK)
                {
                    currentForm.SaveProject(SaveProject.FileName);
                    return true;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Could not save!", ex.Message, MessageBox.Buttons.Ok, MessageBox.Icons.Error);
            }

            return false;
        }

        private void OpenProject_Click(object sender, EventArgs e)
        {
            if (BrowseProject.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using Stream stream = File.Open(BrowseProject.FileName, FileMode.Open);
                    var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    var project = (Project)binaryFormatter.Deserialize(stream);
                    addTab(project.Platform, project);
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Not a valid project file!", MessageBox.Buttons.Ok, MessageBox.Icons.Error);
                }
            }
        }
    }
}
