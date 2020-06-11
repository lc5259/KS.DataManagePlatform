

namespace KS.DataManage.Client
{
    partial class UC_CstmrInfoMgt
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.kCombAccount = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.lblAccount = new System.Windows.Forms.Label();
            this.kbtnSearch = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kbtnDelete = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kbtnCopy = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kbtnUpdate = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kbtnInsert = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.pnlDgv = new System.Windows.Forms.Panel();
            this.kDGVAcc = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ItmAddTCode = new System.Windows.Forms.ToolStripMenuItem();
            this.ItmDelTCode = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kCombAccount)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnlDgv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kDGVAcc)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.pnlDgv, 0, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(918, 580);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tableLayoutPanel.SetColumnSpan(this.panel2, 2);
            this.panel2.Controls.Add(this.kCombAccount);
            this.panel2.Controls.Add(this.lblAccount);
            this.panel2.Controls.Add(this.kbtnSearch);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(918, 55);
            this.panel2.TabIndex = 2;
            // 
            // kCombAccount
            // 
            this.kCombAccount.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.kCombAccount.DropDownWidth = 121;
            this.kCombAccount.Location = new System.Drawing.Point(94, 16);
            this.kCombAccount.Name = "kCombAccount";
            this.kCombAccount.Size = new System.Drawing.Size(121, 21);
            this.kCombAccount.TabIndex = 2;
            this.kCombAccount.Text = "kryptonComboBox1";
            // 
            // lblAccount
            // 
            this.lblAccount.AutoSize = true;
            this.lblAccount.Location = new System.Drawing.Point(30, 21);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(59, 12);
            this.lblAccount.TabIndex = 1;
            this.lblAccount.Text = "资金账号:";
            // 
            // kbtnSearch
            // 
            this.kbtnSearch.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.kbtnSearch.Location = new System.Drawing.Point(231, 9);
            this.kbtnSearch.Name = "kbtnSearch";
            this.kbtnSearch.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(192)))), ((int)(((byte)(222)))));
            this.kbtnSearch.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(192)))), ((int)(((byte)(222)))));
            this.kbtnSearch.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("FontAwesome", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnSearch.Size = new System.Drawing.Size(80, 40);
            this.kbtnSearch.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(192)))), ((int)(((byte)(222)))));
            this.kbtnSearch.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(192)))), ((int)(((byte)(222)))));
            this.kbtnSearch.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.kbtnSearch.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.kbtnSearch.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kbtnSearch.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.kbtnSearch.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.kbtnSearch.StateCommon.Content.ShortText.Font = new System.Drawing.Font("FontAwesome", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnSearch.StateDisabled.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(192)))), ((int)(((byte)(222)))));
            this.kbtnSearch.StateDisabled.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(192)))), ((int)(((byte)(222)))));
            this.kbtnSearch.StateNormal.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(192)))), ((int)(((byte)(222)))));
            this.kbtnSearch.StateNormal.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.kbtnSearch.StateNormal.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.kbtnSearch.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kbtnSearch.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.kbtnSearch.StateNormal.Content.ShortText.Font = new System.Drawing.Font("FontAwesome", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnSearch.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.kbtnSearch.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.kbtnSearch.StatePressed.Border.Color1 = System.Drawing.Color.Black;
            this.kbtnSearch.StatePressed.Border.Color2 = System.Drawing.Color.Black;
            this.kbtnSearch.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kbtnSearch.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.kbtnSearch.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.Black;
            this.kbtnSearch.StatePressed.Content.ShortText.Font = new System.Drawing.Font("FontAwesome", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnSearch.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(184)))), ((int)(((byte)(218)))));
            this.kbtnSearch.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(184)))), ((int)(((byte)(218)))));
            this.kbtnSearch.StateTracking.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Dashed;
            this.kbtnSearch.StateTracking.Back.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.True;
            this.kbtnSearch.StateTracking.Back.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.None;
            this.kbtnSearch.StateTracking.Border.Color1 = System.Drawing.Color.Silver;
            this.kbtnSearch.StateTracking.Border.Color2 = System.Drawing.Color.Silver;
            this.kbtnSearch.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kbtnSearch.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.kbtnSearch.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.kbtnSearch.StateTracking.Content.ShortText.Font = new System.Drawing.Font("FontAwesome", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnSearch.TabIndex = 0;
            this.kbtnSearch.Values.Text = " 查询";
            this.kbtnSearch.Click += new System.EventHandler(this.kbtnSearch_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.kbtnDelete);
            this.panel1.Controls.Add(this.kbtnCopy);
            this.panel1.Controls.Add(this.kbtnUpdate);
            this.panel1.Controls.Add(this.kbtnInsert);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 525);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(918, 55);
            this.panel1.TabIndex = 1;
            // 
            // kbtnDelete
            // 
            this.kbtnDelete.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.kbtnDelete.Location = new System.Drawing.Point(334, 8);
            this.kbtnDelete.Name = "kbtnDelete";
            this.kbtnDelete.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(83)))), ((int)(((byte)(79)))));
            this.kbtnDelete.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(83)))), ((int)(((byte)(79)))));
            this.kbtnDelete.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("FontAwesome", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnDelete.Size = new System.Drawing.Size(80, 40);
            this.kbtnDelete.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(83)))), ((int)(((byte)(79)))));
            this.kbtnDelete.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(83)))), ((int)(((byte)(79)))));
            this.kbtnDelete.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.kbtnDelete.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.kbtnDelete.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kbtnDelete.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.kbtnDelete.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.kbtnDelete.StateCommon.Content.ShortText.Font = new System.Drawing.Font("FontAwesome", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnDelete.StateDisabled.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(83)))), ((int)(((byte)(79)))));
            this.kbtnDelete.StateDisabled.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(83)))), ((int)(((byte)(79)))));
            this.kbtnDelete.StateNormal.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(83)))), ((int)(((byte)(79)))));
            this.kbtnDelete.StateNormal.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.kbtnDelete.StateNormal.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.kbtnDelete.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kbtnDelete.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.kbtnDelete.StateNormal.Content.ShortText.Font = new System.Drawing.Font("FontAwesome", 12F, System.Drawing.FontStyle.Bold);
            this.kbtnDelete.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.kbtnDelete.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.kbtnDelete.StatePressed.Border.Color1 = System.Drawing.Color.Black;
            this.kbtnDelete.StatePressed.Border.Color2 = System.Drawing.Color.Black;
            this.kbtnDelete.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kbtnDelete.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.kbtnDelete.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.Black;
            this.kbtnDelete.StatePressed.Content.ShortText.Font = new System.Drawing.Font("FontAwesome", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnDelete.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(63)))), ((int)(((byte)(58)))));
            this.kbtnDelete.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(63)))), ((int)(((byte)(58)))));
            this.kbtnDelete.StateTracking.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Dashed;
            this.kbtnDelete.StateTracking.Back.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.True;
            this.kbtnDelete.StateTracking.Back.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.None;
            this.kbtnDelete.StateTracking.Border.Color1 = System.Drawing.Color.Silver;
            this.kbtnDelete.StateTracking.Border.Color2 = System.Drawing.Color.Silver;
            this.kbtnDelete.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kbtnDelete.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.kbtnDelete.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.kbtnDelete.StateTracking.Content.ShortText.Font = new System.Drawing.Font("FontAwesome", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnDelete.TabIndex = 5;
            this.kbtnDelete.Values.Text = " 删除";
            this.kbtnDelete.Click += new System.EventHandler(this.kbtnDelete_Click);
            // 
            // kbtnCopy
            // 
            this.kbtnCopy.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.kbtnCopy.Location = new System.Drawing.Point(230, 8);
            this.kbtnCopy.Name = "kbtnCopy";
            this.kbtnCopy.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(184)))), ((int)(((byte)(92)))));
            this.kbtnCopy.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(184)))), ((int)(((byte)(92)))));
            this.kbtnCopy.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("FontAwesome", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnCopy.Size = new System.Drawing.Size(80, 40);
            this.kbtnCopy.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(184)))), ((int)(((byte)(92)))));
            this.kbtnCopy.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(184)))), ((int)(((byte)(92)))));
            this.kbtnCopy.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.kbtnCopy.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.kbtnCopy.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kbtnCopy.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.kbtnCopy.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.kbtnCopy.StateCommon.Content.ShortText.Font = new System.Drawing.Font("FontAwesome", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnCopy.StateDisabled.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(184)))), ((int)(((byte)(92)))));
            this.kbtnCopy.StateDisabled.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(184)))), ((int)(((byte)(92)))));
            this.kbtnCopy.StateNormal.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(184)))), ((int)(((byte)(92)))));
            this.kbtnCopy.StateNormal.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.kbtnCopy.StateNormal.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.kbtnCopy.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kbtnCopy.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.kbtnCopy.StateNormal.Content.ShortText.Font = new System.Drawing.Font("FontAwesome", 12F, System.Drawing.FontStyle.Bold);
            this.kbtnCopy.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.kbtnCopy.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.kbtnCopy.StatePressed.Border.Color1 = System.Drawing.Color.Black;
            this.kbtnCopy.StatePressed.Border.Color2 = System.Drawing.Color.Black;
            this.kbtnCopy.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kbtnCopy.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.kbtnCopy.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.Black;
            this.kbtnCopy.StatePressed.Content.ShortText.Font = new System.Drawing.Font("FontAwesome", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnCopy.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(174)))), ((int)(((byte)(76)))));
            this.kbtnCopy.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(174)))), ((int)(((byte)(76)))));
            this.kbtnCopy.StateTracking.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Dashed;
            this.kbtnCopy.StateTracking.Back.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.True;
            this.kbtnCopy.StateTracking.Back.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.None;
            this.kbtnCopy.StateTracking.Border.Color1 = System.Drawing.Color.Silver;
            this.kbtnCopy.StateTracking.Border.Color2 = System.Drawing.Color.Silver;
            this.kbtnCopy.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kbtnCopy.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.kbtnCopy.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.kbtnCopy.StateTracking.Content.ShortText.Font = new System.Drawing.Font("FontAwesome", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnCopy.TabIndex = 3;
            this.kbtnCopy.Values.Text = " 复制";
            this.kbtnCopy.Click += new System.EventHandler(this.kbtnCopy_Click);
            // 
            // kbtnUpdate
            // 
            this.kbtnUpdate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.kbtnUpdate.Location = new System.Drawing.Point(126, 8);
            this.kbtnUpdate.Name = "kbtnUpdate";
            this.kbtnUpdate.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(173)))), ((int)(((byte)(78)))));
            this.kbtnUpdate.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(173)))), ((int)(((byte)(78)))));
            this.kbtnUpdate.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("FontAwesome", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnUpdate.Size = new System.Drawing.Size(80, 40);
            this.kbtnUpdate.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(173)))), ((int)(((byte)(78)))));
            this.kbtnUpdate.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(173)))), ((int)(((byte)(78)))));
            this.kbtnUpdate.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.kbtnUpdate.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.kbtnUpdate.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kbtnUpdate.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.kbtnUpdate.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.kbtnUpdate.StateCommon.Content.ShortText.Font = new System.Drawing.Font("FontAwesome", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnUpdate.StateDisabled.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(173)))), ((int)(((byte)(78)))));
            this.kbtnUpdate.StateDisabled.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(173)))), ((int)(((byte)(78)))));
            this.kbtnUpdate.StateNormal.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(173)))), ((int)(((byte)(78)))));
            this.kbtnUpdate.StateNormal.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.kbtnUpdate.StateNormal.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.kbtnUpdate.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kbtnUpdate.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.kbtnUpdate.StateNormal.Content.ShortText.Font = new System.Drawing.Font("FontAwesome", 12F, System.Drawing.FontStyle.Bold);
            this.kbtnUpdate.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.kbtnUpdate.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.kbtnUpdate.StatePressed.Border.Color1 = System.Drawing.Color.Black;
            this.kbtnUpdate.StatePressed.Border.Color2 = System.Drawing.Color.Black;
            this.kbtnUpdate.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kbtnUpdate.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.kbtnUpdate.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.Black;
            this.kbtnUpdate.StatePressed.Content.ShortText.Font = new System.Drawing.Font("FontAwesome", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnUpdate.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(162)))), ((int)(((byte)(54)))));
            this.kbtnUpdate.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(162)))), ((int)(((byte)(54)))));
            this.kbtnUpdate.StateTracking.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Dashed;
            this.kbtnUpdate.StateTracking.Back.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.True;
            this.kbtnUpdate.StateTracking.Back.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.None;
            this.kbtnUpdate.StateTracking.Border.Color1 = System.Drawing.Color.Silver;
            this.kbtnUpdate.StateTracking.Border.Color2 = System.Drawing.Color.Silver;
            this.kbtnUpdate.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kbtnUpdate.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.kbtnUpdate.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.kbtnUpdate.StateTracking.Content.ShortText.Font = new System.Drawing.Font("FontAwesome", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnUpdate.TabIndex = 2;
            this.kbtnUpdate.Values.Text = " 修改";
            this.kbtnUpdate.Click += new System.EventHandler(this.kbtnUpdate_Click);
            // 
            // kbtnInsert
            // 
            this.kbtnInsert.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.kbtnInsert.Location = new System.Drawing.Point(22, 8);
            this.kbtnInsert.Name = "kbtnInsert";
            this.kbtnInsert.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(139)))), ((int)(((byte)(202)))));
            this.kbtnInsert.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(139)))), ((int)(((byte)(202)))));
            this.kbtnInsert.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("FontAwesome", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnInsert.Size = new System.Drawing.Size(80, 40);
            this.kbtnInsert.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(139)))), ((int)(((byte)(202)))));
            this.kbtnInsert.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(139)))), ((int)(((byte)(202)))));
            this.kbtnInsert.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.kbtnInsert.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.kbtnInsert.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kbtnInsert.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.kbtnInsert.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.kbtnInsert.StateCommon.Content.ShortText.Font = new System.Drawing.Font("FontAwesome", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnInsert.StateDisabled.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(139)))), ((int)(((byte)(202)))));
            this.kbtnInsert.StateDisabled.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(139)))), ((int)(((byte)(202)))));
            this.kbtnInsert.StateNormal.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(139)))), ((int)(((byte)(202)))));
            this.kbtnInsert.StateNormal.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.kbtnInsert.StateNormal.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.kbtnInsert.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kbtnInsert.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.kbtnInsert.StateNormal.Content.ShortText.Font = new System.Drawing.Font("FontAwesome", 12F, System.Drawing.FontStyle.Bold);
            this.kbtnInsert.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.kbtnInsert.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.kbtnInsert.StatePressed.Border.Color1 = System.Drawing.Color.Black;
            this.kbtnInsert.StatePressed.Border.Color2 = System.Drawing.Color.Black;
            this.kbtnInsert.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kbtnInsert.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.kbtnInsert.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.Black;
            this.kbtnInsert.StatePressed.Content.ShortText.Font = new System.Drawing.Font("FontAwesome", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnInsert.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(126)))), ((int)(((byte)(189)))));
            this.kbtnInsert.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(126)))), ((int)(((byte)(189)))));
            this.kbtnInsert.StateTracking.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Dashed;
            this.kbtnInsert.StateTracking.Back.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.True;
            this.kbtnInsert.StateTracking.Back.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.None;
            this.kbtnInsert.StateTracking.Border.Color1 = System.Drawing.Color.Silver;
            this.kbtnInsert.StateTracking.Border.Color2 = System.Drawing.Color.Silver;
            this.kbtnInsert.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kbtnInsert.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.kbtnInsert.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.kbtnInsert.StateTracking.Content.ShortText.Font = new System.Drawing.Font("FontAwesome", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnInsert.TabIndex = 1;
            this.kbtnInsert.Values.Text = " 新增";
            this.kbtnInsert.Click += new System.EventHandler(this.kbtnInsert_Click);
            // 
            // pnlDgv
            // 
            this.tableLayoutPanel.SetColumnSpan(this.pnlDgv, 2);
            this.pnlDgv.Controls.Add(this.kDGVAcc);
            this.pnlDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDgv.Location = new System.Drawing.Point(3, 58);
            this.pnlDgv.Name = "pnlDgv";
            this.pnlDgv.Size = new System.Drawing.Size(912, 464);
            this.pnlDgv.TabIndex = 3;
            // 
            // kDGVAcc
            // 
            this.kDGVAcc.AllowUserToAddRows = false;
            this.kDGVAcc.AllowUserToOrderColumns = true;
            this.kDGVAcc.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.kDGVAcc.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.kDGVAcc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.kDGVAcc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kDGVAcc.Location = new System.Drawing.Point(0, 0);
            this.kDGVAcc.Margin = new System.Windows.Forms.Padding(0);
            this.kDGVAcc.MultiSelect = false;
            this.kDGVAcc.Name = "kDGVAcc";
            this.kDGVAcc.ReadOnly = true;
            this.kDGVAcc.RowTemplate.Height = 23;
            this.kDGVAcc.Size = new System.Drawing.Size(912, 464);
            this.kDGVAcc.TabIndex = 0;
            this.kDGVAcc.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.kDGVAcc_CellEnter);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ItmAddTCode,
            this.ItmDelTCode});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(147, 48);
            // 
            // ItmAddTCode
            // 
            this.ItmAddTCode.Name = "ItmAddTCode";
            this.ItmAddTCode.Size = new System.Drawing.Size(146, 22);
            this.ItmAddTCode.Text = "新增交易编码";
            this.ItmAddTCode.Click += new System.EventHandler(this.ItmAddTCode_Click);
            // 
            // ItmDelTCode
            // 
            this.ItmDelTCode.Name = "ItmDelTCode";
            this.ItmDelTCode.Size = new System.Drawing.Size(146, 22);
            this.ItmDelTCode.Text = "删除交易编码";
            this.ItmDelTCode.Click += new System.EventHandler(this.ItmDelTCode_Click);
            // 
            // UC_CstmrInfoMgt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "UC_CstmrInfoMgt";
            this.Size = new System.Drawing.Size(918, 580);
            this.Load += new System.EventHandler(this.UC_CstmrInfoMgt_Load);
            this.tableLayoutPanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kCombAccount)).EndInit();
            this.panel1.ResumeLayout(false);
            this.pnlDgv.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kDGVAcc)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        protected System.Windows.Forms.Panel panel2;
        protected System.Windows.Forms.Panel panel1;
        protected ComponentFactory.Krypton.Toolkit.KryptonButton kbtnDelete;
        protected ComponentFactory.Krypton.Toolkit.KryptonButton kbtnCopy;
        protected ComponentFactory.Krypton.Toolkit.KryptonButton kbtnUpdate;
        protected ComponentFactory.Krypton.Toolkit.KryptonButton kbtnInsert;
        public ComponentFactory.Krypton.Toolkit.KryptonButton kbtnSearch;
        public ComponentFactory.Krypton.Toolkit.KryptonDataGridView kDGVAcc;
        public ComponentFactory.Krypton.Toolkit.KryptonComboBox kCombAccount;
        public System.Windows.Forms.Label lblAccount;
        public System.Windows.Forms.Panel pnlDgv;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ItmAddTCode;
        private System.Windows.Forms.ToolStripMenuItem ItmDelTCode;
    }
}
