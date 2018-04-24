namespace eSolution
{
    partial class frmItemMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmItemMaster));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.lueItemID = new DevExpress.XtraEditors.TextEdit();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnSearch = new DevExpress.XtraBars.BarButtonItem();
            this.btnAdd = new DevExpress.XtraBars.BarButtonItem();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnExport = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.lueUseYN = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lueItemCode = new DevExpress.XtraEditors.TextEdit();
            this.lueItemDescription = new DevExpress.XtraEditors.TextEdit();
            this.lueItemType = new DevExpress.XtraEditors.LookUpEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.gcList = new DevExpress.XtraGrid.GridControl();
            this.gvList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.lueSearchItemType = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.lueSearchUseYN = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lueSearchItem = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueItemID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueUseYN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueItemCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueItemDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueItemType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueSearchItemType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSearchUseYN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSearchItem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.groupControl3);
            this.layoutControl1.Controls.Add(this.groupControl2);
            this.layoutControl1.Controls.Add(this.groupControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 31);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(958, 625);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.labelControl6);
            this.groupControl3.Controls.Add(this.lueItemID);
            this.groupControl3.Controls.Add(this.lueUseYN);
            this.groupControl3.Controls.Add(this.labelControl5);
            this.groupControl3.Controls.Add(this.labelControl4);
            this.groupControl3.Controls.Add(this.labelControl3);
            this.groupControl3.Controls.Add(this.lueItemCode);
            this.groupControl3.Controls.Add(this.lueItemDescription);
            this.groupControl3.Controls.Add(this.lueItemType);
            this.groupControl3.Location = new System.Drawing.Point(12, 440);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(934, 173);
            this.groupControl3.TabIndex = 6;
            this.groupControl3.Text = "Item Detail (Add / Modify)";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl6.Location = new System.Drawing.Point(54, 83);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(67, 16);
            this.labelControl6.TabIndex = 9;
            this.labelControl6.Text = "Item Type.:";
            // 
            // lueItemID
            // 
            this.lueItemID.EditValue = "";
            this.lueItemID.Location = new System.Drawing.Point(420, 24);
            this.lueItemID.MenuManager = this.barManager1;
            this.lueItemID.Name = "lueItemID";
            this.lueItemID.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lueItemID.Properties.Appearance.Options.UseFont = true;
            this.lueItemID.Size = new System.Drawing.Size(117, 22);
            this.lueItemID.TabIndex = 8;
            this.lueItemID.Visible = false;
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
            this.barManager1.Images = this.imageCollection1;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnSearch,
            this.btnAdd,
            this.btnSave,
            this.barBtnExport});
            this.barManager1.MaxItemId = 4;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarAppearance.Disabled.Font = new System.Drawing.Font("Tahoma", 10F);
            this.bar1.BarAppearance.Disabled.Options.UseFont = true;
            this.bar1.BarAppearance.Hovered.Font = new System.Drawing.Font("Tahoma", 10F);
            this.bar1.BarAppearance.Hovered.Options.UseFont = true;
            this.bar1.BarAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 10F);
            this.bar1.BarAppearance.Normal.Options.UseFont = true;
            this.bar1.BarAppearance.Pressed.Font = new System.Drawing.Font("Tahoma", 10F);
            this.bar1.BarAppearance.Pressed.Options.UseFont = true;
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSearch, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnAdd, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSave, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barBtnExport, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.Offset = 2;
            this.bar1.Text = "Tools";
            // 
            // btnSearch
            // 
            this.btnSearch.Caption = "Search";
            this.btnSearch.Glyph = ((System.Drawing.Image)(resources.GetObject("btnSearch.Glyph")));
            this.btnSearch.Id = 0;
            this.btnSearch.ItemAppearance.Disabled.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnSearch.ItemAppearance.Disabled.Options.UseFont = true;
            this.btnSearch.ItemAppearance.Hovered.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnSearch.ItemAppearance.Hovered.Options.UseFont = true;
            this.btnSearch.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnSearch.ItemAppearance.Normal.Options.UseFont = true;
            this.btnSearch.ItemAppearance.Pressed.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnSearch.ItemAppearance.Pressed.Options.UseFont = true;
            this.btnSearch.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnSearch.LargeGlyph")));
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSearch_ItemClick);
            // 
            // btnAdd
            // 
            this.btnAdd.Caption = "Add";
            this.btnAdd.Glyph = ((System.Drawing.Image)(resources.GetObject("btnAdd.Glyph")));
            this.btnAdd.Id = 1;
            this.btnAdd.ImageIndex = 0;
            this.btnAdd.ItemAppearance.Disabled.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnAdd.ItemAppearance.Disabled.Options.UseFont = true;
            this.btnAdd.ItemAppearance.Hovered.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnAdd.ItemAppearance.Hovered.Options.UseFont = true;
            this.btnAdd.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnAdd.ItemAppearance.Normal.Options.UseFont = true;
            this.btnAdd.ItemAppearance.Pressed.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnAdd.ItemAppearance.Pressed.Options.UseFont = true;
            this.btnAdd.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnAdd.LargeGlyph")));
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAdd_ItemClick);
            // 
            // btnSave
            // 
            this.btnSave.Caption = "Save";
            this.btnSave.Glyph = ((System.Drawing.Image)(resources.GetObject("btnSave.Glyph")));
            this.btnSave.Id = 2;
            this.btnSave.ImageIndex = 18;
            this.btnSave.ItemAppearance.Disabled.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnSave.ItemAppearance.Disabled.Options.UseFont = true;
            this.btnSave.ItemAppearance.Hovered.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnSave.ItemAppearance.Hovered.Options.UseFont = true;
            this.btnSave.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnSave.ItemAppearance.Normal.Options.UseFont = true;
            this.btnSave.ItemAppearance.Pressed.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnSave.ItemAppearance.Pressed.Options.UseFont = true;
            this.btnSave.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnSave.LargeGlyph")));
            this.btnSave.Name = "btnSave";
            this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSave_ItemClick);
            // 
            // barBtnExport
            // 
            this.barBtnExport.Caption = "Excel Export";
            this.barBtnExport.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnExport.Glyph")));
            this.barBtnExport.Id = 3;
            this.barBtnExport.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barBtnExport.LargeGlyph")));
            this.barBtnExport.Name = "barBtnExport";
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
            this.barDockControlTop.Size = new System.Drawing.Size(958, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 656);
            this.barDockControlBottom.Size = new System.Drawing.Size(958, 23);
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
            this.barDockControlRight.Location = new System.Drawing.Point(958, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 625);
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.InsertGalleryImage("add_32x32.png", "images/actions/add_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/add_32x32.png"), 0);
            this.imageCollection1.Images.SetKeyName(0, "add_32x32.png");
            this.imageCollection1.InsertGalleryImage("additem_32x32.png", "images/actions/additem_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/additem_32x32.png"), 1);
            this.imageCollection1.Images.SetKeyName(1, "additem_32x32.png");
            this.imageCollection1.InsertGalleryImage("apply_32x32.png", "images/actions/apply_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/apply_32x32.png"), 2);
            this.imageCollection1.Images.SetKeyName(2, "apply_32x32.png");
            this.imageCollection1.InsertGalleryImage("cancel_32x32.png", "images/actions/cancel_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/cancel_32x32.png"), 3);
            this.imageCollection1.Images.SetKeyName(3, "cancel_32x32.png");
            this.imageCollection1.InsertGalleryImage("download_32x32.png", "images/actions/download_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/download_32x32.png"), 4);
            this.imageCollection1.Images.SetKeyName(4, "download_32x32.png");
            this.imageCollection1.InsertGalleryImage("loadfrom_32x32.png", "images/actions/loadfrom_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/loadfrom_32x32.png"), 5);
            this.imageCollection1.Images.SetKeyName(5, "loadfrom_32x32.png");
            this.imageCollection1.InsertGalleryImage("open_32x32.png", "images/actions/open_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/open_32x32.png"), 6);
            this.imageCollection1.Images.SetKeyName(6, "open_32x32.png");
            this.imageCollection1.InsertGalleryImage("refresh_32x32.png", "images/actions/refresh_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/refresh_32x32.png"), 7);
            this.imageCollection1.Images.SetKeyName(7, "refresh_32x32.png");
            this.imageCollection1.InsertGalleryImage("refresh2_32x32.png", "images/actions/refresh2_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/refresh2_32x32.png"), 8);
            this.imageCollection1.Images.SetKeyName(8, "refresh2_32x32.png");
            this.imageCollection1.InsertGalleryImage("remove_32x32.png", "images/actions/remove_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/remove_32x32.png"), 9);
            this.imageCollection1.Images.SetKeyName(9, "remove_32x32.png");
            this.imageCollection1.InsertGalleryImage("export_32x32.png", "images/export/export_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/export/export_32x32.png"), 10);
            this.imageCollection1.Images.SetKeyName(10, "export_32x32.png");
            this.imageCollection1.InsertGalleryImage("find_32x32.png", "images/find/find_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/find/find_32x32.png"), 11);
            this.imageCollection1.Images.SetKeyName(11, "find_32x32.png");
            this.imageCollection1.InsertGalleryImage("findcustomers_32x32.png", "images/find/findcustomers_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/find/findcustomers_32x32.png"), 12);
            this.imageCollection1.Images.SetKeyName(12, "findcustomers_32x32.png");
            this.imageCollection1.InsertGalleryImage("usergroup_32x32.png", "images/people/usergroup_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/people/usergroup_32x32.png"), 13);
            this.imageCollection1.Images.SetKeyName(13, "usergroup_32x32.png");
            this.imageCollection1.InsertGalleryImage("preview_32x32.png", "images/print/preview_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/print/preview_32x32.png"), 14);
            this.imageCollection1.Images.SetKeyName(14, "preview_32x32.png");
            this.imageCollection1.InsertGalleryImage("print_32x32.png", "images/print/print_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/print/print_32x32.png"), 15);
            this.imageCollection1.Images.SetKeyName(15, "print_32x32.png");
            this.imageCollection1.InsertGalleryImage("printdialog_32x32.png", "images/print/printdialog_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/print/printdialog_32x32.png"), 16);
            this.imageCollection1.Images.SetKeyName(16, "printdialog_32x32.png");
            this.imageCollection1.InsertGalleryImage("printviapdf_32x32.png", "images/print/printviapdf_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/print/printviapdf_32x32.png"), 17);
            this.imageCollection1.Images.SetKeyName(17, "printviapdf_32x32.png");
            this.imageCollection1.InsertGalleryImage("save_32x32.png", "images/save/save_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/save/save_32x32.png"), 18);
            this.imageCollection1.Images.SetKeyName(18, "save_32x32.png");
            this.imageCollection1.InsertGalleryImage("saveandclose_32x32.png", "images/save/saveandclose_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/save/saveandclose_32x32.png"), 19);
            this.imageCollection1.Images.SetKeyName(19, "saveandclose_32x32.png");
            this.imageCollection1.InsertGalleryImage("properties_32x32.png", "images/setup/properties_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/setup/properties_32x32.png"), 20);
            this.imageCollection1.Images.SetKeyName(20, "properties_32x32.png");
            this.imageCollection1.InsertGalleryImage("question_32x32.png", "images/support/question_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/support/question_32x32.png"), 21);
            this.imageCollection1.Images.SetKeyName(21, "question_32x32.png");
            this.imageCollection1.InsertGalleryImage("zoom_32x32.png", "images/zoom/zoom_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/zoom/zoom_32x32.png"), 22);
            this.imageCollection1.Images.SetKeyName(22, "zoom_32x32.png");
            // 
            // lueUseYN
            // 
            this.lueUseYN.EditValue = "";
            this.lueUseYN.Location = new System.Drawing.Point(162, 108);
            this.lueUseYN.MenuManager = this.barManager1;
            this.lueUseYN.Name = "lueUseYN";
            this.lueUseYN.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lueUseYN.Properties.Appearance.Options.UseFont = true;
            this.lueUseYN.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueUseYN.Properties.NullText = "";
            this.lueUseYN.Size = new System.Drawing.Size(252, 22);
            this.lueUseYN.TabIndex = 4;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl5.Location = new System.Drawing.Point(54, 111);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(54, 16);
            this.labelControl5.TabIndex = 7;
            this.labelControl5.Text = "Use Y/N.:";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl4.Location = new System.Drawing.Point(54, 55);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(102, 16);
            this.labelControl4.TabIndex = 5;
            this.labelControl4.Text = "Item Description.:";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl3.Location = new System.Drawing.Point(54, 27);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(68, 16);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Item Code.:";
            // 
            // lueItemCode
            // 
            this.lueItemCode.EditValue = "";
            this.lueItemCode.Location = new System.Drawing.Point(162, 24);
            this.lueItemCode.MenuManager = this.barManager1;
            this.lueItemCode.Name = "lueItemCode";
            this.lueItemCode.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lueItemCode.Properties.Appearance.Options.UseFont = true;
            this.lueItemCode.Size = new System.Drawing.Size(252, 22);
            this.lueItemCode.TabIndex = 4;
            // 
            // lueItemDescription
            // 
            this.lueItemDescription.EditValue = "";
            this.lueItemDescription.Location = new System.Drawing.Point(162, 52);
            this.lueItemDescription.MenuManager = this.barManager1;
            this.lueItemDescription.Name = "lueItemDescription";
            this.lueItemDescription.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lueItemDescription.Properties.Appearance.Options.UseFont = true;
            this.lueItemDescription.Size = new System.Drawing.Size(543, 22);
            this.lueItemDescription.TabIndex = 6;
            // 
            // lueItemType
            // 
            this.lueItemType.EditValue = "";
            this.lueItemType.Location = new System.Drawing.Point(162, 80);
            this.lueItemType.MenuManager = this.barManager1;
            this.lueItemType.Name = "lueItemType";
            this.lueItemType.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lueItemType.Properties.Appearance.Options.UseFont = true;
            this.lueItemType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueItemType.Properties.NullText = "";
            this.lueItemType.Size = new System.Drawing.Size(252, 22);
            this.lueItemType.TabIndex = 10;
            this.lueItemType.Tag = "ITEMTYPE";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.gcList);
            this.groupControl2.Location = new System.Drawing.Point(12, 83);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(934, 353);
            this.groupControl2.TabIndex = 5;
            this.groupControl2.Text = "Item Master List";
            // 
            // gcList
            // 
            this.gcList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcList.Location = new System.Drawing.Point(2, 21);
            this.gcList.MainView = this.gvList;
            this.gcList.MenuManager = this.barManager1;
            this.gcList.Name = "gcList";
            this.gcList.Size = new System.Drawing.Size(930, 330);
            this.gcList.TabIndex = 0;
            this.gcList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvList});
            // 
            // gvList
            // 
            this.gvList.GridControl = this.gcList;
            this.gvList.Name = "gvList";
            this.gvList.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvList_CustomDrawRowIndicator);
            this.gvList.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gvList_RowCellStyle);
            this.gvList.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvList_FocusedRowChanged);
            this.gvList.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.gvList_MouseWheel);
            this.gvList.RowCountChanged += new System.EventHandler(this.gvList_RowCountChanged);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.lueSearchItemType);
            this.groupControl1.Controls.Add(this.labelControl7);
            this.groupControl1.Controls.Add(this.lueSearchUseYN);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.lueSearchItem);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(934, 67);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "Search";
            // 
            // lueSearchItemType
            // 
            this.lueSearchItemType.EditValue = "";
            this.lueSearchItemType.Location = new System.Drawing.Point(428, 33);
            this.lueSearchItemType.MenuManager = this.barManager1;
            this.lueSearchItemType.Name = "lueSearchItemType";
            this.lueSearchItemType.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lueSearchItemType.Properties.Appearance.Options.UseFont = true;
            this.lueSearchItemType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueSearchItemType.Properties.NullText = "";
            this.lueSearchItemType.Size = new System.Drawing.Size(122, 22);
            this.lueSearchItemType.TabIndex = 5;
            this.lueSearchItemType.Tag = "ITEMTYPE";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl7.Location = new System.Drawing.Point(355, 36);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(67, 16);
            this.labelControl7.TabIndex = 4;
            this.labelControl7.Text = "Item Type.:";
            // 
            // lueSearchUseYN
            // 
            this.lueSearchUseYN.EditValue = "";
            this.lueSearchUseYN.Location = new System.Drawing.Point(643, 33);
            this.lueSearchUseYN.MenuManager = this.barManager1;
            this.lueSearchUseYN.Name = "lueSearchUseYN";
            this.lueSearchUseYN.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lueSearchUseYN.Properties.Appearance.Options.UseFont = true;
            this.lueSearchUseYN.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueSearchUseYN.Properties.NullText = "";
            this.lueSearchUseYN.Size = new System.Drawing.Size(122, 22);
            this.lueSearchUseYN.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl2.Location = new System.Drawing.Point(583, 36);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(54, 16);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Use Y/N.:";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl1.Location = new System.Drawing.Point(30, 36);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(35, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Item.:";
            // 
            // lueSearchItem
            // 
            this.lueSearchItem.EditValue = "";
            this.lueSearchItem.Location = new System.Drawing.Point(71, 33);
            this.lueSearchItem.MenuManager = this.barManager1;
            this.lueSearchItem.Name = "lueSearchItem";
            this.lueSearchItem.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lueSearchItem.Properties.Appearance.Options.UseFont = true;
            this.lueSearchItem.Size = new System.Drawing.Size(252, 22);
            this.lueSearchItem.TabIndex = 1;
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
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(958, 625);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.groupControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(938, 71);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.groupControl2;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 71);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(938, 357);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.groupControl3;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 428);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(938, 177);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // frmItemMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 679);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmItemMaster";
            this.Text = "Item Master";
            this.Load += new System.EventHandler(this.frmItemMaster_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueItemID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueUseYN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueItemCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueItemDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueItemType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueSearchItemType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSearchUseYN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSearchItem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LookUpEdit lueSearchUseYN;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btnSearch;
        private DevExpress.XtraBars.BarButtonItem btnAdd;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraGrid.GridControl gcList;
        private DevExpress.XtraGrid.Views.Grid.GridView gvList;
        private DevExpress.XtraEditors.LookUpEdit lueUseYN;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit lueItemCode;
        private DevExpress.XtraEditors.TextEdit lueItemDescription;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraEditors.TextEdit lueSearchItem;
        private DevExpress.XtraEditors.TextEdit lueItemID;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LookUpEdit lueItemType;
        private DevExpress.XtraEditors.LookUpEdit lueSearchItemType;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraBars.BarButtonItem barBtnExport;
    }
}