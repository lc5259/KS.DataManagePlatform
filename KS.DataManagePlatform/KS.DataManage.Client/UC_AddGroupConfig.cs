using ComponentFactory.Krypton.Toolkit;
using KS.DataManage.Client;
using KS.DataManage.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

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
            try
            {
                string GroupName = kryTextBoxName.Text.ToString();
                // FrmMain frmMain = new FrmMain();
                if (!string.IsNullOrEmpty(GroupName))
                {
                    FrmMain.AddGroup(GroupName);
                   
                    #region 创建UserConfig.xml
                    XmlDocument xmlDoc = new XmlDocument();
                    //创建Xml声明部分，即<?xml version="1.0" encoding="utf-8" ?>
                    XmlDeclaration Declaration = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);

                    //创建根节点
                    XmlNode rootNode = xmlDoc.CreateElement("root");

                    //创建genfile节点
                    XmlNode genfileNode = xmlDoc.CreateElement("genfile");

                    //创建genfile的字节点
                    XmlNode srcpathNode = xmlDoc.CreateElement("srcpath");
                    srcpathNode.InnerText = @"D:\";

                    XmlNode cffexpath1Node = xmlDoc.CreateElement("cffexpath1");
                    cffexpath1Node.InnerText = @"F:\file-new\tag";

                    XmlNode cffexpath2Node = xmlDoc.CreateElement("cffexpath2");
                    //cffexpath2Node.InnerText = kryTextBoxCffexOutPath2.Text.ToString();

                    XmlNode cfmmcpath1Node = xmlDoc.CreateElement("cfmmcpath1");
                    cfmmcpath1Node.InnerText = @" F:\file - new\tag";

                    XmlNode cfmmcpath2Node = xmlDoc.CreateElement("cfmmcpath2");
                    //cfmmcpath2Node.InnerText = kryTextBoxMonitorCenterOutPath2.Text.ToString();

                    XmlNode filetxtNode = xmlDoc.CreateElement("filetxt");
                    filetxtNode.InnerText = "1";

                    XmlNode filedbfNode = xmlDoc.CreateElement("filedbf");
                    filedbfNode.InnerText = "1";

                    XmlNode filehbNode = xmlDoc.CreateElement("filehb");
                    filehbNode.InnerText = "1";

                    XmlNode outPathTypeNode = xmlDoc.CreateElement("outPathType");
                    outPathTypeNode.InnerText = "0";

                    XmlNode dirPathTypeNode = xmlDoc.CreateElement("dirPathType");
                    dirPathTypeNode.InnerText = "0";


                    XmlNode dirPathNode = xmlDoc.CreateElement("dirPath");
                    //dirPathNode.InnerText = krypTBFolderName.Text.ToString();

                    XmlNode AccIdNode = xmlDoc.CreateElement("AccId");
                    XmlNode MailConfigNode = xmlDoc.CreateElement("MailConfig");

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
                    string SavePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Config\\{0}_UserConfig.xml", GroupName));
                    xmlDoc.Save(SavePath);
                    #endregion

                    //以默认分组的xml为模板
                    //XDocument xmlListDocSource = XDocument.Load(GlobalData.GetDataConfigPath("默认分组"));

                    //for (int i = 0; i < xmlListDocSource.Descendants("AccountId").Count; i++)
                    //{
                        
                    //}

                    //foreach (XElement item in xmlListDocSource.Descendants("AccountId").)
                    //{
                    //    if (item.Attribute("value").Value.ToString().Equals("模版4.1") || item.Attribute("value").Value.ToString().Equals("模版4.2") || item.Attribute("value").Value.ToString().Equals("模版4.3") || item.Attribute("value").Value.ToString().Equals("模版4.3.2"))
                    //    {

                    //    }
                    //    else
                    //    {
                            
                    //        item.Remove();
                    //        break;
                    //    }
                    //}

                    XmlDocument xmlListDocSource = new XmlDocument();
                    XmlDocument xmlListDocDest = new XmlDocument();

                    xmlListDocSource.Load(GlobalData.GetDataConfigPath("默认分组"));
                    for (int i = 0; i < xmlListDocSource.GetElementsByTagName("AccountId").Count; i++)
                    {
                        XmlNode root = xmlListDocSource.SelectSingleNode("root");//获取跟节点
                        XmlNodeList nodes = root.ChildNodes;//获取根节点的字节的点
                        foreach (XmlNode node in nodes)
                        {
                            if (node.NodeType != XmlNodeType.Element)
                            {
                                continue;
                            }
                            XmlElement item = node as XmlElement;
                            if (item.GetAttribute("value").ToString().Equals("模版4.1") || item.GetAttribute("value").ToString().Equals("模版4.2") || item.GetAttribute("value").ToString().Equals("模版4.3") || item.GetAttribute("value").ToString().Equals("模版4.3.2"))
                            {

                            }
                            else
                            {
                                root.RemoveChild(node);
                            }

                            //XmlNode idNode = node.SelectSingleNode("value"); //根据value删除
                            //if (idNode.InnerText.Equals(id))
                            //{
                            //    root.RemoveChild(node);
                            //    break;
                            //}
                        }




                        //XmlElement item = xmlListDocSource.GetElementsByTagName("AccountId")[i] as XmlElement;
                        //if (item.GetAttribute("value").ToString().Equals("模版4.1") || item.GetAttribute("value").ToString().Equals("模版4.2") || item.GetAttribute("value").ToString().Equals("模版4.3") || item.GetAttribute("value").ToString().Equals("模版4.3.2"))
                        //{

                        //}
                        //else
                        //{
                        //    xmlListDocSource.
                        //    item.RemoveAll();
                        //}
                    }
                    //foreach (XmlElement item in xmlListDocSource.GetElementsByTagName("AccountId"))
                    //{
                    //    if (item.GetAttribute("value").ToString().Equals("模版4.1") || item.GetAttribute("value").ToString().Equals("模版4.2") || item.GetAttribute("value").ToString().Equals("模版4.3") || item.GetAttribute("value").ToString().Equals("模版4.3.2"))
                    //    {

                    //    }
                    //    else
                    //    {

                    //        item.RemoveAll();
                    //    }
                    //}

                    //foreach (XmlElement item in xmlListDocSource.GetElementsByTagName("AccountId"))
                    //{
                    //    if (item.GetAttribute("value").ToString().Equals("模版4.1") || item.GetAttribute("value").ToString().Equals("模版4.2") || item.GetAttribute("value").ToString().Equals("模版4.3") || item.GetAttribute("value").ToString().Equals("模版4.3.2"))
                    //    {

                    //    }
                    //    else
                    //    {

                    //        item.RemoveAll();
                    //    }
                    //}
                    xmlListDocSource.Save(GlobalData.GetDataConfigPath(GroupName));

                    //
                    GlobalData.AccountGroup.Add(GroupName);
                    //((UC_DataSetting)uc).LoadConfigFile();
                    UC_DataSetting uc = new UC_DataSetting();
                    uc.kCombAccount.DataSource = GlobalData.AccountGroup;


                    //分组名添加的分组的配置文件中
                    string ConfigFileName = GlobalData.SysConfigPath;
                    XDocument configDocument = XDocument.Load(ConfigFileName);

                    XElement _xElement = new XElement("TABNAME", GroupName);

                    XElement xmlroot = configDocument.Root;
                    foreach (XElement item in xmlroot.Descendants("Broker"))
                    {
                        foreach (XElement item1 in item.Nodes())
                        {
                            if(item1.Name == "GROUPDATA")
                            {
                                item1.Add(_xElement);
                            }
                        }
                      
                    }
                    configDocument.Save(ConfigFileName);

                    //XElement sdg = configDocument.LastNode.Parent;
                    //sdg.Add(_xElement);

                    //configDocument.LastNode.AddAfterSelf(_xElement);
                    // foreach (XElement item in configDocument.Descendants("Broker"))
                    // {
                    //     if (item.Name == "GROUPDATA")
                    //     {
                    //         item.Add(_xElement);
                    //     }
                    // }

                    //
                    // XNode sd = configDocument.LastNode;
                    //sd.AddAfterSelf(filehbNode13);

                    if (!kryCheckBoxContinuousGroup.Checked)
                    {
                        this.Close();
                    }
                }
            }
            catch (Exception ex )
            {

            }
            
        }
    }
}
