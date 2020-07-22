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
    public partial class FrmGenerateFileKeywordSet : FrmSaveBase
    {
        DataRow drOrigin;
        DataTable dtOrigin;
        int drIndex;
        public FrmGenerateFileKeywordSet()
        {
            InitializeComponent();
            UC_DataSetting.ReturnDt = null;
        }
        public FrmGenerateFileKeywordSet(int drIndex, DataTable dt, string title)
        {
            InitializeComponent();
            UC_DataSetting.ReturnDt = null;
            if (title == "生成文件关键字修改")
            {
                kryCBBGenerateFileKeywordNo.Enabled = false;
            }
            this.Text = title;
            this.drOrigin = dt.Rows[drIndex];
            this.dtOrigin = dt;
            this.drIndex = drIndex;

            kryCBBGenerateFileKeywordNo.Text = this.drOrigin["DataGenerateFileKeywordNo"].ToString();
            kryCBBGenerateFileKeywordName.Text = this.drOrigin["DataGenerateFileKeywordName"].ToString();
            kryCBBGenerateFileKeywordIndex.Text = this.drOrigin["DataGenerateFileKeywordIndex"].ToString();

        }
        //private void kbtnCancle_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //}
        public override void OnClose()
        {
            UC_DataSetting.ReturnDt = dtOrigin;
        }
        private void kbtnSave_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (dtOrigin == null)
            {
                dt.Columns.Add("DataGenerateFileKeywordNo", typeof(System.String));
                dt.Columns.Add("DataGenerateFileKeywordName", typeof(System.String));
                dt.Columns.Add("DataGenerateFileKeywordIndex", typeof(System.String));
            }
            else
            {
                dt = dtOrigin.Copy();
            }

            //DataTable dt = dtOrigin.Copy();
           
            DataRow dr = dt.NewRow();
            dr["DataGenerateFileKeywordNo"] = kryCBBGenerateFileKeywordNo.Text.ToString();
            dr["DataGenerateFileKeywordName"] = kryCBBGenerateFileKeywordName.Text.ToString();
            dr["DataGenerateFileKeywordIndex"] = kryCBBGenerateFileKeywordIndex.Text.ToString();

            if (this.Text == "生成文件关键字修改")
            {
                dt.Rows.RemoveAt(this.drIndex);
            }
            dt.Rows.InsertAt(dr, this.drIndex);

            UC_DataSetting.ReturnDt = dt;

            //if (this.Text == "生成文件关键字增加")
            //{

            //    XElement _xElement = new XElement("filepkg");
            //    _xElement.Add(new XAttribute("pkid", dr["DataGenerateFileKeywordNo"]),
            //                  new XAttribute("name", dr["DataGenerateFileKeywordName"]),
            //                  new XAttribute("pkgColIndex", dr["DataGenerateFileKeywordIndex"])
            //                 );

            //    UC_DataSetting.ReturnXElement = _xElement;
            //    //UC_DataSetting.ReturnOrganCode = dr["DataTargetOrganizationName"].ToString();
            //}
            if (this.Text == "生成文件关键字修改")
            {
                foreach (XElement itemfile in GlobalData.TemplateConfigInfo.Descendants("file"))
                {
                    //foreach (XElement item in itemOrganCode.Nodes())
                    //{
                    if (itemfile.Attribute("filetitle").Value == UC_DataSetting.SelectedTargetFileTitle)
                    {
                        foreach (XElement itemfilepkg in itemfile.Descendants("filepkg"))
                        {
                            if (itemfilepkg.Attribute("pkid").Value == this.drOrigin["DataGenerateFileKeywordNo"].ToString() && itemfilepkg.Attribute("name").Value == this.drOrigin["DataGenerateFileKeywordName"].ToString())
                            {
                                itemfilepkg.Attribute("pkid").Value = dr["DataGenerateFileKeywordNo"].ToString();
                                itemfilepkg.Attribute("name").Value = dr["DataGenerateFileKeywordName"].ToString();
                                itemfilepkg.Attribute("pkgColIndex").Value = dr["DataGenerateFileKeywordIndex"].ToString();

                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                XElement _xElement = new XElement("filepkg");
                _xElement.Add(new XAttribute("pkid", dr["DataGenerateFileKeywordNo"]),
                              new XAttribute("name", dr["DataGenerateFileKeywordName"]),
                              new XAttribute("pkgColIndex", dr["DataGenerateFileKeywordIndex"])
                             );

                UC_DataSetting.ReturnXElement = _xElement;
            }
            this.Close();
        }
    }
}
