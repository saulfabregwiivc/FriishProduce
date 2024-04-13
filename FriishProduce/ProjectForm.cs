﻿using libWiiSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FriishProduce
{
    public partial class ProjectForm : Form
    {
        public Console Console;
        protected string TIDCode;
        protected string Untitled;
        protected string oldImgPath = "null";
        protected string newImgPath = "null";
        protected string WADPath = null;

        public bool ReadyToExport
        {
            get
            {
                bool yes = !string.IsNullOrEmpty(Creator?.TitleID) && Creator?.TitleID.Length == 4
                            && !string.IsNullOrWhiteSpace(ChannelTitle.Text)
                            && !string.IsNullOrEmpty(Creator?.BannerTitle)
                            && (Img != null)
                            && ROM?.Path != null;

                return SaveDataTitle.Visible ? yes && !string.IsNullOrEmpty(Creator?.SaveDataTitle[0]) : yes;
            }
        }

        // -----------------------------------
        // Public variables
        // -----------------------------------
        protected ROM ROM { get; set; }
        protected WAD OutWAD { get; set; }
        protected string PatchFile { get; set; }
        protected string Manual { get; set; }
        protected LibRetroDB LibRetro { get; set; }
        protected Database Database { get; set; }
        protected ImageHelper Img { get; set; }
        protected Creator Creator { get; set; }

        protected InjectorWiiVC VC { get; set; }

        // -----------------------------------
        // Options
        // -----------------------------------
        protected ContentOptions CO { get; set; }

        // -----------------------------------
        // Connection with parent form
        // -----------------------------------
        public new MainForm Parent { get; set; }
        public event EventHandler ExportCheck;
        private ProjectType ParentProject { get; set; }
        public bool ROMLoaded { get => ROM?.Path != null; }
        private bool FormEnabled { get => groupBox1.Enabled && groupBox2.Enabled; }
        private bool isVCMode { get => InjectorsList.SelectedItem?.ToString().ToLower() == Program.Lang.String("vc").ToLower(); }


        // -----------------------------------

        public void Save()
        {
            var p = new ProjectType();
            p.Console = Console;
            p.Creator = Creator;
            p.ROM = ROM?.Path;
            p.PatchFile = PatchFile;
            p.Img = Img?.Source ?? null;
            p.Options = CO?.Options ?? null;
            p.LibRetro = LibRetro;
            p.WADRegion = TargetRegion.SelectedIndex;
            p.Base = (Base.SelectedIndex, 0);
            p.LinkSaveDataTitle = LinkSaveData.Checked;
            p.ImageOptions = (imageintpl.SelectedIndex, image_fit.Checked);

            for (int i = 0; i < BaseRegionList.Items.Count; i++)
                if (BaseRegionList.Items[i].GetType() == typeof(ToolStripMenuItem) && (BaseRegionList.Items[i] as ToolStripMenuItem).Checked) p.Base = (Base.SelectedIndex, i);

            using (Stream stream = File.Open(Parent.SaveProject.FileName, FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, p);
            }

            Tag = null;
            ExportCheck.Invoke(this, EventArgs.Empty);
        }

        private void ToggleControls(bool value)
        {
            Random.Visible =
            groupBox1.Enabled =
            groupBox2.Enabled =
            groupBox2.Enabled =
            groupBox3.Enabled =
            groupBox4.Enabled =
            groupBox5.Enabled =
            groupBox6.Enabled =
            groupBox7.Enabled = value;
        }

        public void RefreshForm()
        {
            // ----------------------------
            if (DesignMode) return;
            // ----------------------------
            #region Localization
            Program.Lang.Control(this, "projectform");
            title_id_2.Text = title_id.Text;
            BrowsePatch.Filter = Program.Lang.String("filter.patch");

            // Change title text to untitled string
            Untitled = string.Format(Program.Lang.String("untitled_project", "mainform"), Program.Lang.String(Enum.GetName(typeof(Console), Console).ToLower(), "platforms"));
            Text = string.IsNullOrWhiteSpace(ChannelTitle.Text) ? Untitled : ChannelTitle.Text;

            SetROMDataText();

            var baseMax = Math.Max(base_name.Location.X + base_name.Width - 4, title_id.Location.X + title_id.Width - 4);
            baseName.Location = new Point(baseMax, base_name.Location.Y);
            baseID.Location = new Point(baseMax, title_id.Location.Y);

            // Selected index properties
            imageintpl.Items.Clear();
            imageintpl.Items.AddRange(Program.Lang.StringArray("image_interpolation_mode", Name));
            imageintpl.SelectedIndex = Properties.Settings.Default.ImageInterpolation;

            // Regions lists
            TargetRegion.Items.Clear();
            TargetRegion.Items.Add(Program.Lang.String("region_rf"));
            TargetRegion.SelectedIndex = 0;

            switch (Program.Lang.Current.ToLower())
            {
                default:
                    TargetRegion.Items.Add(Program.Lang.String("region_u"));
                    TargetRegion.Items.Add(Program.Lang.String("region_e"));
                    TargetRegion.Items.Add(Program.Lang.String("region_j"));
                    TargetRegion.Items.Add(Program.Lang.String("region_k"));
                    break;

                case "ja":
                    TargetRegion.Items.Add(Program.Lang.String("region_j"));
                    TargetRegion.Items.Add(Program.Lang.String("region_u"));
                    TargetRegion.Items.Add(Program.Lang.String("region_e"));
                    TargetRegion.Items.Add(Program.Lang.String("region_k"));
                    break;

                case "ko":
                    TargetRegion.Items.Add(Program.Lang.String("region_k"));
                    TargetRegion.Items.Add(Program.Lang.String("region_u"));
                    TargetRegion.Items.Add(Program.Lang.String("region_e"));
                    TargetRegion.Items.Add(Program.Lang.String("region_j"));
                    break;
            }
            #endregion

            if (Base.SelectedIndex >= 0)
                for (int i = 0; i < Database.Entries[Base.SelectedIndex].Regions.Count; i++)
                {
                    switch (Database.Entries[Base.SelectedIndex].Regions[i])
                    {
                        default:
                        case 0:
                            BaseRegionList.Items[i].Text = Program.Lang.String("region_j");
                            break;

                        case 1:
                        case 2:
                            BaseRegionList.Items[i].Text = Program.Lang.String("region_u");
                            break;

                        case 3:
                        case 4:
                        case 5:
                            BaseRegionList.Items[i].Text = Program.Lang.String("region_e");
                            break;

                        case 6:
                        case 7:
                            BaseRegionList.Items[i].Text = Program.Lang.String("region_k");
                            break;
                    }
                }


            for (int i = 0; i < Base.Items.Count; i++)
            {
                var title = Database.Entries[i].Regions.Contains(0) && Program.Lang.Current.StartsWith("ja") ? Database.Entries[i].Titles[0]
                          : Database.Entries[i].Regions.Contains(0) && Program.Lang.Current.StartsWith("ko") ? Database.Entries[i].Titles[Database.Entries[i].Titles.Count - 1]
                          : Database.Entries[i].Regions.Contains(0) && Database.Entries[i].Regions.Count > 1 ? Database.Entries[i].Titles[1]
                          : Database.Entries[i].Titles[0];

                Base.Items[i] = title;
            }

            // Injection methods list
            InjectorsList.Items.Clear();

            switch (Console)
            {
                case Console.NES:
                    InjectorsList.Items.Add(Program.Lang.String("vc"));
                    InjectorsList.Items.Add(Forwarder.List[0]);
                    InjectorsList.Items.Add(Forwarder.List[1]);
                    InjectorsList.Items.Add(Forwarder.List[2]);
                    break;

                case Console.SNES:
                    InjectorsList.Items.Add(Program.Lang.String("vc"));
                    InjectorsList.Items.Add(Forwarder.List[3]);
                    InjectorsList.Items.Add(Forwarder.List[4]);
                    InjectorsList.Items.Add(Forwarder.List[5]);
                    break;

                case Console.N64:
                    InjectorsList.Items.Add(Program.Lang.String("vc"));
                    InjectorsList.Items.Add(Forwarder.List[8]);
                    InjectorsList.Items.Add(Forwarder.List[9]);
                    InjectorsList.Items.Add(Forwarder.List[10]);
                    InjectorsList.Items.Add(Forwarder.List[11]);
                    break;

                case Console.SMS:
                case Console.SMD:
                    InjectorsList.Items.Add(Program.Lang.String("vc"));
                    InjectorsList.Items.Add(Forwarder.List[7]);
                    break;

                case Console.PCE:
                case Console.NEO:
                case Console.MSX:
                case Console.C64:
                    InjectorsList.Items.Add(Program.Lang.String("vc"));
                    break;

                case Console.Flash:
                    InjectorsList.Items.Add(Program.Lang.String("by_default"));
                    break;

                case Console.GBA:
                    InjectorsList.Items.Add(Forwarder.List[6]);
                    break;

                case Console.PSX:
                    InjectorsList.Items.Add(Forwarder.List[12]);
                    break;

                default:
                    break;
            }

            InjectorsList.SelectedIndex = 0;
            label3.Enabled = InjectorsList.Enabled = InjectorsList.Items.Count > 1;

            if (Properties.Settings.Default.ImageFitAspectRatio) image_fit.Checked = true; else image_stretch.Checked = true;
        }

        public ProjectForm(Console c, string ROMpath = null)
        {
            Console = c;
            Database = new Database(Console);

            InitializeComponent();

            if (ROMpath != null)
            {
                ROM.Path = ROMpath;
                LoadROM(ROM.Path, Properties.Settings.Default.AutoLibRetro);
            }
        }

        public ProjectForm(ProjectType p)
        {
            Console = p.Console;
            Database = new Database(Console);
            ParentProject = p;

            InitializeComponent();
        }

        private void Form_Shown(object sender, EventArgs e)
        {
            // ----------------------------
            if (DesignMode) return;
            // ----------------------------

            // Declare WAD metadata modifier
            // ********
            Creator = new Creator();
            TIDCode = null;

            using (var icon = new Bitmap(Parent.Icons[Console]))
            {
                icon.MakeTransparent(Color.White);
                Icon = Icon.FromHandle(icon.GetHicon());
            }

            switch (Console)
            {
                case Console.NES:
                    TIDCode = "F";
                    ROM = new ROM_NES();
                    break;

                case Console.SNES:
                    TIDCode = "J";
                    ROM = new ROM_SNES();
                    break;

                case Console.N64:
                    TIDCode = "N";
                    ROM = new ROM_N64();
                    break;

                case Console.SMS:
                    TIDCode = "L";
                    ROM = new ROM_SEGA() { IsSMS = true };
                    break;

                case Console.SMD:
                    TIDCode = "M";
                    ROM = new ROM_SEGA() { IsSMS = false };
                    break;

                case Console.PCE:
                    TIDCode = "P"; // Q for CD games
                    ROM = new ROM_PCE();
                    break;

                case Console.NEO:
                    TIDCode = "E";
                    ROM = new ROM_NEO();
                    break;

                case Console.MSX:
                    TIDCode = "X";
                    ROM = new ROM_MSX();
                    break;

                case Console.Flash:
                    ROM = new SWF();
                    software_name.Enabled = Patch.Enabled = false;
                    break;

                default:
                    ROM = new Disc();
                    break;
            }

            LibRetro = Parent.LibRetro;

            // Cosmetic
            // ********
            if (Console == Console.SMS || Console == Console.SMD) SaveIcon_Panel.BackgroundImage = Properties.Resources.SaveIconPlaceholder_SEGA;
            RefreshForm();

            Creator.BannerYear = (int)ReleaseYear.Value;
            Creator.BannerPlayers = (int)Players.Value;

            AddBases();

            if (ParentProject != null)
            {
                Creator = ParentProject.Creator;

                if (ParentProject.LibRetro != null) LibRetro = ParentProject.LibRetro;
                if (CO != null) CO.Options = ParentProject.Options;

                ROM.Path = File.Exists(ParentProject.ROM) ? ParentProject.ROM : null;

                Img = new ImageHelper(ParentProject.Console, null);
                Img.LoadToSource(ParentProject.Img);
                LoadImage(ParentProject.Img);

                Base.SelectedIndex = ParentProject.Base.Item1;
                for (int i = 0; i < BaseRegionList.Items.Count; i++)
                    if (BaseRegionList.Items[i].GetType() == typeof(ToolStripMenuItem)) (BaseRegionList.Items[i] as ToolStripMenuItem).Checked = false;
                (BaseRegionList.Items[ParentProject.Base.Item2] as ToolStripMenuItem).Checked = true;
                UpdateBaseForm(ParentProject.Base.Item2);

                SetROMDataText();

                ChannelTitle.Text = Creator.ChannelTitles[1];
                BannerTitle.Text = Creator.BannerTitle;
                ReleaseYear.Value = Creator.BannerYear;
                Players.Value = Creator.BannerPlayers;
                SaveDataTitle.Lines = Creator.SaveDataTitle;
                TitleID.Text = Creator.TitleID;
                TargetRegion.SelectedIndex = ParentProject.WADRegion;
                LinkSaveData.Checked = ParentProject.LinkSaveDataTitle;
                imageintpl.SelectedIndex = ParentProject.ImageOptions.Item1;
                image_fit.Checked = ParentProject.ImageOptions.Item2;

                PatchFile = File.Exists(ParentProject.PatchFile) ? ParentProject.PatchFile : null;
                Patch.Checked = !string.IsNullOrWhiteSpace(ParentProject.PatchFile);

                ParentProject = null;
                ToggleControls(!string.IsNullOrEmpty(ROM?.Path));
            }

            FStorage_USB.Checked = Options.FORWARDER.Default.root_storage_device.ToLower().Contains("usb");
            FStorage_SD.Checked = !FStorage_USB.Checked;
            toggleSwitch1.Checked = Options.FORWARDER.Default.nand_loader.ToLower().Contains("vwii");
            CustomManual.Enabled = Console != Console.NEO && Console != Console.PCE;

            Tag = null;
            ExportCheck.Invoke(this, EventArgs.Empty);
        }

        // -----------------------------------

        protected virtual void CheckExport()
        {
            // ----------------------------
            if (DesignMode || ParentProject != null) return;
            // ----------------------------

            Creator.TitleID = TitleID.Text;
            Creator.BannerTitle = BannerTitle.Text;
            Creator.BannerYear = (int)ReleaseYear.Value;
            Creator.BannerPlayers = (int)Players.Value;
            Creator.SaveDataTitle =
                SaveDataTitle.Lines.Length == 1 ? new string[] { SaveDataTitle.Text } :
                SaveDataTitle.Lines.Length == 0 ? new string[] { "" } :
                SaveDataTitle.Lines;

            SetROMDataText();

            Tag = "dirty";
            ExportCheck.Invoke(this, EventArgs.Empty);
        }

        public bool[] CheckToolStripButtons() => new bool[]
            {
                Console != Console.Flash && (ROM?.Bytes != null || !string.IsNullOrWhiteSpace(ROM?.Path)), // LibRetro
                Console != Console.Flash && isVCMode, // Browse manual
            };

        protected virtual void SetROMDataText()
        {
            filename.Text = string.Format(Program.Lang.String("filename", Name), !string.IsNullOrWhiteSpace(ROM?.Path) ? Path.GetFileName(ROM.Path) : Program.Lang.String("unknown"));

            if (LibRetro == null)
                software_name.Text = string.Format(Program.Lang.String("software_name", Name), Program.Lang.String("unknown"));
            else
                software_name.Text = string.Format(Program.Lang.String("software_name", Name), LibRetro.GetCleanTitle()?.Replace(Environment.NewLine, " - ") ?? Program.Lang.String("unknown"));

            label11.Text = !string.IsNullOrWhiteSpace(PatchFile) ? Path.GetFileName(PatchFile) : Program.Lang.String("none");
            label11.Enabled = !string.IsNullOrWhiteSpace(PatchFile);

            pictureBox1.Image = Preview.Banner(Console, BannerTitle.Text, (int)ReleaseYear.Value, (int)Players.Value, Img?.VCPic, (int)Creator.OrigRegion);
            pictureBox2.Image = Preview.Icon(Img?.IconVCPic);
        }

        private void RandomTID() => TitleID.Text = Creator.TitleID = TIDCode != null ? TIDCode + GenerateTitleID().Substring(0, 3) : GenerateTitleID();

        public string GetName()
        {
            return Patch.Checked ? Path.GetFileNameWithoutExtension(PatchFile) + $" [{TitleID.Text.ToUpper()}]"
                 : ROM?.Path != null ? Path.GetFileNameWithoutExtension(ROM?.Path) + $" [{TitleID.Text.ToUpper()}]"

                 : $"{Console} - {ChannelTitle.Text} [{TitleID.Text.ToUpper()}]";
        }

        private void isClosing(object sender, FormClosingEventArgs e)
        {
            // ----------------------------
            if (DesignMode) return;
            // ----------------------------

            e.Cancel = !CheckUnsaved();
        }

        public bool CheckUnsaved()
        {
            if (Tag?.ToString() == "dirty")
            {
                var result = MessageBox.Show(string.Format(Program.Lang.Msg(1), Text), null, new string[] { Program.Lang.String("b_save"), Program.Lang.String("b_dont_save"), Program.Lang.String("b_cancel") });
                {
                    if (result == MessageBox.Result.Button1)
                    {
                        return Parent.SaveAs_Trigger();
                    }

                    else if (result == MessageBox.Result.Button2)
                    {
                        return true;
                    }

                    else if (result == MessageBox.Result.Cancel || result == MessageBox.Result.Button3)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private void Random_Click(object sender, EventArgs e) => RandomTID();

        private void Value_Changed(object sender, EventArgs e) => CheckExport();

        private void LinkSaveDataTitle()
        {
            if (LinkSaveData.Checked)
            {
                string[] lines = new string[2];
                int limit = SaveDataTitle.Multiline ? SaveDataTitle.MaxLength / 2 : SaveDataTitle.MaxLength;
                if (ChannelTitle.TextLength <= limit) lines[0] = ChannelTitle.Text;
                if (BannerTitle.Lines.Length > 1 && BannerTitle.Lines[1].Length <= limit) lines[1] = BannerTitle.Lines[1];

                SaveDataTitle.Text
                    = string.IsNullOrWhiteSpace(lines[1]) ? lines[0]
                    : string.IsNullOrWhiteSpace(lines[0]) ? lines[1]
                    : string.IsNullOrWhiteSpace(lines[0]) && string.IsNullOrWhiteSpace(lines[1]) ? null
                    : SaveDataTitle.Multiline ? string.Join(Environment.NewLine, lines) : lines[0];

                if (FormEnabled) CheckExport();
            }
        }

        private void LinkSaveData_Changed(object sender, EventArgs e)
        {
            if (sender == LinkSaveData)
            {
                SaveDataTitle.Enabled = !LinkSaveData.Checked;
                if (LinkSaveData.Checked) LinkSaveDataTitle();
            }
        }

        private void TextBox_Changed(object sender, EventArgs e)
        {
            if (sender == ChannelTitle)
            {
                Text = string.IsNullOrWhiteSpace(ChannelTitle.Text) ? Untitled : ChannelTitle.Text;

                if (!ChannelTitle_Locale.Checked)
                {
                    ChannelTitle_Locale.Enabled = !string.IsNullOrWhiteSpace(ChannelTitle.Text);
                    Creator.ChannelTitles = new string[8] { ChannelTitle.Text, ChannelTitle.Text, ChannelTitle.Text, ChannelTitle.Text, ChannelTitle.Text, ChannelTitle.Text, ChannelTitle.Text, ChannelTitle.Text };
                }
            }

            if (sender == BannerTitle || sender == ChannelTitle) LinkSaveDataTitle();

            var currentSender = sender as TextBox;
            if (currentSender.Multiline && currentSender.Lines.Length > 2) currentSender.Lines = new string[] { currentSender.Lines[0], currentSender.Lines[1] };

            CheckExport();
        }

        private void TextBox_Handle(object sender, KeyPressEventArgs e)
        {
            var currentSender = sender as TextBox;
            var currentIndex = currentSender.GetLineFromCharIndex(currentSender.SelectionStart);
            var lineMaxLength = currentSender.Multiline ? Math.Round((double)currentSender.MaxLength / 2) : currentSender.MaxLength;

            if (!string.IsNullOrEmpty(currentSender.Text)
                && currentSender.Lines[currentIndex].Length >= lineMaxLength
                && e.KeyChar != (char)Keys.Delete && e.KeyChar != (char)8 && e.KeyChar != (char)Keys.Enter)
                goto Handled;

            if (currentSender.Multiline && currentSender.Lines.Length == 2 && e.KeyChar == (char)Keys.Enter) goto Handled;

            return;

        Handled:
            System.Media.SystemSounds.Beep.Play();
            e.Handled = true;
        }

        private void OpenWAD_CheckedChanged(object sender, EventArgs e)
        {
            // ----------------------------
            if (DesignMode) return;
            // ----------------------------

            Base.Enabled = BaseRegion.Enabled = !ImportWAD.Checked;
            if (Base.Enabled)
            {
                AddBases();
            }
            else
            {
                Base.Items.Clear();
                BaseRegion.Image = null;
            }

            if (ImportWAD.Checked && WADPath == null)
            {
                BrowseWAD.Title = ImportWAD.Text;
                BrowseWAD.Filter = Program.Lang.String("filter.wad");
                var result = BrowseWAD.ShowDialog();

                if (result == DialogResult.OK && !LoadWAD(BrowseWAD.FileName)) ImportWAD.Checked = false;
                else if (result == DialogResult.Cancel) ImportWAD.Checked = false;
            }
            else
            {
                WADPath = null;
            }

            if (groupBox2.Enabled) CheckExport();
        }

        private void InterpolationChanged(object sender, EventArgs e)
        {
            // ----------------------------
            if (DesignMode) return;
            // ----------------------------

            if (imageintpl.SelectedIndex != Properties.Settings.Default.ImageInterpolation) Tag = "dirty";
            LoadImage();
        }

        private void SwitchAspectRatio(object sender, EventArgs e)
        {
            // ----------------------------
            if (DesignMode) return;
            // ----------------------------

            if (sender == image_stretch || sender == image_fit)
            {
                if (sender == image_stretch && image_fit.Checked)
                {
                    Tag = "dirty";
                    image_fit.Checked = !image_stretch.Checked;
                }

                else if (sender == image_fit && image_stretch.Checked)
                {
                    Tag = "dirty";
                    image_stretch.Checked = !image_fit.Checked;
                }

                LoadImage();
            }

            else if (groupBox3.Enabled) CheckExport();
        }

        #region Load Data Functions
        private string GenerateTitleID()
        {
            var r = new Random();
            string allowed = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(allowed, 4).Select(s => s[r.Next(s.Length)]).ToArray());
        }

        public bool LoadWAD(string path)
        {
            WAD Reader = new WAD();

            try
            {
                Reader = WAD.Load(path);
            }
            catch
            {
                MessageBox.Show(Program.Lang.Msg(2), 0, Ookii.Dialogs.WinForms.TaskDialogIcon.Warning);
                return false;
            }

            foreach (var entry in Database.Entries)
                for (int i = 0; i < entry.Regions.Count; i++)
                    if (entry.GetUpperID(i) == Reader.UpperTitleID.ToUpper())
                    {
                        WADPath = path;

                        baseName.Text = entry.Titles[i];
                        baseID.Text = entry.GetUpperID(i);
                        UpdateBaseGeneral(0);
                        Reader.Dispose();
                        return true;
                    }

            Reader.Dispose();
            System.Media.SystemSounds.Beep.Play();
            MessageBox.Show(string.Format(Program.Lang.Msg(5), Reader.UpperTitleID));
            return false;
        }

        public void LoadManual(string path)
        {
            if (path != null)
            {
                // Check if is a valid emanual contents folder
                // ****************
                string folder = null;
                if (Directory.Exists(Path.Combine(path, "emanual")))
                    folder = Path.Combine(path, "emanual");
                else if (Directory.Exists(Path.Combine(path, "html")))
                    folder = Path.Combine(path, "html");

                int validFiles = 0;
                if (folder != null)
                    foreach (var item in Directory.EnumerateFiles(folder))
                    {
                        if ((Path.GetFileNameWithoutExtension(item).StartsWith("startup") && Path.GetExtension(item) == ".html")
                         || Path.GetFileName(item) == "standard.css"
                         || Path.GetFileName(item) == "contents.css"
                         || Path.GetFileName(item) == "vsscript.css") validFiles++;
                    }

                if (validFiles < 2)
                {
                    MessageBox.Show(Program.Lang.Msg(7), MessageBox.Buttons.Ok, Ookii.Dialogs.WinForms.TaskDialogIcon.Warning);
                    Manual = null;
                    return;
                }
            }

            Manual = path;
            CustomManual.Checked = Manual != null;
        }

        public void LoadImage()
        {
            if (Creator != null && Img != null) LoadImage(Img.Source);
            else CheckExport();
        }

        public void LoadImage(string path)
        {
            if (Img != null) oldImgPath = newImgPath;
            newImgPath = path;

            if (Img == null) Img = new ImageHelper(Console, path);
            else Img.Create(Console, path);

            LoadImage(Img.Source);
        }

        public bool LoadImage(Bitmap src)
        {
            if (src == null) return false;

            try
            {
                Bitmap img = (Bitmap)src.Clone();

                Img.Interpolation = (InterpolationMode)imageintpl.SelectedIndex;
                Img.FitAspectRatio = image_fit.Checked;

                // Additionally edit image before generating files, e.g. with modification of image palette/brightness, used only for images with exact resolution of original screen size
                // ********
                switch (Console)
                {
                    default:
                        break;

                    case Console.NES:
                        if (InjectorsList.SelectedIndex == 0
                            && src.Width == 256 && (src.Height == 224 || src.Height == 240)
                            && CO.Options != null
                            && bool.Parse(CO.Options["use_tImg"]))
                        {
                            var CO_NES = CO as Options_VC_NES;

                            if (CO_NES.ImgPaletteIndex == -1 || oldImgPath != newImgPath)
                                CO_NES.ImgPaletteIndex = CO_NES.CheckPalette(img);

                            img = CO_NES.SwapColors(img, CO_NES.Palettes[CO_NES.ImgPaletteIndex], CO_NES.Palettes[int.Parse(CO_NES.Options["palette"])]);
                        }
                        break;

                    case Console.SMS:
                    case Console.SMD:
                        break;
                }

                Img.Generate(img);
                img.Dispose();

                if (Img.Source != null)
                {
                    SaveIcon_Panel.BackgroundImage = Img.SaveIcon();
                    pictureBox2.Image = Preview.Icon(Img.IconVCPic);
                }

                CheckExport();
                return true;
            }
            catch
            {
                MessageBox.Show(Program.Lang.Msg(1, true));
                return false;
            }
        }

        public void LoadROM(bool UseLibRetro = true) => LoadROM(Parent.BrowseROM.FileName, UseLibRetro);

        public void LoadROM(string ROMpath, bool UseLibRetro = true)
        {
            switch (Console)
            {
                default:
                case Console.NES:
                case Console.SNES:
                case Console.N64:
                case Console.SMS:
                case Console.SMD:
                case Console.PCE:
                case Console.C64:
                case Console.MSX:
                    if (ROM == null || !ROM.CheckValidity(ROMpath))
                    {
                        MessageBox.Show(Program.Lang.Msg(2), 0, Ookii.Dialogs.WinForms.TaskDialogIcon.Warning);
                        return;
                    }
                    break;

                case Console.NEO:
                    // Check if ZIP archive is of valid format
                    // ****************
                    if (!ROM.CheckZIPValidity(ROMpath, new string[] { "c1", "c2", "m1", "p1", "s1", "v1" }, true, true))
                    {
                        MessageBox.Show(Program.Lang.Msg(2), 0, Ookii.Dialogs.WinForms.TaskDialogIcon.Warning);
                        return;
                    }
                    break;

                case Console.Flash:
                    break;
            }

            if (ROM != null) ROM.Path = ROMpath;

            PatchFile = null;
            Patch.Checked = false;

            ToggleControls(true);
            RandomTID();
            CheckExport();

            Parent.tabControl.Visible = true;

            if (ROM != null && UseLibRetro && CheckToolStripButtons()[0]) LoadLibRetroData();
        }

        public async void LoadLibRetroData()
        {
            if (ROM == null || ROM.Path == null) return;

            try
            {
                LibRetro = new LibRetroDB { SoftwarePath = ROM.Path };
                var Retrieved = await Task.FromResult(LibRetro.Get(Console));
                if (Retrieved)
                {
                    // Set banner title
                    BannerTitle.Text = Creator.BannerTitle = LibRetro.GetCleanTitle() ?? Creator.BannerTitle;

                    // Set channel title text
                    if (LibRetro.GetCleanTitle() != null)
                    {
                        var text = LibRetro.GetCleanTitle().Replace("\r", "").Split('\n');
                        if (text[0].Length <= ChannelTitle.MaxLength) { ChannelTitle_Locale.Checked = false; ChannelTitle.Text = text[0]; }
                        if (ChannelTitle.TextLength <= SaveDataTitle.MaxLength) SaveDataTitle.Text = ChannelTitle.Text;
                    }

                    // Set image
                    if (LibRetro.GetImgURL() != null) { LoadImage(LibRetro.GetImgURL()); }

                    // Set year and players
                    ReleaseYear.Value = Creator.BannerYear = !string.IsNullOrEmpty(LibRetro.GetYear()) ? int.Parse(LibRetro.GetYear()) : Creator.BannerYear;
                    Players.Value = Creator.BannerPlayers = !string.IsNullOrEmpty(LibRetro.GetPlayers()) ? int.Parse(LibRetro.GetPlayers()) : Creator.BannerPlayers;
                }

                if (Retrieved) CheckExport();

                // Show message if partially failed to retrieve data
                if (Retrieved && (LibRetro.GetTitle() == null || LibRetro.GetPlayers() == null || LibRetro.GetYear() == null || LibRetro.GetImgURL() == null))
                    MessageBox.Show(Program.Lang.Msg(4));
                else if (!Retrieved) System.Media.SystemSounds.Beep.Play();

            }
            catch (Exception ex)
            {
                MessageBox.Show(Program.Lang.String("error", "messages"), ex.Message, MessageBox.Buttons.Ok, Properties.Resources.brick);
            }
        }

        public bool SaveToWAD()
        {
            try
            {
                Parent.CleanTemp();
                Creator.Out = Parent.SaveWAD.FileName;

                if (Patch.Checked) ROM.Patch(PatchFile);

                OutWAD = new WAD();

                // Get WAD data
                // *******
                if (WADPath != null) OutWAD = WAD.Load(WADPath);
                else foreach (var entry in Database.Entries)
                        for (int i = 0; i < entry.Regions.Count; i++)
                            if (entry.GetUpperID(i) == baseID.Text.ToUpper()) OutWAD = entry.GetWAD(i);

                switch (Console)
                {
                    case Console.NES:
                    case Console.SNES:
                    case Console.N64:
                    case Console.SMS:
                    case Console.SMD:
                    case Console.PCE:
                    case Console.NEO:
                    case Console.MSX:
                        if (isVCMode)
                            WiiVCInject();
                        else
                            ForwarderCreator();
                        break;

                    case Console.GBA:
                        ForwarderCreator();
                        break;

                    case Console.Flash:
                        FlashInject();
                        break;

                    default:
                        throw new NotImplementedException();
                }

                // Banner
                // *******
                BannerHelper.Modify(OutWAD, Console, OutWAD.Region, Creator.BannerTitle, Creator.BannerYear, Creator.BannerPlayers);
                if (Img.VCPic != null) Img.ReplaceBanner(OutWAD);

                // Other WAD settings to be changed
                // *******
                OutWAD.Region = TargetRegion.SelectedItem.ToString() == Program.Lang.String("region_j") ? libWiiSharp.Region.Japan
                    : TargetRegion.SelectedItem.ToString() == Program.Lang.String("region_u") ? libWiiSharp.Region.USA
                    : TargetRegion.SelectedItem.ToString() == Program.Lang.String("region_e") ? libWiiSharp.Region.Europe
                    : TargetRegion.SelectedItem.ToString() == Program.Lang.String("region_k") ? libWiiSharp.Region.Korea
                    : libWiiSharp.Region.Free;

                // Remaining ones done by WAD creator helper, which will save to a new file
                // *******
                Creator.MakeWAD(OutWAD);

                // Check new WAD file
                // *******
                if (File.Exists(Creator.Out) && File.ReadAllBytes(Creator.Out).Length > 10)
                {
                    System.Media.SystemSounds.Beep.Play();

                    var Message = MessageBox.Show(Program.Lang.Msg(3), null, MessageBox.Buttons.Custom, Ookii.Dialogs.WinForms.TaskDialogIcon.Information);

                    if (Message == MessageBox.Result.Button1)
                    {
                        string args = string.Format("/e, /select, \"{0}\"", Creator.Out);

                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                        {
                            FileName = "explorer",
                            Arguments = args
                        });
                    }

                    return true;
                }
                else throw new Exception(Program.Lang.Msg(6, true));
            }

            catch (Exception ex)
            {
                MessageBox.Show(Program.Lang.String("error", "messages"), ex.Message, MessageBox.Buttons.Ok, Properties.Resources.brick);
                return false;
            }

            finally
            {
                Creator.Out = null;
                OutWAD = null;
                Parent.CleanTemp();
                if (VC != null) VC.Dispose();
            }
        }

        public void ForwarderCreator()
        {
            Forwarder f = new Forwarder()
            {
                ROM = ROM.Bytes,
                ROMExtension = Path.GetExtension(this.ROM.Path),
                ID = Creator.TitleID,
                Emulator = InjectorsList.SelectedItem.ToString(),
                Storage = FStorage_USB.Checked ? Forwarder.Storages.USB : Forwarder.Storages.SD
            };

            // Actually inject everything
            // *******
            f.CreateZIP(Path.Combine(Path.GetDirectoryName(Creator.Out), Path.GetFileNameWithoutExtension(Creator.Out) + $" ({f.Storage}).zip"));
            OutWAD = f.CreateWAD(OutWAD, toggleSwitch1.Checked);
        }

        public void FlashInject()
        {
            Injectors.Flash.Settings = CO.Options;
            OutWAD = Injectors.Flash.Inject(OutWAD, ROM.Path, Creator.SaveDataTitle, Img);
        }

        public void WiiVCInject()
        {
            // Create Wii VC injector to use
            // *******
            switch (Console)
            {
                default:
                    throw new NotImplementedException();

                // NES
                // *******
                case Console.NES:
                    VC = new Injectors.NES();
                    break;

                // SNES
                // *******
                case Console.SNES:
                    VC = new Injectors.SNES();
                    break;

                // N64
                // *******
                case Console.N64:
                    VC = new Injectors.N64()
                    {
                        Settings = CO.Options,

                        CompressionType = CO.EmuType == 3 ? (CO.Options.ElementAt(3).Value == "0" ? 1 : 2) : 0,
                        Allocate = CO.Options.ElementAt(3).Value == "True" && (CO.EmuType <= 1),
                    };
                    break;

                // SEGA
                // *******
                case Console.SMS:
                case Console.SMD:
                    VC = new Injectors.SEGA()
                    {
                        IsSMS = Console == Console.SMS
                    };
                    break;

                // PCE
                // *******
                case Console.PCE:
                    VC = new Injectors.PCE();
                    break;

                // NEOGEO
                // *******
                case Console.NEO:
                    VC = new Injectors.NEO();
                    break;

                // MSX
                // *******
                case Console.MSX:
                    VC = new Injectors.MSX();
                    break;
            }

            VC.WAD = OutWAD;

            // Get settings from relevant form
            // *******
            if (CO != null) { VC.Settings = CO.Options; } else { VC.Settings = new Dictionary<string, string> { { "N/A", "N/A" } }; }

            // Set path to manual folder (if it exists) and load WAD
            // *******
            VC.ManualPath = Manual;

            // Actually inject everything
            // *******
            OutWAD = VC.Inject(ROM, Creator.SaveDataTitle, Img);
        }
        #endregion

        #region **Console-Specific Functions**
        // ******************
        // CONSOLE-SPECIFIC
        // ******************
        private void OpenInjectorOptions(object sender, EventArgs e)
        {
            var result = CO.ShowDialog(this) == DialogResult.OK;

            switch (Console)
            {
                default:
                case Console.SNES:
                case Console.MSX:
                    break;

                case Console.NES:
                    if (result) { LoadImage(); }
                    break;

                case Console.N64:
                case Console.SMS:
                case Console.SMD:
                case Console.PCE:
                case Console.NEO:
                case Console.Flash:
                    if (result) { CheckExport(); }
                    break;
            }
        }
        #endregion

        #region Base WAD Management/Visual
        private void AddBases()
        {
            foreach (var entry in Database.Entries)
            {
                var title = entry.Regions.Contains(0) && Program.Lang.Current.StartsWith("ja") ? entry.Titles[0]
                          : entry.Regions.Contains(0) && Program.Lang.Current.StartsWith("ko") ? entry.Titles[entry.Titles.Count - 1]
                          : entry.Regions.Contains(0) && entry.Regions.Count > 1 ? entry.Titles[1]
                          : entry.Titles[0];

                Base.Items.Add(title);
            }

            if (Base.Items.Count > 0) { Base.SelectedIndex = 0; }

            Base.Enabled = Base.Items.Count > 1;
            UpdateBaseForm();
        }


        // -----------------------------------

        private void Base_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ----------------------------
            if (DesignMode) return;
            // ----------------------------

            var regions = new List<string>();
            for (int i = 0; i < Database.Entries[Base.SelectedIndex].Regions.Count; i++)
            {
                switch (Database.Entries[Base.SelectedIndex].Regions[i])
                {
                    case 0:
                        regions.Add(Program.Lang.String("region_j"));
                        break;

                    case 1:
                    case 2:
                        regions.Add(Program.Lang.String("region_u"));
                        break;

                    case 3:
                    case 4:
                    case 5:
                        regions.Add(Program.Lang.String("region_e"));
                        break;

                    case 6:
                    case 7:
                        regions.Add(Program.Lang.String("region_k"));
                        break;

                    default:
                        break;
                }
            }

            // Check if language is set to Japanese or Korean
            // If so, make Japan/Korea region item the first in the WAD region context list
            // ********
            var selected = regions.IndexOf(Program.Lang.String("region_u"));

            var altRegions = new Dictionary<string, int>()
            {
                { "ja", 0 },
                { "ko", 1 },
                { "fr", 2 },
                { "de", 2 },
                { "nl", 2 },
                { "it", 2 },
                { "pl", 2 },
                { "ru", 2 },
                { "uk", 2 },
                { "tr", 2 },
                { "hu", 2 },
                { "ca", 2 },
                { "eu", 2 },
                { "gl", 2 },
                { "ast", 2 },
                { "no", 2 },
                { "sv", 2 },
                { "fi", 2 },
                { "-GB", 2 },
                { "-UK", 2 },
                { "-ES", 2 },
                { "-PT", 2 },
                { "-RU", 2 },
                { "-IN", 2 },
                { "-ZA", 2 },
                { "-CA", 3 },
                { "-US", 3 },
                { "-MX", 3 },
                { "-BR", 3 },
            };
            foreach (var item in altRegions) if (Program.Lang.Current.ToLower().StartsWith(item.Key) || (item.Key.Contains("-") && Program.Lang.Current.ToLower().EndsWith(item.Key)))
                    selected = regions.IndexOf(item.Value == 0 ? Program.Lang.String("region_j") : item.Value == 1 ? Program.Lang.String("region_k") : item.Value == 2 ? Program.Lang.String("region_e") : Program.Lang.String("region_u"));

            if (selected == -1) selected = 0;

            // Reset currently-selected base info
            // ********
            BaseRegionList.Items.Clear();

            // Add regions to WAD region context list
            // ********
            for (int i = 0; i < Database.Entries[Base.SelectedIndex].Regions.Count; i++)
            {
                switch (Database.Entries[Base.SelectedIndex].Regions[i])
                {
                    case 0:
                        BaseRegionList.Items.Add(Program.Lang.String("region_j"), null, WADRegionList_Click);
                        break;

                    case 1:
                    case 2:
                        BaseRegionList.Items.Add(Program.Lang.String("region_u"), null, WADRegionList_Click);
                        break;

                    case 3:
                    case 4:
                    case 5:
                        BaseRegionList.Items.Add(Program.Lang.String("region_e"), null, WADRegionList_Click);
                        break;

                    case 6:
                    case 7:
                        BaseRegionList.Items.Add(Program.Lang.String("region_k"), null, WADRegionList_Click);
                        break;

                    default:
                        break;
                }
            }

            // Final visual updates
            // ********
            UpdateBaseForm(selected);
            BaseRegion.Cursor = BaseRegionList.Items.Count == 1 ? Cursors.Default : Cursors.Hand;
        }

        private void WADRegion_Click(object sender, EventArgs e)
        {
            if (BaseRegionList.Items.Count > 1)
                BaseRegionList.Show(this, PointToClient(Cursor.Position));
        }

        private void WADRegionList_Click(object sender, EventArgs e)
        {
            string targetRegion = (sender as ToolStripMenuItem).Text;

            for (int i = 0; i < BaseRegionList.Items.Count; i++)
            {
                if ((BaseRegionList.Items[i] as ToolStripMenuItem).Text == targetRegion)
                {
                    UpdateBaseForm(i);
                    CheckExport();
                    return;
                }
            }
        }

        private void UpdateBaseForm(int index = -1)
        {
            if (index == -1)
            {
                for (index = 0; index < Database.Entries[Base.SelectedIndex].Regions.Count; index++)
                    if (Database.Entries[Base.SelectedIndex].GetUpperID(index)[3] == baseID.Text[3])
                        goto Set;

                return;
            }

            Set:
            // Native name & Title ID
            // ********
            baseName.Text = Database.Entries[Base.SelectedIndex].Titles[index];
            baseID.Text = Database.Entries[Base.SelectedIndex].GetUpperID(index);

            foreach (ToolStripMenuItem item in BaseRegionList.Items.OfType<ToolStripMenuItem>())
                item.Checked = false;
            (BaseRegionList.Items[index] as ToolStripMenuItem).Checked = true;

            // Flag
            // ********
            switch (Database.Entries[Base.SelectedIndex].Regions[index])
                {
                    default:
                    case 0:
                        BaseRegion.Image = Properties.Resources.flag_jp;
                        break;

                    case 1:
                    case 2:
                        BaseRegion.Image = Properties.Resources.flag_us;
                        break;

                    case 3:
                        BaseRegion.Image = (int)Console <= 2 ? Properties.Resources.flag_eu50 : Properties.Resources.flag_eu;
                        break;

                    case 4:
                    case 5:
                        BaseRegion.Image = (int)Console <= 2 ? Properties.Resources.flag_eu60 : Properties.Resources.flag_eu;
                        break;

                    case 6:
                    case 7:
                        BaseRegion.Image = Properties.Resources.flag_kr;
                        break;
                }

            UpdateBaseGeneral(index);
        }

        private void UpdateBaseGeneral(int index)
        {
            int oldSaveLength = SaveDataTitle.MaxLength;

            // Korean WADs use different encoding format & using two lines or going over max limit cause visual bugs
            // ********
            Creator.OrigRegion = Database.Entries[Base.SelectedIndex].Regions[index] >= 6 ? Creator.RegionType.Korea
                     : Database.Entries[Base.SelectedIndex].Regions[index] == 0 ? Creator.RegionType.Japan
                     : Database.Entries[Base.SelectedIndex].Regions[index] >= 3 && Database.Entries[Base.SelectedIndex].Regions[index] <= 5 ? Creator.RegionType.Europe
                     : Creator.RegionType.Universal;

            // Changing SaveDataTitle max length & clearing text field when needed
            // ----------------------
            if (Console == Console.NES) SaveDataTitle.MaxLength = Creator.OrigRegion == Creator.RegionType.Korea ? 30 : 20;
            else if (Console == Console.SNES) SaveDataTitle.MaxLength = 80;
            else if (Console == Console.N64) SaveDataTitle.MaxLength = 100;
            else if (Console == Console.NEO
                  || Console == Console.MSX) SaveDataTitle.MaxLength = 64;
            else SaveDataTitle.MaxLength = 80;

            // Also, some consoles only support a single line anyway
            // ********
            bool isSingleLine = Creator.OrigRegion == Creator.RegionType.Korea
                             || Console == Console.NES
                             || Console == Console.SMS
                             || Console == Console.SMD
                             || Console == Console.PCE;

            // Set textbox to use single line when needed
            // ********
            if (SaveDataTitle.Multiline == isSingleLine)
            {
                SaveDataTitle.Multiline = !isSingleLine;
                SaveDataTitle.Location = SaveDataTitle.Multiline ? new Point(SaveDataTitle.Location.X, 28) : new Point(SaveDataTitle.Location.X, 35);
                SaveDataTitle.Clear();
                goto End;
            }
            if (Creator.OrigRegion == Creator.RegionType.Korea && SaveDataTitle.Multiline) SaveDataTitle.MaxLength /= 2; // Applies to both NES/FC & SNES/SFC

            // Clear text field if at least one line is longer than the maximum limit allowed
            // ********
            double max = SaveDataTitle.Multiline ? Math.Round((double)SaveDataTitle.MaxLength / 2) : SaveDataTitle.MaxLength;
            foreach (var line in SaveDataTitle.Lines)
                if (line.Length > max && SaveDataTitle.MaxLength != oldSaveLength)
                    SaveDataTitle.Clear();

            End:
            LinkSaveDataTitle();
            UpdateBaseConsole();
            pictureBox1.Image = Preview.Banner(Console, BannerTitle.Text, (int)ReleaseYear.Value, (int)Players.Value, Img?.VCPic, (int)Creator.OrigRegion);
        }

        private int emuVer
        {
            get
            {
                if (Database != null)
                    foreach (var entry in Database.Entries)
                        for (int i = 0; i < entry.Regions.Count; i++)
                            if (entry.GetUpperID(i) == baseID.Text.ToUpper())
                                return entry.EmuRevs[i];

                return 0;
            }
        }

        private void ResetContentOptions()
        {
            COPanel_VC.Hide();
            COPanel_Forwarder.Hide();
            bool ShowSaveData = false;

            CO = null;
            if (isVCMode)
            {
                COPanel_VC.Show();
                ShowSaveData = true;

                switch (Console)
                {
                    case Console.NES:
                        CO = new Options_VC_NES();
                        break;

                    case Console.SNES:
                        break;

                    case Console.N64:
                        CO = new Options_VC_N64();
                        break;

                    case Console.SMS:
                    case Console.SMD:
                        CO = new Options_VC_SEGA() { IsSMS = Console == Console.SMS };
                        break;

                    case Console.PCE:
                        CO = new Options_VC_PCE();
                        break;

                    case Console.NEO:
                        CO = new Options_VC_NEO();
                        break;

                    case Console.MSX:
                        break;

                    case Console.C64:
                        break;
                }
            }

            else if (Console == Console.Flash)
            {
                ShowSaveData = true;
                CO = new Options_Flash();
            }

            else
                COPanel_Forwarder.Show();

            if (CO != null) CO.Text = Program.Lang.String("injection_method_options", "projectform");

            LinkSaveData.Visible = SaveIcon_Panel.Visible = SaveDataTitle.Visible = ShowSaveData;
            label16.Visible = !SaveDataTitle.Visible;

            var selected = COPanel_Forwarder.Visible ? COPanel_Forwarder : COPanel_VC.Visible ? COPanel_VC : null;
            int height = selected == null ? button1.Location.Y + button1.Height + 10 : selected.Location.Y + selected.Height + 10;
            groupBox3.Size = new Size(groupBox3.Width, height);

            UpdateBaseConsole();
        }

        /// <summary>
        /// Changes injector settings based on selected base/console
        /// </summary>
        private void UpdateBaseConsole()
        {
            // ******************
            // CONSOLE-SPECIFIC
            // ******************
            // -------------------------------------------------------------------------------------
            switch (Console)
            {
                case Console.SNES:
                    break;

                case Console.N64:
                    if (isVCMode) CO.EmuType = Creator.OrigRegion == Creator.RegionType.Korea ? 3 : emuVer;
                    break;

                case Console.SMS:
                case Console.SMD:
                    CO.EmuType = emuVer;
                    break;

                case Console.PCE:
                    break;

                case Console.NEO:
                    break;

                case Console.MSX:
                    break;

                default:
                    break;
            }

            button1.Enabled = CO != null;
        }
        #endregion

        private void ChannelTitle_Locale_CheckedChanged(object sender, EventArgs e)
        {
            if (ChannelTitle_Locale.Checked)
            {
                ChannelTitles titles = new ChannelTitles(ChannelTitle.Text);
                if (titles.ShowDialog() == DialogResult.OK)
                {
                    Creator.ChannelTitles = new string[8]
                        {
                        titles.Japanese.Text,
                        titles.English.Text,
                        titles.German.Text,
                        titles.French.Text,
                        titles.Spanish.Text,
                        titles.Italian.Text,
                        titles.Dutch.Text,
                        titles.Korean.Text,
                        };
                    ChannelTitle.Text = Program.Lang.Current == "ja" ? titles.Japanese.Text
                                          : Program.Lang.Current == "ko" ? titles.Korean.Text
                                          : Program.Lang.Current == "nl" ? titles.Dutch.Text
                                          : Program.Lang.Current == "es" ? titles.Spanish.Text
                                          : Program.Lang.Current == "it" ? titles.Italian.Text
                                          : Program.Lang.Current == "fr" ? titles.French.Text
                                          : Program.Lang.Current == "de" ? titles.English.Text
                                          : titles.English.Text;
                }
            }

            else Creator.ChannelTitles = new string[8] { ChannelTitle.Text, ChannelTitle.Text, ChannelTitle.Text, ChannelTitle.Text, ChannelTitle.Text, ChannelTitle.Text, ChannelTitle.Text, ChannelTitle.Text };

            ChannelTitle.Enabled = !ChannelTitle_Locale.Checked;
        }

        private void CustomManual_CheckedChanged(object sender, EventArgs e)
        {
            if (CustomManual.Checked && CustomManual.Enabled)
            {
                if (!Properties.Settings.Default.DoNotShow_000) MessageBox.Show((sender as Control).Text, Program.Lang.Msg(6), 0);

                if (BrowseManual.ShowDialog() == DialogResult.OK)
                {
                    LoadManual(BrowseManual.SelectedPath);
                    CheckExport();
                }

                else
                {
                    if (Manual != null)
                    {
                        LoadManual(null);
                        CheckExport();
                    }

                    CustomManual.Checked = false;
                }
            }

            else if (!CustomManual.Checked && Manual != null && CustomManual.Enabled)
            {
                LoadManual(null);
                CheckExport();
            }
        }

        private void Patch_CheckedChanged(object sender, EventArgs e)
        {
            if (Patch.Checked && PatchFile == null)
            {
                if (BrowsePatch.ShowDialog() == DialogResult.OK)
                {
                    PatchFile = BrowsePatch.FileName;
                    CheckExport();
                }

                else
                {
                    if (!Patch.Checked && PatchFile != null)
                    {
                        PatchFile = null;
                        CheckExport();
                    }

                    Patch.Checked = false;
                }
            }

            else if (!Patch.Checked && PatchFile != null)
            {
                PatchFile = null;
                CheckExport();
            }
        }

        private void InjectorsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetContentOptions();
            if (groupBox3.Enabled) CheckExport();
        }

        private void RegionsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (groupBox4.Enabled) CheckExport();
        }

        private void ToggleSwitchChanged(object sender, EventArgs e)
        {
            if (sender == toggleSwitch1) toggleSwitchL1.Text = toggleSwitch1.Checked ? "vWii (Wii U)" : "Wii";
        }
    }
}