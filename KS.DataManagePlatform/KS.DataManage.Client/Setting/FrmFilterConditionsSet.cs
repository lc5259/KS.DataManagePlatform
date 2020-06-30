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
    public partial class FrmFilterConditionsSet : FrmSaveBase
    {
        DataRow dr;
        DataTable dtOrigin;
        int drIndex;
        public FrmFilterConditionsSet()
        {
            InitializeComponent();


        }
        public FrmFilterConditionsSet(int drIndex, DataTable dt, string title)
        {
            InitializeComponent();

            this.Text = title;
            this.dr = dt.Rows[drIndex];
            this.dtOrigin = dt;
            this.drIndex = drIndex;

            kryCBBFilterConditionsNo.Text = dr["DataFilterConditionsNo"].ToString();
            kryCBBFilterConditionsColumnName.Text = dr["DataFilterConditionsColumnName"].ToString();
            kryCBBFilterConditionsColumnIndex.Text = dr["DataFilterConditionsColumnIndex"].ToString();
            kryCBBFilterConditionseConditionvalue.Text = dr["DataFilterConditionseConditionvalue"].ToString();
            kryCBBFilterConditionseConditionalSymbol.Text = dr["DataFilterConditionseConditionalSymbol"].ToString();
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
            this.Close();
        }
    }
}
