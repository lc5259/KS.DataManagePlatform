using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KS.DataManage.Utils;
using ComponentFactory.Krypton.Toolkit;

namespace KS.DataManage.Client
{
    public partial class UC_GeneFile : UserControl
    {
        public UC_GeneFile()
        {
            InitializeComponent();
            //SetFont();//测试阶段暂时关闭
        }


        bool _createVisible = true;
        bool IsSingleCffexCheckAll = true;
        bool IsSingleCffexCheck = true;
        bool IsSingleMotorCenterAll = true;
        bool IsSingleMotorCenter = true;

        bool IsMoreCffexCheckAll = true;
        bool IsMoreCffexCheck = true;
        bool IsMoreMotorCenterAll = true;
        bool IsMoreMotorCenter = true;

        [DefaultValue((bool)true), Description("新增按钮是否可见")]
        public virtual bool CreateVisible
        {
            get { return _createVisible; }
            set
            {
                _createVisible = value;
            }
        }

        bool _updateVisible = true;
        [DefaultValue((bool)true), Description("修改按钮是否可见")]
        public virtual bool UpdateVisible
        {
            get { return _updateVisible; }
            set
            {
                _updateVisible = value;
            }
        }

        bool _copyVisible = true;
        [DefaultValue((bool)true), Description("复制按钮是否可见")]
        public virtual bool CopyVisible
        {
            get { return _copyVisible; }
            set
            {
                _copyVisible = value;
            }
        }

        bool _deleteVisible = true;
        [DefaultValue((bool)true), Description("删除按钮是否可见")]
        public virtual bool DeleteVisible
        {
            get { return _deleteVisible; }
            set
            {
                _deleteVisible = value;
            }
        }

        bool _outpuVisible = true;
        [DefaultValue((bool)true), Description("导出按钮是否可见")]
        public virtual bool OutputVisible
        {
            get { return _outpuVisible; }
            set
            {
                _outpuVisible = value;
            }
        }

        bool _label1Visible = true;
        [DefaultValue((bool)true), Description("Label1按钮是否可见")]
        public virtual bool Label1Visible
        {
            get { return _label1Visible; }
            set
            {
                _label1Visible = value;
            }
        }

        bool _label2Visible = true;
        [DefaultValue((bool)true), Description("Label2按钮是否可见")]
        public virtual bool Label2Visible
        {
            get { return _label2Visible; }
            set
            {
                _label2Visible = value;
            }
        }

        bool _label3Visible = true;
        [DefaultValue((bool)true), Description("Label3按钮是否可见")]
        public virtual bool Label3Visible
        {
            get { return _label3Visible; }
            set
            {
                _label3Visible = value;
            }
        }

        bool _label4Visible = true;
        [DefaultValue((bool)true), Description("Label4按钮是否可见")]
        public virtual bool Label4Visible
        {
            get { return _label4Visible; }
            set
            {
                _label4Visible = value;
            }
        }

        bool _combBox1Visible = true;
        [DefaultValue((bool)true), Description("comb1是否可见")]
        public virtual bool Comb1Visible
        {
            get { return _combBox1Visible; }
            set
            {
                _combBox1Visible = value;
            }
        }

        bool _combBox2Visible = true;
        [DefaultValue((bool)true), Description("comb2是否可见")]
        public virtual bool Comb2Visible
        {
            get { return _combBox2Visible; }
            set
            {
                _combBox2Visible = value;
            }
        }

        bool _combBox3Visible = true;
        [DefaultValue((bool)true), Description("comb3是否可见")]
        public virtual bool Comb3Visible
        {
            get { return _combBox3Visible; }
            set
            {
                _combBox3Visible = value;
            }
        }

        bool _combBox4Visible = true;
        [DefaultValue((bool)true), Description("comb4是否可见")]
        public virtual bool Comb4Visible
        {
            get { return _combBox4Visible; }
            set
            {
                _combBox4Visible = value;
            }
        }

        bool _kdgvVisible = true;
        [DefaultValue((bool)true), Description("Dgv是否可见")]
        public virtual bool KryptonDGVVisible
        {
            get { return _kdgvVisible; }
            set
            {
                _kdgvVisible = value;
            }
        }

        bool _inputVisible = false;
        [DefaultValue((bool)true), Description("导入按钮是否可见")]
        public virtual bool InputVisible
        {
            get { return _inputVisible; }
            set
            {
                _inputVisible = value;
            }
        }

