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
    public partial class FrmSourceFileSet : FrmSaveBase
    {
        DataRow dr;
        DataTable dtOrigin;
        int drIndex;
        public FrmSourceFileSet()
        {
            InitializeComponent();
        }
        public FrmSourceFileSet(int drIndex, DataTable dt, string title)
        {
            InitializeComponent();

            this.Text = title;
            this.dr = dt.Rows[drIndex];
            this.dtOrigin = dt;
            this.drIndex = drIndex;

            kryCBBSourceFileNo.Text = this.dr["DataSourceFileNo"].ToString();
            kryCBBSourceFileName.Text = this.dr["DataSourceFileName"].ToString();
            kryCBBSourceFileNameFunfAccountNoIndex.Text = this.dr["DataSourceFileFunfAccountNoIndex"].ToString();
            kryCBBSourceFileFrom.Text = this.dr["DataSourceFileFrom"].ToString();
            kryCBBSourceFileSeparator.Text = this.dr["DataSourceFileSeparator"].ToString();
            kryCBBSourceFileMergeType.Text = this.dr["DataSourceFileMergeType"].ToString();

        }
        private void kbtnCancle_Click(object sender, EventArgs e)
        {
            UC_DataSetting.ReturnDt = dtOrigin;
           // System.Threading.Thread.Sleep(200);
            this.Close();
        }

        private void kbtnSave_Click(object sender, EventArgs e)
        {
            DataTable dt = dtOrigin.Copy();
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
            this.Close();
        }
    }
}
