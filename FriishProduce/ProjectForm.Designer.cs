﻿
namespace FriishProduce
{
    partial class ProjectForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectForm));
            this.baseRegionList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.browseInputWad = new System.Windows.Forms.OpenFileDialog();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.SaveIcon_Panel = new System.Windows.Forms.PictureBox();
            this.fill_save_data = new System.Windows.Forms.CheckBox();
            this.save_data_title = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.manual_type = new System.Windows.Forms.ComboBox();
            this.injection_methods = new System.Windows.Forms.ComboBox();
            this.region_list = new System.Windows.Forms.ComboBox();
            this.channel_name = new System.Windows.Forms.TextBox();
            this.title_id_upper = new System.Windows.Forms.TextBox();
            this.title_id_random = new System.Windows.Forms.PictureBox();
            this.banner = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.import_wad = new System.Windows.Forms.Button();
            this.checkImg3 = new System.Windows.Forms.PictureBox();
            this.use_online_wad = new System.Windows.Forms.RadioButton();
            this.base_name = new System.Windows.Forms.Label();
            this.baseName = new System.Windows.Forms.Label();
            this.BaseRegion = new System.Windows.Forms.PictureBox();
            this.Base = new System.Windows.Forms.ComboBox();
            this.title_id = new System.Windows.Forms.Label();
            this.baseID = new System.Windows.Forms.Label();
            this.use_offline_wad = new System.Windows.Forms.RadioButton();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.wad_filename = new System.Windows.Forms.TextBox();
            this.browsePatch = new System.Windows.Forms.OpenFileDialog();
            this.browseManual = new Ookii.Dialogs.WinForms.VistaFolderBrowserDialog();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.download_image = new System.Windows.Forms.Button();
            this.image_resize1 = new System.Windows.Forms.RadioButton();
            this.image_resize0 = new System.Windows.Forms.RadioButton();
            this.image_interpolation_mode = new System.Windows.Forms.ComboBox();
            this.import_image = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.injection_method_options = new System.Windows.Forms.Button();
            this.extra = new System.Windows.Forms.Label();
            this.forwarder_root_device = new System.Windows.Forms.ComboBox();
            this.browseROM = new System.Windows.Forms.OpenFileDialog();
            this.browseImage = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.include_patch = new System.Windows.Forms.CheckBox();
            this.rom_label = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.banner_sound = new System.Windows.Forms.Button();
            this.banner_details = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.video_modes = new System.Windows.Forms.ComboBox();
            this.bannerMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.play_banner_sound = new System.Windows.Forms.ToolStripMenuItem();
            this.replace_banner_sound = new System.Windows.Forms.ToolStripMenuItem();
            this.restore_banner_sound = new System.Windows.Forms.ToolStripMenuItem();
            this.browseSound = new System.Windows.Forms.OpenFileDialog();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SaveIcon_Panel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.title_id_random)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.banner)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkImg3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BaseRegion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.bannerMenu.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // baseRegionList
            // 
            resources.ApplyResources(this.baseRegionList, "baseRegionList");
            this.baseRegionList.Name = "WADRegion";
            this.baseRegionList.ShowCheckMargin = true;
            this.baseRegionList.ShowImageMargin = false;
            // 
            // browseInputWad
            // 
            resources.ApplyResources(this.browseInputWad, "browseInputWad");
            this.browseInputWad.SupportMultiDottedExtensions = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.SaveIcon_Panel);
            this.groupBox5.Controls.Add(this.fill_save_data);
            this.groupBox5.Controls.Add(this.save_data_title);
            this.groupBox5.Controls.Add(this.label16);
            resources.ApplyResources(this.groupBox5, "groupBox5");
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.TabStop = false;
            this.groupBox5.Tag = "save_data";
            // 
            // SaveIcon_Panel
            // 
            this.SaveIcon_Panel.BackgroundImage = global::FriishProduce.Properties.Resources.SaveIconPlaceholder;
            resources.ApplyResources(this.SaveIcon_Panel, "SaveIcon_Panel");
            this.SaveIcon_Panel.Name = "SaveIcon_Panel";
            this.SaveIcon_Panel.TabStop = false;
            // 
            // fill_save_data
            // 
            resources.ApplyResources(this.fill_save_data, "fill_save_data");
            this.fill_save_data.Name = "fill_save_data";
            this.fill_save_data.Tag = "fill_save_data";
            this.fill_save_data.UseVisualStyleBackColor = true;
            this.fill_save_data.CheckedChanged += new System.EventHandler(this.LinkSaveData_Changed);
            // 
            // save_data_title
            // 
            resources.ApplyResources(this.save_data_title, "save_data_title");
            this.save_data_title.Name = "save_data_title";
            this.save_data_title.Tag = "24";
            this.save_data_title.TextChanged += new System.EventHandler(this.TextBox_Changed);
            this.save_data_title.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_Handle);
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            this.label16.Tag = "none";
            // 
            // manual_type
            // 
            this.manual_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.manual_type.FormattingEnabled = true;
            resources.ApplyResources(this.manual_type, "manual_type");
            this.manual_type.Name = "manual_type";
            this.manual_type.Tag = "manual_type";
            this.manual_type.SelectedIndexChanged += new System.EventHandler(this.CustomManual_CheckedChanged);
            // 
            // injection_methods
            // 
            this.injection_methods.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.injection_methods.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.injection_methods.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.injection_methods.FormattingEnabled = true;
            resources.ApplyResources(this.injection_methods, "injection_methods");
            this.injection_methods.Name = "injection_methods";
            this.injection_methods.SelectedIndexChanged += new System.EventHandler(this.InjectorsList_SelectedIndexChanged);
            // 
            // region_list
            // 
            this.region_list.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.region_list.FormattingEnabled = true;
            resources.ApplyResources(this.region_list, "region_list");
            this.region_list.Name = "region_list";
            this.region_list.SelectedIndexChanged += new System.EventHandler(this.RegionsList_SelectedIndexChanged);
            // 
            // channel_name
            // 
            resources.ApplyResources(this.channel_name, "channel_name");
            this.channel_name.Name = "channel_name";
            this.channel_name.TextChanged += new System.EventHandler(this.TextBox_Changed);
            // 
            // title_id_upper
            // 
            this.title_id_upper.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.title_id_upper, "title_id_upper");
            this.title_id_upper.Name = "title_id_upper";
            this.title_id_upper.TextChanged += new System.EventHandler(this.TextBox_Changed);
            // 
            // title_id_random
            // 
            this.title_id_random.Cursor = System.Windows.Forms.Cursors.Hand;
            this.title_id_random.Image = global::FriishProduce.Properties.Resources.arrow_switch;
            resources.ApplyResources(this.title_id_random, "title_id_random");
            this.title_id_random.Name = "title_id_random";
            this.title_id_random.TabStop = false;
            this.title_id_random.Click += new System.EventHandler(this.Random_Click);
            // 
            // banner
            // 
            this.banner.BackColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(this.banner, "banner");
            this.banner.Name = "banner";
            this.banner.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.import_wad);
            this.groupBox2.Controls.Add(this.checkImg3);
            this.groupBox2.Controls.Add(this.use_online_wad);
            this.groupBox2.Controls.Add(this.base_name);
            this.groupBox2.Controls.Add(this.baseName);
            this.groupBox2.Controls.Add(this.BaseRegion);
            this.groupBox2.Controls.Add(this.Base);
            this.groupBox2.Controls.Add(this.title_id);
            this.groupBox2.Controls.Add(this.baseID);
            this.groupBox2.Controls.Add(this.use_offline_wad);
            this.groupBox2.Controls.Add(this.pictureBox2);
            this.groupBox2.Controls.Add(this.wad_filename);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            this.groupBox2.Tag = "wad_base";
            // 
            // import_wad
            // 
            resources.ApplyResources(this.import_wad, "import_wad");
            this.import_wad.Name = "import_wad";
            this.import_wad.Tag = "import_wad";
            this.import_wad.UseVisualStyleBackColor = true;
            this.import_wad.Click += new System.EventHandler(this.import_wad_Click);
            // 
            // checkImg3
            // 
            resources.ApplyResources(this.checkImg3, "checkImg3");
            this.checkImg3.Name = "checkImg3";
            this.checkImg3.TabStop = false;
            // 
            // use_online_wad
            // 
            resources.ApplyResources(this.use_online_wad, "use_online_wad");
            this.use_online_wad.Name = "use_online_wad";
            this.use_online_wad.Tag = "use_online_wad";
            this.use_online_wad.UseVisualStyleBackColor = true;
            this.use_online_wad.CheckedChanged += new System.EventHandler(this.OpenWAD_CheckedChanged);
            // 
            // base_name
            // 
            resources.ApplyResources(this.base_name, "base_name");
            this.base_name.Name = "base_name";
            this.base_name.Tag = "base_name";
            this.base_name.UseMnemonic = false;
            // 
            // baseName
            // 
            resources.ApplyResources(this.baseName, "baseName");
            this.baseName.Name = "baseName";
            this.baseName.UseMnemonic = false;
            // 
            // BaseRegion
            // 
            this.BaseRegion.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BaseRegion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BaseRegion.ContextMenuStrip = this.baseRegionList;
            resources.ApplyResources(this.BaseRegion, "BaseRegion");
            this.BaseRegion.Name = "BaseRegion";
            this.BaseRegion.TabStop = false;
            this.BaseRegion.Click += new System.EventHandler(this.WADRegion_Click);
            // 
            // Base
            // 
            this.Base.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.Base.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Base.DropDownHeight = 150;
            this.Base.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.Base, "Base");
            this.Base.FormattingEnabled = true;
            this.Base.Name = "Base";
            this.Base.SelectedIndexChanged += new System.EventHandler(this.Base_SelectedIndexChanged);
            // 
            // title_id
            // 
            resources.ApplyResources(this.title_id, "title_id");
            this.title_id.Name = "title_id";
            this.title_id.Tag = "title_id";
            this.title_id.UseMnemonic = false;
            // 
            // baseID
            // 
            resources.ApplyResources(this.baseID, "baseID");
            this.baseID.Name = "baseID";
            this.baseID.UseMnemonic = false;
            // 
            // use_offline_wad
            // 
            resources.ApplyResources(this.use_offline_wad, "use_offline_wad");
            this.use_offline_wad.Name = "use_offline_wad";
            this.use_offline_wad.Tag = "";
            this.use_offline_wad.UseVisualStyleBackColor = true;
            this.use_offline_wad.CheckedChanged += new System.EventHandler(this.OpenWAD_CheckedChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ControlDark;
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            // 
            // wad_filename
            // 
            resources.ApplyResources(this.wad_filename, "wad_filename");
            this.wad_filename.Name = "wad_filename";
            this.wad_filename.ReadOnly = true;
            // 
            // browsePatch
            // 
            this.browsePatch.RestoreDirectory = true;
            this.browsePatch.SupportMultiDottedExtensions = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.download_image);
            this.groupBox6.Controls.Add(this.image_resize1);
            this.groupBox6.Controls.Add(this.image_resize0);
            this.groupBox6.Controls.Add(this.image_interpolation_mode);
            this.groupBox6.Controls.Add(this.import_image);
            this.groupBox6.Controls.Add(this.pictureBox1);
            resources.ApplyResources(this.groupBox6, "groupBox6");
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.TabStop = false;
            this.groupBox6.Tag = "image";
            // 
            // download_image
            // 
            resources.ApplyResources(this.download_image, "download_image");
            this.download_image.Name = "download_image";
            this.download_image.Tag = "download_image";
            this.download_image.UseVisualStyleBackColor = true;
            this.download_image.Click += new System.EventHandler(this.download_image_Click);
            // 
            // image_resize1
            // 
            resources.ApplyResources(this.image_resize1, "image_resize1");
            this.image_resize1.Name = "image_resize1";
            this.image_resize1.TabStop = true;
            this.image_resize1.Tag = "image_resize1";
            this.image_resize1.UseVisualStyleBackColor = true;
            this.image_resize1.CheckedChanged += new System.EventHandler(this.SwitchAspectRatio);
            // 
            // image_resize0
            // 
            resources.ApplyResources(this.image_resize0, "image_resize0");
            this.image_resize0.Name = "image_resize0";
            this.image_resize0.TabStop = true;
            this.image_resize0.Tag = "image_resize0";
            this.image_resize0.UseVisualStyleBackColor = true;
            this.image_resize0.CheckedChanged += new System.EventHandler(this.SwitchAspectRatio);
            // 
            // image_interpolation_mode
            // 
            this.image_interpolation_mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.image_interpolation_mode, "image_interpolation_mode");
            this.image_interpolation_mode.FormattingEnabled = true;
            this.image_interpolation_mode.Items.AddRange(new object[] {
            resources.GetString("image_interpolation_mode.Items")});
            this.image_interpolation_mode.Name = "image_interpolation_mode";
            this.image_interpolation_mode.Tag = "image_interpolation_mode";
            // 
            // import_image
            // 
            resources.ApplyResources(this.import_image, "import_image");
            this.import_image.Name = "import_image";
            this.import_image.Tag = "import_image";
            this.import_image.UseVisualStyleBackColor = true;
            this.import_image.Click += new System.EventHandler(this.import_image_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlDark;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.injection_method_options);
            this.groupBox3.Controls.Add(this.injection_methods);
            this.groupBox3.Controls.Add(this.manual_type);
            this.groupBox3.Controls.Add(this.extra);
            this.groupBox3.Controls.Add(this.forwarder_root_device);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            this.groupBox3.Tag = "injection_method";
            // 
            // injection_method_options
            // 
            resources.ApplyResources(this.injection_method_options, "injection_method_options");
            this.injection_method_options.Name = "injection_method_options";
            this.injection_method_options.Tag = "injection_method_options";
            this.injection_method_options.UseVisualStyleBackColor = true;
            this.injection_method_options.Click += new System.EventHandler(this.openInjectorOptions);
            // 
            // extra
            // 
            resources.ApplyResources(this.extra, "extra");
            this.extra.Name = "extra";
            // 
            // forwarder_root_device
            // 
            this.forwarder_root_device.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.forwarder_root_device.FormattingEnabled = true;
            this.forwarder_root_device.Items.AddRange(new object[] {
            resources.GetString("forwarder_root_device.Items"),
            resources.GetString("forwarder_root_device.Items1")});
            resources.ApplyResources(this.forwarder_root_device, "forwarder_root_device");
            this.forwarder_root_device.Name = "forwarder_root_device";
            this.forwarder_root_device.Tag = "";
            // 
            // browseROM
            // 
            this.browseROM.RestoreDirectory = true;
            this.browseROM.SupportMultiDottedExtensions = true;
            // 
            // browseImage
            // 
            resources.ApplyResources(this.browseImage, "browseImage");
            this.browseImage.RestoreDirectory = true;
            this.browseImage.SupportMultiDottedExtensions = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.include_patch);
            this.groupBox1.Controls.Add(this.rom_label);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "main";
            // 
            // include_patch
            // 
            resources.ApplyResources(this.include_patch, "include_patch");
            this.include_patch.Name = "include_patch";
            this.include_patch.Tag = "include_patch";
            this.include_patch.UseVisualStyleBackColor = true;
            this.include_patch.CheckedChanged += new System.EventHandler(this.import_patch_CheckedChanged);
            // 
            // rom_label
            // 
            resources.ApplyResources(this.rom_label, "rom_label");
            this.rom_label.Name = "rom_label";
            this.rom_label.Tag = "rom_label";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.banner_sound);
            this.groupBox7.Controls.Add(this.banner_details);
            this.groupBox7.Controls.Add(this.banner);
            resources.ApplyResources(this.groupBox7, "groupBox7");
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.TabStop = false;
            this.groupBox7.Tag = "banner";
            // 
            // banner_sound
            // 
            resources.ApplyResources(this.banner_sound, "banner_sound");
            this.banner_sound.Name = "banner_sound";
            this.banner_sound.Tag = "banner_sound";
            this.banner_sound.UseVisualStyleBackColor = true;
            this.banner_sound.Click += new System.EventHandler(this.banner_sound_Click);
            // 
            // banner_details
            // 
            resources.ApplyResources(this.banner_details, "banner_details");
            this.banner_details.Name = "banner_details";
            this.banner_details.Tag = "banner_details";
            this.banner_details.UseVisualStyleBackColor = true;
            this.banner_details.Click += new System.EventHandler(this.banner_customize_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.label2);
            this.groupBox8.Controls.Add(this.label1);
            this.groupBox8.Controls.Add(this.video_modes);
            this.groupBox8.Controls.Add(this.title_id_upper);
            this.groupBox8.Controls.Add(this.title_id_random);
            this.groupBox8.Controls.Add(this.region_list);
            this.groupBox8.Controls.Add(this.channel_name);
            resources.ApplyResources(this.groupBox8, "groupBox8");
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.TabStop = false;
            this.groupBox8.Tag = "channel_metadata";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            this.label2.Tag = "title_id";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.label1.Tag = "channel_name";
            // 
            // video_modes
            // 
            this.video_modes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.video_modes.FormattingEnabled = true;
            this.video_modes.Items.AddRange(new object[] {
            resources.GetString("video_modes.Items"),
            resources.GetString("video_modes.Items1"),
            resources.GetString("video_modes.Items2"),
            resources.GetString("video_modes.Items3"),
            resources.GetString("video_modes.Items4"),
            resources.GetString("video_modes.Items5"),
            resources.GetString("video_modes.Items6"),
            resources.GetString("video_modes.Items7"),
            resources.GetString("video_modes.Items8")});
            resources.ApplyResources(this.video_modes, "video_modes");
            this.video_modes.Name = "video_modes";
            // 
            // bannerMenu
            // 
            this.bannerMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.play_banner_sound,
            this.replace_banner_sound,
            this.restore_banner_sound});
            this.bannerMenu.Name = "bannerMenu";
            resources.ApplyResources(this.bannerMenu, "bannerMenu");
            // 
            // play_banner_sound
            // 
            this.play_banner_sound.Name = "play_banner_sound";
            resources.ApplyResources(this.play_banner_sound, "play_banner_sound");
            this.play_banner_sound.Tag = "play_banner_sound";
            this.play_banner_sound.Click += new System.EventHandler(this.play_banner_sound_Click);
            // 
            // replace_banner_sound
            // 
            this.replace_banner_sound.Name = "replace_banner_sound";
            resources.ApplyResources(this.replace_banner_sound, "replace_banner_sound");
            this.replace_banner_sound.Tag = "replace_banner_sound";
            this.replace_banner_sound.Click += new System.EventHandler(this.replace_banner_sound_Click);
            // 
            // restore_banner_sound
            // 
            resources.ApplyResources(this.restore_banner_sound, "restore_banner_sound");
            this.restore_banner_sound.Name = "restore_banner_sound";
            this.restore_banner_sound.Tag = "restore_banner_sound";
            this.restore_banner_sound.Click += new System.EventHandler(this.restore_banner_sound_Click);
            // 
            // browseSound
            // 
            resources.ApplyResources(this.browseSound, "browseSound");
            this.browseSound.RestoreDirectory = true;
            this.browseSound.SupportMultiDottedExtensions = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.pictureBox3);
            this.groupBox4.Controls.Add(this.checkBox1);
            this.groupBox4.Controls.Add(this.textBox1);
            this.groupBox4.Controls.Add(this.label3);
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            this.groupBox4.Tag = "save_data";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::FriishProduce.Properties.Resources.SaveIconPlaceholder;
            resources.ApplyResources(this.pictureBox3, "pictureBox3");
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.TabStop = false;
            // 
            // checkBox1
            // 
            resources.ApplyResources(this.checkBox1, "checkBox1");
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Tag = "fill_save_data";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.LinkSaveData_Changed);
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            this.textBox1.Tag = "24";
            this.textBox1.TextChanged += new System.EventHandler(this.TextBox_Changed);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_Handle);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            this.label3.Tag = "none";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.label4);
            this.groupBox9.Controls.Add(this.label5);
            this.groupBox9.Controls.Add(this.comboBox1);
            this.groupBox9.Controls.Add(this.textBox2);
            this.groupBox9.Controls.Add(this.pictureBox4);
            this.groupBox9.Controls.Add(this.comboBox2);
            this.groupBox9.Controls.Add(this.textBox3);
            resources.ApplyResources(this.groupBox9, "groupBox9");
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.TabStop = false;
            this.groupBox9.Tag = "channel_metadata";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            this.label4.Tag = "title_id";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            this.label5.Tag = "channel_name";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            resources.GetString("comboBox1.Items"),
            resources.GetString("comboBox1.Items1"),
            resources.GetString("comboBox1.Items2"),
            resources.GetString("comboBox1.Items3"),
            resources.GetString("comboBox1.Items4"),
            resources.GetString("comboBox1.Items5"),
            resources.GetString("comboBox1.Items6"),
            resources.GetString("comboBox1.Items7"),
            resources.GetString("comboBox1.Items8")});
            resources.ApplyResources(this.comboBox1, "comboBox1");
            this.comboBox1.Name = "comboBox1";
            // 
            // textBox2
            // 
            this.textBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.textBox2, "textBox2");
            this.textBox2.Name = "textBox2";
            this.textBox2.TextChanged += new System.EventHandler(this.TextBox_Changed);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox4.Image = global::FriishProduce.Properties.Resources.arrow_switch;
            resources.ApplyResources(this.pictureBox4, "pictureBox4");
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.Random_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            resources.ApplyResources(this.comboBox2, "comboBox2");
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.RegionsList_SelectedIndexChanged);
            // 
            // textBox3
            // 
            resources.ApplyResources(this.textBox3, "textBox3");
            this.textBox3.Name = "textBox3";
            this.textBox3.TextChanged += new System.EventHandler(this.TextBox_Changed);
            // 
            // ProjectForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox5);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "ProjectForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.isClosing);
            this.Load += new System.EventHandler(this.Form_Shown);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SaveIcon_Panel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.title_id_random)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.banner)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkImg3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BaseRegion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.bannerMenu.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox save_data_title;
        private System.Windows.Forms.TextBox channel_name;
        private System.Windows.Forms.TextBox title_id_upper;
        private System.Windows.Forms.PictureBox title_id_random;
        private System.Windows.Forms.ComboBox Base;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox BaseRegion;
        private System.Windows.Forms.ContextMenuStrip baseRegionList;
        private System.Windows.Forms.Label baseName;
        private System.Windows.Forms.Label baseID;
        private System.Windows.Forms.Label title_id;
        private System.Windows.Forms.Label base_name;
        internal System.Windows.Forms.OpenFileDialog browseInputWad;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox injection_methods;
        internal System.Windows.Forms.OpenFileDialog browsePatch;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox region_list;
        private System.Windows.Forms.CheckBox fill_save_data;
        private Ookii.Dialogs.WinForms.VistaFolderBrowserDialog browseManual;
        private System.Windows.Forms.ComboBox manual_type;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PictureBox banner;
        private System.Windows.Forms.PictureBox SaveIcon_Panel;
        private System.Windows.Forms.Button injection_method_options;
        private System.Windows.Forms.OpenFileDialog browseROM;
        private System.Windows.Forms.OpenFileDialog browseImage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox forwarder_root_device;
        private System.Windows.Forms.Button import_wad;
        private System.Windows.Forms.RadioButton use_online_wad;
        private System.Windows.Forms.RadioButton use_offline_wad;
        private System.Windows.Forms.PictureBox checkImg3;
        private System.Windows.Forms.TextBox wad_filename;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label extra;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.ContextMenuStrip bannerMenu;
        private System.Windows.Forms.OpenFileDialog browseSound;
        private System.Windows.Forms.ComboBox image_interpolation_mode;
        private System.Windows.Forms.Label rom_label;
        private System.Windows.Forms.Button import_image;
        private System.Windows.Forms.CheckBox include_patch;
        private System.Windows.Forms.RadioButton image_resize0;
        private System.Windows.Forms.RadioButton image_resize1;
        private System.Windows.Forms.Button banner_sound;
        private System.Windows.Forms.Button banner_details;
        private System.Windows.Forms.ToolStripMenuItem play_banner_sound;
        private System.Windows.Forms.ToolStripMenuItem replace_banner_sound;
        private System.Windows.Forms.ToolStripMenuItem restore_banner_sound;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox video_modes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button download_image;
    }
}