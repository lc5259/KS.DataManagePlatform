using ComponentFactory.Krypton.Toolkit;
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
    public partial class FrmFileWordsList : FrmSaveBase
    {
        DataRow dr;
        DataTable dtOrigin;
        int drIndex;
        public FrmFileWordsList()
        {
            InitializeComponent();
        }
        public FrmFileWordsList(int drIndex, DataTable dt,string title)
        {
            InitializeComponent();

            this.Text = title;
            this.dr = dt.Rows[drIndex] ;
            this.dtOrigin = dt;
            this.drIndex = drIndex;

            kryCBBFileFieldNo.Text = dr["DataFileFieldNo"].ToString();
            kryCBBFileFieldTXTColumnName.Text = dr["DataFileFieldTXTColumnName"].ToString();
            kryCBBFileFieldDBFColumnName.Text = dr["DataFileFieldDBFColumnName"].ToString();
            kryCBBFileFieldColumnNameDigit.Text = dr["DataFileFieldColumnNameDigit"].ToString();
            kryCBBFileFieldColumnValueDigit.Text = dr["DataFileFieldColumnValueDigit"].ToString();
            kryCBBFileFieldColumnValueAccuracy.Text = dr["DataFileFieldColumnValueAccuracy"].ToString();
            kryCBBFileFieldAlignment.Text = dr["DataFileFieldAlignment"].ToString();
            kryCBBFileFieldIsOut.Text = dr["DataFileFieldIsOut"].ToString();
            kryCBBFileFieldNotNull.Text = dr["DataFileFieldNotNull"].ToString();
            kryCBBFileFieldCalculationSymbols.Text = dr["DataFileFieldCalculationSymbols"].ToString();
            kryCBBFileFieldFixedValue.Text = dr["DataFileFieldFixedValue"].ToString();
            kryCBBFileFieldIsSummary.Text = dr["DataFileFieldIsSummary"].ToString();
            kryCBBFileFieldIsComplementCharacter.Text = dr["DataFileFieldIsComplementCharacter"].ToString();
            kryCBBFileFieldIsFiledIndex.Text = dr["DataFileFieldIsFiledIndex"].ToString();
            kryCBBFileFieldIsDefaultValue.Text = dr["DataFileFieldIsDefaultValue"].ToString();
            kryCBBFileFieldIsAbsoluteValue.Text = dr["DataFileFieldIsAbsoluteValue"].ToString();
            kryCBBFileFieldIsAbsoluteValueOut.Text = dr["DataFileFieldIsAbsoluteValueOut"].ToString();

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
            this.Close();
        }

      
    }
}
