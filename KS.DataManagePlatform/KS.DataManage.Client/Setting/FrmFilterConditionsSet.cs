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
    public partial class FrmFilterConditionsSet : FrmSaveBase
    {
        public FrmFilterConditionsSet()
        {
            InitializeComponent();
        }

        private void kbtnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
