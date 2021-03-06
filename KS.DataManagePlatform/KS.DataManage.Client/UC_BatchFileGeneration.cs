﻿using ComponentFactory.Krypton.Toolkit;
using KS.DataManage.Controls;
using KS.DataManage.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace KS.DataManagePlatform
{
    public partial class BatchFileGeneration11 : KryptonForm
    {
        bool SingleFileIsSuccess = true;
        bool MergeFileIsSuccess = true;
        public BatchFileGeneration11()
        {
            InitializeComponent();
            //DataTable dt = new DataTable();
            //dt.Columns.Add("DataName", typeof(System.Boolean));
            //dt.Columns.Add("DataStatus", typeof(System.String)); //var s = new DataColumn(); s.
            //dt.Columns.Add("DataTime", typeof(System.String));
            //dt.Columns.Add("DataRemark", typeof(System.String));


            //string ConfigFileName = GlobalData.SysConfigPath;
            //XDocument configDocument = XDocument.Load(ConfigFileName);
            //foreach (XElement item in configDocument.Descendants("GROUPDATA"))
            //{
            //    DataRow dr = dt.NewRow();
            //    dr["DataName"] = item.Attribute("TABNAME").Value;
            //}f

        }
        public BatchFileGeneration11(TreeNodeCollection Nodes)
        {
            InitializeComponent();
            DataTable dt = new DataTable();
            dt.Columns.Add("DataName", typeof(System.String));
            dt.Columns.Add("DataStatus", typeof(System.String)); //var s = new DataColumn(); s.
            dt.Columns.Add("DataTime", typeof(System.String));
            dt.Columns.Add("DataRemark", typeof(System.String));

            foreach (TreeNode item in Nodes)
            {
                DataRow dr = dt.NewRow();
                dr["DataName"] = item.Text;
                dt.Rows.Add(dr);
            }
            dataGridView.DataSource = dt;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOneTouch_Click(object sender, EventArgs e)
        {
         
            
            foreach (DataGridViewRow itemRows in dataGridView.Rows)
            {
                if (itemRows.Cells[0].Value == null || !itemRows.Cells[0].Value.ToString().ToLower().Equals("true"))
                {
                    continue;
                }
                else
                {
                    Task taskGroup = new Task(() =>
                    {
                        if (this.InvokeRequired)
                        {
                            this.Invoke(new Action(() =>
                            {
                                #region 每组生成
                                string UserConfig = GlobalData.GetGeneConfigPath(itemRows.Cells[1].Value.ToString());
                                if (!File.Exists(UserConfig))
                                {
                                    KryptonMessageBox.Show(string.Format("配置文件 {0} 不存在！", UserConfig), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    Log.Error(string.Format("配置文件 {0} 不存在！", UserConfig));
                                    return;
                                }
                                XDocument UserConfigDocument = XDocument.Load(UserConfig);
                                XElement xroot = UserConfigDocument.Root;//根节点

                                string ag = xroot.Descendants().FirstOrDefault(a => a.Name.LocalName == "cfmmcpath2").Value;
                                string OriginPath = xroot.Descendants().FirstOrDefault(a => a.Name.LocalName == "srcpath").Value;
                                string CffexOutPath1 = xroot.Descendants().FirstOrDefault(a => a.Name.LocalName == "cffexpath1").Value;
                                string CffexOutPath2 = xroot.Descendants().FirstOrDefault(a => a.Name.LocalName == "cffexpath2").Value;
                                string MonitorCenterOutPath1 = xroot.Descendants().FirstOrDefault(a => a.Name.LocalName == "cfmmcpath1").Value;
                                string MonitorCenterOutPath2 = xroot.Descendants().FirstOrDefault(a => a.Name.LocalName == "cfmmcpath2").Value;


                                List<string> SingleCffexAccount = new List<string>();
                                List<string> SingleMotorCenterAccount = new List<string>();
                                List<string> MergeCffexAccount = new List<string>();
                                List<string> MergeMotorCenterAccount = new List<string>();

                                foreach (XElement itemAccId in UserConfigDocument.Descendants("CFFEX"))
                                {
                                    SingleCffexAccount.Add(itemAccId.Value);
                                }
                                foreach (XElement itemAccId in UserConfigDocument.Descendants("CFMMC"))
                                {
                                    SingleMotorCenterAccount.Add(itemAccId.Value);
                                }
                                foreach (XElement itemAccId in UserConfigDocument.Descendants("CFFEXMERGE"))
                                {
                                    MergeCffexAccount.Add(itemAccId.Value);

                                }
                                foreach (XElement itemAccId in UserConfigDocument.Descendants("CFMMCMERGE"))
                                {
                                    MergeMotorCenterAccount.Add(itemAccId.Value);
                                }

                                //foreach (XElement itemAccId in UserConfigDocument.Descendants("AccId"))
                                //{

                                //    if (itemAccId.Name.ToString() == "CFFEX")
                                //    {
                                //        SingleCffexAccount.Add(itemAccId.Value);
                                //    }
                                //    if (itemAccId.Name.ToString() == "CFMMC")
                                //    {
                                //        SingleMotorCenterAccount.Add(itemAccId.Value);
                                //    }
                                //    if (itemAccId.Name.ToString() == "CFFEXMERGE")
                                //    {
                                //        MergeCffexAccount.Add(itemAccId.Value);
                                //    }
                                //    if (itemAccId.Name.ToString() == "CFMMCMERGE")
                                //    {
                                //        MergeMotorCenterAccount.Add(itemAccId.Value);
                                //    }
                                //}
                                //if (kryCLBSingleMotorCenterAccount.CheckedItems.Count == 0)
                                //{
                                //    MessageBox.Show("未选中资金账号", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //    return;
                                //}

                                this.SuspendLayout();
                                string ConfigFileName = GlobalData.GetDataConfigPath(itemRows.Cells[1].Value.ToString());
                                if (!File.Exists(ConfigFileName))
                                {
                                    KryptonMessageBox.Show(string.Format("配置文件 {0} 不存在！", ConfigFileName), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    Log.Error(string.Format("配置文件 {0} 不存在！", ConfigFileName));
                                    return;
                                }
                                XDocument configDocument = XDocument.Load(ConfigFileName);
                                try
                                {
                                    XElement configRoot = configDocument.Root;

                                    string targetDBFFileName = string.Empty;
                                    string targetDBFDirectoryName = string.Empty;
                                    string targetFileName = string.Empty;
                                    string targetDirectoryName = string.Empty;
                                    string targetDirectoryName1 = string.Empty;
                                    string SourceFileName = string.Empty;


                                    FrmWait _frmWait = new FrmWait();
                                    //_frmWait.ShowDialog();
                                    try
                                    {

                                        //krypLbFlag.Visible = true;
                                        //krypLbFlag.Text = "读入原文件开始...";
                                        //临时测试用


                                        #region 业务逻辑处理 单账号生成
                                        Task task = new Task(() =>
                                        {
                                            if (this.InvokeRequired)
                                            {
                                                //this.BeginInvoke((Action)delegate ()
                                                //{
                                                //    _frmWait.ShowDialog();
                                                //});
                                                this.Invoke(new Action(() =>
                                                {
                                                    //生成中金所

                                                    foreach (string itemSingleCffexAccount in SingleCffexAccount)
                                                    {
                                                        foreach (XElement itemAccountId in configDocument.Descendants("AccountId"))
                                                        {
                                                            if (itemAccountId.Attribute("value").Value == itemSingleCffexAccount)
                                                            {
                                                                if (itemAccountId.Attribute("cffexFile").Equals("0")) //不生成中金所文件
                                                                {
                                                                    return;
                                                                }
                                                                foreach (XElement itemOrganCode in itemAccountId.Descendants("OrganCode"))
                                                                {

                                                                    if (itemOrganCode.Attribute("name").Value == "中金所")
                                                                    {
                                                                        foreach (XElement itemfile in itemOrganCode.Nodes())
                                                                        {
                                                                            string str = "其中：交易保证金               635757  "; //我们抓取当前字符当中的123.11
                                                                            str = Regex.Replace(str, @"[^\d.\d]", "");

                                                                            bool sdg = Regex.IsMatch(str, @"\d+$");
                                                                            if ((itemfile.Attribute("filetitle").Value == "会员资金情况表") && itemfile.Attribute("fileext").Value == "DBF")
                                                                            {

                                                                            }
                                                                            if (itemfile.Attribute("fileext").Value == "DBF") //此时过滤之后，能进入到下面的dbf文件。只有会员资金情况表
                                                                            {
                                                                                if (itemfile.Attribute("filetitle").Value != "会员资金情况表")
                                                                                {
                                                                                    continue;
                                                                                }
                                                                            }

                                                                            List<string> colnumName = new List<string>();
                                                                            List<string> colnumNameTMP = new List<string>();
                                                                            //List<string> colnumValue = new List<string>();
                                                                            //Dictionary<int, string> colnumValueFinal = new Dictionary<int, string>();
                                                                            List<Dictionary<int, string>> colnumValueFinal = new List<Dictionary<int, string>>();
                                                                            DataTable dtResult = new DataTable();
                                                                            DataTable dt = new DataTable();
                                                                            List<string> DBFColumnNamelist = new List<string>();
                                                                            bool IsTransverse = false;  //是否横向的标志
                                                                            bool IsOutColumn = false;

                                                                            if (itemfile.Attribute("fileext").Value == "DBF" && itemfile.Attribute("filetitle").Value == "会员资金情况表") //单独处理会员资金情况表的dbf文件，设计思路是先生成一个这个dbf文件的txt文件
                                                                            {
                                                                                if (itemAccountId.Attribute("outType").Value.Equals("1"))  //按日期导出at
                                                                                {
                                                                                    string targetFile = (itemfile.Attribute("filename").Value.ToString().Replace("{accountid}", itemSingleCffexAccount)).Replace("{tradingday}", kryDTPDate.Value.ToString("yyyyMMdd")) + "Temp";
                                                                                    string DBFtargetFile = (itemfile.Attribute("filename").Value.ToString().Replace("{accountid}", itemSingleCffexAccount)).Replace("{tradingday}", kryDTPDate.Value.ToString("yyyyMMdd"));
                                                                                    targetFileName = Path.Combine(MonitorCenterOutPath1.ToString() + "\\" + string.Format(@"{0}\中金所格式\TXT文件\{1}\{2}.txt", kryDTPDate.Value.ToString("yyyyMMdd"), itemSingleCffexAccount, targetFile));
                                                                                    targetDirectoryName = Path.Combine(MonitorCenterOutPath1.ToString() + "\\" + string.Format(@"{0}\中金所格式\TXT文件\{1}", kryDTPDate.Value.ToString("yyyyMMdd"), itemSingleCffexAccount));
                                                                                    targetDirectoryName1 = Path.Combine(MonitorCenterOutPath2.ToString() + "\\" + string.Format(@"{0}\中金所格式\TXT文件\{1}", kryDTPDate.Value.ToString("yyyyMMdd"), itemSingleCffexAccount));

                                                                                    targetDBFDirectoryName = Path.Combine(MonitorCenterOutPath1.ToString() + "\\" + string.Format(@"{0}\中金所格式\DBF文件\{1}", kryDTPDate.Value.ToString("yyyyMMdd"), itemSingleCffexAccount));
                                                                                    targetDBFFileName = Path.Combine(MonitorCenterOutPath1.ToString() + "\\" + string.Format(@"{0}\中金所格式\DBF文件\{1}\{2}.dbf", kryDTPDate.Value.ToString("yyyyMMdd"), itemSingleCffexAccount, DBFtargetFile));
                                                                                }
                                                                                else   //按账号导出
                                                                                {
                                                                                    string targetFile = (itemfile.Attribute("filename").Value.ToString().Replace("{accountid}", itemSingleCffexAccount)).Replace("{tradingday}", kryDTPDate.Value.ToString("yyyyMMdd")) + "Temp";
                                                                                    string DBFtargetFile = (itemfile.Attribute("filename").Value.ToString().Replace("{accountid}", itemSingleCffexAccount)).Replace("{tradingday}", kryDTPDate.Value.ToString("yyyyMMdd"));
                                                                                    targetFileName = Path.Combine(MonitorCenterOutPath1.ToString() + "\\" + string.Format(@"{0}\中金所格式\TXT文件\{1}\{2}.txt", itemSingleCffexAccount, kryDTPDate.Value.ToString("yyyyMMdd"), targetFile));
                                                                                    targetDirectoryName = Path.Combine(MonitorCenterOutPath1.ToString() + "\\" + string.Format(@"{0}\中金所格式\TXT文件\{1}", itemSingleCffexAccount, kryDTPDate.Value.ToString("yyyyMMdd")));
                                                                                    targetDirectoryName1 = Path.Combine(MonitorCenterOutPath2.ToString() + "\\" + string.Format(@"{0}\中金所格式\TXT文件\{1}", itemSingleCffexAccount, kryDTPDate.Value.ToString("yyyyMMdd")));

                                                                                    targetDBFDirectoryName = Path.Combine(MonitorCenterOutPath1.ToString() + "\\" + string.Format(@"{0}\中金所格式\DBF文件\{1}", itemSingleCffexAccount, kryDTPDate.Value.ToString("yyyyMMdd")));
                                                                                    targetDBFFileName = Path.Combine(MonitorCenterOutPath1.ToString() + "\\" + string.Format(@"{0}\中金所格式\DBF文件\{1}\{2}.dbf", itemSingleCffexAccount, kryDTPDate.Value.ToString("yyyyMMdd"), DBFtargetFile));
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                if (itemAccountId.Attribute("outType").Value.Equals("1"))  //按日期导出at
                                                                                {
                                                                                    string targetFile = (itemfile.Attribute("filename").Value.ToString().Replace("{accountid}", itemSingleCffexAccount)).Replace("{tradingday}", kryDTPDate.Value.ToString("yyyyMMdd"));
                                                                                    targetFileName = Path.Combine(MonitorCenterOutPath1.ToString() + "\\" + string.Format(@"{0}\中金所格式\TXT文件\{1}\{2}.txt", kryDTPDate.Value.ToString("yyyyMMdd"), itemSingleCffexAccount, targetFile));
                                                                                    targetDirectoryName = Path.Combine(MonitorCenterOutPath1.ToString() + "\\" + string.Format(@"{0}\中金所格式\TXT文件\{1}", kryDTPDate.Value.ToString("yyyyMMdd"), itemSingleCffexAccount));
                                                                                    targetDirectoryName1 = Path.Combine(MonitorCenterOutPath2.ToString() + "\\" + string.Format(@"{0}\中金所格式\TXT文件\{1}", kryDTPDate.Value.ToString("yyyyMMdd"), itemSingleCffexAccount));

                                                                                    targetDBFDirectoryName = Path.Combine(MonitorCenterOutPath1.ToString() + "\\" + string.Format(@"{0}\中金所格式\DBF文件\{1}", kryDTPDate.Value.ToString("yyyyMMdd"), itemSingleCffexAccount));
                                                                                    targetDBFFileName = Path.Combine(MonitorCenterOutPath1.ToString() + "\\" + string.Format(@"{0}\中金所格式\DBF文件\{1}\{2}.dbf", kryDTPDate.Value.ToString("yyyyMMdd"), itemSingleCffexAccount, targetFile));
                                                                                }
                                                                                else   //按账号导出
                                                                                {
                                                                                    string targetFile = (itemfile.Attribute("filename").Value.ToString().Replace("{accountid}", itemSingleCffexAccount)).Replace("{tradingday}", kryDTPDate.Value.ToString("yyyyMMdd"));
                                                                                    targetFileName = Path.Combine(MonitorCenterOutPath1.ToString() + "\\" + string.Format(@"{0}\中金所格式\TXT文件\{1}\{2}.txt", itemSingleCffexAccount, kryDTPDate.Value.ToString("yyyyMMdd"), targetFile));
                                                                                    targetDirectoryName = Path.Combine(MonitorCenterOutPath1.ToString() + "\\" + string.Format(@"{0}\中金所格式\TXT文件\{1}", itemSingleCffexAccount, kryDTPDate.Value.ToString("yyyyMMdd")));
                                                                                    targetDirectoryName1 = Path.Combine(MonitorCenterOutPath2.ToString() + "\\" + string.Format(@"{0}\中金所格式\TXT文件\{1}", itemSingleCffexAccount, kryDTPDate.Value.ToString("yyyyMMdd")));

                                                                                    targetDBFDirectoryName = Path.Combine(MonitorCenterOutPath1.ToString() + "\\" + string.Format(@"{0}\中金所格式\DBF文件\{1}", itemSingleCffexAccount, kryDTPDate.Value.ToString("yyyyMMdd")));
                                                                                    targetDBFFileName = Path.Combine(MonitorCenterOutPath1.ToString() + "\\" + string.Format(@"{0}\中金所格式\DBF文件\{1}\{2}.dbf", itemSingleCffexAccount, kryDTPDate.Value.ToString("yyyyMMdd"), targetFile));
                                                                                }
                                                                            }

                                                                            if (!Directory.Exists(targetDirectoryName))
                                                                            {
                                                                                Directory.CreateDirectory(targetDirectoryName);
                                                                            }
                                                                            if (!Directory.Exists(targetDBFDirectoryName))
                                                                            {
                                                                                Directory.CreateDirectory(targetDBFDirectoryName);
                                                                            }
                                                                            if (File.Exists(targetFileName))
                                                                            {
                                                                                File.Delete(targetFileName);
                                                                            }
                                                                            if (File.Exists(targetDBFFileName))
                                                                            {
                                                                                File.Delete(targetDBFFileName);
                                                                            }

                                                                            if (itemfile.Attribute("IsOutPut").Value == "否")
                                                                            {
                                                                                continue;
                                                                            }
                                                                            using (FileStream fsTargetFile = new FileStream(targetFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                                                                            {
                                                                                using (StreamWriter swTargetFile = new StreamWriter(fsTargetFile))
                                                                                {
                                                                                    string info = itemfile.Attribute("filetitle").Value.ToString().PadLeft(30) + "\r\n" + "\r\n" + string.Format("结算会员号：{0}", GlobalData.SGMemberID/*0102*/).PadRight(30) + string.Format("结算会员名称：{0}", GlobalData.CompanyName/*"abc公司"*/).PadRight(30) + string.Format("结算日期：{0}", kryDTPDate.Value.ToString("yyyyMMdd")).PadRight(30) + "\n";
                                                                                    swTargetFile.Write(info);

                                                                                }
                                                                            }
                                                                            #region 设置datatable及要生成的列名
                                                                            foreach (XElement itemfileSrc in itemfile.Descendants("fileSrc"))
                                                                            {
                                                                                //生成横线行
                                                                                if (string.IsNullOrEmpty(itemfileSrc.Attribute("srcfile").Value))
                                                                                {
                                                                                    try
                                                                                    {
                                                                                        IsTransverse = true;
                                                                                        using (StreamWriter swTargetFile = File.AppendText(targetFileName))
                                                                                        {
                                                                                            string line = string.Empty;
                                                                                            foreach (XElement itemfilecols in itemfileSrc.Nodes())
                                                                                            {
                                                                                                char padstr = string.IsNullOrEmpty(itemfilecols.Attribute("padstr").Value.Trim()) ? (' ') : (itemfilecols.Attribute("padstr").Value.Trim().ToCharArray()[0]);
                                                                                                if (string.IsNullOrEmpty(itemfilecols.Attribute("FixValue").Value))
                                                                                                {
                                                                                                    line = "";
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    line += itemfilecols.Attribute("FixValue").Value.PadRight(int.Parse(itemfilecols.Attribute("vlength").Value), (padstr));
                                                                                                }

                                                                                                if (itemfilecols.Attribute("isout").Value == "否")
                                                                                                {
                                                                                                    line = "";
                                                                                                }
                                                                                            }
                                                                                            swTargetFile.WriteLine(line);
                                                                                        }
                                                                                        continue;
                                                                                    }
                                                                                    catch (Exception ex)
                                                                                    {
                                                                                        SingleFileIsSuccess = false;
                                                                                        MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                                        return;
                                                                                    }

                                                                                }
                                                                                foreach (XElement itemfilecols in itemfileSrc.Nodes())
                                                                                {
                                                                                    if (dtResult.Columns.Count == 0)
                                                                                    {
                                                                                        dtResult.Columns.Add(itemfilecols.Attribute("label").Value, typeof(System.String));
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        if (!dtResult.Columns.Contains(itemfilecols.Attribute("label").Value))
                                                                                        {
                                                                                            dtResult.Columns.Add(itemfilecols.Attribute("label").Value, typeof(System.String));
                                                                                        }
                                                                                    }
                                                                                    if (itemfilecols.Attribute("isout").Value == "是" && itemfile.Attribute("arrangeType").Value == "纵向")
                                                                                    {
                                                                                        if (DBFColumnNamelist.Count == 0)
                                                                                        {
                                                                                            DBFColumnNamelist.Add(itemfilecols.Attribute("code").Value);
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            if (!DBFColumnNamelist.Contains(itemfilecols.Attribute("code").Value))
                                                                                            {
                                                                                                DBFColumnNamelist.Add(itemfilecols.Attribute("code").Value);
                                                                                            }
                                                                                        }
                                                                                    }

                                                                                }
                                                                                if (itemfileSrc.Attribute("srcfileType").Value.Equals("监控中心"))
                                                                                {
                                                                                    SourceFileName = Path.Combine(OriginPath.ToString() + "\\" + kryDTPDate.Value.ToString("yyyyMMdd") + string.Format("\\{0}{1}{2}.txt", GlobalData.SeatNo, itemfileSrc.Attribute("srcfile").Value, kryDTPDate.Value.ToString("yyyyMMdd")));
                                                                                }
                                                                                else if (itemfileSrc.Attribute("srcfileType").Value.Equals("交易所"))
                                                                                {
                                                                                    SourceFileName = Path.Combine(OriginPath.ToString() + "\\" + kryDTPDate.Value.ToString("yyyyMMdd") + string.Format("\\{0}.DBF", itemfileSrc.Attribute("srcfile").Value));

                                                                                    SourceFileName = SourceFileName.Replace("{tradingday}", kryDTPDate.Value.ToString("yyyyMMdd"));
                                                                                    //读dbf
                                                                                    try
                                                                                    {
                                                                                        TDbfReader dbfFile = new TDbfReader(SourceFileName);
                                                                                        //dbfFile.SaveToTXT();
                                                                                        dt = dbfFile.Table;
                                                                                    }
                                                                                    catch (Exception ex)
                                                                                    {
                                                                                        SingleFileIsSuccess = false;
                                                                                        MessageBox.Show(this, ex.Message, "加载DBF失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                                        return;
                                                                                    }

                                                                                    //int iIndex = SourceFileName.LastIndexOf('\\');
                                                                                    //string strConn = @"Provider=vfpoledb;Data Source=" + SourceFileName.Substring(0, iIndex) + ";Collating Sequence=machine;";
                                                                                    //try
                                                                                    //{
                                                                                    //    using (OleDbConnection oleCon = new OleDbConnection(strConn))
                                                                                    //    {
                                                                                    //        oleCon.Open();
                                                                                    //        //if (string.IsNullOrEmpty(sSQL))
                                                                                    //        string sSQL = "SELECT * FROM " + SourceFileName.Substring(iIndex + 1);

                                                                                    //        OleDbDataAdapter adapter = new OleDbDataAdapter(sSQL, oleCon);

                                                                                    //        DataTable dt = new DataTable();
                                                                                    //        adapter.Fill(dt);

                                                                                    //        //return dt;
                                                                                    //    }
                                                                                    //}
                                                                                    //catch (System.Exception ex)
                                                                                    //{
                                                                                    //    MessageBox.Show(this, ex.Message, "加载DBF失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                                    //   // return null;
                                                                                    //}
                                                                                }


                                                                                if (!File.Exists(SourceFileName))
                                                                                {
                                                                                    MessageBox.Show(string.Format("{0}文件不存在", itemfile.Attribute("filetitle").Value), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                                    continue;
                                                                                }
                                                                                if (itemfileSrc.Attribute("srcfileType").Value.Equals("监控中心"))
                                                                                {
                                                                                    //if (colnumName.Count  > 0 &&  !colnumName.Contains(itemfileSrc.Attribute("label").Value))
                                                                                    //{
                                                                                    //    colnumName.Add(itemfileSrc.Attribute("label").Value);
                                                                                    //}
                                                                                    if (IsTransverse && !IsOutColumn)
                                                                                    {
                                                                                        //横线行输出的。线输出列
                                                                                        using (StreamWriter swTargetFile = File.AppendText(targetFileName))
                                                                                        {
                                                                                            foreach (XElement itemfilecols in itemfileSrc.Nodes())
                                                                                            {
                                                                                                string line = string.Empty;
                                                                                                if (!string.IsNullOrEmpty(itemfilecols.Attribute("isout").Value.Trim()))   //是否输出
                                                                                                {
                                                                                                    if (itemfilecols.Attribute("isout").Value.Trim() == "否")
                                                                                                    {
                                                                                                        line = "";
                                                                                                    }
                                                                                                    else
                                                                                                    {
                                                                                                        if (!string.IsNullOrEmpty(itemfilecols.Attribute("tlength").Value) && (int.Parse(itemfilecols.Attribute("tlength").Value.Trim()) > 0)) //列名位数 +对齐方式
                                                                                                        {
                                                                                                            string align = itemfilecols.Attribute("align").Value;

                                                                                                            line = dtResult.Columns[int.Parse(itemfilecols.Attribute("cid").Value.Trim())].ToString().Trim().PadRight(int.Parse(itemfilecols.Attribute("tlength").Value.Trim()), ' ');//以空格填充
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                                swTargetFile.WriteLine(line);
                                                                                            }
                                                                                            IsOutColumn = true;
                                                                                        }
                                                                                    }

                                                                                    using (FileStream fsSourceFile = new FileStream(SourceFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                                                                                    {
                                                                                        using (StreamReader swSourceFile = new StreamReader(fsSourceFile))
                                                                                        {
                                                                                            string line = string.Empty;

                                                                                            while ((line = swSourceFile.ReadLine()) != null)
                                                                                            {
                                                                                                string[] sArray = line.Split('@');

                                                                                                if (sArray[0] == kryDTPDate.Value.ToString("yyyy-MM-dd") && sArray[1] == itemSingleCffexAccount)
                                                                                                {
                                                                                                    try
                                                                                                    {
                                                                                                        Dictionary<int, string> colnumValue = new Dictionary<int, string>();
                                                                                                        DataRow dr = dtResult.NewRow();

                                                                                                        //为中国金融期货交易所 客户分项资金明细表做的特殊处理，因为他里面的字段索引cid从1 开始 ，已改成从0开始
                                                                                                        if (itemfile.Attribute("filetitle").Value.ToString() == "中国金融期货交易所 客户分项资金明细表")
                                                                                                        {

                                                                                                            foreach (XElement itemfilecols in itemfileSrc.Nodes())
                                                                                                            {
                                                                                                                //dtResult.Columns.Add(itemfilecols.Attribute("label").Value, typeof(System.String));

                                                                                                                if (colnumName.Count == 0)
                                                                                                                {
                                                                                                                    colnumName.Add(itemfilecols.Attribute("label").Value);
                                                                                                                    colnumNameTMP.Add(itemfilecols.Attribute("label").Value);
                                                                                                                }
                                                                                                                else
                                                                                                                {
                                                                                                                    if (!colnumNameTMP.Contains(itemfilecols.Attribute("label").Value.Trim()))
                                                                                                                    {
                                                                                                                        colnumName.Add(itemfilecols.Attribute("label").Value);
                                                                                                                        colnumNameTMP.Add(itemfilecols.Attribute("label").Value);
                                                                                                                    }
                                                                                                                }
                                                                                                                if (!string.IsNullOrEmpty(itemfilecols.Attribute("isout").Value.Trim()))   //是否输出
                                                                                                                {
                                                                                                                    if (itemfilecols.Attribute("isout").Value.Trim() == "否")
                                                                                                                    {
                                                                                                                        colnumName[int.Parse(itemfilecols.Attribute("cid").Value.Trim())] = "";
                                                                                                                    }
                                                                                                                    else
                                                                                                                    {
                                                                                                                        if (!string.IsNullOrEmpty(itemfilecols.Attribute("tlength").Value) && (int.Parse(itemfilecols.Attribute("tlength").Value.Trim()) > 0)) //列名位数 +对齐方式
                                                                                                                        {
                                                                                                                            string align = itemfilecols.Attribute("align").Value;

                                                                                                                            if (!string.IsNullOrEmpty(align) && align.Equals("左"))
                                                                                                                            {
                                                                                                                                colnumName[int.Parse(itemfilecols.Attribute("cid").Value.Trim())] = colnumName[int.Parse(itemfilecols.Attribute("cid").Value.Trim())].Trim().PadRight(int.Parse(itemfilecols.Attribute("tlength").Value.Trim()), ' ');//以空格填充
                                                                                                                            }
                                                                                                                            if (!string.IsNullOrEmpty(align) && align.Equals("右"))
                                                                                                                            {
                                                                                                                                colnumName[int.Parse(itemfilecols.Attribute("cid").Value.Trim())] = colnumName[int.Parse(itemfilecols.Attribute("cid").Value.Trim())].Trim().PadLeft(int.Parse(itemfilecols.Attribute("tlength").Value.Trim()), ' ');//以空格填充
                                                                                                                            }

                                                                                                                        }
                                                                                                                    }
                                                                                                                    //sArray[int.Parse(itemfilecols.Attribute("colIndex").Value) - 1] = Datafilecols;
                                                                                                                }

                                                                                                                string Datafilecols = string.Empty;
                                                                                                                if (!string.IsNullOrEmpty(itemfilecols.Attribute("colIndex").Value.Trim()))
                                                                                                                {
                                                                                                                    Datafilecols = sArray[int.Parse(itemfilecols.Attribute("colIndex").Value) - 1];

                                                                                                                    if (colnumValue.ContainsKey(int.Parse(itemfilecols.Attribute("cid").Value.ToString())))
                                                                                                                    {
                                                                                                                        Dictionary<int, string>.ValueCollection value = colnumValue.Values;

                                                                                                                        //string newValue = (int.Parse(colnumValue[int.Parse(itemfilecols.Attribute("cid").Value.ToString())]) + int.Parse(SGDealData(itemfilecols, Datafilecols, sArray))).ToString();

                                                                                                                        string newValue = (int.Parse(value.ElementAt(int.Parse(itemfilecols.Attribute("cid").Value.ToString()))) + int.Parse(SGDealData(itemfilecols, Datafilecols, sArray))).ToString();
                                                                                                                        colnumValue[int.Parse(itemfilecols.Attribute("cid").Value.ToString())] = newValue.Trim();

                                                                                                                        //string newValue = dr[int.Parse(itemfilecols.Attribute("cid").Value.ToString())].ToString() + Datafilecols;

                                                                                                                        dr[int.Parse(itemfilecols.Attribute("cid").Value.ToString())] = newValue.Trim();
                                                                                                                    }
                                                                                                                    else
                                                                                                                    {
                                                                                                                        colnumValue.Add(int.Parse(itemfilecols.Attribute("cid").Value.ToString()), SGDealData(itemfilecols, Datafilecols, sArray));
                                                                                                                        //dr[int.Parse(itemfilecols.Attribute("cid").Value.ToString())] = SGDealData(itemfilecols, Datafilecols, sArray);
                                                                                                                        if (!string.IsNullOrEmpty(itemfilecols.Attribute("express").Value.Trim().ToString()) && itemfilecols.Attribute("express").Value.Trim() == "-")
                                                                                                                        {
                                                                                                                            Datafilecols = "-" + Datafilecols.Trim();
                                                                                                                        }
                                                                                                                        dr[int.Parse(itemfilecols.Attribute("cid").Value.ToString())] = Datafilecols.Trim();
                                                                                                                    }
                                                                                                                }
                                                                                                                //sArray = SGDealData(itemfilecols, Datafilecols, sArray);
                                                                                                                if (sArray[0] == "数据处理出错")
                                                                                                                {
                                                                                                                    SingleFileIsSuccess = false;
                                                                                                                    MessageBox.Show(sArray[0], "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                                                                    return;
                                                                                                                }

                                                                                                            }
                                                                                                        }
                                                                                                        else  //普通的中金表
                                                                                                        {
                                                                                                            foreach (XElement itemfilecols in itemfileSrc.Nodes())
                                                                                                            {
                                                                                                                //dtResult.Columns.Add(itemfilecols.Attribute("label").Value, typeof(System.String));

                                                                                                                if (colnumName.Count == 0)
                                                                                                                {
                                                                                                                    colnumName.Add(itemfilecols.Attribute("label").Value);
                                                                                                                    colnumNameTMP.Add(itemfilecols.Attribute("label").Value);
                                                                                                                }
                                                                                                                else
                                                                                                                {
                                                                                                                    if (!colnumNameTMP.Contains(itemfilecols.Attribute("label").Value.Trim()))
                                                                                                                    {
                                                                                                                        colnumName.Add(itemfilecols.Attribute("label").Value);
                                                                                                                        colnumNameTMP.Add(itemfilecols.Attribute("label").Value);
                                                                                                                    }
                                                                                                                }
                                                                                                                if (!string.IsNullOrEmpty(itemfilecols.Attribute("isout").Value.Trim()))   //是否输出
                                                                                                                {
                                                                                                                    if (itemfilecols.Attribute("isout").Value.Trim() == "否")
                                                                                                                    {
                                                                                                                        colnumName[int.Parse(itemfilecols.Attribute("cid").Value.Trim())] = "";
                                                                                                                    }
                                                                                                                    else
                                                                                                                    {
                                                                                                                        if (!string.IsNullOrEmpty(itemfilecols.Attribute("tlength").Value) && (int.Parse(itemfilecols.Attribute("tlength").Value.Trim()) > 0)) //列名位数 +对齐方式
                                                                                                                        {
                                                                                                                            string align = itemfilecols.Attribute("align").Value;

                                                                                                                            if (!string.IsNullOrEmpty(align) && align.Equals("左"))
                                                                                                                            {
                                                                                                                                colnumName[int.Parse(itemfilecols.Attribute("cid").Value.Trim())] = colnumName[int.Parse(itemfilecols.Attribute("cid").Value.Trim())].Trim().PadRight(int.Parse(itemfilecols.Attribute("tlength").Value.Trim()), ' ');//以空格填充
                                                                                                                            }
                                                                                                                            if (!string.IsNullOrEmpty(align) && align.Equals("右"))
                                                                                                                            {
                                                                                                                                colnumName[int.Parse(itemfilecols.Attribute("cid").Value.Trim())] = colnumName[int.Parse(itemfilecols.Attribute("cid").Value.Trim())].Trim().PadLeft(int.Parse(itemfilecols.Attribute("tlength").Value.Trim()), ' ');//以空格填充
                                                                                                                            }

                                                                                                                        }
                                                                                                                    }
                                                                                                                    //sArray[int.Parse(itemfilecols.Attribute("colIndex").Value) - 1] = Datafilecols;
                                                                                                                }

                                                                                                                string Datafilecols = string.Empty;
                                                                                                                if (!string.IsNullOrEmpty(itemfilecols.Attribute("colIndex").Value.Trim()))
                                                                                                                {
                                                                                                                    Datafilecols = sArray[int.Parse(itemfilecols.Attribute("colIndex").Value) - 1];

                                                                                                                    if (colnumValue.ContainsKey(int.Parse(itemfilecols.Attribute("cid").Value.ToString())))
                                                                                                                    {
                                                                                                                        Dictionary<int, string>.ValueCollection value = colnumValue.Values;

                                                                                                                        //string newValue = (int.Parse(colnumValue[int.Parse(itemfilecols.Attribute("cid").Value.ToString())]) + int.Parse(SGDealData(itemfilecols, Datafilecols, sArray))).ToString();

                                                                                                                        string newValue = (int.Parse(value.ElementAt(int.Parse(itemfilecols.Attribute("cid").Value.ToString()))) + int.Parse(SGDealData(itemfilecols, Datafilecols, sArray))).ToString();
                                                                                                                        colnumValue[int.Parse(itemfilecols.Attribute("cid").Value.ToString())] = newValue.Trim();

                                                                                                                        //string newValue = dr[int.Parse(itemfilecols.Attribute("cid").Value.ToString())].ToString() + Datafilecols;

                                                                                                                        dr[int.Parse(itemfilecols.Attribute("cid").Value.ToString())] = newValue.Trim();
                                                                                                                    }
                                                                                                                    else
                                                                                                                    {
                                                                                                                        colnumValue.Add(int.Parse(itemfilecols.Attribute("cid").Value.ToString()), SGDealData(itemfilecols, Datafilecols, sArray));
                                                                                                                        //dr[int.Parse(itemfilecols.Attribute("cid").Value.ToString())] = SGDealData(itemfilecols, Datafilecols, sArray);
                                                                                                                        if (!string.IsNullOrEmpty(itemfilecols.Attribute("express").Value.Trim().ToString()) && itemfilecols.Attribute("express").Value.Trim() == "-")
                                                                                                                        {
                                                                                                                            Datafilecols = "-" + Datafilecols.Trim();
                                                                                                                        }
                                                                                                                        dr[int.Parse(itemfilecols.Attribute("cid").Value.ToString())] = Datafilecols.Trim();
                                                                                                                    }
                                                                                                                }
                                                                                                                //sArray = SGDealData(itemfilecols, Datafilecols, sArray);
                                                                                                                if (sArray[0] == "数据处理出错")
                                                                                                                {
                                                                                                                    SingleFileIsSuccess = false;
                                                                                                                    MessageBox.Show(sArray[0], "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                                                                    return;
                                                                                                                }

                                                                                                            }
                                                                                                        }

                                                                                                        // colnumValueFinal.Add(colnumValue);
                                                                                                        dtResult.Rows.Add(dr);
                                                                                                    }
                                                                                                    catch (Exception ex)
                                                                                                    {
                                                                                                        SingleFileIsSuccess = false;
                                                                                                        MessageBox.Show(itemfile.Attribute("filetitle") + ex.Message.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                                                        return;
                                                                                                    }
                                                                                                    try
                                                                                                    {
                                                                                                        if (IsTransverse)
                                                                                                        {
                                                                                                            List<string> txtLineList = new List<string>();
                                                                                                            using (FileStream fsTargentFileTemp = new FileStream(targetFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                                                                                                            {

                                                                                                                using (StreamReader srTargetFileTemp = new StreamReader(fsTargentFileTemp/*, Encoding.GetEncoding("GB2312")*/))
                                                                                                                {
                                                                                                                    string lineTemp;

                                                                                                                    while ((lineTemp = srTargetFileTemp.ReadLine()) != null)
                                                                                                                    {
                                                                                                                        txtLineList.Add(lineTemp);
                                                                                                                    }
                                                                                                                }

                                                                                                            }
                                                                                                            using (FileStream fsTargentFileTemp = new FileStream(targetFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                                                                                                            {
                                                                                                                using (StreamWriter swTargetFileTemp = new StreamWriter(fsTargentFileTemp/*,Encoding.GetEncoding("GB2312")*/))
                                                                                                                {
                                                                                                                    //double sumPercentage = dtResult.AsEnumerable().Where(dr => { return dtResult.Rows.IndexOf(dr) > 0; }).Sum(eee => Convert.ToDouble(eee.Field<String>("资金账号"))); //计算某一列的值总和
                                                                                                                    //string sdg = dtResult.Columns[0].ToString();
                                                                                                                    //double total = dtResult.AsEnumerable().Select(d => Convert.ToDouble(d.Field<string>(sdg))).Sum();

                                                                                                                    for (int i = 0; i < dtResult.Rows.Count; i++)
                                                                                                                    {
                                                                                                                        string WrinteInValue = string.Empty;
                                                                                                                        DataRow dr = dtResult.Rows[i];
                                                                                                                        foreach (XElement itemfilecols in itemfileSrc.Nodes())
                                                                                                                        {
                                                                                                                            WrinteInValue = dr[int.Parse(itemfilecols.Attribute("cid").Value.ToString())].ToString();
                                                                                                                            for (int j = 0; j < txtLineList.Count; j++)
                                                                                                                            {
                                                                                                                                if (txtLineList[j].Contains(itemfilecols.Attribute("label").Value))
                                                                                                                                {
                                                                                                                                    //string ReplaceStr = txtLineList[j].Substring((itemfilecols.Attribute("label").Value.Length  /*int.Parse(itemfilecols.Attribute("vlength").Value*/));

                                                                                                                                    //ReplaceStr = string.IsNullOrEmpty(ReplaceStr.Trim()) ? ("0") : (ReplaceStr.Trim());
                                                                                                                                    // WrinteInValue = string.IsNullOrEmpty(WrinteInValue.Trim()) ? ("0") : (WrinteInValue.Trim());

                                                                                                                                    //txtLineList[j] = txtLineList[j].Replace(txtLineList[j], txtLineList[j].Substring(0, (itemfilecols.Attribute("label").Value.Length)).PadRight(int.Parse(itemfilecols.Attribute("vlength").Value)) + (decimal.Parse(ReplaceStr) + decimal.Parse(WrinteInValue)).ToString());
                                                                                                                                    WrinteInValue = dtResult.AsEnumerable().Select(d => Convert.ToDouble(d.Field<string>(dtResult.Columns[int.Parse(itemfilecols.Attribute("cid").Value)].ToString()))).Sum().ToString();
                                                                                                                                    if (!string.IsNullOrEmpty(itemfilecols.Attribute("express").Value.Trim()) && itemfilecols.Attribute("express").Value == "-")
                                                                                                                                    {
                                                                                                                                        //dr[int.Parse(itemfilecols.Attribute("cid").Value.ToString())] = "-" + dr[int.Parse(itemfilecols.Attribute("cid").Value.ToString())];
                                                                                                                                        ////string sd = Regex.Replace(txtLineList[j], @"[^\d.\d]", "");
                                                                                                                                        //WrinteInValue = (decimal.Parse(Regex.Replace(txtLineList[j], @"[^\d.\d]", "")) - decimal.Parse(WrinteInValue.Trim())).ToString();
                                                                                                                                        //txtLineList[j] = 
                                                                                                                                    }

                                                                                                                                    //WrinteInValue = dtResult.AsEnumerable().Select(d => Convert.ToDouble(d.Field<string>(dtResult.Columns[int.Parse(itemfilecols.Attribute("cid").Value)].ToString()))).

                                                                                                                                    txtLineList[j] = txtLineList[j].Replace(txtLineList[j], txtLineList[j].Substring(0, (itemfilecols.Attribute("label").Value.Length)).PadRight(int.Parse(itemfilecols.Attribute("vlength").Value)) + WrinteInValue);
                                                                                                                                    break;
                                                                                                                                }
                                                                                                                            }
                                                                                                                        }
                                                                                                                    }
                                                                                                                    fsTargentFileTemp.Seek(0, SeekOrigin.Begin);
                                                                                                                    fsTargentFileTemp.SetLength(0);
                                                                                                                    // System.IO.File.WriteAllText(targetFileName, string.Empty);
                                                                                                                    //swTargetFileTemp.Write("");
                                                                                                                    for (int i = 0; i < txtLineList.Count; i++)
                                                                                                                    {
                                                                                                                        swTargetFileTemp.WriteLine(txtLineList[i]);
                                                                                                                    }
                                                                                                                    //foreach (string item in txtLineList)
                                                                                                                    //{
                                                                                                                    //    swTargetFileTemp.WriteLine(item);
                                                                                                                    //}

                                                                                                                }
                                                                                                            }

                                                                                                        }
                                                                                                    }
                                                                                                    catch (Exception ex)
                                                                                                    {
                                                                                                        SingleFileIsSuccess = false;
                                                                                                    }



                                                                                                    //using (StreamWriter swTargetFile = File.AppendText(targetFileName))
                                                                                                    //{

                                                                                                    //    for (int i = 0; i < dtResult.Rows.Count; i++)
                                                                                                    //    {
                                                                                                    //        DataRow dr = dtResult.Rows[i];

                                                                                                    //        using (FileStream fsTargentFile = new FileStream(targetFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                                                                                                    //        {
                                                                                                    //            using (StreamReader swTargetFilTemp = new StreamReader(fsTargentFile))
                                                                                                    //            {
                                                                                                    //                //string line = string.Empty;

                                                                                                    //                while ((line = swSourceFile.ReadLine()) != null)
                                                                                                    //                {
                                                                                                    //                }
                                                                                                    //            }
                                                                                                    //        }

                                                                                                    //    }
                                                                                                    //}
                                                                                                    //line = string.Join("@", sArray);
                                                                                                    //if (File.Exists(targetFileName))
                                                                                                    //{
                                                                                                    //    using (StreamWriter swTargetFile = File.AppendText(targetFileName))
                                                                                                    //    {
                                                                                                    //        swTargetFile.WriteLine(line);

                                                                                                    //    }
                                                                                                    //}
                                                                                                    //else
                                                                                                    //{
                                                                                                    //    using (FileStream fsTargetFile = new FileStream(targetFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                                                                                                    //    {
                                                                                                    //        using (StreamWriter swTargetFile = new StreamWriter(fsTargetFile))
                                                                                                    //        {
                                                                                                    //            swTargetFile.WriteLine(line);

                                                                                                    //        }
                                                                                                    //    }
                                                                                                    //}

                                                                                                }

                                                                                            }

                                                                                        }
                                                                                    }

                                                                                }
                                                                                else if (itemfileSrc.Attribute("srcfileType").Value.Equals("交易所"))
                                                                                {
                                                                                    if (itemfile.Attribute("filetitle").Value == "中国金融期货交易所 客户分项资金明细表")
                                                                                    {
                                                                                        DataTable dtResultTemp = dtResult.Copy(); //dtResultd的克隆表，作用是将dtResultd表中无法与dr表匹配的行移除掉，但由于foreach无法直接对dtResultd操作，因此声明了这个临时表
                                                                                                                                  //List<string> keywordList = new List<string>();
                                                                                        DataRow drTemp = dtResultTemp.NewRow();
                                                                                        for (int i = dtResult.Rows.Count - 1; i >= 0; i--)
                                                                                        {
                                                                                            var itemDrResul = dtResult.Rows[i];
                                                                                            bool IsDtDataMatch = false; //dt表是否有匹配dr表的数据标志，若能匹配则为true，否则为false
                                                                                            Dictionary<int, string> keywordList = new Dictionary<int, string>();
                                                                                            foreach (XElement itemfilecols in itemfileSrc.Nodes())
                                                                                            {
                                                                                                foreach (XElement itemfilepkg in itemfile.Descendants("filepkg"))
                                                                                                {
                                                                                                    if ((int.Parse(itemfilecols.Attribute("cid").Value) - 1) == (int.Parse(itemfilepkg.Attribute("pkgColIndex").Value)) && !string.IsNullOrEmpty(itemfilecols.Attribute("colIndex").Value))
                                                                                                    {
                                                                                                        keywordList.Add(int.Parse(itemfilecols.Attribute("colIndex").Value), itemDrResul[int.Parse(itemfilecols.Attribute("cid").Value) - 1].ToString());
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                            //string keyword1 = itemDrResul[2].ToString();
                                                                                            //string keyword2 = itemDrResul[3].ToString();
                                                                                            foreach (DataRow itemDr in dt.Rows)
                                                                                            {
                                                                                                foreach (XElement itemfilecols in itemfileSrc.Nodes())
                                                                                                {
                                                                                                    if (!string.IsNullOrEmpty(itemfilecols.Attribute("colIndex").Value.Trim()))
                                                                                                    {
                                                                                                        if (itemDr[keywordList.Keys.First() - 1].ToString() == keywordList[keywordList.Keys.First()])
                                                                                                        {
                                                                                                            IsDtDataMatch = true;
                                                                                                            itemDrResul[int.Parse(itemfilecols.Attribute("cid").Value)] = itemDr[int.Parse(itemfilecols.Attribute("colIndex").Value.Trim())].ToString();

                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                                //if (itemDr[2].ToString() == keyword1 && itemDr[3].ToString() == keyword2)  //colIndex的值
                                                                                                //{
                                                                                                //    itemDrResul[16] = itemDr[16].ToString();
                                                                                                //}
                                                                                            }
                                                                                            if (!IsDtDataMatch)
                                                                                            {
                                                                                                dtResult.Rows.RemoveAt(i);
                                                                                            }
                                                                                        }


                                                                                        //foreach (DataRow itemDrResul in dtResult.Rows)
                                                                                        //{
                                                                                        //    //dtResult.Rows.Remove(itemDrResul);
                                                                                        //    bool IsDtDataMatch = false; //dt表是否有匹配dr表的数据标志，若能匹配则为true，否则为false
                                                                                        //    Dictionary<int, string> keywordList = new Dictionary<int, string>();
                                                                                        //    foreach (XElement itemfilecols in itemfileSrc.Nodes())
                                                                                        //    {
                                                                                        //        foreach (XElement itemfilepkg in itemfile.Descendants("filepkg"))
                                                                                        //        {
                                                                                        //            if ( (int.Parse( itemfilecols.Attribute("cid").Value) - 1) == (int.Parse( itemfilepkg.Attribute("pkgColIndex").Value))  && !string.IsNullOrEmpty(itemfilecols.Attribute("colIndex").Value))
                                                                                        //            {
                                                                                        //                keywordList.Add(int.Parse(itemfilecols.Attribute("colIndex").Value), itemDrResul[int.Parse(itemfilecols.Attribute("cid").Value) - 1].ToString());
                                                                                        //            }
                                                                                        //        }
                                                                                        //    }
                                                                                        //    //string keyword1 = itemDrResul[2].ToString();
                                                                                        //    //string keyword2 = itemDrResul[3].ToString();
                                                                                        //    foreach (DataRow itemDr in dt.Rows)
                                                                                        //    {
                                                                                        //        foreach (XElement itemfilecols in itemfileSrc.Nodes())
                                                                                        //        {
                                                                                        //            if (!string.IsNullOrEmpty(itemfilecols.Attribute("colIndex").Value.Trim()))
                                                                                        //            {
                                                                                        //                if (itemDr[keywordList.Keys.First() - 1].ToString() == keywordList[keywordList.Keys.First()])
                                                                                        //                {
                                                                                        //                    IsDtDataMatch = true;
                                                                                        //                    itemDrResul[int.Parse(itemfilecols.Attribute("cid").Value)] = itemDr[int.Parse(itemfilecols.Attribute("colIndex").Value.Trim())].ToString();

                                                                                        //                }
                                                                                        //            }
                                                                                        //        }
                                                                                        //        //if (itemDr[2].ToString() == keyword1 && itemDr[3].ToString() == keyword2)  //colIndex的值
                                                                                        //        //{
                                                                                        //        //    itemDrResul[16] = itemDr[16].ToString();
                                                                                        //        //}
                                                                                        //    }
                                                                                        //    if (!IsDtDataMatch)
                                                                                        //    {
                                                                                        //        dtResult.Rows.Remove(itemDrResul);
                                                                                        //    }

                                                                                        //}
                                                                                        //dtResult = dtResultTemp;
                                                                                        //foreach (XElement itemfilecols in itemfileSrc.Nodes())
                                                                                        //{
                                                                                        //    if (itemfilecols.Attribute("colIndex").Value.Trim())
                                                                                        //}
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        //List<string> keywordList = new List<string>();
                                                                                        foreach (DataRow itemDrResul in dtResult.Rows)
                                                                                        {
                                                                                            Dictionary<int, string> keywordList = new Dictionary<int, string>();
                                                                                            foreach (XElement itemfilecols in itemfileSrc.Nodes())
                                                                                            {
                                                                                                foreach (XElement itemfilepkg in itemfile.Descendants("filepkg"))
                                                                                                {
                                                                                                    if (itemfilecols.Attribute("cid").Value == itemfilepkg.Attribute("pkgColIndex").Value && !string.IsNullOrEmpty(itemfilecols.Attribute("colIndex").Value))
                                                                                                    {
                                                                                                        keywordList.Add(int.Parse(itemfilecols.Attribute("colIndex").Value), itemDrResul[int.Parse(itemfilecols.Attribute("cid").Value)].ToString());
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                            //string keyword1 = itemDrResul[2].ToString();
                                                                                            //string keyword2 = itemDrResul[3].ToString();
                                                                                            foreach (DataRow itemDr in dt.Rows)
                                                                                            {

                                                                                                foreach (XElement itemfilecols in itemfileSrc.Nodes())
                                                                                                {
                                                                                                    if (!string.IsNullOrEmpty(itemfilecols.Attribute("colIndex").Value.Trim()))
                                                                                                    {
                                                                                                        if (itemDr[keywordList.Keys.First() - 1].ToString() == keywordList[keywordList.Keys.First()])
                                                                                                        {
                                                                                                            itemDrResul[int.Parse(itemfilecols.Attribute("cid").Value)] = itemDr[int.Parse(itemfilecols.Attribute("colIndex").Value.Trim()) - 1].ToString();
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                                //if (itemDr[2].ToString() == keyword1 && itemDr[3].ToString() == keyword2)  //colIndex的值
                                                                                                //{
                                                                                                //    itemDrResul[16] = itemDr[16].ToString();
                                                                                                //}
                                                                                            }
                                                                                        }
                                                                                        //foreach (XElement itemfilecols in itemfileSrc.Nodes())
                                                                                        //{
                                                                                        //    if (itemfilecols.Attribute("colIndex").Value.Trim())
                                                                                        //}
                                                                                    }

                                                                                }
                                                                            }
                                                                            #endregion
                                                                            #region 生成txt和dbf文件
                                                                            if (File.Exists(targetFileName))
                                                                            {
                                                                                using (StreamWriter swTargetFile = File.AppendText(targetFileName))
                                                                                {
                                                                                    if (IsTransverse)  //横向输出列
                                                                                    {
                                                                                        //try
                                                                                        //{
                                                                                        //    for (int i = 0; i < dtResult.Rows.Count; i++)
                                                                                        //    {
                                                                                        //        DataRow dr = dtResult.Rows[i];
                                                                                        //        List<string> RowValueList = new List<string>();

                                                                                        //        foreach (XElement itemfileSrc in itemfile.Descendants("fileSrc"))
                                                                                        //        {
                                                                                        //            foreach (XElement itemfilecols in itemfileSrc.Nodes())
                                                                                        //            {
                                                                                        //                string line = string.Empty;
                                                                                        //                if (!string.IsNullOrEmpty(itemfilecols.Attribute("isout").Value.Trim()))   //是否输出
                                                                                        //                {
                                                                                        //                    if (itemfilecols.Attribute("isout").Value.Trim() == "否")
                                                                                        //                    {
                                                                                        //                        line = "";
                                                                                        //                    }
                                                                                        //                    else
                                                                                        //                    {
                                                                                        //                        if (!string.IsNullOrEmpty(itemfilecols.Attribute("tlength").Value) && (int.Parse(itemfilecols.Attribute("tlength").Value.Trim()) > 0)) //列名位数 +对齐方式
                                                                                        //                        {
                                                                                        //                            string align = itemfilecols.Attribute("align").Value;

                                                                                        //                            if (!string.IsNullOrEmpty(align) && align.Equals("左"))
                                                                                        //                            {
                                                                                        //                                line = dtResult.Columns[int.Parse(itemfilecols.Attribute("cid").Value.Trim())].ToString().Trim().PadRight(int.Parse(itemfilecols.Attribute("tlength").Value.Trim()), ' ');//以空格填充
                                                                                        //                            }
                                                                                        //                            if (!string.IsNullOrEmpty(align) && align.Equals("右"))
                                                                                        //                            {
                                                                                        //                                line = dtResult.Columns[int.Parse(itemfilecols.Attribute("cid").Value.Trim())].ToString().Trim().PadLeft(int.Parse(itemfilecols.Attribute("tlength").Value.Trim()), ' ');//以空格填充
                                                                                        //                            }

                                                                                        //                        }
                                                                                        //                    }
                                                                                        //                    //sArray[int.Parse(itemfilecols.Attribute("colIndex").Value) - 1] = Datafilecols;
                                                                                        //                }
                                                                                        //                //line = dtResult.Columns[int.Parse(itemfilecols.Attribute("cid").Value)].ToString()

                                                                                        //                line += SGDealDataRowValue(itemfilecols, dr[int.Parse(itemfilecols.Attribute("cid").Value)].ToString(), dr);

                                                                                        //                swTargetFile.WriteLine(line);

                                                                                        //                //RowValueList.Add(SGDealDataRowValue(itemfilecols, dr[int.Parse(itemfilecols.Attribute("cid").Value)].ToString(), dr));
                                                                                        //            }
                                                                                        //            break;
                                                                                        //        }
                                                                                        //        //line = string.Join(string.Empty, RowValueList.ToArray());


                                                                                        //    }
                                                                                        //}
                                                                                        //catch (Exception ex)
                                                                                        //{

                                                                                        //}
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        if (itemfile.Attribute("filetitle").Value == "中国金融期货交易所 客户分项资金明细表")
                                                                                        {
                                                                                            string LineColNameIonfo = string.Join(string.Empty, colnumName.ToArray());
                                                                                            swTargetFile.WriteLine("\n" + LineColNameIonfo);
                                                                                            try
                                                                                            {
                                                                                                for (int i = 0; i < dtResult.Rows.Count; i++)
                                                                                                {
                                                                                                    DataRow dr = dtResult.Rows[i];
                                                                                                    List<string> RowValueList = new List<string>();
                                                                                                    foreach (XElement itemfileSrc in itemfile.Descendants("fileSrc"))
                                                                                                    {
                                                                                                        foreach (XElement itemfilecols in itemfileSrc.Nodes())
                                                                                                        {
                                                                                                            RowValueList.Add(SGDealDataRowValueClientCapitalDetail(itemfilecols, dr[int.Parse(itemfilecols.Attribute("cid").Value) - 1].ToString(), dr));
                                                                                                        }
                                                                                                        break;
                                                                                                    }
                                                                                                    string line = string.Join(string.Empty, RowValueList.ToArray());

                                                                                                    swTargetFile.WriteLine(line);
                                                                                                }


                                                                                            }
                                                                                            catch (Exception ex)
                                                                                            {
                                                                                                SingleFileIsSuccess = false;
                                                                                                MessageBox.Show(itemfile.Attribute("filetitle") + ex.Message.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                                                return;
                                                                                            }
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            // string LineValueIonfo = string.Join(string.Empty, colnumValueFinal.ToArray());
                                                                                            string LineColNameIonfo = string.Join(string.Empty, colnumName.ToArray());
                                                                                            swTargetFile.WriteLine("\n" + LineColNameIonfo);
                                                                                            // swTargetFile.WriteLine(LineValueIonfo);
                                                                                            //string columns = "", content = "", columnName = "";
                                                                                            try
                                                                                            {
                                                                                                for (int i = 0; i < dtResult.Rows.Count; i++)
                                                                                                {
                                                                                                    DataRow dr = dtResult.Rows[i];
                                                                                                    List<string> RowValueList = new List<string>();
                                                                                                    foreach (XElement itemfileSrc in itemfile.Descendants("fileSrc"))
                                                                                                    {
                                                                                                        foreach (XElement itemfilecols in itemfileSrc.Nodes())
                                                                                                        {
                                                                                                            RowValueList.Add(SGDealDataRowValue(itemfilecols, dr[int.Parse(itemfilecols.Attribute("cid").Value)].ToString(), dr));
                                                                                                        }
                                                                                                        break;
                                                                                                    }
                                                                                                    string line = string.Join(string.Empty, RowValueList.ToArray());

                                                                                                    swTargetFile.WriteLine(line);
                                                                                                }
                                                                                                //for (int i = 0; i < dtResult.Columns.Count; i++)
                                                                                                //{
                                                                                                //    //columns = dtResult.Columns[i].ColumnName.ToString();
                                                                                                //    foreach (var item in collection)
                                                                                                //    {

                                                                                                //    }
                                                                                                //    for (int j = 0; j < dtResult.Columns.Count; j++)
                                                                                                //    {
                                                                                                //        content += dtResult.Rows[i][j].ToString().Trim();
                                                                                                //    }
                                                                                                //    swTargetFile.WriteLine(content);
                                                                                                //}



                                                                                            }
                                                                                            catch (Exception ex)
                                                                                            {
                                                                                                SingleFileIsSuccess = false;
                                                                                                MessageBox.Show(itemfile.Attribute("filetitle") + ex.Message.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                                                return;
                                                                                            }
                                                                                        }

                                                                                    }

                                                                                }

                                                                                //TFileReader.SaveDataTableToTXT(dispatchFile, dtResult, targetFileName, true);

                                                                                //生成dbf文档  ，纵向输出，
                                                                                if (itemfile.Attribute("arrangeType").Value == "纵向")
                                                                                {
                                                                                    string testPath = AppDomain.CurrentDomain.BaseDirectory;
                                                                                    var odbf = new DbfFile(Encoding.GetEncoding(936));
                                                                                    // odbf.Open(Path.Combine(targetDirectoryName, "test.dbf"), FileMode.Create); 
                                                                                    odbf.Open(targetDBFFileName, FileMode.Create);

                                                                                    //创建列头
                                                                                    foreach (string item in DBFColumnNamelist)
                                                                                    {
                                                                                        odbf.Header.AddColumn(new DbfColumn(item, DbfColumn.DbfColumnType.Character, 20, 0));
                                                                                    }

                                                                                    List<string> txtFileCount = File.ReadAllLines(targetFileName).ToList();

                                                                                    if (txtFileCount.Count > 5)
                                                                                    {
                                                                                        for (int i = 5; i < txtFileCount.Count; i++)
                                                                                        {

                                                                                            string line = txtFileCount[i].Trim();
                                                                                            if (!string.IsNullOrEmpty(line))
                                                                                            {
                                                                                                string lineTemp = new Regex("[\\s]+").Replace(line, "@");
                                                                                                string[] sArray = lineTemp.Split('@');
                                                                                                var orec = new DbfRecord(odbf.Header) { AllowDecimalTruncate = true };
                                                                                                for (int j = 0; j < sArray.Length; j++)
                                                                                                {
                                                                                                    orec[j] = sArray[j];

                                                                                                }
                                                                                                odbf.Write(orec, true);
                                                                                            }
                                                                                        }
                                                                                    }

                                                                                    odbf.Close();
                                                                                }
                                                                                else  //横向输出的 现在只有【会员资金情况表】
                                                                                {
                                                                                    if (itemfile.Attribute("fileext").Value == "DBF" && itemfile.Attribute("filetitle").Value == "会员资金情况表")
                                                                                    {
                                                                                        string testPath = AppDomain.CurrentDomain.BaseDirectory;
                                                                                        var odbf = new DbfFile(Encoding.GetEncoding(936));
                                                                                        // odbf.Open(Path.Combine(targetDirectoryName, "test.dbf"), FileMode.Create); 
                                                                                        odbf.Open(targetDBFFileName, FileMode.Create);

                                                                                        //创建列头
                                                                                        //foreach (XElement itemfileSrc in itemfile.Descendants("fileSrc"))
                                                                                        //{
                                                                                        //    if (string.IsNullOrEmpty( itemfileSrc.Attribute("srcfile").Value))
                                                                                        //    {

                                                                                        //    }
                                                                                        //}
                                                                                        odbf.Header.AddColumn(new DbfColumn("accountID", DbfColumn.DbfColumnType.Character, 20, 0));
                                                                                        odbf.Header.AddColumn(new DbfColumn("itemDesc", DbfColumn.DbfColumnType.Character, 20, 0));
                                                                                        odbf.Header.AddColumn(new DbfColumn("itemValue", DbfColumn.DbfColumnType.Character, 20, 0));

                                                                                        //foreach (string item in DBFColumnNamelist)
                                                                                        //{
                                                                                        //    odbf.Header.AddColumn(new DbfColumn(item, DbfColumn.DbfColumnType.Character, 20, 0));
                                                                                        //}

                                                                                        List<string> txtFileCount = File.ReadAllLines(targetFileName).ToList();

                                                                                        if (txtFileCount.Count > 4)
                                                                                        {
                                                                                            for (int i = 4; i < txtFileCount.Count; i++)
                                                                                            {
                                                                                                string line = txtFileCount[i].Trim();
                                                                                                if (!string.IsNullOrEmpty(line) && Regex.IsMatch(line, @"\d+$"))
                                                                                                {
                                                                                                    string lineTemp = new Regex("[\\s]+").Replace(line, "@");
                                                                                                    string[] sArray = lineTemp.Split('@');
                                                                                                    var orec = new DbfRecord(odbf.Header) { AllowDecimalTruncate = true };
                                                                                                    //string dsg = Path.GetFileNameWithoutExtension(targetFileName).Split('_')[0];
                                                                                                    orec[0] = Path.GetFileNameWithoutExtension(targetFileName).Split('_')[0];
                                                                                                    for (int j = 0; j < sArray.Length; j++)
                                                                                                    {
                                                                                                        orec[j + 1] = sArray[j];

                                                                                                    }
                                                                                                    odbf.Write(orec, true);
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                        odbf.Close();
                                                                                    }

                                                                                }

                                                                            }
                                                                            #endregion
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }


                                                    bool MotorCenterGeneFileResult = false;
                                                    bool CZCEGeneFileResult = false;
                                                    bool DCEGeneFileResult = false;
                                                    bool CffexGeneFileResult = false;

                                                    #region 生成监控中心文件
                                                    //生成监控中心
                                                    foreach (string itemSingleMotorCenterAccount in SingleMotorCenterAccount)
                                                    {
                                                        foreach (XElement itemAccountId in configDocument.Descendants("AccountId"))
                                                        {
                                                            if (itemAccountId.Attribute("value").Value == itemSingleMotorCenterAccount)
                                                            {
                                                                if (itemAccountId.Attribute("cfmmcFile").Equals("0")) //不生成监控中心文件
                                                                {
                                                                    return;
                                                                }
                                                                foreach (XElement itemOrganCode in itemAccountId.Descendants("OrganCode"))
                                                                {
                                                                    if (itemOrganCode.Attribute("name").Value == "监控中心")
                                                                    {
                                                                        foreach (XElement itemfile in itemOrganCode.Nodes())
                                                                        {
                                                                            foreach (XElement itemfileSrc in itemfile.Nodes())
                                                                            {
                                                                                SourceFileName = Path.Combine(OriginPath.ToString() + "\\" + kryDTPDate.Value.ToString("yyyyMMdd") + string.Format("\\{0}{1}{2}.txt", GlobalData.SeatNo, itemfileSrc.Attribute("srcfile").Value, kryDTPDate.Value.ToString("yyyyMMdd")));


                                                                                if (itemAccountId.Attribute("outType").Value.Equals("1"))  //按日期导出
                                                                                {
                                                                                    targetFileName = Path.Combine(MonitorCenterOutPath1.ToString() + "\\" + string.Format(@"{0}\监控中心格式\TXT文件\{1}\{2}{3}{4}.txt", kryDTPDate.Value.ToString("yyyyMMdd"), itemSingleMotorCenterAccount, itemSingleMotorCenterAccount, itemfileSrc.Attribute("srcfile").Value.ToString().ToUpper(), kryDTPDate.Value.ToString("yyyyMMdd")));
                                                                                    targetDirectoryName = Path.Combine(MonitorCenterOutPath1.ToString() + "\\" + string.Format(@"{0}\监控中心格式\TXT文件\{1}", kryDTPDate.Value.ToString("yyyyMMdd"), itemSingleMotorCenterAccount));
                                                                                    targetDirectoryName1 = Path.Combine(MonitorCenterOutPath2.ToString() + "\\" + string.Format(@"{0}\监控中心格式\TXT文件\{1}", kryDTPDate.Value.ToString("yyyyMMdd"), itemSingleMotorCenterAccount));
                                                                                }
                                                                                else   //按账号导出
                                                                                {
                                                                                    targetFileName = Path.Combine(MonitorCenterOutPath1.ToString() + "\\" + string.Format(@"{0}\监控中心格式\TXT文件\{1}\{2}{3}{4}.txt", itemSingleMotorCenterAccount, kryDTPDate.Value.ToString("yyyyMMdd"), itemSingleMotorCenterAccount, itemfileSrc.Attribute("srcfile").Value.ToString().ToUpper(), kryDTPDate.Value.ToString("yyyyMMdd")));
                                                                                    targetDirectoryName = Path.Combine(MonitorCenterOutPath1.ToString() + "\\" + string.Format(@"{0}\监控中心格式\TXT文件\{1}", itemSingleMotorCenterAccount, kryDTPDate.Value.ToString("yyyyMMdd")));
                                                                                    targetDirectoryName1 = Path.Combine(MonitorCenterOutPath2.ToString() + "\\" + string.Format(@"{0}\监控中心格式\TXT文件\{1}", itemSingleMotorCenterAccount, kryDTPDate.Value.ToString("yyyyMMdd")));
                                                                                }

                                                                                if (!Directory.Exists(targetDirectoryName))
                                                                                {
                                                                                    Directory.CreateDirectory(targetDirectoryName);
                                                                                }
                                                                                if (File.Exists(targetFileName))
                                                                                {
                                                                                    File.Delete(targetFileName);
                                                                                }
                                                                                if (!File.Exists(SourceFileName))
                                                                                {
                                                                                    MessageBox.Show(string.Format("{0}文件不存在", itemfile.Attribute("filetitle").Value), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                                    continue;
                                                                                }
                                                                                if (itemfile.Attribute("IsOutPut").Value == "否")
                                                                                {
                                                                                    continue;
                                                                                }
                                                                                using (FileStream fsSourceFile = new FileStream(SourceFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                                                                                {
                                                                                    using (StreamReader swSourceFile = new StreamReader(fsSourceFile))
                                                                                    {
                                                                                        string line = string.Empty;
                                                                                        while ((line = swSourceFile.ReadLine()) != null)
                                                                                        {
                                                                                            string[] sArray = line.Split('@');
                                                                                            if (sArray[0] == kryDTPDate.Value.ToString("yyyy-MM-dd") && sArray[1] == itemSingleMotorCenterAccount)
                                                                                            {

                                                                                                try
                                                                                                {
                                                                                                    foreach (XElement itemfilecols in itemfileSrc.Nodes())
                                                                                                    {
                                                                                                        string Datafilecols = sArray[int.Parse(itemfilecols.Attribute("cid").Value) - 1];

                                                                                                        sArray = MonitorCenterDealData(itemfilecols, Datafilecols, sArray);
                                                                                                        if (sArray[0] == "数据处理出错")
                                                                                                        {
                                                                                                            SingleFileIsSuccess = false;
                                                                                                            MessageBox.Show(itemfile.Attribute("filetitle").Value + sArray[0], "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                                                            return;
                                                                                                        }
                                                                                                        #region

                                                                                                        #endregion
                                                                                                    }
                                                                                                }
                                                                                                catch (Exception ex)
                                                                                                {
                                                                                                    SingleFileIsSuccess = false;
                                                                                                    MessageBox.Show(itemfile.Attribute("filetitle") + ex.Message.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                                                    return;
                                                                                                }

                                                                                                line = string.Join("@", sArray);
                                                                                                if (File.Exists(targetFileName))
                                                                                                {
                                                                                                    using (StreamWriter swTargetFile = File.AppendText(targetFileName))
                                                                                                    {
                                                                                                        swTargetFile.WriteLine(line);

                                                                                                    }
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    using (FileStream fsTargetFile = new FileStream(targetFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                                                                                                    {
                                                                                                        using (StreamWriter swTargetFile = new StreamWriter(fsTargetFile))
                                                                                                        {
                                                                                                            swTargetFile.WriteLine(line);

                                                                                                        }
                                                                                                    }
                                                                                                }

                                                                                            }

                                                                                        }
                                                                                        if (!File.Exists(targetFileName))
                                                                                        {
                                                                                            using (File.Create(targetFileName))
                                                                                            {
                                                                                                ;
                                                                                            }

                                                                                        }

                                                                                    }
                                                                                }

                                                                            }
                                                                        }

                                                                        if (!Directory.Exists(targetDirectoryName1))
                                                                        {
                                                                            Directory.CreateDirectory(targetDirectoryName1);
                                                                        }
                                                                        foreach (string file in Directory.GetFiles(targetDirectoryName))
                                                                        {
                                                                            string name = System.IO.Path.GetFileName(file);
                                                                            string dest = System.IO.Path.Combine(targetDirectoryName1, name);
                                                                            if (File.Exists(dest))
                                                                            {
                                                                                File.Delete(dest);
                                                                            }
                                                                            System.IO.File.Copy(file, dest);//复制文件
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                    #endregion

                                                    //生成证商所文件
                                                    foreach (string itemSingleMotorCenterAccount in SingleMotorCenterAccount)
                                                    {
                                                        foreach (XElement itemAccountId in configDocument.Descendants("AccountId"))
                                                        {
                                                            if (itemAccountId.Attribute("value").Value == itemSingleMotorCenterAccount)
                                                            {
                                                                foreach (XElement itemOrganCode in itemAccountId.Descendants("OrganCode"))
                                                                {
                                                                    if (itemOrganCode.Attribute("name").Value == "郑商所")
                                                                    {
                                                                        foreach (XElement itemfile in itemOrganCode.Nodes())
                                                                        {
                                                                            foreach (XElement itemfileSrc in itemfile.Nodes())
                                                                            {

                                                                                SourceFileName = Path.Combine(OriginPath.ToString() + "\\" + kryDTPDate.Value.ToString("yyyyMMdd") + string.Format("\\{0}组合持仓表.txt", kryDTPDate.Value.ToString("yyyyMMdd")));

                                                                                //按账号导出的目录
                                                                                string txtFileName = (itemfile.Attribute("filename").Value.ToString().Replace("{accountid}", itemSingleMotorCenterAccount)).Replace("{tradingday}", kryDTPDate.Value.ToString("yyyyMMdd"));

                                                                                targetFileName = Path.Combine(MonitorCenterOutPath1.ToString() + "\\" + string.Format(@"{0}\郑商所格式\TXT文件\{1}\{2}.txt", itemSingleMotorCenterAccount, kryDTPDate.Value.ToString("yyyyMMdd"), txtFileName));
                                                                                targetDirectoryName = Path.Combine(MonitorCenterOutPath1.ToString() + "\\" + string.Format(@"{0}\郑商所格式\TXT文件\{1}", itemSingleMotorCenterAccount, kryDTPDate.Value.ToString("yyyyMMdd")));
                                                                                targetDirectoryName1 = Path.Combine(MonitorCenterOutPath2.ToString() + "\\" + string.Format(@"{0}\郑商所格式\TXT文件\{1}", itemSingleMotorCenterAccount, kryDTPDate.Value.ToString("yyyyMMdd")));

                                                                                if (!Directory.Exists(targetDirectoryName))
                                                                                {
                                                                                    Directory.CreateDirectory(targetDirectoryName);
                                                                                }
                                                                                if (File.Exists(targetFileName))
                                                                                {
                                                                                    File.Delete(targetFileName);
                                                                                }
                                                                                if (!File.Exists(SourceFileName))
                                                                                {
                                                                                    MessageBox.Show("{郑商所组合持仓表不存在", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                                    continue;
                                                                                }
                                                                                using (FileStream fsSourceFile = new FileStream(SourceFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                                                                                {
                                                                                    using (StreamReader swSourceFile = new StreamReader(fsSourceFile, Encoding.GetEncoding("GB2312")))
                                                                                    {
                                                                                        // string txtInfo = swSourceFile.ReadToEnd();
                                                                                        string line = string.Empty;
                                                                                        int count = 0;
                                                                                        bool IsWriteNextLine = false;

                                                                                        while ((line = swSourceFile.ReadLine()) != null)
                                                                                        {
                                                                                            //foreach (XElement itemfilecols in itemfileSrc.Nodes())
                                                                                            //{
                                                                                            if (count > 0)
                                                                                            {
                                                                                                try
                                                                                                {
                                                                                                    using (StreamWriter swTargetFileAppend = new StreamWriter(targetFileName, true, Encoding.GetEncoding("GB2312")))
                                                                                                    {
                                                                                                        if (count > 5)
                                                                                                        {
                                                                                                            if (IsWriteNextLine)
                                                                                                            {
                                                                                                                List<string> colNameList = ColValueSplitLineCZCE(line);
                                                                                                                foreach (XElement itemfilecols in itemfileSrc.Nodes())
                                                                                                                {
                                                                                                                    string Datafilecols = colNameList[int.Parse(itemfilecols.Attribute("cid").Value.Trim()) - 1];

                                                                                                                    colNameList = CZCEDealData(itemfilecols, Datafilecols, colNameList);

                                                                                                                }
                                                                                                                line = string.Join(string.Empty, colNameList.ToArray());

                                                                                                                swTargetFileAppend.WriteLine(line);
                                                                                                                IsWriteNextLine = false;
                                                                                                                count = count + 1;
                                                                                                                continue;
                                                                                                            }
                                                                                                            if (line.Substring(0, 8).Equals(itemSingleMotorCenterAccount))   //  "34339297"    itemSingleMotorCenterAccount
                                                                                                            {
                                                                                                                List<string> colNameList = ColValueSplitLineCZCE(line);
                                                                                                                foreach (XElement itemfilecols in itemfileSrc.Nodes())
                                                                                                                {
                                                                                                                    string Datafilecols = colNameList[int.Parse(itemfilecols.Attribute("cid").Value.Trim()) - 1];

                                                                                                                    colNameList = CZCEDealData(itemfilecols, Datafilecols, colNameList);

                                                                                                                }
                                                                                                                line = string.Join(string.Empty, colNameList.ToArray());

                                                                                                                swTargetFileAppend.WriteLine(line);
                                                                                                                IsWriteNextLine = true;
                                                                                                            }
                                                                                                        }
                                                                                                        else
                                                                                                        {
                                                                                                            if (count == 4)
                                                                                                            {
                                                                                                                List<string> colNameList = ColNameSplitLineCZCE(line);

                                                                                                                foreach (XElement itemfilecols in itemfileSrc.Nodes())
                                                                                                                {
                                                                                                                    if (true)
                                                                                                                    {
                                                                                                                        if (!string.IsNullOrEmpty(itemfilecols.Attribute("tlength").Value) && (int.Parse(itemfilecols.Attribute("tlength").Value.Trim()) > 0)) //列名位数 +对齐方式
                                                                                                                        {
                                                                                                                            string align = itemfilecols.Attribute("align").Value;

                                                                                                                            if (!string.IsNullOrEmpty(align) && align.Equals("左"))
                                                                                                                            {
                                                                                                                                colNameList[int.Parse(itemfilecols.Attribute("cid").Value.Trim()) - 1] = colNameList[int.Parse(itemfilecols.Attribute("cid").Value.Trim()) - 1].Trim().PadRight(int.Parse(itemfilecols.Attribute("tlength").Value.Trim()), ' ');//以空格填充
                                                                                                                            }
                                                                                                                            if (!string.IsNullOrEmpty(align) && align.Equals("右"))
                                                                                                                            {
                                                                                                                                colNameList[int.Parse(itemfilecols.Attribute("cid").Value.Trim()) - 1] = colNameList[int.Parse(itemfilecols.Attribute("cid").Value.Trim()) - 1].Trim().PadLeft(int.Parse(itemfilecols.Attribute("tlength").Value.Trim()), ' ');//以空格填充
                                                                                                                            }
                                                                                                                            //colNameList[int.Parse(itemfilecols.Attribute("cid").Value.Trim())] = 
                                                                                                                        }
                                                                                                                    }
                                                                                                                }

                                                                                                                line = string.Join(string.Empty, colNameList.ToArray());
                                                                                                            }
                                                                                                            swTargetFileAppend.WriteLine(line);
                                                                                                            count = count + 1;
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                                catch (Exception ex)
                                                                                                {
                                                                                                    SingleFileIsSuccess = false;
                                                                                                }

                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                using (FileStream fsTargetFile = new FileStream(targetFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                                                                                                {
                                                                                                    using (StreamWriter swTargetFile = new StreamWriter(fsTargetFile, Encoding.GetEncoding("GB2312")))
                                                                                                    {
                                                                                                        swTargetFile.WriteLine(line);
                                                                                                        count = count + 1;
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }

                                                                        if (!Directory.Exists(targetDirectoryName1))
                                                                        {
                                                                            Directory.CreateDirectory(targetDirectoryName1);
                                                                        }
                                                                        foreach (string file in Directory.GetFiles(targetDirectoryName))
                                                                        {
                                                                            string name = System.IO.Path.GetFileName(file);
                                                                            string dest = System.IO.Path.Combine(targetDirectoryName1, name);
                                                                            if (File.Exists(dest))
                                                                            {
                                                                                File.Delete(dest);
                                                                            }
                                                                            System.IO.File.Copy(file, dest);//复制文件
                                                                        }


                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }

                                                    //生成大商所文件
                                                    foreach (string itemSingleMotorCenterAccount in SingleMotorCenterAccount)
                                                    {
                                                        foreach (XElement itemAccountId in configDocument.Descendants("AccountId"))
                                                        {
                                                            if (itemAccountId.Attribute("value").Value == itemSingleMotorCenterAccount)
                                                            {
                                                                foreach (XElement itemOrganCode in itemAccountId.Descendants("OrganCode"))
                                                                {
                                                                    if (itemOrganCode.Attribute("name").Value == "大商所")
                                                                    {
                                                                        foreach (XElement itemfile in itemOrganCode.Nodes())
                                                                        {
                                                                            foreach (XElement itemfileSrc in itemfile.Nodes())
                                                                            {
                                                                                SourceFileName = Path.Combine(OriginPath.ToString() + "\\" + kryDTPDate.Value.ToString("yyyyMMdd") + string.Format("\\{0}_持仓明细表.txt", kryDTPDate.Value.ToString("yyyyMMdd")));

                                                                                //按账号导出的目录
                                                                                string txtFileName = (itemfile.Attribute("filename").Value.ToString().Replace("{accountid}", itemSingleMotorCenterAccount)).Replace("{tradingday}", kryDTPDate.Value.ToString("yyyyMMdd"));

                                                                                targetFileName = Path.Combine(MonitorCenterOutPath1.ToString() + "\\" + string.Format(@"{0}\大商所格式\TXT文件\{1}\{2}.txt", itemSingleMotorCenterAccount, kryDTPDate.Value.ToString("yyyyMMdd"), txtFileName));
                                                                                targetDirectoryName = Path.Combine(MonitorCenterOutPath1.ToString() + "\\" + string.Format(@"{0}\大商所格式\TXT文件\{1}", itemSingleMotorCenterAccount, kryDTPDate.Value.ToString("yyyyMMdd")));
                                                                                targetDirectoryName1 = Path.Combine(MonitorCenterOutPath2.ToString() + "\\" + string.Format(@"{0}\大商所格式\TXT文件\{1}", itemSingleMotorCenterAccount, kryDTPDate.Value.ToString("yyyyMMdd")));

                                                                                if (!Directory.Exists(targetDirectoryName))
                                                                                {
                                                                                    Directory.CreateDirectory(targetDirectoryName);
                                                                                }
                                                                                if (File.Exists(targetFileName))
                                                                                {
                                                                                    File.Delete(targetFileName);
                                                                                }
                                                                                if (!File.Exists(SourceFileName))
                                                                                {
                                                                                    MessageBox.Show("{大商所持仓明细表不存在", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                                    continue;
                                                                                }

                                                                                using (FileStream fsSourceFile = new FileStream(SourceFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                                                                                {
                                                                                    using (StreamReader swSourceFile = new StreamReader(fsSourceFile, Encoding.GetEncoding("GB2312")))
                                                                                    {
                                                                                        string line = string.Empty;
                                                                                        int count = 0;
                                                                                        bool IsWriteNextLine = false;

                                                                                        while ((line = swSourceFile.ReadLine()) != null)
                                                                                        {
                                                                                            if (count > 0)
                                                                                            {
                                                                                                try
                                                                                                {
                                                                                                    using (StreamWriter swTargetFileAppend = new StreamWriter(targetFileName, true, Encoding.GetEncoding("GB2312")))
                                                                                                    {
                                                                                                        if (count > 3)
                                                                                                        {
                                                                                                            if (!string.IsNullOrEmpty(line.Trim()) && line.Substring(30, 8).Equals(itemSingleMotorCenterAccount))  //    "01767714"  itemSingleMotorCenterAccount
                                                                                                            {
                                                                                                                List<string> colNameList = ColValueSplitLineDCE(line);
                                                                                                                foreach (XElement itemfilecols in itemfileSrc.Nodes())
                                                                                                                {
                                                                                                                    string Datafilecols = colNameList[int.Parse(itemfilecols.Attribute("cid").Value.Trim()) - 1];

                                                                                                                    colNameList = DCEDealData(itemfilecols, Datafilecols, colNameList);

                                                                                                                }
                                                                                                                line = string.Join(string.Empty, colNameList.ToArray());

                                                                                                                swTargetFileAppend.WriteLine(line);
                                                                                                                IsWriteNextLine = true;
                                                                                                            }
                                                                                                            count = count + 1;
                                                                                                        }
                                                                                                        else
                                                                                                        {
                                                                                                            if (count == 3)
                                                                                                            {
                                                                                                                List<string> colNameList = ColNameSplitLineDCE(line);

                                                                                                                foreach (XElement itemfilecols in itemfileSrc.Nodes())
                                                                                                                {
                                                                                                                    if (true)
                                                                                                                    {
                                                                                                                        if (!string.IsNullOrEmpty(itemfilecols.Attribute("tlength").Value) && (int.Parse(itemfilecols.Attribute("tlength").Value.Trim()) > 0)) //列名位数 +对齐方式
                                                                                                                        {
                                                                                                                            string align = itemfilecols.Attribute("align").Value;

                                                                                                                            if (!string.IsNullOrEmpty(align) && align.Equals("左"))
                                                                                                                            {
                                                                                                                                colNameList[int.Parse(itemfilecols.Attribute("cid").Value.Trim()) - 1] = colNameList[int.Parse(itemfilecols.Attribute("cid").Value.Trim()) - 1].Trim().PadRight(int.Parse(itemfilecols.Attribute("tlength").Value.Trim()), ' ');//以空格填充
                                                                                                                            }
                                                                                                                            if (!string.IsNullOrEmpty(align) && align.Equals("右"))
                                                                                                                            {
                                                                                                                                colNameList[int.Parse(itemfilecols.Attribute("cid").Value.Trim()) - 1] = colNameList[int.Parse(itemfilecols.Attribute("cid").Value.Trim()) - 1].Trim().PadLeft(int.Parse(itemfilecols.Attribute("tlength").Value.Trim()), ' ');//以空格填充
                                                                                                                            }
                                                                                                                        }
                                                                                                                    }
                                                                                                                }
                                                                                                                line = string.Join(string.Empty, colNameList.ToArray());
                                                                                                            }
                                                                                                            swTargetFileAppend.WriteLine(line);
                                                                                                            count = count + 1;
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                                catch (Exception ex)
                                                                                                {
                                                                                                    SingleFileIsSuccess = false;
                                                                                                    MessageBox.Show(ex.Message.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                                                    return;
                                                                                                }
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                using (FileStream fsTargetFile = new FileStream(targetFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                                                                                                {
                                                                                                    using (StreamWriter swTargetFile = new StreamWriter(fsTargetFile, Encoding.GetEncoding("GB2312")))
                                                                                                    {
                                                                                                        swTargetFile.WriteLine(line);
                                                                                                        count = count + 1;
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }

                                                                        if (!Directory.Exists(targetDirectoryName1))
                                                                        {
                                                                            Directory.CreateDirectory(targetDirectoryName1);
                                                                        }
                                                                        foreach (string file in Directory.GetFiles(targetDirectoryName))
                                                                        {
                                                                            string name = System.IO.Path.GetFileName(file);
                                                                            string dest = System.IO.Path.Combine(targetDirectoryName1, name);
                                                                            if (File.Exists(dest))
                                                                            {
                                                                                File.Delete(dest);
                                                                            }
                                                                            System.IO.File.Copy(file, dest);//复制文件
                                                                        }

                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }

                                                }));
                                            }
                                            else
                                            {
                                                //this.BeginInvoke((Action)delegate ()
                                                //{
                                                //    _frmWait.ShowDialog();
                                                //});
                                                //krypLbFlag.Visible = true;
                                                //krypLbFlag.Text = "读入原文件开始...";
                                                //生成中金所
                                                foreach (string itemSingleCffexAccount in SingleCffexAccount)
                                                {

                                                }

                                                #region 生成监控中心文件
                                                //生成监控中心
                                                foreach (string itemSingleMotorCenterAccount in SingleMotorCenterAccount)
                                                {
                                                    foreach (XElement itemAccountId in configDocument.Descendants("AccountId"))
                                                    {
                                                        if (itemAccountId.Attribute("value").Value == itemSingleMotorCenterAccount)
                                                        {
                                                            foreach (XElement itemOrganCode in itemAccountId.Descendants("OrganCode"))
                                                            {
                                                                if (itemOrganCode.Attribute("name").Value == "监控中心")
                                                                {
                                                                    foreach (XElement itemfile in itemOrganCode.Nodes())
                                                                    {
                                                                        foreach (XElement itemfileSrc in itemfile.Nodes())
                                                                        {
                                                                            SourceFileName = Path.Combine(OriginPath.ToString() + "\\" + kryDTPDate.Value.ToString("yyyyMMdd") + string.Format("\\{0}{1}{2}.txt", GlobalData.SeatNo, itemfileSrc.Attribute("srcfile").Value, kryDTPDate.Value.ToString("yyyyMMdd")));


                                                                            if (itemAccountId.Attribute("outType").Value.Equals("1"))  //按日期导出
                                                                            {
                                                                                targetFileName = Path.Combine(MonitorCenterOutPath1.ToString() + "\\" + string.Format(@"{0}\监控中心格式\TXT文件\{1}\{2}{3}{4}.txt", kryDTPDate.Value.ToString("yyyyMMdd"), itemSingleMotorCenterAccount, itemSingleMotorCenterAccount, itemfileSrc.Attribute("srcfile").Value.ToString().ToUpper(), kryDTPDate.Value.ToString("yyyyMMdd")));
                                                                                targetDirectoryName = Path.Combine(MonitorCenterOutPath1.ToString() + "\\" + string.Format(@"{0}\监控中心格式\TXT文件\{1}", kryDTPDate.Value.ToString("yyyyMMdd"), itemSingleMotorCenterAccount));
                                                                                targetDirectoryName1 = Path.Combine(MonitorCenterOutPath2.ToString() + "\\" + string.Format(@"{0}\监控中心格式\TXT文件\{1}", kryDTPDate.Value.ToString("yyyyMMdd"), itemSingleMotorCenterAccount));
                                                                            }
                                                                            else   //按账号导出
                                                                            {
                                                                                targetFileName = Path.Combine(MonitorCenterOutPath1.ToString() + "\\" + string.Format(@"{0}\监控中心格式\TXT文件\{1}\{2}{3}{4}.txt", itemSingleMotorCenterAccount, kryDTPDate.Value.ToString("yyyyMMdd"), itemSingleMotorCenterAccount, itemfileSrc.Attribute("srcfile").Value.ToString().ToUpper(), kryDTPDate.Value.ToString("yyyyMMdd")));
                                                                                targetDirectoryName = Path.Combine(MonitorCenterOutPath1.ToString() + "\\" + string.Format(@"{0}\监控中心格式\TXT文件\{1}", itemSingleMotorCenterAccount, kryDTPDate.Value.ToString("yyyyMMdd")));
                                                                                targetDirectoryName1 = Path.Combine(MonitorCenterOutPath2.ToString() + "\\" + string.Format(@"{0}\监控中心格式\TXT文件\{1}", itemSingleMotorCenterAccount, kryDTPDate.Value.ToString("yyyyMMdd")));
                                                                            }

                                                                            if (!Directory.Exists(targetDirectoryName))
                                                                            {
                                                                                Directory.CreateDirectory(targetDirectoryName);
                                                                            }
                                                                            if (File.Exists(targetFileName))
                                                                            {
                                                                                File.Delete(targetFileName);
                                                                            }
                                                                            if (!File.Exists(SourceFileName))
                                                                            {
                                                                                MessageBox.Show(string.Format("{0}文件不存在", itemfile.Attribute("filetitle").Value), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                                continue;
                                                                            }
                                                                            using (FileStream fsSourceFile = new FileStream(SourceFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                                                                            {
                                                                                using (StreamReader swSourceFile = new StreamReader(fsSourceFile))
                                                                                {
                                                                                    string line = string.Empty;
                                                                                    while ((line = swSourceFile.ReadLine()) != null)
                                                                                    {
                                                                                        string[] sArray = line.Split('@');
                                                                                        if (sArray[0] == kryDTPDate.Value.ToString("yyyy-MM-dd") && sArray[1] == itemSingleMotorCenterAccount)
                                                                                        {

                                                                                            try
                                                                                            {
                                                                                                foreach (XElement itemfilecols in itemfileSrc.Nodes())
                                                                                                {
                                                                                                    string Datafilecols = sArray[int.Parse(itemfilecols.Attribute("cid").Value) - 1];

                                                                                                    sArray = MonitorCenterDealData(itemfilecols, Datafilecols, sArray);
                                                                                                    if (sArray[0] == "数据处理出错")
                                                                                                    {
                                                                                                        SingleFileIsSuccess = false;
                                                                                                        MessageBox.Show(sArray[0], "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                                                        return;
                                                                                                    }
                                                                                                    #region
                                                                                                    //if (!string.IsNullOrEmpty(itemfilecols.Attribute("precision").Value.Trim()) && (int.Parse(itemfilecols.Attribute("precision").Value.Trim()) > 0))   //列值精度处理
                                                                                                    //{
                                                                                                    //    string _format = "#0.";
                                                                                                    //    for (int i = 0; i < int.Parse(itemfilecols.Attribute("precision").Value.Trim()); i++)
                                                                                                    //    {
                                                                                                    //        _format = _format + "0";
                                                                                                    //    }

                                                                                                    //    Datafilecols = decimal.Parse(sArray[int.Parse(itemfilecols.Attribute("colIndex").Value.ToString()) - 1]).ToString(_format);

                                                                                                    //    sArray[int.Parse(itemfilecols.Attribute("cid").Value) - 1] = Datafilecols;

                                                                                                    //}
                                                                                                    //if(!string.IsNullOrEmpty(itemfilecols.Attribute("vlength").Value.Trim()) && (int.Parse(itemfilecols.Attribute("vlength").Value.Trim()) > 0)) //列值位数
                                                                                                    //{
                                                                                                    //    string MakeUpField = string.IsNullOrEmpty(itemfilecols.Attribute("padstr").Value.Trim()) ? ("0"): (itemfilecols.Attribute("padstr").Value.Trim());
                                                                                                    //    sArray[int.Parse(itemfilecols.Attribute("cid").Value) - 1] = sArray[int.Parse(itemfilecols.Attribute("cid").Value) - 1].PadLeft( int.Parse( itemfilecols.Attribute("vlength").Value.Trim()),MakeUpField.ToCharArray()[0]);
                                                                                                    //}

                                                                                                    //if (!string.IsNullOrEmpty(itemfilecols.Attribute("isAbs").Value.Trim())) //绝对值
                                                                                                    //{
                                                                                                    //    if (itemfilecols.Attribute("isAbs").Value.Trim() == "是")
                                                                                                    //    {
                                                                                                    //        Datafilecols = System.Math.Abs(decimal.Parse(Datafilecols)).ToString();
                                                                                                    //    }

                                                                                                    //    sArray[int.Parse(itemfilecols.Attribute("cid").Value) - 1] = Datafilecols;
                                                                                                    //}

                                                                                                    //if (!string.IsNullOrEmpty(itemfilecols.Attribute("isout").Value.Trim()))   //是否输出
                                                                                                    //{
                                                                                                    //    if (itemfilecols.Attribute("isout").Value.Trim() == "否")
                                                                                                    //    {
                                                                                                    //        Datafilecols = "";
                                                                                                    //    }

                                                                                                    //    sArray[int.Parse(itemfilecols.Attribute("cid").Value) - 1] = Datafilecols;
                                                                                                    //}
                                                                                                    //if (!string.IsNullOrEmpty(itemfilecols.Attribute("FixValue").Value.Trim()))   //固定值
                                                                                                    //{
                                                                                                    //    Datafilecols = itemfilecols.Attribute("FixValue").Value.Trim();

                                                                                                    //    sArray[int.Parse(itemfilecols.Attribute("cid").Value) - 1] = Datafilecols;
                                                                                                    //}
                                                                                                    #endregion
                                                                                                }
                                                                                            }
                                                                                            catch (Exception ex)
                                                                                            {
                                                                                                SingleFileIsSuccess = false;
                                                                                                MessageBox.Show(itemfile.Attribute("filetitle") + ex.Message.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                                                return;
                                                                                            }

                                                                                            line = string.Join("@", sArray);
                                                                                            if (File.Exists(targetFileName))
                                                                                            {
                                                                                                using (StreamWriter swTargetFile = File.AppendText(targetFileName))
                                                                                                {
                                                                                                    swTargetFile.WriteLine(line);

                                                                                                }
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                using (FileStream fsTargetFile = new FileStream(targetFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                                                                                                {
                                                                                                    using (StreamWriter swTargetFile = new StreamWriter(fsTargetFile))
                                                                                                    {
                                                                                                        swTargetFile.WriteLine(line);

                                                                                                    }
                                                                                                }
                                                                                            }

                                                                                        }

                                                                                    }
                                                                                    if (!File.Exists(targetFileName))
                                                                                    {
                                                                                        using (File.Create(targetFileName))
                                                                                        {
                                                                                            ;
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
                                                if (!Directory.Exists(targetDirectoryName1))
                                                {
                                                    Directory.CreateDirectory(targetDirectoryName1);
                                                }
                                                foreach (string file in Directory.GetFiles(targetDirectoryName))
                                                {
                                                    string name = System.IO.Path.GetFileName(file);
                                                    string dest = System.IO.Path.Combine(targetDirectoryName1, name);
                                                    if (File.Exists(dest))
                                                    {
                                                        File.Delete(dest);
                                                    }
                                                    System.IO.File.Copy(file, dest);//复制文件
                                                }
                                                #endregion

                                                //生成证商所文件
                                                foreach (string itemSingleMotorCenterAccount in SingleMotorCenterAccount)
                                                {
                                                    foreach (XElement itemAccountId in configDocument.Descendants("AccountId"))
                                                    {
                                                        if (itemAccountId.Attribute("value").Value == itemSingleMotorCenterAccount)
                                                        {
                                                            foreach (XElement itemOrganCode in itemAccountId.Descendants("OrganCode"))
                                                            {
                                                                if (itemOrganCode.Attribute("name").Value == "郑商所")
                                                                {
                                                                    foreach (XElement itemfile in itemOrganCode.Nodes())
                                                                    {
                                                                        foreach (XElement itemfileSrc in itemfile.Nodes())
                                                                        {

                                                                            SourceFileName = Path.Combine(OriginPath.ToString() + "\\" + kryDTPDate.Value.ToString("yyyyMMdd") + string.Format("\\{0}组合持仓表.txt", kryDTPDate.Value.ToString("yyyyMMdd")));

                                                                            //按账号导出的目录
                                                                            string txtFileName = (itemfile.Attribute("filename").Value.ToString().Replace("{accountid}", itemSingleMotorCenterAccount)).Replace("{tradingday}", kryDTPDate.Value.ToString("yyyyMMdd"));

                                                                            targetFileName = Path.Combine(MonitorCenterOutPath1.ToString() + "\\" + string.Format(@"{0}\郑商所格式\TXT文件\{1}\{2}.txt", itemSingleMotorCenterAccount, kryDTPDate.Value.ToString("yyyyMMdd"), txtFileName));
                                                                            targetDirectoryName = Path.Combine(MonitorCenterOutPath1.ToString() + "\\" + string.Format(@"{0}\郑商所格式\TXT文件\{1}", itemSingleMotorCenterAccount, kryDTPDate.Value.ToString("yyyyMMdd")));
                                                                            targetDirectoryName1 = Path.Combine(MonitorCenterOutPath2.ToString() + "\\" + string.Format(@"{0}\郑商所格式\TXT文件\{1}", itemSingleMotorCenterAccount, kryDTPDate.Value.ToString("yyyyMMdd")));

                                                                            if (!Directory.Exists(targetDirectoryName))
                                                                            {
                                                                                Directory.CreateDirectory(targetDirectoryName);
                                                                            }
                                                                            if (File.Exists(targetFileName))
                                                                            {
                                                                                File.Delete(targetFileName);
                                                                            }
                                                                            if (!File.Exists(SourceFileName))
                                                                            {
                                                                                MessageBox.Show("{郑商所组合持仓表不存在", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                                continue;
                                                                            }
                                                                            using (FileStream fsSourceFile = new FileStream(SourceFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                                                                            {
                                                                                using (StreamReader swSourceFile = new StreamReader(fsSourceFile, Encoding.GetEncoding("GB2312")))
                                                                                {
                                                                                    // string txtInfo = swSourceFile.ReadToEnd();
                                                                                    string line = string.Empty;
                                                                                    int count = 0;
                                                                                    bool IsWriteNextLine = false;

                                                                                    while ((line = swSourceFile.ReadLine()) != null)
                                                                                    {
                                                                                        //foreach (XElement itemfilecols in itemfileSrc.Nodes())
                                                                                        //{
                                                                                        if (count > 0)
                                                                                        {
                                                                                            try
                                                                                            {
                                                                                                using (StreamWriter swTargetFileAppend = new StreamWriter(targetFileName, true, Encoding.GetEncoding("GB2312")))
                                                                                                {
                                                                                                    if (count > 5)
                                                                                                    {
                                                                                                        if (IsWriteNextLine)
                                                                                                        {
                                                                                                            List<string> colNameList = ColValueSplitLineCZCE(line);
                                                                                                            foreach (XElement itemfilecols in itemfileSrc.Nodes())
                                                                                                            {
                                                                                                                string Datafilecols = colNameList[int.Parse(itemfilecols.Attribute("cid").Value.Trim()) - 1];

                                                                                                                colNameList = CZCEDealData(itemfilecols, Datafilecols, colNameList);

                                                                                                            }
                                                                                                            line = string.Join(string.Empty, colNameList.ToArray());

                                                                                                            swTargetFileAppend.WriteLine(line);
                                                                                                            IsWriteNextLine = false;
                                                                                                            count = count + 1;
                                                                                                            continue;
                                                                                                        }
                                                                                                        if (line.Substring(0, 8).Equals(itemSingleMotorCenterAccount))   //itemSingleMotorCenterAccount  34339297
                                                                                                        {
                                                                                                            List<string> colNameList = ColValueSplitLineCZCE(line);
                                                                                                            foreach (XElement itemfilecols in itemfileSrc.Nodes())
                                                                                                            {
                                                                                                                string Datafilecols = colNameList[int.Parse(itemfilecols.Attribute("cid").Value.Trim()) - 1];

                                                                                                                colNameList = CZCEDealData(itemfilecols, Datafilecols, colNameList);

                                                                                                            }
                                                                                                            line = string.Join(string.Empty, colNameList.ToArray());

                                                                                                            swTargetFileAppend.WriteLine(line);
                                                                                                            IsWriteNextLine = true;
                                                                                                        }
                                                                                                    }
                                                                                                    else
                                                                                                    {
                                                                                                        if (count == 4)
                                                                                                        {
                                                                                                            List<string> colNameList = ColNameSplitLineCZCE(line);

                                                                                                            foreach (XElement itemfilecols in itemfileSrc.Nodes())
                                                                                                            {
                                                                                                                if (true)
                                                                                                                {
                                                                                                                    if (!string.IsNullOrEmpty(itemfilecols.Attribute("tlength").Value) && (int.Parse(itemfilecols.Attribute("tlength").Value.Trim()) > 0)) //列名位数 +对齐方式
                                                                                                                    {
                                                                                                                        string align = itemfilecols.Attribute("align").Value;

                                                                                                                        if (!string.IsNullOrEmpty(align) && align.Equals("左"))
                                                                                                                        {
                                                                                                                            colNameList[int.Parse(itemfilecols.Attribute("cid").Value.Trim()) - 1] = colNameList[int.Parse(itemfilecols.Attribute("cid").Value.Trim()) - 1].Trim().PadRight(int.Parse(itemfilecols.Attribute("tlength").Value.Trim()), ' ');//以空格填充
                                                                                                                        }
                                                                                                                        if (!string.IsNullOrEmpty(align) && align.Equals("右"))
                                                                                                                        {
                                                                                                                            colNameList[int.Parse(itemfilecols.Attribute("cid").Value.Trim()) - 1] = colNameList[int.Parse(itemfilecols.Attribute("cid").Value.Trim()) - 1].Trim().PadLeft(int.Parse(itemfilecols.Attribute("tlength").Value.Trim()), ' ');//以空格填充
                                                                                                                        }
                                                                                                                        //colNameList[int.Parse(itemfilecols.Attribute("cid").Value.Trim())] = 
                                                                                                                    }
                                                                                                                }
                                                                                                            }
                                                                                                            //{//if (!string.IsNullOrEmpty(itemfilecols.Attribute("tlength").Value) && (int.Parse(itemfilecols.Attribute("tlength").Value.Trim()) > 0)) //列名位数
                                                                                                            // //{

                                                                                                            //    //}
                                                                                                            //}
                                                                                                            line = string.Join(string.Empty, colNameList.ToArray());
                                                                                                        }
                                                                                                        swTargetFileAppend.WriteLine(line);
                                                                                                        count = count + 1;
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                            catch (Exception ex)
                                                                                            {
                                                                                                SingleFileIsSuccess = false;
                                                                                            }

                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            using (FileStream fsTargetFile = new FileStream(targetFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                                                                                            {
                                                                                                using (StreamWriter swTargetFile = new StreamWriter(fsTargetFile, Encoding.GetEncoding("GB2312")))
                                                                                                {
                                                                                                    swTargetFile.WriteLine(line);
                                                                                                    count = count + 1;
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
                                                    }
                                                }

                                                //生成大商所文件
                                                foreach (string itemSingleMotorCenterAccount in SingleMotorCenterAccount)
                                                {
                                                    foreach (XElement itemAccountId in configDocument.Descendants("AccountId"))
                                                    {
                                                        if (itemAccountId.Attribute("value").Value == itemSingleMotorCenterAccount)
                                                        {
                                                            foreach (XElement itemOrganCode in itemAccountId.Descendants("OrganCode"))
                                                            {
                                                                if (itemOrganCode.Attribute("name").Value == "大商所")
                                                                {
                                                                    foreach (XElement itemfile in itemOrganCode.Nodes())
                                                                    {
                                                                        foreach (XElement itemfileSrc in itemfile.Nodes())
                                                                        {
                                                                            SourceFileName = Path.Combine(OriginPath.ToString() + "\\" + kryDTPDate.Value.ToString("yyyyMMdd") + string.Format("\\{0}_持仓明细表.txt", kryDTPDate.Value.ToString("yyyyMMdd")));

                                                                            //按账号导出的目录
                                                                            string txtFileName = (itemfile.Attribute("filename").Value.ToString().Replace("{accountid}", itemSingleMotorCenterAccount)).Replace("{tradingday}", kryDTPDate.Value.ToString("yyyyMMdd"));

                                                                            targetFileName = Path.Combine(MonitorCenterOutPath1.ToString() + "\\" + string.Format(@"{0}\大商所格式\TXT文件\{1}\{2}.txt", itemSingleMotorCenterAccount, kryDTPDate.Value.ToString("yyyyMMdd"), txtFileName));
                                                                            targetDirectoryName = Path.Combine(MonitorCenterOutPath1.ToString() + "\\" + string.Format(@"{0}\大商所格式\TXT文件\{1}", itemSingleMotorCenterAccount, kryDTPDate.Value.ToString("yyyyMMdd")));
                                                                            targetDirectoryName1 = Path.Combine(MonitorCenterOutPath2.ToString() + "\\" + string.Format(@"{0}\大商所格式\TXT文件\{1}", itemSingleMotorCenterAccount, kryDTPDate.Value.ToString("yyyyMMdd")));

                                                                            if (!Directory.Exists(targetDirectoryName))
                                                                            {
                                                                                Directory.CreateDirectory(targetDirectoryName);
                                                                            }
                                                                            if (File.Exists(targetFileName))
                                                                            {
                                                                                File.Delete(targetFileName);
                                                                            }
                                                                            if (!File.Exists(SourceFileName))
                                                                            {
                                                                                MessageBox.Show("{大商所持仓明细表不存在", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                                continue;
                                                                            }

                                                                            using (FileStream fsSourceFile = new FileStream(SourceFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                                                                            {
                                                                                using (StreamReader swSourceFile = new StreamReader(fsSourceFile, Encoding.GetEncoding("GB2312")))
                                                                                {
                                                                                    string line = string.Empty;
                                                                                    int count = 0;
                                                                                    bool IsWriteNextLine = false;

                                                                                    while ((line = swSourceFile.ReadLine()) != null)
                                                                                    {
                                                                                        if (count > 0)
                                                                                        {
                                                                                            try
                                                                                            {
                                                                                                using (StreamWriter swTargetFileAppend = new StreamWriter(targetFileName, true, Encoding.GetEncoding("GB2312")))
                                                                                                {
                                                                                                    if (count > 3)
                                                                                                    {
                                                                                                        if (!string.IsNullOrEmpty(line.Trim()) && line.Substring(30, 8).Equals(itemSingleMotorCenterAccount))   //itemSingleMotorCenterAccount  01767714
                                                                                                        {
                                                                                                            List<string> colNameList = ColValueSplitLineDCE(line);
                                                                                                            foreach (XElement itemfilecols in itemfileSrc.Nodes())
                                                                                                            {
                                                                                                                string Datafilecols = colNameList[int.Parse(itemfilecols.Attribute("cid").Value.Trim()) - 1];

                                                                                                                colNameList = DCEDealData(itemfilecols, Datafilecols, colNameList);

                                                                                                            }
                                                                                                            line = string.Join(string.Empty, colNameList.ToArray());

                                                                                                            swTargetFileAppend.WriteLine(line);
                                                                                                            IsWriteNextLine = true;
                                                                                                        }
                                                                                                        count = count + 1;
                                                                                                    }
                                                                                                    else
                                                                                                    {
                                                                                                        if (count == 3)
                                                                                                        {
                                                                                                            List<string> colNameList = ColNameSplitLineDCE(line);

                                                                                                            foreach (XElement itemfilecols in itemfileSrc.Nodes())
                                                                                                            {
                                                                                                                if (true)
                                                                                                                {
                                                                                                                    if (!string.IsNullOrEmpty(itemfilecols.Attribute("tlength").Value) && (int.Parse(itemfilecols.Attribute("tlength").Value.Trim()) > 0)) //列名位数 +对齐方式
                                                                                                                    {
                                                                                                                        string align = itemfilecols.Attribute("align").Value;

                                                                                                                        if (!string.IsNullOrEmpty(align) && align.Equals("左"))
                                                                                                                        {
                                                                                                                            colNameList[int.Parse(itemfilecols.Attribute("cid").Value.Trim()) - 1] = colNameList[int.Parse(itemfilecols.Attribute("cid").Value.Trim()) - 1].Trim().PadRight(int.Parse(itemfilecols.Attribute("tlength").Value.Trim()), ' ');//以空格填充
                                                                                                                        }
                                                                                                                        if (!string.IsNullOrEmpty(align) && align.Equals("右"))
                                                                                                                        {
                                                                                                                            colNameList[int.Parse(itemfilecols.Attribute("cid").Value.Trim()) - 1] = colNameList[int.Parse(itemfilecols.Attribute("cid").Value.Trim()) - 1].Trim().PadLeft(int.Parse(itemfilecols.Attribute("tlength").Value.Trim()), ' ');//以空格填充
                                                                                                                        }
                                                                                                                    }
                                                                                                                }
                                                                                                            }
                                                                                                            line = string.Join(string.Empty, colNameList.ToArray());
                                                                                                        }
                                                                                                        swTargetFileAppend.WriteLine(line);
                                                                                                        count = count + 1;
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                            catch (Exception ex)
                                                                                            {
                                                                                                SingleFileIsSuccess = false;
                                                                                                MessageBox.Show(ex.Message.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                                                return;
                                                                                            }
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            using (FileStream fsTargetFile = new FileStream(targetFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                                                                                            {
                                                                                                using (StreamWriter swTargetFile = new StreamWriter(fsTargetFile, Encoding.GetEncoding("GB2312")))
                                                                                                {
                                                                                                    swTargetFile.WriteLine(line);
                                                                                                    count = count + 1;
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
                                                    }
                                                }
                                            }

                                        });
                                        task.Start();
                                        task.ContinueWith((t) =>
                                        {
                                            if (InvokeRequired)
                                            {
                                                this.Invoke(new Action(() =>
                                                {
                                                    // _frmWait.Close();
                                                    if (SingleFileIsSuccess)
                                                    {
                                                        itemRows.Cells[4].Value += "单账号文件生成成功,";
                                                        //krypLbFlag.Text = "读入原文件结束...";
                                                        MessageBox.Show("单账号生成文件生成成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    }
                                                    else
                                                    {
                                                        itemRows.Cells[4].Value += "单账号文件生成失败,";
                                                        //由于SingleFileIsSuccess是全局变量。当某一次文件生成失败为false时，后续的值就一直是false了，因为这个将其置为true
                                                        SingleFileIsSuccess = true;
                                                        //krypLbFlag.Text = "读入原文件结束...";
                                                        MessageBox.Show("单账号生成文件生成失败", "失败", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    }

                                                }));
                                            }
                                            else
                                            {
                                                if (SingleFileIsSuccess)
                                                {
                                                    //由于SingleFileIsSuccess是全局变量。当某一次文件生成失败为false时，后续的值就一直是false了，因为这个将其置为true
                                                    SingleFileIsSuccess = true;
                                                    //krypLbFlag.Text = "单账号生成读入原文件结束...";
                                                    MessageBox.Show("单账号生成文件生成失败", "失败", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                }
                                            }
                                        });
                                        #endregion


                                        //多账户合并
                                        Task taskMERGE = new Task(() =>
                                        {
                                            if (this.InvokeRequired)
                                            {
                                                this.Invoke(new Action(() =>
                                                {
                                                    try
                                                    {
                                                        #region
                                                        // 生成中金所
                                                        bool IsExistCffex = false; //此标志是为了第二次写入文件事，向已存在的文件追加东西，而不是覆盖原文件
                                                        Dictionary<string, string> ColumnNameDict = new Dictionary<string, string>();
                                                        List<string> FileHaveColumnNameList = new List<string>();

                                                        List<string> CapitalDBFAccountNo = new List<string>(); //这个标志的作用是将会员资金情况表的dbf文件的accountNo列的值写入正确的资金账号
                                                        foreach (string itemMoreMotorCenterAccount in MergeCffexAccount)
                                                        {
                                                            foreach (XElement itemAccountId in configDocument.Descendants("AccountId"))
                                                            {
                                                                if (itemAccountId.Attribute("value").Value == itemMoreMotorCenterAccount)
                                                                {
                                                                    if (itemAccountId.Attribute("cffexFile").Equals("0")) //不生成中金所文件
                                                                    {
                                                                        return;
                                                                    }
                                                                    foreach (XElement itemOrganCode in itemAccountId.Descendants("OrganCode"))
                                                                    {

                                                                        if (itemOrganCode.Attribute("name").Value == "中金所")
                                                                        {
                                                                            foreach (XElement itemfile in itemOrganCode.Nodes())
                                                                            {
                                                                                string str = "其中：交易保证金               635757  "; //我们抓取当前字符当中的123.11
                                                                                str = Regex.Replace(str, @"[^\d.\d]", "");

                                                                                bool sdg = Regex.IsMatch(str, @"\d+$");
                                                                                if ((itemfile.Attribute("filetitle").Value == "会员资金情况表") && itemfile.Attribute("fileext").Value == "DBF")
                                                                                {

                                                                                }
                                                                                if (itemfile.Attribute("fileext").Value == "DBF") //此时过滤之后，能进入到下面的dbf文件。只有会员资金情况表
                                                                                {
                                                                                    if (itemfile.Attribute("filetitle").Value != "会员资金情况表")
                                                                                    {
                                                                                        continue;
                                                                                    }
                                                                                }
                                                                                List<string> colnumName = new List<string>();
                                                                                List<string> colnumNameTMP = new List<string>();
                                                                                //List<string> colnumValue = new List<string>();
                                                                                //Dictionary<int, string> colnumValueFinal = new Dictionary<int, string>();
                                                                                List<Dictionary<int, string>> colnumValueFinal = new List<Dictionary<int, string>>();
                                                                                DataTable dtResult = new DataTable();
                                                                                DataTable dt = new DataTable();
                                                                                List<string> DBFColumnNamelist = new List<string>();
                                                                                bool IsTransverse = false;  //是否横向的标志
                                                                                bool IsOutColumn = false;


                                                                                //if (itemAccountId.Attribute("outType").Value.Equals("1"))  //按日期导出at
                                                                                //{

                                                                                if (itemfile.Attribute("fileext").Value == "DBF" && itemfile.Attribute("filetitle").Value == "会员资金情况表") //单独处理会员资金情况表的dbf文件，设计思路是先生成一个这个dbf文件的txt文件
                                                                                {
                                                                                    string targetFile = (itemfile.Attribute("filename").Value.ToString().Replace("{accountid}", GlobalData.SGMemberID)).Replace("{tradingday}", kryDTPDate.Value.ToString("yyyyMMdd")) + "Temp";
                                                                                    string DBFtargetFile = (itemfile.Attribute("filename").Value.ToString().Replace("{accountid}", GlobalData.SGMemberID)).Replace("{tradingday}", kryDTPDate.Value.ToString("yyyyMMdd"));
                                                                                    targetFileName = Path.Combine(MonitorCenterOutPath1.ToString() + "\\" + string.Format(@"{0}\中金所格式\TXT文件\{1}\{2}.txt", kryDTPDate.Value.ToString("yyyyMMdd"), GlobalData.SGMemberID, targetFile));
                                                                                    targetDirectoryName = Path.Combine(MonitorCenterOutPath1.ToString() + "\\" + string.Format(@"{0}\中金所格式\TXT文件\{1}", kryDTPDate.Value.ToString("yyyyMMdd"), GlobalData.SGMemberID));
                                                                                    targetDirectoryName1 = Path.Combine(MonitorCenterOutPath2.ToString() + "\\" + string.Format(@"{0}\中金所格式\TXT文件\{1}", kryDTPDate.Value.ToString("yyyyMMdd"), GlobalData.SGMemberID));

                                                                                    targetDBFDirectoryName = Path.Combine(MonitorCenterOutPath1.ToString() + "\\" + string.Format(@"{0}\中金所格式\DBF文件\{1}", kryDTPDate.Value.ToString("yyyyMMdd"), GlobalData.SGMemberID));
                                                                                    targetDBFFileName = Path.Combine(MonitorCenterOutPath1.ToString() + "\\" + string.Format(@"{0}\中金所格式\DBF文件\{1}\{2}.dbf", kryDTPDate.Value.ToString("yyyyMMdd"), GlobalData.SGMemberID, DBFtargetFile));
                                                                                }
                                                                                else
                                                                                {
                                                                                    string targetFile = (itemfile.Attribute("filename").Value.ToString().Replace("{accountid}", GlobalData.SGMemberID)).Replace("{tradingday}", kryDTPDate.Value.ToString("yyyyMMdd"));
                                                                                    targetFileName = Path.Combine(MonitorCenterOutPath1.ToString() + "\\" + string.Format(@"{0}\中金所格式\TXT文件\{1}\{2}.txt", kryDTPDate.Value.ToString("yyyyMMdd"), GlobalData.SGMemberID, targetFile));
                                                                                    targetDirectoryName = Path.Combine(MonitorCenterOutPath1.ToString() + "\\" + string.Format(@"{0}\中金所格式\TXT文件\{1}", kryDTPDate.Value.ToString("yyyyMMdd"), GlobalData.SGMemberID));
                                                                                    targetDirectoryName1 = Path.Combine(MonitorCenterOutPath2.ToString() + "\\" + string.Format(@"{0}\中金所格式\TXT文件\{1}", kryDTPDate.Value.ToString("yyyyMMdd"), GlobalData.SGMemberID));

                                                                                    targetDBFDirectoryName = Path.Combine(MonitorCenterOutPath1.ToString() + "\\" + string.Format(@"{0}\中金所格式\DBF文件\{1}", kryDTPDate.Value.ToString("yyyyMMdd"), GlobalData.SGMemberID));
                                                                                    targetDBFFileName = Path.Combine(MonitorCenterOutPath1.ToString() + "\\" + string.Format(@"{0}\中金所格式\DBF文件\{1}\{2}.dbf", kryDTPDate.Value.ToString("yyyyMMdd"), GlobalData.SGMemberID, targetFile));
                                                                                }

                                                                                //}
                                                                                //else   //按账号导出
                                                                                //{
                                                                                //    string targetFile = (itemfile.Attribute("filename").Value.ToString().Replace("{accountid}", itemMoreMotorCenterAccount)).Replace("{tradingday}", kryDTPDate.Value.ToString("yyyyMMdd"));
                                                                                //    targetFileName = Path.Combine(MonitorCenterOutPath1.ToString() + "\\" + string.Format(@"{0}\中金所格式\TXT文件\{1}\{2}.txt", itemMoreMotorCenterAccount, kryDTPDate.Value.ToString("yyyyMMdd"), targetFile));
                                                                                //    targetDirectoryName = Path.Combine(MonitorCenterOutPath1.ToString() + "\\" + string.Format(@"{0}\中金所格式\TXT文件\{1}", itemMoreMotorCenterAccount, kryDTPDate.Value.ToString("yyyyMMdd")));
                                                                                //    targetDirectoryName1 = Path.Combine(MonitorCenterOutPath2.ToString() + "\\" + string.Format(@"{0}\中金所格式\TXT文件\{1}", itemMoreMotorCenterAccount, kryDTPDate.Value.ToString("yyyyMMdd")));

                                                                                //    targetDBFDirectoryName = Path.Combine(MonitorCenterOutPath1.ToString() + "\\" + string.Format(@"{0}\中金所格式\DBF文件\{1}", itemMoreMotorCenterAccount, kryDTPDate.Value.ToString("yyyyMMdd")));
                                                                                //    targetDBFFileName = Path.Combine(MonitorCenterOutPath1.ToString() + "\\" + string.Format(@"{0}\中金所格式\DBF文件\{1}\{2}.dbf", itemMoreMotorCenterAccount, kryDTPDate.Value.ToString("yyyyMMdd"), targetFile));
                                                                                //}

                                                                                if (!Directory.Exists(targetDirectoryName))
                                                                                {
                                                                                    Directory.CreateDirectory(targetDirectoryName);
                                                                                }
                                                                                else
                                                                                {
                                                                                    if (!IsExistCffex)
                                                                                    {
                                                                                        //为了删除掉此目录下遗留下来的上次文件
                                                                                        DirectoryInfo targetDirectoryInfo = new DirectoryInfo(targetDirectoryName);
                                                                                        targetDirectoryInfo.Delete(true);

                                                                                        Directory.CreateDirectory(targetDirectoryName);
                                                                                    }
                                                                                }
                                                                                if (!Directory.Exists(targetDBFDirectoryName))
                                                                                {
                                                                                    Directory.CreateDirectory(targetDBFDirectoryName);
                                                                                }
                                                                                else
                                                                                {
                                                                                    if (!IsExistCffex)
                                                                                    {
                                                                                        //为了删除掉此目录下遗留下来的上次文件
                                                                                        DirectoryInfo targetDirectoryInfo = new DirectoryInfo(targetDBFDirectoryName);
                                                                                        targetDirectoryInfo.Delete(true);

                                                                                        Directory.CreateDirectory(targetDBFDirectoryName);
                                                                                    }
                                                                                }
                                                                                //if (!Directory.Exists(targetDirectoryName))
                                                                                //{
                                                                                //    Directory.CreateDirectory(targetDirectoryName);
                                                                                //}
                                                                                //if (!Directory.Exists(targetDBFDirectoryName))
                                                                                //{
                                                                                //    Directory.CreateDirectory(targetDBFDirectoryName);
                                                                                //}
                                                                                //if (File.Exists(targetFileName) && !IsExistCffex)
                                                                                //{
                                                                                //    File.Delete(targetFileName);
                                                                                //}
                                                                                //if (File.Exists(targetDBFFileName) && !IsExistCffex)
                                                                                //{
                                                                                //    File.Delete(targetDBFFileName);
                                                                                //}

                                                                                if (itemfile.Attribute("IsOutPut").Value == "否")
                                                                                {
                                                                                    continue;
                                                                                }
                                                                                if (!File.Exists(targetFileName))
                                                                                {
                                                                                    using (FileStream fsTargetFile = new FileStream(targetFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                                                                                    {
                                                                                        using (StreamWriter swTargetFile = new StreamWriter(fsTargetFile))
                                                                                        {
                                                                                            string info = itemfile.Attribute("filetitle").Value.ToString().PadLeft(30) + "\r\n" + "\r\n" + string.Format("结算会员号：{0}", GlobalData.SGMemberID/*0102*/).PadRight(30) + string.Format("结算会员名称：{0}", GlobalData.CompanyName/*"abc公司"*/).PadRight(30) + string.Format("结算日期：{0}", kryDTPDate.Value.ToString("yyyyMMdd")).PadRight(30) + "\n";
                                                                                            swTargetFile.Write(info);
                                                                                            //IsExistCffex = true;
                                                                                        }
                                                                                    }
                                                                                }

                                                                                foreach (XElement itemfileSrc in itemfile.Descendants("fileSrc"))
                                                                                {
                                                                                    //要求每个资金账号的横线行都输出
                                                                                    //生成横线行
                                                                                    if (string.IsNullOrEmpty(itemfileSrc.Attribute("srcfile").Value))
                                                                                    {
                                                                                        IsTransverse = true;
                                                                                        using (StreamWriter swTargetFile = File.AppendText(targetFileName))
                                                                                        {
                                                                                            string line = string.Empty;
                                                                                            foreach (XElement itemfilecols in itemfileSrc.Nodes())
                                                                                            {
                                                                                                char padstr = string.IsNullOrEmpty(itemfilecols.Attribute("padstr").Value.Trim()) ? (' ') : (itemfilecols.Attribute("padstr").Value.Trim().ToCharArray()[0]);
                                                                                                if (string.IsNullOrEmpty(itemfilecols.Attribute("FixValue").Value))
                                                                                                {
                                                                                                    line = "";
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    line += itemfilecols.Attribute("FixValue").Value.PadRight(int.Parse(itemfilecols.Attribute("vlength").Value), (padstr));
                                                                                                }

                                                                                                if (itemfilecols.Attribute("isout").Value == "否")
                                                                                                {
                                                                                                    line = "";
                                                                                                }
                                                                                            }
                                                                                            swTargetFile.WriteLine(line);
                                                                                            //IsExistCffex = true;
                                                                                        }
                                                                                        continue;

                                                                                    }

                                                                                    foreach (XElement itemfilecols in itemfileSrc.Nodes())
                                                                                    {
                                                                                        if (dtResult.Columns.Count == 0)
                                                                                        {
                                                                                            dtResult.Columns.Add(itemfilecols.Attribute("label").Value, typeof(System.String));
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            if (!dtResult.Columns.Contains(itemfilecols.Attribute("label").Value))
                                                                                            {
                                                                                                dtResult.Columns.Add(itemfilecols.Attribute("label").Value, typeof(System.String));
                                                                                            }
                                                                                        }
                                                                                        if (itemfilecols.Attribute("isout").Value == "是" && itemfile.Attribute("arrangeType").Value == "纵向")
                                                                                        {
                                                                                            if (DBFColumnNamelist.Count == 0)
                                                                                            {
                                                                                                DBFColumnNamelist.Add(itemfilecols.Attribute("code").Value);
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                if (!DBFColumnNamelist.Contains(itemfilecols.Attribute("code").Value))
                                                                                                {
                                                                                                    DBFColumnNamelist.Add(itemfilecols.Attribute("code").Value);
                                                                                                }
                                                                                            }
                                                                                        }

                                                                                    }
                                                                                    if (itemfileSrc.Attribute("srcfileType").Value.Equals("监控中心"))
                                                                                    {
                                                                                        SourceFileName = Path.Combine(OriginPath.ToString() + "\\" + kryDTPDate.Value.ToString("yyyyMMdd") + string.Format("\\{0}{1}{2}.txt", GlobalData.SeatNo, itemfileSrc.Attribute("srcfile").Value, kryDTPDate.Value.ToString("yyyyMMdd")));
                                                                                    }
                                                                                    else if (itemfileSrc.Attribute("srcfileType").Value.Equals("交易所"))
                                                                                    {
                                                                                        SourceFileName = Path.Combine(OriginPath.ToString() + "\\" + kryDTPDate.Value.ToString("yyyyMMdd") + string.Format("\\{0}.DBF", itemfileSrc.Attribute("srcfile").Value));

                                                                                        SourceFileName = SourceFileName.Replace("{tradingday}", kryDTPDate.Value.ToString("yyyyMMdd"));
                                                                                        //读dbf
                                                                                        try
                                                                                        {
                                                                                            TDbfReader dbfFile = new TDbfReader(SourceFileName);
                                                                                            //dbfFile.SaveToTXT();
                                                                                            dt = dbfFile.Table;
                                                                                        }
                                                                                        catch (Exception ex)
                                                                                        {
                                                                                            MergeFileIsSuccess = false;
                                                                                            MessageBox.Show(this, ex.Message, "加载DBF失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                                            return;
                                                                                        }

                                                                                        //int iIndex = SourceFileName.LastIndexOf('\\');
                                                                                        //string strConn = @"Provider=vfpoledb;Data Source=" + SourceFileName.Substring(0, iIndex) + ";Collating Sequence=machine;";
                                                                                        //try
                                                                                        //{
                                                                                        //    using (OleDbConnection oleCon = new OleDbConnection(strConn))
                                                                                        //    {
                                                                                        //        oleCon.Open();
                                                                                        //        //if (string.IsNullOrEmpty(sSQL))
                                                                                        //        string sSQL = "SELECT * FROM " + SourceFileName.Substring(iIndex + 1);

                                                                                        //        OleDbDataAdapter adapter = new OleDbDataAdapter(sSQL, oleCon);

                                                                                        //        DataTable dt = new DataTable();
                                                                                        //        adapter.Fill(dt);

                                                                                        //        //return dt;
                                                                                        //    }
                                                                                        //}
                                                                                        //catch (System.Exception ex)
                                                                                        //{
                                                                                        //    MessageBox.Show(this, ex.Message, "加载DBF失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                                        //   // return null;
                                                                                        //}
                                                                                    }


                                                                                    if (!File.Exists(SourceFileName))
                                                                                    {
                                                                                        MessageBox.Show(string.Format("{0}文件不存在", itemfile.Attribute("filetitle").Value), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                                        continue;
                                                                                    }
                                                                                    if (itemfileSrc.Attribute("srcfileType").Value.Equals("监控中心"))
                                                                                    {
                                                                                        //if (colnumName.Count  > 0 &&  !colnumName.Contains(itemfileSrc.Attribute("label").Value))
                                                                                        //{
                                                                                        //    colnumName.Add(itemfileSrc.Attribute("label").Value);
                                                                                        //}
                                                                                        if (IsTransverse && !IsOutColumn) //要求每个横向输出的资金账号都要输出列
                                                                                        {
                                                                                            //横线行输出的。先输出列
                                                                                            using (StreamWriter swTargetFile = File.AppendText(targetFileName))
                                                                                            {
                                                                                                foreach (XElement itemfilecols in itemfileSrc.Nodes())
                                                                                                {
                                                                                                    string line = string.Empty;
                                                                                                    if (!string.IsNullOrEmpty(itemfilecols.Attribute("isout").Value.Trim()))   //是否输出
                                                                                                    {
                                                                                                        if (itemfilecols.Attribute("isout").Value.Trim() == "否")
                                                                                                        {
                                                                                                            line = "";
                                                                                                        }
                                                                                                        else
                                                                                                        {
                                                                                                            if (!string.IsNullOrEmpty(itemfilecols.Attribute("tlength").Value) && (int.Parse(itemfilecols.Attribute("tlength").Value.Trim()) > 0)) //列名位数 +对齐方式
                                                                                                            {
                                                                                                                string align = itemfilecols.Attribute("align").Value;

                                                                                                                line = dtResult.Columns[int.Parse(itemfilecols.Attribute("cid").Value.Trim())].ToString().Trim().PadRight(int.Parse(itemfilecols.Attribute("tlength").Value.Trim()), ' ');//以空格填充
                                                                                                            }
                                                                                                        }
                                                                                                    }
                                                                                                    swTargetFile.WriteLine(line);
                                                                                                }
                                                                                                IsOutColumn = true;
                                                                                            }
                                                                                        }

                                                                                        //处理数据，将数据放在dtResult中
                                                                                        using (FileStream fsSourceFile = new FileStream(SourceFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                                                                                        {
                                                                                            using (StreamReader swSourceFile = new StreamReader(fsSourceFile))
                                                                                            {
                                                                                                string line = string.Empty;

                                                                                                while ((line = swSourceFile.ReadLine()) != null)
                                                                                                {
                                                                                                    string[] sArray = line.Split('@');

                                                                                                    if (sArray[0] == kryDTPDate.Value.ToString("yyyy-MM-dd") && sArray[1] == itemMoreMotorCenterAccount)
                                                                                                    {
                                                                                                        try
                                                                                                        {
                                                                                                            Dictionary<int, string> colnumValue = new Dictionary<int, string>();
                                                                                                            DataRow dr = dtResult.NewRow();

                                                                                                            //为中国金融期货交易所 客户分项资金明细表做的特殊处理，因为他里面的字段索引cid从1 开始 ，已改成从0开始，其实和普通的其他中金表一样的索引了
                                                                                                            if (itemfile.Attribute("filetitle").Value.ToString() == "中国金融期货交易所 客户分项资金明细表")
                                                                                                            {

                                                                                                                foreach (XElement itemfilecols in itemfileSrc.Nodes())
                                                                                                                {
                                                                                                                    //dtResult.Columns.Add(itemfilecols.Attribute("label").Value, typeof(System.String));

                                                                                                                    if (colnumName.Count == 0)
                                                                                                                    {
                                                                                                                        colnumName.Add(itemfilecols.Attribute("label").Value);
                                                                                                                        colnumNameTMP.Add(itemfilecols.Attribute("label").Value);
                                                                                                                    }
                                                                                                                    else
                                                                                                                    {
                                                                                                                        if (!colnumNameTMP.Contains(itemfilecols.Attribute("label").Value.Trim()))
                                                                                                                        {
                                                                                                                            colnumName.Add(itemfilecols.Attribute("label").Value);
                                                                                                                            colnumNameTMP.Add(itemfilecols.Attribute("label").Value);
                                                                                                                        }
                                                                                                                    }
                                                                                                                    if (!string.IsNullOrEmpty(itemfilecols.Attribute("isout").Value.Trim()))   //是否输出
                                                                                                                    {
                                                                                                                        if (itemfilecols.Attribute("isout").Value.Trim() == "否")
                                                                                                                        {
                                                                                                                            colnumName[int.Parse(itemfilecols.Attribute("cid").Value.Trim())] = "";
                                                                                                                        }
                                                                                                                        else
                                                                                                                        {
                                                                                                                            if (!string.IsNullOrEmpty(itemfilecols.Attribute("tlength").Value) && (int.Parse(itemfilecols.Attribute("tlength").Value.Trim()) > 0)) //列名位数 +对齐方式
                                                                                                                            {
                                                                                                                                string align = itemfilecols.Attribute("align").Value;

                                                                                                                                if (!string.IsNullOrEmpty(align) && align.Equals("左"))
                                                                                                                                {
                                                                                                                                    colnumName[int.Parse(itemfilecols.Attribute("cid").Value.Trim())] = colnumName[int.Parse(itemfilecols.Attribute("cid").Value.Trim())].Trim().PadRight(int.Parse(itemfilecols.Attribute("tlength").Value.Trim()), ' ');//以空格填充
                                                                                                                                }
                                                                                                                                if (!string.IsNullOrEmpty(align) && align.Equals("右"))
                                                                                                                                {
                                                                                                                                    colnumName[int.Parse(itemfilecols.Attribute("cid").Value.Trim())] = colnumName[int.Parse(itemfilecols.Attribute("cid").Value.Trim())].Trim().PadLeft(int.Parse(itemfilecols.Attribute("tlength").Value.Trim()), ' ');//以空格填充
                                                                                                                                }

                                                                                                                            }
                                                                                                                        }
                                                                                                                        //sArray[int.Parse(itemfilecols.Attribute("colIndex").Value) - 1] = Datafilecols;
                                                                                                                    }

                                                                                                                    string Datafilecols = string.Empty;
                                                                                                                    if (!string.IsNullOrEmpty(itemfilecols.Attribute("colIndex").Value.Trim()))
                                                                                                                    {
                                                                                                                        Datafilecols = sArray[int.Parse(itemfilecols.Attribute("colIndex").Value) - 1];

                                                                                                                        if (colnumValue.ContainsKey(int.Parse(itemfilecols.Attribute("cid").Value.ToString())))
                                                                                                                        {
                                                                                                                            Dictionary<int, string>.ValueCollection value = colnumValue.Values;

                                                                                                                            //string newValue = (int.Parse(colnumValue[int.Parse(itemfilecols.Attribute("cid").Value.ToString())]) + int.Parse(SGDealData(itemfilecols, Datafilecols, sArray))).ToString();

                                                                                                                            string newValue = (int.Parse(value.ElementAt(int.Parse(itemfilecols.Attribute("cid").Value.ToString()))) + int.Parse(SGDealData(itemfilecols, Datafilecols, sArray))).ToString();
                                                                                                                            colnumValue[int.Parse(itemfilecols.Attribute("cid").Value.ToString())] = newValue.Trim();

                                                                                                                            //string newValue = dr[int.Parse(itemfilecols.Attribute("cid").Value.ToString())].ToString() + Datafilecols;

                                                                                                                            dr[int.Parse(itemfilecols.Attribute("cid").Value.ToString())] = newValue.Trim();
                                                                                                                        }
                                                                                                                        else
                                                                                                                        {
                                                                                                                            colnumValue.Add(int.Parse(itemfilecols.Attribute("cid").Value.ToString()), SGDealData(itemfilecols, Datafilecols, sArray));
                                                                                                                            //dr[int.Parse(itemfilecols.Attribute("cid").Value.ToString())] = SGDealData(itemfilecols, Datafilecols, sArray);
                                                                                                                            if (!string.IsNullOrEmpty(itemfilecols.Attribute("express").Value.Trim().ToString()) && itemfilecols.Attribute("express").Value.Trim() == "-")
                                                                                                                            {
                                                                                                                                Datafilecols = "-" + Datafilecols.Trim();
                                                                                                                            }
                                                                                                                            dr[int.Parse(itemfilecols.Attribute("cid").Value.ToString())] = Datafilecols.Trim();
                                                                                                                        }
                                                                                                                    }
                                                                                                                    //sArray = SGDealData(itemfilecols, Datafilecols, sArray);
                                                                                                                    if (sArray[0] == "数据处理出错")
                                                                                                                    {
                                                                                                                        MergeFileIsSuccess = false;
                                                                                                                        MessageBox.Show(sArray[0], "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                                                                        return;
                                                                                                                    }

                                                                                                                }
                                                                                                            }
                                                                                                            else  //普通的中金表
                                                                                                            {
                                                                                                                foreach (XElement itemfilecols in itemfileSrc.Nodes())
                                                                                                                {
                                                                                                                    //dtResult.Columns.Add(itemfilecols.Attribute("label").Value, typeof(System.String));

                                                                                                                    if (colnumName.Count == 0)
                                                                                                                    {
                                                                                                                        colnumName.Add(itemfilecols.Attribute("label").Value);
                                                                                                                        colnumNameTMP.Add(itemfilecols.Attribute("label").Value);
                                                                                                                    }
                                                                                                                    else
                                                                                                                    {
                                                                                                                        if (!colnumNameTMP.Contains(itemfilecols.Attribute("label").Value.Trim()))
                                                                                                                        {
                                                                                                                            colnumName.Add(itemfilecols.Attribute("label").Value);
                                                                                                                            colnumNameTMP.Add(itemfilecols.Attribute("label").Value);
                                                                                                                        }
                                                                                                                    }
                                                                                                                    if (!string.IsNullOrEmpty(itemfilecols.Attribute("isout").Value.Trim()))   //是否输出
                                                                                                                    {
                                                                                                                        if (itemfilecols.Attribute("isout").Value.Trim() == "否")
                                                                                                                        {
                                                                                                                            colnumName[int.Parse(itemfilecols.Attribute("cid").Value.Trim())] = "";
                                                                                                                        }
                                                                                                                        else
                                                                                                                        {
                                                                                                                            if (!string.IsNullOrEmpty(itemfilecols.Attribute("tlength").Value) && (int.Parse(itemfilecols.Attribute("tlength").Value.Trim()) > 0)) //列名位数 +对齐方式
                                                                                                                            {
                                                                                                                                string align = itemfilecols.Attribute("align").Value;

                                                                                                                                if (!string.IsNullOrEmpty(align) && align.Equals("左"))
                                                                                                                                {
                                                                                                                                    colnumName[int.Parse(itemfilecols.Attribute("cid").Value.Trim())] = colnumName[int.Parse(itemfilecols.Attribute("cid").Value.Trim())].Trim().PadRight(int.Parse(itemfilecols.Attribute("tlength").Value.Trim()), ' ');//以空格填充
                                                                                                                                }
                                                                                                                                if (!string.IsNullOrEmpty(align) && align.Equals("右"))
                                                                                                                                {
                                                                                                                                    colnumName[int.Parse(itemfilecols.Attribute("cid").Value.Trim())] = colnumName[int.Parse(itemfilecols.Attribute("cid").Value.Trim())].Trim().PadLeft(int.Parse(itemfilecols.Attribute("tlength").Value.Trim()), ' ');//以空格填充
                                                                                                                                }

                                                                                                                            }
                                                                                                                        }
                                                                                                                        //sArray[int.Parse(itemfilecols.Attribute("colIndex").Value) - 1] = Datafilecols;
                                                                                                                    }

                                                                                                                    string Datafilecols = string.Empty;
                                                                                                                    if (!string.IsNullOrEmpty(itemfilecols.Attribute("colIndex").Value.Trim()))
                                                                                                                    {
                                                                                                                        Datafilecols = sArray[int.Parse(itemfilecols.Attribute("colIndex").Value) - 1];

                                                                                                                        if (colnumValue.ContainsKey(int.Parse(itemfilecols.Attribute("cid").Value.ToString())))
                                                                                                                        {
                                                                                                                            Dictionary<int, string>.ValueCollection value = colnumValue.Values;

                                                                                                                            //string newValue = (int.Parse(colnumValue[int.Parse(itemfilecols.Attribute("cid").Value.ToString())]) + int.Parse(SGDealData(itemfilecols, Datafilecols, sArray))).ToString();

                                                                                                                            string newValue = (int.Parse(value.ElementAt(int.Parse(itemfilecols.Attribute("cid").Value.ToString()))) + int.Parse(SGDealData(itemfilecols, Datafilecols, sArray))).ToString();
                                                                                                                            colnumValue[int.Parse(itemfilecols.Attribute("cid").Value.ToString())] = newValue.Trim();

                                                                                                                            //string newValue = dr[int.Parse(itemfilecols.Attribute("cid").Value.ToString())].ToString() + Datafilecols;

                                                                                                                            dr[int.Parse(itemfilecols.Attribute("cid").Value.ToString())] = newValue.Trim();
                                                                                                                        }
                                                                                                                        else
                                                                                                                        {
                                                                                                                            colnumValue.Add(int.Parse(itemfilecols.Attribute("cid").Value.ToString()), SGDealData(itemfilecols, Datafilecols, sArray));
                                                                                                                            //dr[int.Parse(itemfilecols.Attribute("cid").Value.ToString())] = SGDealData(itemfilecols, Datafilecols, sArray);
                                                                                                                            if (!string.IsNullOrEmpty(itemfilecols.Attribute("express").Value.Trim().ToString()) && itemfilecols.Attribute("express").Value.Trim() == "-")
                                                                                                                            {
                                                                                                                                Datafilecols = "-" + Datafilecols.Trim();
                                                                                                                            }
                                                                                                                            dr[int.Parse(itemfilecols.Attribute("cid").Value.ToString())] = Datafilecols.Trim();
                                                                                                                        }
                                                                                                                    }
                                                                                                                    //sArray = SGDealData(itemfilecols, Datafilecols, sArray);
                                                                                                                    if (sArray[0] == "数据处理出错")
                                                                                                                    {
                                                                                                                        MergeFileIsSuccess = false;
                                                                                                                        MessageBox.Show(sArray[0], "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                                                                        return;
                                                                                                                    }

                                                                                                                }
                                                                                                            }

                                                                                                            // colnumValueFinal.Add(colnumValue);
                                                                                                            dtResult.Rows.Add(dr);
                                                                                                        }
                                                                                                        catch (Exception ex)
                                                                                                        {
                                                                                                            MergeFileIsSuccess = false;
                                                                                                            MessageBox.Show(itemfile.Attribute("filetitle") + ex.Message.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                                                            return;
                                                                                                        }
                                                                                                        try
                                                                                                        {
                                                                                                            // 横线输出的 将数据写入到文件中
                                                                                                            if (IsTransverse)  //横向输出的内容。要求横向输出的内容每个资金账号都单独输出
                                                                                                            {
                                                                                                                List<string> txtLineList = new List<string>();
                                                                                                                using (FileStream fsTargentFileTemp = new FileStream(targetFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                                                                                                                {

                                                                                                                    using (StreamReader srTargetFileTemp = new StreamReader(fsTargentFileTemp/*, Encoding.GetEncoding("GB2312")*/))
                                                                                                                    {
                                                                                                                        string lineTemp;

                                                                                                                        while ((lineTemp = srTargetFileTemp.ReadLine()) != null)
                                                                                                                        {
                                                                                                                            txtLineList.Add(lineTemp);
                                                                                                                            //foreach (XElement itemfilecols in itemfileSrc.Nodes())
                                                                                                                            //{
                                                                                                                            //    if (lineTemp.Contains(itemfilecols.Attribute("label").Value)/* && !Regex.IsMatch(lineTemp, @"\d+$")*/)
                                                                                                                            //    {
                                                                                                                            //        txtLineList.Add(lineTemp);
                                                                                                                            //    }
                                                                                                                            //}
                                                                                                                        }
                                                                                                                    }
                                                                                                                }
                                                                                                                //using (StreamWriter swTargetFileTemp = File.AppendText(targetFileName))
                                                                                                                //{
                                                                                                                //    for (int i = 0; i < dtResult.Rows.Count; i++)
                                                                                                                //    {
                                                                                                                //        string WrinteInValue = string.Empty;
                                                                                                                //        DataRow dr = dtResult.Rows[i];
                                                                                                                //        foreach (XElement itemfilecols in itemfileSrc.Nodes())
                                                                                                                //        {
                                                                                                                //            WrinteInValue = dr[int.Parse(itemfilecols.Attribute("cid").Value.ToString())].ToString();
                                                                                                                //            for (int j = 0; j < txtLineList.Count; j++)
                                                                                                                //            {
                                                                                                                //                if (txtLineList[j].Contains(itemfilecols.Attribute("label").Value) /*&& !Regex.IsMatch(txtLineList[j], @"\d+$")*/)
                                                                                                                //                {

                                                                                                                //                    WrinteInValue = dtResult.AsEnumerable().Select(d => Convert.ToDouble(d.Field<string>(dtResult.Columns[int.Parse(itemfilecols.Attribute("cid").Value)].ToString()))).Sum().ToString();

                                                                                                                //                    if (!string.IsNullOrEmpty(itemfilecols.Attribute("express").Value.Trim()) && itemfilecols.Attribute("express").Value == "-")
                                                                                                                //                    {
                                                                                                                //                        //dr[int.Parse(itemfilecols.Attribute("cid").Value.ToString())] = "-" + dr[int.Parse(itemfilecols.Attribute("cid").Value.ToString())];
                                                                                                                //                        ////string sd = Regex.Replace(txtLineList[j], @"[^\d.\d]", "");
                                                                                                                //                        //WrinteInValue = (decimal.Parse(Regex.Replace(txtLineList[j], @"[^\d.\d]", "")) - decimal.Parse(WrinteInValue.Trim())).ToString();
                                                                                                                //                        //txtLineList[j] = 
                                                                                                                //                    }
                                                                                                                //                    //WrinteInValue = dtResult.AsEnumerable().Select(d => Convert.ToDouble(d.Field<string>(dtResult.Columns[int.Parse(itemfilecols.Attribute("cid").Value)].ToString()))).

                                                                                                                //                    txtLineList[j] = txtLineList[j].Replace(txtLineList[j], txtLineList[j].Substring(0, (itemfilecols.Attribute("label").Value.Length)).PadRight(int.Parse(itemfilecols.Attribute("vlength").Value)) + WrinteInValue);
                                                                                                                //                    break;
                                                                                                                //                }
                                                                                                                //            }
                                                                                                                //        }
                                                                                                                //    }
                                                                                                                //    //fsTargentFileTemp.Seek(0, SeekOrigin.Begin);
                                                                                                                //    //fsTargentFileTemp.SetLength(0);
                                                                                                                //    // System.IO.File.WriteAllText(targetFileName, string.Empty);
                                                                                                                //    //swTargetFileTemp.Write("");
                                                                                                                //    for (int i = 0; i < txtLineList.Count; i++)
                                                                                                                //    {
                                                                                                                //        swTargetFileTemp.WriteLine(txtLineList[i]);
                                                                                                                //    }

                                                                                                                //}
                                                                                                                using (FileStream fsTargentFileTemp = new FileStream(targetFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                                                                                                                {
                                                                                                                    using (StreamWriter swTargetFileTemp = new StreamWriter(fsTargentFileTemp/*,Encoding.GetEncoding("GB2312")*/))
                                                                                                                    {
                                                                                                                        for (int i = 0; i < dtResult.Rows.Count; i++)
                                                                                                                        {
                                                                                                                            string WrinteInValue = string.Empty;
                                                                                                                            DataRow dr = dtResult.Rows[i];
                                                                                                                            foreach (XElement itemfilecols in itemfileSrc.Nodes())
                                                                                                                            {
                                                                                                                                WrinteInValue = dr[int.Parse(itemfilecols.Attribute("cid").Value.ToString())].ToString();
                                                                                                                                for (int j = txtLineList.Count - 1; j >= 0; j--)
                                                                                                                                {
                                                                                                                                    string txtEachLine = System.Text.RegularExpressions.Regex.Replace(txtLineList[j].Trim(), @"\d", "").Replace(".", "").Trim(); //去掉字符串中的数字
                                                                                                                                    if (txtEachLine.Equals(itemfilecols.Attribute("label").Value.Trim()) /*&& !Regex.IsMatch(txtLineList[j], @"\d+$")*/)
                                                                                                                                    {

                                                                                                                                        WrinteInValue = dtResult.AsEnumerable().Select(d => Convert.ToDouble(d.Field<string>(dtResult.Columns[int.Parse(itemfilecols.Attribute("cid").Value)].ToString()))).Sum().ToString();

                                                                                                                                        if (!string.IsNullOrEmpty(itemfilecols.Attribute("express").Value.Trim()) && itemfilecols.Attribute("express").Value == "-")
                                                                                                                                        {
                                                                                                                                            //dr[int.Parse(itemfilecols.Attribute("cid").Value.ToString())] = "-" + dr[int.Parse(itemfilecols.Attribute("cid").Value.ToString())];
                                                                                                                                            ////string sd = Regex.Replace(txtLineList[j], @"[^\d.\d]", "");
                                                                                                                                            //WrinteInValue = (decimal.Parse(Regex.Replace(txtLineList[j], @"[^\d.\d]", "")) - decimal.Parse(WrinteInValue.Trim())).ToString();
                                                                                                                                            //txtLineList[j] = 
                                                                                                                                        }
                                                                                                                                        //WrinteInValue = dtResult.AsEnumerable().Select(d => Convert.ToDouble(d.Field<string>(dtResult.Columns[int.Parse(itemfilecols.Attribute("cid").Value)].ToString()))).

                                                                                                                                        txtLineList[j] = txtLineList[j].Replace(txtLineList[j], txtLineList[j].Substring(0, (itemfilecols.Attribute("label").Value.Length)).PadRight(int.Parse(itemfilecols.Attribute("vlength").Value)) + WrinteInValue);
                                                                                                                                        break;
                                                                                                                                    }
                                                                                                                                }
                                                                                                                            }
                                                                                                                        }
                                                                                                                        fsTargentFileTemp.Seek(0, SeekOrigin.Begin);
                                                                                                                        fsTargentFileTemp.SetLength(0);
                                                                                                                        // System.IO.File.WriteAllText(targetFileName, string.Empty);
                                                                                                                        //swTargetFileTemp.Write("");
                                                                                                                        for (int i = 0; i < txtLineList.Count; i++)
                                                                                                                        {
                                                                                                                            swTargetFileTemp.WriteLine(txtLineList[i]);
                                                                                                                        }
                                                                                                                        if (!CapitalDBFAccountNo.Contains(itemMoreMotorCenterAccount))
                                                                                                                        {
                                                                                                                            CapitalDBFAccountNo.Add(itemMoreMotorCenterAccount);
                                                                                                                        }
                                                                                                                        //foreach (string item in txtLineList)
                                                                                                                        //{
                                                                                                                        //    swTargetFileTemp.WriteLine(item);
                                                                                                                        //}

                                                                                                                    }
                                                                                                                }

                                                                                                            }
                                                                                                        }
                                                                                                        catch (Exception ex)
                                                                                                        {
                                                                                                            MergeFileIsSuccess = false;
                                                                                                        }



                                                                                                        //using (StreamWriter swTargetFile = File.AppendText(targetFileName))
                                                                                                        //{

                                                                                                        //    for (int i = 0; i < dtResult.Rows.Count; i++)
                                                                                                        //    {
                                                                                                        //        DataRow dr = dtResult.Rows[i];

                                                                                                        //        using (FileStream fsTargentFile = new FileStream(targetFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                                                                                                        //        {
                                                                                                        //            using (StreamReader swTargetFilTemp = new StreamReader(fsTargentFile))
                                                                                                        //            {
                                                                                                        //                //string line = string.Empty;

                                                                                                        //                while ((line = swSourceFile.ReadLine()) != null)
                                                                                                        //                {
                                                                                                        //                }
                                                                                                        //            }
                                                                                                        //        }

                                                                                                        //    }
                                                                                                        //}
                                                                                                        //line = string.Join("@", sArray);
                                                                                                        //if (File.Exists(targetFileName))
                                                                                                        //{
                                                                                                        //    using (StreamWriter swTargetFile = File.AppendText(targetFileName))
                                                                                                        //    {
                                                                                                        //        swTargetFile.WriteLine(line);

                                                                                                        //    }
                                                                                                        //}
                                                                                                        //else
                                                                                                        //{
                                                                                                        //    using (FileStream fsTargetFile = new FileStream(targetFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                                                                                                        //    {
                                                                                                        //        using (StreamWriter swTargetFile = new StreamWriter(fsTargetFile))
                                                                                                        //        {
                                                                                                        //            swTargetFile.WriteLine(line);

                                                                                                        //        }
                                                                                                        //    }
                                                                                                        //}

                                                                                                    }

                                                                                                }

                                                                                            }
                                                                                        }

                                                                                    }
                                                                                    else if (itemfileSrc.Attribute("srcfileType").Value.Equals("交易所"))
                                                                                    {
                                                                                        if (itemfile.Attribute("filetitle").Value == "中国金融期货交易所 客户分项资金明细表")
                                                                                        {
                                                                                            DataTable dtResultTemp = dtResult.Copy(); //dtResultd的克隆表，作用是将dtResultd表中无法与dr表匹配的行移除掉，但由于foreach无法直接对dtResultd操作，因此声明了这个临时表
                                                                                                                                      //List<string> keywordList = new List<string>();
                                                                                            DataRow drTemp = dtResultTemp.NewRow();
                                                                                            for (int i = dtResult.Rows.Count - 1; i >= 0; i--)
                                                                                            {
                                                                                                var itemDrResul = dtResult.Rows[i];
                                                                                                bool IsDtDataMatch = false; //dt表是否有匹配dr表的数据标志，若能匹配则为true，否则为false
                                                                                                Dictionary<int, string> keywordList = new Dictionary<int, string>();
                                                                                                foreach (XElement itemfilecols in itemfileSrc.Nodes())
                                                                                                {
                                                                                                    foreach (XElement itemfilepkg in itemfile.Descendants("filepkg"))
                                                                                                    {
                                                                                                        if ((int.Parse(itemfilecols.Attribute("cid").Value) - 1) == (int.Parse(itemfilepkg.Attribute("pkgColIndex").Value)) && !string.IsNullOrEmpty(itemfilecols.Attribute("colIndex").Value))
                                                                                                        {
                                                                                                            keywordList.Add(int.Parse(itemfilecols.Attribute("colIndex").Value), itemDrResul[int.Parse(itemfilecols.Attribute("cid").Value) - 1].ToString());
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                                //string keyword1 = itemDrResul[2].ToString();
                                                                                                //string keyword2 = itemDrResul[3].ToString();
                                                                                                foreach (DataRow itemDr in dt.Rows)
                                                                                                {
                                                                                                    foreach (XElement itemfilecols in itemfileSrc.Nodes())
                                                                                                    {
                                                                                                        if (!string.IsNullOrEmpty(itemfilecols.Attribute("colIndex").Value.Trim()))
                                                                                                        {
                                                                                                            if (itemDr[keywordList.Keys.First() - 1].ToString() == keywordList[keywordList.Keys.First()])
                                                                                                            {
                                                                                                                IsDtDataMatch = true;
                                                                                                                itemDrResul[int.Parse(itemfilecols.Attribute("cid").Value)] = itemDr[int.Parse(itemfilecols.Attribute("colIndex").Value.Trim())].ToString();

                                                                                                            }
                                                                                                        }
                                                                                                    }
                                                                                                    //if (itemDr[2].ToString() == keyword1 && itemDr[3].ToString() == keyword2)  //colIndex的值
                                                                                                    //{
                                                                                                    //    itemDrResul[16] = itemDr[16].ToString();
                                                                                                    //}
                                                                                                }
                                                                                                if (!IsDtDataMatch)
                                                                                                {
                                                                                                    dtResult.Rows.RemoveAt(i);
                                                                                                }
                                                                                            }


                                                                                            //foreach (DataRow itemDrResul in dtResult.Rows)
                                                                                            //{
                                                                                            //    //dtResult.Rows.Remove(itemDrResul);
                                                                                            //    bool IsDtDataMatch = false; //dt表是否有匹配dr表的数据标志，若能匹配则为true，否则为false
                                                                                            //    Dictionary<int, string> keywordList = new Dictionary<int, string>();
                                                                                            //    foreach (XElement itemfilecols in itemfileSrc.Nodes())
                                                                                            //    {
                                                                                            //        foreach (XElement itemfilepkg in itemfile.Descendants("filepkg"))
                                                                                            //        {
                                                                                            //            if ( (int.Parse( itemfilecols.Attribute("cid").Value) - 1) == (int.Parse( itemfilepkg.Attribute("pkgColIndex").Value))  && !string.IsNullOrEmpty(itemfilecols.Attribute("colIndex").Value))
                                                                                            //            {
                                                                                            //                keywordList.Add(int.Parse(itemfilecols.Attribute("colIndex").Value), itemDrResul[int.Parse(itemfilecols.Attribute("cid").Value) - 1].ToString());
                                                                                            //            }
                                                                                            //        }
                                                                                            //    }
                                                                                            //    //string keyword1 = itemDrResul[2].ToString();
                                                                                            //    //string keyword2 = itemDrResul[3].ToString();
                                                                                            //    foreach (DataRow itemDr in dt.Rows)
                                                                                            //    {
                                                                                            //        foreach (XElement itemfilecols in itemfileSrc.Nodes())
                                                                                            //        {
                                                                                            //            if (!string.IsNullOrEmpty(itemfilecols.Attribute("colIndex").Value.Trim()))
                                                                                            //            {
                                                                                            //                if (itemDr[keywordList.Keys.First() - 1].ToString() == keywordList[keywordList.Keys.First()])
                                                                                            //                {
                                                                                            //                    IsDtDataMatch = true;
                                                                                            //                    itemDrResul[int.Parse(itemfilecols.Attribute("cid").Value)] = itemDr[int.Parse(itemfilecols.Attribute("colIndex").Value.Trim())].ToString();

                                                                                            //                }
                                                                                            //            }
                                                                                            //        }
                                                                                            //        //if (itemDr[2].ToString() == keyword1 && itemDr[3].ToString() == keyword2)  //colIndex的值
                                                                                            //        //{
                                                                                            //        //    itemDrResul[16] = itemDr[16].ToString();
                                                                                            //        //}
                                                                                            //    }
                                                                                            //    if (!IsDtDataMatch)
                                                                                            //    {
                                                                                            //        dtResult.Rows.Remove(itemDrResul);
                                                                                            //    }

                                                                                            //}
                                                                                            //dtResult = dtResultTemp;
                                                                                            //foreach (XElement itemfilecols in itemfileSrc.Nodes())
                                                                                            //{
                                                                                            //    if (itemfilecols.Attribute("colIndex").Value.Trim())
                                                                                            //}
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            //List<string> keywordList = new List<string>();
                                                                                            foreach (DataRow itemDrResul in dtResult.Rows)
                                                                                            {
                                                                                                Dictionary<int, string> keywordList = new Dictionary<int, string>();
                                                                                                foreach (XElement itemfilecols in itemfileSrc.Nodes())
                                                                                                {
                                                                                                    foreach (XElement itemfilepkg in itemfile.Descendants("filepkg"))
                                                                                                    {
                                                                                                        if (itemfilecols.Attribute("cid").Value == itemfilepkg.Attribute("pkgColIndex").Value && !string.IsNullOrEmpty(itemfilecols.Attribute("colIndex").Value))
                                                                                                        {
                                                                                                            keywordList.Add(int.Parse(itemfilecols.Attribute("colIndex").Value), itemDrResul[int.Parse(itemfilecols.Attribute("cid").Value)].ToString());
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                                //string keyword1 = itemDrResul[2].ToString();
                                                                                                //string keyword2 = itemDrResul[3].ToString();
                                                                                                foreach (DataRow itemDr in dt.Rows)
                                                                                                {

                                                                                                    foreach (XElement itemfilecols in itemfileSrc.Nodes())
                                                                                                    {
                                                                                                        if (!string.IsNullOrEmpty(itemfilecols.Attribute("colIndex").Value.Trim()))
                                                                                                        {
                                                                                                            if (itemDr[keywordList.Keys.First() - 1].ToString() == keywordList[keywordList.Keys.First()])
                                                                                                            {
                                                                                                                itemDrResul[int.Parse(itemfilecols.Attribute("cid").Value)] = itemDr[int.Parse(itemfilecols.Attribute("colIndex").Value.Trim()) - 1].ToString();
                                                                                                            }
                                                                                                        }
                                                                                                    }
                                                                                                    //if (itemDr[2].ToString() == keyword1 && itemDr[3].ToString() == keyword2)  //colIndex的值
                                                                                                    //{
                                                                                                    //    itemDrResul[16] = itemDr[16].ToString();
                                                                                                    //}
                                                                                                }
                                                                                            }
                                                                                            //foreach (XElement itemfilecols in itemfileSrc.Nodes())
                                                                                            //{
                                                                                            //    if (itemfilecols.Attribute("colIndex").Value.Trim())
                                                                                            //}
                                                                                        }

                                                                                    }
                                                                                }
                                                                                if (File.Exists(targetFileName))
                                                                                {
                                                                                    using (StreamWriter swTargetFile = File.AppendText(targetFileName))
                                                                                    {
                                                                                        if (IsTransverse)  //横向输出列
                                                                                        {
                                                                                            //try
                                                                                            //{
                                                                                            //    for (int i = 0; i < dtResult.Rows.Count; i++)
                                                                                            //    {
                                                                                            //        DataRow dr = dtResult.Rows[i];
                                                                                            //        List<string> RowValueList = new List<string>();

                                                                                            //        foreach (XElement itemfileSrc in itemfile.Descendants("fileSrc"))
                                                                                            //        {
                                                                                            //            foreach (XElement itemfilecols in itemfileSrc.Nodes())
                                                                                            //            {
                                                                                            //                string line = string.Empty;
                                                                                            //                if (!string.IsNullOrEmpty(itemfilecols.Attribute("isout").Value.Trim()))   //是否输出
                                                                                            //                {
                                                                                            //                    if (itemfilecols.Attribute("isout").Value.Trim() == "否")
                                                                                            //                    {
                                                                                            //                        line = "";
                                                                                            //                    }
                                                                                            //                    else
                                                                                            //                    {
                                                                                            //                        if (!string.IsNullOrEmpty(itemfilecols.Attribute("tlength").Value) && (int.Parse(itemfilecols.Attribute("tlength").Value.Trim()) > 0)) //列名位数 +对齐方式
                                                                                            //                        {
                                                                                            //                            string align = itemfilecols.Attribute("align").Value;

                                                                                            //                            if (!string.IsNullOrEmpty(align) && align.Equals("左"))
                                                                                            //                            {
                                                                                            //                                line = dtResult.Columns[int.Parse(itemfilecols.Attribute("cid").Value.Trim())].ToString().Trim().PadRight(int.Parse(itemfilecols.Attribute("tlength").Value.Trim()), ' ');//以空格填充
                                                                                            //                            }
                                                                                            //                            if (!string.IsNullOrEmpty(align) && align.Equals("右"))
                                                                                            //                            {
                                                                                            //                                line = dtResult.Columns[int.Parse(itemfilecols.Attribute("cid").Value.Trim())].ToString().Trim().PadLeft(int.Parse(itemfilecols.Attribute("tlength").Value.Trim()), ' ');//以空格填充
                                                                                            //                            }

                                                                                            //                        }
                                                                                            //                    }
                                                                                            //                    //sArray[int.Parse(itemfilecols.Attribute("colIndex").Value) - 1] = Datafilecols;
                                                                                            //                }
                                                                                            //                //line = dtResult.Columns[int.Parse(itemfilecols.Attribute("cid").Value)].ToString()

                                                                                            //                line += SGDealDataRowValue(itemfilecols, dr[int.Parse(itemfilecols.Attribute("cid").Value)].ToString(), dr);

                                                                                            //                swTargetFile.WriteLine(line);

                                                                                            //                //RowValueList.Add(SGDealDataRowValue(itemfilecols, dr[int.Parse(itemfilecols.Attribute("cid").Value)].ToString(), dr));
                                                                                            //            }
                                                                                            //            break;
                                                                                            //        }
                                                                                            //        //line = string.Join(string.Empty, RowValueList.ToArray());


                                                                                            //    }
                                                                                            //}
                                                                                            //catch (Exception ex)
                                                                                            //{

                                                                                            //}
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            if (itemfile.Attribute("filetitle").Value == "中国金融期货交易所 客户分项资金明细表")
                                                                                            {
                                                                                                if (colnumName.Count != 0 && !FileHaveColumnNameList.Contains(itemfile.Attribute("filetitle").Value))
                                                                                                {
                                                                                                    string LineColNameIonfo = string.Join(string.Empty, colnumName.ToArray());
                                                                                                    swTargetFile.WriteLine("\n" + LineColNameIonfo);
                                                                                                    FileHaveColumnNameList.Add(itemfile.Attribute("filetitle").Value);
                                                                                                }
                                                                                                try
                                                                                                {
                                                                                                    for (int i = 0; i < dtResult.Rows.Count; i++)
                                                                                                    {
                                                                                                        DataRow dr = dtResult.Rows[i];
                                                                                                        List<string> RowValueList = new List<string>();
                                                                                                        foreach (XElement itemfileSrc in itemfile.Descendants("fileSrc"))
                                                                                                        {
                                                                                                            foreach (XElement itemfilecols in itemfileSrc.Nodes())
                                                                                                            {
                                                                                                                RowValueList.Add(SGDealDataRowValueClientCapitalDetail(itemfilecols, dr[int.Parse(itemfilecols.Attribute("cid").Value) - 1].ToString(), dr));
                                                                                                            }
                                                                                                            break;
                                                                                                        }
                                                                                                        string line = string.Join(string.Empty, RowValueList.ToArray());

                                                                                                        swTargetFile.WriteLine(line);
                                                                                                        IsExistCffex = true;
                                                                                                    }
                                                                                                    IsExistCffex = true;

                                                                                                }
                                                                                                catch (Exception ex)
                                                                                                {
                                                                                                    MergeFileIsSuccess = false;
                                                                                                    MessageBox.Show(itemfile.Attribute("filetitle") + ex.Message.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                                                    return;
                                                                                                }
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                // string LineValueIonfo = string.Join(string.Empty, colnumValueFinal.ToArray());
                                                                                                if (colnumName.Count != 0 && !FileHaveColumnNameList.Contains(itemfile.Attribute("filetitle").Value))
                                                                                                {
                                                                                                    string LineColNameIonfo = string.Join(string.Empty, colnumName.ToArray());
                                                                                                    swTargetFile.WriteLine("\n" + LineColNameIonfo);
                                                                                                    FileHaveColumnNameList.Add(itemfile.Attribute("filetitle").Value);
                                                                                                }

                                                                                                // swTargetFile.WriteLine(LineValueIonfo);
                                                                                                //string columns = "", content = "", columnName = "";
                                                                                                try
                                                                                                {
                                                                                                    for (int i = 0; i < dtResult.Rows.Count; i++)
                                                                                                    {
                                                                                                        DataRow dr = dtResult.Rows[i];
                                                                                                        List<string> RowValueList = new List<string>();
                                                                                                        foreach (XElement itemfileSrc in itemfile.Descendants("fileSrc"))
                                                                                                        {
                                                                                                            foreach (XElement itemfilecols in itemfileSrc.Nodes())
                                                                                                            {
                                                                                                                RowValueList.Add(SGDealDataRowValue(itemfilecols, dr[int.Parse(itemfilecols.Attribute("cid").Value)].ToString(), dr));
                                                                                                            }
                                                                                                            break;
                                                                                                        }
                                                                                                        string line = string.Join(string.Empty, RowValueList.ToArray());

                                                                                                        swTargetFile.WriteLine(line);
                                                                                                        IsExistCffex = true;
                                                                                                    }
                                                                                                    //for (int i = 0; i < dtResult.Columns.Count; i++)
                                                                                                    //{
                                                                                                    //    //columns = dtResult.Columns[i].ColumnName.ToString();
                                                                                                    //    foreach (var item in collection)
                                                                                                    //    {

                                                                                                    //    }
                                                                                                    //    for (int j = 0; j < dtResult.Columns.Count; j++)
                                                                                                    //    {
                                                                                                    //        content += dtResult.Rows[i][j].ToString().Trim();
                                                                                                    //    }
                                                                                                    //    swTargetFile.WriteLine(content);
                                                                                                    //}
                                                                                                    IsExistCffex = true;


                                                                                                }
                                                                                                catch (Exception ex)
                                                                                                {
                                                                                                    MergeFileIsSuccess = false;
                                                                                                    MessageBox.Show(itemfile.Attribute("filetitle") + ex.Message.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                                                    return;
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }

                                                                                    //TFileReader.SaveDataTableToTXT(dispatchFile, dtResult, targetFileName, true);

                                                                                    //生成dbf文档 ,dbf文档不用做特殊处理，因为我的设计思路是从已经生成号的txt文件中生成dbf
                                                                                    //生成dbf文档  ，纵向输出，
                                                                                    if (itemfile.Attribute("arrangeType").Value == "纵向")
                                                                                    {
                                                                                        string testPath = AppDomain.CurrentDomain.BaseDirectory;
                                                                                        var odbf = new DbfFile(Encoding.GetEncoding(936));
                                                                                        // odbf.Open(Path.Combine(targetDirectoryName, "test.dbf"), FileMode.Create); 
                                                                                        odbf.Open(targetDBFFileName, FileMode.Create);

                                                                                        //创建列头
                                                                                        foreach (string item in DBFColumnNamelist)
                                                                                        {
                                                                                            odbf.Header.AddColumn(new DbfColumn(item, DbfColumn.DbfColumnType.Character, 20, 0));
                                                                                        }

                                                                                        List<string> txtFileCount = File.ReadAllLines(targetFileName).ToList();

                                                                                        if (txtFileCount.Count > 5)
                                                                                        {
                                                                                            for (int i = 5; i < txtFileCount.Count; i++)
                                                                                            {

                                                                                                string line = txtFileCount[i].Trim();
                                                                                                if (!string.IsNullOrEmpty(line))
                                                                                                {
                                                                                                    string lineTemp = new Regex("[\\s]+").Replace(line, "@");
                                                                                                    string[] sArray = lineTemp.Split('@');
                                                                                                    var orec = new DbfRecord(odbf.Header) { AllowDecimalTruncate = true };
                                                                                                    for (int j = 0; j < sArray.Length; j++)
                                                                                                    {
                                                                                                        orec[j] = sArray[j];

                                                                                                    }
                                                                                                    odbf.Write(orec, true);
                                                                                                }
                                                                                            }
                                                                                        }

                                                                                        odbf.Close();
                                                                                    }
                                                                                    else  //横向输出的 现在只有【会员资金情况表】
                                                                                    {
                                                                                        if (itemfile.Attribute("fileext").Value == "DBF" && itemfile.Attribute("filetitle").Value == "会员资金情况表")
                                                                                        {
                                                                                            string testPath = AppDomain.CurrentDomain.BaseDirectory;
                                                                                            var odbf = new DbfFile(Encoding.GetEncoding(936));
                                                                                            // odbf.Open(Path.Combine(targetDirectoryName, "test.dbf"), FileMode.Create); 
                                                                                            odbf.Open(targetDBFFileName, FileMode.Create);

                                                                                            //创建列头
                                                                                            //foreach (XElement itemfileSrc in itemfile.Descendants("fileSrc"))
                                                                                            //{
                                                                                            //    if (string.IsNullOrEmpty( itemfileSrc.Attribute("srcfile").Value))
                                                                                            //    {

                                                                                            //    }
                                                                                            //}
                                                                                            odbf.Header.AddColumn(new DbfColumn("accountID", DbfColumn.DbfColumnType.Character, 20, 0));
                                                                                            odbf.Header.AddColumn(new DbfColumn("itemDesc", DbfColumn.DbfColumnType.Character, 20, 0));
                                                                                            odbf.Header.AddColumn(new DbfColumn("itemValue", DbfColumn.DbfColumnType.Character, 20, 0));

                                                                                            //foreach (string item in DBFColumnNamelist)
                                                                                            //{
                                                                                            //    odbf.Header.AddColumn(new DbfColumn(item, DbfColumn.DbfColumnType.Character, 20, 0));
                                                                                            //}

                                                                                            List<string> txtFileCount = File.ReadAllLines(targetFileName).ToList();
                                                                                            string FundAccountNo = string.Empty;
                                                                                            int number = 0;
                                                                                            if (txtFileCount.Count > 4)
                                                                                            {
                                                                                                for (int i = 3; i < txtFileCount.Count; i++) //从3开始是为了把这一行作为标志
                                                                                                {
                                                                                                    string line = txtFileCount[i].Trim();

                                                                                                    if (line.Contains("accountID"))
                                                                                                    {
                                                                                                        number++;
                                                                                                        FundAccountNo = CapitalDBFAccountNo[number - 1];
                                                                                                    }

                                                                                                    if (!string.IsNullOrEmpty(line) && Regex.IsMatch(line, @"\d+$"))
                                                                                                    {
                                                                                                        string lineTemp = new Regex("[\\s]+").Replace(line, "@");
                                                                                                        string[] sArray = lineTemp.Split('@');
                                                                                                        var orec = new DbfRecord(odbf.Header) { AllowDecimalTruncate = true };
                                                                                                        //string dsg = Path.GetFileNameWithoutExtension(targetFileName).Split('_')[0];
                                                                                                        //orec[0] = Path.GetFileNameWithoutExtension(targetFileName).Split('_')[0];
                                                                                                        orec[0] = FundAccountNo;
                                                                                                        for (int j = 0; j < sArray.Length; j++)
                                                                                                        {
                                                                                                            orec[j + 1] = sArray[j];

                                                                                                        }
                                                                                                        odbf.Write(orec, true);
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                            odbf.Close();
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }

                                                        #endregion
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        MergeFileIsSuccess = false;
                                                        MessageBox.Show(ex.Message, "失败", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                        return;
                                                    }

                                                    bool MotorCenterGeneFileResult = false;
                                                    bool CZCEGeneFileResult = false;
                                                    bool DCEGeneFileResult = false;
                                                    bool CffexGeneFileResult = false;

                                                    #region 生成监控中心文件
                                                    //生成监控中心
                                                    bool IsExistMotorCenter = false; //设置此标志的目的是因为可能此文件夹地下残留上次生成的老文件
                                                    foreach (string itemSingleMotorCenterAccount in MergeMotorCenterAccount)
                                                    {
                                                        foreach (XElement itemAccountId in configDocument.Descendants("AccountId"))
                                                        {
                                                            if (itemAccountId.Attribute("value").Value == itemSingleMotorCenterAccount)
                                                            {
                                                                if (itemAccountId.Attribute("cfmmcFile").Equals("0")) //不生成监控中心文件
                                                                {
                                                                    return;
                                                                }
                                                                foreach (XElement itemOrganCode in itemAccountId.Descendants("OrganCode"))
                                                                {

                                                                    if (itemOrganCode.Attribute("name").Value == "监控中心")
                                                                    {
                                                                        foreach (XElement itemfile in itemOrganCode.Nodes())
                                                                        {
                                                                            foreach (XElement itemfileSrc in itemfile.Nodes())
                                                                            {
                                                                                SourceFileName = Path.Combine(OriginPath.ToString() + "\\" + kryDTPDate.Value.ToString("yyyyMMdd") + string.Format("\\{0}{1}{2}.txt", GlobalData.SeatNo, itemfileSrc.Attribute("srcfile").Value, kryDTPDate.Value.ToString("yyyyMMdd")));


                                                                                //if (itemAccountId.Attribute("outType").Value.Equals("1"))  //按日期导出
                                                                                //{
                                                                                targetFileName = Path.Combine(MonitorCenterOutPath1.ToString() + "\\" + string.Format(@"{0}\监控中心格式\TXT文件\{1}\{2}{3}{4}.txt", kryDTPDate.Value.ToString("yyyyMMdd"), GlobalData.SeatNo, GlobalData.SeatNo, itemfileSrc.Attribute("srcfile").Value.ToString().ToUpper(), kryDTPDate.Value.ToString("yyyyMMdd")));
                                                                                targetDirectoryName = Path.Combine(MonitorCenterOutPath1.ToString() + "\\" + string.Format(@"{0}\监控中心格式\TXT文件\{1}", kryDTPDate.Value.ToString("yyyyMMdd"), GlobalData.SeatNo));
                                                                                targetDirectoryName1 = Path.Combine(MonitorCenterOutPath2.ToString() + "\\" + string.Format(@"{0}\监控中心格式\TXT文件\{1}", kryDTPDate.Value.ToString("yyyyMMdd"), GlobalData.SeatNo));
                                                                                //}
                                                                                //else   //按账号导出
                                                                                //{
                                                                                //    targetFileName = Path.Combine(MonitorCenterOutPath1.ToString() + "\\" + string.Format(@"{0}\监控中心格式\TXT文件\{1}\{2}{3}{4}.txt", itemSingleMotorCenterAccount, kryDTPDate.Value.ToString("yyyyMMdd"), itemSingleMotorCenterAccount, itemfileSrc.Attribute("srcfile").Value.ToString().ToUpper(), kryDTPDate.Value.ToString("yyyyMMdd")));
                                                                                //    targetDirectoryName = Path.Combine(MonitorCenterOutPath1.ToString() + "\\" + string.Format(@"{0}\监控中心格式\TXT文件\{1}", itemSingleMotorCenterAccount, kryDTPDate.Value.ToString("yyyyMMdd")));
                                                                                //    targetDirectoryName1 = Path.Combine(MonitorCenterOutPath2.ToString() + "\\" + string.Format(@"{0}\监控中心格式\TXT文件\{1}", itemSingleMotorCenterAccount, kryDTPDate.Value.ToString("yyyyMMdd")));
                                                                                //}
                                                                                if (!Directory.Exists(targetDirectoryName))
                                                                                {
                                                                                    Directory.CreateDirectory(targetDirectoryName);
                                                                                }
                                                                                else
                                                                                {
                                                                                    if (!IsExistMotorCenter)
                                                                                    {
                                                                                        //为了删除掉此目录下遗留下来的上次文件
                                                                                        DirectoryInfo targetDirectoryInfo = new DirectoryInfo(targetDirectoryName);
                                                                                        targetDirectoryInfo.Delete(true);

                                                                                        Directory.CreateDirectory(targetDirectoryName);
                                                                                    }
                                                                                }
                                                                                //if (Directory.Exists(targetDirectoryName) && !IsExistMotorCenter)
                                                                                //{
                                                                                //    //为了删除掉此目录下遗留下来的上次文件
                                                                                //    DirectoryInfo targetDirectoryInfo = new DirectoryInfo(targetDirectoryName);
                                                                                //    targetDirectoryInfo.Delete(true);

                                                                                //    Directory.CreateDirectory(targetDirectoryName);
                                                                                //}

                                                                                //if (!Directory.Exists(targetDirectoryName) && !IsExistMotorCenter)
                                                                                //{
                                                                                //    Directory.CreateDirectory(targetDirectoryName);
                                                                                //}
                                                                                if (File.Exists(targetFileName) && !IsExistMotorCenter)
                                                                                {
                                                                                    File.Delete(targetFileName);

                                                                                }
                                                                                if (!File.Exists(SourceFileName))
                                                                                {
                                                                                    MessageBox.Show(string.Format("{0}文件不存在", itemfile.Attribute("filetitle").Value), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                                    continue;
                                                                                }
                                                                                if (itemfile.Attribute("IsOutPut").Value == "否")
                                                                                {
                                                                                    continue;
                                                                                }
                                                                                using (FileStream fsSourceFile = new FileStream(SourceFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                                                                                {
                                                                                    using (StreamReader swSourceFile = new StreamReader(fsSourceFile))
                                                                                    {
                                                                                        string line = string.Empty;
                                                                                        while ((line = swSourceFile.ReadLine()) != null)
                                                                                        {
                                                                                            string[] sArray = line.Split('@');
                                                                                            if (sArray[0] == kryDTPDate.Value.ToString("yyyy-MM-dd") && sArray[1] == itemSingleMotorCenterAccount)
                                                                                            {

                                                                                                try
                                                                                                {
                                                                                                    foreach (XElement itemfilecols in itemfileSrc.Nodes())
                                                                                                    {
                                                                                                        string Datafilecols = sArray[int.Parse(itemfilecols.Attribute("cid").Value) - 1];

                                                                                                        sArray = MonitorCenterDealData(itemfilecols, Datafilecols, sArray);
                                                                                                        if (sArray[0] == "数据处理出错")
                                                                                                        {
                                                                                                            MergeFileIsSuccess = false;
                                                                                                            MessageBox.Show(itemfile.Attribute("filetitle").Value + sArray[0], "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                                                            return;
                                                                                                        }
                                                                                                        #region

                                                                                                        #endregion
                                                                                                    }
                                                                                                }
                                                                                                catch (Exception ex)
                                                                                                {
                                                                                                    MergeFileIsSuccess = false;
                                                                                                    MessageBox.Show(itemfile.Attribute("filetitle") + ex.Message.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                                                    return;
                                                                                                }

                                                                                                line = string.Join("@", sArray);
                                                                                                if (File.Exists(targetFileName))
                                                                                                {
                                                                                                    using (StreamWriter swTargetFile = File.AppendText(targetFileName))
                                                                                                    {
                                                                                                        swTargetFile.WriteLine(line);
                                                                                                        IsExistMotorCenter = true;
                                                                                                    }
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    using (FileStream fsTargetFile = new FileStream(targetFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                                                                                                    {
                                                                                                        using (StreamWriter swTargetFile = new StreamWriter(fsTargetFile))
                                                                                                        {
                                                                                                            swTargetFile.WriteLine(line);
                                                                                                            IsExistMotorCenter = true;
                                                                                                        }
                                                                                                    }
                                                                                                }

                                                                                            }

                                                                                        }
                                                                                        if (!File.Exists(targetFileName))
                                                                                        {

                                                                                            using (File.Create(targetFileName))
                                                                                            {
                                                                                                IsExistMotorCenter = true;
                                                                                            }

                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }

                                                                        if (!Directory.Exists(targetDirectoryName1))
                                                                        {
                                                                            Directory.CreateDirectory(targetDirectoryName1);
                                                                        }
                                                                        foreach (string file in Directory.GetFiles(targetDirectoryName))
                                                                        {
                                                                            string name = System.IO.Path.GetFileName(file);
                                                                            string dest = System.IO.Path.Combine(targetDirectoryName1, name);
                                                                            if (File.Exists(dest))
                                                                            {
                                                                                File.Delete(dest);
                                                                            }
                                                                            System.IO.File.Copy(file, dest);//复制文件
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                    #endregion

                                                    //生成证商所文件
                                                    bool IsExistZZ = false;
                                                    foreach (string itemSingleMotorCenterAccount in MergeMotorCenterAccount)
                                                    {
                                                        foreach (XElement itemAccountId in configDocument.Descendants("AccountId"))
                                                        {
                                                            if (itemAccountId.Attribute("value").Value == itemSingleMotorCenterAccount)
                                                            {
                                                                foreach (XElement itemOrganCode in itemAccountId.Descendants("OrganCode"))
                                                                {
                                                                    if (itemOrganCode.Attribute("name").Value == "郑商所")
                                                                    {
                                                                        foreach (XElement itemfile in itemOrganCode.Nodes())
                                                                        {
                                                                            foreach (XElement itemfileSrc in itemfile.Nodes())
                                                                            {
                                                                                SourceFileName = Path.Combine(OriginPath.ToString() + "\\" + kryDTPDate.Value.ToString("yyyyMMdd") + string.Format("\\{0}组合持仓表.txt", kryDTPDate.Value.ToString("yyyyMMdd")));

                                                                                //按账号导出的目录
                                                                                string txtFileName = (itemfile.Attribute("filename").Value.ToString().Replace("{accountid}", GlobalData.SeatNo)).Replace("{tradingday}", kryDTPDate.Value.ToString("yyyyMMdd"));

                                                                                targetFileName = Path.Combine(MonitorCenterOutPath1.ToString() + "\\" + string.Format(@"{0}\郑商所格式\TXT文件\{1}\{2}.txt", kryDTPDate.Value.ToString("yyyyMMdd"), GlobalData.SeatNo, txtFileName));
                                                                                targetDirectoryName = Path.Combine(MonitorCenterOutPath1.ToString() + "\\" + string.Format(@"{0}\郑商所格式\TXT文件\{1}", kryDTPDate.Value.ToString("yyyyMMdd"), GlobalData.SeatNo));
                                                                                targetDirectoryName1 = Path.Combine(MonitorCenterOutPath2.ToString() + "\\" + string.Format(@"{0}\郑商所格式\TXT文件\{1}", kryDTPDate.Value.ToString("yyyyMMdd"), GlobalData.SeatNo));

                                                                                if (!Directory.Exists(targetDirectoryName))
                                                                                {
                                                                                    Directory.CreateDirectory(targetDirectoryName);
                                                                                }
                                                                                else
                                                                                {
                                                                                    if (!IsExistZZ)
                                                                                    {
                                                                                        //为了删除掉此目录下遗留下来的上次文件
                                                                                        DirectoryInfo targetDirectoryInfo = new DirectoryInfo(targetDirectoryName);
                                                                                        targetDirectoryInfo.Delete(true);

                                                                                        Directory.CreateDirectory(targetDirectoryName);
                                                                                    }
                                                                                }
                                                                                //if (Directory.Exists(targetDirectoryName)  && !IsExistZZ)
                                                                                //{
                                                                                //    DirectoryInfo targetDirectoryInfo = new DirectoryInfo(targetDirectoryName);
                                                                                //    targetDirectoryInfo.Delete(true);
                                                                                //    Directory.CreateDirectory(targetDirectoryName);
                                                                                //}
                                                                                if (File.Exists(targetFileName) && !IsExistZZ)
                                                                                {
                                                                                    File.Delete(targetFileName);
                                                                                }
                                                                                if (!File.Exists(SourceFileName))
                                                                                {
                                                                                    MessageBox.Show("{郑商所组合持仓表不存在", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                                    continue;
                                                                                }
                                                                                using (FileStream fsSourceFile = new FileStream(SourceFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                                                                                {
                                                                                    using (StreamReader swSourceFile = new StreamReader(fsSourceFile, Encoding.GetEncoding("GB2312")))
                                                                                    {
                                                                                        // string txtInfo = swSourceFile.ReadToEnd();
                                                                                        string line = string.Empty;
                                                                                        int count = 0;
                                                                                        bool IsWriteNextLine = false;

                                                                                        while ((line = swSourceFile.ReadLine()) != null)
                                                                                        {
                                                                                            //foreach (XElement itemfilecols in itemfileSrc.Nodes())
                                                                                            //{
                                                                                            if (count > 0)
                                                                                            {
                                                                                                try
                                                                                                {
                                                                                                    using (StreamWriter swTargetFileAppend = new StreamWriter(targetFileName, true, Encoding.GetEncoding("GB2312")))
                                                                                                    {
                                                                                                        if (count > 5)
                                                                                                        {
                                                                                                            if (IsWriteNextLine)
                                                                                                            {
                                                                                                                List<string> colNameList = ColValueSplitLineCZCE(line);
                                                                                                                foreach (XElement itemfilecols in itemfileSrc.Nodes())
                                                                                                                {
                                                                                                                    string Datafilecols = colNameList[int.Parse(itemfilecols.Attribute("cid").Value.Trim()) - 1];

                                                                                                                    colNameList = CZCEDealData(itemfilecols, Datafilecols, colNameList);

                                                                                                                }
                                                                                                                line = string.Join(string.Empty, colNameList.ToArray());

                                                                                                                swTargetFileAppend.WriteLine(line);
                                                                                                                IsWriteNextLine = false;
                                                                                                                count = count + 1;
                                                                                                                IsExistZZ = true;
                                                                                                                continue;
                                                                                                            }
                                                                                                            if (line.Substring(0, 8).Equals(itemSingleMotorCenterAccount))   //  "34339297"    itemSingleMotorCenterAccount
                                                                                                            {
                                                                                                                List<string> colNameList = ColValueSplitLineCZCE(line);
                                                                                                                foreach (XElement itemfilecols in itemfileSrc.Nodes())
                                                                                                                {
                                                                                                                    string Datafilecols = colNameList[int.Parse(itemfilecols.Attribute("cid").Value.Trim()) - 1];

                                                                                                                    colNameList = CZCEDealData(itemfilecols, Datafilecols, colNameList);

                                                                                                                }
                                                                                                                line = string.Join(string.Empty, colNameList.ToArray());

                                                                                                                swTargetFileAppend.WriteLine(line);
                                                                                                                IsWriteNextLine = true;
                                                                                                                IsExistZZ = true;
                                                                                                            }
                                                                                                        }
                                                                                                        else
                                                                                                        {
                                                                                                            if (count == 4)
                                                                                                            {
                                                                                                                List<string> colNameList = ColNameSplitLineCZCE(line);

                                                                                                                foreach (XElement itemfilecols in itemfileSrc.Nodes())
                                                                                                                {
                                                                                                                    if (true)
                                                                                                                    {
                                                                                                                        if (!string.IsNullOrEmpty(itemfilecols.Attribute("tlength").Value) && (int.Parse(itemfilecols.Attribute("tlength").Value.Trim()) > 0)) //列名位数 +对齐方式
                                                                                                                        {
                                                                                                                            string align = itemfilecols.Attribute("align").Value;

                                                                                                                            if (!string.IsNullOrEmpty(align) && align.Equals("左"))
                                                                                                                            {
                                                                                                                                colNameList[int.Parse(itemfilecols.Attribute("cid").Value.Trim()) - 1] = colNameList[int.Parse(itemfilecols.Attribute("cid").Value.Trim()) - 1].Trim().PadRight(int.Parse(itemfilecols.Attribute("tlength").Value.Trim()), ' ');//以空格填充
                                                                                                                            }
                                                                                                                            if (!string.IsNullOrEmpty(align) && align.Equals("右"))
                                                                                                                            {
                                                                                                                                colNameList[int.Parse(itemfilecols.Attribute("cid").Value.Trim()) - 1] = colNameList[int.Parse(itemfilecols.Attribute("cid").Value.Trim()) - 1].Trim().PadLeft(int.Parse(itemfilecols.Attribute("tlength").Value.Trim()), ' ');//以空格填充
                                                                                                                            }
                                                                                                                            //colNameList[int.Parse(itemfilecols.Attribute("cid").Value.Trim())] = 
                                                                                                                        }
                                                                                                                    }
                                                                                                                }

                                                                                                                line = string.Join(string.Empty, colNameList.ToArray());
                                                                                                            }
                                                                                                            swTargetFileAppend.WriteLine(line);
                                                                                                            count = count + 1;
                                                                                                            IsExistZZ = true;
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                                catch (Exception ex)
                                                                                                {
                                                                                                    MergeFileIsSuccess = false;
                                                                                                }

                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                using (FileStream fsTargetFile = new FileStream(targetFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                                                                                                {
                                                                                                    using (StreamWriter swTargetFile = new StreamWriter(fsTargetFile, Encoding.GetEncoding("GB2312")))
                                                                                                    {
                                                                                                        swTargetFile.WriteLine(line);
                                                                                                        count = count + 1;
                                                                                                        IsExistZZ = true;
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }

                                                                        if (!Directory.Exists(targetDirectoryName1))
                                                                        {
                                                                            Directory.CreateDirectory(targetDirectoryName1);
                                                                        }
                                                                        foreach (string file in Directory.GetFiles(targetDirectoryName))
                                                                        {
                                                                            string name = System.IO.Path.GetFileName(file);
                                                                            string dest = System.IO.Path.Combine(targetDirectoryName1, name);
                                                                            if (File.Exists(dest))
                                                                            {
                                                                                File.Delete(dest);
                                                                            }
                                                                            System.IO.File.Copy(file, dest);//复制文件
                                                                        }


                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }

                                                    //生成大商所文件
                                                    bool IsExistDCE = false;
                                                    foreach (string itemSingleMotorCenterAccount in MergeMotorCenterAccount)
                                                    {
                                                        foreach (XElement itemAccountId in configDocument.Descendants("AccountId"))
                                                        {
                                                            if (itemAccountId.Attribute("value").Value == itemSingleMotorCenterAccount)
                                                            {
                                                                foreach (XElement itemOrganCode in itemAccountId.Descendants("OrganCode"))
                                                                {
                                                                    if (itemOrganCode.Attribute("name").Value == "大商所")
                                                                    {
                                                                        foreach (XElement itemfile in itemOrganCode.Nodes())
                                                                        {
                                                                            foreach (XElement itemfileSrc in itemfile.Nodes())
                                                                            {
                                                                                SourceFileName = Path.Combine(OriginPath.ToString() + "\\" + kryDTPDate.Value.ToString("yyyyMMdd") + string.Format("\\{0}_持仓明细表.txt", kryDTPDate.Value.ToString("yyyyMMdd")));

                                                                                //按账号导出的目录
                                                                                string txtFileName = (itemfile.Attribute("filename").Value.ToString().Replace("{accountid}", GlobalData.SeatNo)).Replace("{tradingday}", kryDTPDate.Value.ToString("yyyyMMdd"));

                                                                                targetFileName = Path.Combine(MonitorCenterOutPath1.ToString() + "\\" + string.Format(@"{0}\大商所格式\TXT文件\{1}\{2}.txt", kryDTPDate.Value.ToString("yyyyMMdd"), GlobalData.SeatNo, txtFileName));
                                                                                targetDirectoryName = Path.Combine(MonitorCenterOutPath1.ToString() + "\\" + string.Format(@"{0}\大商所格式\TXT文件\{1}", kryDTPDate.Value.ToString("yyyyMMdd"), GlobalData.SeatNo));
                                                                                targetDirectoryName1 = Path.Combine(MonitorCenterOutPath2.ToString() + "\\" + string.Format(@"{0}\大商所格式\TXT文件\{1}", kryDTPDate.Value.ToString("yyyyMMdd"), GlobalData.SeatNo));

                                                                                if (!Directory.Exists(targetDirectoryName))
                                                                                {
                                                                                    Directory.CreateDirectory(targetDirectoryName);
                                                                                }
                                                                                else
                                                                                {
                                                                                    if (!IsExistDCE)
                                                                                    {
                                                                                        //为了删除掉此目录下遗留下来的上次文件
                                                                                        DirectoryInfo targetDirectoryInfo = new DirectoryInfo(targetDirectoryName);
                                                                                        targetDirectoryInfo.Delete(true);

                                                                                        Directory.CreateDirectory(targetDirectoryName);
                                                                                    }
                                                                                }
                                                                                //if (Directory.Exists(targetDirectoryName) && !IsExistDCE)
                                                                                //{
                                                                                //    DirectoryInfo targetDirectoryInfo = new DirectoryInfo(targetDirectoryName);
                                                                                //    targetDirectoryInfo.Delete(true);
                                                                                //    Directory.CreateDirectory(targetDirectoryName);
                                                                                //}
                                                                                if (File.Exists(targetFileName) && !IsExistDCE)
                                                                                {
                                                                                    File.Delete(targetFileName);
                                                                                }
                                                                                if (!File.Exists(SourceFileName))
                                                                                {
                                                                                    MessageBox.Show("{大商所持仓明细表不存在", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                                    continue;
                                                                                }

                                                                                using (FileStream fsSourceFile = new FileStream(SourceFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                                                                                {
                                                                                    using (StreamReader swSourceFile = new StreamReader(fsSourceFile, Encoding.GetEncoding("GB2312")))
                                                                                    {
                                                                                        string line = string.Empty;
                                                                                        int count = 0;
                                                                                        bool IsWriteNextLine = false;

                                                                                        while ((line = swSourceFile.ReadLine()) != null)
                                                                                        {
                                                                                            if (count > 0)
                                                                                            {
                                                                                                try
                                                                                                {
                                                                                                    using (StreamWriter swTargetFileAppend = new StreamWriter(targetFileName, true, Encoding.GetEncoding("GB2312")))
                                                                                                    {
                                                                                                        if (count > 3)
                                                                                                        {
                                                                                                            if (!string.IsNullOrEmpty(line.Trim()) && line.Substring(30, 8).Equals(itemSingleMotorCenterAccount))  //    "01767714"  itemSingleMotorCenterAccount
                                                                                                            {
                                                                                                                List<string> colNameList = ColValueSplitLineDCE(line);
                                                                                                                foreach (XElement itemfilecols in itemfileSrc.Nodes())
                                                                                                                {
                                                                                                                    string Datafilecols = colNameList[int.Parse(itemfilecols.Attribute("cid").Value.Trim()) - 1];

                                                                                                                    colNameList = DCEDealData(itemfilecols, Datafilecols, colNameList);

                                                                                                                }
                                                                                                                line = string.Join(string.Empty, colNameList.ToArray());

                                                                                                                swTargetFileAppend.WriteLine(line);
                                                                                                                IsWriteNextLine = true;
                                                                                                                IsExistDCE = true;
                                                                                                            }
                                                                                                            count = count + 1;
                                                                                                        }
                                                                                                        else
                                                                                                        {
                                                                                                            if (count == 3)
                                                                                                            {
                                                                                                                List<string> colNameList = ColNameSplitLineDCE(line);

                                                                                                                foreach (XElement itemfilecols in itemfileSrc.Nodes())
                                                                                                                {
                                                                                                                    if (true)
                                                                                                                    {
                                                                                                                        if (!string.IsNullOrEmpty(itemfilecols.Attribute("tlength").Value) && (int.Parse(itemfilecols.Attribute("tlength").Value.Trim()) > 0)) //列名位数 +对齐方式
                                                                                                                        {
                                                                                                                            string align = itemfilecols.Attribute("align").Value;

                                                                                                                            if (!string.IsNullOrEmpty(align) && align.Equals("左"))
                                                                                                                            {
                                                                                                                                colNameList[int.Parse(itemfilecols.Attribute("cid").Value.Trim()) - 1] = colNameList[int.Parse(itemfilecols.Attribute("cid").Value.Trim()) - 1].Trim().PadRight(int.Parse(itemfilecols.Attribute("tlength").Value.Trim()), ' ');//以空格填充
                                                                                                                            }
                                                                                                                            if (!string.IsNullOrEmpty(align) && align.Equals("右"))
                                                                                                                            {
                                                                                                                                colNameList[int.Parse(itemfilecols.Attribute("cid").Value.Trim()) - 1] = colNameList[int.Parse(itemfilecols.Attribute("cid").Value.Trim()) - 1].Trim().PadLeft(int.Parse(itemfilecols.Attribute("tlength").Value.Trim()), ' ');//以空格填充
                                                                                                                            }
                                                                                                                        }
                                                                                                                    }
                                                                                                                }
                                                                                                                line = string.Join(string.Empty, colNameList.ToArray());
                                                                                                            }
                                                                                                            swTargetFileAppend.WriteLine(line);
                                                                                                            count = count + 1;
                                                                                                            IsExistDCE = true;
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                                catch (Exception ex)
                                                                                                {
                                                                                                    MergeFileIsSuccess = false;
                                                                                                    MessageBox.Show(ex.Message.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                                                    return;
                                                                                                }
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                using (FileStream fsTargetFile = new FileStream(targetFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                                                                                                {
                                                                                                    using (StreamWriter swTargetFile = new StreamWriter(fsTargetFile, Encoding.GetEncoding("GB2312")))
                                                                                                    {
                                                                                                        swTargetFile.WriteLine(line);
                                                                                                        count = count + 1;
                                                                                                        IsExistDCE = true;
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }

                                                                        if (!Directory.Exists(targetDirectoryName1))
                                                                        {
                                                                            Directory.CreateDirectory(targetDirectoryName1);
                                                                        }
                                                                        foreach (string file in Directory.GetFiles(targetDirectoryName))
                                                                        {
                                                                            string name = System.IO.Path.GetFileName(file);
                                                                            string dest = System.IO.Path.Combine(targetDirectoryName1, name);
                                                                            if (File.Exists(dest))
                                                                            {
                                                                                File.Delete(dest);
                                                                            }
                                                                            System.IO.File.Copy(file, dest);//复制文件
                                                                        }

                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }));
                                            }
                                        });
                                        taskMERGE.Start();
                                        taskMERGE.ContinueWith((t) =>
                                        {
                                            if (InvokeRequired)
                                            {
                                                this.Invoke(new Action(() =>
                                                {
                                                    // _frmWait.Close();
                                                    if (MergeFileIsSuccess)
                                                    {
                                                        itemRows.Cells[4].Value += "多账号文件生成成功,";
                                                        //krypLbFlag.Text = "读入原文件结束...";
                                                        MessageBox.Show("多账号合并文件生成成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    }
                                                    else
                                                    {
                                                        itemRows.Cells[4].Value += "多账号文件生成失败,";
                                                        //由于SingleFileIsSuccess是全局变量。当某一次文件生成失败为false时，后续的值就一直是false了，因为这个将其置为true
                                                        MergeFileIsSuccess = true;
                                                        //krypLbFlag.Text = "读入原文件结束...";
                                                        MessageBox.Show("多账号合并文件生成失败", "失败", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    }

                                                }));
                                            }
                                            else
                                            {
                                                if (MergeFileIsSuccess)
                                                {
                                                    itemRows.Cells[4].Value += "多账号文件生成失败,";
                                                    //由于SingleFileIsSuccess是全局变量。当某一次文件生成失败为false时，后续的值就一直是false了，因为这个将其置为true
                                                    MergeFileIsSuccess = true;
                                                    //krypLbFlag.Text = "读入原文件结束...";
                                                    MessageBox.Show("多账号合并文件生成失败", "失败", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                }
                                            }
                                        });

                                    }
                                    catch (Exception ex)
                                    {
                                        MergeFileIsSuccess = false;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MergeFileIsSuccess = false;
                                    MessageBox.Show(ex.Message.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                #endregion

                            }));
                        }
                    });
                    taskGroup.Start();
                    taskGroup.ContinueWith((t) =>
                    {
                        if (InvokeRequired)
                        {
                            this.Invoke(new Action(() =>
                            {
                                if (SingleFileIsSuccess)
                                {
                                    itemRows.Cells[2].Value = "成功";

                                    MessageBox.Show("文件生成成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    itemRows.Cells[2].Value = "失败";
                                    //由于SingleFileIsSuccess是全局变量。当某一次文件生成失败为false时，后续的值就一直是false了，因为这个将其置为true
                                    SingleFileIsSuccess = true;
                                    MessageBox.Show("文件生成失败", "失败", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }

                            }));
                        }
                    });
                }
               

            }
            //        }));
            //    }
            //});
            //taskOneTouch.Start();
            //taskOneTouch.ContinueWith((t) =>
            //{
            //    if (InvokeRequired)
            //    {
            //        this.Invoke(new Action(() =>
            //        {
            //            // _frmWait.Close();
            //            if (SingleFileIsSuccess)
            //            {
            //                //krypLbFlag.Text = "读入原文件结束...";

            //                MessageBox.Show("单账号生成文件生成成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            }
            //            else
            //            {
            //                //由于SingleFileIsSuccess是全局变量。当某一次文件生成失败为false时，后续的值就一直是false了，因为这个将其置为true
            //                SingleFileIsSuccess = true;
            //                //krypLbFlag.Text = "读入原文件结束...";
            //                MessageBox.Show("单账号生成文件生成失败", "失败", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            }

            //        }));
            //    }
            //    else
            //    {
            //        if (SingleFileIsSuccess)
            //        {
            //            //由于SingleFileIsSuccess是全局变量。当某一次文件生成失败为false时，后续的值就一直是false了，因为这个将其置为true
            //            SingleFileIsSuccess = true;
            //            //krypLbFlag.Text = "单账号生成读入原文件结束...";
            //            MessageBox.Show("单账号生成文件生成失败", "失败", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }
            //    }
            //});

        }
        private string SGDealData(XElement itemfilecols, string Datafilecols, string[] sArray)
        {
            try
            {
                if (!string.IsNullOrEmpty(itemfilecols.Attribute("precision").Value.Trim()) && (int.Parse(itemfilecols.Attribute("precision").Value.Trim()) > 0))   //列值精度处理
                {
                    string _format = "#0.";
                    for (int i = 0; i < int.Parse(itemfilecols.Attribute("precision").Value.Trim()); i++)
                    {
                        _format = _format + "0";
                    }

                    Datafilecols = decimal.Parse(sArray[int.Parse(itemfilecols.Attribute("colIndex").Value.ToString()) - 1]).ToString(_format);

                    sArray[int.Parse(itemfilecols.Attribute("colIndex").Value) - 1] = Datafilecols;

                }
                if (!string.IsNullOrEmpty(itemfilecols.Attribute("vlength").Value) && (int.Parse(itemfilecols.Attribute("vlength").Value.Trim()) > 0)) //列值位数 +对齐方式
                {
                    string align = itemfilecols.Attribute("align").Value;

                    if (!string.IsNullOrEmpty(align) && align.Equals("左"))
                    {
                        sArray[int.Parse(itemfilecols.Attribute("colIndex").Value.Trim()) - 1] = sArray[int.Parse(itemfilecols.Attribute("colIndex").Value.Trim()) - 1].Trim().PadRight(int.Parse(itemfilecols.Attribute("vlength").Value.Trim()), ' ');//以空格填充
                    }
                    if (!string.IsNullOrEmpty(align) && align.Equals("右"))
                    {
                        sArray[int.Parse(itemfilecols.Attribute("colIndex").Value.Trim()) - 1] = sArray[int.Parse(itemfilecols.Attribute("colIndex").Value.Trim()) - 1].Trim().PadLeft(int.Parse(itemfilecols.Attribute("vlength").Value.Trim()), ' ');//以空格填充
                    }
                    Datafilecols = sArray[int.Parse(itemfilecols.Attribute("colIndex").Value.Trim()) - 1];
                }

                if (!string.IsNullOrEmpty(itemfilecols.Attribute("isAbs").Value.Trim())) //绝对值
                {
                    if (itemfilecols.Attribute("isAbs").Value.Trim() == "是")
                    {
                        Datafilecols = System.Math.Abs(decimal.Parse(Datafilecols)).ToString();
                    }

                    sArray[int.Parse(itemfilecols.Attribute("colIndex").Value) - 1] = Datafilecols;
                }


                if (!string.IsNullOrEmpty(itemfilecols.Attribute("FixValue").Value.Trim()))   //固定值
                {
                    Datafilecols = itemfilecols.Attribute("FixValue").Value.Trim();

                    sArray[int.Parse(itemfilecols.Attribute("colIndex").Value) - 1] = Datafilecols;
                }
                if (!string.IsNullOrEmpty(itemfilecols.Attribute("isout").Value.Trim()))   //是否输出
                {
                    if (itemfilecols.Attribute("isout").Value.Trim() == "否")
                    {
                        Datafilecols = "";
                    }

                    //sArray[int.Parse(itemfilecols.Attribute("colIndex").Value) - 1] = Datafilecols;
                }

            }
            catch (Exception ex)
            {
                // MergeFileIsSuccess = false;
                string errorInfo = "数据处理出错";
                MessageBox.Show(ex.Message.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return errorInfo;
            }
            return Datafilecols;
            //return sArray[int.Parse(itemfilecols.Attribute("colIndex").Value) - 1];
        }

        //处理每行数据
        private string SGDealDataRowValue(XElement itemfilecols, string Datafilecols, DataRow sArray)
        {
            try
            {
                if (string.IsNullOrEmpty(sArray[int.Parse(itemfilecols.Attribute("cid").Value.ToString())].ToString().Trim()))
                {
                    sArray[int.Parse(itemfilecols.Attribute("cid").Value.ToString())] = "0";
                }
                if (!string.IsNullOrEmpty(itemfilecols.Attribute("FixValue").Value.Trim()))   //固定值
                {
                    Datafilecols = itemfilecols.Attribute("FixValue").Value.Trim();

                    sArray[int.Parse(itemfilecols.Attribute("cid").Value)] = Datafilecols;
                }
                if (!string.IsNullOrEmpty(itemfilecols.Attribute("precision").Value.Trim()) && (int.Parse(itemfilecols.Attribute("precision").Value.Trim()) > 0))   //列值精度处理
                {
                    string _format = "#0.";
                    for (int i = 0; i < int.Parse(itemfilecols.Attribute("precision").Value.Trim()); i++)
                    {
                        _format = _format + "0";
                    }

                    Datafilecols = decimal.Parse(sArray[int.Parse(itemfilecols.Attribute("cid").Value.ToString())].ToString()).ToString(_format);

                    sArray[int.Parse(itemfilecols.Attribute("cid").Value)] = Datafilecols;

                }
                if (!string.IsNullOrEmpty(itemfilecols.Attribute("vlength").Value) && (int.Parse(itemfilecols.Attribute("vlength").Value.Trim()) > 0)) //列值位数 +对齐方式
                {
                    string align = itemfilecols.Attribute("align").Value;

                    if (!string.IsNullOrEmpty(align) && align.Equals("左"))
                    {
                        sArray[int.Parse(itemfilecols.Attribute("cid").Value.Trim())] = sArray[int.Parse(itemfilecols.Attribute("cid").Value.Trim())].ToString().Trim().PadRight(int.Parse(itemfilecols.Attribute("vlength").Value.Trim()), ' ');//以空格填充
                    }
                    if (!string.IsNullOrEmpty(align) && align.Equals("右"))
                    {
                        sArray[int.Parse(itemfilecols.Attribute("cid").Value.Trim())] = sArray[int.Parse(itemfilecols.Attribute("cid").Value.Trim())].ToString().Trim().PadLeft(int.Parse(itemfilecols.Attribute("vlength").Value.Trim()), ' ');//以空格填充
                    }
                    Datafilecols = sArray[int.Parse(itemfilecols.Attribute("cid").Value.ToString().Trim())].ToString();
                }

                if (!string.IsNullOrEmpty(itemfilecols.Attribute("isAbs").Value.Trim())) //绝对值
                {
                    if (itemfilecols.Attribute("isAbs").Value.Trim() == "是")
                    {
                        Datafilecols = System.Math.Abs(decimal.Parse(Datafilecols)).ToString();
                    }

                    sArray[int.Parse(itemfilecols.Attribute("cid").Value)] = Datafilecols;
                }

                if (!string.IsNullOrEmpty(itemfilecols.Attribute("express").Value.Trim())) //计算符号
                {
                    if (itemfilecols.Attribute("express").Value.Trim() == "-")
                    {
                        Datafilecols = "-" + Datafilecols;
                    }

                    sArray[int.Parse(itemfilecols.Attribute("cid").Value)] = Datafilecols;
                }


                if (!string.IsNullOrEmpty(itemfilecols.Attribute("isout").Value.Trim()))   //是否输出
                {
                    if (itemfilecols.Attribute("isout").Value.Trim() == "否")
                    {
                        Datafilecols = "";
                    }

                    //sArray[int.Parse(itemfilecols.Attribute("colIndex").Value) - 1] = Datafilecols;
                }

            }
            catch (Exception ex)
            {
                // MergeFileIsSuccess = false;
                string errorInfo = "数据处理出错";
                MessageBox.Show(ex.Message.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return errorInfo;
            }
            return Datafilecols;
            //return sArray[int.Parse(itemfilecols.Attribute("colIndex").Value) - 1];
        }

        //处理每行数据 单独对中国金融期货交易所 客户分项资金明细表处理，因为他的字段索引从1开始
        private string SGDealDataRowValueClientCapitalDetail(XElement itemfilecols, string Datafilecols, DataRow sArray)
        {
            try
            {
                if (string.IsNullOrEmpty(sArray[int.Parse(itemfilecols.Attribute("cid").Value.ToString()) - 1].ToString().Trim()))
                {
                    sArray[int.Parse(itemfilecols.Attribute("cid").Value.ToString()) - 1] = "0";
                }
                if (!string.IsNullOrEmpty(itemfilecols.Attribute("precision").Value.Trim()) && (int.Parse(itemfilecols.Attribute("precision").Value.Trim()) > 0))   //列值精度处理
                {
                    string _format = "#0.";
                    for (int i = 0; i < int.Parse(itemfilecols.Attribute("precision").Value.Trim()); i++)
                    {
                        _format = _format + "0";
                    }

                    Datafilecols = decimal.Parse(sArray[int.Parse(itemfilecols.Attribute("cid").Value.ToString()) - 1].ToString()).ToString(_format);

                    sArray[int.Parse(itemfilecols.Attribute("cid").Value) - 1] = Datafilecols;

                }
                if (!string.IsNullOrEmpty(itemfilecols.Attribute("vlength").Value) && (int.Parse(itemfilecols.Attribute("vlength").Value.Trim()) > 0)) //列值位数 +对齐方式
                {
                    string align = itemfilecols.Attribute("align").Value;

                    if (!string.IsNullOrEmpty(align) && align.Equals("左"))
                    {
                        sArray[int.Parse(itemfilecols.Attribute("cid").Value.Trim()) - 1] = sArray[int.Parse(itemfilecols.Attribute("cid").Value.Trim()) - 1].ToString().Trim().PadRight(int.Parse(itemfilecols.Attribute("vlength").Value.Trim()), ' ');//以空格填充
                    }
                    if (!string.IsNullOrEmpty(align) && align.Equals("右"))
                    {
                        sArray[int.Parse(itemfilecols.Attribute("cid").Value.Trim()) - 1] = sArray[int.Parse(itemfilecols.Attribute("cid").Value.Trim()) - 1].ToString().Trim().PadLeft(int.Parse(itemfilecols.Attribute("vlength").Value.Trim()), ' ');//以空格填充
                    }
                    Datafilecols = sArray[int.Parse(itemfilecols.Attribute("cid").Value.ToString().Trim()) - 1].ToString();
                }

                if (!string.IsNullOrEmpty(itemfilecols.Attribute("isAbs").Value.Trim())) //绝对值
                {
                    if (itemfilecols.Attribute("isAbs").Value.Trim() == "是")
                    {
                        Datafilecols = System.Math.Abs(decimal.Parse(Datafilecols)).ToString();
                    }

                    sArray[int.Parse(itemfilecols.Attribute("cid").Value) - 1] = Datafilecols;
                }

                if (!string.IsNullOrEmpty(itemfilecols.Attribute("express").Value.Trim())) //计算符号
                {
                    if (itemfilecols.Attribute("express").Value.Trim() == "-")
                    {
                        Datafilecols = "-" + Datafilecols;
                    }

                    sArray[int.Parse(itemfilecols.Attribute("cid").Value) - 1] = Datafilecols;
                }

                if (!string.IsNullOrEmpty(itemfilecols.Attribute("FixValue").Value.Trim()))   //固定值
                {
                    Datafilecols = itemfilecols.Attribute("FixValue").Value.Trim();

                    sArray[int.Parse(itemfilecols.Attribute("cid").Value) - 1] = Datafilecols;
                }
                if (!string.IsNullOrEmpty(itemfilecols.Attribute("isout").Value.Trim()))   //是否输出
                {
                    if (itemfilecols.Attribute("isout").Value.Trim() == "否")
                    {
                        Datafilecols = "";
                    }

                    //sArray[int.Parse(itemfilecols.Attribute("colIndex").Value) - 1] = Datafilecols;
                }

            }
            catch (Exception ex)
            {
                //IsSuccess = false;
                string errorInfo = "数据处理出错";
                MessageBox.Show(ex.Message.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return errorInfo;
            }
            return Datafilecols;
            //return sArray[int.Parse(itemfilecols.Attribute("colIndex").Value) - 1];
        }
        private string[] MonitorCenterDealData(XElement itemfilecols, string Datafilecols, string[] sArray)
        {
            try
            {
                if (!string.IsNullOrEmpty(itemfilecols.Attribute("precision").Value.Trim()) && (int.Parse(itemfilecols.Attribute("precision").Value.Trim()) > 0))   //列值精度处理
                {
                    string _format = "#0.";
                    for (int i = 0; i < int.Parse(itemfilecols.Attribute("precision").Value.Trim()); i++)
                    {
                        _format = _format + "0";
                    }

                    Datafilecols = decimal.Parse(sArray[int.Parse(itemfilecols.Attribute("colIndex").Value.ToString()) - 1]).ToString(_format);

                    sArray[int.Parse(itemfilecols.Attribute("cid").Value) - 1] = Datafilecols;

                }
                if (!string.IsNullOrEmpty(itemfilecols.Attribute("vlength").Value.Trim()) && (int.Parse(itemfilecols.Attribute("vlength").Value.Trim()) > 0)) //列值位数
                {
                    string MakeUpField = string.IsNullOrEmpty(itemfilecols.Attribute("padstr").Value.Trim()) ? ("0") : (itemfilecols.Attribute("padstr").Value.Trim());
                    sArray[int.Parse(itemfilecols.Attribute("cid").Value) - 1] = sArray[int.Parse(itemfilecols.Attribute("cid").Value) - 1].PadLeft(int.Parse(itemfilecols.Attribute("vlength").Value.Trim()), MakeUpField.ToCharArray()[0]);
                }

                if (!string.IsNullOrEmpty(itemfilecols.Attribute("isAbs").Value.Trim())) //绝对值
                {
                    if (itemfilecols.Attribute("isAbs").Value.Trim() == "是")
                    {
                        Datafilecols = System.Math.Abs(decimal.Parse(Datafilecols)).ToString();
                    }

                    sArray[int.Parse(itemfilecols.Attribute("cid").Value) - 1] = Datafilecols;
                }


                if (!string.IsNullOrEmpty(itemfilecols.Attribute("FixValue").Value.Trim()))   //固定值
                {
                    Datafilecols = itemfilecols.Attribute("FixValue").Value.Trim();

                    sArray[int.Parse(itemfilecols.Attribute("cid").Value) - 1] = Datafilecols;
                }
                if (!string.IsNullOrEmpty(itemfilecols.Attribute("isout").Value.Trim()))   //是否输出
                {
                    if (itemfilecols.Attribute("isout").Value.Trim() == "否")
                    {
                        Datafilecols = "";
                    }

                    sArray[int.Parse(itemfilecols.Attribute("cid").Value) - 1] = Datafilecols;
                }

            }
            catch (Exception ex)
            {
                //IsSuccess = false;
                MessageBox.Show(ex.Message.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new string[] { "数据处理出错" };
            }
            return sArray;
        }
        private List<string> CZCEDealData(XElement itemfilecols, string Datafilecols, List<string> colNameList)
        {
            if (!string.IsNullOrEmpty(itemfilecols.Attribute("precision").Value.Trim()) && (int.Parse(itemfilecols.Attribute("precision").Value.Trim()) > 0))   //列值精度处理
            {
                string _format = "#0.";
                for (int i = 0; i < int.Parse(itemfilecols.Attribute("precision").Value.Trim()); i++)
                {
                    _format = _format + "0";
                }
                if (!string.IsNullOrEmpty(Datafilecols.Trim()))
                {
                    colNameList[int.Parse(itemfilecols.Attribute("cid").Value.Trim()) - 1] = decimal.Parse(colNameList[int.Parse(itemfilecols.Attribute("cid").Value.ToString()) - 1]).ToString(_format);
                }
                Datafilecols = colNameList[int.Parse(itemfilecols.Attribute("cid").Value.Trim()) - 1];
            }

            if (!string.IsNullOrEmpty(itemfilecols.Attribute("vlength").Value) && (int.Parse(itemfilecols.Attribute("vlength").Value.Trim()) > 0)) //列值位数 +对齐方式
            {
                string align = itemfilecols.Attribute("align").Value;

                if (!string.IsNullOrEmpty(align) && align.Equals("左"))
                {
                    colNameList[int.Parse(itemfilecols.Attribute("cid").Value.Trim()) - 1] = colNameList[int.Parse(itemfilecols.Attribute("cid").Value.Trim()) - 1].Trim().PadRight(int.Parse(itemfilecols.Attribute("vlength").Value.Trim()), ' ');//以空格填充
                }
                if (!string.IsNullOrEmpty(align) && align.Equals("右"))
                {
                    colNameList[int.Parse(itemfilecols.Attribute("cid").Value.Trim()) - 1] = colNameList[int.Parse(itemfilecols.Attribute("cid").Value.Trim()) - 1].Trim().PadLeft(int.Parse(itemfilecols.Attribute("vlength").Value.Trim()), ' ');//以空格填充
                }
                Datafilecols = colNameList[int.Parse(itemfilecols.Attribute("cid").Value.Trim()) - 1];
            }
            if (!string.IsNullOrEmpty(itemfilecols.Attribute("isAbs").Value.Trim())) //绝对值
            {
                if (itemfilecols.Attribute("isAbs").Value.Trim() == "是")
                {
                    Datafilecols = System.Math.Abs(decimal.Parse(Datafilecols)).ToString();
                }

                colNameList[int.Parse(itemfilecols.Attribute("cid").Value) - 1] = Datafilecols;
            }


            if (!string.IsNullOrEmpty(itemfilecols.Attribute("FixValue").Value.Trim()))   //固定值
            {
                Datafilecols = itemfilecols.Attribute("FixValue").Value.Trim();

                colNameList[int.Parse(itemfilecols.Attribute("cid").Value) - 1] = Datafilecols;
            }
            if (!string.IsNullOrEmpty(itemfilecols.Attribute("isout").Value.Trim()))   //是否输出
            {
                if (itemfilecols.Attribute("isout").Value.Trim() == "否")
                {
                    Datafilecols = "";
                }

                colNameList[int.Parse(itemfilecols.Attribute("cid").Value) - 1] = Datafilecols;
            }
            return colNameList;
        }
        private List<string> ColNameSplitLineCZCE(string line)
        {
            List<string> strList = new List<string> { };
            for (int i = 1; i < 14; i++)
            {
                switch (i)
                {
                    case 1:
                        strList.Add(line.Substring(0, 8));
                        break;
                    case 2:
                        strList.Add(line.Substring(8, 16));
                        break;
                    case 3:
                        strList.Add(line.Substring(24, 4));
                        break;
                    case 4:
                        strList.Add(line.Substring(28, 16));
                        break;
                    case 5:
                        strList.Add(line.Substring(44, 16));
                        break;
                    case 6:
                        strList.Add(line.Substring(60, 8));
                        break;
                    case 7:
                        strList.Add(line.Substring(68, 5));
                        break;
                    case 8:
                        strList.Add(line.Substring(73, 9));
                        break;
                    case 9:
                        strList.Add(line.Substring(82, 8));
                        break;
                    case 10:
                        strList.Add(line.Substring(90, 8));
                        break;
                    case 11:
                        strList.Add(line.Substring(98, 10));
                        break;
                    case 12:
                        strList.Add(line.Substring(108, 9));
                        break;
                    case 13:
                        strList.Add(line.Substring(117, 10));
                        break;
                }

            }
            return strList;
        }
        private List<string> ColValueSplitLineCZCE(string line)
        {
            List<string> strList = new List<string> { };
            for (int i = 1; i < 14; i++)
            {
                switch (i)
                {
                    case 1:
                        strList.Add(line.Substring(0, 12));
                        break;
                    case 2:
                        strList.Add(line.Substring(12, 20));
                        break;
                    case 3:
                        strList.Add(line.Substring(32, 8));
                        break;
                    case 4:
                        strList.Add(line.Substring(40, 20));
                        break;
                    case 5:
                        strList.Add(line.Substring(60, 20));
                        break;
                    case 6:
                        strList.Add(line.Substring(80, 10));
                        break;
                    case 7:
                        strList.Add(line.Substring(90, 8));
                        break;
                    case 8:
                        strList.Add(line.Substring(98, 12));
                        break;
                    case 9:
                        strList.Add(line.Substring(110, 12));
                        break;
                    case 10:
                        strList.Add(line.Substring(122, 12));
                        break;
                    case 11:
                        strList.Add(line.Substring(134, 15));
                        break;
                    case 12:
                        strList.Add(line.Substring(149, 15));
                        break;
                    case 13:
                        strList.Add(line.Substring(164, 15));
                        break;
                }

            }
            return strList;
        }

        private List<string> ColNameSplitLineDCE(string line)
        {
            List<string> strList = new List<string> { };
            for (int i = 1; i < 13; i++)
            {
                switch (i)
                {
                    case 1:
                        strList.Add(line.Substring(0, 6));
                        break;
                    case 2:
                        strList.Add(line.Substring(6, 6));
                        break;
                    case 3:
                        strList.Add(line.Substring(12, 5));
                        break;
                    case 4:
                        strList.Add(line.Substring(17, 14));
                        break;
                    case 5:
                        strList.Add(line.Substring(31, 10));
                        break;
                    case 6:
                        strList.Add(line.Substring(41, 15));
                        break;
                    case 7:
                        strList.Add(line.Substring(56, 10));
                        break;
                    case 8:
                        strList.Add(line.Substring(66, 10));
                        break;
                    case 9:
                        strList.Add(line.Substring(76, 7));
                        break;
                    case 10:
                        strList.Add(line.Substring(83, 17));
                        break;
                    case 11:
                        strList.Add(line.Substring(100, 9));
                        break;
                    case 12:
                        strList.Add(line.Substring(109, 3));
                        break;
                        //case 13:
                        //    strList.Add(line.Substring(118, 3));
                        //    break;
                }

            }
            return strList;
        }
        private List<string> ColValueSplitLineDCE(string line)
        {
            List<string> strList = new List<string> { };
            for (int i = 1; i < 13; i++)
            {
                switch (i)
                {
                    case 1:
                        strList.Add(line.Substring(0, 10));
                        break;
                    case 2:
                        strList.Add(line.Substring(10, 10));
                        break;
                    case 3:
                        strList.Add(line.Substring(20, 10));
                        break;
                    case 4:
                        strList.Add(line.Substring(30, 18));
                        break;
                    case 5:
                        strList.Add(line.Substring(48, 12));
                        break;
                    case 6:
                        strList.Add(line.Substring(60, 26));
                        break;
                    case 7:
                        strList.Add(line.Substring(86, 13));
                        break;
                    case 8:
                        strList.Add(line.Substring(99, 11));
                        break;
                    case 9:
                        strList.Add(line.Substring(110, 6));
                        break;
                    case 10:
                        strList.Add(line.Substring(116, 18));
                        break;
                    case 11:
                        strList.Add(line.Substring(134, 10));
                        break;
                    case 12:
                        strList.Add(line.Substring(144, 4));
                        break;

                }

            }
            return strList;
        }
        private List<string> DCEDealData(XElement itemfilecols, string Datafilecols, List<string> colNameList)
        {
            if (!string.IsNullOrEmpty(itemfilecols.Attribute("precision").Value.Trim()) && (int.Parse(itemfilecols.Attribute("precision").Value.Trim()) > 0))   //列值精度处理
            {
                string _format = "#0.";
                for (int i = 0; i < int.Parse(itemfilecols.Attribute("precision").Value.Trim()); i++)
                {
                    _format = _format + "0";
                }
                if (!string.IsNullOrEmpty(Datafilecols.Trim()))
                {
                    colNameList[int.Parse(itemfilecols.Attribute("cid").Value.Trim()) - 1] = decimal.Parse(colNameList[int.Parse(itemfilecols.Attribute("cid").Value.ToString()) - 1]).ToString(_format);
                }
                Datafilecols = colNameList[int.Parse(itemfilecols.Attribute("cid").Value.Trim()) - 1];
            }

            if (!string.IsNullOrEmpty(itemfilecols.Attribute("vlength").Value) && (int.Parse(itemfilecols.Attribute("vlength").Value.Trim()) > 0)) //列值位数 +对齐方式
            {
                string align = itemfilecols.Attribute("align").Value;

                if (!string.IsNullOrEmpty(align) && align.Equals("左"))
                {
                    colNameList[int.Parse(itemfilecols.Attribute("cid").Value.Trim()) - 1] = colNameList[int.Parse(itemfilecols.Attribute("cid").Value.Trim()) - 1].Trim().PadRight(int.Parse(itemfilecols.Attribute("vlength").Value.Trim()), ' ');//以空格填充
                }
                if (!string.IsNullOrEmpty(align) && align.Equals("右"))
                {
                    colNameList[int.Parse(itemfilecols.Attribute("cid").Value.Trim()) - 1] = colNameList[int.Parse(itemfilecols.Attribute("cid").Value.Trim()) - 1].Trim().PadLeft(int.Parse(itemfilecols.Attribute("vlength").Value.Trim()), ' ');//以空格填充
                }
                Datafilecols = colNameList[int.Parse(itemfilecols.Attribute("cid").Value.Trim()) - 1];
            }
            if (!string.IsNullOrEmpty(itemfilecols.Attribute("isAbs").Value.Trim())) //绝对值
            {
                if (itemfilecols.Attribute("isAbs").Value.Trim() == "是")
                {
                    Datafilecols = System.Math.Abs(decimal.Parse(Datafilecols)).ToString();
                }

                colNameList[int.Parse(itemfilecols.Attribute("cid").Value) - 1] = Datafilecols;
            }


            if (!string.IsNullOrEmpty(itemfilecols.Attribute("FixValue").Value.Trim()))   //固定值
            {
                Datafilecols = itemfilecols.Attribute("FixValue").Value.Trim();

                colNameList[int.Parse(itemfilecols.Attribute("cid").Value) - 1] = Datafilecols;
            }
            if (!string.IsNullOrEmpty(itemfilecols.Attribute("isout").Value.Trim()))   //是否输出
            {
                if (itemfilecols.Attribute("isout").Value.Trim() == "否")
                {
                    Datafilecols = "";
                }

                colNameList[int.Parse(itemfilecols.Attribute("cid").Value) - 1] = Datafilecols;
            }
            return colNameList;
        }
    }
}
