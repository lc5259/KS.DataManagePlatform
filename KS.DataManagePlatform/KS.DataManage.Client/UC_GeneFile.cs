using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KS.DataManage.Utils;
using ComponentFactory.Krypton.Toolkit;
using System.IO;
using System.Xml.Linq;
using System.Xml;
using KS.DataManage.Controls;
using System.Threading.Tasks;
using System.Threading;
using System.Data.OleDb;
namespace KS.DataManage.Client
{
    public partial class UC_GeneFile : UserControl
    {
        string _fileGroup = "";
        public UC_GeneFile()
        {
            InitializeComponent();
            //SetFont();//测试阶段暂时关闭

        }


        public UC_GeneFile(string group)
        {
            InitializeComponent();
            //SetFont();//测试阶段暂时关闭

            //this.SuspendLayout();

            //LoadConfigFile();
            //this.ResumeLayout(false);
        }
        public void LoadConfigFile(string grp)
        {
            _fileGroup = grp;
            this.SuspendLayout();
            string ConfigFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Config\\{0}_UserConfig.xml", grp));
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

                foreach (XElement xNode in configDocument.Descendants("genfile").Nodes())
                {
                    XElement s = xNode;

                    if (xNode.Name.LocalName.Equals("srcpath"))
                    {
                        this.kryTextBoxOriginPath.Text = xNode.Value;
                    }
                    else if (xNode.Name.LocalName.Equals("cffexpath1"))
                    {
                        kryTextBoxCffexOutPath1.Text = xNode.Value;
                    }
                    else if (xNode.Name.LocalName.Equals("cffexpath2"))
                    {
                        kryTextBoxCffexOutPath2.Text = xNode.Value;
                    }
                    else if (xNode.Name.LocalName.Equals("cfmmcpath1"))
                    {
                        kryTextBoxMonitorCenterOutPath1.Text = xNode.Value;
                    }
                    else if (xNode.Name.LocalName.Equals("cfmmcpath2"))
                    {
                        kryTextBoxMonitorCenterOutPath2.Text = xNode.Value;
                    }
                    else if (xNode.Name.LocalName.Equals("filetxt"))
                    {

                    }
                    else if (xNode.Name.LocalName.Equals("filedbf"))
                    {

                    }
                    else if (xNode.Name.LocalName.Equals("filehb"))
                    {

                    }
                    else if (xNode.Name.LocalName.Equals("outPathType"))
                    {

                    }
                    else if (xNode.Name.LocalName.Equals("dirPathType"))
                    {

                    }
                    else if (xNode.Name.LocalName.Equals("dirPath"))
                    {

                    }
                    else if (xNode.Name.LocalName.Equals("AccId"))
                    {
                        foreach (XText item in xNode.Descendants("CFFEX").Nodes())
                        {
                            kryCLBSingleCffexAccount.Items.Add(item.Value);
                        }
                        kryLbSingleCffexAccountCount.Text = "(" + kryCLBSingleCffexAccount.CheckedItems.Count + "/" + kryCLBSingleCffexAccount.Items.Count.ToString() + ")";

                        foreach (XText item in xNode.Descendants("CFMMC").Nodes())
                        {
                            kryCLBSingleMotorCenterAccount.Items.Add(item.Value);
                        }
                        kryLbSingleMotorCenterAccountCount.Text = "(" + kryCLBSingleMotorCenterAccount.CheckedItems.Count + "/" + kryCLBSingleMotorCenterAccount.Items.Count.ToString() + ")";

                        foreach (XText item in xNode.Descendants("CFFEXMERGE").Nodes())
                        {
                            kryCLBMoreCffexAccount.Items.Add(item.Value);
                        }
                        kryLbMoreCffexAccountCount.Text = "(" + kryCLBMoreCffexAccount.CheckedItems.Count + "/" + kryCLBMoreCffexAccount.Items.Count.ToString() + ")";

                        foreach (XText item in xNode.Descendants("CFMMCMERGE").Nodes())
                        {
                            kryCLBMoreMotorCenterAccount.Items.Add(item.Value);
                        }
                        kryLbMoreMotorCenterAccountCount.Text = "(" + kryCLBMoreMotorCenterAccount.CheckedItems.Count + "/" + kryCLBMoreMotorCenterAccount.Items.Count.ToString() + ")";

                    }
                    else if (xNode.Name.LocalName.Equals("MailConfig"))
                    {

                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            this.ResumeLayout(false);
        }

        bool _createVisible = true;
        bool IsSingleCffexCheckAll = true;
        bool IsSingleCffexCheck = true;
        bool IsSingleMotorCenterAll = true;
        bool IsSingleMotorCenter = true;

        bool IsMoreCffexCheckAll = true;
        bool IsMoreCffexCheck = true;
        bool IsMoreMotorCenterAll = true;
        bool IsMoreMotorCenter = true;

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

        private void UCShowData_Load(object sender, EventArgs e)
        {
            SetFont();
            //if (this.InvokeRequired)
            //{
            //    this.Invoke(new Action(()=> {

            //        LoadConfigFile();

            //    }));
            //}
            //else
            //{
            //    LoadConfigFile();
            //}
        }

        private void kryBtOpenOriginPathFile_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            path.ShowDialog();
            this.kryTextBoxOriginPath.Text = path.SelectedPath;

        }

        private void kryBtOpenCffexOutPathFile1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            path.ShowDialog();
            this.kryTextBoxCffexOutPath1.Text = this.kryTextBoxMonitorCenterOutPath1.Text = path.SelectedPath;
        }

        private void kryBtOpenCffexOutPathFile2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            path.ShowDialog();
            this.kryTextBoxCffexOutPath2.Text = this.kryTextBoxMonitorCenterOutPath2.Text = path.SelectedPath;
        }

