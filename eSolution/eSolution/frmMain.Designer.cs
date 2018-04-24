namespace eSolution
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barSubMenuFile = new DevExpress.XtraBars.BarSubItem();
            this.barSubMenuExit = new DevExpress.XtraBars.BarButtonItem();
            this.barSubMenuHelp = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.navBarMainMenu = new DevExpress.XtraNavBar.NavBarControl();
            this.grpProduction = new DevExpress.XtraNavBar.NavBarGroup();
            this.mnuSizeMeasForApple = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem2 = new DevExpress.XtraNavBar.NavBarItem();
            this.mnuCustomerPOList = new DevExpress.XtraNavBar.NavBarItem();
            this.mnuPacking = new DevExpress.XtraNavBar.NavBarItem();
            this.mnuPalletize = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem1 = new DevExpress.XtraNavBar.NavBarItem();
            this.mnuPackingHistory = new DevExpress.XtraNavBar.NavBarItem();
            this.mnuPalletStatus = new DevExpress.XtraNavBar.NavBarItem();
            this.mnuInventorySummary = new DevExpress.XtraNavBar.NavBarItem();
            this.grpBasic = new DevExpress.XtraNavBar.NavBarGroup();
            this.mnuModelMaster = new DevExpress.XtraNavBar.NavBarItem();
            this.mnuModelItemByCustomer = new DevExpress.XtraNavBar.NavBarItem();
            this.mnuCustomer = new DevExpress.XtraNavBar.NavBarItem();
            this.mnuSupplier = new DevExpress.XtraNavBar.NavBarItem();
            this.mnuUserCode = new DevExpress.XtraNavBar.NavBarItem();
            this.grpReport = new DevExpress.XtraNavBar.NavBarGroup();
            this.mnuDailyResult = new DevExpress.XtraNavBar.NavBarItem();
            this.mnuPackingSummaryForCVE = new DevExpress.XtraNavBar.NavBarItem();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarMainMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barSubMenuFile,
            this.barSubMenuExit,
            this.barSubMenuHelp,
            this.barButtonItem1});
            this.barManager1.MaxItemId = 4;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSubMenuFile, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSubMenuHelp, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.Text = "Tools";
            // 
            // barSubMenuFile
            // 
            this.barSubMenuFile.Caption = "&File";
            this.barSubMenuFile.Glyph = ((System.Drawing.Image)(resources.GetObject("barSubMenuFile.Glyph")));
            this.barSubMenuFile.Id = 0;
            this.barSubMenuFile.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barSubMenuFile.LargeGlyph")));
            this.barSubMenuFile.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubMenuExit)});
            this.barSubMenuFile.Name = "barSubMenuFile";
            // 
            // barSubMenuExit
            // 
            this.barSubMenuExit.Caption = "E&xit";
            this.barSubMenuExit.Glyph = ((System.Drawing.Image)(resources.GetObject("barSubMenuExit.Glyph")));
            this.barSubMenuExit.Id = 1;
            this.barSubMenuExit.Name = "barSubMenuExit";
            this.barSubMenuExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barSubMenuExit_ItemClick);
            // 
            // barSubMenuHelp
            // 
            this.barSubMenuHelp.Caption = "&Help";
            this.barSubMenuHelp.Glyph = ((System.Drawing.Image)(resources.GetObject("barSubMenuHelp.Glyph")));
            this.barSubMenuHelp.Id = 2;
            this.barSubMenuHelp.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1)});
            this.barSubMenuHelp.Name = "barSubMenuHelp";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "About";
            this.barButtonItem1.Id = 3;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1008, 47);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 706);
            this.barDockControlBottom.Size = new System.Drawing.Size(1008, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 47);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 659);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1008, 47);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 659);
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // navBarMainMenu
            // 
            this.navBarMainMenu.ActiveGroup = this.grpProduction;
            this.navBarMainMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.navBarMainMenu.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.grpBasic,
            this.grpProduction,
            this.grpReport});
            this.navBarMainMenu.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.mnuModelMaster,
            this.mnuModelItemByCustomer,
            this.mnuCustomer,
            this.mnuPacking,
            this.mnuSupplier,
            this.mnuPalletize,
            this.mnuCustomerPOList,
            this.mnuUserCode,
            this.mnuPackingHistory,
            this.navBarItem1,
            this.mnuPalletStatus,
            this.mnuInventorySummary,
            this.navBarItem2,
            this.mnuSizeMeasForApple,
            this.mnuDailyResult,
            this.mnuPackingSummaryForCVE});
            this.navBarMainMenu.Location = new System.Drawing.Point(0, 47);
            this.navBarMainMenu.Name = "navBarMainMenu";
            this.navBarMainMenu.OptionsNavPane.ExpandedWidth = 177;
            this.navBarMainMenu.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.navBarMainMenu.Size = new System.Drawing.Size(177, 659);
            this.navBarMainMenu.TabIndex = 7;
            this.navBarMainMenu.Text = "navBarControl1";
            this.navBarMainMenu.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarMainMenu_LinkClicked);
            // 
            // grpProduction
            // 
            this.grpProduction.Caption = "Production";
            this.grpProduction.Expanded = true;
            this.grpProduction.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.mnuSizeMeasForApple),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem2),
            new DevExpress.XtraNavBar.NavBarItemLink(this.mnuCustomerPOList),
            new DevExpress.XtraNavBar.NavBarItemLink(this.mnuPacking),
            new DevExpress.XtraNavBar.NavBarItemLink(this.mnuPalletize),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem1),
            new DevExpress.XtraNavBar.NavBarItemLink(this.mnuPackingHistory),
            new DevExpress.XtraNavBar.NavBarItemLink(this.mnuPalletStatus),
            new DevExpress.XtraNavBar.NavBarItemLink(this.mnuPackingSummaryForCVE),
            new DevExpress.XtraNavBar.NavBarItemLink(this.mnuInventorySummary)});
            this.grpProduction.LargeImage = ((System.Drawing.Image)(resources.GetObject("grpProduction.LargeImage")));
            this.grpProduction.Name = "grpProduction";
            this.grpProduction.SmallImage = ((System.Drawing.Image)(resources.GetObject("grpProduction.SmallImage")));
            // 
            // mnuSizeMeasForApple
            // 
            this.mnuSizeMeasForApple.Caption = "Size Measurement for Apple";
            this.mnuSizeMeasForApple.Name = "mnuSizeMeasForApple";
            this.mnuSizeMeasForApple.Tag = "eSolution.WinfrmBasic.frmSizeMeasForApple";
            // 
            // navBarItem2
            // 
            this.navBarItem2.Caption = "-";
            this.navBarItem2.Name = "navBarItem2";
            // 
            // mnuCustomerPOList
            // 
            this.mnuCustomerPOList.Caption = "Customer P/O List";
            this.mnuCustomerPOList.Name = "mnuCustomerPOList";
            this.mnuCustomerPOList.Tag = "eSolution.frmPOList";
            // 
            // mnuPacking
            // 
            this.mnuPacking.Caption = "Packing-Shippment";
            this.mnuPacking.Name = "mnuPacking";
            this.mnuPacking.Tag = "eSolution.WinfrmBasic.frmPacking";
            // 
            // mnuPalletize
            // 
            this.mnuPalletize.Caption = "Palletize";
            this.mnuPalletize.Name = "mnuPalletize";
            this.mnuPalletize.Tag = "eSolution.WinfrmBasic.frmPalletize";
            // 
            // navBarItem1
            // 
            this.navBarItem1.Caption = "-";
            this.navBarItem1.Name = "navBarItem1";
            // 
            // mnuPackingHistory
            // 
            this.mnuPackingHistory.Caption = "Packing History";
            this.mnuPackingHistory.Name = "mnuPackingHistory";
            this.mnuPackingHistory.Tag = "eSolution.WinfrmBasic.frmPOPackingHistory";
            // 
            // mnuPalletStatus
            // 
            this.mnuPalletStatus.Caption = "Pallet Status";
            this.mnuPalletStatus.Name = "mnuPalletStatus";
            this.mnuPalletStatus.Tag = "eSolution.WinfrmBasic.frmPalletStatus";
            // 
            // mnuInventorySummary
            // 
            this.mnuInventorySummary.Caption = "Inventory Summary";
            this.mnuInventorySummary.Name = "mnuInventorySummary";
            this.mnuInventorySummary.Tag = "eSolution.WinfrmBasic.frmInventorySummary";
            // 
            // grpBasic
            // 
            this.grpBasic.Caption = "Basic Information";
            this.grpBasic.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.mnuModelMaster),
            new DevExpress.XtraNavBar.NavBarItemLink(this.mnuModelItemByCustomer),
            new DevExpress.XtraNavBar.NavBarItemLink(this.mnuCustomer),
            new DevExpress.XtraNavBar.NavBarItemLink(this.mnuSupplier),
            new DevExpress.XtraNavBar.NavBarItemLink(this.mnuUserCode)});
            this.grpBasic.LargeImage = ((System.Drawing.Image)(resources.GetObject("grpBasic.LargeImage")));
            this.grpBasic.Name = "grpBasic";
            // 
            // mnuModelMaster
            // 
            this.mnuModelMaster.Caption = "Model Master";
            this.mnuModelMaster.Name = "mnuModelMaster";
            this.mnuModelMaster.Tag = "eSolution.frmItemMaster";
            // 
            // mnuModelItemByCustomer
            // 
            this.mnuModelItemByCustomer.Caption = "Model Item By Customer";
            this.mnuModelItemByCustomer.Name = "mnuModelItemByCustomer";
            this.mnuModelItemByCustomer.Tag = "eSolution.WinfrmBasic.frmItemByCustomer";
            // 
            // mnuCustomer
            // 
            this.mnuCustomer.Caption = "Customer";
            this.mnuCustomer.Name = "mnuCustomer";
            this.mnuCustomer.Tag = "eSolution.WinfrmBasic.frmCustomerMaster";
            // 
            // mnuSupplier
            // 
            this.mnuSupplier.Caption = "Supplier";
            this.mnuSupplier.Name = "mnuSupplier";
            // 
            // mnuUserCode
            // 
            this.mnuUserCode.Caption = "User Code ";
            this.mnuUserCode.Name = "mnuUserCode";
            this.mnuUserCode.Tag = "eSolution.WinfrmBasic.frmUserCode";
            // 
            // grpReport
            // 
            this.grpReport.Caption = "Report";
            this.grpReport.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.mnuDailyResult)});
            this.grpReport.LargeImage = ((System.Drawing.Image)(resources.GetObject("grpReport.LargeImage")));
            this.grpReport.Name = "grpReport";
            // 
            // mnuDailyResult
            // 
            this.mnuDailyResult.Caption = "Daily Result";
            this.mnuDailyResult.Name = "mnuDailyResult";
            this.mnuDailyResult.Tag = "eSolution.WinfrmBasic.frmDailyResult";
            // 
            // mnuPackingSummaryForCVE
            // 
            this.mnuPackingSummaryForCVE.Caption = "Packing Summary for CVE";
            this.mnuPackingSummaryForCVE.Name = "mnuPackingSummaryForCVE";
            this.mnuPackingSummaryForCVE.Tag = "eSolution.WinfrmBasic.frmPackingSummaryForCVE";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.navBarMainMenu);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "eSolution for EG2";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarMainMenu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraNavBar.NavBarControl navBarMainMenu;
        private DevExpress.XtraNavBar.NavBarGroup grpBasic;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraNavBar.NavBarGroup grpProduction;
        private DevExpress.XtraNavBar.NavBarItem mnuModelMaster;
        private DevExpress.XtraNavBar.NavBarItem mnuCustomer;
        private DevExpress.XtraNavBar.NavBarItem mnuPacking;
        private DevExpress.XtraBars.BarSubItem barSubMenuFile;
        private DevExpress.XtraBars.BarButtonItem barSubMenuExit;
        private DevExpress.XtraBars.BarSubItem barSubMenuHelp;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraNavBar.NavBarItem mnuModelItemByCustomer;
        private DevExpress.XtraNavBar.NavBarItem mnuSupplier;
        private DevExpress.XtraNavBar.NavBarItem mnuPalletize;
        private DevExpress.XtraNavBar.NavBarItem mnuCustomerPOList;
        private DevExpress.XtraNavBar.NavBarItem mnuUserCode;
        private DevExpress.XtraNavBar.NavBarItem navBarItem1;
        private DevExpress.XtraNavBar.NavBarItem mnuPackingHistory;
        private DevExpress.XtraNavBar.NavBarItem mnuPalletStatus;
        private DevExpress.XtraNavBar.NavBarItem mnuInventorySummary;
        private DevExpress.XtraNavBar.NavBarItem mnuSizeMeasForApple;
        private DevExpress.XtraNavBar.NavBarItem navBarItem2;
        private DevExpress.XtraNavBar.NavBarGroup grpReport;
        private DevExpress.XtraNavBar.NavBarItem mnuDailyResult;
        private DevExpress.XtraNavBar.NavBarItem mnuPackingSummaryForCVE;
    }
}