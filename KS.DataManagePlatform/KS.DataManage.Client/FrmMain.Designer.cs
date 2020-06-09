namespace KS.Zero.Client
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
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.kbtnMin = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kbtnClose = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kbtnMax = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.label1 = new System.Windows.Forms.Label();
            this.pBLogo = new System.Windows.Forms.PictureBox();
            this.kryptonButton1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kDWorkspaceContent)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.pnlTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonDockingManager
            // 
            this.kryptonDockingManager.DefaultCloseRequest = ComponentFactory.Krypton.Docking.DockingCloseRequest.RemovePageAndDispose;
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
            this.kDWorkspaceContent.Size = new System.Drawing.Size(1012, 658);
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
            this.panel1.Size = new System.Drawing.Size(1012, 658);
            this.panel1.TabIndex = 1;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.pnlTitle, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(1018, 694);
            this.tableLayoutPanel.TabIndex = 13;
            // 
            // pnlTitle
            // 
            this.pnlTitle.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnlTitle.Controls.Add(this.kryptonButton1);
            this.pnlTitle.Controls.Add(this.button1);
            this.pnlTitle.Controls.Add(this.kbtnMin);
            this.pnlTitle.Controls.Add(this.kbtnClose);
            this.pnlTitle.Controls.Add(this.kbtnMax);
            this.pnlTitle.Controls.Add(this.label1);
            this.pnlTitle.Controls.Add(this.pBLogo);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Margin = new System.Windows.Forms.Padding(0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(1018, 30);
            this.pnlTitle.TabIndex = 4;
            this.pnlTitle.DoubleClick += new System.EventHandler(this.pnlTitle_DoubleClick);
            this.pnlTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlTitle_MouseMove);
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
            this.kbtnMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnMin.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.Form;
            this.kbtnMin.Location = new System.Drawing.Point(928, 0);
            this.kbtnMin.Margin = new System.Windows.Forms.Padding(0);
            this.kbtnMin.Name = "kbtnMin";
            this.kbtnMin.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.kbtnMin.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.kbtnMin.OverrideDefault.Border.DrawBorders = ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.None;
            this.kbtnMin.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.kbtnMin.Size = new System.Drawing.Size(30, 30);
            this.kbtnMin.StateNormal.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.kbtnMin.StateNormal.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.kbtnMin.StateNormal.Border.DrawBorders = ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.None;
            this.kbtnMin.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.kbtnMin.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.kbtnMin.StatePressed.Border.DrawBorders = ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.None;
            this.kbtnMin.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.kbtnMin.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.kbtnMin.StateTracking.Border.DrawBorders = ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.None;
            this.kbtnMin.TabIndex = 21;
            this.kbtnMin.Values.Image = global::KS.Zero.Client.Properties.Resources.min16X16;
            this.kbtnMin.Values.Text = "";
            this.kbtnMin.Click += new System.EventHandler(this.kbtnMin_Click);
            // 
            // kbtnClose
            // 
            this.kbtnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnClose.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.FormClose;
            this.kbtnClose.Location = new System.Drawing.Point(988, 0);
            this.kbtnClose.Margin = new System.Windows.Forms.Padding(0);
            this.kbtnClose.Name = "kbtnClose";
            this.kbtnClose.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.kbtnClose.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.kbtnClose.OverrideDefault.Border.DrawBorders = ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.None;
            this.kbtnClose.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.kbtnClose.Size = new System.Drawing.Size(30, 30);
            this.kbtnClose.StateNormal.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.kbtnClose.StateNormal.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.kbtnClose.StateNormal.Border.DrawBorders = ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.None;
            this.kbtnClose.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.kbtnClose.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.kbtnClose.StatePressed.Border.DrawBorders = ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.None;
            this.kbtnClose.StateTracking.Back.Color1 = System.Drawing.Color.Red;
            this.kbtnClose.StateTracking.Back.Color2 = System.Drawing.Color.Red;
            this.kbtnClose.StateTracking.Border.DrawBorders = ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.None;
            this.kbtnClose.TabIndex = 20;
            this.kbtnClose.Values.Image = global::KS.Zero.Client.Properties.Resources.close_16X16;
            this.kbtnClose.Values.Text = "";
            this.kbtnClose.Click += new System.EventHandler(this.kbtnClose_Click);
            // 
            // kbtnMax
            // 
            this.kbtnMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnMax.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.Form;
            this.kbtnMax.Location = new System.Drawing.Point(958, 0);
            this.kbtnMax.Margin = new System.Windows.Forms.Padding(0);
            this.kbtnMax.Name = "kbtnMax";
            this.kbtnMax.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.kbtnMax.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.kbtnMax.OverrideDefault.Border.DrawBorders = ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.None;
            this.kbtnMax.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.kbtnMax.Size = new System.Drawing.Size(30, 30);
            this.kbtnMax.StateNormal.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.kbtnMax.StateNormal.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.kbtnMax.StateNormal.Border.DrawBorders = ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.None;
            this.kbtnMax.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.kbtnMax.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.kbtnMax.StatePressed.Border.DrawBorders = ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.None;
            this.kbtnMax.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.kbtnMax.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.kbtnMax.StateTracking.Border.DrawBorders = ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.None;
            this.kbtnMax.TabIndex = 19;
            this.kbtnMax.Values.Image = global::KS.Zero.Client.Properties.Resources.screenexpand16px;
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
            this.label1.Size = new System.Drawing.Size(251, 19);
            this.label1.TabIndex = 18;
            this.label1.Text = "金仕达极速交易系统(Zero) 管理客户端";
            this.label1.DoubleClick += new System.EventHandler(this.pnlTitle_DoubleClick);
            // 
            // pBLogo
            // 
            this.pBLogo.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pBLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pBLogo.Image = global::KS.Zero.Client.Properties.Resources.main;
            this.pBLogo.Location = new System.Drawing.Point(0, 0);
            this.pBLogo.Margin = new System.Windows.Forms.Padding(0);
            this.pBLogo.Name = "pBLogo";
            this.pBLogo.Size = new System.Drawing.Size(30, 30);
            this.pBLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBLogo.TabIndex = 13;
            this.pBLogo.TabStop = false;
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.Location = new System.Drawing.Point(514, -10);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(162, 49);
            this.kryptonButton1.TabIndex = 23;
            this.kryptonButton1.Values.Text = "kryptonButton1";
            this.kryptonButton1.Click += new System.EventHandler(this.kryptonButton1_Click);
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
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
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
    }
}