        private void kryBtOpenMonitorCenterOutPathFile1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            path.ShowDialog();
            this.kryTextBoxMonitorCenterOutPath1.Text = path.SelectedPath;
        }

        private void kryBtOpenMonitorCenterOutPathFile2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            path.ShowDialog();
            this.kryTextBoxMonitorCenterOutPath2.Text = path.SelectedPath;
        }

        private void kryCBSingleCffexAccount_CheckedChanged(object sender, EventArgs e)
        {
            IsSingleCffexCheck = false;
            if (IsSingleCffexCheckAll)
            {
                if (kryCBSingleCffexAccount.Checked)
                {
                    for (int i = 0; i < kryCLBSingleCffexAccount.Items.Count; i++)
                    {
                        kryCLBSingleCffexAccount.SetItemChecked(i, true);
                    }

                }
                else
                {
                    for (int i = 0; i < kryCLBSingleCffexAccount.Items.Count; i++)
                    {
                        kryCLBSingleCffexAccount.SetItemChecked(i, false);
                    }
                }
            }
            kryLbSingleCffexAccountCount.Text = "(" + kryCLBSingleCffexAccount.CheckedItems.Count + "/" + kryCLBSingleCffexAccount.Items.Count.ToString() + ")";
            IsSingleCffexCheck = true;
        }
        private void kryCLBSingleCffexAccount_SelectedValueChanged(object sender, EventArgs e)
        {
            IsSingleCffexCheckAll = false;
            if (IsSingleCffexCheck)
            {
                for (int i = 0; i < kryCLBSingleCffexAccount.Items.Count; i++)
                {
                    if (kryCLBSingleCffexAccount.GetItemChecked(i))
                    {
                        this.kryCBSingleCffexAccount.Checked = true;
                    }
                    else
                    {
                        this.kryCBSingleCffexAccount.Checked = false;
                        kryLbSingleCffexAccountCount.Text = "(" + kryCLBSingleCffexAccount.CheckedItems.Count + "/" + kryCLBSingleCffexAccount.Items.Count.ToString() + ")";
                        IsSingleCffexCheckAll = true;
                        return;
                    }
                }
            }
            kryLbSingleCffexAccountCount.Text = "(" + kryCLBSingleCffexAccount.CheckedItems.Count + "/" + kryCLBSingleCffexAccount.Items.Count.ToString() + ")";
            IsSingleCffexCheckAll = true;
        }
        private void kryBtSingleAccountCffex_Click(object sender, EventArgs e)
        {
            if (!kryCLBSingleCffexAccount.Items.Contains(kryTBSingleFundAcconutNo.Text.ToString()))
            {
                kryCLBSingleCffexAccount.Items.Add(kryTBSingleFundAcconutNo.Text.ToString());
                kryLbSingleCffexAccountCount.Text = "(" + kryCLBSingleCffexAccount.CheckedItems.Count + "/" + kryCLBSingleCffexAccount.Items.Count.ToString() + ")";
            }
        }

        private void krypBtSingleAccountMotorCenter_Click(object sender, EventArgs e)
        {
            if (!kryCLBSingleMotorCenterAccount.Items.Contains(kryTBSingleFundAcconutNo.Text.ToString()))
            {
                kryCLBSingleMotorCenterAccount.Items.Add(kryTBSingleFundAcconutNo.Text.ToString());
                kryLbSingleMotorCenterAccountCount.Text = "(" + kryCLBSingleMotorCenterAccount.CheckedItems.Count + "/" + kryCLBSingleMotorCenterAccount.Items.Count.ToString() + ")";
            }

        }

        private void kryBtSingleAccountAll_Click(object sender, EventArgs e)
        {
            kryBtSingleAccountCffex_Click(null, null);
            krypBtSingleAccountMotorCenter_Click(null, null);
        }

        private void kryCBSingleMotorCenterAccount_CheckedChanged(object sender, EventArgs e)
        {
            IsSingleMotorCenter = false;
            if (IsSingleMotorCenterAll)
            {
                if (kryCBSingleMotorCenterAccount.Checked)
                {
                    for (int i = 0; i < kryCLBSingleMotorCenterAccount.Items.Count; i++)
                    {
                        kryCLBSingleMotorCenterAccount.SetItemChecked(i, true);
                    }

                }
                else
                {
                    for (int i = 0; i < kryCLBSingleMotorCenterAccount.Items.Count; i++)
                    {
                        kryCLBSingleMotorCenterAccount.SetItemChecked(i, false);
                    }
                }
            }
            kryLbSingleMotorCenterAccountCount.Text = "(" + kryCLBSingleMotorCenterAccount.CheckedItems.Count + "/" + kryCLBSingleMotorCenterAccount.Items.Count.ToString() + ")";
            IsSingleMotorCenter = true;
        }

        private void kryCLBSingleMotorCenterAccount_SelectedValueChanged(object sender, EventArgs e)
        {
            IsSingleMotorCenterAll = false;
            if (IsSingleMotorCenter)
            {
                for (int i = 0; i < kryCLBSingleMotorCenterAccount.Items.Count; i++)
                {
                    if (kryCLBSingleMotorCenterAccount.GetItemChecked(i))
                    {
                        this.kryCBSingleMotorCenterAccount.Checked = true;
                    }
                    else
                    {
                        this.kryCBSingleMotorCenterAccount.Checked = false;
                        IsSingleMotorCenterAll = true;
                        kryLbSingleMotorCenterAccountCount.Text = "(" + kryCLBSingleMotorCenterAccount.CheckedItems.Count + "/" + kryCLBSingleMotorCenterAccount.Items.Count.ToString() + ")";
                        return;
                    }
                }
            }
            kryLbSingleMotorCenterAccountCount.Text = "(" + kryCLBSingleMotorCenterAccount.CheckedItems.Count + "/" + kryCLBSingleMotorCenterAccount.Items.Count.ToString() + ")";
            IsSingleMotorCenterAll = true;
        }

        private void kryBtMoreAccountCffex_Click(object sender, EventArgs e)
        {
            if (!kryCLBMoreCffexAccount.Items.Contains(kryTBMoreFundAcconutNo.Text.ToString()))
            {
                kryCLBMoreCffexAccount.Items.Add(kryTBMoreFundAcconutNo.Text.ToString());
                kryLbMoreCffexAccountCount.Text = "(" + kryCLBMoreCffexAccount.CheckedItems.Count + "/" + kryCLBMoreCffexAccount.Items.Count.ToString() + ")";
            }
        }

        private void krypBtMoreAccountMotorCenter_Click(object sender, EventArgs e)
        {
            if (!kryCLBMoreMotorCenterAccount.Items.Contains(kryTBMoreFundAcconutNo.Text.ToString()))
            {
                kryCLBMoreMotorCenterAccount.Items.Add(kryTBMoreFundAcconutNo.Text.ToString());
                kryLbMoreMotorCenterAccountCount.Text = "(" + kryCLBMoreMotorCenterAccount.CheckedItems.Count + "/" + kryCLBMoreMotorCenterAccount.Items.Count.ToString() + ")";
            }
        }

        private void kryBtSingleToMotorCenter_Click(object sender, EventArgs e)
        {
            if ((kryCLBSingleCffexAccount.SelectedItem != null) && (!kryCLBSingleMotorCenterAccount.Items.Contains(kryCLBSingleCffexAccount.SelectedItem)))
            {
                kryCLBSingleMotorCenterAccount.Items.Add(kryCLBSingleCffexAccount.SelectedItem);
            }

        }

        private void kryBtSingleToCffex_Click(object sender, EventArgs e)
        {
            if ((kryCLBSingleMotorCenterAccount.SelectedItem != null) && (!kryCLBSingleCffexAccount.Items.Contains(kryCLBSingleMotorCenterAccount.SelectedItem)))
            {
                kryCLBSingleCffexAccount.Items.Add(kryCLBSingleMotorCenterAccount.SelectedItem);
            }
        }

        private void kryBtSingleToSync_Click(object sender, EventArgs e)
        {
            List<string> SyncList = new List<string>();
            foreach (var item in kryCLBSingleCffexAccount.Items)
            {
                SyncList.Add(item.ToString());
            }
            foreach (var item in kryCLBSingleMotorCenterAccount.Items)
            {
                if (!SyncList.Contains(item.ToString()))
                {
                    SyncList.Add(item.ToString());
                }
            }

            kryCLBSingleCffexAccount.Items.Clear();
            kryCLBSingleMotorCenterAccount.Items.Clear();

            foreach (var item in SyncList)
            {
                kryCLBSingleCffexAccount.Items.Add(item.ToString());
                kryCLBSingleMotorCenterAccount.Items.Add(item.ToString());
            }
        }

        private void kryCLBSingleCffexAccount_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
            }
            catch
            {
            }
            kryCLBSingleCffexAccount.Items.RemoveAt(kryCLBSingleCffexAccount.SelectedIndex);
        }

        private void kryCLBSingleCffexAccount_DoubleClick(object sender, EventArgs e)
        {
            try
            {
            }
            catch
            {
            }
            kryCLBSingleCffexAccount.Items.RemoveAt(kryCLBSingleCffexAccount.SelectedIndex);
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            kryCLBSingleCffexAccount.Items.Remove(kryCLBSingleCffexAccount.SelectedItem);
            kryCLBSingleMotorCenterAccount.Items.Remove(kryCLBSingleMotorCenterAccount.SelectedItem);
        }

        private void kryBtMoreAccountAll_Click(object sender, EventArgs e)
        {
            kryBtMoreAccountCffex_Click(null, null);
            krypBtMoreAccountMotorCenter_Click(null, null);
        }

        private void kryCBMoreCffexAccount_CheckedChanged(object sender, EventArgs e)
        {
            IsMoreCffexCheck = false;
            if (IsMoreCffexCheckAll)
            {
                if (kryCBMoreCffexAccount.Checked)
                {
                    for (int i = 0; i < kryCLBMoreCffexAccount.Items.Count; i++)
                    {
                        kryCLBMoreCffexAccount.SetItemChecked(i, true);
                    }

                }
                else
                {
                    for (int i = 0; i < kryCLBMoreCffexAccount.Items.Count; i++)
                    {
                        kryCLBMoreCffexAccount.SetItemChecked(i, false);
                    }
                }
            }
            kryLbMoreCffexAccountCount.Text = "(" + kryCLBMoreCffexAccount.CheckedItems.Count + "/" + kryCLBMoreCffexAccount.Items.Count.ToString() + ")";
            IsMoreCffexCheck = true;
        }

        private void kryCLBMoreCffexAccount_SelectedValueChanged(object sender, EventArgs e)
        {
            IsMoreCffexCheckAll = false;
            if (IsMoreCffexCheck)
            {
                for (int i = 0; i < kryCLBMoreCffexAccount.Items.Count; i++)
                {
                    if (kryCLBMoreCffexAccount.GetItemChecked(i))
                    {
                        this.kryCBMoreCffexAccount.Checked = true;
                    }
                    else
                    {
                        this.kryCBMoreCffexAccount.Checked = false;
                        kryLbMoreCffexAccountCount.Text = "(" + kryCLBMoreCffexAccount.CheckedItems.Count + "/" + kryCLBMoreCffexAccount.Items.Count.ToString() + ")";
                        IsMoreCffexCheckAll = true;
                        return;
                    }
                }
            }
            kryLbMoreCffexAccountCount.Text = "(" + kryCLBMoreCffexAccount.CheckedItems.Count + "/" + kryCLBMoreCffexAccount.Items.Count.ToString() + ")";
            IsMoreCffexCheckAll = true;
        }

        private void kryCBMoreMotorCenterAccount_CheckedChanged(object sender, EventArgs e)
        {
            IsMoreMotorCenter = false;
            if (IsMoreMotorCenterAll)
            {
                if (kryCBMoreMotorCenterAccount.Checked)
                {
                    for (int i = 0; i < kryCLBMoreMotorCenterAccount.Items.Count; i++)
                    {
                        kryCLBMoreMotorCenterAccount.SetItemChecked(i, true);
                    }

                }
                else
                {
                    for (int i = 0; i < kryCLBMoreMotorCenterAccount.Items.Count; i++)
                    {
                        kryCLBMoreMotorCenterAccount.SetItemChecked(i, false);
                    }
                }
            }
            kryLbMoreMotorCenterAccountCount.Text = "(" + kryCLBMoreMotorCenterAccount.CheckedItems.Count + "/" + kryCLBMoreMotorCenterAccount.Items.Count.ToString() + ")";
            IsMoreMotorCenter = true;
        }

        private void kryCLBMoreMotorCenterAccount_SelectedValueChanged(object sender, EventArgs e)
        {
            IsMoreMotorCenterAll = false;
            if (IsMoreMotorCenter)
            {
                for (int i = 0; i < kryCLBMoreMotorCenterAccount.Items.Count; i++)
                {
                    if (kryCLBMoreMotorCenterAccount.GetItemChecked(i))
                    {
                        this.kryCBMoreMotorCenterAccount.Checked = true;
                    }
                    else
                    {
                        this.kryCBMoreMotorCenterAccount.Checked = false;
                        IsMoreMotorCenterAll = true;
                        kryLbMoreMotorCenterAccountCount.Text = "(" + kryCLBMoreMotorCenterAccount.CheckedItems.Count + "/" + kryCLBMoreMotorCenterAccount.Items.Count.ToString() + ")";
                        return;
                    }
                }
            }
            kryLbMoreMotorCenterAccountCount.Text = "(" + kryCLBMoreMotorCenterAccount.CheckedItems.Count + "/" + kryCLBMoreMotorCenterAccount.Items.Count.ToString() + ")";
            IsMoreMotorCenterAll = true;
        }

        private void kryBtMoreToMotorCenter_Click(object sender, EventArgs e)
        {
            if ((kryCLBMoreCffexAccount.SelectedItem != null) && (!kryCLBMoreMotorCenterAccount.Items.Contains(kryCLBMoreCffexAccount.SelectedItem)))
            {
                kryCLBMoreMotorCenterAccount.Items.Add(kryCLBMoreCffexAccount.SelectedItem);
            }
        }

        private void kryBtMoreToSync_Click(object sender, EventArgs e)
        {
            List<string> SyncList = new List<string>();
            foreach (var item in kryCLBMoreCffexAccount.Items)
            {
                SyncList.Add(item.ToString());
            }
            foreach (var item in kryCLBMoreMotorCenterAccount.Items)
            {
                if (!SyncList.Contains(item.ToString()))
                {
                    SyncList.Add(item.ToString());
                }
            }

            kryCLBMoreCffexAccount.Items.Clear();
            kryCLBMoreMotorCenterAccount.Items.Clear();

            foreach (var item in SyncList)
            {
                kryCLBMoreCffexAccount.Items.Add(item.ToString());
                kryCLBMoreMotorCenterAccount.Items.Add(item.ToString());
            }
        }

        private void kryBtMoreToCffex_Click(object sender, EventArgs e)
        {
            if ((kryCLBMoreMotorCenterAccount.SelectedItem != null) && (!kryCLBMoreCffexAccount.Items.Contains(kryCLBMoreMotorCenterAccount.SelectedItem)))
            {
                kryCLBMoreCffexAccount.Items.Add(kryCLBMoreMotorCenterAccount.SelectedItem);
            }
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            kryCLBMoreCffexAccount.Items.Remove(kryCLBMoreCffexAccount.SelectedItem);
            kryCLBMoreMotorCenterAccount.Items.Remove(kryCLBMoreMotorCenterAccount.SelectedItem);
        }

        private void kryRadioButtonFolderCustomizeYES_CheckedChanged(object sender, EventArgs e)
        {
            krypTBFolderName.Enabled = true;
        }

        private void kryRadioButtonFolderCustomizeNO_CheckedChanged(object sender, EventArgs e)
        {
            krypTBFolderName.Enabled = false;
            krypTBFolderName.Text = "";
        }

        private void kryBtSave_Click(object sender, EventArgs e)
        {
            XmlDocument xmlDoc = new XmlDocument();
            //创建Xml声明部分，即<?xml version="1.0" encoding="utf-8" ?>
            XmlDeclaration Declaration = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);

            //创建根节点
            XmlNode rootNode = xmlDoc.CreateElement("root");

            //创建genfile节点
            XmlNode genfileNode = xmlDoc.CreateElement("genfile");

            //创建genfile的字节点
            XmlNode srcpathNode = xmlDoc.CreateElement("srcpath");
            srcpathNode.InnerText = kryTextBoxOriginPath.Text.ToString();

            XmlNode cffexpath1Node = xmlDoc.CreateElement("cffexpath1");
            cffexpath1Node.InnerText = kryTextBoxCffexOutPath1.Text.ToString();

            XmlNode cffexpath2Node = xmlDoc.CreateElement("cffexpath2");
            cffexpath2Node.InnerText = kryTextBoxCffexOutPath2.Text.ToString();

            XmlNode cfmmcpath1Node = xmlDoc.CreateElement("cfmmcpath1");
            cfmmcpath1Node.InnerText = kryTextBoxMonitorCenterOutPath1.Text.ToString();

            XmlNode cfmmcpath2Node = xmlDoc.CreateElement("cfmmcpath2");
            cfmmcpath2Node.InnerText = kryTextBoxMonitorCenterOutPath2.Text.ToString();

            XmlNode filetxtNode = xmlDoc.CreateElement("filetxt");
            if (kryCBTXT.Checked)
            {
                filetxtNode.InnerText = "1";
            }
            else
            {
                filetxtNode.InnerText = "0";
            }

            XmlNode filedbfNode = xmlDoc.CreateElement("filedbf");
            if (kryCBDBF.Checked)
            {
                filedbfNode.InnerText = "1";
            }
            else
            {
                filedbfNode.InnerText = "0";
            }

            XmlNode filehbNode = xmlDoc.CreateElement("filehb");
            filehbNode.InnerText = "0";

            XmlNode outPathTypeNode = xmlDoc.CreateElement("outPathType");
            if (krypRadioButtonByDate.Checked)
            {
                outPathTypeNode.InnerText = "1";
            }
            if (kryRadioButtonByAccount.Checked)
            {
                outPathTypeNode.InnerText = "0";
            }

            XmlNode dirPathTypeNode = xmlDoc.CreateElement("dirPathType");
            if (kryRadioButtonFolderCustomizeYES.Checked)
            {
                dirPathTypeNode.InnerText = "1";
            }
            if (kryRadioButtonFolderCustomizeNO.Checked)
            {
                dirPathTypeNode.InnerText = "0";
            }

            XmlNode dirPathNode = xmlDoc.CreateElement("dirPath");
            dirPathNode.InnerText = krypTBFolderName.Text.ToString();

            XmlNode AccIdNode = xmlDoc.CreateElement("AccId");
            XmlNode MailConfigNode = xmlDoc.CreateElement("MailConfig");

            //AccId添加子字节点
            // XmlNode CFFEXNode = xmlDoc.CreateElement("CFFEX");
            foreach (var item in kryCLBSingleCffexAccount.Items)
            {
                XmlNode CFFEXNode = xmlDoc.CreateElement("CFFEX");
                CFFEXNode.InnerText = item.ToString();
                AccIdNode.AppendChild(CFFEXNode);
            }
            foreach (var item in kryCLBSingleMotorCenterAccount.Items)
            {
                XmlNode CFMMCNode = xmlDoc.CreateElement("CFMMC");
                CFMMCNode.InnerText = item.ToString();
                AccIdNode.AppendChild(CFMMCNode);
            }
            foreach (var item in kryCLBMoreCffexAccount.Items)
            {
                XmlNode CFFEXMERGEENode = xmlDoc.CreateElement("CFFEXMERGE");
                CFFEXMERGEENode.InnerText = item.ToString();
                AccIdNode.AppendChild(CFFEXMERGEENode);
            }
            foreach (var item in kryCLBMoreMotorCenterAccount.Items)
            {
                XmlNode CFMMCMERGECNode = xmlDoc.CreateElement("CFMMCMERGE");
                CFMMCMERGECNode.InnerText = item.ToString();
                AccIdNode.AppendChild(CFMMCMERGECNode);
            }

            //创建MailConfig的字节点
            XmlNode mailfromNode = xmlDoc.CreateElement("mailfrom");
            XmlNode usernameNode = xmlDoc.CreateElement("username");
            XmlNode passwordNode = xmlDoc.CreateElement("password");
            XmlNode serveraddressNode = xmlDoc.CreateElement("serveraddress");
            XmlNode portNode = xmlDoc.CreateElement("port");
            portNode.InnerText = "25";
            ////AccId添加子字节点
            //AccIdNode.AppendChild(CFFEXNode);

            //MailConfig添加子字节点
            MailConfigNode.AppendChild(mailfromNode);
            MailConfigNode.AppendChild(usernameNode);
            MailConfigNode.AppendChild(passwordNode);
            MailConfigNode.AppendChild(serveraddressNode);
            MailConfigNode.AppendChild(portNode);

            //genfile添加子字节点
            genfileNode.AppendChild(srcpathNode);
            genfileNode.AppendChild(cffexpath1Node);
            genfileNode.AppendChild(cffexpath2Node);
            genfileNode.AppendChild(cfmmcpath1Node);
            genfileNode.AppendChild(cfmmcpath2Node);
            genfileNode.AppendChild(filetxtNode);
            genfileNode.AppendChild(filedbfNode);
            genfileNode.AppendChild(filehbNode);
            genfileNode.AppendChild(outPathTypeNode);
            genfileNode.AppendChild(dirPathTypeNode);
            genfileNode.AppendChild(dirPathNode);
            genfileNode.AppendChild(AccIdNode);
            genfileNode.AppendChild(MailConfigNode);

            //root根节点添加子字节点
            rootNode.AppendChild(genfileNode);

            //xml附加根节点
            xmlDoc.AppendChild(rootNode);

            xmlDoc.InsertBefore(Declaration, xmlDoc.DocumentElement);

            //保存xml文档
            string SavePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Config\\{0}_UserConfig.xml", _fileGroup));
            xmlDoc.Save(SavePath);



            if (File.Exists(SavePath))
            {
                MessageBox.Show("保存设置成功");
            }


        }
        private void kryBtOK_Click(object sender, EventArgs e)
        {

            string OriginPath = Path.Combine(kryTextBoxOriginPath.Text);
            string CffexOutPath1 = Path.Combine(kryTextBoxCffexOutPath1.Text);
            string CffexOutPath2 = Path.Combine(kryTextBoxCffexOutPath2.Text);
            string MonitorCenterOutPath1 = Path.Combine(kryTextBoxMonitorCenterOutPath1.Text);
            string MonitorCenterOutPath2 = Path.Combine(kryTextBoxMonitorCenterOutPath2.Text);

            if (kryCLBSingleMotorCenterAccount.CheckedItems.Count == 0)
            {
                MessageBox.Show("未选中资金账号", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.SuspendLayout();
            string ConfigFileName = GlobalData.GetDataConfigPath(_fileGroup);
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

                string targetFileName = string.Empty;
                string targetDirectoryName = string.Empty;
                string targetDirectoryName1 = string.Empty;
                string SourceFileName = string.Empty;


                FrmWait _frmWait = new FrmWait();
                //_frmWait.ShowDialog();
                try
                {

                    krypLbFlag.Visible = true;
                    krypLbFlag.Text = "读入原文件开始...";
                    //临时测试用

                    #region 业务逻辑处理
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
                                foreach (string itemSingleCffexAccount in kryCLBSingleCffexAccount.Items)
                                {
                                    foreach (string itemSingleMotorCenterAccount in kryCLBSingleMotorCenterAccount.CheckedItems)
                                    {
                                        foreach (XElement itemAccountId in configDocument.Descendants("AccountId"))
                                        {
                                            if (itemAccountId.Attribute("value").Value == itemSingleMotorCenterAccount)
                                            {
                                                foreach (XElement itemOrganCode in itemAccountId.Descendants("OrganCode"))
                                                {
                                                    if (itemOrganCode.Attribute("name").Value == "中金所")
                                                    {
                                                        foreach (XElement itemfile in itemOrganCode.Nodes())
                                                        {
                                                            List<string> colnumName = new List<string>();
                                                            //List<string> colnumValue = new List<string>();
                                                            //Dictionary<int, string> colnumValueFinal = new Dictionary<int, string>();
                                                            List<Dictionary<int, string>> colnumValueFinal = new List<Dictionary<int, string>>();
                                                            DataTable dtResult = new DataTable();
                                                            DataTable dt = new DataTable();

                                                            if (itemAccountId.Attribute("outType").Value.Equals("1"))  //按日期导出at
                                                            {
                                                                string targetFile = (itemfile.Attribute("filename").Value.ToString().Replace("{accountid}", itemSingleMotorCenterAccount)).Replace("{tradingday}", kryDTPDate.Value.ToString("yyyyMMdd"));
                                                                targetFileName = Path.Combine(kryTextBoxMonitorCenterOutPath1.Text.ToString() + "\\" + string.Format(@"{0}\中金所格式\TXT文件\{1}\{2}.txt", kryDTPDate.Value.ToString("yyyyMMdd"), itemSingleMotorCenterAccount, targetFile));
                                                                targetDirectoryName = Path.Combine(kryTextBoxMonitorCenterOutPath1.Text.ToString() + "\\" + string.Format(@"{0}\中金所格式\TXT文件\{1}", kryDTPDate.Value.ToString("yyyyMMdd"), itemSingleMotorCenterAccount));
                                                                targetDirectoryName1 = Path.Combine(kryTextBoxMonitorCenterOutPath2.Text.ToString() + "\\" + string.Format(@"{0}\中金所格式\TXT文件\{1}", kryDTPDate.Value.ToString("yyyyMMdd"), itemSingleMotorCenterAccount));
                                                            }
                                                            else   //按账号导出
                                                            {
                                                                string targetFile = (itemfile.Attribute("filename").Value.ToString().Replace("{accountid}", itemSingleMotorCenterAccount)).Replace("{tradingday}", kryDTPDate.Value.ToString("yyyyMMdd"));
                                                                targetFileName = Path.Combine(kryTextBoxMonitorCenterOutPath1.Text.ToString() + "\\" + string.Format(@"{0}\中金所格式\TXT文件\{1}\{2}.txt", itemSingleMotorCenterAccount, kryDTPDate.Value.ToString("yyyyMMdd"), targetFile));
                                                                targetDirectoryName = Path.Combine(kryTextBoxMonitorCenterOutPath1.Text.ToString() + "\\" + string.Format(@"{0}\中金所格式\TXT文件\{1}", itemSingleMotorCenterAccount, kryDTPDate.Value.ToString("yyyyMMdd")));
                                                                targetDirectoryName1 = Path.Combine(kryTextBoxMonitorCenterOutPath2.Text.ToString() + "\\" + string.Format(@"{0}\中金所格式\TXT文件\{1}", itemSingleMotorCenterAccount, kryDTPDate.Value.ToString("yyyyMMdd")));
                                                            }
                                                            if (!Directory.Exists(targetDirectoryName))
                                                            {
                                                                Directory.CreateDirectory(targetDirectoryName);
                                                            }
                                                            if (File.Exists(targetFileName))
                                                            {
                                                                File.Delete(targetFileName);
                                                            }
                                                            using (FileStream fsTargetFile = new FileStream(targetFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                                                            {
                                                                using (StreamWriter swTargetFile = new StreamWriter(fsTargetFile))
                                                                {
                                                                    string info = itemfile.Attribute("filetitle").Value.ToString().PadLeft(30) + "\r\n" + "\r\n" + string.Format("结算会员号：{0}", 0102).PadRight(30) + string.Format("结算会员名称：{0}", "abc公司").PadRight(30) + string.Format("结算日期：{0}", kryDTPDate.Value.ToString("yyyyMMdd")).PadRight(30);
                                                                    swTargetFile.Write(info);

                                                                }
                                                            }


                                                            foreach (XElement itemfileSrc in itemfile.Descendants("fileSrc"))
                                                            {
                                                                if (itemfileSrc.Attribute("srcfileType").Value.Equals("监控中心"))
                                                                {
                                                                    SourceFileName = Path.Combine(kryTextBoxOriginPath.Text.ToString() + "\\" + kryDTPDate.Value.ToString("yyyyMMdd") + string.Format("\\0228{0}{1}.txt", itemfileSrc.Attribute("srcfile").Value, kryDTPDate.Value.ToString("yyyyMMdd")));
                                                                }
                                                                else
                                                                {
                                                                    SourceFileName = Path.Combine(kryTextBoxOriginPath.Text.ToString() + "\\" + kryDTPDate.Value.ToString("yyyyMMdd") + string.Format("\\{0}.DBF", itemfileSrc.Attribute("srcfile").Value));

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
                                                                                        Dictionary<int, string> colnumValue = new Dictionary<int, string>();
                                                                                        DataRow dr = dtResult.NewRow();
                                                                                        foreach (XElement itemfilecols in itemfileSrc.Nodes())
                                                                                        {
                                                                                            //dtResult.Columns.Add(itemfilecols.Attribute("label").Value, typeof(System.String));

                                                                                            //if (colnumName.Count == 0)
                                                                                            //{
                                                                                            //    colnumName.Add(itemfilecols.Attribute("label").Value);
                                                                                            //}
                                                                                            //else
                                                                                            //{
                                                                                            //    if (!colnumName.Contains(itemfilecols.Attribute("label").Value))
                                                                                            //    {
                                                                                            //        colnumName.Add(itemfilecols.Attribute("label").Value);
                                                                                            //    }
                                                                                            //}

                                                                                            if (!string.IsNullOrEmpty(itemfilecols.Attribute("colIndex").Value.Trim()))
                                                                                            {
                                                                                                string Datafilecols = sArray[int.Parse(itemfilecols.Attribute("colIndex").Value) - 1];

                                                                                                if (colnumValue.ContainsKey(int.Parse(itemfilecols.Attribute("cid").Value.ToString())))
                                                                                                {
                                                                                                    Dictionary<int, string>.ValueCollection value = colnumValue.Values;

                                                                                                    //string newValue = (int.Parse(colnumValue[int.Parse(itemfilecols.Attribute("cid").Value.ToString())]) + int.Parse(SGDealData(itemfilecols, Datafilecols, sArray))).ToString();

                                                                                                    //string newValue = (int.Parse( value.ElementAt(int.Parse(itemfilecols.Attribute("cid").Value.ToString()))) +  int.Parse( SGDealData(itemfilecols, Datafilecols, sArray))).ToString();
                                                                                                    //colnumValue[int.Parse(itemfilecols.Attribute("cid").Value.ToString())] = newValue;

                                                                                                    string newValue = dr[int.Parse(itemfilecols.Attribute("cid").Value.ToString())].ToString() + Datafilecols;

                                                                                                    dr[int.Parse(itemfilecols.Attribute("cid").Value.ToString())] = newValue;
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    //colnumValue.Add(int.Parse(itemfilecols.Attribute("cid").Value.ToString()), SGDealData(itemfilecols, Datafilecols, sArray));
                                                                                                    //dr[int.Parse(itemfilecols.Attribute("cid").Value.ToString())] = SGDealData(itemfilecols, Datafilecols, sArray);

                                                                                                    dr[int.Parse(itemfilecols.Attribute("cid").Value.ToString())] = Datafilecols;
                                                                                                }
                                                                                            }
                                                                                            //sArray = SGDealData(itemfilecols, Datafilecols, sArray);
                                                                                            if (sArray[0] == "数据处理出错")
                                                                                            {
                                                                                                MessageBox.Show(sArray[0], "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                                                return;
                                                                                            }

                                                                                        }
                                                                                        colnumValueFinal.Add(colnumValue);
                                                                                        dtResult.Rows.Add(dr);
                                                                                    }
                                                                                    catch (Exception ex)
                                                                                    {
                                                                                        MessageBox.Show(itemfile.Attribute("filetitle") + ex.Message.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                                        return;
                                                                                    }

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
                                                                else
                                                                {
                                                                    Dictionary<int, string> keywordList = new Dictionary<int, string>();
                                                                    //List<string> keywordList = new List<string>();
                                                                    foreach (DataRow itemDrResul in dtResult.Rows)
                                                                    {
                                                                        foreach (XElement itemfilecols in itemfileSrc.Nodes())
                                                                        {
                                                                            foreach (XElement itemfilepkg in itemfile.Descendants("filepkg"))
                                                                            {
                                                                                if (itemfilecols.Attribute("cid").Value == itemfilepkg.Attribute("pkgColIndex").Value && !string.IsNullOrEmpty(itemfilecols.Attribute("colIndex").Value))
                                                                                {
                                                                                    keywordList.Add( int.Parse( itemfilecols.Attribute("colIndex").Value),itemDrResul[int.Parse(itemfilecols.Attribute("cid").Value)].ToString());
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
                                                                                    if (itemDr[keywordList[0]].ToString() == keywordList[0])
                                                                                    {
                                                                                        itemDrResul[int.Parse(itemfilecols.Attribute("cid").Value)] = itemDr[int.Parse(itemfilecols.Attribute("colIndex").Value.Trim())].ToString();
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


                                                            if (File.Exists(targetFileName))
                                                            {
                                                                using (StreamWriter swTargetFile = File.AppendText(targetFileName))
                                                                {
                                                                    // string LineValueIonfo = string.Join(string.Empty, colnumValueFinal.ToArray());
                                                                    string LineColNameIonfo = string.Join(string.Empty, colnumName.ToArray());
                                                                    swTargetFile.WriteLine(LineColNameIonfo);
                                                                    // swTargetFile.WriteLine(LineValueIonfo);

                                                                }
                                                            }
                                                        }
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
                                foreach (string itemSingleMotorCenterAccount in kryCLBSingleMotorCenterAccount.CheckedItems)
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
                                                            SourceFileName = Path.Combine(kryTextBoxOriginPath.Text.ToString() + "\\" + kryDTPDate.Value.ToString("yyyyMMdd") + string.Format("\\0228{0}{1}.txt", itemfileSrc.Attribute("srcfile").Value, kryDTPDate.Value.ToString("yyyyMMdd")));


                                                            if (itemAccountId.Attribute("outType").Value.Equals("1"))  //按日期导出
                                                            {
                                                                targetFileName = Path.Combine(kryTextBoxMonitorCenterOutPath1.Text.ToString() + "\\" + string.Format(@"{0}\监控中心格式\TXT文件\{1}\{2}{3}{4}.txt", kryDTPDate.Value.ToString("yyyyMMdd"), itemSingleMotorCenterAccount, itemSingleMotorCenterAccount, itemfileSrc.Attribute("srcfile").Value.ToString().ToUpper(), kryDTPDate.Value.ToString("yyyyMMdd")));
                                                                targetDirectoryName = Path.Combine(kryTextBoxMonitorCenterOutPath1.Text.ToString() + "\\" + string.Format(@"{0}\监控中心格式\TXT文件\{1}", kryDTPDate.Value.ToString("yyyyMMdd"), itemSingleMotorCenterAccount));
                                                                targetDirectoryName1 = Path.Combine(kryTextBoxMonitorCenterOutPath2.Text.ToString() + "\\" + string.Format(@"{0}\监控中心格式\TXT文件\{1}", kryDTPDate.Value.ToString("yyyyMMdd"), itemSingleMotorCenterAccount));
                                                            }
                                                            else   //按账号导出
                                                            {
                                                                targetFileName = Path.Combine(kryTextBoxMonitorCenterOutPath1.Text.ToString() + "\\" + string.Format(@"{0}\监控中心格式\TXT文件\{1}\{2}{3}{4}.txt", itemSingleMotorCenterAccount, kryDTPDate.Value.ToString("yyyyMMdd"), itemSingleMotorCenterAccount, itemfileSrc.Attribute("srcfile").Value.ToString().ToUpper(), kryDTPDate.Value.ToString("yyyyMMdd")));
                                                                targetDirectoryName = Path.Combine(kryTextBoxMonitorCenterOutPath1.Text.ToString() + "\\" + string.Format(@"{0}\监控中心格式\TXT文件\{1}", itemSingleMotorCenterAccount, kryDTPDate.Value.ToString("yyyyMMdd")));
                                                                targetDirectoryName1 = Path.Combine(kryTextBoxMonitorCenterOutPath2.Text.ToString() + "\\" + string.Format(@"{0}\监控中心格式\TXT文件\{1}", itemSingleMotorCenterAccount, kryDTPDate.Value.ToString("yyyyMMdd")));
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
                                                                                        MessageBox.Show(sArray[0], "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                                        return;
                                                                                    }
                                                                                    #region

                                                                                    #endregion
                                                                                }
                                                                            }
                                                                            catch (Exception ex)
                                                                            {
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
                                foreach (string itemSingleMotorCenterAccount in kryCLBSingleMotorCenterAccount.CheckedItems)
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

                                                            SourceFileName = Path.Combine(kryTextBoxOriginPath.Text.ToString() + "\\" + kryDTPDate.Value.ToString("yyyyMMdd") + string.Format("\\{0}组合持仓表.txt", kryDTPDate.Value.ToString("yyyyMMdd")));

                                                            //按账号导出的目录
                                                            string txtFileName = (itemfile.Attribute("filename").Value.ToString().Replace("{accountid}", itemSingleMotorCenterAccount)).Replace("{tradingday}", kryDTPDate.Value.ToString("yyyyMMdd"));

                                                            targetFileName = Path.Combine(kryTextBoxMonitorCenterOutPath1.Text.ToString() + "\\" + string.Format(@"{0}\郑商所格式\TXT文件\{1}\{2}.txt", itemSingleMotorCenterAccount, kryDTPDate.Value.ToString("yyyyMMdd"), txtFileName));
                                                            targetDirectoryName = Path.Combine(kryTextBoxMonitorCenterOutPath1.Text.ToString() + "\\" + string.Format(@"{0}\郑商所格式\TXT文件\{1}", itemSingleMotorCenterAccount, kryDTPDate.Value.ToString("yyyyMMdd")));
                                                            targetDirectoryName1 = Path.Combine(kryTextBoxMonitorCenterOutPath2.Text.ToString() + "\\" + string.Format(@"{0}\郑商所格式\TXT文件\{1}", itemSingleMotorCenterAccount, kryDTPDate.Value.ToString("yyyyMMdd")));

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
                                foreach (string itemSingleMotorCenterAccount in kryCLBSingleMotorCenterAccount.CheckedItems)
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
                                                            SourceFileName = Path.Combine(kryTextBoxOriginPath.Text.ToString() + "\\" + kryDTPDate.Value.ToString("yyyyMMdd") + string.Format("\\{0}_持仓明细表.txt", kryDTPDate.Value.ToString("yyyyMMdd")));

                                                            //按账号导出的目录
                                                            string txtFileName = (itemfile.Attribute("filename").Value.ToString().Replace("{accountid}", itemSingleMotorCenterAccount)).Replace("{tradingday}", kryDTPDate.Value.ToString("yyyyMMdd"));

                                                            targetFileName = Path.Combine(kryTextBoxMonitorCenterOutPath1.Text.ToString() + "\\" + string.Format(@"{0}\大商所格式\TXT文件\{1}\{2}.txt", itemSingleMotorCenterAccount, kryDTPDate.Value.ToString("yyyyMMdd"), txtFileName));
                                                            targetDirectoryName = Path.Combine(kryTextBoxMonitorCenterOutPath1.Text.ToString() + "\\" + string.Format(@"{0}\大商所格式\TXT文件\{1}", itemSingleMotorCenterAccount, kryDTPDate.Value.ToString("yyyyMMdd")));
                                                            targetDirectoryName1 = Path.Combine(kryTextBoxMonitorCenterOutPath2.Text.ToString() + "\\" + string.Format(@"{0}\大商所格式\TXT文件\{1}", itemSingleMotorCenterAccount, kryDTPDate.Value.ToString("yyyyMMdd")));

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
                            krypLbFlag.Visible = true;
                            krypLbFlag.Text = "读入原文件开始...";
                            //生成中金所
                            foreach (string itemSingleCffexAccount in kryCLBSingleCffexAccount.Items)
                            {

                            }

                            #region 生成监控中心文件
                            //生成监控中心
                            foreach (string itemSingleMotorCenterAccount in kryCLBSingleMotorCenterAccount.CheckedItems)
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
                                                        SourceFileName = Path.Combine(kryTextBoxOriginPath.Text.ToString() + "\\" + kryDTPDate.Value.ToString("yyyyMMdd") + string.Format("\\0228{0}{1}.txt", itemfileSrc.Attribute("srcfile").Value, kryDTPDate.Value.ToString("yyyyMMdd")));


                                                        if (itemAccountId.Attribute("outType").Value.Equals("1"))  //按日期导出
                                                        {
                                                            targetFileName = Path.Combine(kryTextBoxMonitorCenterOutPath1.Text.ToString() + "\\" + string.Format(@"{0}\监控中心格式\TXT文件\{1}\{2}{3}{4}.txt", kryDTPDate.Value.ToString("yyyyMMdd"), itemSingleMotorCenterAccount, itemSingleMotorCenterAccount, itemfileSrc.Attribute("srcfile").Value.ToString().ToUpper(), kryDTPDate.Value.ToString("yyyyMMdd")));
                                                            targetDirectoryName = Path.Combine(kryTextBoxMonitorCenterOutPath1.Text.ToString() + "\\" + string.Format(@"{0}\监控中心格式\TXT文件\{1}", kryDTPDate.Value.ToString("yyyyMMdd"), itemSingleMotorCenterAccount));
                                                            targetDirectoryName1 = Path.Combine(kryTextBoxMonitorCenterOutPath2.Text.ToString() + "\\" + string.Format(@"{0}\监控中心格式\TXT文件\{1}", kryDTPDate.Value.ToString("yyyyMMdd"), itemSingleMotorCenterAccount));
                                                        }
                                                        else   //按账号导出
                                                        {
                                                            targetFileName = Path.Combine(kryTextBoxMonitorCenterOutPath1.Text.ToString() + "\\" + string.Format(@"{0}\监控中心格式\TXT文件\{1}\{2}{3}{4}.txt", itemSingleMotorCenterAccount, kryDTPDate.Value.ToString("yyyyMMdd"), itemSingleMotorCenterAccount, itemfileSrc.Attribute("srcfile").Value.ToString().ToUpper(), kryDTPDate.Value.ToString("yyyyMMdd")));
                                                            targetDirectoryName = Path.Combine(kryTextBoxMonitorCenterOutPath1.Text.ToString() + "\\" + string.Format(@"{0}\监控中心格式\TXT文件\{1}", itemSingleMotorCenterAccount, kryDTPDate.Value.ToString("yyyyMMdd")));
                                                            targetDirectoryName1 = Path.Combine(kryTextBoxMonitorCenterOutPath2.Text.ToString() + "\\" + string.Format(@"{0}\监控中心格式\TXT文件\{1}", itemSingleMotorCenterAccount, kryDTPDate.Value.ToString("yyyyMMdd")));
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
                            foreach (string itemSingleMotorCenterAccount in kryCLBSingleMotorCenterAccount.CheckedItems)
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

                                                        SourceFileName = Path.Combine(kryTextBoxOriginPath.Text.ToString() + "\\" + kryDTPDate.Value.ToString("yyyyMMdd") + string.Format("\\{0}组合持仓表.txt", kryDTPDate.Value.ToString("yyyyMMdd")));

                                                        //按账号导出的目录
                                                        string txtFileName = (itemfile.Attribute("filename").Value.ToString().Replace("{accountid}", itemSingleMotorCenterAccount)).Replace("{tradingday}", kryDTPDate.Value.ToString("yyyyMMdd"));

                                                        targetFileName = Path.Combine(kryTextBoxMonitorCenterOutPath1.Text.ToString() + "\\" + string.Format(@"{0}\郑商所格式\TXT文件\{1}\{2}.txt", itemSingleMotorCenterAccount, kryDTPDate.Value.ToString("yyyyMMdd"), txtFileName));
                                                        targetDirectoryName = Path.Combine(kryTextBoxMonitorCenterOutPath1.Text.ToString() + "\\" + string.Format(@"{0}\郑商所格式\TXT文件\{1}", itemSingleMotorCenterAccount, kryDTPDate.Value.ToString("yyyyMMdd")));
                                                        targetDirectoryName1 = Path.Combine(kryTextBoxMonitorCenterOutPath2.Text.ToString() + "\\" + string.Format(@"{0}\郑商所格式\TXT文件\{1}", itemSingleMotorCenterAccount, kryDTPDate.Value.ToString("yyyyMMdd")));

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
                            foreach (string itemSingleMotorCenterAccount in kryCLBSingleMotorCenterAccount.CheckedItems)
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
                                                        SourceFileName = Path.Combine(kryTextBoxOriginPath.Text.ToString() + "\\" + kryDTPDate.Value.ToString("yyyyMMdd") + string.Format("\\{0}_持仓明细表.txt", kryDTPDate.Value.ToString("yyyyMMdd")));

                                                        //按账号导出的目录
                                                        string txtFileName = (itemfile.Attribute("filename").Value.ToString().Replace("{accountid}", itemSingleMotorCenterAccount)).Replace("{tradingday}", kryDTPDate.Value.ToString("yyyyMMdd"));

                                                        targetFileName = Path.Combine(kryTextBoxMonitorCenterOutPath1.Text.ToString() + "\\" + string.Format(@"{0}\大商所格式\TXT文件\{1}\{2}.txt", itemSingleMotorCenterAccount, kryDTPDate.Value.ToString("yyyyMMdd"), txtFileName));
                                                        targetDirectoryName = Path.Combine(kryTextBoxMonitorCenterOutPath1.Text.ToString() + "\\" + string.Format(@"{0}\大商所格式\TXT文件\{1}", itemSingleMotorCenterAccount, kryDTPDate.Value.ToString("yyyyMMdd")));
                                                        targetDirectoryName1 = Path.Combine(kryTextBoxMonitorCenterOutPath2.Text.ToString() + "\\" + string.Format(@"{0}\大商所格式\TXT文件\{1}", itemSingleMotorCenterAccount, kryDTPDate.Value.ToString("yyyyMMdd")));

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
                                krypLbFlag.Text = "读入原文件结束...";
                                MessageBox.Show("文件生成成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }));
                        }
                        else
                        {
                            //_frmWait.Close();
                            krypLbFlag.Text = "读入原文件结束...";
                            MessageBox.Show("文件生成成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    });
                    #endregion 
                    //MessageBox.Show("11111111111123333333333333");
                    //FrmFundOtherSet fr = new FrmFundOtherSet();
                    //fr.Show();
                    //Task tsk = new Task(() =>
                    //{
                    //    if (this.InvokeRequired)
                    //    {
                    //        this.BeginInvoke((Action)delegate ()
                    //        {
                    //            _frmWait.ShowDialog();

                    //        });
                    //        //Thread.Sleep(5000);
                    //        //if (this.InvokeRequired)
                    //        //{
                    //        //    this.Invoke(new Action(() =>
                    //        //    {
                    //        //        _frmWait.Close();

                    //        //    }));
                    //        //}
                    //        //else
                    //        //{
                    //        //    _frmWait.Close();
                    //        //}

                    //    }
                    //    else

                    //    {
                    //        _frmWait.ShowDialog();

                    //    }
                    //});
                    //tsk.Start();

                }
                catch (Exception ex)
                {

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


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
        //private DataTable ReadDBF(string sFile)
        //{

        //    //int iIndex = sFile.LastIndexOf('\\');
        //    //string strConn = @"Provider=vfpoledb;Data Source=" + sFile.Substring(0, iIndex) + ";Collating Sequence=machine;";
        //    //try
        //    //{
        //    //    using (OleDbConnection oleCon = new OleDbConnection(strConn))
        //    //    {
        //    //        oleCon.Open();
        //    //        if (string.IsNullOrEmpty(sSQL))
        //    //            sSQL = "SELECT * FROM " + sFile.Substring(iIndex + 1);

        //    //        OleDbDataAdapter adapter = new OleDbDataAdapter(sSQL, oleCon);

        //    //        DataTable dt = new DataTable();
        //    //        adapter.Fill(dt);

        //    //        return dt;
        //    //    }
        //    //}
        //    //catch (System.Exception ex)
        //    //{
        //    //    MessageBox.Show(this, ex.Message, "加载DBF失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    //    return null;
        //    //}


        //}
    }

}
