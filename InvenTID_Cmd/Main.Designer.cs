namespace InvenTID
{
    partial class FrmMain
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
            DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::InvenTID.SplashScreen1), true, true);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnConnect = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.btnPairNew = new DevExpress.XtraBars.BarButtonItem();
            this.btnVersionInfo = new DevExpress.XtraBars.BarButtonItem();
            this.btnDisconnect = new DevExpress.XtraBars.BarButtonItem();
            this.btnInventory = new DevExpress.XtraBars.BarButtonItem();
            this.btnAbort = new DevExpress.XtraBars.BarButtonItem();
            this.btnClear = new DevExpress.XtraBars.BarButtonItem();
            this.btnGetTags = new DevExpress.XtraBars.BarButtonItem();
            this.btnPurgeTags = new DevExpress.XtraBars.BarButtonItem();
            this.btnWeb = new DevExpress.XtraBars.BarButtonItem();
            this.btnGetActiveScanners = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.triggers = new DevExpress.XtraBars.BarButtonItem();
            this.btnConf = new DevExpress.XtraBars.BarButtonItem();
            this.btnAbout = new DevExpress.XtraBars.BarButtonItem();
            this.btnStart = new DevExpress.XtraBars.BarButtonItem();
            this.btnStop = new DevExpress.XtraBars.BarButtonItem();
            this.btnCapacites = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.tabPane1 = new DevExpress.XtraBars.Navigation.TabPane();
            this.tabNavigationPage1 = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.txtTotalTags = new System.Windows.Forms.TextBox();
            this.grdTags = new System.Windows.Forms.DataGridView();
            this.tabNavigationPage2 = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.tabNavigationPage3 = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.btnVerifPort = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtPortSignalR = new DevExpress.XtraEditors.TextEdit();
            this.SaveConfig = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.checkLaunchServer = new System.Windows.Forms.CheckBox();
            this.checkLaunchWeb = new System.Windows.Forms.CheckBox();
            this.checkOpenMinimized = new System.Windows.Forms.CheckBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.weblink = new DevExpress.XtraEditors.TextEdit();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnSetBatchMode = new DevExpress.XtraEditors.SimpleButton();
            this.btnGetBatchMode = new DevExpress.XtraEditors.SimpleButton();
            this.cmb_BatchMode = new System.Windows.Forms.ComboBox();
            this.btnRestoreDefaults = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.btnGetStatus = new DevExpress.XtraEditors.SimpleButton();
            this.btnSaveConfig = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnSetBeeperVolume = new DevExpress.XtraEditors.SimpleButton();
            this.btnGetBeeperVolume = new DevExpress.XtraEditors.SimpleButton();
            this.cboBeeperVolume = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblRegion = new System.Windows.Forms.Label();
            this.btnGetRegion = new DevExpress.XtraEditors.SimpleButton();
            this.txtRegion = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSetPower = new DevExpress.XtraEditors.SimpleButton();
            this.btnGetPower = new DevExpress.XtraEditors.SimpleButton();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPower = new System.Windows.Forms.TextBox();
            this.tabNavigationPage4 = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.grpDashboard = new DevExpress.XtraEditors.GroupControl();
            this.txtManufactureDate = new System.Windows.Forms.TextBox();
            this.txtManufactureName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSerialNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtModelName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.grpStatut = new DevExpress.XtraEditors.GroupControl();
            this.ledSignalR = new System.Windows.Forms.PictureBox();
            this.ledRfid = new System.Windows.Forms.PictureBox();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.grpLogin = new DevExpress.XtraEditors.GroupControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtUsername = new DevExpress.XtraEditors.TextEdit();
            this.logOn = new DevExpress.XtraEditors.SimpleButton();
            this.checkAutoLogin = new System.Windows.Forms.CheckBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.comboBoxReaders = new System.Windows.Forms.ComboBox();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPane1)).BeginInit();
            this.tabPane1.SuspendLayout();
            this.tabNavigationPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTags)).BeginInit();
            this.tabNavigationPage2.SuspendLayout();
            this.tabNavigationPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPortSignalR.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weblink.Properties)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabNavigationPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpDashboard)).BeginInit();
            this.grpDashboard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpStatut)).BeginInit();
            this.grpStatut.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ledSignalR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledRfid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpLogin)).BeginInit();
            this.grpLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // splashScreenManager1
            // 
            splashScreenManager1.ClosingDelay = 500;
            // 
            // ribbon
            // 
            this.ribbon.AllowMdiChildButtons = false;
            this.ribbon.AllowMinimizeRibbon = false;
            this.ribbon.ApplicationIcon = ((System.Drawing.Bitmap)(resources.GetObject("ribbon.ApplicationIcon")));
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.btnConnect,
            this.btnRefresh,
            this.btnPairNew,
            this.btnVersionInfo,
            this.btnDisconnect,
            this.btnInventory,
            this.btnAbort,
            this.btnClear,
            this.btnGetTags,
            this.btnPurgeTags,
            this.btnWeb,
            this.btnGetActiveScanners,
            this.barButtonItem2,
            this.triggers,
            this.btnConf,
            this.btnAbout,
            this.btnStart,
            this.btnStop,
            this.btnCapacites});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 30;
            this.ribbon.Name = "ribbon";
            this.ribbon.OptionsCustomizationForm.FormIcon = ((System.Drawing.Icon)(resources.GetObject("resource.FormIcon")));
            this.ribbon.PageCategoryAlignment = DevExpress.XtraBars.Ribbon.RibbonPageCategoryAlignment.Left;
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage2,
            this.ribbonPage3});
            this.ribbon.RibbonCaptionAlignment = DevExpress.XtraBars.Ribbon.RibbonCaptionAlignment.Left;
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowDisplayOptionsMenuButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowToolbarCustomizeItem = false;
            this.ribbon.Size = new System.Drawing.Size(501, 147);
            this.ribbon.Toolbar.ShowCustomizeItem = false;
            // 
            // btnConnect
            // 
            this.btnConnect.Caption = "Connecter";
            this.btnConnect.Id = 3;
            this.btnConnect.ImageOptions.Image = global::InvenTID.Properties.Resources.radio_32x32;
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnConnect.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnConnect_ItemClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "Actualiser";
            this.btnRefresh.Id = 4;
            this.btnRefresh.ImageOptions.Image = global::InvenTID.Properties.Resources.convert_32x32;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefresh_ItemClick);
            // 
            // btnPairNew
            // 
            this.btnPairNew.Caption = "Coupler";
            this.btnPairNew.Id = 5;
            this.btnPairNew.ImageOptions.Image = global::InvenTID.Properties.Resources.phone_32x32;
            this.btnPairNew.Name = "btnPairNew";
            this.btnPairNew.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnPairNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPairNew_ItemClick);
            // 
            // btnVersionInfo
            // 
            this.btnVersionInfo.Caption = "Version";
            this.btnVersionInfo.Id = 6;
            this.btnVersionInfo.ImageOptions.Image = global::InvenTID.Properties.Resources.parameters2_32x32;
            this.btnVersionInfo.Name = "btnVersionInfo";
            this.btnVersionInfo.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnVersionInfo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnVersionInfo_ItemClick);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Caption = "Deconnecter";
            this.btnDisconnect.Id = 7;
            this.btnDisconnect.ImageOptions.Image = global::InvenTID.Properties.Resources.cancel_32x32;
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnDisconnect.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDisconnect_ItemClick);
            // 
            // btnInventory
            // 
            this.btnInventory.Caption = "Lancer";
            this.btnInventory.Id = 8;
            this.btnInventory.ImageOptions.Image = global::InvenTID.Properties.Resources.formatastable_32x32;
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnInventory.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnInventory_ItemClick);
            // 
            // btnAbort
            // 
            this.btnAbort.Caption = "Stop";
            this.btnAbort.Id = 9;
            this.btnAbort.ImageOptions.Image = global::InvenTID.Properties.Resources.removeitem_32x32;
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnAbort.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAbort_ItemClick);
            // 
            // btnClear
            // 
            this.btnClear.Caption = "Effacer";
            this.btnClear.Id = 10;
            this.btnClear.ImageOptions.Image = global::InvenTID.Properties.Resources.trash_32x32;
            this.btnClear.Name = "btnClear";
            this.btnClear.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnClear.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClear_ItemClick);
            // 
            // btnGetTags
            // 
            this.btnGetTags.Caption = "Lire memoire";
            this.btnGetTags.Id = 11;
            this.btnGetTags.ImageOptions.Image = global::InvenTID.Properties.Resources.steparea_32x32;
            this.btnGetTags.Name = "btnGetTags";
            this.btnGetTags.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnGetTags.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGetBatchedTags_Click);
            // 
            // btnPurgeTags
            // 
            this.btnPurgeTags.Caption = "Effacer memoire";
            this.btnPurgeTags.Id = 12;
            this.btnPurgeTags.ImageOptions.Image = global::InvenTID.Properties.Resources.stepline_32x32;
            this.btnPurgeTags.Name = "btnPurgeTags";
            this.btnPurgeTags.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnPurgeTags.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPurgeTags_Click);
            // 
            // btnWeb
            // 
            this.btnWeb.Caption = "Web";
            this.btnWeb.Id = 15;
            this.btnWeb.ImageOptions.Image = global::InvenTID.Properties.Resources.viewonweb_32x32;
            this.btnWeb.Name = "btnWeb";
            this.btnWeb.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnWeb.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnWeb_ItemClick);
            // 
            // btnGetActiveScanners
            // 
            this.btnGetActiveScanners.Caption = "Scanners Actifs";
            this.btnGetActiveScanners.Id = 16;
            this.btnGetActiveScanners.ImageOptions.Image = global::InvenTID.Properties.Resources.combobox_32x32;
            this.btnGetActiveScanners.Name = "btnGetActiveScanners";
            this.btnGetActiveScanners.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnGetActiveScanners.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGetActiveScanners_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Quitter";
            this.barButtonItem2.Id = 17;
            this.barButtonItem2.ImageOptions.Image = global::InvenTID.Properties.Resources.close_32x32;
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // triggers
            // 
            this.triggers.Caption = "Triggers";
            this.triggers.Id = 19;
            this.triggers.ImageOptions.Image = global::InvenTID.Properties.Resources.up2_32x32;
            this.triggers.Name = "triggers";
            this.triggers.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.triggers.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Triggers_ItemClick);
            // 
            // btnConf
            // 
            this.btnConf.Caption = "Configuration";
            this.btnConf.Id = 20;
            this.btnConf.ImageOptions.Image = global::InvenTID.Properties.Resources.chartxaxissettings_32x32;
            this.btnConf.Name = "btnConf";
            this.btnConf.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnConf.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnConf_ItemClick);
            // 
            // btnAbout
            // 
            this.btnAbout.Caption = "A propos de...";
            this.btnAbout.Id = 21;
            this.btnAbout.ImageOptions.Image = global::InvenTID.Properties.Resources.knowledgebasearticle_32x32;
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnAbout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAbout_ItemClick);
            // 
            // btnStart
            // 
            this.btnStart.Caption = "Demarrer";
            this.btnStart.Id = 27;
            this.btnStart.ImageOptions.Image = global::InvenTID.Properties.Resources.play_32x32;
            this.btnStart.Name = "btnStart";
            this.btnStart.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnStart.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnStart_ItemClick);
            // 
            // btnStop
            // 
            this.btnStop.Caption = "Stop";
            this.btnStop.Enabled = false;
            this.btnStop.Id = 28;
            this.btnStop.ImageOptions.Image = global::InvenTID.Properties.Resources.stop_32x32;
            this.btnStop.Name = "btnStop";
            this.btnStop.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnStop.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnStop_ItemClick);
            // 
            // btnCapacites
            // 
            this.btnCapacites.Caption = "Informations";
            this.btnCapacites.Id = 29;
            this.btnCapacites.ImageOptions.Image = global::InvenTID.Properties.Resources.info_32x321;
            this.btnCapacites.Name = "btnCapacites";
            this.btnCapacites.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnCapacites.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCapacites_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup6});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Connection";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnWeb);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnRefresh);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnConnect);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnDisconnect);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnPairNew);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnVersionInfo);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Scanner";
            // 
            // ribbonPageGroup6
            // 
            this.ribbonPageGroup6.ItemLinks.Add(this.btnStart);
            this.ribbonPageGroup6.ItemLinks.Add(this.btnStop);
            this.ribbonPageGroup6.Name = "ribbonPageGroup6";
            this.ribbonPageGroup6.Text = "Serveur";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2,
            this.ribbonPageGroup3});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "Inventaire";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnInventory);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnAbort);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnClear);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Operation";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.btnGetTags);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnPurgeTags);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "Memoire";
            // 
            // ribbonPage3
            // 
            this.ribbonPage3.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup4,
            this.ribbonPageGroup5});
            this.ribbonPage3.Name = "ribbonPage3";
            this.ribbonPage3.Text = "Options";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.btnGetActiveScanners);
            this.ribbonPageGroup4.ItemLinks.Add(this.triggers);
            this.ribbonPageGroup4.ItemLinks.Add(this.btnConf);
            this.ribbonPageGroup4.ItemLinks.Add(this.btnCapacites);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "Plus";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.ItemLinks.Add(this.btnAbout);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            this.ribbonPageGroup5.Text = "Aide";
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2013 Dark Gray";
            // 
            // tabPane1
            // 
            this.tabPane1.Controls.Add(this.tabNavigationPage1);
            this.tabPane1.Controls.Add(this.tabNavigationPage2);
            this.tabPane1.Controls.Add(this.tabNavigationPage3);
            this.tabPane1.Controls.Add(this.tabNavigationPage4);
            this.tabPane1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPane1.Location = new System.Drawing.Point(0, 147);
            this.tabPane1.LookAndFeel.SkinName = "Office 2013 Light Gray";
            this.tabPane1.Name = "tabPane1";
            this.tabPane1.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.tabNavigationPage4,
            this.tabNavigationPage1,
            this.tabNavigationPage3,
            this.tabNavigationPage2});
            this.tabPane1.RegularSize = new System.Drawing.Size(501, 302);
            this.tabPane1.SelectedPage = this.tabNavigationPage4;
            this.tabPane1.Size = new System.Drawing.Size(501, 302);
            this.tabPane1.TabIndex = 2;
            this.tabPane1.Text = "Liste";
            // 
            // tabNavigationPage1
            // 
            this.tabNavigationPage1.Caption = "Liste Tags";
            this.tabNavigationPage1.Controls.Add(this.txtTotalTags);
            this.tabNavigationPage1.Controls.Add(this.grdTags);
            this.tabNavigationPage1.Image = global::InvenTID.Properties.Resources.gridcolumnheader_32x32;
            this.tabNavigationPage1.Name = "tabNavigationPage1";
            this.tabNavigationPage1.Size = new System.Drawing.Size(483, 238);
            // 
            // txtTotalTags
            // 
            this.txtTotalTags.Location = new System.Drawing.Point(378, 215);
            this.txtTotalTags.Name = "txtTotalTags";
            this.txtTotalTags.ReadOnly = true;
            this.txtTotalTags.Size = new System.Drawing.Size(100, 21);
            this.txtTotalTags.TabIndex = 7;
            // 
            // grdTags
            // 
            this.grdTags.AllowUserToAddRows = false;
            this.grdTags.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.grdTags.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.grdTags.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTags.Location = new System.Drawing.Point(2, 2);
            this.grdTags.Margin = new System.Windows.Forms.Padding(2);
            this.grdTags.Name = "grdTags";
            this.grdTags.ReadOnly = true;
            this.grdTags.RowTemplate.Height = 24;
            this.grdTags.Size = new System.Drawing.Size(481, 212);
            this.grdTags.TabIndex = 23;
            // 
            // tabNavigationPage2
            // 
            this.tabNavigationPage2.Caption = "Log";
            this.tabNavigationPage2.Controls.Add(this.txtOutput);
            this.tabNavigationPage2.Image = global::InvenTID.Properties.Resources.changechartlegendalignment_32x32;
            this.tabNavigationPage2.Name = "tabNavigationPage2";
            this.tabNavigationPage2.Size = new System.Drawing.Size(483, 238);
            // 
            // txtOutput
            // 
            this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutput.Location = new System.Drawing.Point(3, 3);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOutput.Size = new System.Drawing.Size(477, 233);
            this.txtOutput.TabIndex = 6;
            this.txtOutput.TabStop = false;
            // 
            // tabNavigationPage3
            // 
            this.tabNavigationPage3.Caption = "Configuration";
            this.tabNavigationPage3.Controls.Add(this.btnVerifPort);
            this.tabNavigationPage3.Controls.Add(this.labelControl3);
            this.tabNavigationPage3.Controls.Add(this.txtPortSignalR);
            this.tabNavigationPage3.Controls.Add(this.SaveConfig);
            this.tabNavigationPage3.Controls.Add(this.labelControl2);
            this.tabNavigationPage3.Controls.Add(this.checkLaunchServer);
            this.tabNavigationPage3.Controls.Add(this.checkLaunchWeb);
            this.tabNavigationPage3.Controls.Add(this.checkOpenMinimized);
            this.tabNavigationPage3.Controls.Add(this.labelControl1);
            this.tabNavigationPage3.Controls.Add(this.weblink);
            this.tabNavigationPage3.Controls.Add(this.groupBox5);
            this.tabNavigationPage3.Controls.Add(this.btnRestoreDefaults);
            this.tabNavigationPage3.Controls.Add(this.groupBox2);
            this.tabNavigationPage3.Controls.Add(this.btnSaveConfig);
            this.tabNavigationPage3.Controls.Add(this.groupBox4);
            this.tabNavigationPage3.Controls.Add(this.groupBox3);
            this.tabNavigationPage3.Controls.Add(this.groupBox1);
            this.tabNavigationPage3.Image = global::InvenTID.Properties.Resources.chartxaxissettings_32x321;
            this.tabNavigationPage3.Name = "tabNavigationPage3";
            this.tabNavigationPage3.Size = new System.Drawing.Size(483, 238);
            // 
            // btnVerifPort
            // 
            this.btnVerifPort.Location = new System.Drawing.Point(418, 183);
            this.btnVerifPort.Name = "btnVerifPort";
            this.btnVerifPort.Size = new System.Drawing.Size(40, 22);
            this.btnVerifPort.TabIndex = 60;
            this.btnVerifPort.Text = "Verif.";
            this.btnVerifPort.Click += new System.EventHandler(this.btnVerifPort_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(253, 187);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(24, 13);
            this.labelControl3.TabIndex = 59;
            this.labelControl3.Text = "Port:";
            // 
            // txtPortSignalR
            // 
            this.txtPortSignalR.Location = new System.Drawing.Point(281, 184);
            this.txtPortSignalR.MenuManager = this.ribbon;
            this.txtPortSignalR.Name = "txtPortSignalR";
            this.txtPortSignalR.Properties.MaxLength = 5;
            this.txtPortSignalR.Size = new System.Drawing.Size(131, 20);
            this.txtPortSignalR.TabIndex = 58;
            // 
            // SaveConfig
            // 
            this.SaveConfig.Location = new System.Drawing.Point(257, 210);
            this.SaveConfig.Name = "SaveConfig";
            this.SaveConfig.Size = new System.Drawing.Size(57, 22);
            this.SaveConfig.TabIndex = 57;
            this.SaveConfig.Text = "Appliquer";
            this.SaveConfig.Click += new System.EventHandler(this.SaveConfig_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(278, 164);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(181, 13);
            this.labelControl2.TabIndex = 56;
            this.labelControl2.Text = "Ex: http://inventid.actemium.com:80/";
            // 
            // checkLaunchServer
            // 
            this.checkLaunchServer.AutoSize = true;
            this.checkLaunchServer.Location = new System.Drawing.Point(253, 117);
            this.checkLaunchServer.Name = "checkLaunchServer";
            this.checkLaunchServer.Size = new System.Drawing.Size(192, 17);
            this.checkLaunchServer.TabIndex = 55;
            this.checkLaunchServer.Text = "Connecter l\'appli automatiquement";
            this.checkLaunchServer.UseVisualStyleBackColor = true;
            // 
            // checkLaunchWeb
            // 
            this.checkLaunchWeb.AutoSize = true;
            this.checkLaunchWeb.Location = new System.Drawing.Point(253, 94);
            this.checkLaunchWeb.Name = "checkLaunchWeb";
            this.checkLaunchWeb.Size = new System.Drawing.Size(176, 17);
            this.checkLaunchWeb.TabIndex = 55;
            this.checkLaunchWeb.Text = "Lancer l\'appli WEB à l\'ouverture";
            this.checkLaunchWeb.UseVisualStyleBackColor = true;
            // 
            // checkOpenMinimized
            // 
            this.checkOpenMinimized.AutoSize = true;
            this.checkOpenMinimized.Location = new System.Drawing.Point(253, 71);
            this.checkOpenMinimized.Name = "checkOpenMinimized";
            this.checkOpenMinimized.Size = new System.Drawing.Size(133, 17);
            this.checkOpenMinimized.TabIndex = 54;
            this.checkOpenMinimized.Text = "Minimiser à l\'ouverture";
            this.checkOpenMinimized.UseVisualStyleBackColor = true;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(253, 145);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(22, 13);
            this.labelControl1.TabIndex = 53;
            this.labelControl1.Text = "Site:";
            // 
            // weblink
            // 
            this.weblink.Location = new System.Drawing.Point(281, 141);
            this.weblink.MenuManager = this.ribbon;
            this.weblink.Name = "weblink";
            this.weblink.Size = new System.Drawing.Size(177, 20);
            this.weblink.TabIndex = 52;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox5.BackColor = System.Drawing.Color.Transparent;
            this.groupBox5.Controls.Add(this.btnSetBatchMode);
            this.groupBox5.Controls.Add(this.btnGetBatchMode);
            this.groupBox5.Controls.Add(this.cmb_BatchMode);
            this.groupBox5.Location = new System.Drawing.Point(252, 7);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox5.Size = new System.Drawing.Size(217, 55);
            this.groupBox5.TabIndex = 49;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Batch Mode";
            // 
            // btnSetBatchMode
            // 
            this.btnSetBatchMode.Location = new System.Drawing.Point(166, 23);
            this.btnSetBatchMode.Name = "btnSetBatchMode";
            this.btnSetBatchMode.Size = new System.Drawing.Size(41, 23);
            this.btnSetBatchMode.TabIndex = 41;
            this.btnSetBatchMode.Text = "Definir";
            this.btnSetBatchMode.Click += new System.EventHandler(this.btnSetBatchMode_Click);
            // 
            // btnGetBatchMode
            // 
            this.btnGetBatchMode.Location = new System.Drawing.Point(133, 23);
            this.btnGetBatchMode.Name = "btnGetBatchMode";
            this.btnGetBatchMode.Size = new System.Drawing.Size(28, 23);
            this.btnGetBatchMode.TabIndex = 40;
            this.btnGetBatchMode.Text = "Lire";
            this.btnGetBatchMode.Click += new System.EventHandler(this.btnGetBatchMode_Click);
            // 
            // cmb_BatchMode
            // 
            this.cmb_BatchMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_BatchMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_BatchMode.FormattingEnabled = true;
            this.cmb_BatchMode.Location = new System.Drawing.Point(4, 24);
            this.cmb_BatchMode.Margin = new System.Windows.Forms.Padding(2);
            this.cmb_BatchMode.Name = "cmb_BatchMode";
            this.cmb_BatchMode.Size = new System.Drawing.Size(124, 21);
            this.cmb_BatchMode.TabIndex = 27;
            // 
            // btnRestoreDefaults
            // 
            this.btnRestoreDefaults.Location = new System.Drawing.Point(387, 210);
            this.btnRestoreDefaults.Name = "btnRestoreDefaults";
            this.btnRestoreDefaults.Size = new System.Drawing.Size(71, 22);
            this.btnRestoreDefaults.TabIndex = 41;
            this.btnRestoreDefaults.Text = "Reinitialiser";
            this.btnRestoreDefaults.Click += new System.EventHandler(this.btnRestoreDefaults_ItemClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.cboStatus);
            this.groupBox2.Controls.Add(this.btnGetStatus);
            this.groupBox2.Location = new System.Drawing.Point(14, 177);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(225, 50);
            this.groupBox2.TabIndex = 39;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Etat";
            // 
            // cboStatus
            // 
            this.cboStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Items.AddRange(new object[] {
            "Battery",
            "Power",
            "Temperature"});
            this.cboStatus.Location = new System.Drawing.Point(10, 18);
            this.cboStatus.Margin = new System.Windows.Forms.Padding(2);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(159, 21);
            this.cboStatus.TabIndex = 45;
            // 
            // btnGetStatus
            // 
            this.btnGetStatus.Location = new System.Drawing.Point(175, 16);
            this.btnGetStatus.Name = "btnGetStatus";
            this.btnGetStatus.Size = new System.Drawing.Size(40, 23);
            this.btnGetStatus.TabIndex = 40;
            this.btnGetStatus.Text = "Lire";
            this.btnGetStatus.Click += new System.EventHandler(this.btnGetStatus_ItemClick);
            // 
            // btnSaveConfig
            // 
            this.btnSaveConfig.Location = new System.Drawing.Point(318, 210);
            this.btnSaveConfig.Name = "btnSaveConfig";
            this.btnSaveConfig.Size = new System.Drawing.Size(64, 22);
            this.btnSaveConfig.TabIndex = 40;
            this.btnSaveConfig.Text = "Enregistrer";
            this.btnSaveConfig.Click += new System.EventHandler(this.btnSaveConfig_ItemClick);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.btnSetBeeperVolume);
            this.groupBox4.Controls.Add(this.btnGetBeeperVolume);
            this.groupBox4.Controls.Add(this.cboBeeperVolume);
            this.groupBox4.Location = new System.Drawing.Point(14, 66);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(225, 56);
            this.groupBox4.TabIndex = 37;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Volume Beeper";
            // 
            // btnSetBeeperVolume
            // 
            this.btnSetBeeperVolume.Location = new System.Drawing.Point(175, 23);
            this.btnSetBeeperVolume.Name = "btnSetBeeperVolume";
            this.btnSetBeeperVolume.Size = new System.Drawing.Size(40, 23);
            this.btnSetBeeperVolume.TabIndex = 41;
            this.btnSetBeeperVolume.Text = "Definir";
            this.btnSetBeeperVolume.Click += new System.EventHandler(this.btnSetBeeperVolume_ItemClick);
            // 
            // btnGetBeeperVolume
            // 
            this.btnGetBeeperVolume.Location = new System.Drawing.Point(134, 23);
            this.btnGetBeeperVolume.Name = "btnGetBeeperVolume";
            this.btnGetBeeperVolume.Size = new System.Drawing.Size(35, 23);
            this.btnGetBeeperVolume.TabIndex = 40;
            this.btnGetBeeperVolume.Text = "Lire";
            this.btnGetBeeperVolume.Click += new System.EventHandler(this.btnGetBeeperVolume_ItemClick);
            // 
            // cboBeeperVolume
            // 
            this.cboBeeperVolume.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBeeperVolume.FormattingEnabled = true;
            this.cboBeeperVolume.Location = new System.Drawing.Point(11, 23);
            this.cboBeeperVolume.Margin = new System.Windows.Forms.Padding(2);
            this.cboBeeperVolume.Name = "cboBeeperVolume";
            this.cboBeeperVolume.Size = new System.Drawing.Size(118, 21);
            this.cboBeeperVolume.TabIndex = 26;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.lblRegion);
            this.groupBox3.Controls.Add(this.btnGetRegion);
            this.groupBox3.Controls.Add(this.txtRegion);
            this.groupBox3.Location = new System.Drawing.Point(15, 126);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(224, 50);
            this.groupBox3.TabIndex = 38;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Config Regulation";
            // 
            // lblRegion
            // 
            this.lblRegion.AutoSize = true;
            this.lblRegion.Location = new System.Drawing.Point(11, 21);
            this.lblRegion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRegion.Name = "lblRegion";
            this.lblRegion.Size = new System.Drawing.Size(40, 13);
            this.lblRegion.TabIndex = 30;
            this.lblRegion.Text = "Region";
            // 
            // btnGetRegion
            // 
            this.btnGetRegion.Location = new System.Drawing.Point(174, 21);
            this.btnGetRegion.Name = "btnGetRegion";
            this.btnGetRegion.Size = new System.Drawing.Size(40, 23);
            this.btnGetRegion.TabIndex = 40;
            this.btnGetRegion.Text = "Lire";
            this.btnGetRegion.Click += new System.EventHandler(this.btnGetRegion_ItemClick);
            // 
            // txtRegion
            // 
            this.txtRegion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRegion.Location = new System.Drawing.Point(60, 21);
            this.txtRegion.Name = "txtRegion";
            this.txtRegion.ReadOnly = true;
            this.txtRegion.Size = new System.Drawing.Size(108, 21);
            this.txtRegion.TabIndex = 27;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnSetPower);
            this.groupBox1.Controls.Add(this.btnGetPower);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtPower);
            this.groupBox1.Location = new System.Drawing.Point(14, 7);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(225, 55);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configuration Antenne";
            // 
            // btnSetPower
            // 
            this.btnSetPower.Location = new System.Drawing.Point(175, 22);
            this.btnSetPower.Name = "btnSetPower";
            this.btnSetPower.Size = new System.Drawing.Size(40, 23);
            this.btnSetPower.TabIndex = 41;
            this.btnSetPower.Text = "Definir";
            this.btnSetPower.Click += new System.EventHandler(this.btnSetPower_ItemClick);
            // 
            // btnGetPower
            // 
            this.btnGetPower.Location = new System.Drawing.Point(134, 22);
            this.btnGetPower.Name = "btnGetPower";
            this.btnGetPower.Size = new System.Drawing.Size(35, 23);
            this.btnGetPower.TabIndex = 40;
            this.btnGetPower.Text = "Lire";
            this.btnGetPower.Click += new System.EventHandler(this.btnGetPower_ItemClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 27);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Transmit. PI";
            // 
            // txtPower
            // 
            this.txtPower.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPower.Location = new System.Drawing.Point(77, 23);
            this.txtPower.Name = "txtPower";
            this.txtPower.Size = new System.Drawing.Size(52, 21);
            this.txtPower.TabIndex = 23;
            // 
            // tabNavigationPage4
            // 
            this.tabNavigationPage4.Caption = "login";
            this.tabNavigationPage4.Controls.Add(this.grpDashboard);
            this.tabNavigationPage4.Controls.Add(this.grpStatut);
            this.tabNavigationPage4.Controls.Add(this.grpLogin);
            this.tabNavigationPage4.Image = ((System.Drawing.Image)(resources.GetObject("tabNavigationPage4.Image")));
            this.tabNavigationPage4.Name = "tabNavigationPage4";
            this.tabNavigationPage4.Size = new System.Drawing.Size(483, 238);
            // 
            // grpDashboard
            // 
            this.grpDashboard.Controls.Add(this.txtManufactureDate);
            this.grpDashboard.Controls.Add(this.txtManufactureName);
            this.grpDashboard.Controls.Add(this.label8);
            this.grpDashboard.Controls.Add(this.label6);
            this.grpDashboard.Controls.Add(this.txtSerialNumber);
            this.grpDashboard.Controls.Add(this.label1);
            this.grpDashboard.Controls.Add(this.txtModelName);
            this.grpDashboard.Controls.Add(this.label7);
            this.grpDashboard.Location = new System.Drawing.Point(3, 3);
            this.grpDashboard.Name = "grpDashboard";
            this.grpDashboard.Size = new System.Drawing.Size(349, 131);
            this.grpDashboard.TabIndex = 2;
            this.grpDashboard.Text = "Info Lecteur RFID";
            // 
            // txtManufactureDate
            // 
            this.txtManufactureDate.Enabled = false;
            this.txtManufactureDate.Location = new System.Drawing.Point(64, 98);
            this.txtManufactureDate.Margin = new System.Windows.Forms.Padding(2);
            this.txtManufactureDate.Name = "txtManufactureDate";
            this.txtManufactureDate.ReadOnly = true;
            this.txtManufactureDate.Size = new System.Drawing.Size(135, 21);
            this.txtManufactureDate.TabIndex = 67;
            // 
            // txtManufactureName
            // 
            this.txtManufactureName.Enabled = false;
            this.txtManufactureName.Location = new System.Drawing.Point(64, 50);
            this.txtManufactureName.Margin = new System.Windows.Forms.Padding(2);
            this.txtManufactureName.Name = "txtManufactureName";
            this.txtManufactureName.ReadOnly = true;
            this.txtManufactureName.Size = new System.Drawing.Size(271, 21);
            this.txtManufactureName.TabIndex = 63;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 101);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 66;
            this.label8.Text = "Date fab.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 53);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 62;
            this.label6.Text = "Produit";
            // 
            // txtSerialNumber
            // 
            this.txtSerialNumber.Enabled = false;
            this.txtSerialNumber.Location = new System.Drawing.Point(64, 74);
            this.txtSerialNumber.Margin = new System.Windows.Forms.Padding(2);
            this.txtSerialNumber.Name = "txtSerialNumber";
            this.txtSerialNumber.ReadOnly = true;
            this.txtSerialNumber.Size = new System.Drawing.Size(271, 21);
            this.txtSerialNumber.TabIndex = 65;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 60;
            this.label1.Text = "Fabricant";
            // 
            // txtModelName
            // 
            this.txtModelName.Enabled = false;
            this.txtModelName.Location = new System.Drawing.Point(64, 26);
            this.txtModelName.Margin = new System.Windows.Forms.Padding(2);
            this.txtModelName.Name = "txtModelName";
            this.txtModelName.ReadOnly = true;
            this.txtModelName.Size = new System.Drawing.Size(271, 21);
            this.txtModelName.TabIndex = 61;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 77);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 13);
            this.label7.TabIndex = 64;
            this.label7.Text = "SN";
            // 
            // grpStatut
            // 
            this.grpStatut.Controls.Add(this.ledSignalR);
            this.grpStatut.Controls.Add(this.ledRfid);
            this.grpStatut.Controls.Add(this.labelControl7);
            this.grpStatut.Controls.Add(this.labelControl6);
            this.grpStatut.Location = new System.Drawing.Point(358, 3);
            this.grpStatut.Name = "grpStatut";
            this.grpStatut.Size = new System.Drawing.Size(122, 229);
            this.grpStatut.TabIndex = 1;
            this.grpStatut.Text = "Etat";
            // 
            // ledSignalR
            // 
            this.ledSignalR.Image = global::InvenTID.Properties.Resources.led_red;
            this.ledSignalR.Location = new System.Drawing.Point(36, 156);
            this.ledSignalR.Name = "ledSignalR";
            this.ledSignalR.Size = new System.Drawing.Size(50, 50);
            this.ledSignalR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ledSignalR.TabIndex = 59;
            this.ledSignalR.TabStop = false;
            // 
            // ledRfid
            // 
            this.ledRfid.Image = global::InvenTID.Properties.Resources.led_red;
            this.ledRfid.Location = new System.Drawing.Point(36, 62);
            this.ledRfid.Name = "ledRfid";
            this.ledRfid.Size = new System.Drawing.Size(50, 50);
            this.ledRfid.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ledRfid.TabIndex = 1;
            this.ledRfid.TabStop = false;
            // 
            // labelControl7
            // 
            this.labelControl7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl7.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Appearance.Options.UseForeColor = true;
            this.labelControl7.Location = new System.Drawing.Point(36, 125);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(49, 13);
            this.labelControl7.TabIndex = 58;
            this.labelControl7.Text = "CONSOLE";
            // 
            // labelControl6
            // 
            this.labelControl6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl6.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Appearance.Options.UseForeColor = true;
            this.labelControl6.Location = new System.Drawing.Point(26, 34);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(73, 13);
            this.labelControl6.TabIndex = 58;
            this.labelControl6.Text = "Lecteur RFID";
            // 
            // grpLogin
            // 
            this.grpLogin.Controls.Add(this.labelControl5);
            this.grpLogin.Controls.Add(this.txtPassword);
            this.grpLogin.Controls.Add(this.labelControl4);
            this.grpLogin.Controls.Add(this.txtUsername);
            this.grpLogin.Controls.Add(this.logOn);
            this.grpLogin.Controls.Add(this.checkAutoLogin);
            this.grpLogin.Location = new System.Drawing.Point(3, 133);
            this.grpLogin.Name = "grpLogin";
            this.grpLogin.Size = new System.Drawing.Size(349, 99);
            this.grpLogin.TabIndex = 0;
            this.grpLogin.Text = "Connexion à l\'application";
            // 
            // labelControl5
            // 
            this.labelControl5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl5.Location = new System.Drawing.Point(12, 52);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(64, 13);
            this.labelControl5.TabIndex = 60;
            this.labelControl5.Text = "Mot de passe";
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Location = new System.Drawing.Point(84, 50);
            this.txtPassword.MenuManager = this.ribbon;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(206, 20);
            this.txtPassword.TabIndex = 59;
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl4.Location = new System.Drawing.Point(12, 26);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(50, 13);
            this.labelControl4.TabIndex = 58;
            this.labelControl4.Text = "Identifiant";
            // 
            // txtUsername
            // 
            this.txtUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsername.Location = new System.Drawing.Point(84, 25);
            this.txtUsername.MenuManager = this.ribbon;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(206, 20);
            this.txtUsername.TabIndex = 57;
            // 
            // logOn
            // 
            this.logOn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.logOn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("logOn.ImageOptions.Image")));
            this.logOn.Location = new System.Drawing.Point(296, 26);
            this.logOn.Name = "logOn";
            this.logOn.Size = new System.Drawing.Size(39, 44);
            this.logOn.TabIndex = 56;
            this.logOn.Click += new System.EventHandler(this.logOn_Click);
            // 
            // checkAutoLogin
            // 
            this.checkAutoLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkAutoLogin.AutoSize = true;
            this.checkAutoLogin.Location = new System.Drawing.Point(12, 76);
            this.checkAutoLogin.Name = "checkAutoLogin";
            this.checkAutoLogin.Size = new System.Drawing.Size(230, 17);
            this.checkAutoLogin.TabIndex = 55;
            this.checkAutoLogin.Text = "Enregistrer mes informations de connexion";
            this.checkAutoLogin.UseVisualStyleBackColor = true;
            this.checkAutoLogin.CheckedChanged += new System.EventHandler(this.checkAutoLogin_CheckedChanged);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "Actemium InvenTID en mode reduit";
            this.notifyIcon1.BalloonTipTitle = "Message";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "InvenTID";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // comboBoxReaders
            // 
            this.comboBoxReaders.FormattingEnabled = true;
            this.comboBoxReaders.Location = new System.Drawing.Point(236, 31);
            this.comboBoxReaders.Name = "comboBoxReaders";
            this.comboBoxReaders.Size = new System.Drawing.Size(263, 21);
            this.comboBoxReaders.TabIndex = 26;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 449);
            this.Controls.Add(this.comboBoxReaders);
            this.Controls.Add(this.tabPane1);
            this.Controls.Add(this.ribbon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(606, 450);
            this.MinimumSize = new System.Drawing.Size(489, 450);
            this.Name = "FrmMain";
            this.Ribbon = this.ribbon;
            this.Text = "Actemium RFID-based Tools Management";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_Closing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.Resize += new System.EventHandler(this.FrmMain_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPane1)).EndInit();
            this.tabPane1.ResumeLayout(false);
            this.tabNavigationPage1.ResumeLayout(false);
            this.tabNavigationPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTags)).EndInit();
            this.tabNavigationPage2.ResumeLayout(false);
            this.tabNavigationPage2.PerformLayout();
            this.tabNavigationPage3.ResumeLayout(false);
            this.tabNavigationPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPortSignalR.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weblink.Properties)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabNavigationPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpDashboard)).EndInit();
            this.grpDashboard.ResumeLayout(false);
            this.grpDashboard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpStatut)).EndInit();
            this.grpStatut.ResumeLayout(false);
            this.grpStatut.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ledSignalR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledRfid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpLogin)).EndInit();
            this.grpLogin.ResumeLayout(false);
            this.grpLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        public DevExpress.XtraBars.BarButtonItem btnConnect;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private DevExpress.XtraBars.BarButtonItem btnPairNew;
        private DevExpress.XtraBars.BarButtonItem btnVersionInfo;
        public DevExpress.XtraBars.BarButtonItem btnDisconnect;
        public DevExpress.XtraBars.BarButtonItem btnInventory;
        public DevExpress.XtraBars.BarButtonItem btnAbort;
        public DevExpress.XtraBars.BarButtonItem btnClear;
        private DevExpress.XtraBars.BarButtonItem btnGetTags;
        private DevExpress.XtraBars.BarButtonItem btnPurgeTags;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem btnWeb;
        private DevExpress.XtraBars.BarButtonItem btnGetActiveScanners;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraBars.Navigation.TabPane tabPane1;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPage1;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPage2;
        private System.Windows.Forms.DataGridView grdTags;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem triggers;
        private DevExpress.XtraBars.BarButtonItem btnConf;
        private DevExpress.XtraBars.BarButtonItem btnAbout;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPage3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cboBeeperVolume;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblRegion;
        private System.Windows.Forms.TextBox txtRegion;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.SimpleButton btnGetPower;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPower;
        private System.Windows.Forms.TextBox txtOutput;
        private DevExpress.XtraEditors.SimpleButton btnGetStatus;
        private DevExpress.XtraEditors.SimpleButton btnSetBeeperVolume;
        private DevExpress.XtraEditors.SimpleButton btnGetBeeperVolume;
        private DevExpress.XtraEditors.SimpleButton btnGetRegion;
        private DevExpress.XtraEditors.SimpleButton btnSetPower;
        private DevExpress.XtraEditors.SimpleButton btnRestoreDefaults;
        private DevExpress.XtraEditors.SimpleButton btnSaveConfig;
        private System.Windows.Forms.TextBox txtTotalTags;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ComboBox comboBoxReaders;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox cmb_BatchMode;
        private DevExpress.XtraEditors.SimpleButton btnSetBatchMode;
        private DevExpress.XtraEditors.SimpleButton btnGetBatchMode;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit weblink;
        private System.Windows.Forms.CheckBox checkLaunchWeb;
        private System.Windows.Forms.CheckBox checkOpenMinimized;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton SaveConfig;
        private DevExpress.XtraBars.BarButtonItem btnStart;
        private DevExpress.XtraBars.BarButtonItem btnStop;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        private System.Windows.Forms.CheckBox checkLaunchServer;
        private DevExpress.XtraBars.BarButtonItem btnCapacites;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtPortSignalR;
        private DevExpress.XtraEditors.SimpleButton btnVerifPort;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPage4;
        private DevExpress.XtraEditors.GroupControl grpLogin;
        private DevExpress.XtraEditors.GroupControl grpStatut;
        private System.Windows.Forms.CheckBox checkAutoLogin;
        private DevExpress.XtraEditors.SimpleButton logOn;
        private DevExpress.XtraEditors.GroupControl grpDashboard;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtUsername;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private System.Windows.Forms.PictureBox ledSignalR;
        private System.Windows.Forms.PictureBox ledRfid;
        private System.Windows.Forms.TextBox txtManufactureDate;
        private System.Windows.Forms.TextBox txtManufactureName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSerialNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtModelName;
        private System.Windows.Forms.Label label7;
    }
}