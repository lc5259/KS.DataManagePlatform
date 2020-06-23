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
    public partial class FrmGenerateFileKeywordSet : FrmSaveBase
    {
        public FrmGenerateFileKeywordSet()
        {
            InitializeComponent();
        }

        private void kbtnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
