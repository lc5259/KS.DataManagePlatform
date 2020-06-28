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
        public static DataTable ReturnDt;
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
            if (ftas.IsSave)
            {
                this.SuspendLayout();
                string FundAccountNo = ftas.kryTextBoxFundAccountNo.Text.ToString();


                List<string> CombTradeID = new List<string>();
                CombTradeID = this.kCombTradeID.DataSource as List<string>;
                CombTradeID.Add(FundAccountNo);

                this.kCombTradeID.DataSource = null;
                this.kCombTradeID.Items.Clear();
                //foreach (var item in CombTradeID)
                //{
                //    this.kCombTradeID.Items.Add(item);
                //}
                this.kCombTradeID.DataSource = CombTradeID ;
                this.kCombTradeID.Text = FundAccountNo;

                this.kCombTradeID.Refresh();
                this.ResumeLayout(false);
                
                //kCombTradeID.Items.Add(FundAccountNo);
            }
            
        }

        private void kBtnOtherSet_Click(object sender, EventArgs e)
        {
            FrmFundOtherSet ffos = new FrmFundOtherSet();
            ffos.ShowDialog();
        }

        private void btnAddTargetFile_Click(object sender, EventArgs e)
        {
            int drIndex =    kDGVFileList.CurrentRow.Index;
            DataTable dt = kDGVFileList.DataSource as DataTable;
            FrmTargetFileSet frmTargetFileSet = new FrmTargetFileSet( drIndex, dt,"文件列表增加");
            frmTargetFileSet.ShowDialog();
            this.kDGVFileList.DataSource = ReturnDt;
        }

        private void btnUpdateTargetFile_Click(object sender, EventArgs e)
        {
            int drIndex = kDGVFileList.CurrentRow.Index;
            DataTable dt = kDGVFileList.DataSource as DataTable;
            FrmTargetFileSet frmTargetFileSet = new FrmTargetFileSet(drIndex, dt, "文件列表修改");
            frmTargetFileSet.ShowDialog();
            this.kDGVFileList.DataSource = ReturnDt;
        }

        private void btnAddSourceFile_Click(object sender, EventArgs e)
        {
            int drIndex = kDGVSourceFileList.CurrentRow.Index;
            DataTable dt = kDGVSourceFileList.DataSource as DataTable;
            FrmSourceFileSet frmSourceFileSet = new FrmSourceFileSet(drIndex, dt, "源文件列表增加");
            frmSourceFileSet.ShowDialog();
            this.kDGVSourceFileList.DataSource = ReturnDt;

            //FrmSourceFileSet frmSourceFileSet = new FrmSourceFileSet();
            //frmSourceFileSet.ShowDialog();
        }
        private void btnUpdateSourceFile_Click(object sender, EventArgs e)
        {
            int drIndex = kDGVSourceFileList.CurrentRow.Index;
            DataTable dt = kDGVSourceFileList.DataSource as DataTable;
            FrmSourceFileSet frmSourceFileSet = new FrmSourceFileSet(drIndex, dt, "源文件列表修改");
            frmSourceFileSet.ShowDialog();
            this.kDGVSourceFileList.DataSource = ReturnDt;
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
                        this.kDGVFileList.DataSource = FileDataTable.FildListDT(xNode);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        private void kDGVFileList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                string TargetFileNo = this.kDGVFileList.Rows[e.RowIndex].Cells["TargetFileNo"].Value.ToString();
                string TargetFileTitle = this.kDGVFileList.Rows[e.RowIndex].Cells["TargetFileTitle"].Value.ToString();
                string TargetFileName = this.kDGVFileList.Rows[e.RowIndex].Cells["TargetFileName"].Value.ToString();

                try
                {
                    foreach (XElement xNode in _configDocument.Descendants("AccountId"))
                    {
                        if (xNode.Attribute("value").Value.Equals(kCombTradeID.SelectedItem.ToString()))
                        {
                            foreach (XElement itemFileNode in xNode.Descendants("OrganCode"))
                            {
                                foreach (XElement fileSrc in itemFileNode.Nodes())
                                {
                                    if (fileSrc.Attribute("fid").Value.ToString().Equals(TargetFileNo) && fileSrc.Attribute("filetitle").Value.Equals(TargetFileTitle) && fileSrc.Attribute("filename").Value.ToString().Equals(TargetFileName))
                                    {
                                        this.kDGVSourceFileList.DataSource = FileDataTable.SourceFileListDT(fileSrc);
                                        this.kDGVKeyWords.DataSource = FileDataTable.KeyWordstDT(fileSrc);
                                        break;
                                    }
                                }
                                
                            }
                             
                        }
                    }
                }
                catch (Exception ex)
                {

                    throw;
                }


                //string ConfigFileName = GlobalData.GetDataConfigPath(kCombAccount.SelectedItem.ToString());
                //System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
                //xmlDoc.LoadXml(ConfigFileName);
                //System.Xml.XmlNode root = xmlDoc.SelectSingleNode("//response");

                //int sdg = this.kDGVDict.CurrentCell.RowIndex;

                //DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)this.kDGVDict.Rows[sdg].Cells["TargetFilecheckAll"];
                //cell.Value = "1";


            }
        }

        private void btnDelTargetFile_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认删除？", "请确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (DataGridViewRow item in kDGVFileList.SelectedRows)
                {
                    kDGVFileList.Rows.Remove(item);
                }
            }
            
        }

        private void btnDelSourceFile_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认删除？", "请确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (DataGridViewRow item in kDGVSourceFileList.SelectedRows)
                {
                    kDGVSourceFileList.Rows.Remove(item);
                }
            }
        }
    }
}
