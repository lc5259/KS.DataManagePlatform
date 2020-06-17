using ComponentFactory.Krypton.Toolkit;
using KS.DataManage.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KS.DataManagePlatform
{
    //增加分组数据配置
    public partial class AddGroupConfig : KryptonForm
    {
        public AddGroupConfig()
        {
            InitializeComponent();
        }

        

        private void kryButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void kryButtonOK_Click(object sender, EventArgs e)
        {

            string GroupName = kryTextBoxName.Text.ToString();
            // FrmMain frmMain = new FrmMain();
            if (!string.IsNullOrEmpty(GroupName))
            {
                FrmMain.AddGroup(GroupName);
                if (!kryCheckBoxContinuousGroup.Checked)
                {
                    this.Close();
                }
            }
        }
    }
}
