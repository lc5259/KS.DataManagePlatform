using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KS.DataManage.Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        internal void Initialize()
        {
            MessageBox.Show("初始化");
        }
        #region 预加载--里面没啥东西
        internal void InvokeInitializeBeforeLoad()
        {
            //this.Invoke(new FrmMain.BeforeLoad(this.InitializeBeforeLoad));
            MessageBox.Show("初始化");
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
    }
}
