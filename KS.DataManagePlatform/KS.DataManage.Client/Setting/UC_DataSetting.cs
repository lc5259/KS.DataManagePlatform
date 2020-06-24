using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KS.DataManage.Utils;
using System.IO;
using System.Xml.Linq;
using ComponentFactory.Krypton.Toolkit;

namespace KS.DataManage.Client
{
    public partial class UC_DataSetting : UserControl
    {
        XDocument _configDocument;
        List<string> _listModule = new List<string>();
        public UC_DataSetting()
        {
            InitializeComponent();
            //SetFont();//测试阶段暂时关闭
        }

        void SetFont()
        {
            //FontClass.LoadFont4KBtn(kbtnSearch, "查询");
            //FontClass.LoadFont4KBtn(kbtnInsert, "新增");
            //FontClass.LoadFont4KBtn(kbtnDelete, "删除");
            //FontClass.LoadFont4KBtn(kbtnUpdate, "修改");
            //FontClass.LoadFont4KBtn(kbtnCopy, "复制");
            //FontClass.LoadFont4KBtn(kbtnInput, "导入");
            //FontClass.LoadFont4KBtn(kbtnOutput, "导出");
        }

        private void UC_DataSetting_Load(object sender, EventArgs e)
        {
            SetFont();
        }
        public void LoadConfigFile(string name)
        {
            this.SuspendLayout();
            kCombAccount.DataSource = GlobalData.AccountGroup;

            this.ResumeLayout(false);
        }
        private void btnAddTradeID_Click(object sender, EventArgs e)
        {
            FrmTradeAccountSet ftas = new FrmTradeAccountSet();
            ftas.ShowDialog();
        }

        private void kBtnOtherSet_Click(object sender, EventArgs e)
        {
            FrmFundOtherSet ffos = new FrmFundOtherSet();
            ffos.ShowDialog();
        }

        private void btnAddTargetFile_Click(object sender, EventArgs e)
        {
            FrmTargetFileSet frmTargetFileSet = new FrmTargetFileSet();
            frmTargetFileSet.ShowDialog();
        }

        private void btnUpdateTargetFile_Click(object sender, EventArgs e)
        {
            FrmTargetFileSet frmTargetFileSet = new FrmTargetFileSet();
            frmTargetFileSet.ShowDialog();
        }

        private void btnAddSourceFile_Click(object sender, EventArgs e)
        {
            FrmSourceFileSet frmSourceFileSet = new FrmSourceFileSet();
            frmSourceFileSet.ShowDialog();
        }

        private void btnAddGenerateFileKeyword_Click(object sender, EventArgs e)
        {
            FrmGenerateFileKeywordSet frmGenerateFileKeywordSet = new FrmGenerateFileKeywordSet();
            frmGenerateFileKeywordSet.ShowDialog();
        }
        private void kCombAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SuspendLayout();
            string ConfigFileName = GlobalData.GetDataConfigPath(kCombAccount.SelectedItem.ToString());
            if (!File.Exists(ConfigFileName))
            {
                KryptonMessageBox.Show(string.Format("配置文件 {0} 不存在！", ConfigFileName), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(string.Format("配置文件 {0} 不存在！", ConfigFileName));
                return;
            }
            _configDocument = XDocument.Load(ConfigFileName);
            XElement configRoot = _configDocument.Root;
            List<string> a = new List<string>();
            //kCombTradeID.Items.Clear();
            foreach (var xNode in configRoot.Nodes())
            {
                if (xNode is XElement)
                {
                    a.Add(((XElement)xNode).Attribute("value").Value);
                }
            }
            kCombTradeID.DataSource = a;

            this.ResumeLayout(false);
        }

        private void kCombTradeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (XElement xNode in _configDocument.Descendants("AccountId"))
                {
                    if (xNode.Attribute("value").Value.Equals(kCombTradeID.SelectedItem.ToString()))
                    {
                        this.dataGridView1.DataSource = FileDataTable.FildListDT(xNode);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
