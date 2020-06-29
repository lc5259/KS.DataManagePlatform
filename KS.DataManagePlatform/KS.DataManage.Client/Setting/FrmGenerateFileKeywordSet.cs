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
    public partial class FrmGenerateFileKeywordSet : FrmSaveBase
    {
        DataRow dr;
        DataTable dtOrigin;
        int drIndex;
        public FrmGenerateFileKeywordSet()
        {
            InitializeComponent();
        }
        public FrmGenerateFileKeywordSet(int drIndex, DataTable dt, string title)
        {
            InitializeComponent();

            this.Text = title;
            this.dr = dt.Rows[drIndex];
            this.dtOrigin = dt;
            this.drIndex = drIndex;

            kryCBBGenerateFileKeywordNo.Text = this.dr["DataGenerateFileKeywordNo"].ToString();
            kryCBBGenerateFileKeywordName.Text = this.dr["DataGenerateFileKeywordName"].ToString();
            kryCBBGenerateFileKeywordIndex.Text = this.dr["DataGenerateFileKeywordIndex"].ToString();

        }
        private void kbtnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void kbtnSave_Click(object sender, EventArgs e)
        {
            DataTable dt = dtOrigin.Copy();
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
            this.Close();
        }
    }
}
