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

        string SelectedTargetFileTitle = string.Empty;
        string SelectedTargetFileName = string.Empty;
        string SelectedSourceFileName = string.Empty;

        public UC_DataSetting()
        {
            InitializeComponent();
            //SetFont();//测试阶段暂时关闭
            //kDGVDict.AutoGenerateColumns = false; 
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
                this.kCombTradeID.DataSource = CombTradeID;
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
        #region  文件列表增删改
        private void btnAddTargetFile_Click(object sender, EventArgs e)
        {
            int drIndex = kDGVFileList.CurrentRow.Index;
            DataTable dt = kDGVFileList.DataSource as DataTable;
            FrmTargetFileSet frmTargetFileSet = new FrmTargetFileSet(drIndex, dt, "文件列表增加");
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
        #endregion

        #region 源文件列表增删改
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
        #endregion

        # region 生成文件关键字增删改
        private void btnAddGenerateFileKeyword_Click(object sender, EventArgs e)
        {
            int drIndex = kDGVKeyWords.CurrentRow.Index;
            DataTable dt = kDGVKeyWords.DataSource as DataTable;
            FrmGenerateFileKeywordSet frmGenerateFileKeywordSet = new FrmGenerateFileKeywordSet(drIndex, dt, "生成文件关键字增加");
            frmGenerateFileKeywordSet.ShowDialog();
            this.kDGVKeyWords.DataSource = ReturnDt;

        }
        private void btnUpdateGenerateFileKeyword_Click(object sender, EventArgs e)
        {
            int drIndex = kDGVKeyWords.CurrentRow.Index;
            DataTable dt = kDGVKeyWords.DataSource as DataTable;
            FrmGenerateFileKeywordSet frmGenerateFileKeywordSet = new FrmGenerateFileKeywordSet(drIndex, dt, "生成文件关键字修改");
            frmGenerateFileKeywordSet.ShowDialog();
            this.kDGVKeyWords.DataSource = ReturnDt;
        }
        private void btnDelGenerateFileKeyword_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认删除？", "请确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (DataGridViewRow item in kDGVKeyWords.SelectedRows)
                {
                    kDGVKeyWords.Rows.Remove(item);
                }
            }
        }
        #endregion

        #region 文件字段列表增删改
        private void btnAddFileField_Click(object sender, EventArgs e)
        {
            int drIndex = kDGVFileWordsList.CurrentRow.Index;
            DataTable dt = kDGVFileWordsList.DataSource as DataTable;
            FrmFileWordsList frmFileWordsList = new FrmFileWordsList(drIndex, dt, "文件字段列表增加");
            frmFileWordsList.ShowDialog();
            this.kDGVFileWordsList.DataSource = ReturnDt;
        }
        private void btnUpdateFileField_Click(object sender, EventArgs e)
        {
            int drIndex = kDGVFileWordsList.CurrentRow.Index;
            DataTable dt = kDGVFileWordsList.DataSource as DataTable;
            FrmFileWordsList frmFileWordsList = new FrmFileWordsList(drIndex, dt, "文件字段列表修改");
            frmFileWordsList.ShowDialog();
            this.kDGVFileWordsList.DataSource = ReturnDt;
        }
        private void btnDelFileField_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认删除？", "请确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (DataGridViewRow item in kDGVFileWordsList.SelectedRows)
                {
                    kDGVFileWordsList.Rows.Remove(item);
                }
            }
        }
        #endregion

        #region 过滤条件增删改
        private void btnAddFilterConditions_Click(object sender, EventArgs e)
        {
            int drIndex = kDGVFilter.CurrentRow.Index;
            DataTable dt = kDGVFilter.DataSource as DataTable;
            FrmFilterConditionsSet frmFilterConditionsSet = new FrmFilterConditionsSet(drIndex, dt, "过滤条件增加");
            frmFilterConditionsSet.ShowDialog();
            this.kDGVFilter.DataSource = ReturnDt;
        }

        private void btnUpdateFilterConditions_Click(object sender, EventArgs e)
        {
            int drIndex = kDGVFilter.CurrentRow.Index;
            DataTable dt = kDGVFilter.DataSource as DataTable;
            FrmFilterConditionsSet frmFilterConditionsSet = new FrmFilterConditionsSet(drIndex, dt, "过滤条件修改");
            frmFilterConditionsSet.ShowDialog();
            this.kDGVFilter.DataSource = ReturnDt;
        }
        private void btnDelFilterConditions_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认删除？", "请确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (DataGridViewRow item in kDGVFilter.SelectedRows)
                {
                    kDGVFilter.Rows.Remove(item);
                }
            }
        }
        #endregion

        #region 数据字典增删改
        private void btnAddDataDictionary_Click(object sender, EventArgs e)
        {
            int drIndex = kDGVDict.CurrentRow.Index;
            DataTable dt = kDGVDict.DataSource as DataTable;
            FrmDict frmDict = new FrmDict(drIndex, dt, "数据字典增加");
            frmDict.ShowDialog();
            this.kDGVDict.DataSource = ReturnDt;
        }

        private void btnUpdateDataDictionary_Click(object sender, EventArgs e)
        {
            int drIndex = kDGVDict.CurrentRow.Index;
            DataTable dt = kDGVDict.DataSource as DataTable;
            FrmDict frmDict = new FrmDict(drIndex, dt, "数据字典修改");
            frmDict.ShowDialog();
            this.kDGVDict.DataSource = ReturnDt;
        }
        private void btnDelDataDictionary_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认删除？", "请确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (DataGridViewRow item in kDGVDict.SelectedRows)
                {
                    kDGVDict.Rows.Remove(item);
                }
            }
        }
        #endregion

        /// <summary>
        ///  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// 文件列表datagridview显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// 源文件列表datagridview和生成文件关键字datagridview显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void kDGVFileList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataTable dtFileWordsList = (DataTable)kDGVFileWordsList.DataSource;
                if (dtFileWordsList != null)
                {
                    dtFileWordsList.Rows.Clear();
                    kDGVFileWordsList.DataSource = dtFileWordsList;
                }

                DataTable dtFilter = (DataTable)kDGVFilter.DataSource;
                if (dtFilter != null)
                {
                    dtFilter.Rows.Clear();
                    kDGVFilter.DataSource = dtFilter;
                }


                DataTable dtDict = (DataTable)kDGVDict.DataSource;
                if (dtDict != null)
                {
                    dtDict.Rows.Clear();
                    kDGVDict.DataSource = dtDict;
                }
                try
                {
                    if (e.ColumnIndex == 0)
                    {
                        if (kDGVFileList.Rows[e.RowIndex].Cells[0].Value == null || (!kDGVFileList.Rows[e.RowIndex].Cells[0].Value.ToString().ToLower().Equals("true")))
                        {
                            kDGVFileList.Rows[e.RowIndex].Cells[0].Value = true;
                        }
                        else
                        {
                            kDGVFileList.Rows[e.RowIndex].Cells[0].Value = false;
                        }

                    }
                }
                catch (Exception ex)
                {

                    throw;
                }


                string TargetFileNo = this.kDGVFileList.Rows[e.RowIndex].Cells["TargetFileNo"].Value.ToString();
                string TargetFileTitle = this.kDGVFileList.Rows[e.RowIndex].Cells["TargetFileTitle"].Value.ToString();
                string TargetFileName = this.kDGVFileList.Rows[e.RowIndex].Cells["TargetFileName"].Value.ToString();
                SelectedTargetFileTitle = TargetFileTitle;
                SelectedTargetFileName = TargetFileName;
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
                #region
                //string ConfigFileName = GlobalData.GetDataConfigPath(kCombAccount.SelectedItem.ToString());
                //System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
                //xmlDoc.LoadXml(ConfigFileName);
                //System.Xml.XmlNode root = xmlDoc.SelectSingleNode("//response");

                //int sdg = this.kDGVDict.CurrentCell.RowIndex;

                //DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)this.kDGVDict.Rows[sdg].Cells["TargetFilecheckAll"];
                //cell.Value = "1";
                #endregion

            }
        }

        /// <summary>
        /// 文件字段列表datagridview显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void kDGVSourceFileList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataTable dtFilter = (DataTable)kDGVFilter.DataSource;
                if (dtFilter != null)
                {
                    dtFilter.Rows.Clear();
                    kDGVFilter.DataSource = dtFilter;
                }

                DataTable dtDict = (DataTable)kDGVDict.DataSource;
                if (dtDict != null)
                {
                    dtDict.Rows.Clear();
                    kDGVDict.DataSource = dtDict;
                }

                string SourceFileName = this.kDGVSourceFileList.Rows[e.RowIndex].Cells["SourceFileName"].Value.ToString();
                SelectedSourceFileName = SourceFileName;
                //string TargetFileNo = this.kDGVFileList.Rows[e.RowIndex].Cells["TargetFileNo"].Value.ToString();
                string TargetFileTitle = SelectedTargetFileTitle;
                string TargetFileName = SelectedTargetFileName;

                foreach (XElement xNode in _configDocument.Descendants("AccountId"))
                {
                    if (xNode.Attribute("value").Value.Equals(kCombTradeID.SelectedItem.ToString()))
                    {
                        foreach (XElement itemFileNode in xNode.Descendants("OrganCode"))
                        {
                            foreach (XElement fileSrc in itemFileNode.Nodes())
                            {
                                if (fileSrc.Attribute("filetitle").Value.Equals(TargetFileTitle) && fileSrc.Attribute("filename").Value.ToString().Equals(TargetFileName))
                                {
                                    foreach (XElement itemFilecols in fileSrc.Descendants("fileSrc"))
                                    {
                                        if (itemFilecols.Attribute("srcfile").Value.Equals(SourceFileName))
                                        {
                                            this.kDGVFileWordsList.DataSource = FileDataTable.FildWordsListDT(itemFilecols);

                                            break;
                                        }
                                    }

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
        }


        /// <summary>
        /// 过滤条件datagridview和数据字典datagridview显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void kDGVFileWordsList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable dtFilter = (DataTable)kDGVFilter.DataSource;
            if (dtFilter != null)
            {
                dtFilter.Rows.Clear();
                kDGVFilter.DataSource = dtFilter;
            }

            DataTable dtDict = (DataTable)kDGVDict.DataSource;
            if (dtDict != null)
            {
                dtDict.Rows.Clear();
                kDGVDict.DataSource = dtDict;
            }


            string TargetFileTitle = SelectedTargetFileTitle;
            string TargetFileName = SelectedTargetFileName;
            string SourceFileName = SelectedSourceFileName;

            string TXTColumnName = this.kDGVFileWordsList.Rows[e.RowIndex].Cells["FileFieldTXTColumnName"].Value.ToString();
            foreach (XElement xNode in _configDocument.Descendants("AccountId"))
            {
                if (xNode.Attribute("value").Value.Equals(kCombTradeID.SelectedItem.ToString()))
                {
                    foreach (XElement itemFileNode in xNode.Descendants("OrganCode"))
                    {
                        foreach (XElement fileSrc in itemFileNode.Nodes())
                        {
                            if (fileSrc.Attribute("filetitle").Value.Equals(TargetFileTitle) && fileSrc.Attribute("filename").Value.ToString().Equals(TargetFileName))
                            {
                                foreach (XElement itemFilecols in fileSrc.Descendants("fileSrc"))
                                {
                                    if (itemFilecols.Attribute("srcfile").Value.Equals(SourceFileName))
                                    {
                                        foreach (XElement item in itemFilecols.Nodes())
                                        {
                                            if (item.Attribute("label").Value.Equals(TXTColumnName))
                                            {
                                                this.kDGVFilter.DataSource = FileDataTable.FilterDT(item);
                                                this.kDGVDict.DataSource = FileDataTable.DictDT(item);
                                                break;
                                            }
                                        }

                                    }
                                }

                            }
                        }

                    }

                }
            }
        }

        private void kDGVFileList_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    bool checkAll = true;
                    foreach (DataGridViewRow item in kDGVFileList.Rows)
                    {
                        if (item.Cells[0].Value == null || !(bool)item.Cells[0].Value)
                        {
                            checkAll = false;
                        }
                    }
                    if (!checkAll)
                    {
                        foreach (DataGridViewRow item in kDGVFileList.Rows)
                        {
                            item.Cells[0].Value = true; // item[0] = true;
                        }
                    }
                    else 
                    {
                        foreach (DataGridViewRow item in kDGVFileList.Rows)
                        {
                            item.Cells[0].Value = false;
                        }
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
