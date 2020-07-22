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

namespace KS.DataManage.Client
{
    public delegate void setTextValue(string textValue);
    public partial class FrmTradeAccountSet : FrmSaveBase
    {

        public bool IsSave = false;
        public event setTextValue setFormTextValue;
        public FrmTradeAccountSet()
        {
            InitializeComponent();
        }
        public FrmTradeAccountSet(bool _IsSave,string FundAccountNo)
        {
            InitializeComponent();
            this.IsSave = _IsSave;
            this.kryTextBoxFundAccountNo.Text = FundAccountNo;
        }
        
        private void kbtnSave_Click(object sender, EventArgs e)
        {
            //List<string> CombTradeID = new List<string>();
            //UC_DataSetting _uC_DataSetting = new UC_DataSetting();
            //CombTradeID = _uC_DataSetting.kCombTradeID.DataSource as List<string>;
            //CombTradeID.Add(kryTextBoxFundAccountNo.Text.ToString());
            //_uC_DataSetting.kCombTradeID.DataSource = CombTradeID;

            //IsSave = true;

            //setFormTextValue(kryTextBoxFundAccountNo.Text.ToString());



            //UC_GeneFile _uC_GeneFile = (UC_GeneFile)this.Owner;
            //UC_GeneFile.AddFunfList(kryCheckBoxCffex.Checked, kryCheckBoxMotorCenter.Checked, GlobalData.AddFundAccountNO);
            if (string.IsNullOrEmpty(kryTextBoxFundAccountNo.Text.ToString().Trim()))
            {
                MessageBox.Show("资金账号不能为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.IsSave = true;
            this.Close();

        }

        private void kbtnCancle_Click(object sender, EventArgs e)
        {
            this.IsSave = false;
            this.Close();
        }
    }
}
