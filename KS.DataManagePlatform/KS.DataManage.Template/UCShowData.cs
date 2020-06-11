using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KS.DataManage.Utils;

namespace KS.DataManage.Templete
{
    public partial class UCShowData : UserControl
    {
        public UCShowData()
        {
            InitializeComponent();
            //SetFont();//测试阶段暂时关闭
        }


        bool _createVisible = true;
        [DefaultValue((bool)true), Description("新增按钮是否可见")]
        public virtual bool CreateVisible
        {
            get { return _createVisible; }
            set
            {
                kbtnInsert.Visible = value;
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
                kbtnUpdate.Visible = value;
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
                kbtnCopy.Visible = value;
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
                kbtnDelete.Visible = value;
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
                kbtnOutput.Visible = value;
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
                this.label1.Visible = value;
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
                this.label2.Visible = value;
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
                this.label3.Visible = value;
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
                this.label4.Visible = value;
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
                this.kryptonComboBox1.Visible = value;
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
                this.kryptonComboBox2.Visible = value;
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
                this.kryptonComboBox3.Visible = value;
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
                this.kryptonComboBox4.Visible = value;
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
                this.kDGV.Visible = value;
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
                this.kbtnInput.Visible = value;
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

    }
}
