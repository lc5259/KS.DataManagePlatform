using KS.DataManage.Templete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KS.DataManage.Client
{
    public partial class FrmTargetFileSet : FrmSaveBase
    {
        public FrmTargetFileSet()
        {
            InitializeComponent();
        }

        private void kbtnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void kbtnSave_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("DataTargetOrganizationName", typeof(System.String)); //var s = new DataColumn(); s.
            dt.Columns.Add("DataTargetFileNo", typeof(System.String));
            dt.Columns.Add("DataTargetFileTitle", typeof(System.String));
            dt.Columns.Add("DataTargetFileName", typeof(System.String));
            dt.Columns.Add("DataTargetFileFormat", typeof(System.String));
            dt.Columns.Add("DataTargetFileTXTEqueDBF", typeof(System.String));
            dt.Columns.Add("DataTargetFileColumnDirection", typeof(System.String));
            dt.Columns.Add("DataTargetFileIsOutTitle", typeof(System.String));
            dt.Columns.Add("DataTargetFileIsOutColumnName", typeof(System.String));
            dt.Columns.Add("DataTargetFileIsConnector", typeof(System.String));
            dt.Columns.Add("DataTargetFileIsIsSummary", typeof(System.String));
            dt.Columns.Add("DataTargetFileIsIsShowFundAccountNo", typeof(System.String));
            dt.Columns.Add("DataTargetFileIsIEachAccountOutTitle", typeof(System.String));

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

            dt.Rows.Add(dr);

        }
    }
}
