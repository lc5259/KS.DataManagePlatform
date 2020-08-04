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
    public delegate void setTextValue(string textValue);
    public partial class FrmTradeAccountSet : FrmSaveBase
    {

        public bool IsSave = false;
        public event setTextValue setFormTextValue;
        public FrmTradeAccountSet()
        {
            InitializeComponent();
        }
        public FrmTradeAccountSet(bool _IsSave,string FundAccountNo, XElement TemplateConfigInfo)
        {
            InitializeComponent();
            this.IsSave = _IsSave;
            this.kryTextBoxFundAccountNo.Text = FundAccountNo;
            kryCheckBoxCffex.Checked = (TemplateConfigInfo.Attribute("cffexFile").Value.Equals("1")) ? (true) : (false);
            kryCheckBoxMotorCenter.Checked = (TemplateConfigInfo.Attribute("cfmmcFile").Value.Equals("1")) ? (true) : (false);
            switch (TemplateConfigInfo.Attribute("cffexext").Value)
            {
                case "0":
                    krypCBCffexTxt.Checked = false;
                    krypCBCffexDBF.Checked = false;
                    break;
                case "1":
                    krypCBCffexTxt.Checked = true;
                    krypCBCffexDBF.Checked = false;
                    break;
                case "2":
                    krypCBCffexTxt.Checked = false;
                    krypCBCffexDBF.Checked = true;
                    break;
                case "3":
                    krypCBCffexTxt.Checked = true;
                    krypCBCffexDBF.Checked = true;
                    break;
            }
            krypCBMotorCenterTXT.Checked = (TemplateConfigInfo.Attribute("cfmmcext").Value.Equals("1")) ? (true) : (false);

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
            AppDatas.CffexFile = (kryCheckBoxCffex.Checked is true) ? ("1") : ("0");
            AppDatas.CfmmcFile = (kryCheckBoxMotorCenter.Checked is true) ? ("1") : ("0");
            AppDatas.Cffexext = "0";
            AppDatas.Cffexext = (krypCBCffexTxt.Checked is true) ? ((int.Parse(AppDatas.Cffexext) + 1).ToString()) : (AppDatas.Cffexext);
            AppDatas.Cffexext = (krypCBCffexDBF.Checked is true) ? ((int.Parse(AppDatas.Cffexext) + 2).ToString()) : (AppDatas.Cffexext);
            AppDatas.Cfmmcext = "0";
            AppDatas.Cfmmcext = (krypCBMotorCenterTXT.Checked is true) ? ((int.Parse(AppDatas.Cfmmcext) + 1).ToString()) : (AppDatas.Cfmmcext);
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
