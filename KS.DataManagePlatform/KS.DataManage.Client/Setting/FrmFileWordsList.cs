using ComponentFactory.Krypton.Toolkit;
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
    public partial class FrmFileWordsList : FrmSaveBase
    {
        DataRow drOrigin;
        DataTable dtOrigin;
        int drIndex;
        public FrmFileWordsList()
        {
            InitializeComponent();
            UC_DataSetting.ReturnDt = null;
        }
        public FrmFileWordsList(int drIndex, DataTable dt,string title)
        {
            InitializeComponent();
            UC_DataSetting.ReturnDt = null;
            if (title == "文件字段列表修改")
            {
                kryCBBFileFieldNo.Enabled = false;
            }
           

            this.Text = title;
            this.drOrigin = dt.Rows[drIndex] ;
            this.dtOrigin = dt;
            this.drIndex = drIndex;

            kryCBBFileFieldNo.Text = this.drOrigin["DataFileFieldNo"].ToString();
            kryCBBFileFieldTXTColumnName.Text = this.drOrigin["DataFileFieldTXTColumnName"].ToString();
            kryCBBFileFieldDBFColumnName.Text = this.drOrigin["DataFileFieldDBFColumnName"].ToString();
            kryCBBFileFieldColumnNameDigit.Text = this.drOrigin["DataFileFieldColumnNameDigit"].ToString();
            kryCBBFileFieldColumnValueDigit.Text = this.drOrigin["DataFileFieldColumnValueDigit"].ToString();
            kryCBBFileFieldColumnValueAccuracy.Text = this.drOrigin["DataFileFieldColumnValueAccuracy"].ToString();
            kryCBBFileFieldAlignment.Text = this.drOrigin["DataFileFieldAlignment"].ToString();
            kryCBBFileFieldIsOut.Text = this.drOrigin["DataFileFieldIsOut"].ToString();
            kryCBBFileFieldNotNull.Text = this.drOrigin["DataFileFieldNotNull"].ToString();
            kryCBBFileFieldCalculationSymbols.Text = this.drOrigin["DataFileFieldCalculationSymbols"].ToString();
            kryCBBFileFieldFixedValue.Text = this.drOrigin["DataFileFieldFixedValue"].ToString();
            kryCBBFileFieldIsSummary.Text = this.drOrigin["DataFileFieldIsSummary"].ToString();
            kryCBBFileFieldIsComplementCharacter.Text = this.drOrigin["DataFileFieldIsComplementCharacter"].ToString();
            kryCBBFileFieldIsFiledIndex.Text = this.drOrigin["DataFileFieldIsFiledIndex"].ToString();
            kryCBBFileFieldIsDefaultValue.Text = this.drOrigin["DataFileFieldIsDefaultValue"].ToString();
            kryCBBFileFieldIsAbsoluteValue.Text = this.drOrigin["DataFileFieldIsAbsoluteValue"].ToString();
            kryCBBFileFieldIsAbsoluteValueOut.Text = this.drOrigin["DataFileFieldIsAbsoluteValueOut"].ToString();

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
                dt.Columns.Add("DataFileFieldNo", typeof(System.String));
                dt.Columns.Add("DataFileFieldTXTColumnName", typeof(System.String));
                dt.Columns.Add("DataFileFieldDBFColumnName", typeof(System.String));
                dt.Columns.Add("DataFileFieldColumnNameDigit", typeof(System.String));
                dt.Columns.Add("DataFileFieldColumnValueDigit", typeof(System.String));
                dt.Columns.Add("DataFileFieldColumnValueAccuracy", typeof(System.String));
                dt.Columns.Add("DataFileFieldAlignment", typeof(System.String));
                dt.Columns.Add("DataFileFieldIsOut", typeof(System.String));
                dt.Columns.Add("DataFileFieldNotNull", typeof(System.String));
                dt.Columns.Add("DataFileFieldCalculationSymbols", typeof(System.String));
                dt.Columns.Add("DataFileFieldFixedValue", typeof(System.String));
                dt.Columns.Add("DataFileFieldIsSummary", typeof(System.String));
                dt.Columns.Add("DataFileFieldIsComplementCharacter", typeof(System.String));
                dt.Columns.Add("DataFileFieldIsFiledIndex", typeof(System.String));
                dt.Columns.Add("DataFileFieldIsDefaultValue", typeof(System.String));
                dt.Columns.Add("DataFileFieldIsAbsoluteValue", typeof(System.String));
                dt.Columns.Add("DataFileFieldIsAbsoluteValueOut", typeof(System.String));
            }
            else
            {
                dt = dtOrigin.Copy();
            }
            //DataTable dt = dtOrigin.Copy();

            DataRow dr = dt.NewRow();
            dr["DataFileFieldNo"] = kryCBBFileFieldNo.Text;
            dr["DataFileFieldTXTColumnName"] = kryCBBFileFieldTXTColumnName.Text;
            dr["DataFileFieldDBFColumnName"] = kryCBBFileFieldDBFColumnName.Text;
            dr["DataFileFieldColumnNameDigit"] = kryCBBFileFieldColumnNameDigit.Text;
            dr["DataFileFieldColumnValueDigit"] = kryCBBFileFieldColumnValueDigit.Text;
            dr["DataFileFieldColumnValueAccuracy"] = kryCBBFileFieldColumnValueAccuracy.Text;
            dr["DataFileFieldAlignment"] = kryCBBFileFieldAlignment.Text;
            dr["DataFileFieldIsOut"] = kryCBBFileFieldIsOut.Text;
            dr["DataFileFieldNotNull"] = kryCBBFileFieldNotNull.Text;
            dr["DataFileFieldCalculationSymbols"] = kryCBBFileFieldCalculationSymbols.Text;
            dr["DataFileFieldFixedValue"] = kryCBBFileFieldFixedValue.Text;
            dr["DataFileFieldIsSummary"] = kryCBBFileFieldIsSummary.Text;
            dr["DataFileFieldIsComplementCharacter"] = kryCBBFileFieldIsComplementCharacter.Text;
            dr["DataFileFieldIsFiledIndex"] = kryCBBFileFieldIsFiledIndex.Text;
            dr["DataFileFieldIsDefaultValue"] = kryCBBFileFieldIsDefaultValue.Text;
            dr["DataFileFieldIsAbsoluteValue"] = kryCBBFileFieldIsAbsoluteValue.Text;
            dr["DataFileFieldIsAbsoluteValueOut"] = kryCBBFileFieldIsAbsoluteValueOut.Text;

            if (this.Text == "文件字段列表修改")
            {
                dt.Rows.RemoveAt(this.drIndex);
            }
            dt.Rows.InsertAt(dr, this.drIndex);

            UC_DataSetting.ReturnDt = dt;
            //if (this.Text == "文件字段列表增加")
            //{

            //    XElement _xElement = new XElement("filecols");
            //    _xElement.Add(new XAttribute("cid", dr["DataFileFieldNo"]),
            //                  new XAttribute("label", dr["DataFileFieldTXTColumnName"]),
            //                  new XAttribute("code", dr["DataFileFieldDBFColumnName"]),
            //                  new XAttribute("tlength", dr["DataFileFieldColumnNameDigit"]),
            //                  new XAttribute("vlength", dr["DataFileFieldColumnValueDigit"]),
            //                  new XAttribute("align", dr["DataFileFieldAlignment"]),
            //                  new XAttribute("precision", dr["DataFileFieldColumnValueAccuracy"]),
            //                  new XAttribute("isout", dr["DataFileFieldIsOut"]),
            //                  new XAttribute("notnull", dr["DataFileFieldNotNull"]),
            //                  new XAttribute("IsCal", "不确定"),
            //                  new XAttribute("express", dr["DataFileFieldCalculationSymbols"]),
            //                  new XAttribute("FixValue", dr["DataFileFieldFixedValue"]), 
            //                  new XAttribute("IsSum", dr["DataFileFieldIsSummary"]),
            //                  new XAttribute("padstr", dr["DataFileFieldIsComplementCharacter"]),
            //                  new XAttribute("colIndex", dr["DataFileFieldIsFiledIndex"]), 
            //                  new XAttribute("default", dr["DataFileFieldIsDefaultValue"]),
            //                  new XAttribute("isAbs", dr["DataFileFieldIsAbsoluteValue"]),
            //                  new XAttribute("isAbs_output", dr["DataFileFieldIsAbsoluteValueOut"])
            //                 );

            //    UC_DataSetting.ReturnXElement = _xElement;
            //    //UC_DataSetting.ReturnOrganCode = dr["DataTargetOrganizationName"].ToString();
            //}

            if (this.Text == "文件字段列表修改")
            {
                foreach (XElement itemfile in GlobalData.TemplateConfigInfo.Descendants("file"))
                {
                    //foreach (XElement item in itemOrganCode.Nodes())
                    //{
                    if (itemfile.Attribute("filetitle").Value == UC_DataSetting.SelectedTargetFileTitle)
                    {
                        foreach (XElement itemfileSrc in itemfile.Descendants("fileSrc"))
                        {
                            if (itemfileSrc.Attribute("srcfile").Value == UC_DataSetting.SelectedSourceFileName)
                            {
                                foreach (XElement itemfilecols in itemfileSrc.Nodes())
                                {
                                    if (itemfilecols.Attribute("cid").Value == this.drOrigin["DataFileFieldNo"].ToString())
                                    {
                                        itemfilecols.Attribute("cid").Value = dr["DataFileFieldNo"].ToString();
                                        itemfilecols.Attribute("label").Value = dr["DataFileFieldTXTColumnName"].ToString();
                                        itemfilecols.Attribute("code").Value = dr["DataFileFieldDBFColumnName"].ToString();
                                        itemfilecols.Attribute("tlength").Value = dr["DataFileFieldColumnNameDigit"].ToString();
                                        itemfilecols.Attribute("vlength").Value = dr["DataFileFieldColumnValueDigit"].ToString();
                                        itemfilecols.Attribute("align").Value = dr["DataFileFieldAlignment"].ToString();
                                        itemfilecols.Attribute("precision").Value = dr["DataFileFieldColumnValueAccuracy"].ToString();
                                        itemfilecols.Attribute("isout").Value = dr["DataFileFieldIsOut"].ToString();
                                        itemfilecols.Attribute("notnull").Value = dr["DataFileFieldNotNull"].ToString();
                                        itemfilecols.Attribute("IsCal").Value = itemfilecols.Attribute("IsCal").Value;
                                        itemfilecols.Attribute("express").Value = dr["DataFileFieldCalculationSymbols"].ToString();
                                        itemfilecols.Attribute("FixValue").Value = dr["DataFileFieldFixedValue"].ToString();
                                        itemfilecols.Attribute("IsSum").Value = dr["DataFileFieldIsSummary"].ToString();
                                        itemfilecols.Attribute("padstr").Value = dr["DataFileFieldIsComplementCharacter"].ToString();
                                        itemfilecols.Attribute("colIndex").Value = dr["DataFileFieldIsFiledIndex"].ToString();
                                        itemfilecols.Attribute("default").Value = dr["DataFileFieldIsDefaultValue"].ToString();
                                        itemfilecols.Attribute("isAbs").Value = dr["DataFileFieldIsAbsoluteValue"].ToString();
                                        if (itemfilecols.Attribute("isAbs_output") != null)
                                        {
                                            itemfilecols.Attribute("isAbs_output").Value = dr["DataFileFieldIsAbsoluteValueOut"].ToString();
                                        }


                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                XElement _xElement = new XElement("filecols");
                _xElement.Add(new XAttribute("cid", dr["DataFileFieldNo"]),
                              new XAttribute("label", dr["DataFileFieldTXTColumnName"]),
                              new XAttribute("code", dr["DataFileFieldDBFColumnName"]),
                              new XAttribute("tlength", dr["DataFileFieldColumnNameDigit"]),
                              new XAttribute("vlength", dr["DataFileFieldColumnValueDigit"]),
                              new XAttribute("align", dr["DataFileFieldAlignment"]),
                              new XAttribute("precision", dr["DataFileFieldColumnValueAccuracy"]),
                              new XAttribute("isout", dr["DataFileFieldIsOut"]),
                              new XAttribute("notnull", dr["DataFileFieldNotNull"]),
                              new XAttribute("IsCal", "不确定"),
                              new XAttribute("express", dr["DataFileFieldCalculationSymbols"]),
                              new XAttribute("FixValue", dr["DataFileFieldFixedValue"]),
                              new XAttribute("IsSum", dr["DataFileFieldIsSummary"]),
                              new XAttribute("padstr", dr["DataFileFieldIsComplementCharacter"]),
                              new XAttribute("colIndex", dr["DataFileFieldIsFiledIndex"]),
                              new XAttribute("default", dr["DataFileFieldIsDefaultValue"]),
                              new XAttribute("isAbs", dr["DataFileFieldIsAbsoluteValue"]),
                              new XAttribute("isAbs_output", dr["DataFileFieldIsAbsoluteValueOut"])
                             );

                UC_DataSetting.ReturnXElement = _xElement;
            }
            this.Close();
        }

      
    }
}
