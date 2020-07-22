using KS.DataManage.Templete;
using KS.DataManage.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace KS.DataManage.Client
{
    public partial class FrmSourceFileSet : FrmSaveBase
    {
        DataRow drOrigin;
        DataTable dtOrigin;
        int drIndex;
        public FrmSourceFileSet()
        {
            InitializeComponent();
            UC_DataSetting.ReturnDt = null;
        }
        public FrmSourceFileSet(int drIndex, DataTable dt, string title)
        {
            InitializeComponent();
            UC_DataSetting.ReturnDt = null;
            if (title == "源文件列表修改")
            {
                kryCBBSourceFileNo.Enabled = false;
            }

            this.Text = title;
            this.drOrigin = dt.Rows[drIndex];
            this.dtOrigin = dt;
            this.drIndex = drIndex;

            kryCBBSourceFileNo.Text = this.drOrigin["DataSourceFileNo"].ToString();
            kryCBBSourceFileName.Text = this.drOrigin["DataSourceFileName"].ToString();
            kryCBBSourceFileNameFunfAccountNoIndex.Text = this.drOrigin["DataSourceFileFunfAccountNoIndex"].ToString();
            kryCBBSourceFileFrom.Text = this.drOrigin["DataSourceFileFrom"].ToString();
            kryCBBSourceFileSeparator.Text = this.drOrigin["DataSourceFileSeparator"].ToString();
            kryCBBSourceFileMergeType.Text = this.drOrigin["DataSourceFileMergeType"].ToString();

        }
        private void kbtnCancle_Click(object sender, EventArgs e)
        {
            UC_DataSetting.ReturnDt = dtOrigin;
            // System.Threading.Thread.Sleep(200);
            this.Close();
        }
        public override void OnClose()
        {
            UC_DataSetting.ReturnDt = dtOrigin;
        }
        private void kbtnSave_Click(object sender, EventArgs e)
        {
            DataTable dt =  new DataTable(); 
            if (dtOrigin == null)
            {
                dt.Columns.Add("DataSourceFileNo", typeof(System.String));
                dt.Columns.Add("DataSourceFileName", typeof(System.String));
                dt.Columns.Add("DataSourceFileFunfAccountNoIndex", typeof(System.String));
                dt.Columns.Add("DataSourceFileFrom", typeof(System.String));
                dt.Columns.Add("DataSourceFileSeparator", typeof(System.String));
                dt.Columns.Add("DataSourceFileMergeType", typeof(System.String));
            }
            else
            {
                 dt = dtOrigin.Copy();
            }
           
            DataRow dr = dt.NewRow();
            dr["DataSourceFileNo"] = kryCBBSourceFileNo.Text.ToString();
            dr["DataSourceFileName"] = kryCBBSourceFileName.Text.ToString();
            dr["DataSourceFileFunfAccountNoIndex"] = kryCBBSourceFileNameFunfAccountNoIndex.Text.ToString();
            dr["DataSourceFileFrom"] = kryCBBSourceFileFrom.Text.ToString();
            dr["DataSourceFileSeparator"] = kryCBBSourceFileSeparator.Text.ToString();
            dr["DataSourceFileMergeType"] = kryCBBSourceFileMergeType.Text.ToString();

            if (this.Text == "源文件列表修改")
            {
                dt.Rows.RemoveAt(this.drIndex);
            }
            dt.Rows.InsertAt(dr, this.drIndex);

            UC_DataSetting.ReturnDt = dt;
            

            //if (this.Text == "源文件列表增加")
            //{

            //    XElement _xElement = new XElement("fileSrc");
            //    _xElement.Add(new XAttribute("srcid", dr["DataSourceFileNo"]),
            //                  new XAttribute("srcfile", dr["DataSourceFileName"]),
            //                  new XAttribute("AccIdIndex", dr["DataSourceFileFunfAccountNoIndex"]),
            //                  new XAttribute("srcfileType", dr["DataSourceFileFrom"]),
            //                  new XAttribute("splitc", dr["DataSourceFileSeparator"]),
            //                  new XAttribute("combtype", dr["DataSourceFileMergeType"])
            //                 );

            //    UC_DataSetting.ReturnXElement = _xElement;
            //    //UC_DataSetting.ReturnOrganCode = dr["DataTargetOrganizationName"].ToString();
            //}

            if (this.Text == "源文件列表修改")
            {
                foreach (XElement itemfile in GlobalData.TemplateConfigInfo.Descendants("file"))
                {
                    //foreach (XElement item in itemOrganCode.Nodes())
                    //{
                    if (itemfile.Attribute("filetitle").Value == UC_DataSetting.SelectedTargetFileTitle)
                    {
                        foreach (XElement itemfileSrc in itemfile.Descendants("fileSrc"))
                        {
                            if (itemfileSrc.Attribute("srcfile").Value == this.drOrigin["DataSourceFileName"].ToString() && itemfileSrc.Attribute("srcid").Value == this.drOrigin["DataSourceFileNo"].ToString())
                            {
                                itemfileSrc.Attribute("srcid").Value = dr["DataSourceFileNo"].ToString();
                                itemfileSrc.Attribute("srcfile").Value = dr["DataSourceFileName"].ToString();
                                itemfileSrc.Attribute("AccIdIndex").Value = dr["DataSourceFileFunfAccountNoIndex"].ToString();
                                itemfileSrc.Attribute("srcfileType").Value = dr["DataSourceFileFrom"].ToString();
                                itemfileSrc.Attribute("splitc").Value = dr["DataSourceFileSeparator"].ToString();
                                itemfileSrc.Attribute("combtype").Value = dr["DataSourceFileMergeType"].ToString();
                                break;
                            }
                        }
                    }
                }
            }
            else   //源文件列表增加
            {
                XElement _xElement = new XElement("fileSrc");
                _xElement.Add(new XAttribute("srcid", dr["DataSourceFileNo"]),
                              new XAttribute("srcfile", dr["DataSourceFileName"]),
                              new XAttribute("AccIdIndex", dr["DataSourceFileFunfAccountNoIndex"]),
                              new XAttribute("srcfileType", dr["DataSourceFileFrom"]),
                              new XAttribute("splitc", dr["DataSourceFileSeparator"]),
                              new XAttribute("combtype", dr["DataSourceFileMergeType"])
                             );

                UC_DataSetting.ReturnXElement = _xElement;
                //UC_DataSetting.ReturnOrganCode = dr["DataTargetOrganizationName"].ToString();
            }
            this.Close();
        }

        private void FrmSourceFileSet_FormClosing(object sender, FormClosingEventArgs e)
        {
            //UC_DataSetting.ReturnDt = dtOrigin;
        }
    }
}
