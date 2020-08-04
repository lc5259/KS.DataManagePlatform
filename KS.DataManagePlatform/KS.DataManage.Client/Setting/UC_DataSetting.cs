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
        public static XElement ReturnXElement;
        public static string ReturnOrganCode;
        XDocument _configDocument;
        List<string> _listModule = new List<string>();

        public static string SelectedTargetFileTitle = string.Empty;
        public static string SelectedTargetFileName = string.Empty;
        public static string SelectedSourceFileNo = string.Empty;
        public static string SelectedSourceFileName = string.Empty;
        public static string SelectedTXTColumnName = string.Empty;
        public static string SelectedFileFieldNo = string.Empty;
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
        /// <summary>
        /// 资金账户增删改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddTradeID_Click(object sender, EventArgs e)
        {
            FrmTradeAccountSet ftas = new FrmTradeAccountSet(false, kCombTradeID.Text, GlobalData.TemplateConfigInfo);
            ftas.ShowDialog();
            if (ftas.IsSave)
            {
                this.SuspendLayout();
                string FundAccountNo = ftas.kryTextBoxFundAccountNo.Text.ToString();

                List<string> CombTradeID = new List<string>();
                CombTradeID = this.kCombTradeID.DataSource as List<string>;
                if (CombTradeID.Contains(FundAccountNo))
                {
                    MessageBox.Show("资金账号已存在", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                XElement AddNode = new XElement(GlobalData.TemplateConfigInfo);

                AddNode.SetAttributeValue("value", FundAccountNo);
                foreach (XElement item in AddNode.Nodes())
                {
                    if (item.Name == "DlgConfigSettings")
                    {
                        item.Attribute("account").Value = FundAccountNo;
                        break;
                    }
                }

                AddNode.Attribute("cffexFile").Value = AppDatas.CffexFile;
                AddNode.Attribute("cfmmcFile").Value = AppDatas.CfmmcFile;
                AddNode.Attribute("cffexext").Value = AppDatas.Cffexext;
                AddNode.Attribute("cfmmcext").Value = AppDatas.Cfmmcext;

                _configDocument.Root.Add(AddNode);

               
                CombTradeID.Add(FundAccountNo);

                this.kCombTradeID.DataSource = new List<string>();
                //foreach (var item in CombTradeID)
                //{
                //    this.kCombTradeID.Items.Add(item);
                //}
                this.kCombTradeID.DataSource = CombTradeID;
                this.kCombTradeID.Text = FundAccountNo;

                this.kCombTradeID.Refresh();
                this.ResumeLayout(false);


                
               
                //GlobalData.TemplateConfigInfo.Descendants().Where( x=> x.Element("DlgConfigSettings").Attribute("account").Value == "34"  ).
                //kCombTradeID.Items.Add(FundAccountNo);
            }

        }
        private void btnUpdateTradeID_Click(object sender, EventArgs e)
        {
            FrmTradeAccountSet ftas = new FrmTradeAccountSet(false, kCombTradeID.Text, GlobalData.TemplateConfigInfo);
            ftas.ShowDialog();

            if (ftas.IsSave)
            {
                this.SuspendLayout();
                string FundAccountNo = ftas.kryTextBoxFundAccountNo.Text.ToString();


                List<string> CombTradeID = new List<string>();
                CombTradeID = this.kCombTradeID.DataSource as List<string>;
                for (int i = 0; i < CombTradeID.Count; i++)
                {
                    if (CombTradeID[i] == kCombTradeID.Text)
                    {
                        CombTradeID[i] = FundAccountNo;
                        break;
                    }
                }

                this.kCombTradeID.DataSource = null;

                this.kCombTradeID.DataSource = CombTradeID;
                this.kCombTradeID.Text = FundAccountNo;

                this.kCombTradeID.Refresh();
                this.ResumeLayout(false);

                GlobalData.TemplateConfigInfo.SetAttributeValue("value", FundAccountNo);
                foreach (XElement item in GlobalData.TemplateConfigInfo.Nodes())
                {
                    if (item.Name == "DlgConfigSettings")
                    {
                        item.Attribute("account").Value = FundAccountNo;
                        break;
                    }
                }
                GlobalData.TemplateConfigInfo.Attribute("cffexFile").Value = AppDatas.CffexFile;
                GlobalData.TemplateConfigInfo.Attribute("cfmmcFile").Value = AppDatas.CfmmcFile;
                GlobalData.TemplateConfigInfo.Attribute("cffexext").Value = AppDatas.Cffexext;
                GlobalData.TemplateConfigInfo.Attribute("cfmmcext").Value = AppDatas.Cfmmcext;
            }
        }

        private void btnDelTradeID_Click(object sender, EventArgs e)
        {
            List<string> CombTradeID = new List<string>();
            CombTradeID = this.kCombTradeID.DataSource as List<string>;
            for (int i = 0; i < CombTradeID.Count; i++)
            {
                if (CombTradeID[i] == kCombTradeID.Text)
                {
                    CombTradeID.RemoveAt(i);
                    break;
                }
            }
            foreach (XElement item in _configDocument.Descendants("AccountId"))
            {
                if (item.Attribute("value").Value == kCombTradeID.Text)
                {
                    item.Remove();
                    break;
                }
            }

            this.kCombTradeID.DataSource = null;

            this.kCombTradeID.DataSource = CombTradeID;
            //this.kCombTradeID.Text = "";

            this.kCombTradeID.Refresh();

           
        }
        private void kBtnOtherSet_Click(object sender, EventArgs e)
        {
            FrmFundOtherSet ffos = new FrmFundOtherSet();
            ffos.ShowDialog();
        }
        #region  文件列表增删改
        private void btnAddTargetFile_Click(object sender, EventArgs e)
        {
            if (kDGVFileList.CurrentRow != null)
            {
                int drIndex = kDGVFileList.CurrentRow.Index;
                DataTable dt = kDGVFileList.DataSource as DataTable;
                FrmTargetFileSet frmTargetFileSet = new FrmTargetFileSet(drIndex, dt, "文件列表增加");
                frmTargetFileSet.ShowDialog();
                if (ReturnDt == null)
                {
                    ReturnDt = dt;
                }
                this.kDGVFileList.DataSource = ReturnDt;
            }
            else
            {
                FrmTargetFileSet frmTargetFileSet = new FrmTargetFileSet();
                frmTargetFileSet.ShowDialog();

                this.kDGVFileList.DataSource = ReturnDt;
            }

            foreach (XElement item in GlobalData.TemplateConfigInfo.Descendants("OrganCode"))
            {
                if (item.Attribute("name").Value == ReturnOrganCode)
                {
                    item.Add(ReturnXElement);
                    break;
                }
            }

            //GlobalData.TemplateConfigInfo.Add(ReturnXElement);


            //IEnumerable<DataRow> query2  = ReturnDt.AsEnumerable().Except(dt.AsEnumerable());

            //var esdf213 = dt.AsEnumerable().Except(ReturnDt.AsEnumerable(),DataRowComparer.Default).ToList();
            //var esgadhdf = ReturnDt.AsEnumerable().Intersect(dt.AsEnumerable(), DataRowComparer.Default).ToList();
        }

        private void btnUpdateTargetFile_Click(object sender, EventArgs e)
        {
            if (kDGVFileList.CurrentRow == null)
            {
                MessageBox.Show("请先选中一行数据", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int drIndex = kDGVFileList.CurrentRow.Index;
            DataTable dt = kDGVFileList.DataSource as DataTable;
            FrmTargetFileSet frmTargetFileSet = new FrmTargetFileSet(drIndex, dt, "文件列表修改");
            frmTargetFileSet.ShowDialog();
            if (ReturnDt == null)
            {
                ReturnDt = dt;
            }
            this.kDGVFileList.DataSource = ReturnDt;

            //foreach (XElement itemFile in GlobalData.TemplateConfigInfo.Descendants("OrganCode"))
            //{
            //    if (itemFile.Attribute("name").Value == ReturnOrganCode)
            //    {
            //        foreach (var item in itemFile.Nodes())
            //        {
            //            if (item.)
            //            {
            //                item.ReplaceWith();
            //            }
            //        }
            //        itemFile.Add(ReturnXElement);
            //        break;
            //    }
            //}
        }
        private void btnDelTargetFile_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认删除？", "请确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (DataGridViewRow item in kDGVFileList.SelectedRows)
                {

                    foreach (XElement itemOrganCode in GlobalData.TemplateConfigInfo.Descendants("OrganCode"))
                    {
                        if (itemOrganCode.Attribute("name").Value == item.Cells[1].Value.ToString())
                        //if (itemOrganCode.Attribute("name").Value == item.Cells[1].Value.ToString())
                        {
                            foreach (XElement itemfile in itemOrganCode.Nodes())
                            {
                                if (itemfile.Attribute("filetitle").Value == item.Cells[3].Value.ToString() && itemfile.Attribute("fid").Value == item.Cells[2].Value.ToString())
                                {
                                    itemfile.Remove();
                                    break;
                                }
                            }
                        }
                    }
                    kDGVFileList.Rows.Remove(item);
                }
            }

        }
        #endregion

        #region 源文件列表增删改
        private void btnAddSourceFile_Click(object sender, EventArgs e)
        {
            if (kDGVSourceFileList.CurrentRow != null)
            {
                int drIndex = kDGVSourceFileList.CurrentRow.Index;
                DataTable dt = kDGVSourceFileList.DataSource as DataTable;
                FrmSourceFileSet frmSourceFileSet = new FrmSourceFileSet(drIndex, dt, "源文件列表增加");
                frmSourceFileSet.ShowDialog();
                if (ReturnDt == null)
                {
                    ReturnDt = dt;
                }
                this.kDGVSourceFileList.DataSource = ReturnDt;
            }

            else
            {
                FrmSourceFileSet frmSourceFileSet = new FrmSourceFileSet();
                frmSourceFileSet.ShowDialog();

                this.kDGVSourceFileList.DataSource = ReturnDt;
            }

            foreach (XElement itemOrganCode in GlobalData.TemplateConfigInfo.Descendants("OrganCode"))
            {

                foreach (XElement itemfile in itemOrganCode.Nodes())
                {
                    if (itemfile.Attribute("filetitle").Value == SelectedTargetFileTitle)
                    {
                        itemfile.Add(ReturnXElement);
                        break;
                    }
                }

            }
            //FrmSourceFileSet frmSourceFileSet = new FrmSourceFileSet();
            //frmSourceFileSet.ShowDialog();
        }
        private void btnUpdateSourceFile_Click(object sender, EventArgs e)
        {
            if (kDGVSourceFileList.CurrentRow == null)
            {
                MessageBox.Show("请先选中一行数据", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int drIndex = kDGVSourceFileList.CurrentRow.Index;
            DataTable dt = kDGVSourceFileList.DataSource as DataTable;
            FrmSourceFileSet frmSourceFileSet = new FrmSourceFileSet(drIndex, dt, "源文件列表修改");
            frmSourceFileSet.ShowDialog();
            if (ReturnDt == null)
            {
                ReturnDt = dt;
            }
            this.kDGVSourceFileList.DataSource = ReturnDt;
        }
        private void btnDelSourceFile_Click(object sender, EventArgs e)
        {
            if (kDGVSourceFileList.CurrentRow == null)
            {
                MessageBox.Show("请先选中一行数据", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("确认删除？", "请确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (DataGridViewRow item in kDGVSourceFileList.SelectedRows)
                {
                    foreach (XElement itemfile in GlobalData.TemplateConfigInfo.Descendants("file"))
                    {
                        if (itemfile.Attribute("filetitle").Value == SelectedTargetFileTitle)
                        {
                            foreach (XElement itemfileSrc in itemfile.Descendants("fileSrc"))
                            {
                                if (itemfileSrc.Attribute("srcfile").Value == item.Cells[1].Value.ToString() && itemfileSrc.Attribute("srcid").Value == item.Cells[0].Value.ToString())
                                {
                                    itemfileSrc.Remove();
                                    break;
                                }
                            }

                        }
                    }

                    kDGVSourceFileList.Rows.Remove(item);
                }
            }
        }
        #endregion

        # region 生成文件关键字增删改
        private void btnAddGenerateFileKeyword_Click(object sender, EventArgs e)
        {

            if (kDGVKeyWords.CurrentRow != null)
            {
                int drIndex = kDGVKeyWords.CurrentRow.Index;
                DataTable dt = kDGVKeyWords.DataSource as DataTable;
                FrmGenerateFileKeywordSet frmGenerateFileKeywordSet = new FrmGenerateFileKeywordSet(drIndex, dt, "生成文件关键字增加");
                frmGenerateFileKeywordSet.ShowDialog();
                if (ReturnDt == null)
                {
                    ReturnDt = dt;
                }
                this.kDGVKeyWords.DataSource = ReturnDt;
            }
            else
            {
                DataTable dt = kDGVKeyWords.DataSource as DataTable;
                FrmGenerateFileKeywordSet frmGenerateFileKeywordSet = new FrmGenerateFileKeywordSet();
                frmGenerateFileKeywordSet.ShowDialog();
                if (ReturnDt == null)
                {
                    ReturnDt = dt;
                }
                this.kDGVKeyWords.DataSource = ReturnDt;
            }


            foreach (XElement itemOrganCode in GlobalData.TemplateConfigInfo.Descendants("OrganCode"))
            {

                foreach (XElement itemfile in itemOrganCode.Nodes())
                {
                    if (itemfile.Attribute("filetitle").Value == SelectedTargetFileTitle)
                    {
                        itemfile.Add(ReturnXElement);
                        break;
                    }
                }

            }
        }
        private void btnUpdateGenerateFileKeyword_Click(object sender, EventArgs e)
        {
            if (kDGVKeyWords.CurrentRow == null)
            {
                MessageBox.Show("请先选中一行数据", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int drIndex = kDGVKeyWords.CurrentRow.Index;
            DataTable dt = kDGVKeyWords.DataSource as DataTable;
            FrmGenerateFileKeywordSet frmGenerateFileKeywordSet = new FrmGenerateFileKeywordSet(drIndex, dt, "生成文件关键字修改");
            frmGenerateFileKeywordSet.ShowDialog();
            if (ReturnDt == null)
            {
                ReturnDt = dt;
            }
            this.kDGVKeyWords.DataSource = ReturnDt;
        }
        private void btnDelGenerateFileKeyword_Click(object sender, EventArgs e)
        {
            if (kDGVKeyWords.CurrentRow == null)
            {
                MessageBox.Show("请先选中一行数据", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("确认删除？", "请确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (DataGridViewRow item in kDGVKeyWords.SelectedRows)
                {
                    foreach (XElement itemfile in GlobalData.TemplateConfigInfo.Descendants("file"))
                    {
                        if (itemfile.Attribute("filetitle").Value == SelectedTargetFileTitle)
                        {
                            foreach (XElement itemfilepkg in itemfile.Descendants("filepkg"))
                            {
                                if (itemfilepkg.Attribute("pkid").Value == item.Cells[0].Value.ToString() && itemfilepkg.Attribute("name").Value == item.Cells[1].Value.ToString())
                                {
                                    itemfilepkg.Remove();
                                    break;
                                }
                            }

                        }
                    }

                    kDGVKeyWords.Rows.Remove(item);
                }
            }
        }
        #endregion

        #region 文件字段列表增删改
        private void btnAddFileField_Click(object sender, EventArgs e)
        {
            if (kDGVFileWordsList.CurrentRow != null)
            {
                int drIndex = kDGVFileWordsList.CurrentRow.Index;
                DataTable dt = kDGVFileWordsList.DataSource as DataTable;
                FrmFileWordsList frmFileWordsList = new FrmFileWordsList(drIndex, dt, "文件字段列表增加");
                frmFileWordsList.ShowDialog();
                if (ReturnDt == null)
                {
                    ReturnDt = dt;
                }
                this.kDGVFileWordsList.DataSource = ReturnDt;
            }
            else
            {
                FrmFileWordsList frmFileWordsList = new FrmFileWordsList();
                frmFileWordsList.ShowDialog();
                this.kDGVFileWordsList.DataSource = ReturnDt;
            }
            foreach (XElement itemOrganCode in GlobalData.TemplateConfigInfo.Descendants("OrganCode"))
            {
                foreach (XElement itemfile in itemOrganCode.Nodes())
                {
                    if (itemfile.Attribute("filetitle").Value == SelectedTargetFileTitle)
                    {
                        foreach (XElement itemfileSrc in itemfile.Descendants("fileSrc"))
                        {
                            if (itemfileSrc.Attribute("srcfile").Value == SelectedSourceFileName && itemfileSrc.Attribute("srcid").Value == SelectedSourceFileNo)
                            {
                                itemfileSrc.Add(ReturnXElement);
                                break;
                            }
                        }

                    }
                }
            }
        }
        private void btnUpdateFileField_Click(object sender, EventArgs e)
        {
            if (kDGVFileWordsList.CurrentRow == null)
            {
                MessageBox.Show("请先选中一行数据", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int drIndex = kDGVFileWordsList.CurrentRow.Index;
            DataTable dt = kDGVFileWordsList.DataSource as DataTable;
            FrmFileWordsList frmFileWordsList = new FrmFileWordsList(drIndex, dt, "文件字段列表修改");
            frmFileWordsList.ShowDialog();
            if (ReturnDt == null)
            {
                ReturnDt = dt;
            }
            this.kDGVFileWordsList.DataSource = ReturnDt;
        }
        private void btnDelFileField_Click(object sender, EventArgs e)
        {
            if (kDGVFileWordsList.CurrentRow == null)
            {
                MessageBox.Show("请先选中一行数据", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("确认删除？", "请确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (DataGridViewRow item in kDGVFileWordsList.SelectedRows)
                {
                    foreach (XElement itemfile in GlobalData.TemplateConfigInfo.Descendants("file"))
                    {
                        if (itemfile.Attribute("filetitle").Value == SelectedTargetFileTitle)
                        {
                            foreach (XElement itemfileSrc in itemfile.Descendants("fileSrc"))
                            {
                                if (itemfileSrc.Attribute("srcfile").Value == SelectedSourceFileName && itemfileSrc.Attribute("srcid").Value == SelectedSourceFileNo)
                                {
                                    foreach (XElement itemfilecols in itemfileSrc.Nodes())
                                    {
                                        if (itemfilecols.Attribute("cid").Value == item.Cells[0].Value.ToString() && itemfilecols.Attribute("label").Value == item.Cells[1].Value.ToString())
                                        {
                                            itemfilecols.Remove();
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    kDGVFileWordsList.Rows.Remove(item);
                }
            }
        }
        #endregion

        #region 过滤条件增删改
        private void btnAddFilterConditions_Click(object sender, EventArgs e)
        {
            if (kDGVFilter.CurrentRow != null)
            {
                int drIndex = kDGVFilter.CurrentRow.Index;
                DataTable dt = kDGVFilter.DataSource as DataTable;
                FrmFilterConditionsSet frmFilterConditionsSet = new FrmFilterConditionsSet(drIndex, dt, "过滤条件增加");
                frmFilterConditionsSet.ShowDialog();
                if (ReturnDt == null)
                {
                    ReturnDt = dt;
                }
                this.kDGVFilter.DataSource = ReturnDt;
            }
            else
            {
                DataTable dt = kDGVFilter.DataSource as DataTable;
                FrmFilterConditionsSet frmFilterConditionsSet = new FrmFilterConditionsSet();
                frmFilterConditionsSet.ShowDialog();
                if (ReturnDt == null)
                {
                    ReturnDt = dt;
                }
                this.kDGVFilter.DataSource = ReturnDt;
            }
            foreach (XElement itemOrganCode in GlobalData.TemplateConfigInfo.Descendants("OrganCode"))
            {
                foreach (XElement itemfile in itemOrganCode.Nodes())
                {
                    if (itemfile.Attribute("filetitle").Value == SelectedTargetFileTitle)
                    {
                        foreach (XElement itemfileSrc in itemfile.Descendants("fileSrc"))
                        {
                            if (itemfileSrc.Attribute("srcfile").Value == SelectedSourceFileName && itemfileSrc.Attribute("srcid").Value == SelectedSourceFileNo)
                            {
                                foreach (XElement itemfilecols in itemfileSrc.Nodes())
                                {
                                    if (itemfilecols.Attribute("label").Value == SelectedTXTColumnName && itemfilecols.Attribute("cid").Value == SelectedFileFieldNo)
                                    {
                                        itemfilecols.Add(ReturnXElement);
                                        break;
                                    }
                                }

                            }
                        }
                    }
                }
            }
        }

        private void btnUpdateFilterConditions_Click(object sender, EventArgs e)
        {
            if (kDGVFilter.CurrentRow == null)
            {
                MessageBox.Show("请先选中一行数据", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int drIndex = kDGVFilter.CurrentRow.Index;
            DataTable dt = kDGVFilter.DataSource as DataTable;
            FrmFilterConditionsSet frmFilterConditionsSet = new FrmFilterConditionsSet(drIndex, dt, "过滤条件修改");
            frmFilterConditionsSet.ShowDialog();
            if (ReturnDt == null)
            {
                ReturnDt = dt;
            }
            this.kDGVFilter.DataSource = ReturnDt;
        }
        private void btnDelFilterConditions_Click(object sender, EventArgs e)
        {
            if (kDGVFilter.CurrentRow == null)
            {
                MessageBox.Show("请先选中一行数据", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("确认删除？", "请确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (DataGridViewRow item in kDGVFilter.SelectedRows)
                {
                    foreach (XElement itemfile in GlobalData.TemplateConfigInfo.Descendants("file"))
                    {
                        if (itemfile.Attribute("filetitle").Value == SelectedTargetFileTitle)
                        {
                            foreach (XElement itemfileSrc in itemfile.Descendants("fileSrc"))
                            {
                                if (itemfileSrc.Attribute("srcfile").Value == SelectedSourceFileName && itemfileSrc.Attribute("srcid").Value == SelectedSourceFileNo)
                                {
                                    foreach (XElement itemfilecols in itemfileSrc.Nodes())
                                    {
                                        if (itemfilecols.Attribute("cid").Value == UC_DataSetting.SelectedFileFieldNo && itemfilecols.Attribute("label").Value == UC_DataSetting.SelectedTXTColumnName)
                                        {
                                            foreach (XElement itemfilter in itemfilecols.Descendants("filter"))
                                            {
                                                if (itemfilter.Attribute("filtId").Value == item.Cells[0].Value.ToString())
                                                {
                                                    itemfilter.Remove();
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    kDGVFilter.Rows.Remove(item);
                }
            }
        }
        #endregion

        #region 数据字典增删改
        private void btnAddDataDictionary_Click(object sender, EventArgs e)
        {
            if (kDGVDict.CurrentRow != null)
            {
                int drIndex = kDGVDict.CurrentRow.Index;
                DataTable dt = kDGVDict.DataSource as DataTable;
                FrmDict frmDict = new FrmDict(drIndex, dt, "数据字典增加");
                frmDict.ShowDialog();
                if (ReturnDt == null)
                {
                    ReturnDt = dt;
                }
                this.kDGVDict.DataSource = ReturnDt;
            }
            else
            {
                DataTable dt = kDGVDict.DataSource as DataTable;
                FrmDict frmDict = new FrmDict();
                frmDict.ShowDialog();
                if (ReturnDt == null)
                {
                    ReturnDt = dt;
                }
                this.kDGVDict.DataSource = ReturnDt;
            }
            foreach (XElement itemOrganCode in GlobalData.TemplateConfigInfo.Descendants("OrganCode"))
            {
                foreach (XElement itemfile in itemOrganCode.Nodes())
                {
                    if (itemfile.Attribute("filetitle").Value == SelectedTargetFileTitle)
                    {
                        foreach (XElement itemfileSrc in itemfile.Descendants("fileSrc"))
                        {
                            if (itemfileSrc.Attribute("srcfile").Value == SelectedSourceFileName && itemfileSrc.Attribute("srcid").Value == SelectedSourceFileNo)
                            {
                                foreach (XElement itemfilecols in itemfileSrc.Nodes())
                                {
                                    if (itemfilecols.Attribute("label").Value == SelectedTXTColumnName && itemfilecols.Attribute("cid").Value == SelectedFileFieldNo)
                                    {
                                        itemfilecols.Add(ReturnXElement);
                                        break;
                                    }
                                }

                            }
                        }
                    }
                }
            }
        }

        private void btnUpdateDataDictionary_Click(object sender, EventArgs e)
        {
            if (kDGVDict.CurrentRow == null)
            {
                MessageBox.Show("请先选中一行数据", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int drIndex = kDGVDict.CurrentRow.Index;
            DataTable dt = kDGVDict.DataSource as DataTable;
            FrmDict frmDict = new FrmDict(drIndex, dt, "数据字典修改");
            frmDict.ShowDialog();
            if (ReturnDt == null)
            {
                ReturnDt = dt;
            }
            this.kDGVDict.DataSource = ReturnDt;
        }
        private void btnDelDataDictionary_Click(object sender, EventArgs e)
        {
            if (kDGVDict.CurrentRow == null)
            {
                MessageBox.Show("请先选中一行数据", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("确认删除？", "请确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (DataGridViewRow item in kDGVDict.SelectedRows)
                {
                    foreach (XElement itemfile in GlobalData.TemplateConfigInfo.Descendants("file"))
                    {
                        if (itemfile.Attribute("filetitle").Value == SelectedTargetFileTitle)
                        {
                            foreach (XElement itemfileSrc in itemfile.Descendants("fileSrc"))
                            {
                                if (itemfileSrc.Attribute("srcfile").Value == SelectedSourceFileName && itemfileSrc.Attribute("srcid").Value == SelectedSourceFileNo)
                                {
                                    foreach (XElement itemfilecols in itemfileSrc.Nodes())
                                    {
                                        if (itemfilecols.Attribute("cid").Value == UC_DataSetting.SelectedFileFieldNo && itemfilecols.Attribute("label").Value == UC_DataSetting.SelectedTXTColumnName)
                                        {
                                            foreach (XElement itemdict in itemfilecols.Descendants("dict"))
                                            {
                                                if (itemdict.Attribute("dictid").Value == item.Cells[0].Value.ToString())
                                                {
                                                    itemdict.Remove();
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
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
                    if (xNode.Attribute("value").Value.Equals(kCombTradeID.Text.ToString()))
                    //if (xNode.Attribute("value").Value.Equals(kCombTradeID.SelectedItem.ToString()))
                    {
                        //GlobalData.TemplateConfigInfo = new XElement(xNode);
                        GlobalData.TemplateConfigInfo = xNode;
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
                tableLayoutPanelSourceFile.Enabled = true;
                tableLayoutPanelKeyWords.Enabled = true;

                tableLayoutPanelFileField.Enabled = false;
                tableLayoutPanelFilter.Enabled = false;
                tableLayoutPanelDict.Enabled = false;

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
                        string IsOutPut = string.Empty;
                        if (kDGVFileList.Rows[e.RowIndex].Cells[0].Value == null || (!kDGVFileList.Rows[e.RowIndex].Cells[0].Value.ToString().ToLower().Equals("true")))
                        {
                            kDGVFileList.Rows[e.RowIndex].Cells[0].Value = true;
                            IsOutPut = "是";
                        }
                        else
                        {
                            kDGVFileList.Rows[e.RowIndex].Cells[0].Value = false;
                            IsOutPut = "否";
                        }
                        
                       // string OrganizationName = kDGVFileList.Rows[e.RowIndex].Cells[1].Value.ToString();
                        string FileNo = kDGVFileList.Rows[e.RowIndex].Cells[2].Value.ToString();
                        foreach (XElement xNode in _configDocument.Descendants("AccountId"))
                        {
                            if (xNode.Attribute("value").Value.Equals(kCombTradeID.SelectedItem.ToString()))
                            {
                                foreach (XElement itemFileNode in xNode.Descendants("OrganCode"))
                                {
                                    foreach (XElement file in itemFileNode.Nodes())
                                    {
                                        if (file.Attribute("fid").Value.ToString().Equals(FileNo))
                                        {
                                            file.SetAttributeValue("IsOutPut", IsOutPut);
                                            break;
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
                if (e.RowIndex > -1)
                {
                    tableLayoutPanelFileField.Enabled = true;

                    tableLayoutPanelFilter.Enabled = false;
                    tableLayoutPanelDict.Enabled = false;
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
                    string SourceFileNo = this.kDGVSourceFileList.Rows[e.RowIndex].Cells["SourceFileNo"].Value.ToString();
                    SelectedSourceFileName = SourceFileName;
                    SelectedSourceFileNo = SourceFileNo;
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
                                            if (itemFilecols.Attribute("srcfile").Value.Equals(SourceFileName) && itemFilecols.Attribute("srcid").Value.Equals(SelectedSourceFileNo))
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
            try
            {
                if (e.RowIndex > -1)
                {
                    tableLayoutPanelFilter.Enabled = true;
                    tableLayoutPanelDict.Enabled = true;
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
                    string SourceFileNo = SelectedSourceFileNo;

                    string TXTColumnName = this.kDGVFileWordsList.Rows[e.RowIndex].Cells["FileFieldTXTColumnName"].Value.ToString();
                    string FileFieldNo = this.kDGVFileWordsList.Rows[e.RowIndex].Cells["FileFieldNo"].Value.ToString();
                    SelectedTXTColumnName = TXTColumnName;
                    SelectedFileFieldNo = FileFieldNo;

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
                                            if (itemFilecols.Attribute("srcfile").Value.Equals(SourceFileName) && itemFilecols.Attribute("srcid").Value.Equals(SourceFileNo))
                                            {
                                                foreach (XElement item in itemFilecols.Nodes())
                                                {
                                                    if (item.Attribute("label").Value.Equals(TXTColumnName) && item.Attribute("cid").Value.Equals(FileFieldNo))
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
            }
            catch(Exception ex)
            {
                throw;
            }
            
        }
        private void kDGVFilter_CellClick(object sender, DataGridViewCellEventArgs e)
        {

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
                            foreach (XElement itemfile in GlobalData.TemplateConfigInfo.Descendants("file"))
                            {
                                if (itemfile.Attribute("filetitle").Value == item.Cells[3].Value.ToString())
                                {
                                    itemfile.Attribute("IsOutPut").Value = "是";
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (DataGridViewRow item in kDGVFileList.Rows)
                        {
                            item.Cells[0].Value = false;
                            foreach (XElement itemfile in GlobalData.TemplateConfigInfo.Descendants("file"))
                            {
                                if (itemfile.Attribute("filetitle").Value == item.Cells[3].Value.ToString())
                                {
                                    itemfile.Attribute("IsOutPut").Value = "否";
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
        }
        private void kBtnZJPath1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            path.ShowDialog();
            this.kTxtZJPath1.Text = this.kTxtJKZXPath1.Text = path.SelectedPath;
        }

        private void kBtnJKZXPath1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            path.ShowDialog();
            this.kTxtJKZXPath1.Text = path.SelectedPath;
        }

        private void kBtnZJPath2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            path.ShowDialog();
            this.kTxtZJPath2.Text = this.kTxtJKZXPath2.Text = path.SelectedPath;

        }

        private void kBtnJKZXPath2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            path.ShowDialog();
            this.kTxtJKZXPath2.Text = path.SelectedPath;
        }

        private void kryptonButtonSaveConfig_Click(object sender, EventArgs e)
        {
            string ConfigFileName = GlobalData.GetDataConfigPath(kCombAccount.SelectedItem.ToString());
            _configDocument.Save(ConfigFileName);
            MessageBox.Show("保存成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //bool Exist = false;
            //foreach (XElement xNode in _configDocument.Descendants("AccountId"))
            //{
            //    if (xNode.Attribute("value").Value.Equals(kCombTradeID.SelectedItem.ToString()))
            //    {
            //        Exist = true;
            //        xNode.ReplaceAll(GlobalData.TemplateConfigInfo);
            //        break;
            //    }
            //}
            //if (!Exist)
            //{
            //    _configDocument.Root.Add(GlobalData.TemplateConfigInfo);
            //}
        }

        private void kRBtnDate_Click(object sender, EventArgs e)
        {
            //点击按日期的时候，界面就自动选择按账号了
            //GlobalData.TemplateConfigInfo.Attribute("outType").Value = "1";
        }

        private void kRBtnAccount_CheckedChanged(object sender, EventArgs e)
        {
            bool ByAccount = kRBtnAccount.Checked;  //资金账号被勾选
            if (ByAccount)
            {
                GlobalData.TemplateConfigInfo.Attribute("outType").Value = "2";
            }
            else
            {
                GlobalData.TemplateConfigInfo.Attribute("outType").Value = "1";
            }
        }

        private void kCombTradeID_DataSourceChanged(object sender, EventArgs e)
        {
            List<string> _list = new List<string>();
            _list =   this.kCombTradeID.DataSource as List<string>;
            AppDatas.ListData = _list;
            // UC_GeneFile _uC_GeneFile = new UC_GeneFile();
            //_uC_GeneFile.RefreshSingleFundAcconutNo(_list);
            
        }
    }
}
