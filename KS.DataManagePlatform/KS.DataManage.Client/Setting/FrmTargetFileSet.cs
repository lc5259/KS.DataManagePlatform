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
    public partial class FrmTargetFileSet : FrmSaveBase
    {
        DataRow dr;
        DataTable dtOrigin;
        int drIndex;
        public FrmTargetFileSet()
        {
            InitializeComponent();
        }
        public FrmTargetFileSet(int drIndex, DataTable dt, string title)
        {
            InitializeComponent();

            this.Text = title;
            this.dr = dt.Rows[drIndex];
            this.dtOrigin = dt;
            this.drIndex = drIndex;


            kryCBBTargetFileOrganizationName.Text = this.dr["DataTargetOrganizationName"].ToString();
            kryCBBTargetFileTitle.Text = this.dr["DataTargetFileTitle"].ToString();
            kryCBBTargetFileNo.Text = this.dr["DataTargetFileNo"].ToString();
            kryCBBTargetFileName.Text = this.dr["DataTargetFileName"].ToString();
            kryCBBTargetFileFormat.Text = this.dr["DataTargetFileFormat"].ToString();
            kryCBBTargetFileColumnDirection.Text = this.dr["DataTargetFileColumnDirection"].ToString();
            kryCBBTargetFileIsOutTitle.Text = this.dr["DataTargetFileIsOutTitle"].ToString();
            kryCBBTargetFileIsOutColumnName.Text = this.dr["DataTargetFileIsOutColumnName"].ToString();
            kryCBBTargetFileIsConnector.Text = this.dr["DataTargetFileIsConnector"].ToString();
            kryCBBTargetFileIsIsSummary.Text = this.dr["DataTargetFileIsIsSummary"].ToString();
            kryCBBTargetFileIsIsShowFundAccountNo.Text = this.dr["DataTargetFileIsIsShowFundAccountNo"].ToString();
            kryCBBTargetFileIsIEachAccountOutTitle.Text = this.dr["DataTargetFileIsIEachAccountOutTitle"].ToString();
            kryCBBTargetFileTXTEqueDBF.Text = this.dr["DataTargetFileTXTEqueDBF"].ToString();
            // DisplayData(dr);
            //kryCBBTargetFileOrganizationName.Text = this.dr.Cells["TargetFileOrganizationName"].Value.ToString();
            //kryCBBTargetFileTitle.Text = this.dr.Cells["TargetFileTitle"].Value.ToString();
            //kryCBBTargetFileNo.Text = this.dr.Cells["TargetFileNo"].Value.ToString();
            //kryCBBTargetFileName.Text = this.dr.Cells["TargetFileName"].Value.ToString();
            //kryCBBTargetFileFormat.Text = this.dr.Cells["TargetFileFormat"].Value.ToString();
            //kryCBBTargetFileColumnDirection.Text = this.dr.Cells["TargetFileColumnDirection"].Value.ToString();
            //kryCBBTargetFileIsOutTitle.Text = this.dr.Cells["TargetFileIsOutTitle"].Value.ToString();
            //kryCBBTargetFileIsOutColumnName.Text = this.dr.Cells["TargetFileIsOutColumnName"].Value.ToString();
            //kryCBBTargetFileIsConnector.Text = this.dr.Cells["TargetFileIsConnector"].Value.ToString();
            //kryCBBTargetFileIsIsSummary.Text = this.dr.Cells["TargetFileIsIsSummary"].Value.ToString();
            //kryCBBTargetFileIsIsShowFundAccountNo.Text = this.dr.Cells["TargetFileIsIsShowFundAccountNo"].Value.ToString();
            //kryCBBTargetFileIsIEachAccountOutTitle.Text = this.dr.Cells["TargetFileIsIEachAccountOutTitle"].Value.ToString();
            //kryCBBTargetFileTXTEqueDBF.Text = this.dr.Cells["TargetFileTXTEqueDBF"].Value.ToString();
        }

        //protected virtual void DisplayData(DataRow dr)
        //{
        //    foreach (Control  ChildControl in this.kryptonPanel1.Controls)
        //    {
        //        if (!(ChildControl is KryptonLabel))
        //        {
        //            foreach (var item in dr.Table.TableName)
        //            {
        //                if (ChildControl.Name.Contains(item))
        //                {
        //                    ChildControl.Text = dr[item.ToString()].ToString();
        //                    break;
        //                }
        //            }

        //        }
        //    } 
        //}

        private void kbtnCancle_Click(object sender, EventArgs e)
        {
            UC_DataSetting.ReturnDt = dtOrigin;
            this.Close();
        }

        private void kbtnSave_Click(object sender, EventArgs e)
        {
            DataTable dt = dtOrigin.Copy();

            // DataTable dt = new DataTable();
            //dt.Columns.Add("DataTargetOrganizationName", typeof(System.String)); //var s = new DataColumn(); s.
            //dt.Columns.Add("DataTargetFileNo", typeof(System.String));
            //dt.Columns.Add("DataTargetFileTitle", typeof(System.String));
            //dt.Columns.Add("DataTargetFileName", typeof(System.String));
            //dt.Columns.Add("DataTargetFileFormat", typeof(System.String));
            //dt.Columns.Add("DataTargetFileTXTEqueDBF", typeof(System.String));
            //dt.Columns.Add("DataTargetFileColumnDirection", typeof(System.String));
            //dt.Columns.Add("DataTargetFileIsOutTitle", typeof(System.String));
            //dt.Columns.Add("DataTargetFileIsOutColumnName", typeof(System.String));
            //dt.Columns.Add("DataTargetFileIsConnector", typeof(System.String));
            //dt.Columns.Add("DataTargetFileIsIsSummary", typeof(System.String));
            //dt.Columns.Add("DataTargetFileIsIsShowFundAccountNo", typeof(System.String));
            //dt.Columns.Add("DataTargetFileIsIEachAccountOutTitle", typeof(System.String));

            DataRow dr = dt.NewRow();
            dr["DataTargetOrganizationName"] = kryCBBTargetFileOrganizationName.Text.ToString();
            dr["DataTargetFileNo"] = kryCBBTargetFileNo.Text.ToString();
            dr["DataTargetFileTitle"] = kryCBBTargetFileTitle.Text.ToString();
            dr["DataTargetFileName"] = kryCBBTargetFileName.Text.ToString();
            dr["DataTargetFileFormat"] = kryCBBTargetFileFormat.Text.ToString();
            dr["DataTargetFileTXTEqueDBF"] = kryCBBTargetFileTXTEqueDBF.Text.ToString();
            dr["DataTargetFileColumnDirection"] = kryCBBTargetFileColumnDirection.Text.ToString();
            dr["DataTargetFileIsOutTitle"] = kryCBBTargetFileIsOutTitle.Text.ToString();
            dr["DataTargetFileIsOutColumnName"] = kryCBBTargetFileIsOutColumnName.Text.ToString();
            dr["DataTargetFileIsConnector"] = kryCBBTargetFileIsConnector.Text.ToString();
            dr["DataTargetFileIsIsSummary"] = kryCBBTargetFileIsIsSummary.Text.ToString();
            dr["DataTargetFileIsIsShowFundAccountNo"] = kryCBBTargetFileIsIsShowFundAccountNo.Text.ToString();
            dr["DataTargetFileIsIEachAccountOutTitle"] = kryCBBTargetFileIsIEachAccountOutTitle.Text.ToString();

            if (this.Text == "文件列表修改")
            {
                dt.Rows.RemoveAt(this.drIndex);

            }
            dt.Rows.InsertAt(dr, this.drIndex);

            UC_DataSetting.ReturnDt = dt;

            if (this.Text == "文件列表增加")
            {

                XElement _xElement = new XElement("file");
                _xElement.Add(new XAttribute("fid", dr["DataTargetFileNo"]),
                              new XAttribute("filetitle", dr["DataTargetFileTitle"]),
                              new XAttribute("filename", dr["DataTargetFileName"]),
                              new XAttribute("fileext", dr["DataTargetFileFormat"]),
                              new XAttribute("isallsame", dr["DataTargetFileTXTEqueDBF"]),
                              new XAttribute("arrangeType", dr["DataTargetFileColumnDirection"]),
                              new XAttribute("IsOutTitle", dr["DataTargetFileIsOutTitle"]),
                              new XAttribute("IsOutColName", dr["DataTargetFileIsOutColumnName"]),
                              new XAttribute("splitc", dr["DataTargetFileIsConnector"]),
                              new XAttribute("IsSum", dr["DataTargetFileIsIsSummary"]),
                              new XAttribute("IsOutPut", "不确定"),
                              new XAttribute("IsDispAccId", dr["DataTargetFileIsIsShowFundAccountNo"]),
                              new XAttribute("IsOutLineTitle", dr["DataTargetFileIsIEachAccountOutTitle"]));

                UC_DataSetting.ReturnXElement = _xElement;
                UC_DataSetting.ReturnOrganCode = dr["DataTargetOrganizationName"].ToString();
            }


            if (this.Text == "文件列表修改")
            {
                foreach (XElement itemfile in GlobalData.TemplateConfigInfo.Descendants("OrganCode"))
                {
                    if (itemfile.Attribute("name").Value == dr["DataTargetOrganizationName"].ToString())
                    {
                        foreach (XElement item in itemfile.Nodes())
                        {
                            if (item.Attribute("filetitle").Value == dr["DataTargetFileTitle"].ToString())
                            {
                                item.Attribute("fid").Value = dr["DataTargetFileNo"].ToString();
                                item.Attribute("filetitle").Value = dr["DataTargetFileTitle"].ToString();
                                item.Attribute("filename").Value = dr["DataTargetFileName"].ToString();
                                item.Attribute("fileext").Value = dr["DataTargetFileFormat"].ToString();
                                item.Attribute("isallsame").Value = dr["DataTargetFileTXTEqueDBF"].ToString();
                                item.Attribute("arrangeType").Value = dr["DataTargetFileColumnDirection"].ToString();
                                item.Attribute("IsOutTitle").Value = dr["DataTargetFileIsOutTitle"].ToString();
                                item.Attribute("IsOutColName").Value = dr["DataTargetFileIsOutColumnName"].ToString();
                                item.Attribute("splitc").Value = dr["DataTargetFileIsConnector"].ToString();
                                item.Attribute("IsSum").Value = dr["DataTargetFileIsIsSummary"].ToString();
                                item.Attribute("IsOutPut").Value = "不确定";
                                item.Attribute("IsDispAccId").Value = dr["DataTargetFileIsIsShowFundAccountNo"].ToString();
                                if (item.LastAttribute.Name == "IsOutLineTitle")
                                {
                                    item.Attribute("IsOutLineTitle").Value = dr["DataTargetFileIsIEachAccountOutTitle"].ToString();
                                }


                                break;
                                //item.ReplaceNodes(_xElement);
                                break;
                            }
                        }
                    }
                }
            }
            this.Close();
        }
    }
}
