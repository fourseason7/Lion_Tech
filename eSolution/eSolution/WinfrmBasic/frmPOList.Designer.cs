namespace eSolution
{
    partial class frmPOList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPOList));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barBtnSearch = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnNew = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gcPODetail = new DevExpress.XtraEditors.GroupControl();
            this.gcDetail = new DevExpress.XtraGrid.GridControl();
            this.gvDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcPOHeader = new DevExpress.XtraEditors.GroupControl();
            this.gcHeader = new DevExpress.XtraGrid.GridControl();
            this.gvHeader = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcSearch = new DevExpress.XtraEditors.GroupControl();
            this.lueSearchPOType = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.dtSearchDateTo = new DevExpress.XtraEditors.DateEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lueSearchPO = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lueSearchCustomer = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtSearchItem = new DevExpress.XtraEditors.TextEdit();
            this.lueSearchStatus = new DevExpress.XtraEditors.LookUpEdit();
            this.dtSearchDateFrom = new DevExpress.XtraEditors.DateEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcPODetail)).BeginInit();
            this.gcPODetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPOHeader)).BeginInit();
            this.gcPOHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSearch)).BeginInit();
            this.gcSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueSearchPOType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSearchDateTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSearchDateTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSearchPO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSearchCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchItem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSearchStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSearchDateFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSearchDateFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
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
            this.barBtnSearch,
            this.barBtnNew,
            this.barBtnDelete,
            this.barBtnEdit});
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barBtnSearch, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barBtnNew, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barBtnDelete, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barBtnEdit, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.Offset = 1;
            this.bar1.Text = "Tools";
            // 
            // barBtnSearch
            // 
            this.barBtnSearch.Caption = "Search";
            this.barBtnSearch.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnSearch.Glyph")));
            this.barBtnSearch.Id = 0;
            this.barBtnSearch.ItemAppearance.Disabled.Font = new System.Drawing.Font("Tahoma", 10F);
            this.barBtnSearch.ItemAppearance.Disabled.Options.UseFont = true;
            this.barBtnSearch.ItemAppearance.Hovered.Font = new System.Drawing.Font("Tahoma", 10F);
            this.barBtnSearch.ItemAppearance.Hovered.Options.UseFont = true;
            this.barBtnSearch.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 10F);
            this.barBtnSearch.ItemAppearance.Normal.Options.UseFont = true;
            this.barBtnSearch.ItemAppearance.Pressed.Font = new System.Drawing.Font("Tahoma", 10F);
            this.barBtnSearch.ItemAppearance.Pressed.Options.UseFont = true;
            this.barBtnSearch.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barBtnSearch.LargeGlyph")));
            this.barBtnSearch.Name = "barBtnSearch";
            this.barBtnSearch.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnSearch_ItemClick);
            // 
            // barBtnNew
            // 
            this.barBtnNew.Caption = "Create New P/O";
            this.barBtnNew.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnNew.Glyph")));
            this.barBtnNew.Id = 1;
            this.barBtnNew.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barBtnNew.LargeGlyph")));
            this.barBtnNew.Name = "barBtnNew";
            this.barBtnNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnNew_ItemClick);
            // 
            // barBtnDelete
            // 
            this.barBtnDelete.Caption = "Delete P/O";
            this.barBtnDelete.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnDelete.Glyph")));
            this.barBtnDelete.Id = 2;
            this.barBtnDelete.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barBtnDelete.LargeGlyph")));
            this.barBtnDelete.Name = "barBtnDelete";
            this.barBtnDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnDelete_ItemClick);
            // 
            // barBtnEdit
            // 
            this.barBtnEdit.Caption = "Edit P/O";
            this.barBtnEdit.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnEdit.Glyph")));
            this.barBtnEdit.Id = 3;
            this.barBtnEdit.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barBtnEdit.LargeGlyph")));
            this.barBtnEdit.Name = "barBtnEdit";
            this.barBtnEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnEdit_ItemClick);
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
            this.barDockControlTop.Size = new System.Drawing.Size(857, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 656);
            this.barDockControlBottom.Size = new System.Drawing.Size(857, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 625);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(857, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 625);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gcPODetail);
            this.layoutControl1.Controls.Add(this.gcPOHeader);
            this.layoutControl1.Controls.Add(this.gcSearch);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 31);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(2247, 226, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(857, 625);
            this.layoutControl1.TabIndex = 4;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gcPODetail
            // 
            this.gcPODetail.Controls.Add(this.gcDetail);
            this.gcPODetail.Location = new System.Drawing.Point(12, 324);
            this.gcPODetail.Name = "gcPODetail";
            this.gcPODetail.Size = new System.Drawing.Size(833, 289);
            this.gcPODetail.TabIndex = 6;
            this.gcPODetail.Text = "Purchase Order Detail";
            // 
            // gcDetail
            // 
            this.gcDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDetail.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gcDetail.Location = new System.Drawing.Point(2, 21);
            this.gcDetail.MainView = this.gvDetail;
            this.gcDetail.MenuManager = this.barManager1;
            this.gcDetail.Name = "gcDetail";
            this.gcDetail.Size = new System.Drawing.Size(829, 266);
            this.gcDetail.TabIndex = 0;
            this.gcDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDetail});
            // 
            // gvDetail
            // 
            this.gvDetail.GridControl = this.gcDetail;
            this.gvDetail.Name = "gvDetail";
            this.gvDetail.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvDetail_CustomDrawRowIndicator);
            this.gvDetail.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.gvDetail_MouseWheel);
            this.gvDetail.RowCountChanged += new System.EventHandler(this.gvDetail_RowCountChanged);
            // 
            // gcPOHeader
            // 
            this.gcPOHeader.Controls.Add(this.gcHeader);
            this.gcPOHeader.Location = new System.Drawing.Point(12, 98);
            this.gcPOHeader.Name = "gcPOHeader";
            this.gcPOHeader.Size = new System.Drawing.Size(833, 222);
            this.gcPOHeader.TabIndex = 5;
            this.gcPOHeader.Text = "Purchase Order Header";
            // 
            // gcHeader
            // 
            this.gcHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcHeader.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gcHeader.Location = new System.Drawing.Point(2, 21);
            this.gcHeader.MainView = this.gvHeader;
            this.gcHeader.MenuManager = this.barManager1;
            this.gcHeader.Name = "gcHeader";
            this.gcHeader.Size = new System.Drawing.Size(829, 199);
            this.gcHeader.TabIndex = 0;
            this.gcHeader.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvHeader});
            // 
            // gvHeader
            // 
            this.gvHeader.GridControl = this.gcHeader;
            this.gvHeader.Name = "gvHeader";
            this.gvHeader.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvHeader_CustomDrawRowIndicator);
            this.gvHeader.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvHeader_FocusedRowChanged);
            this.gvHeader.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.gvHeader_MouseWheel);
            this.gvHeader.RowCountChanged += new System.EventHandler(this.gvHeader_RowCountChanged);
            // 
            // gcSearch
            // 
            this.gcSearch.Controls.Add(this.lueSearchPOType);
            this.gcSearch.Controls.Add(this.labelControl7);
            this.gcSearch.Controls.Add(this.labelControl6);
            this.gcSearch.Controls.Add(this.dtSearchDateTo);
            this.gcSearch.Controls.Add(this.labelControl5);
            this.gcSearch.Controls.Add(this.labelControl4);
            this.gcSearch.Controls.Add(this.labelControl3);
            this.gcSearch.Controls.Add(this.lueSearchPO);
            this.gcSearch.Controls.Add(this.labelControl2);
            this.gcSearch.Controls.Add(this.lueSearchCustomer);
            this.gcSearch.Controls.Add(this.labelControl1);
            this.gcSearch.Controls.Add(this.txtSearchItem);
            this.gcSearch.Controls.Add(this.lueSearchStatus);
            this.gcSearch.Controls.Add(this.dtSearchDateFrom);
            this.gcSearch.Location = new System.Drawing.Point(12, 12);
            this.gcSearch.Name = "gcSearch";
            this.gcSearch.Size = new System.Drawing.Size(833, 82);
            this.gcSearch.TabIndex = 4;
            this.gcSearch.Text = "Search Condition";
            this.gcSearch.Paint += new System.Windows.Forms.PaintEventHandler(this.gcSearch_Paint);
            // 
            // lueSearchPOType
            // 
            this.lueSearchPOType.Location = new System.Drawing.Point(706, 24);
            this.lueSearchPOType.Name = "lueSearchPOType";
            this.lueSearchPOType.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lueSearchPOType.Properties.Appearance.Options.UseFont = true;
            this.lueSearchPOType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueSearchPOType.Properties.NullText = "";
            this.lueSearchPOType.Size = new System.Drawing.Size(92, 22);
            this.lueSearchPOType.TabIndex = 19;
            this.lueSearchPOType.Tag = "POTYPE";
            this.lueSearchPOType.EditValueChanged += new System.EventHandler(this.lueSearchPOType_EditValueChanged);
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl7.Location = new System.Drawing.Point(636, 27);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(62, 16);
            this.labelControl7.TabIndex = 18;
            this.labelControl7.Text = "P/O Type.:";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl6.Location = new System.Drawing.Point(192, 27);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(5, 16);
            this.labelControl6.TabIndex = 17;
            this.labelControl6.Text = "-";
            // 
            // dtSearchDateTo
            // 
            this.dtSearchDateTo.EditValue = new System.DateTime(2016, 2, 20, 0, 0, 0, 0);
            this.dtSearchDateTo.Location = new System.Drawing.Point(203, 24);
            this.dtSearchDateTo.Name = "dtSearchDateTo";
            this.dtSearchDateTo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.dtSearchDateTo.Properties.Appearance.Options.UseFont = true;
            this.dtSearchDateTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtSearchDateTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtSearchDateTo.Size = new System.Drawing.Size(103, 22);
            this.dtSearchDateTo.TabIndex = 16;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl5.Location = new System.Drawing.Point(5, 27);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(72, 16);
            this.labelControl5.TabIndex = 14;
            this.labelControl5.Text = "Order Date.:";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl4.Location = new System.Drawing.Point(507, 55);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(45, 16);
            this.labelControl4.TabIndex = 12;
            this.labelControl4.Text = "Status.:";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl3.Location = new System.Drawing.Point(282, 55);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(35, 16);
            this.labelControl3.TabIndex = 10;
            this.labelControl3.Text = "Item.:";
            // 
            // lueSearchPO
            // 
            this.lueSearchPO.Location = new System.Drawing.Point(83, 52);
            this.lueSearchPO.Name = "lueSearchPO";
            this.lueSearchPO.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lueSearchPO.Properties.Appearance.Options.UseFont = true;
            this.lueSearchPO.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueSearchPO.Properties.NullText = "";
            this.lueSearchPO.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lueSearchPO.Size = new System.Drawing.Size(128, 22);
            this.lueSearchPO.TabIndex = 9;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl2.Location = new System.Drawing.Point(38, 55);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(39, 16);
            this.labelControl2.TabIndex = 8;
            this.labelControl2.Text = "P/O#.:";
            // 
            // lueSearchCustomer
            // 
            this.lueSearchCustomer.Location = new System.Drawing.Point(407, 24);
            this.lueSearchCustomer.Name = "lueSearchCustomer";
            this.lueSearchCustomer.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lueSearchCustomer.Properties.Appearance.Options.UseFont = true;
            this.lueSearchCustomer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueSearchCustomer.Properties.NullText = "";
            this.lueSearchCustomer.Size = new System.Drawing.Size(187, 22);
            this.lueSearchCustomer.TabIndex = 7;
            this.lueSearchCustomer.EditValueChanged += new System.EventHandler(this.lueSearchCustomer_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl1.Location = new System.Drawing.Point(337, 27);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(64, 16);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "Customer.:";
            // 
            // txtSearchItem
            // 
            this.txtSearchItem.Location = new System.Drawing.Point(323, 52);
            this.txtSearchItem.Name = "txtSearchItem";
            this.txtSearchItem.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtSearchItem.Properties.Appearance.Options.UseFont = true;
            this.txtSearchItem.Size = new System.Drawing.Size(122, 22);
            this.txtSearchItem.TabIndex = 11;
            // 
            // lueSearchStatus
            // 
            this.lueSearchStatus.Location = new System.Drawing.Point(558, 52);
            this.lueSearchStatus.Name = "lueSearchStatus";
            this.lueSearchStatus.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lueSearchStatus.Properties.Appearance.Options.UseFont = true;
            this.lueSearchStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueSearchStatus.Properties.NullText = "";
            this.lueSearchStatus.Size = new System.Drawing.Size(94, 22);
            this.lueSearchStatus.TabIndex = 13;
            // 
            // dtSearchDateFrom
            // 
            this.dtSearchDateFrom.EditValue = new System.DateTime(2016, 2, 20, 0, 0, 0, 0);
            this.dtSearchDateFrom.Location = new System.Drawing.Point(83, 24);
            this.dtSearchDateFrom.Name = "dtSearchDateFrom";
            this.dtSearchDateFrom.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.dtSearchDateFrom.Properties.Appearance.Options.UseFont = true;
            this.dtSearchDateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtSearchDateFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtSearchDateFrom.Size = new System.Drawing.Size(103, 22);
            this.dtSearchDateFrom.TabIndex = 15;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(857, 625);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gcSearch;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(0, 86);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(104, 86);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(837, 86);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gcPOHeader;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 86);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(837, 226);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.gcPODetail;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 312);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(837, 293);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // frmPOList
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 679);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Font = new System.Drawing.Font("Tahoma", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmPOList";
            this.Text = "Purhcase Order List";
            this.Activated += new System.EventHandler(this.frmPOList_Activated);
            this.Load += new System.EventHandler(this.frmPOList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcPODetail)).EndInit();
            this.gcPODetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPOHeader)).EndInit();
            this.gcPOHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSearch)).EndInit();
            this.gcSearch.ResumeLayout(false);
            this.gcSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueSearchPOType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSearchDateTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSearchDateTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSearchPO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSearchCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchItem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSearchStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSearchDateFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSearchDateFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.GroupControl gcPODetail;
        private DevExpress.XtraGrid.GridControl gcDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDetail;
        private DevExpress.XtraEditors.GroupControl gcPOHeader;
        private DevExpress.XtraGrid.GridControl gcHeader;
        private DevExpress.XtraGrid.Views.Grid.GridView gvHeader;
        private DevExpress.XtraEditors.GroupControl gcSearch;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraBars.BarButtonItem barBtnSearch;
        private DevExpress.XtraBars.BarButtonItem barBtnNew;
        private DevExpress.XtraBars.BarButtonItem barBtnDelete;
        private DevExpress.XtraBars.BarButtonItem barBtnEdit;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LookUpEdit lueSearchPO;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LookUpEdit lueSearchCustomer;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtSearchItem;
        private DevExpress.XtraEditors.LookUpEdit lueSearchStatus;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.DateEdit dtSearchDateTo;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.DateEdit dtSearchDateFrom;
        private DevExpress.XtraEditors.LookUpEdit lueSearchPOType;
        private DevExpress.XtraEditors.LabelControl labelControl7;
    }
}