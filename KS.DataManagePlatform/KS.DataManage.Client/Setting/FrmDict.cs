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
    public partial class FrmDict : FrmSaveBase
    {
        DataRow drOrigin;
        DataTable dtOrigin;
        int drIndex;
        public FrmDict()
        {
            InitializeComponent();


        }
        public FrmDict(int drIndex, DataTable dt, string title)
        {
            InitializeComponent();
            if (title == "数据字典修改")
            {
                kryCBBDictionaryNo.Enabled = false;
            }

            this.Text = title;
            this.drOrigin = dt.Rows[drIndex];
            this.dtOrigin = dt;
            this.drIndex = drIndex;

            kryCBBDictionaryNo.Text = drOrigin["DataDictionaryNo"].ToString();
            kryCBBDictionaryTargetValue.Text = drOrigin["DataDictionaryTargetValue"].ToString();
            kryCBBDictionarySourceValue.Text = drOrigin["DataDictionarySourceValue"].ToString();
           
        }
        //private void kbtnCancle_Click(object sender, EventArgs e)
        //{
        //    UC_DataSetting.ReturnDt = dtOrigin;
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
                dt.Columns.Add("DataDictionaryNo", typeof(System.String));
                dt.Columns.Add("DataDictionarySourceValue", typeof(System.String));
                dt.Columns.Add("DataDictionaryTargetValue", typeof(System.String));
            }
            else
            {
                dt = dtOrigin.Copy();
            }
            //DataTable dt = dtOrigin.Copy();
            DataRow dr = dt.NewRow();
            dr["DataDictionaryNo"]  = kryCBBDictionaryNo.Text; 
            dr["DataDictionaryTargetValue"] = kryCBBDictionaryTargetValue.Text; 
            dr["DataDictionarySourceValue"] = kryCBBDictionarySourceValue.Text; 
         

            if (this.Text == "数据字典修改")
            {
                dt.Rows.RemoveAt(this.drIndex);
            }
            dt.Rows.InsertAt(dr, this.drIndex);

            UC_DataSetting.ReturnDt = dt;

            //if (this.Text == "数据字典增加")
            //{
            //    XElement _xElement = new XElement("dict");
            //    _xElement.Add(new XAttribute("dictid", dr["DataDictionaryNo"]),
            //                  new XAttribute("src", dr["DataDictionarySourceValue"]), 
            //                  new XAttribute("tag", dr["DataDictionaryTargetValue"])
            //                 );

            //    UC_DataSetting.ReturnXElement = _xElement;
            //    //UC_DataSetting.ReturnOrganCode = dr["DataTargetOrganizationName"].ToString();
            //}

            if (this.Text == "数据字典修改")
            {
                foreach (XElement itemfile in GlobalData.TemplateConfigInfo.Descendants("file"))
                {
                    //foreach (XElement item in itemOrganCode.Nodes())
                    //{
                    if (itemfile.Attribute("filetitle").Value == UC_DataSetting.SelectedTargetFileTitle)
                    {
                        foreach (XElement itemfileSrc in itemfile.Descendants("fileSrc"))
                        {
                            if (itemfileSrc.Attribute("srcfile").Value == UC_DataSetting.SelectedSourceFileName && itemfileSrc.Attribute("srcid").Value == UC_DataSetting.SelectedSourceFileNo)
                            {
                                foreach (XElement itemfilecols in itemfileSrc.Nodes())
                                {
                                    if (itemfilecols.Attribute("cid").Value == UC_DataSetting.SelectedFileFieldNo && itemfilecols.Attribute("label").Value == UC_DataSetting.SelectedTXTColumnName)
                                    {
                                        foreach (XElement itemdict in itemfilecols.Descendants("dict"))
                                        {
                                            if (itemdict.Attribute("dictid").Value == drOrigin["DataDictionaryNo"].ToString())
                                            {
                                                itemdict.Attribute("dictid").Value = dr["DataDictionaryNo"].ToString();
                                                itemdict.Attribute("src").Value = dr["DataDictionarySourceValue"].ToString();
                                                itemdict.Attribute("tag").Value = dr["DataDictionaryTargetValue"].ToString();
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
            else
            {
                XElement _xElement = new XElement("dict");
                _xElement.Add(new XAttribute("dictid", dr["DataDictionaryNo"]),
                              new XAttribute("src", dr["DataDictionarySourceValue"]),
                              new XAttribute("tag", dr["DataDictionaryTargetValue"])
                             );

                UC_DataSetting.ReturnXElement = _xElement;
            }
            this.Close();
        }
    }
}
