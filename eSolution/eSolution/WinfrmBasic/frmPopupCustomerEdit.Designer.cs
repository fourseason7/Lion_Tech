namespace eSolution.WinfrmBasic
{
    partial class frmPopupCustomerEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPopupCustomerEdit));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barBtnNew = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnSave = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grpCustomer = new DevExpress.XtraEditors.GroupControl();
            this.txtCustomerID = new DevExpress.XtraEditors.TextEdit();
            this.lueUseYN = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.txtContactTitle = new DevExpress.XtraEditors.TextEdit();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.txtContactName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.txtFax = new DevExpress.XtraEditors.TextEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.txtPhone = new DevExpress.XtraEditors.TextEdit();
            this.txtPostalCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtCity = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtAddress2 = new DevExpress.XtraEditors.TextEdit();
            this.txtAddress1 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtCustomerName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtCustomerCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lueState = new DevExpress.XtraEditors.LookUpEdit();
            this.luePaymentTerm = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpCustomer)).BeginInit();
            this.grpCustomer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueUseYN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContactTitle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContactName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFax.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPostalCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueState.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luePaymentTerm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
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
            this.barBtnNew,
            this.barBtnEdit,
            this.barBtnSave});
            this.barManager1.MaxItemId = 3;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barBtnNew, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barBtnEdit, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barBtnSave, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.Text = "Tools";
            // 
            // barBtnNew
            // 
            this.barBtnNew.Caption = "New";
            this.barBtnNew.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnNew.Glyph")));
            this.barBtnNew.Id = 0;
            this.barBtnNew.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barBtnNew.LargeGlyph")));
            this.barBtnNew.Name = "barBtnNew";
            this.barBtnNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnNew_ItemClick);
            // 
            // barBtnEdit
            // 
            this.barBtnEdit.Caption = "Edit";
            this.barBtnEdit.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnEdit.Glyph")));
            this.barBtnEdit.Id = 1;
            this.barBtnEdit.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barBtnEdit.LargeGlyph")));
            this.barBtnEdit.Name = "barBtnEdit";
            // 
            // barBtnSave
            // 
            this.barBtnSave.Caption = "Save";
            this.barBtnSave.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnSave.Glyph")));
            this.barBtnSave.Id = 2;
            this.barBtnSave.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barBtnSave.LargeGlyph")));
            this.barBtnSave.Name = "barBtnSave";
            this.barBtnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnSave_ItemClick);
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
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlTop.Size = new System.Drawing.Size(667, 39);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 590);
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlBottom.Size = new System.Drawing.Size(667, 25);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 39);
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 551);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(667, 39);
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 551);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grpCustomer);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 39);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(667, 551);
            this.layoutControl1.TabIndex = 4;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grpCustomer
            // 
            this.grpCustomer.Controls.Add(this.txtCustomerID);
            this.grpCustomer.Controls.Add(this.lueUseYN);
            this.grpCustomer.Controls.Add(this.labelControl13);
            this.grpCustomer.Controls.Add(this.labelControl12);
            this.grpCustomer.Controls.Add(this.txtContactTitle);
            this.grpCustomer.Controls.Add(this.labelControl11);
            this.grpCustomer.Controls.Add(this.txtContactName);
            this.grpCustomer.Controls.Add(this.labelControl10);
            this.grpCustomer.Controls.Add(this.txtFax);
            this.grpCustomer.Controls.Add(this.labelControl9);
            this.grpCustomer.Controls.Add(this.labelControl8);
            this.grpCustomer.Controls.Add(this.txtPhone);
            this.grpCustomer.Controls.Add(this.txtPostalCode);
            this.grpCustomer.Controls.Add(this.labelControl7);
            this.grpCustomer.Controls.Add(this.labelControl6);
            this.grpCustomer.Controls.Add(this.txtCity);
            this.grpCustomer.Controls.Add(this.labelControl5);
            this.grpCustomer.Controls.Add(this.txtAddress2);
            this.grpCustomer.Controls.Add(this.txtAddress1);
            this.grpCustomer.Controls.Add(this.labelControl4);
            this.grpCustomer.Controls.Add(this.txtCustomerName);
            this.grpCustomer.Controls.Add(this.labelControl3);
            this.grpCustomer.Controls.Add(this.txtCustomerCode);
            this.grpCustomer.Controls.Add(this.labelControl2);
            this.grpCustomer.Controls.Add(this.labelControl1);
            this.grpCustomer.Controls.Add(this.lueState);
            this.grpCustomer.Controls.Add(this.luePaymentTerm);
            this.grpCustomer.Location = new System.Drawing.Point(16, 16);
            this.grpCustomer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpCustomer.Name = "grpCustomer";
            this.grpCustomer.Size = new System.Drawing.Size(635, 519);
            this.grpCustomer.TabIndex = 4;
            this.grpCustomer.Text = "Customer Detail";
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.Location = new System.Drawing.Point(485, 47);
            this.txtCustomerID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCustomerID.MenuManager = this.barManager1;
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.Size = new System.Drawing.Size(117, 22);
            this.txtCustomerID.TabIndex = 26;
            // 
            // lueUseYN
            // 
            this.lueUseYN.Location = new System.Drawing.Point(131, 431);
            this.lueUseYN.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lueUseYN.MenuManager = this.barManager1;
            this.lueUseYN.Name = "lueUseYN";
            this.lueUseYN.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueUseYN.Properties.NullText = "";
            this.lueUseYN.Size = new System.Drawing.Size(117, 22);
            this.lueUseYN.TabIndex = 25;
            // 
            // labelControl13
            // 
            this.labelControl13.Location = new System.Drawing.Point(72, 434);
            this.labelControl13.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(54, 16);
            this.labelControl13.TabIndex = 24;
            this.labelControl13.Text = "Use Y/N.:";
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(34, 402);
            this.labelControl12.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(93, 16);
            this.labelControl12.TabIndex = 22;
            this.labelControl12.Text = "Payment Term.:";
            // 
            // txtContactTitle
            // 
            this.txtContactTitle.Location = new System.Drawing.Point(131, 143);
            this.txtContactTitle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtContactTitle.MenuManager = this.barManager1;
            this.txtContactTitle.Name = "txtContactTitle";
            this.txtContactTitle.Size = new System.Drawing.Size(471, 22);
            this.txtContactTitle.TabIndex = 21;
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(89, 146);
            this.labelControl11.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(34, 16);
            this.labelControl11.TabIndex = 20;
            this.labelControl11.Text = "Title.:";
            // 
            // txtContactName
            // 
            this.txtContactName.Location = new System.Drawing.Point(131, 111);
            this.txtContactName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtContactName.MenuManager = this.barManager1;
            this.txtContactName.Name = "txtContactName";
            this.txtContactName.Size = new System.Drawing.Size(471, 22);
            this.txtContactName.TabIndex = 19;
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(37, 114);
            this.labelControl10.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(89, 16);
            this.labelControl10.TabIndex = 18;
            this.labelControl10.Text = "Contact Name.:";
            // 
            // txtFax
            // 
            this.txtFax.Location = new System.Drawing.Point(131, 367);
            this.txtFax.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFax.MenuManager = this.barManager1;
            this.txtFax.Name = "txtFax";
            this.txtFax.Properties.Mask.EditMask = "(999) 000-0000";
            this.txtFax.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.txtFax.Size = new System.Drawing.Size(117, 22);
            this.txtFax.TabIndex = 17;
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(86, 370);
            this.labelControl9.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(38, 16);
            this.labelControl9.TabIndex = 16;
            this.labelControl9.Text = "Fax#.:";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(72, 338);
            this.labelControl8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(53, 16);
            this.labelControl8.TabIndex = 15;
            this.labelControl8.Text = "Phone#.:";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(131, 335);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPhone.MenuManager = this.barManager1;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Properties.Mask.EditMask = "(999) 000-0000";
            this.txtPhone.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.txtPhone.Size = new System.Drawing.Size(117, 22);
            this.txtPhone.TabIndex = 14;
            // 
            // txtPostalCode
            // 
            this.txtPostalCode.Location = new System.Drawing.Point(131, 303);
            this.txtPostalCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPostalCode.MenuManager = this.barManager1;
            this.txtPostalCode.Name = "txtPostalCode";
            this.txtPostalCode.Properties.Mask.EditMask = "00000-9999";
            this.txtPostalCode.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.txtPostalCode.Size = new System.Drawing.Size(153, 22);
            this.txtPostalCode.TabIndex = 13;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(50, 306);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(76, 16);
            this.labelControl7.TabIndex = 12;
            this.labelControl7.Text = "Postal Code.:";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(84, 274);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(39, 16);
            this.labelControl6.TabIndex = 10;
            this.labelControl6.Text = "State.:";
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(131, 239);
            this.txtCity.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCity.MenuManager = this.barManager1;
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(153, 22);
            this.txtCity.TabIndex = 9;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(94, 242);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(30, 16);
            this.labelControl5.TabIndex = 8;
            this.labelControl5.Text = "City.:";
            // 
            // txtAddress2
            // 
            this.txtAddress2.Location = new System.Drawing.Point(131, 207);
            this.txtAddress2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAddress2.MenuManager = this.barManager1;
            this.txtAddress2.Name = "txtAddress2";
            this.txtAddress2.Size = new System.Drawing.Size(471, 22);
            this.txtAddress2.TabIndex = 7;
            // 
            // txtAddress1
            // 
            this.txtAddress1.Location = new System.Drawing.Point(131, 175);
            this.txtAddress1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAddress1.MenuManager = this.barManager1;
            this.txtAddress1.Name = "txtAddress1";
            this.txtAddress1.Size = new System.Drawing.Size(471, 22);
            this.txtAddress1.TabIndex = 6;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(69, 178);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(55, 16);
            this.labelControl4.TabIndex = 5;
            this.labelControl4.Text = "Address.:";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(131, 79);
            this.txtCustomerName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCustomerName.MenuManager = this.barManager1;
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(471, 22);
            this.txtCustomerName.TabIndex = 4;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl3.Location = new System.Drawing.Point(254, 50);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(145, 16);
            this.labelControl3.TabIndex = 3;
            this.labelControl3.Text = "* Customer Code : 3Digit";
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.Location = new System.Drawing.Point(131, 47);
            this.txtCustomerCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCustomerCode.MenuManager = this.barManager1;
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.Size = new System.Drawing.Size(117, 22);
            this.txtCustomerCode.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(28, 82);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(101, 16);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Customer Name.:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(30, 50);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(97, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Customer Code.:";
            // 
            // lueState
            // 
            this.lueState.Location = new System.Drawing.Point(131, 271);
            this.lueState.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lueState.MenuManager = this.barManager1;
            this.lueState.Name = "lueState";
            this.lueState.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueState.Properties.NullText = "";
            this.lueState.Size = new System.Drawing.Size(153, 22);
            this.lueState.TabIndex = 11;
            // 
            // luePaymentTerm
            // 
            this.luePaymentTerm.Location = new System.Drawing.Point(131, 399);
            this.luePaymentTerm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.luePaymentTerm.MenuManager = this.barManager1;
            this.luePaymentTerm.Name = "luePaymentTerm";
            this.luePaymentTerm.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luePaymentTerm.Properties.NullText = "";
            this.luePaymentTerm.Size = new System.Drawing.Size(299, 22);
            this.luePaymentTerm.TabIndex = 23;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(667, 551);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grpCustomer;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(641, 525);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // frmPopupCustomerEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 615);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmPopupCustomerEdit";
            this.Text = "Customer Edit";
            this.Load += new System.EventHandler(this.frmPopupCustomerEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpCustomer)).EndInit();
            this.grpCustomer.ResumeLayout(false);
            this.grpCustomer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueUseYN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContactTitle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContactName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFax.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPostalCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueState.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luePaymentTerm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
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
        private DevExpress.XtraBars.BarButtonItem barBtnNew;
        private DevExpress.XtraBars.BarButtonItem barBtnEdit;
        private DevExpress.XtraBars.BarButtonItem barBtnSave;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.GroupControl grpCustomer;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txtCity;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtAddress2;
        private DevExpress.XtraEditors.TextEdit txtAddress1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtCustomerName;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtCustomerCode;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.LookUpEdit lueState;
        private DevExpress.XtraEditors.LookUpEdit lueUseYN;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.TextEdit txtContactTitle;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.TextEdit txtContactName;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.TextEdit txtFax;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.TextEdit txtPhone;
        private DevExpress.XtraEditors.TextEdit txtPostalCode;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LookUpEdit luePaymentTerm;
        private DevExpress.XtraEditors.TextEdit txtCustomerID;
    }
}