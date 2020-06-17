namespace KS.DataManage.Client
{
    partial class FrmMain
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.kryptonDockingManager = new ComponentFactory.Krypton.Docking.KryptonDockingManager();
            this.kryptonManager = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            this.kDWorkspaceContent = new ComponentFactory.Krypton.Docking.KryptonDockableWorkspace();
            this.panel1 = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.SystemTSMItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SetTSMItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.InputTSMItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OutputTSMItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AccountTSMItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddTSMItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteTSMItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LotsTSMItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GeneTSMItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutTSMItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UsTSMItem = new System.Windows.Forms.ToolStripMenuItem();
            this.VersionTSMItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kryptonButton1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.button1 = new System.Windows.Forms.Button();
            this.kbtnMin = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kbtnMax = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.label1 = new System.Windows.Forms.Label();
            this.pBLogo = new System.Windows.Forms.PictureBox();
            this.kbtnClose = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonContextMenuItems1 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems();
            this.kryptonContextMenuItem1 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.kDWorkspaceContent)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.pnlTitle.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonDockingManager
            // 
            this.kryptonDockingManager.DefaultCloseRequest = ComponentFactory.Krypton.Docking.DockingCloseRequest.RemovePageAndDispose;
            this.kryptonDockingManager.Strings.TextAutoHide = "自动隐藏";
            this.kryptonDockingManager.Strings.TextClose = "关闭";
            this.kryptonDockingManager.Strings.TextCloseAllButThis = "除此之外全部关闭";
            this.kryptonDockingManager.Strings.TextDock = "停靠";
            this.kryptonDockingManager.Strings.TextFloat = "浮动";
            this.kryptonDockingManager.Strings.TextHide = "隐藏";
            this.kryptonDockingManager.PageCloseRequest += new System.EventHandler<ComponentFactory.Krypton.Docking.CloseRequestEventArgs>(this.kryptonDockingManager_PageCloseRequest);
            this.kryptonDockingManager.DockspaceAdding += new System.EventHandler<ComponentFactory.Krypton.Docking.DockspaceEventArgs>(this.kryptonDockingManager_DockspaceAdding);
            this.kryptonDockingManager.FloatingWindowAdding += new System.EventHandler<ComponentFactory.Krypton.Docking.FloatingWindowEventArgs>(this.kryptonDockingManager_FloatingWindowAdding);
            this.kryptonDockingManager.FloatingWindowRemoved += new System.EventHandler<ComponentFactory.Krypton.Docking.FloatingWindowEventArgs>(this.kryptonDockingManager_FloatingWindowRemoved);
            // 
            // kryptonManager
            // 
            this.kryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2010Silver;
            // 
            // kDWorkspaceContent
            // 
            this.kDWorkspaceContent.AutoHiddenHost = false;
            this.kDWorkspaceContent.CompactFlags = ((ComponentFactory.Krypton.Workspace.CompactFlags)(((ComponentFactory.Krypton.Workspace.CompactFlags.RemoveEmptyCells | ComponentFactory.Krypton.Workspace.CompactFlags.RemoveEmptySequences) 
            | ComponentFactory.Krypton.Workspace.CompactFlags.PromoteLeafs)));
            this.kDWorkspaceContent.ContextMenus.TextClose = "&关闭";
            this.kDWorkspaceContent.ContextMenus.TextMaximize = "&最大化";
            this.kDWorkspaceContent.ContextMenus.TextMoveNext = "下一个";
            this.kDWorkspaceContent.ContextMenus.TextMovePrevious = "前一个";
            this.kDWorkspaceContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kDWorkspaceContent.Location = new System.Drawing.Point(0, 0);
            this.kDWorkspaceContent.Name = "kDWorkspaceContent";
            // 
            // 
            // 
            this.kDWorkspaceContent.Root.UniqueName = "149485AFCDEC4E1D53AA746D904E8476";
            this.kDWorkspaceContent.Root.WorkspaceControl = this.kDWorkspaceContent;
            this.kDWorkspaceContent.SeparatorStyle = ComponentFactory.Krypton.Toolkit.SeparatorStyle.HighProfile;
            this.kDWorkspaceContent.ShowMaximizeButton = false;
            this.kDWorkspaceContent.Size = new System.Drawing.Size(1012, 638);
            this.kDWorkspaceContent.TabIndex = 0;
            this.kDWorkspaceContent.TabStop = true;
            this.kDWorkspaceContent.PageCloseClicked += new System.EventHandler<ComponentFactory.Krypton.Docking.UniqueNameEventArgs>(this.kDWorkspaceContent_PageCloseClicked);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.kDWorkspaceContent);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1012, 638);
            this.panel1.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusStrip1.Location = new System.Drawing.Point(0, 674);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1018, 20);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.pnlTitle, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.statusStrip1, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(1018, 694);
            this.tableLayoutPanel.TabIndex = 13;
            // 
            // pnlTitle
            // 
            this.pnlTitle.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlTitle.Controls.Add(this.pnlMenu);
            this.pnlTitle.Controls.Add(this.kryptonButton1);
            this.pnlTitle.Controls.Add(this.button1);
            this.pnlTitle.Controls.Add(this.kbtnMin);
            this.pnlTitle.Controls.Add(this.kbtnMax);
            this.pnlTitle.Controls.Add(this.label1);
            this.pnlTitle.Controls.Add(this.pBLogo);
            this.pnlTitle.Controls.Add(this.kbtnClose);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Margin = new System.Windows.Forms.Padding(0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(1018, 30);
            this.pnlTitle.TabIndex = 4;
            this.pnlTitle.DoubleClick += new System.EventHandler(this.pnlTitle_DoubleClick);
            this.pnlTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlTitle_MouseMove);
            // 
            // pnlMenu
            // 
            this.pnlMenu.Controls.Add(this.menuStrip);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlMenu.Location = new System.Drawing.Point(593, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(335, 30);
            this.pnlMenu.TabIndex = 24;
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SystemTSMItem,
            this.AccountTSMItem,
            this.LotsTSMItem,
            this.AboutTSMItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(335, 30);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // SystemTSMItem
            // 
            this.SystemTSMItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SetTSMItem,
            this.toolStripSeparator1,
            this.InputTSMItem,
            this.OutputTSMItem});
            this.SystemTSMItem.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.SystemTSMItem.Name = "SystemTSMItem";
            this.SystemTSMItem.Size = new System.Drawing.Size(59, 26);
            this.SystemTSMItem.Text = "系统(&F)";
            // 
            // SetTSMItem
            // 
            this.SetTSMItem.Name = "SetTSMItem";
            this.SetTSMItem.Size = new System.Drawing.Size(152, 22);
            this.SetTSMItem.Text = "参数设置";
            this.SetTSMItem.Click += new System.EventHandler(this.SetTSMItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // InputTSMItem
            // 
            this.InputTSMItem.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.InputTSMItem.Name = "InputTSMItem";
            this.InputTSMItem.Size = new System.Drawing.Size(152, 22);
            this.InputTSMItem.Text = "账号配置导出";
            // 
            // OutputTSMItem
            // 
            this.OutputTSMItem.Name = "OutputTSMItem";
            this.OutputTSMItem.Size = new System.Drawing.Size(152, 22);
            this.OutputTSMItem.Text = "账号配置导出";
            // 
            // AccountTSMItem
            // 
            this.AccountTSMItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddTSMItem,
            this.DeleteTSMItem});
            this.AccountTSMItem.ForeColor = System.Drawing.SystemColors.Highlight;
            this.AccountTSMItem.Name = "AccountTSMItem";
            this.AccountTSMItem.Size = new System.Drawing.Size(97, 26);
            this.AccountTSMItem.Text = "账户分组配置";
            // 
            // AddTSMItem
            // 
            this.AddTSMItem.Name = "AddTSMItem";
            this.AddTSMItem.Size = new System.Drawing.Size(180, 22);
            this.AddTSMItem.Text = "增加分组";
            this.AddTSMItem.Click += new System.EventHandler(this.AddTSMItem_Click);
            // 
            // DeleteTSMItem
            // 
            this.DeleteTSMItem.Name = "DeleteTSMItem";
            this.DeleteTSMItem.Size = new System.Drawing.Size(180, 22);
            this.DeleteTSMItem.Text = "删除分组";
            this.DeleteTSMItem.Click += new System.EventHandler(this.DeleteTSMItem_Click);
            // 
            // LotsTSMItem
            // 
            this.LotsTSMItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GeneTSMItem});
            this.LotsTSMItem.Name = "LotsTSMItem";
            this.LotsTSMItem.Size = new System.Drawing.Size(97, 26);
            this.LotsTSMItem.Text = "批量文件生成";
            // 
            // GeneTSMItem
            // 
            this.GeneTSMItem.Name = "GeneTSMItem";
            this.GeneTSMItem.Size = new System.Drawing.Size(180, 22);
            this.GeneTSMItem.Text = "一键生成";
            this.GeneTSMItem.Click += new System.EventHandler(this.GeneTSMItem_Click);
            // 
            // AboutTSMItem
            // 
            this.AboutTSMItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UsTSMItem,
            this.VersionTSMItem});
            this.AboutTSMItem.Name = "AboutTSMItem";
            this.AboutTSMItem.Size = new System.Drawing.Size(45, 26);
            this.AboutTSMItem.Text = "关于";
            // 
            // UsTSMItem
            // 
            this.UsTSMItem.Name = "UsTSMItem";
            this.UsTSMItem.Size = new System.Drawing.Size(126, 22);
            this.UsTSMItem.Text = "关于我们";
            // 
            // VersionTSMItem
            // 
            this.VersionTSMItem.Name = "VersionTSMItem";
            this.VersionTSMItem.Size = new System.Drawing.Size(126, 22);
            this.VersionTSMItem.Text = "版本信息";
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.Location = new System.Drawing.Point(448, -9);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(103, 49);
            this.kryptonButton1.TabIndex = 23;
            this.kryptonButton1.Values.Text = "kryptonButton1";
            this.kryptonButton1.Click += new System.EventHandler(this.kryptonButton1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(383, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(59, 30);
            this.button1.TabIndex = 22;
            this.button1.Text = "test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // kbtnMin
            // 
            this.kbtnMin.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.Form;
            this.kbtnMin.Dock = System.Windows.Forms.DockStyle.Right;
            this.kbtnMin.Location = new System.Drawing.Point(928, 0);
            this.kbtnMin.Margin = new System.Windows.Forms.Padding(0);
            this.kbtnMin.Name = "kbtnMin";
            this.kbtnMin.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.kbtnMin.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.kbtnMin.OverrideDefault.Border.DrawBorders = ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.None;
            this.kbtnMin.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.kbtnMin.Size = new System.Drawing.Size(30, 30);
            this.kbtnMin.StateNormal.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.kbtnMin.StateNormal.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.kbtnMin.StateNormal.Border.DrawBorders = ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.None;
            this.kbtnMin.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.kbtnMin.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.kbtnMin.StatePressed.Border.DrawBorders = ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.None;
            this.kbtnMin.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.kbtnMin.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.kbtnMin.StateTracking.Border.DrawBorders = ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.None;
            this.kbtnMin.TabIndex = 21;
            this.kbtnMin.Values.Image = global::KS.DataManage.Client.Properties.Resources.min16X16;
            this.kbtnMin.Values.Text = "";
            this.kbtnMin.Click += new System.EventHandler(this.kbtnMin_Click);
            // 
            // kbtnMax
            // 
            this.kbtnMax.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.Form;
            this.kbtnMax.Dock = System.Windows.Forms.DockStyle.Right;
            this.kbtnMax.Location = new System.Drawing.Point(958, 0);
            this.kbtnMax.Margin = new System.Windows.Forms.Padding(0);
            this.kbtnMax.Name = "kbtnMax";
            this.kbtnMax.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.kbtnMax.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.kbtnMax.OverrideDefault.Border.DrawBorders = ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.None;
            this.kbtnMax.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.kbtnMax.Size = new System.Drawing.Size(30, 30);
            this.kbtnMax.StateNormal.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.kbtnMax.StateNormal.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.kbtnMax.StateNormal.Border.DrawBorders = ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.None;
            this.kbtnMax.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.kbtnMax.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.kbtnMax.StatePressed.Border.DrawBorders = ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.None;
            this.kbtnMax.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.kbtnMax.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.kbtnMax.StateTracking.Border.DrawBorders = ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.None;
            this.kbtnMax.TabIndex = 19;
            this.kbtnMax.Values.Image = global::KS.DataManage.Client.Properties.Resources.screenexpand16px;
            this.kbtnMax.Values.Text = "";
            this.kbtnMax.Click += new System.EventHandler(this.kbtnMax_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(32, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 19);
            this.label1.TabIndex = 18;
            this.label1.Text = "金仕达  特法数据处理平台";
            this.label1.DoubleClick += new System.EventHandler(this.pnlTitle_DoubleClick);
            // 
            // pBLogo
            // 
            this.pBLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.pBLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pBLogo.Image = global::KS.DataManage.Client.Properties.Resources.main;
            this.pBLogo.Location = new System.Drawing.Point(0, 0);
            this.pBLogo.Margin = new System.Windows.Forms.Padding(0);
            this.pBLogo.Name = "pBLogo";
            this.pBLogo.Size = new System.Drawing.Size(30, 30);
            this.pBLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBLogo.TabIndex = 13;
            this.pBLogo.TabStop = false;
            // 
            // kbtnClose
            // 
            this.kbtnClose.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.FormClose;
            this.kbtnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.kbtnClose.Location = new System.Drawing.Point(988, 0);
            this.kbtnClose.Margin = new System.Windows.Forms.Padding(0);
            this.kbtnClose.Name = "kbtnClose";
            this.kbtnClose.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.kbtnClose.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.kbtnClose.OverrideDefault.Border.DrawBorders = ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.None;
            this.kbtnClose.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.kbtnClose.Size = new System.Drawing.Size(30, 30);
            this.kbtnClose.StateNormal.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.kbtnClose.StateNormal.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.kbtnClose.StateNormal.Border.DrawBorders = ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.None;
            this.kbtnClose.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.kbtnClose.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.kbtnClose.StatePressed.Border.DrawBorders = ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.None;
            this.kbtnClose.StateTracking.Back.Color1 = System.Drawing.Color.Red;
            this.kbtnClose.StateTracking.Back.Color2 = System.Drawing.Color.Red;
            this.kbtnClose.StateTracking.Border.DrawBorders = ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.None;
            this.kbtnClose.TabIndex = 20;
            this.kbtnClose.Values.Image = global::KS.DataManage.Client.Properties.Resources.close_16X16;
            this.kbtnClose.Values.Text = "";
            this.kbtnClose.Click += new System.EventHandler(this.kbtnClose_Click);
            // 
            // kryptonContextMenuItems1
            // 
            this.kryptonContextMenuItems1.Items.AddRange(new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItemBase[] {
            this.kryptonContextMenuItem1});
            // 
            // kryptonContextMenuItem1
            // 
            this.kryptonContextMenuItem1.Text = "Menu Item";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1024, 700);
            this.Controls.Add(this.tableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(1024, 680);
            this.Name = "FrmMain";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "极速系统-管理客户端";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResizeEnd += new System.EventHandler(this.FrmMainForm_ResizeEnd);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmMainForm_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.kDWorkspaceContent)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Docking.KryptonDockingManager kryptonDockingManager;
        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager;
        private ComponentFactory.Krypton.Docking.KryptonDockableWorkspace kDWorkspaceContent;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pBLogo;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kbtnMax;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kbtnClose;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kbtnMin;
        private System.Windows.Forms.Button button1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton1;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems kryptonContextMenuItems1;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem kryptonContextMenuItem1;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem SystemTSMItem;
        private System.Windows.Forms.ToolStripMenuItem AccountTSMItem;
        private System.Windows.Forms.ToolStripMenuItem LotsTSMItem;
        private System.Windows.Forms.ToolStripMenuItem AboutTSMItem;
        private System.Windows.Forms.ToolStripMenuItem SetTSMItem;
        private System.Windows.Forms.ToolStripMenuItem InputTSMItem;
        private System.Windows.Forms.ToolStripMenuItem OutputTSMItem;
        private System.Windows.Forms.ToolStripMenuItem AddTSMItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteTSMItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem GeneTSMItem;
        private System.Windows.Forms.ToolStripMenuItem UsTSMItem;
        private System.Windows.Forms.ToolStripMenuItem VersionTSMItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
    }
}

