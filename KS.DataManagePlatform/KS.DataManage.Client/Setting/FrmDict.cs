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
    public partial class FrmDict : FrmSaveBase
    {
        DataRow dr;
        DataTable dtOrigin;
        int drIndex;
        public FrmDict()
        {
            InitializeComponent();


        }
        public FrmDict(int drIndex, DataTable dt, string title)
        {
            InitializeComponent();

            this.Text = title;
            this.dr = dt.Rows[drIndex];
            this.dtOrigin = dt;
            this.drIndex = drIndex;

            kryCBBDictionaryNo.Text = dr["DataDictionaryNo"].ToString();
            kryCBBDictionaryTargetValue.Text = dr["DataDictionaryTargetValue"].ToString();
            kryCBBDictionarySourceValue.Text = dr["DataDictionarySourceValue"].ToString();
           
        }
        private void kbtnCancle_Click(object sender, EventArgs e)
        {
            UC_DataSetting.ReturnDt = dtOrigin;
            this.Close();
        }

        private void kbtnSave_Click(object sender, EventArgs e)
        {
            DataTable dt = dtOrigin.Copy();

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
            this.Close();
        }
    }
}
