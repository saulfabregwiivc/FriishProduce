﻿using Ookii.Dialogs.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
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

        private dynamic platformsItemList()
        {
            var list = new MenuItem[]
                {
                    new MenuItem(Platform.NES.ToString(), addProject),
                    new MenuItem(Platform.SNES.ToString(), addProject),
                    new MenuItem(Platform.N64.ToString(), addProject),
                    new MenuItem("-"),
                    new MenuItem(Platform.SMS.ToString(), addProject),
                    new MenuItem(Platform.SMD.ToString(), addProject),
                    new MenuItem("-"),
                    new MenuItem(Platform.PCE.ToString(), addProject),
                    new MenuItem(Platform.NEO.ToString(), addProject),
                    new MenuItem(Platform.MSX.ToString(), addProject),
                    new MenuItem(Platform.PSX.ToString(), addProject),
                    new MenuItem(Platform.RPGM.ToString(), addProject),
                    new MenuItem(Platform.Flash.ToString(), addProject),
                };

            foreach (MenuItem item in list)
            {
                if (item.Text != "-")
                    item.Name = item.Text;
                if (!string.IsNullOrWhiteSpace(item.Name))
                    item.Text = string.Format(Program.Lang.String("project_type", Name), Program.Lang.Console((Platform)Enum.Parse(typeof(Platform), item.Name)));
            }

            return list;
        }

        private void AutoSetStrip()
        {
            foreach (MenuItem section in mainMenu1.MenuItems)
                foreach (MenuItem item in section.MenuItems)
                    if (Program.Lang.StringCheck(item.Tag?.ToString().ToLower(), Name)) item.Text = Program.Lang.String(item.Tag?.ToString().ToLower(), Name);

            new_project.MenuItems.Clear();
            new_project.MenuItems.AddRange(platformsItemList());
        }

        /// <summary>
        /// Changes language of this form and all tab pages
        /// </summary>
        private void RefreshForm()
        {
            AutoSetStrip();

            #region Localization
            Program.Lang.Control(this);
            menuItem1.Text = Program.Lang.String(menuItem1.Tag.ToString(), Name);
            menuItem2.Text = Program.Lang.String(menuItem2.Tag.ToString(), Name);
            menuItem3.Text = Program.Lang.String(menuItem3.Tag.ToString(), Name);
            menuItem15.Text = string.Format(Program.Lang.String("about_app"), Program.Lang.ApplicationTitle);
            Text = Program.Lang.ApplicationTitle;

            toolbarOpenProject.Text = menuItem5.Text;
            toolbarSaveAs.Text = menuItem6.Text;
            toolbarExport.Text = menuItem11.Text;
            toolbarCloseProject.Text = menuItem12.Text;
            toolbarRetrieveGameData.Text = menuItem10.Text;
            toolbarSettings.Text = menuItem9.Text;

            SaveProject.Title = menuItem6.Text.Replace("&", "");
            SaveWAD.Title = menuItem11.Text.Replace("&", "");

            try
            {
                BrowseProject.Filter = SaveProject.Filter = Program.Lang.String("filter.project");
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
        }

        public MainForm()
        {
            InitializeComponent();
            Program.Handle = Handle;

            #region Set size of window
            int w = 16;
            int h = mainPanel.Location.Y + tabControl.TabHeight + tabControl.TabTop;
            using (var pF = new ProjectForm(0))
            {
                ClientSize = new Size(pF.Width, pF.Height + h);
                MinimumSize = MaximumSize = Size;
                tabControl.TabBackLowColor = pF.BackColor;
            }
            mainPanel.Dock = DockStyle.None;
            mainPanel.Size = tabControl.Size = new Size(Width - w, Height - h);
            #endregion

            /* mainPanel.BackgroundImage = new Bitmap(1, mainPanel.Height);
            using (Graphics g = Graphics.FromImage(mainPanel.BackgroundImage))
            using (LinearGradientBrush b = new(new Point(0, 0), new Point(0, 40), tabControl.BackHighColor, tabControl.BackLowColor))
            {
                g.Clear(tabControl.BackLowColor);
                g.FillRectangle(b, new RectangleF(0, 0, 1, b.Rectangle.Height));
            } */

            if (mainPanel.BackgroundImage != null) tabControl.BackLowColor = tabControl.BackHighColor = tabControl.BackColor = Color.Transparent;
            tabControl.BackgroundImage = mainPanel.BackgroundImage;
            tabControl.BackgroundImageLayout = mainPanel.BackgroundImageLayout;

            if (Logo.Location.X == 0 || Logo.Location.Y == 0) Logo.Location = new Point((mainPanel.Width / 2) - (Logo.Width / 2), (mainPanel.Height / 2) - Logo.Height);

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
            // Check if any tabs exist
            // ********
            bool hasTabs = tabControl.TabPages.Count > 1 || e.GetType() != typeof(FormClosedEventArgs);

            // Toggle visibility of Export WAD button
            // Toggle visibility of Download LibRetro data button
            // ********
            if (!hasTabs)
            {
                menuItem10.Enabled = false;
                menuItem6.Enabled = false;
                menuItem11.Enabled = false;

                tabControl.Visible = false;
                mainPanel.Visible = true;
            }

            else
            {
                menuItem10.Enabled = (tabControl.SelectedForm as ProjectForm).ToolbarButtons[0];
                menuItem11.Enabled = (tabControl.SelectedForm as ProjectForm).IsExportable;
            }

            menuItem12.Enabled = hasTabs;

            // Context menu
            // ********
            if (tabControl.TabPages.Count >= 1)
                if (sender == tabControl.TabPages[0])
                {
                    menuItem10.Enabled = (tabControl.SelectedForm as ProjectForm).ToolbarButtons[0];
                    menuItem6.Enabled = (tabControl.SelectedForm as ProjectForm).Tag?.ToString().ToLower() == "dirty";
                }

            toolbarSaveAs.Enabled = menuItem6.Enabled;
            toolbarCloseProject.Enabled = menuItem12.Enabled;
            toolbarRetrieveGameData.Enabled = menuItem10.Enabled;
            toolbarExport.Enabled = menuItem11.Enabled;
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
            string name = sender.GetType() == typeof(MenuItem) ? (sender as MenuItem).Name.ToString() : (sender as ToolStripItem).Name.ToString();

            try
            {
                addTab((Platform)Enum.Parse(typeof(Platform), name));
            }

            catch
            {
                name = name.Substring(0, name.Length - 1);

                if (Enum.TryParse(name, out Platform console))
                    addTab(console);
            }
        }

        private void addTab(Platform platform, Project x = null)
        {
            ProjectForm p = new(platform, null, x);
            p.Shown += TabChanged;
            p.FormClosed += TabChanged;
            tabControl.TabPages.Add(p);

            tabControl.Visible = true;
            mainPanel.Visible = false;

            // BrowseROMDialog(p);
        }

        private void OpenROM_Click(object sender, EventArgs e) => BrowseROMDialog();

        private void BrowseROMDialog()
        {
            if (tabControl.SelectedForm != null)
            {
                var p = tabControl.SelectedForm as ProjectForm;
                p.BrowseROMDialog();
            }
        }

        private void UseLibRetro_Click(object sender, EventArgs e) => (tabControl.SelectedForm as ProjectForm)?.LoadGameData();

        private void OpenImage_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedForm != null)
            {
                var p = tabControl.SelectedForm as ProjectForm;
                p.BrowseImageDialog();
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

        private void CloseTab_Click(object sender, EventArgs e) { var tab = tabControl.SelectedForm as Form; tab?.Close(); }

        private void About_Click(object sender, EventArgs e) { using var about = new About() { Font = Font }; about.ShowDialog(); }

        private void MenuItem_Exit_Click(object sender, EventArgs e) => Application.Exit();

        private void ExportWAD_Click(object sender, EventArgs e)
        {
            var currentForm = tabControl.SelectedForm as ProjectForm;
            if (currentForm == null) return;

            SaveWAD.FileName = currentForm?.GetName(true);
            SaveWAD.Filter = currentForm.IsForwarder ? Program.Lang.String("filter.zip") : Program.Lang.String("filter.wad");

            if (SaveWAD.ShowDialog() == DialogResult.OK) currentForm?.SaveToWAD(SaveWAD.FileName);
        }

        private void SaveAs_Click(object sender, EventArgs e) => SaveAs_Trigger();

        public bool SaveAs_Trigger()
        {
            try
            {
                if (tabControl.SelectedForm is not ProjectForm currentForm) return false;

                SaveProject.FileName = currentForm?.GetName(false) ?? currentForm.Text;
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
                var project = new Project();

                try
                {
                    using Stream stream = File.Open(BrowseProject.FileName, FileMode.Open);
                    var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    project = (Project)binaryFormatter.Deserialize(stream);
                }

                catch
                {
                    MessageBox.Show("Not a valid project file!", MessageBox.Buttons.Ok, MessageBox.Icons.Error);
                    return;
                }

                addTab(project.Platform, project);
            }
        }
    }
}