        void SetFont()
        {
            //FontClass.LoadFont4KBtn(kbtnSearch, "查询");
            //FontClass.LoadFont4KBtn(kbtnInsert, "新增");
            //FontClass.LoadFont4KBtn(kbtnDelete, "删除");
            //FontClass.LoadFont4KBtn(kbtnUpdate, "修改");
            //FontClass.LoadFont4KBtn(kbtnCopy, "复制");
            //FontClass.LoadFont4KBtn(kbtnInput, "导入");
            //FontClass.LoadFont4KBtn(kbtnOutput, "导出");
        }

        private void UCShowData_Load(object sender, EventArgs e)
        {
            SetFont();
        }

        private void kryBtOpenOriginPathFile_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            path.ShowDialog();
            this.kryTextBoxOriginPath.Text = path.SelectedPath;

        }

        private void kryBtOpenCffexOutPathFile1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            path.ShowDialog();
            this.kryTextBoxCffexOutPath1.Text = this.kryTextBoxMonitorCenterOutPath1.Text = path.SelectedPath;
        }

        private void kryBtOpenCffexOutPathFile2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            path.ShowDialog();
            this.kryTextBoxCffexOutPath2.Text = this.kryTextBoxMonitorCenterOutPath2.Text = path.SelectedPath;
        }

        private void kryBtOpenMonitorCenterOutPathFile1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            path.ShowDialog();
            this.kryTextBoxMonitorCenterOutPath1.Text = path.SelectedPath;
        }

        private void kryBtOpenMonitorCenterOutPathFile2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            path.ShowDialog();
            this.kryTextBoxMonitorCenterOutPath2.Text = path.SelectedPath;
        }

        private void kryCBSingleCffexAccount_CheckedChanged(object sender, EventArgs e)
        {
            IsSingleCffexCheck = false;
            if (IsSingleCffexCheckAll)
            {
                if (kryCBSingleCffexAccount.Checked)
                {
                    for (int i = 0; i < kryCLBSingleCffexAccount.Items.Count; i++)
                    {
                        kryCLBSingleCffexAccount.SetItemChecked(i, true);
                    }

                }
                else
                {
                    for (int i = 0; i < kryCLBSingleCffexAccount.Items.Count; i++)
                    {
                        kryCLBSingleCffexAccount.SetItemChecked(i, false);
                    }
                }
            }
            kryLbSingleCffexAccountCount.Text = "(" + kryCLBSingleCffexAccount.CheckedItems.Count + "/" + kryCLBSingleCffexAccount.Items.Count.ToString() + ")";
            IsSingleCffexCheck = true;
        }
        private void kryCLBSingleCffexAccount_SelectedValueChanged(object sender, EventArgs e)
        {
            IsSingleCffexCheckAll = false;
            if (IsSingleCffexCheck)
            {
                for (int i = 0; i < kryCLBSingleCffexAccount.Items.Count; i++)
                {
                    if (kryCLBSingleCffexAccount.GetItemChecked(i))
                    {
                        this.kryCBSingleCffexAccount.Checked = true;
                    }
                    else
                    {
                        this.kryCBSingleCffexAccount.Checked = false;
                        kryLbSingleCffexAccountCount.Text = "(" + kryCLBSingleCffexAccount.CheckedItems.Count + "/" + kryCLBSingleCffexAccount.Items.Count.ToString() + ")";
                        IsSingleCffexCheckAll = true;
                        return;
                    }
                }
            }
            kryLbSingleCffexAccountCount.Text = "(" + kryCLBSingleCffexAccount.CheckedItems.Count + "/" + kryCLBSingleCffexAccount.Items.Count.ToString() + ")";
            IsSingleCffexCheckAll = true;
        }
        private void kryBtSingleAccountCffex_Click(object sender, EventArgs e)
        {
            if (!kryCLBSingleCffexAccount.Items.Contains(kryTBSingleFundAcconutNo.Text.ToString()))
            {
                kryCLBSingleCffexAccount.Items.Add(kryTBSingleFundAcconutNo.Text.ToString());
                kryLbSingleCffexAccountCount.Text = "(" + kryCLBSingleCffexAccount.CheckedItems.Count + "/" + kryCLBSingleCffexAccount.Items.Count.ToString() + ")";
            }
        }

        private void krypBtSingleAccountMotorCenter_Click(object sender, EventArgs e)
        {
            if (!kryCLBSingleMotorCenterAccount.Items.Contains(kryTBSingleFundAcconutNo.Text.ToString()))
            {
                kryCLBSingleMotorCenterAccount.Items.Add(kryTBSingleFundAcconutNo.Text.ToString());
                kryLbSingleMotorCenterAccountCount.Text = "(" + kryCLBSingleMotorCenterAccount.CheckedItems.Count + "/" + kryCLBSingleMotorCenterAccount.Items.Count.ToString() + ")";
            }
            
        }

        private void kryBtSingleAccountAll_Click(object sender, EventArgs e)
        {
            kryBtSingleAccountCffex_Click(null,null);
            krypBtSingleAccountMotorCenter_Click(null, null);
        }

        private void kryCBSingleMotorCenterAccount_CheckedChanged(object sender, EventArgs e)
        {
            IsSingleMotorCenter = false;
            if (IsSingleMotorCenterAll)
            {
                if (kryCBSingleMotorCenterAccount.Checked)
                {
                    for (int i = 0; i < kryCLBSingleMotorCenterAccount.Items.Count; i++)
                    {
                        kryCLBSingleMotorCenterAccount.SetItemChecked(i, true);
                    }

                }
                else
                {
                    for (int i = 0; i < kryCLBSingleMotorCenterAccount.Items.Count; i++)
                    {
                        kryCLBSingleMotorCenterAccount.SetItemChecked(i, false);
                    }
                }
            }
            kryLbSingleMotorCenterAccountCount.Text = "("+ kryCLBSingleMotorCenterAccount.CheckedItems.Count + "/" + kryCLBSingleMotorCenterAccount.Items.Count.ToString() + ")";
            IsSingleMotorCenter = true;
        }

        private void kryCLBSingleMotorCenterAccount_SelectedValueChanged(object sender, EventArgs e)
        {
            IsSingleMotorCenterAll = false;
            if (IsSingleMotorCenter)
            {
                for (int i = 0; i < kryCLBSingleMotorCenterAccount.Items.Count; i++)
                {
                    if (kryCLBSingleMotorCenterAccount.GetItemChecked(i))
                    {
                        this.kryCBSingleMotorCenterAccount.Checked = true;
                    }
                    else
                    {
                        this.kryCBSingleMotorCenterAccount.Checked = false;
                        IsSingleMotorCenterAll = true;
                        kryLbSingleMotorCenterAccountCount.Text = "("+ kryCLBSingleMotorCenterAccount.CheckedItems.Count + "/" + kryCLBSingleMotorCenterAccount.Items.Count.ToString() +")";
                        return;
                    }
                }
            }
            kryLbSingleMotorCenterAccountCount.Text = "(" +kryCLBSingleMotorCenterAccount.CheckedItems.Count + "/" + kryCLBSingleMotorCenterAccount.Items.Count.ToString() + ")";
            IsSingleMotorCenterAll = true;
        }

        private void kryBtMoreAccountCffex_Click(object sender, EventArgs e)
        {
            if (!kryCLBMoreCffexAccount.Items.Contains(kryTBMoreFundAcconutNo.Text.ToString()))
            {
                kryCLBMoreCffexAccount.Items.Add(kryTBMoreFundAcconutNo.Text.ToString());
                kryLbMoreCffexAccountCount.Text = "(" + kryCLBMoreCffexAccount.CheckedItems.Count + "/" + kryCLBMoreCffexAccount.Items.Count.ToString() + ")";
            }
        }

        private void krypBtMoreAccountMotorCenter_Click(object sender, EventArgs e)
        {
            if (!kryCLBMoreMotorCenterAccount.Items.Contains(kryTBMoreFundAcconutNo.Text.ToString()))
            {
                kryCLBMoreMotorCenterAccount.Items.Add(kryTBMoreFundAcconutNo.Text.ToString());
                kryLbMoreMotorCenterAccountCount.Text = "(" + kryCLBMoreMotorCenterAccount.CheckedItems.Count + "/" + kryCLBMoreMotorCenterAccount.Items.Count.ToString() + ")";
            }
        }

        private void kryBtSingleToMotorCenter_Click(object sender, EventArgs e)
        {
            if ((kryCLBSingleCffexAccount.SelectedItem != null )&&   (!kryCLBSingleMotorCenterAccount.Items.Contains(kryCLBSingleCffexAccount.SelectedItem)))
            {
                kryCLBSingleMotorCenterAccount.Items.Add(kryCLBSingleCffexAccount.SelectedItem);
            }
           
        }

        private void kryBtSingleToCffex_Click(object sender, EventArgs e)
        {
            if (  (kryCLBSingleMotorCenterAccount.SelectedItem != null) && (!kryCLBSingleCffexAccount.Items.Contains(kryCLBSingleMotorCenterAccount.SelectedItem)))
            {
                kryCLBSingleCffexAccount.Items.Add(kryCLBSingleMotorCenterAccount.SelectedItem);
            }
        }

        private void kryBtSingleToSync_Click(object sender, EventArgs e)
        {
            List<string> SyncList = new List<string>();
            foreach (var item in kryCLBSingleCffexAccount.Items)
            {
                SyncList.Add(item.ToString());
            }
            foreach (var item in kryCLBSingleMotorCenterAccount.Items)
            {
                if (!SyncList.Contains(item.ToString()))
                {
                    SyncList.Add(item.ToString());
                }
            }

            kryCLBSingleCffexAccount.Items.Clear();
            kryCLBSingleMotorCenterAccount.Items.Clear();

            foreach (var item in SyncList)
            {
                kryCLBSingleCffexAccount.Items.Add(item.ToString());
                kryCLBSingleMotorCenterAccount.Items.Add(item.ToString());
            }
        }

        private void kryCLBSingleCffexAccount_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
            }
            catch
            {
            }
            kryCLBSingleCffexAccount.Items.RemoveAt(kryCLBSingleCffexAccount.SelectedIndex);
        }

        private void kryCLBSingleCffexAccount_DoubleClick(object sender, EventArgs e)
        {
            try
            {
            }
            catch
            {
            }
            kryCLBSingleCffexAccount.Items.RemoveAt(kryCLBSingleCffexAccount.SelectedIndex);
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            kryCLBSingleCffexAccount.Items.Remove(kryCLBSingleCffexAccount.SelectedItem);
            kryCLBSingleMotorCenterAccount.Items.Remove(kryCLBSingleMotorCenterAccount.SelectedItem);
        }

        private void kryBtMoreAccountAll_Click(object sender, EventArgs e)
        {
            kryBtMoreAccountCffex_Click(null,null);
            krypBtMoreAccountMotorCenter_Click(null, null);
        }

        private void kryCBMoreCffexAccount_CheckedChanged(object sender, EventArgs e)
        {
            IsMoreCffexCheck = false;
            if (IsMoreCffexCheckAll)
            {
                if (kryCBMoreCffexAccount.Checked)
                {
                    for (int i = 0; i < kryCLBMoreCffexAccount.Items.Count; i++)
                    {
                        kryCLBMoreCffexAccount.SetItemChecked(i, true);
                    }

                }
                else
                {
                    for (int i = 0; i < kryCLBMoreCffexAccount.Items.Count; i++)
                    {
                        kryCLBMoreCffexAccount.SetItemChecked(i, false);
                    }
                }
            }
            kryLbMoreCffexAccountCount.Text = "(" + kryCLBMoreCffexAccount.CheckedItems.Count + "/" + kryCLBMoreCffexAccount.Items.Count.ToString() + ")";
            IsMoreCffexCheck = true;
        }

        private void kryCLBMoreCffexAccount_SelectedValueChanged(object sender, EventArgs e)
        {
            IsMoreCffexCheckAll = false;
            if (IsMoreCffexCheck)
            {
                for (int i = 0; i < kryCLBMoreCffexAccount.Items.Count; i++)
                {
                    if (kryCLBMoreCffexAccount.GetItemChecked(i))
                    {
                        this.kryCBMoreCffexAccount.Checked = true;
                    }
                    else
                    {
                        this.kryCBMoreCffexAccount.Checked = false;
                        kryLbMoreCffexAccountCount.Text = "(" + kryCLBMoreCffexAccount.CheckedItems.Count + "/" + kryCLBMoreCffexAccount.Items.Count.ToString() + ")";
                        IsMoreCffexCheckAll = true;
                        return;
                    }
                }
            }
            kryLbMoreCffexAccountCount.Text = "(" + kryCLBMoreCffexAccount.CheckedItems.Count + "/" + kryCLBMoreCffexAccount.Items.Count.ToString() + ")";
            IsMoreCffexCheckAll = true;
        }

        private void kryCBMoreMotorCenterAccount_CheckedChanged(object sender, EventArgs e)
        {
            IsMoreMotorCenter = false;
            if (IsMoreMotorCenterAll)
            {
                if (kryCBMoreMotorCenterAccount.Checked)
                {
                    for (int i = 0; i < kryCLBMoreMotorCenterAccount.Items.Count; i++)
                    {
                        kryCLBMoreMotorCenterAccount.SetItemChecked(i, true);
                    }

                }
                else
                {
                    for (int i = 0; i < kryCLBMoreMotorCenterAccount.Items.Count; i++)
                    {
                        kryCLBMoreMotorCenterAccount.SetItemChecked(i, false);
                    }
                }
            }
            kryLbMoreMotorCenterAccountCount.Text = "(" + kryCLBMoreMotorCenterAccount.CheckedItems.Count + "/" + kryCLBMoreMotorCenterAccount.Items.Count.ToString() + ")";
            IsMoreMotorCenter = true;
        }

        private void kryCLBMoreMotorCenterAccount_SelectedValueChanged(object sender, EventArgs e)
        {
            IsMoreMotorCenterAll = false;
            if (IsMoreMotorCenter)
            {
                for (int i = 0; i < kryCLBMoreMotorCenterAccount.Items.Count; i++)
                {
                    if (kryCLBMoreMotorCenterAccount.GetItemChecked(i))
                    {
                        this.kryCBMoreMotorCenterAccount.Checked = true;
                    }
                    else
                    {
                        this.kryCBMoreMotorCenterAccount.Checked = false;
                        IsMoreMotorCenterAll = true;
                        kryLbMoreMotorCenterAccountCount.Text = "(" + kryCLBMoreMotorCenterAccount.CheckedItems.Count + "/" + kryCLBMoreMotorCenterAccount.Items.Count.ToString() + ")";
                        return;
                    }
                }
            }
            kryLbMoreMotorCenterAccountCount.Text = "(" + kryCLBMoreMotorCenterAccount.CheckedItems.Count + "/" + kryCLBMoreMotorCenterAccount.Items.Count.ToString() + ")";
            IsMoreMotorCenterAll = true;
        }

        private void kryBtMoreToMotorCenter_Click(object sender, EventArgs e)
        {
            if (  (kryCLBMoreCffexAccount.SelectedItem != null) &&(!kryCLBMoreMotorCenterAccount.Items.Contains(kryCLBMoreCffexAccount.SelectedItem)))
            {
                kryCLBMoreMotorCenterAccount.Items.Add(kryCLBMoreCffexAccount.SelectedItem);
            }
        }

        private void kryBtMoreToSync_Click(object sender, EventArgs e)
        {
            List<string> SyncList = new List<string>();
            foreach (var item in kryCLBMoreCffexAccount.Items)
            {
                SyncList.Add(item.ToString());
            }
            foreach (var item in kryCLBMoreMotorCenterAccount.Items)
            {
                if (!SyncList.Contains(item.ToString()))
                {
                    SyncList.Add(item.ToString());
                }
            }

            kryCLBMoreCffexAccount.Items.Clear();
            kryCLBMoreMotorCenterAccount.Items.Clear();

            foreach (var item in SyncList)
            {
                kryCLBMoreCffexAccount.Items.Add(item.ToString());
                kryCLBMoreMotorCenterAccount.Items.Add(item.ToString());
            }
        }

        private void kryBtMoreToCffex_Click(object sender, EventArgs e)
        {
            if ( (kryCLBMoreMotorCenterAccount.SelectedItem != null) && (!kryCLBMoreCffexAccount.Items.Contains(kryCLBMoreMotorCenterAccount.SelectedItem)))
            {
                kryCLBMoreCffexAccount.Items.Add(kryCLBMoreMotorCenterAccount.SelectedItem);
            }
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            kryCLBMoreCffexAccount.Items.Remove(kryCLBMoreCffexAccount.SelectedItem);
            kryCLBMoreMotorCenterAccount.Items.Remove(kryCLBMoreMotorCenterAccount.SelectedItem);
        }

        private void kryRadioButtonFolderCustomizeYES_CheckedChanged(object sender, EventArgs e)
        {
            krypTBFolderName.Enabled = true;
        }

        private void kryRadioButtonFolderCustomizeNO_CheckedChanged(object sender, EventArgs e)
        {
            krypTBFolderName.Enabled = false;
        }
    }
}
