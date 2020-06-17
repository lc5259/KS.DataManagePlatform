using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Navigator;
using KS.DataManage.Utils;

namespace KS.Zero.Controls
{
    public delegate KryptonPage ChangeSelectHandler(NodeInfo ni);//定义委托
    public partial class UCMenu : UserControl
    {
        public event ChangeSelectHandler ChangeSelect;  //定义事件

        public UCMenu()
        {
            InitializeComponent();
            this.SuspendLayout();
            this.kryptonTreeView.Nodes.Clear();
            this.LoadData(null);
            foreach (TreeNode item in kryptonTreeView.Nodes)
            {
                DiGuiNode(item);
            }
            this.ResumeLayout(false);
        }

        public UCMenu(int userID)
        {
            InitializeComponent();
            //menuListUser = GetMenuByUser(userID);
            this.SuspendLayout();
            this.kryptonTreeView.Nodes.Clear();
            this.LoadData(null);
            foreach (TreeNode item in kryptonTreeView.Nodes)
            {
                DiGuiNode(item);
            }
            this.ResumeLayout(false);

        }

        private void UCMenu_Load(object sender, EventArgs e)
        {
            this.kryptonTreeView.ExpandAll();
            //kryptonTreeView.SelectedNode = kryptonTreeView.Nodes[0].FirstNode;
        }

        private void DiGuiNode(TreeNode tn)
        {
            //1.将当前节点显示到lable上
            tn.NodeFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            foreach (TreeNode tnSub in tn.Nodes)
            {
                DiGuiNode(tnSub);
            }
        }

        private void kryptonTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            this.UseWaitCursor = true;
            this.kryptonTreeView.SelectedNode = null;
            this.kryptonTreeView.SelectedNode = e.Node;
        }
        
        TreeView treeView1;
        private void LoadData(TreeNode tn)
        {
            for (int i = 0; i < 5; i++)
            {
                TreeNode cNode = new TreeNode();
                cNode.Text = i.ToString() + i + i + i + i;
                cNode.Tag = "KS.DataManage.Client.UC_FutureContractInfo,KS.DataManage.Client";
                cNode.Name = i.ToString() + i + i + i + i;
                kryptonTreeView.Nodes.Add(cNode);//节点加到treeview
            }
            TreeNode param = new TreeNode();
            param.Text = "参数设置";
            param.Tag = "KS.DataManage.Client.UC_DataSetting,KS.DataManage.Client";
            param.Name = "参数设置";
            kryptonTreeView.Nodes.Add(param);//节点加到treeview
        }

        private void kryptonTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.UseWaitCursor = true;
            try
            {
                if (e.Node.Nodes.Count == 0)
                {
                    NodeInfo ninfo = new NodeInfo(e.Node.Name, e.Node.Text, (e.Node.Tag == null ? string.Empty : e.Node.Tag.ToString()));
                    ChangeSelect(ninfo);
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            finally
            {            //this.kryptonTreeView.SelectedNode = e.Node;
                this.UseWaitCursor = false;
            }
        }
    }
}
