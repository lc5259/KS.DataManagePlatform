using ComponentFactory.Krypton.Toolkit;
using KS.DataManage.Templete;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace KS.DataManage.Client
{
    public partial class UC_FutureContractInfo : UCShowData
    {

        DataTable dt = new DataTable("Table_Contract");
        public UC_FutureContractInfo()
        {
            InitializeComponent();

            //用户表 构造
            dt.Columns.Add("合约代码", typeof(int));
            dt.Columns.Add("合约名称", typeof(string));
            dt.Columns.Add("交易所名称", typeof(string));
            dt.Columns.Add("品种名称", typeof(string));
            dt.Columns.Add("品种代码", typeof(string));
            dt.Columns.Add("合约类型", typeof(string));
            dt.Columns.Add("最小变动价位", typeof(double));
            dt.Columns.Add("最后交易日", typeof(string));
            dt.Columns.Add("合约乘数", typeof(int));
            this.SuspendLayout();
            //DGV美化
            //GridViewShowData(SearchContract());
            //加载label
            //this.label1.Text = "交易所名称";
            //this.label2.Text = "品种名称";
            //this.label3.Text = "合约名称";

            //下拉列表代码 comblist;
            //kryptonComboBox1.DataSource = CombList.GetExchangeCombList();
            //kryptonComboBox2.DataSource = CombList.GetVarietyCombListFuture();
            //kryptonComboBox3.DataSource = CombList.GetContractCombListFuture();
            //kCmbTitle.DataSource = GetUserCombList();
            //kCombBoxPermission.DataSource = GetUserCombList();
            //kCombBoxUser.DataSource = GetUserCombList();
            this.ResumeLayout(false);
        }

        private void UC_FutureContractInfo_Load(object sender, EventArgs e)
        {
            //GridView.showHead(this, label1, kryptonComboBox1, label2, kryptonComboBox2, label3, kryptonComboBox3, kbtnSearch);
            //GridView.ShowData(kDGV);
        }



        #region 控件事件
        private void kbtnInsert_Click(object sender, EventArgs e)
        {
            //FrmFutureContractInfo fci = new FrmFutureContractInfo("新增期货合约", CURDFlags.Insert);
            //DialogResult dr = fci.ShowDialog();
            //if (dr == DialogResult.OK)
            //{
            //    GridViewShowData(SearchContract());
            //}
        }

        private void kbtnUpdate_Click(object sender, EventArgs e)
        {
            //if (this.kDGV.SelectedRows != null)
            //{
            //    Contract entity = DR2Contract(this.kDGV);//获取当前行数据
            //    FrmFutureContractInfo fci = new FrmFutureContractInfo(entity, "修改期货合约", CURDFlags.Update);
            //    DialogResult dr = fci.ShowDialog();
            //    if (dr == DialogResult.OK)
            //    {
            //        GridViewShowData(SearchContract());
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("请先选中一行!");
            //}
        }

        private void kbtnCopy_Click(object sender, EventArgs e)
        {
            //if (this.kDGV.SelectedRows != null)
            //{
            //    Contract entity = DR2Contract(this.kDGV);//获取当前行数据
            //    FrmFutureContractInfo fci = new FrmFutureContractInfo(entity, "复制新增期货合约", CURDFlags.Copy);
            //    DialogResult dr = fci.ShowDialog();
            //    if (dr == DialogResult.OK)
            //    {
            //        GridViewShowData(SearchContract());
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("请先选中一行!");
            //}
        }

        private void kbtnDelete_Click(object sender, EventArgs e)
        {
            //if (this.kDGV.SelectedRows != null)
            //{
            //    Contract entity = DR2Contract(this.kDGV);//获取当前行数据
            //    DialogResult dr = MessageBox.Show("确认删除该行数据? ", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //    if (dr == DialogResult.Yes)
            //    {
            //        ContractService service = new ContractService();
            //        service.DeleteContract(entity);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("请先选中一行!");
            //}
        }

        private void kbtnOutput_Click(object sender, EventArgs e)
        {
            string txt = "abc";
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                //设置文件类型  
                saveFileDialog.Filter = "Excel文件(*.xls)|*.xls|CSV文件(*.csv)|*.csv|所有文件|*.*";
                //设置默认文件类型显示顺序  
                saveFileDialog.FilterIndex = 1;
                //保存对话框是否记忆上次打开的目录  
                saveFileDialog.RestoreDirectory = true;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //获得文件路径  
                    string localFilePath = saveFileDialog.FileName.ToString();
                    using (FileStream fsWrite = new FileStream(localFilePath, FileMode.OpenOrCreate, FileAccess.Write))
                    {
                        byte[] buffer = Encoding.Default.GetBytes(txt);
                        fsWrite.Write(buffer, 0, buffer.Length);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void kbtnInput_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Excel文件(*.xls)|*.xls|CSV文件(*.csv)|*.csv|所有文件|*.*";

                //设置默认文件类型显示顺序  
                openFileDialog.FilterIndex = 1;
                //保存对话框是否记忆上次打开的目录  
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //获得文件路径  
                    string localFilePath = openFileDialog.FileName.ToString();
                    using (FileStream fsWrite = new FileStream(localFilePath, FileMode.OpenOrCreate, FileAccess.Write))
                    {
                        //byte[] buffer = Encoding.Default.GetBytes(txt);
                        //fsWrite.Write(buffer, 0, buffer.Length);
                    }
                }
                //FileStream file = new FileStream("E:\\test.txt", FileMode.Open);
                //file.Seek(0, SeekOrigin.Begin);
                //file.Read(byData, 0, 100); //byData传进来的字节数组,用以接受FileStream对象中的数据,第2个参数是字节数组中开始写入数据的位置,它通常是0,表示从数组的开端文件中向数组写数据,最后一个参数规定从文件读多少字符.
                //Decoder d = Encoding.Default.GetDecoder();
                //d.GetChars(byData, 0, byData.Length, charData, 0);
                //Console.WriteLine(charData);
                //file.Close();
            }
            catch (IOException ex)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void kbtnSearch_Click(object sender, EventArgs e)
        {
            ////List<Contract> list = SearchContract();
            //Contract entity = new Contract();
            //entity.Exchange_no = ((ComboxItem)this.kryptonComboBox1.SelectedItem).Value.ToString();
            //entity.Variety_code = null; //((ComboxItem)this.kryptonComboBox2.SelectedItem).Value.ToString();
            //entity.Contract_name = null; // ((ComboxItem)kryptonComboBox3.SelectedItem).Value.ToString();
            //try
            //{
            //    ContractService service = new ContractService();
            //    GridViewShowData(service.GetContractByParam(entity, true));
            //}
            //catch (Exception ex)
            //{

            //    throw;
            //}
        }
        #endregion


        #region 自定函数
        //private List<ComboxItem> GetExchangeCombList()
        //{
        //    List<ComboxItem> combList = new List<ComboxItem>();
        //    combList.Add(new ComboxItem(" - ", -1));
        //    foreach (var item in DictInfo.GetFutureExNo())
        //    {
        //        combList.Add(new ComboxItem(item.Code.ToString() + " - " + item.Name, int.Parse(item.Code)));
        //    }
        //    return combList;
        //}

        //private List<Contract> SearchContract()
        //{
        //    List<Contract> list = new List<Contract>();
        //    try
        //    {
        //        ContractService service = new ContractService();
        //        list = service.GetALLFutureContract();
        //    }
        //    catch (Exception ex)
        //    {
        //        KS.Zero.Utils.Log.Error(ex.Message);
        //        throw;
        //    }
        //    return list;
        //}
        ////将用户转为DataTable
        //private void GridViewShowData(List<Contract> listUser)
        //{
        //    //this.kDGV.DataSource = null;
        //    dt.Clear();
        //    foreach (var item in listUser)
        //    {
        //        dt.Rows.Add(item.Contract_id,
        //            item.Contract_name,
        //            DictInfo.GetDictStringByNo(item.Exchange_no, DictInfo.GetAllExchangeNo()), //item.Exchange_no,
        //            item.Variety_code,
        //            item.Delivery_variety_code,
        //            DictInfo.GetDictStringByNo(item.Contract_type, DictInfo.GetContractTypeDict()), //item.Contract_type,
        //            item.Pre_settlement_price,
        //            item.Expire_date,
        //            item.Volume_multiple);
        //    }
        //    this.kDGV.DataSource = dt;
        //}

        ////将用户转为Contract
        //private Contract DR2Contract(KryptonDataGridView kdgv)
        //{
        //    var rowinfo = kdgv.CurrentRow;

        //    Contract rowContract = new Contract();
        //    rowContract.Contract_id = rowinfo.Cells["合约代码"].Value.ToString();
        //    rowContract.Contract_name = rowinfo.Cells["合约名称"].Value.ToString();
        //    rowContract.Exchange_no = rowinfo.Cells["交易所名称"].Value.ToString();
        //    rowContract.Variety_code = rowinfo.Cells["品种名称"].Value.ToString();
        //    rowContract.Contract_type = rowinfo.Cells["合约类型"].Value.ToString();
        //    rowContract.Pre_settlement_price = decimal.Parse(rowinfo.Cells["最小变动价位"].Value.ToString());
        //    rowContract.Expire_date = rowinfo.Cells["最后交易日"].Value.ToString();
        //    rowContract.Volume_multiple = double.Parse(rowinfo.Cells["合约乘数"].Value.ToString());
        //    return rowContract;
        //}

        #endregion
    }
}
