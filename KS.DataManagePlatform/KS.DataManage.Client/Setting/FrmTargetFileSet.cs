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
        DataRow drOrigin;
        DataTable dtOrigin;
        int drIndex;
        public FrmTargetFileSet()
        {
            InitializeComponent();
            UC_DataSetting.ReturnDt = null;
        }
        public FrmTargetFileSet(int drIndex, DataTable dt, string title)
        {
            InitializeComponent();
            UC_DataSetting.ReturnDt = null;
            if (title == "文件列表修改")
            {
                kryCBBTargetFileNo.Enabled = false;
            }

            this.Text = title;
            this.drOrigin = dt.Rows[drIndex];
            this.dtOrigin = dt;
            this.drIndex = drIndex;


            kryCBBTargetFileOrganizationName.Text = this.drOrigin["DataTargetOrganizationName"].ToString();
            kryCBBTargetFileTitle.Text = this.drOrigin["DataTargetFileTitle"].ToString();
            kryCBBTargetFileNo.Text = this.drOrigin["DataTargetFileNo"].ToString();
            kryCBBTargetFileName.Text = this.drOrigin["DataTargetFileName"].ToString();
            kryCBBTargetFileFormat.Text = this.drOrigin["DataTargetFileFormat"].ToString();
            kryCBBTargetFileColumnDirection.Text = this.drOrigin["DataTargetFileColumnDirection"].ToString();
            kryCBBTargetFileIsOutTitle.Text = this.drOrigin["DataTargetFileIsOutTitle"].ToString();
            kryCBBTargetFileIsOutColumnName.Text = this.drOrigin["DataTargetFileIsOutColumnName"].ToString();
            kryCBBTargetFileIsConnector.Text = this.drOrigin["DataTargetFileIsConnector"].ToString();
            kryCBBTargetFileIsIsSummary.Text = this.drOrigin["DataTargetFileIsIsSummary"].ToString();
            kryCBBTargetFileIsIsShowFundAccountNo.Text = this.drOrigin["DataTargetFileIsIsShowFundAccountNo"].ToString();
            kryCBBTargetFileIsIEachAccountOutTitle.Text = this.drOrigin["DataTargetFileIsIEachAccountOutTitle"].ToString();
            kryCBBTargetFileTXTEqueDBF.Text = this.drOrigin["DataTargetFileTXTEqueDBF"].ToString();
            // DisplayData(dr);
            //kryCBBTargetFileOrganizationName.Text = this.drOrigin.Cells["TargetFileOrganizationName"].Value.ToString();
            //kryCBBTargetFileTitle.Text = this.drOrigin.Cells["TargetFileTitle"].Value.ToString();
            //kryCBBTargetFileNo.Text = this.drOrigin.Cells["TargetFileNo"].Value.ToString();
            //kryCBBTargetFileName.Text = this.drOrigin.Cells["TargetFileName"].Value.ToString();
            //kryCBBTargetFileFormat.Text = this.drOrigin.Cells["TargetFileFormat"].Value.ToString();
            //kryCBBTargetFileColumnDirection.Text = this.drOrigin.Cells["TargetFileColumnDirection"].Value.ToString();
            //kryCBBTargetFileIsOutTitle.Text = this.drOrigin.Cells["TargetFileIsOutTitle"].Value.ToString();
            //kryCBBTargetFileIsOutColumnName.Text = this.drOrigin.Cells["TargetFileIsOutColumnName"].Value.ToString();
            //kryCBBTargetFileIsConnector.Text = this.drOrigin.Cells["TargetFileIsConnector"].Value.ToString();
            //kryCBBTargetFileIsIsSummary.Text = this.drOrigin.Cells["TargetFileIsIsSummary"].Value.ToString();
            //kryCBBTargetFileIsIsShowFundAccountNo.Text = this.drOrigin.Cells["TargetFileIsIsShowFundAccountNo"].Value.ToString();
            //kryCBBTargetFileIsIEachAccountOutTitle.Text = this.drOrigin.Cells["TargetFileIsIEachAccountOutTitle"].Value.ToString();
            //kryCBBTargetFileTXTEqueDBF.Text = this.drOrigin.Cells["TargetFileTXTEqueDBF"].Value.ToString();
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
         public  override void OnClose()
        {
            UC_DataSetting.ReturnDt = dtOrigin;
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
                              new XAttribute("IsOutPut", "是"),   //默认是
                              new XAttribute("IsDispAccId", dr["DataTargetFileIsIsShowFundAccountNo"]),
                              new XAttribute("IsOutLineTitle", dr["DataTargetFileIsIEachAccountOutTitle"]));

                UC_DataSetting.ReturnXElement = _xElement;
                //UC_DataSetting.ReturnOrganCode = dr["DataTargetOrganizationName"].ToString();
            }


            if (this.Text == "文件列表修改")
            {
                foreach (XElement itemfile in GlobalData.TemplateConfigInfo.Descendants("OrganCode"))
                {
                    if (itemfile.Attribute("name").Value == this.drOrigin["DataTargetOrganizationName"].ToString())
                    {
                        foreach (XElement item in itemfile.Nodes())
                        {
                            if (item.Attribute("filetitle").Value == this.drOrigin["DataTargetFileTitle"].ToString() && item.Attribute("fid").Value == this.drOrigin["DataTargetFileNo"].ToString())
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
            UC_DataSetting.ReturnOrganCode = dr["DataTargetOrganizationName"].ToString();
            //GlobalData.GlobaTargetFileTitle = dr["DataTargetFileTitle"].ToString();
            this.Close();
        }
    }
}
