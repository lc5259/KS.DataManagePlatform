using ComponentFactory.Krypton.Docking;
using ComponentFactory.Krypton.Navigator;
using ComponentFactory.Krypton.Toolkit;
using ComponentFactory.Krypton.Workspace;
using KS.DataManage.Utils;
using KS.DataManagePlatform;
using KS.Zero.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace KS.DataManage.Client
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            //记得加上这句  
            this.MaximumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            InitializeComponent();
        }
        private delegate void BeforeLoad();

        static UCMenu ucMenu;
        private static Dictionary<string, KryptonPage> _pageDic = new Dictionary<string, KryptonPage>();
        public static Dictionary<string, KryptonPage> PageDic
        {
            get { return _pageDic; }
        }


        static List<KryptonFloatingWindow> kFWList = new List<KryptonFloatingWindow>();

        #region 窗体重绘相关
        //FormBorderStyle.None时，支持改变窗体大小
        #region 支持改变窗体大小
        private const int Guying_HTLEFT = 10;
        private const int Guying_HTRIGHT = 11;
        private const int Guying_HTTOP = 12;
        private const int Guying_HTTOPLEFT = 13;
        private const int Guying_HTTOPRIGHT = 14;
        private const int Guying_HTBOTTOM = 15;
        private const int Guying_HTBOTTOMLEFT = 0x10;
        private const int Guying_HTBOTTOMRIGHT = 17;

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x0084:
                    base.WndProc(ref m);
                    Point vPoint = new Point((int)m.LParam & 0xFFFF, (int)m.LParam >> 16 & 0xFFFF);
                    vPoint = PointToClient(vPoint);
                    if (vPoint.X <= 5)
                        if (vPoint.Y <= 5)
                            m.Result = (IntPtr)Guying_HTTOPLEFT;
                        else if (vPoint.Y >= ClientSize.Height - 5)
                            m.Result = (IntPtr)Guying_HTBOTTOMLEFT;
                        else
                            m.Result = (IntPtr)Guying_HTLEFT;
                    else if (vPoint.X >= ClientSize.Width - 5)
                        if (vPoint.Y <= 5)
                            m.Result = (IntPtr)Guying_HTTOPRIGHT;
                        else if (vPoint.Y >= ClientSize.Height - 5)
                            m.Result = (IntPtr)Guying_HTBOTTOMRIGHT;
                        else
                            m.Result = (IntPtr)Guying_HTRIGHT;
                    else if (vPoint.Y <= 5)
                        m.Result = (IntPtr)Guying_HTTOP;
                    else if (vPoint.Y >= ClientSize.Height - 5)
                        m.Result = (IntPtr)Guying_HTBOTTOM;
                    break;
                case 0x0201://鼠标左键按下的消息
                    m.Msg = 0x00A1;//更改消息为非客户区按下鼠标
                    m.LParam = IntPtr.Zero; //默认值
                    m.WParam = new IntPtr(2);//鼠标放在标题栏内
                    base.WndProc(ref m);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        #endregion

        private void pnlTitle_MouseMove(object sender, MouseEventArgs e)
        {
            SelfMouseMove(sender, e); // 调用 MouseMove函数
        }
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;


        //代码开始  
        private const long WM_GETMINMAXINFO = 0x24;

        public struct POINTAPI
        {
            public int x;
            public int y;
        }

        public struct MINMAXINFO
        {
            public POINTAPI ptReserved;
            public POINTAPI ptMaxSize;
            public POINTAPI ptMaxPosition;
            public POINTAPI ptMinTrackSize;
            public POINTAPI ptMaxTrackSize;
        }
        private void SelfMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        //private LoginState _loginState = LoginState.IsLogout;
        private bool _isAbort;

        private void MaxNormalSize()
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                this.kbtnMax.Values.Image = global::KS.DataManage.Client.Properties.Resources.screenexpand16px;
                this.Padding = new System.Windows.Forms.Padding(3);
            }
            else
            {
                FormMax();
            }
        }

        private void FormMax()
        {
            this.WindowState = FormWindowState.Maximized;
            this.kbtnMax.Values.Image = global::KS.DataManage.Client.Properties.Resources.copy16px;
            this.Padding = new System.Windows.Forms.Padding(0);
        }

        private void FrmMainForm_Paint(object sender, PaintEventArgs e)
        {
            Rectangle myRectangle = new Rectangle(0, 0, this.Width, this.Height);
            //ControlPaint.DrawBorder(e.Graphics, myRectangle, Color.Blue, ButtonBorderStyle.Solid);//画个边框   
            ControlPaint.DrawBorder(e.Graphics, myRectangle,
                Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(95))))), 3, ButtonBorderStyle.Solid,
                Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(95))))), 3, ButtonBorderStyle.Solid,
                Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(95))))), 3, ButtonBorderStyle.Solid,
                Color.Blue, 3, ButtonBorderStyle.Solid
            );
        }

        private void FrmMainForm_ResizeEnd(object sender, EventArgs e)
        {
            if (this.Size != this.MaximumSize)
            {
                this.kbtnMax.Values.Image = global::KS.DataManage.Client.Properties.Resources.screenexpand16px;
                this.Padding = new System.Windows.Forms.Padding(3);
            }
        }
        #endregion

        #region 事件相关
        private void Form1_Load(object sender, EventArgs e)
        {
            #region 纯测试
            //List<Usr> list = new List<Usr>();
            //List<UsrMenu> list2 = new List<UsrMenu>();
            //List<MenuToUser> list3 = new List<MenuToUser>();
            //List<Dict> lis4 = new List<Dict>();
            //try
            //{
            //    var service = new UserService();
            //    var service2 = new UserMenuService();
            //    var service3 = new MenuService();
            //    var service4 = new DictService();
            //    list = service.GetALLUser();
            //    //list2 = service2.GetALLMenu();
            //    list3 = service3.GetMenuByUserID(1);
            //    list3 = service3.GetMenuByUserID(2);
            //    lis4 = service4.GetALLDict();
            //}
            //catch (Exception ex)
            //{
            //    KS.DataManage.Utils.Log.Error(ex.Message);
            //    throw;
            //}
            #endregion
        }

        private void pnlTitle_DoubleClick(object sender, EventArgs e)
        {
            MaxNormalSize();
        }

        private void kbtnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void kbtnMax_Click(object sender, EventArgs e)
        {
            MaxNormalSize();
        }

        private void kbtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        #endregion

        #region KryptonPage 相关
        private KryptonPage MainFormNodeChaned(NodeInfo ninfo)
        {
            KryptonWorkspaceCell cell = kDWorkspaceContent.FirstVisibleCell();
            try
            {
                if (cell == null)
                {
                    cell = new KryptonWorkspaceCell();
                    kDWorkspaceContent.Root.Children.Add(cell);
                }

                #region 基于菜单表 要重写
                //新增 判断如果不存在则新增
                if (!_pageDic.ContainsKey(ninfo.NodeName) && kDWorkspaceContent.PageForUniqueName(ninfo.NodeName) == null)
                {
                    KryptonPage pageTmp = OpenForm(ninfo);
                    if (pageTmp != null)
                    {
                        cell.Pages.Add(pageTmp);
                        cell.SelectedPage = pageTmp;
                        cell.Focus();
                    }
                    return pageTmp;
                }
                else if (_pageDic.ContainsKey(ninfo.NodeName) && kDWorkspaceContent.PageForUniqueName(ninfo.NodeName) != null)
                {
                    KryptonFloatingWindow kfw = FindFWindow(_pageDic[ninfo.NodeName]);
                    if (kfw == null)
                    {
                        //如果这个page已经存在那么就要把它找出来 不在FloatWindow里的情况
                        cell = kDWorkspaceContent.CellForUniqueName(ninfo.NodeName);
                        kDWorkspaceContent.ActiveCell = cell;
                        cell.SelectedPage = _pageDic[ninfo.NodeName];
                        return cell.SelectedPage;
                    }
                    else
                    {
                        kfw.Activate();
                        KryptonFloatspace kfs = kfw.FloatspaceControl;
                        kfs.SeparatorStyle = ComponentFactory.Krypton.Toolkit.SeparatorStyle.HighProfile;
                        Form f = kfw.FindForm();
                        cell = kfs.CellForUniqueName(ninfo.NodeName);
                        kfs.ActiveCell = cell;
                        cell.SelectedPage = _pageDic[ninfo.NodeName];
                        cell.Focus();
                        return cell.SelectedPage;
                    }
                }
                else if (kDWorkspaceContent.PageForUniqueName(ninfo.NodeName) != null)
                {
                    KryptonPage pageTmp = kDWorkspaceContent.PageForUniqueName(ninfo.NodeName);
                    kDWorkspaceContent.ClosePage(pageTmp);
                    bool a = pageTmp.Visible;
                    //其他特殊情况
                    pageTmp = OpenForm(ninfo);

                    cell.Pages.Add(pageTmp);
                    cell.SelectedPage = pageTmp;
                    cell.Focus();
                    return cell.SelectedPage;
                }
                return null;
                #endregion
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private static KryptonFloatingWindow FindFWindow(KryptonPage p)
        {
            KryptonFloatingWindow kfw = null;
            foreach (var item in kFWList)
            {
                if (item.Contains(p))
                {
                    kfw = item;
                }
                else
                {
                    continue;
                }
            }
            return kfw;
        }

        private static KryptonPage OpenForm(NodeInfo ninfo)
        {
            if (ninfo.NodeTag == null || ninfo.NodeTag.Equals(string.Empty) || ninfo.NodeTag.Equals("-"))
            {
                MessageBox.Show(string.Format("菜单{0}尚未配置!", ninfo.NodeText), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
            UserControl uc = new UserControl();
            KryptonPage pageTmp = new KryptonPage();
            if (true)
            {
                uc = System.Activator.CreateInstance(Type.GetType(ninfo.NodeTag)) as UserControl;
            }
            pageTmp.SuspendLayout();
            pageTmp.ClearFlags(KryptonPageFlags.DockingAllowAutoHidden | KryptonPageFlags.DockingAllowDocked);
            pageTmp.TextTitle = ninfo.NodeText;
            pageTmp.Text = ninfo.NodeText;
            pageTmp.TextDescription = ninfo.NodeText;
            pageTmp.UniqueName = ninfo.NodeName;

            pageTmp.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
            pageTmp.ResumeLayout(false);
            pageTmp.PerformLayout();
            _pageDic.Add(pageTmp.UniqueName, pageTmp);
            return pageTmp;
        }

        internal void InitialDockingMenu()
        {
            ucMenu = new UCMenu();
            ucMenu.ChangeSelect += new ChangeSelectHandler(MainFormNodeChaned);
            KryptonDockingWorkspace w = kryptonDockingManager.ManageWorkspace(kDWorkspaceContent);
            kryptonDockingManager.ManageControl(panel1, w);
            kryptonDockingManager.ManageFloating(this);

            // Add docking pages
            KryptonPage kp = NewMenu("文 件");
            kp.Width = 50;
            kp.UniqueName = "left";
            KryptonPage[] kpArr = new KryptonPage[] { kp };
            //KryptonDockingControl kdc = new KryptonDockingControl("Menu",,w);
            kryptonDockingManager.AddDockspace("Control", DockingEdge.Left, kpArr);

            kp.ClearFlags(KryptonPageFlags.DockingAllowDropDown
                | KryptonPageFlags.DockingAllowClose
                | KryptonPageFlags.DockingAllowFloating
                | KryptonPageFlags.DockingAllowWorkspace
                | KryptonPageFlags.AllowPageDrag);
        }

        private KryptonPage NewMenu(string s)
        {
            // Create new page with title and image
            KryptonPage p = new KryptonPage();
            p.Text = s + " 生 成 ";
            p.TextTitle = p.Text;
            p.TextDescription = p.Text;
            p.UniqueName = p.Text;

            // Add the control for display inside the page
            ucMenu.Dock = DockStyle.Fill;
            ucMenu.Text = "Page Content";
            p.Controls.Add(ucMenu);

            p.ClearFlags(KryptonPageFlags.DockingAllowDropDown
                | KryptonPageFlags.DockingAllowClose
                | KryptonPageFlags.DockingAllowFloating
                | KryptonPageFlags.DockingAllowWorkspace
                | KryptonPageFlags.AllowPageDrag);

            return p;
        }
        #endregion

        internal void Initialize()
        {
            this.CallLogin();
        }

        private void CallLogin()
        {
            //if (this._loginState == LoginState.IsLogin)
            //{
            //    return;
            //}
            //this.Hide();

            //try
            //{

            //    FrmLogin2 frmLog = new FrmLogin2(this);
            //    frmLog.ShowDialog();
            //    if (frmLog.DialogResult == DialogResult.Abort)
            //    {
            //        this._isAbort = true;
            //        this.DialogResult = DialogResult.Abort;
            //        this.Dispose();
            //    }
            //    else
            //    {
            InitialDockingMenu();
            //        //CommandBusService.RegisterDynamic(110, this.GetType(), "ClosingForm", null, null, this);
            //        //登录ToolStripMenuItem.Enabled = false;
            //        //注销ToolStripMenuItem.Enabled = true;
            //    }

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            //}
            //finally
            //{
            //    //if (this._loginState != LoginState.IsLogin)
            //    //{
            //    //    this.DialogResult = DialogResult.Cancel;
            //    //}
            //    if (!this._isAbort)//&& ConfigureService.TryGet("ShowSettingBeforeLogin") == "true")
            //    {
            //        FormMax();
            //        this.Show();
            //    }
            //}
        }

        #region 预加载--里面没啥东西
        internal void InvokeInitializeBeforeLoad()
        {
            this.Invoke(new FrmMain.BeforeLoad(this.InitializeBeforeLoad));
        }

        internal void InitializeBeforeLoad()
        {
            //加载资源文件之类
            //加载系统上下文 插件之类
            //初始化UI 图标 锁定超时
            //快捷键
            //系统窗口大小
        }
        #endregion

        #region 事件相关
        private void kryptonDockingManager_FloatingWindowAdding(object sender, FloatingWindowEventArgs e)
        {
            e.FloatingWindow.Size = new Size(800, 500);
            e.FloatingWindow.MinimumSize = new System.Drawing.Size(800, 500);
            kFWList.Add(e.FloatingWindow);
        }

        private void kryptonDockingManager_FloatingWindowRemoved(object sender, FloatingWindowEventArgs e)
        {
            kFWList.Remove(e.FloatingWindow);
        }

        KryptonDockspace MemuTemp = null;

        private void kryptonDockingManager_DockspaceAdding(object sender, DockspaceEventArgs e)
        {
            e.DockspaceControl.Size = new Size(250, 500);
            MemuTemp = e.DockspaceControl;
            //
        }

        private void kryptonDockingManager_PageCloseRequest(object sender, CloseRequestEventArgs e)
        {
            KryptonPage pageTmp = kDWorkspaceContent.PageForUniqueName(e.UniqueName);
            kDWorkspaceContent.ClosePage(pageTmp);
        }

        private void kDWorkspaceContent_PageCloseClicked(object sender, UniqueNameEventArgs e)
        {
            _pageDic.Remove(e.UniqueName);
        }
        #endregion

        /// <summary>
        /// 调试用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {

            //MemuTemp.Focus();
            //System.Drawing.Font fn = new Font(FontClass.pfc.Families[0], 12, FontStyle.Regular);//Fixedsys Excelsior 3.01  
            //button1.Font = FontClass.LoadFontFromFile();
            ////button1.Text = "\uF00B";
            var s = _pageDic["参数2"];
        }

        /// <summary>
        /// 调试用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void kryptonButton1_Click(object sender, EventArgs e)
        {

            //System.Drawing.Font fn = new Font(FontClass.pfc.Families[0], 12, FontStyle.Regular);//Fixedsys Excelsior 3.01  
            //kryptonButton1.StateNormal.Content.ShortText.Font = FontClass.LoadFontFromFile();
            /////kryptonButton1.Values.Text = "\uF0C7";
            //kryptonButton1.Text = "\uF00B";
            //menuStrip1.ForeColor
            this.MainFormNodeChaned(new NodeInfo("参数2", "参数设置2", "KS.DataManage.Client.UC_CstmrInfoMgt,KS.DataManage.Client"));
            Log.Info("44444");
            Log.Debug("2222");
            Log.Error("1111");
        }

        private void SetTSMItem_Click(object sender, EventArgs e)
        {
            this.MainFormNodeChaned(new NodeInfo("参数1", "1设置", "KS.DataManage.Client.UC_FutureContractInfo,KS.DataManage.Client"));
        }
        /////////////////////////////////没什么用////////////////////////////////////////////////////
        ///
       

        private void AddTSMItem_Click(object sender, EventArgs e)
        {
            AddGroupConfig addGroupConfig = new AddGroupConfig();
            addGroupConfig.ShowDialog();
        }

        public static void AddGroup(string  GroupName)
        {
            ucMenu.AddTreeNode(GroupName);
        }

        public static void RemoveGroup(string GroupKeyName)
        {
            ucMenu.RemoveTreeNode(GroupKeyName);
        }

        private void DeleteTSMItem_Click(object sender, EventArgs e)
        {
            DelGroupConfig delGroupConfig = new DelGroupConfig();
            foreach (TreeNode item in ucMenu.kryptonTreeView.Nodes)
            {
                //delGroupConfig.kryCheckedListBox.Items.AddRange(new object[] { item.Name.ToString() });
               delGroupConfig.kryCheckedListBox.Items.Add(new KryptonListItem(item.Name.ToString()));
            }
            delGroupConfig.ShowDialog();
        }

        private void GeneTSMItem_Click(object sender, EventArgs e)
        {
            BatchFileGeneration _batchFileGeneration = new BatchFileGeneration();
            _batchFileGeneration.ShowDialog();
        }
    }
}
