using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KS.DataManage.Templete
{
    public partial class FrmSaveBase : KryptonForm
    {
        //private string v;
        //private CURDFlags curdFlags;
        //private T entity;

        public FrmSaveBase()
        {
            InitializeComponent();
        }

        private void kbtnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose(true);
        }

        //public FrmSaveBase(string title, CURDFlags insert)
        //{
        //    InitializeComponent();
        //    this.Text = title;
        //    this.curdFlags = insert;
        //}
    }
}
