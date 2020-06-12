namespace KS.Zero.Controls
{
    partial class UCMenu
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("新增交易账户");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("新增管理用户");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("管理用户权限配置");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("交易账户管理", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("出入金管理");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("出入金管理", new System.Windows.Forms.TreeNode[] {
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("期货合约信息维护");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("金交所合约信息维护");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("合约管理", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8});
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("期货默认保证金率设置");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("期货客户保证金率设置");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("黄金默认保证金费率设置");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("黄金客户保证金率");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("保证金率设置", new System.Windows.Forms.TreeNode[] {
            treeNode10,
            treeNode11,
            treeNode12,
            treeNode13});
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("期货默认手续费率设置");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("期货客户手续费率设置");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("黄金默认手续费费率设置");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("黄金客户手续费率设置");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("手续费率设置", new System.Windows.Forms.TreeNode[] {
            treeNode15,
            treeNode16,
            treeNode17,
            treeNode18});
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("实时委托信息查询");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("实时成交信息查询");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("实时持仓信息查询");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("实时资金信息查询");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("实时库存信息查询");
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("数据查询", new System.Windows.Forms.TreeNode[] {
            treeNode20,
            treeNode21,
            treeNode22,
            treeNode23,
            treeNode24});
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("委托参数设置");
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("自成交管理");
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("撤单管理");
            System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("大额单管理");
            System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("风控参数设置");
            System.Windows.Forms.TreeNode treeNode31 = new System.Windows.Forms.TreeNode("风控设置", new System.Windows.Forms.TreeNode[] {
            treeNode26,
            treeNode27,
            treeNode28,
            treeNode29,
            treeNode30});
            this.kryptonTreeView = new ComponentFactory.Krypton.Toolkit.KryptonTreeView();
            this.SuspendLayout();
            // 
            // kryptonTreeView
            // 
            this.kryptonTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonTreeView.ItemHeight = 28;
            this.kryptonTreeView.Location = new System.Drawing.Point(0, 0);
            this.kryptonTreeView.Name = "kryptonTreeView";
            treeNode1.Name = "节点0";
            treeNode1.Text = "新增交易账户";
            treeNode2.Name = "节点19";
            treeNode2.Text = "新增管理用户";
            treeNode3.Name = "节点18";
            treeNode3.Text = "管理用户权限配置";
            treeNode4.Name = "节点0";
            treeNode4.NodeFont = new System.Drawing.Font("微软雅黑", 10F);
            treeNode4.Tag = "";
            treeNode4.Text = "交易账户管理";
            treeNode5.Name = "节点21";
            treeNode5.Tag = "KS.Zero.Client.IOFeiMgt.UC_IOFei,KS.Zero.Client";
            treeNode5.Text = "出入金管理";
            treeNode6.Name = "节点20";
            treeNode6.Text = "出入金管理";
            treeNode7.Name = "节点4";
            treeNode7.Tag = "KS.Zero.Client.ContractMgt.UC_FutureContractInfo,KS.Zero.Client";
            treeNode7.Text = "期货合约信息维护";
            treeNode8.Name = "节点17";
            treeNode8.Text = "金交所合约信息维护";
            treeNode9.Name = "节点3";
            treeNode9.Text = "合约管理";
            treeNode10.Name = "节点0";
            treeNode10.Text = "期货默认保证金率设置";
            treeNode11.Name = "节点1";
            treeNode11.Text = "期货客户保证金率设置";
            treeNode12.Name = "节点2";
            treeNode12.Text = "黄金默认保证金费率设置";
            treeNode13.Name = "节点3";
            treeNode13.Text = "黄金客户保证金率";
            treeNode14.Name = "节点5";
            treeNode14.Text = "保证金率设置";
            treeNode15.Name = "节点1";
            treeNode15.Text = "期货默认手续费率设置";
            treeNode16.Name = "节点2";
            treeNode16.Text = "期货客户手续费率设置";
            treeNode17.Name = "节点3";
            treeNode17.Text = "黄金默认手续费费率设置";
            treeNode18.Name = "节点4";
            treeNode18.Text = "黄金客户手续费率设置";
            treeNode19.Name = "节点0";
            treeNode19.Text = "手续费率设置";
            treeNode20.Name = "节点6";
            treeNode20.Text = "实时委托信息查询";
            treeNode21.Name = "节点7";
            treeNode21.Text = "实时成交信息查询";
            treeNode22.Name = "节点8";
            treeNode22.Text = "实时持仓信息查询";
            treeNode23.Name = "节点9";
            treeNode23.Text = "实时资金信息查询";
            treeNode24.Name = "节点10";
            treeNode24.Text = "实时库存信息查询";
            treeNode25.Name = "节点5";
            treeNode25.Text = "数据查询";
            treeNode26.Name = "节点12";
            treeNode26.Text = "委托参数设置";
            treeNode27.Name = "节点13";
            treeNode27.Text = "自成交管理";
            treeNode28.Name = "节点14";
            treeNode28.Text = "撤单管理";
            treeNode29.Name = "节点15";
            treeNode29.Text = "大额单管理";
            treeNode30.Name = "节点16";
            treeNode30.Text = "风控参数设置";
            treeNode31.Name = "节点11";
            treeNode31.Text = "风控设置";
            this.kryptonTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode6,
            treeNode9,
            treeNode14,
            treeNode19,
            treeNode25,
            treeNode31});
            this.kryptonTreeView.OverrideFocus.Node.Content.ShortText.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.kryptonTreeView.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.kryptonTreeView.Size = new System.Drawing.Size(150, 572);
            this.kryptonTreeView.TabIndex = 0;
            this.kryptonTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.kryptonTreeView_AfterSelect);
            this.kryptonTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.kryptonTreeView_NodeMouseClick);
            // 
            // UCMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.kryptonTreeView);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "UCMenu";
            this.Size = new System.Drawing.Size(150, 572);
            this.Load += new System.EventHandler(this.UCMenu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public ComponentFactory.Krypton.Toolkit.KryptonTreeView kryptonTreeView;
    }
}
