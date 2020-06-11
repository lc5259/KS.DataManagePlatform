using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ComponentFactory.Krypton.Toolkit;

namespace KS.DataManage.Client
{
    public partial class UC_CstmrInfoMgt : UserControl
    {

        DataTable dt = new DataTable("Table_Account");
        DataTable dtCode = new DataTable("Table_TCode");

        /// <summary>
        /// 客户资料管理
        /// </summary>
        public UC_CstmrInfoMgt()
        {
            InitializeComponent();

            this.SuspendLayout();

            //用户表 构造
            dt.Columns.Add("资金账号", typeof(int));
            dt.Columns.Add("账号市场", typeof(string));
            dt.Columns.Add("昨结准备金", typeof(double));
            dt.Columns.Add("今日入金", typeof(double));
            dt.Columns.Add("今日出金", typeof(double));

            //资金表构造
            dtCode.Columns.Add("交易编码", typeof(int));
            dtCode.Columns.Add("交易所编号", typeof(string));
            dtCode.Columns.Add("投保标志", typeof(string));
            
        }

        #region 自带事件
        private void UC_CstmrInfoMgt_Load(object sender, EventArgs e)
        {

        }

        private void kbtnInsert_Click(object sender, EventArgs e)
        {
        }

        private void kbtnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void kbtnCopy_Click(object sender, EventArgs e)
        {

        }

        private void kbtnDelete_Click(object sender, EventArgs e)
        {

        }

        private void ItmAddTCode_Click(object sender, EventArgs e)
        {
        }

        private void ItmDelTCode_Click(object sender, EventArgs e)
        {

        }

        private void kDGVTradeCode_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void kbtnSearch_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region 自定函数
        

        ////将用户转为DataTable
        //public void GridViewShowData(List<Account> listAccount)
        //{
        //    //this.kDGV.DataSource = null;

        //    this.dt.Clear();

        //    //List<Usr> listUserTmp = GetAllUser();
        //    foreach (var item in listAccount)
        //    {
        //        dt.Rows.Add(item.Account_id,
        //            item.Account_market_type,
        //            item.Available_capital,
        //            item.Deposit_today,
        //            item.Withdraw_today);
        //    }
        //    this.kDGVAcc.DataSource = dt;
        //}

        ////将TradeCode转为DataTable
        //public void GridViewShowData(List<TradeCode> listTCode)
        //{
        //    ////this.kDGV.DataSource = null;

        //    //this.dtCode.Clear();

        //    ////List<Usr> listUserTmp = GetAllUser();
        //    //foreach (var item in listTCode)
        //    //{
        //    //    dtCode.Rows.Add(item.Trade_code_id,
        //    //        item.Exchange_no,
        //    //        item.Hedge_flag);
        //    //}
        //    //this.kDGVTradeCode.DataSource = dtCode;

        //    foreach (var item in listTCode)
        //    {
        //        this.kDGVTradeCode.Rows.Add(new object[]{item.Trade_code_id,
        //            item.Exchange_no,
        //            item.Hedge_flag});
        //    }
        //}

        //private List<Account> GetAllAccount()
        //{
        //    List<Account> list = new List<Account>();
        //    try
        //    {
        //        var service = new AccountService();
        //        list = service.GetALLAccountByUserID(1);
        //    }
        //    catch (Exception ex)
        //    {
        //        KS.Zero.Utils.Log.Error(ex.Message);
        //        throw;
        //    }
        //    return list;
        //}

        //private List<TradeCode> GetTCodeByAccountID(int accountID)
        //{
        //    List<TradeCode> list = new List<TradeCode>();
        //    try
        //    {
        //        var service = new TradeCodeService();
        //        list = service.GetTradeCodeByAccount(1);
        //    }
        //    catch (Exception ex)
        //    {
        //        KS.Zero.Utils.Log.Error(ex.Message);
        //        throw;
        //    }
        //    return list;
        //}

        //private List<AccountTCode> GetAllAccountTCode()
        //{
        //    List<AccountTCode> list = new List<AccountTCode>();
        //    try
        //    {
        //        var service = new AccountService();
        //        list = service.GetAccountTradeCodeByUserID(1);
        //    }
        //    catch (Exception ex)
        //    {
        //        KS.Zero.Utils.Log.Error(ex.Message);
        //        throw;
        //    }
        //    return list;
        //}
        #endregion

        private void kDGVAcc_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }


        private void CleankDGVTradeCode(KryptonDataGridView kdgv)
        {
            while (kdgv.Rows.Count != 0)
            {
                kdgv.Rows.RemoveAt(0);
            }
        }




        //private DataGridViewRow GetNewGVColumn()
        //{
        //    DataGridViewRow dgvCol = new DataGridViewRow();

        //    //dgvCol.Cells.AddRange(tCode,
        //}
        //        this.SH.Items.AddRange(new ComboxItem[] {
        //listExchange,
        //"3",
        //"5",
        //"7"});

        void SetFont()
        {
            //FontClass clssFont = new FontClass();
            //FontClass.LoadFont4KBtn(kbtnSearch, "查询");
            //FontClass.LoadFont4KBtn(kbtnInsert, "新增");
            //FontClass.LoadFont4KBtn(kbtnDelete, "删除");
            //FontClass.LoadFont4KBtn(kbtnUpdate, "修改");
            //FontClass.LoadFont4KBtn(kbtnCopy, "复制");
        }
    }
}
