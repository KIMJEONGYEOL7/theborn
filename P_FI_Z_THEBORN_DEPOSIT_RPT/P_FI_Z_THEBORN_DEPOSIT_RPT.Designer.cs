namespace account
{
    partial class P_FI_Z_THEBORN_DEPOSIT_RPT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(P_FI_Z_THEBORN_DEPOSIT_RPT));
            this.labelExt5 = new Duzon.Common.Controls.LabelExt();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._flex = new Dass.FlexGrid.FlexGrid(this.components);
            this.oneGrid1 = new Duzon.Erpiu.Windows.OneControls.OneGrid();
            this.oneGridItem1 = new Duzon.Erpiu.Windows.OneControls.OneGridItem();
            this.bpPanelControl3 = new Duzon.Common.BpControls.BpPanelControl();
            this.BP_CD_PC = new Duzon.Common.BpControls.BpCodeTextBox();
            this.labelExt2 = new Duzon.Common.Controls.LabelExt();
            this.bpPanelControl2 = new Duzon.Common.BpControls.BpPanelControl();
            this.BP_NO_DEPOSIT = new Duzon.Common.BpControls.BpComboBox();
            this.labelExt1 = new Duzon.Common.Controls.LabelExt();
            this.bpPanelControl1 = new Duzon.Common.BpControls.BpPanelControl();
            this.CBO_YN_USE = new Duzon.Common.Controls.DropDownComboBox();
            this.mDataArea.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._flex)).BeginInit();
            this.oneGridItem1.SuspendLayout();
            this.bpPanelControl3.SuspendLayout();
            this.bpPanelControl2.SuspendLayout();
            this.bpPanelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mDataArea
            // 
            this.mDataArea.Controls.Add(this.tableLayoutPanel1);
            this.mDataArea.Size = new System.Drawing.Size(1090, 756);
            // 
            // labelExt5
            // 
            this.labelExt5.BackColor = System.Drawing.Color.Transparent;
            this.labelExt5.Font = new System.Drawing.Font("굴림체", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelExt5.ForeColor = System.Drawing.Color.Black;
            this.labelExt5.Location = new System.Drawing.Point(3, 2);
            this.labelExt5.Name = "labelExt5";
            this.labelExt5.Size = new System.Drawing.Size(70, 18);
            this.labelExt5.TabIndex = 0;
            this.labelExt5.Tag = "";
            this.labelExt5.Text = "회계단위";
            this.labelExt5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this._flex, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.oneGrid1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1090, 756);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // _flex
            // 
            this._flex.AllowFreezing = C1.Win.C1FlexGrid.AllowFreezingEnum.Both;
            this._flex.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Both;
            this._flex.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this._flex.AutoResize = false;
            this._flex.ColumnInfo = "1,1,0,0,0,0,Columns:0{TextAlign:CenterCenter;TextAlignFixed:CenterCenter;}\t";
            this._flex.Dock = System.Windows.Forms.DockStyle.Fill;
            this._flex.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw;
            this._flex.EnabledHeaderCheck = true;
            this._flex.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this._flex.Location = new System.Drawing.Point(0, 43);
            this._flex.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this._flex.Name = "_flex";
            this._flex.Rows.Count = 1;
            this._flex.Rows.DefaultSize = 20;
            this._flex.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this._flex.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.Always;
            this._flex.ShowSort = false;
            this._flex.Size = new System.Drawing.Size(1090, 713);
            this._flex.StyleInfo = resources.GetString("_flex.StyleInfo");
            this._flex.TabIndex = 55;
            this._flex.UseGridCalculator = true;
            // 
            // oneGrid1
            // 
            this.oneGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.oneGrid1.ItemCollection.AddRange(new Duzon.Erpiu.Windows.OneControls.OneGridItem[] {
            this.oneGridItem1});
            this.oneGrid1.Location = new System.Drawing.Point(0, 0);
            this.oneGrid1.Margin = new System.Windows.Forms.Padding(0);
            this.oneGrid1.Name = "oneGrid1";
            this.oneGrid1.Size = new System.Drawing.Size(1090, 40);
            this.oneGrid1.TabIndex = 53;
            // 
            // oneGridItem1
            // 
            this.oneGridItem1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.oneGridItem1.Controls.Add(this.bpPanelControl3);
            this.oneGridItem1.Controls.Add(this.bpPanelControl2);
            this.oneGridItem1.Controls.Add(this.bpPanelControl1);
            this.oneGridItem1.ItemSizeMode = Duzon.Erpiu.Windows.OneControls.ItemSizeMode.AutoLocation;
            this.oneGridItem1.Location = new System.Drawing.Point(0, 0);
            this.oneGridItem1.Name = "oneGridItem1";
            this.oneGridItem1.Size = new System.Drawing.Size(1080, 23);
            this.oneGridItem1.SizeMode = Duzon.Erpiu.Windows.OneControls.SizeMode.AutoSize;
            this.oneGridItem1.TabIndex = 0;
            // 
            // bpPanelControl3
            // 
            this.bpPanelControl3.Controls.Add(this.CBO_YN_USE);
            this.bpPanelControl3.Controls.Add(this.labelExt2);
            this.bpPanelControl3.Location = new System.Drawing.Point(549, 1);
            this.bpPanelControl3.Name = "bpPanelControl3";
            this.bpPanelControl3.Size = new System.Drawing.Size(270, 23);
            this.bpPanelControl3.TabIndex = 2;
            this.bpPanelControl3.Text = "bpPanelControl3";
            // 
            // BP_CD_PC
            // 
            this.BP_CD_PC.HelpID = Duzon.Common.Forms.Help.HelpID.P_MA_PC_SUB;
            this.BP_CD_PC.Location = new System.Drawing.Point(73, 1);
            this.BP_CD_PC.Name = "BP_CD_PC";
            this.BP_CD_PC.Size = new System.Drawing.Size(193, 21);
            this.BP_CD_PC.TabIndex = 30;
            this.BP_CD_PC.Tag = "";
            // 
            // labelExt2
            // 
            this.labelExt2.BackColor = System.Drawing.Color.Transparent;
            this.labelExt2.Font = new System.Drawing.Font("굴림체", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelExt2.ForeColor = System.Drawing.Color.Black;
            this.labelExt2.Location = new System.Drawing.Point(1, 2);
            this.labelExt2.Name = "labelExt2";
            this.labelExt2.Size = new System.Drawing.Size(70, 18);
            this.labelExt2.TabIndex = 2;
            this.labelExt2.Tag = "";
            this.labelExt2.Text = "사용여부";
            this.labelExt2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bpPanelControl2
            // 
            this.bpPanelControl2.Controls.Add(this.BP_NO_DEPOSIT);
            this.bpPanelControl2.Controls.Add(this.labelExt1);
            this.bpPanelControl2.Location = new System.Drawing.Point(276, 1);
            this.bpPanelControl2.Name = "bpPanelControl2";
            this.bpPanelControl2.Size = new System.Drawing.Size(271, 23);
            this.bpPanelControl2.TabIndex = 1;
            this.bpPanelControl2.Text = "bpPanelControl2";
            // 
            // BP_NO_DEPOSIT
            // 
            this.BP_NO_DEPOSIT.HelpID = Duzon.Common.Forms.Help.HelpID.P_MA_ACCT_LINK_SUB1;
            this.BP_NO_DEPOSIT.Location = new System.Drawing.Point(75, 0);
            this.BP_NO_DEPOSIT.Name = "BP_NO_DEPOSIT";
            this.BP_NO_DEPOSIT.Size = new System.Drawing.Size(192, 21);
            this.BP_NO_DEPOSIT.TabIndex = 20;
            this.BP_NO_DEPOSIT.TabStop = false;
            // 
            // labelExt1
            // 
            this.labelExt1.BackColor = System.Drawing.Color.Transparent;
            this.labelExt1.Font = new System.Drawing.Font("굴림체", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelExt1.ForeColor = System.Drawing.Color.Black;
            this.labelExt1.Location = new System.Drawing.Point(3, 2);
            this.labelExt1.Name = "labelExt1";
            this.labelExt1.Size = new System.Drawing.Size(70, 18);
            this.labelExt1.TabIndex = 1;
            this.labelExt1.Tag = "";
            this.labelExt1.Text = "은행계좌";
            this.labelExt1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bpPanelControl1
            // 
            this.bpPanelControl1.Controls.Add(this.BP_CD_PC);
            this.bpPanelControl1.Controls.Add(this.labelExt5);
            this.bpPanelControl1.Location = new System.Drawing.Point(2, 1);
            this.bpPanelControl1.Name = "bpPanelControl1";
            this.bpPanelControl1.Size = new System.Drawing.Size(272, 23);
            this.bpPanelControl1.TabIndex = 0;
            this.bpPanelControl1.Text = "bpPanelControl1";
            // 
            // CBO_YN_USE
            // 
            this.CBO_YN_USE.AutoDropDown = false;
            this.CBO_YN_USE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.CBO_YN_USE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBO_YN_USE.ItemHeight = 18;
            this.CBO_YN_USE.Location = new System.Drawing.Point(69, 1);
            this.CBO_YN_USE.Name = "CBO_YN_USE";
            this.CBO_YN_USE.Size = new System.Drawing.Size(180, 26);
            this.CBO_YN_USE.TabIndex = 5;
            this.CBO_YN_USE.UseKeyF3 = false;
            // 
            // P_FI_Z_THEBORN_DEPOSIT_RPT
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Name = "P_FI_Z_THEBORN_DEPOSIT_RPT";
            this.Size = new System.Drawing.Size(1090, 796);
            this.TitleText = "VMI재고현황";
            this.mDataArea.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._flex)).EndInit();
            this.oneGridItem1.ResumeLayout(false);
            this.bpPanelControl3.ResumeLayout(false);
            this.bpPanelControl2.ResumeLayout(false);
            this.bpPanelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Duzon.Common.Controls.LabelExt labelExt5;
        private Duzon.Erpiu.Windows.OneControls.OneGrid oneGrid1;
        private Duzon.Erpiu.Windows.OneControls.OneGridItem oneGridItem1;
        private Duzon.Common.BpControls.BpPanelControl bpPanelControl3;
        private Duzon.Common.BpControls.BpPanelControl bpPanelControl2;
        private Duzon.Common.BpControls.BpPanelControl bpPanelControl1;
        private Duzon.Common.Controls.LabelExt labelExt1;
        private Duzon.Common.Controls.LabelExt labelExt2;
        private Duzon.Common.BpControls.BpCodeTextBox BP_CD_PC;
        private Dass.FlexGrid.FlexGrid _flex;
        private Duzon.Common.BpControls.BpComboBox BP_NO_DEPOSIT;
        private Duzon.Common.Controls.DropDownComboBox CBO_YN_USE;

        //private Dass.FlexGrid.FlexGrid _flex2;
    }
}