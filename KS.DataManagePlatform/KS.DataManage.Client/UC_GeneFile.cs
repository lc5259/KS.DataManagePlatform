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
                        IsSingleCffexCheckAll = true;
                        return;
                    }
                }
            }
            IsSingleCffexCheckAll = true;
        }
        private void kryBtSingleAccountCffex_Click(object sender, EventArgs e)
        {

            kryCLBSingleCffexAccount.Items.Add(new KryptonListItem(kryTBSingleFundAcconutNo.Text.ToString()));
        }

        private void krypBtSingleAccountMotorCenter_Click(object sender, EventArgs e)
        {
            kryCLBSingleMotorCenterAccount.Items.Add(new KryptonListItem(kryTBSingleFundAcconutNo.Text.ToString()));
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
                        return;
                    }
                }
            }
            IsSingleMotorCenterAll = true;
        }
    }
}
