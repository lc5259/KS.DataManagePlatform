﻿using System;
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
            string dsg = kryDTPDate.Value.ToString("yyyyMMdd");

            decimal a = 2355.1m;
            a = Math.Round(a,3);
            string gfdsg = string.Empty;

            //string dsg = a.ToString("#0.00");
            string sd = dsg.PadRight(dsg.Length + 3, '0');

            string dsgdd = "#0." ;
            for (int i = 0; i < 4; i++)
            {
                dsgdd = dsgdd + "0";
            }


            string OriginPath = Path.Combine(kryTextBoxOriginPath.Text);
            string CffexOutPath1 = Path.Combine(kryTextBoxCffexOutPath1.Text);
            string CffexOutPath2 = Path.Combine(kryTextBoxCffexOutPath2.Text);
            string MonitorCenterOutPath1 = Path.Combine(kryTextBoxMonitorCenterOutPath1.Text);
            string MonitorCenterOutPath2 = Path.Combine(kryTextBoxMonitorCenterOutPath2.Text);

            //string ConfigFileName = GlobalData.GetDataConfigPath(kCombAccount.SelectedItem.ToString());

            this.SuspendLayout();
            string ConfigFileName = GlobalData.GetDataConfigPath(_fileGroup);
            //string ConfigFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Config\\{0}_UserConfig.xml", _fileGroup));
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


                //临时测试用
                
                //生成中金所
                foreach (string itemSingleCffexAccount in kryCLBSingleCffexAccount.Items)
                {

                }
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
                                            targetFileName = Path.Combine(kryTextBoxMonitorCenterOutPath1.Text.ToString()+ "\\" + string.Format(@"{0}\监控中心格式\TXT文件\{1}\{2}{3}{4}.txt", itemSingleMotorCenterAccount, kryDTPDate.Value.ToString("yyyyMMdd"),itemSingleMotorCenterAccount, itemfileSrc.Attribute("srcfile").Value.ToString().ToUpper(), kryDTPDate.Value.ToString("yyyyMMdd")));
                                            targetDirectoryName  = Path.Combine(kryTextBoxMonitorCenterOutPath1.Text.ToString() + "\\" + string.Format(@"{0}\监控中心格式\TXT文件\{1}", itemSingleMotorCenterAccount, kryDTPDate.Value.ToString("yyyyMMdd")));
                                            targetDirectoryName1 = Path.Combine(kryTextBoxMonitorCenterOutPath2.Text.ToString() + "\\" + string.Format(@"{0}\监控中心格式\TXT文件\{1}", itemSingleMotorCenterAccount, kryDTPDate.Value.ToString("yyyyMMdd")));

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
                                                            //using (StreamWriter swTargetFile = File.AppendText(targetFileName))
                                                            //{
                                                            //    swTargetFile.WriteLine(line);

                                                            //}
                                                            try
                                                            {
                                                                foreach (XElement itemfilecols in itemfileSrc.Nodes())
                                                                {
                                                                    string Datafilecols = sArray[int.Parse(itemfilecols.Attribute("cid").Value) - 1];

                                                                    sArray = DealData(itemfilecols, Datafilecols, sArray);
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
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("文件生成成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private string[] DealData(XElement itemfilecols,string Datafilecols,string[] sArray)
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

                if (!string.IsNullOrEmpty(itemfilecols.Attribute("isout").Value.Trim()))   //是否输出
                {
                    if (itemfilecols.Attribute("isout").Value.Trim() == "否")
                    {
                        Datafilecols = "";
                    }

                    sArray[int.Parse(itemfilecols.Attribute("cid").Value) - 1] = Datafilecols;
                }
                if (!string.IsNullOrEmpty(itemfilecols.Attribute("FixValue").Value.Trim()))   //固定值
                {
                    Datafilecols = itemfilecols.Attribute("FixValue").Value.Trim();

                    sArray[int.Parse(itemfilecols.Attribute("cid").Value) - 1] = Datafilecols;
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new string []{ "数据处理出错"};
            }
            return sArray;
        }
    }

}
