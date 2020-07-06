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
    public partial class FrmFilterConditionsSet : FrmSaveBase
    {
        DataRow drOrigin;
        DataTable dtOrigin;
        int drIndex;
        public FrmFilterConditionsSet()
        {
            InitializeComponent();


        }
        public FrmFilterConditionsSet(int drIndex, DataTable dt, string title)
        {
            InitializeComponent();
            if (title == "过滤条件修改")
            {
                kryCBBFilterConditionsNo.Enabled = false;
            }

            this.Text = title;
            this.drOrigin = dt.Rows[drIndex];
            this.dtOrigin = dt;
            this.drIndex = drIndex;

            kryCBBFilterConditionsNo.Text = drOrigin["DataFilterConditionsNo"].ToString();
            kryCBBFilterConditionsColumnName.Text = drOrigin["DataFilterConditionsColumnName"].ToString();
            kryCBBFilterConditionsColumnIndex.Text = drOrigin["DataFilterConditionsColumnIndex"].ToString();
            kryCBBFilterConditionseConditionvalue.Text = drOrigin["DataFilterConditionseConditionvalue"].ToString();
            kryCBBFilterConditionseConditionalSymbol.Text = drOrigin["DataFilterConditionseConditionalSymbol"].ToString();
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
                dt.Columns.Add("DataFilterConditionsNo", typeof(System.String));
                dt.Columns.Add("DataFilterConditionsColumnName", typeof(System.String));
                dt.Columns.Add("DataFilterConditionsColumnIndex", typeof(System.String));
                dt.Columns.Add("DataFilterConditionseConditionvalue", typeof(System.String));
                dt.Columns.Add("DataFilterConditionseConditionalSymbol", typeof(System.String));
            }
            else
            {
                dt = dtOrigin.Copy();
            }
            //DataTable dt = dtOrigin.Copy();
            DataRow dr = dt.NewRow();
            dr["DataFilterConditionsNo"]  = kryCBBFilterConditionsNo.Text; 
            dr["DataFilterConditionsColumnName"] = kryCBBFilterConditionsColumnName.Text; 
            dr["DataFilterConditionsColumnIndex"] = kryCBBFilterConditionsColumnIndex.Text; 
            dr["DataFilterConditionseConditionvalue"] = kryCBBFilterConditionseConditionvalue.Text; 
            dr["DataFilterConditionseConditionalSymbol"] = kryCBBFilterConditionseConditionalSymbol.Text;

            if (this.Text == "过滤条件修改")
            {
                dt.Rows.RemoveAt(this.drIndex);
            }
            dt.Rows.InsertAt(dr, this.drIndex);

            UC_DataSetting.ReturnDt = dt;

            //if (this.Text == "过滤条件增加")
            //{

            //    XElement _xElement = new XElement("filter");
            //    _xElement.Add(new XAttribute("filtId", dr["DataFilterConditionsNo"]),
            //                  new XAttribute("colname", dr["DataFilterConditionsColumnName"]),
            //                  new XAttribute("colIndex", dr["DataFilterConditionsColumnIndex"]),
            //                  new XAttribute("value", dr["DataFilterConditionseConditionvalue"]),
            //                  new XAttribute("andor", dr["DataFilterConditionseConditionalSymbol"])
            //                 );

            //    UC_DataSetting.ReturnXElement = _xElement;
            //    //UC_DataSetting.ReturnOrganCode = dr["DataTargetOrganizationName"].ToString();
            //}
            if (this.Text == "过滤条件修改")
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
                                        foreach (XElement itemfilter in itemfilecols.Descendants("filter"))
                                        {
                                            if (itemfilter.Attribute("filtId").Value == drOrigin["DataFilterConditionsNo"].ToString() && itemfilter.Attribute("colname").Value == drOrigin["DataFilterConditionsColumnName"].ToString())
                                            {
                                                itemfilter.Attribute("filtId").Value = dr["DataFilterConditionsNo"].ToString();
                                                itemfilter.Attribute("colname").Value = dr["DataFilterConditionsColumnName"].ToString();
                                                itemfilter.Attribute("colIndex").Value = dr["DataFilterConditionsColumnIndex"].ToString();
                                                itemfilter.Attribute("value").Value = dr["DataFilterConditionseConditionvalue"].ToString();
                                                itemfilter.Attribute("andor").Value = dr["DataFilterConditionseConditionalSymbol"].ToString();
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
                XElement _xElement = new XElement("filter");
                _xElement.Add(new XAttribute("filtId", dr["DataFilterConditionsNo"]),
                              new XAttribute("colname", dr["DataFilterConditionsColumnName"]),
                              new XAttribute("colIndex", dr["DataFilterConditionsColumnIndex"]),
                              new XAttribute("value", dr["DataFilterConditionseConditionvalue"]),
                              new XAttribute("andor", dr["DataFilterConditionseConditionalSymbol"])
                             );

                UC_DataSetting.ReturnXElement = _xElement;
            }
            this.Close();
        }
    }
}
