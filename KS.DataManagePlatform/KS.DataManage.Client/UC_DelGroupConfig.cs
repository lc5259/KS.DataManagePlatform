using ComponentFactory.Krypton.Toolkit;
using KS.DataManage.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.CheckedListBox;

namespace KS.DataManagePlatform
{
    public partial class DelGroupConfig : KryptonForm
    {
        public DelGroupConfig()
        {
            InitializeComponent();
        }
        bool IsTrigCheckAllFunction = true;
        bool IsTrigCheckboxFunction = true;

        private void kryCheckBoxAll_CheckedChanged(object sender, EventArgs e)
        {
            IsTrigCheckboxFunction = false;
            if (IsTrigCheckAllFunction)
            {
                if (kryCheckBoxAll.Checked)
                {
                    for (int i = 0; i < kryCheckedListBox.Items.Count; i++)
                    {
                        kryCheckedListBox.SetItemChecked(i, true);
                    }

                }
                else
                {
                    for (int i = 0; i < kryCheckedListBox.Items.Count; i++)
                    {
                        kryCheckedListBox.SetItemChecked(i, false);
                    }
                }
            }
            IsTrigCheckboxFunction = true;
        }

        private void kryCheckedListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            IsTrigCheckAllFunction = false;
            if (IsTrigCheckboxFunction)
            {
                //int index = kryCheckedListBox.SelectedIndex;
                //CheckState SelectedCheckState = kryCheckedListBox.GetItemCheckState(index);
                //if (SelectedCheckState == CheckState.Checked)
                //{
                //    SelectedCheckState = CheckState.Unchecked;
                //}
                //if (SelectedCheckState == CheckState.Unchecked)
                //{
                //    SelectedCheckState = CheckState.Checked;
                //}
                //kryCheckedListBox.SetItemCheckState(index, SelectedCheckState);
                //if (kryCheckedListBox.getc)

                for (int i = 0; i < kryCheckedListBox.Items.Count; i++)
                {
                    if (kryCheckedListBox.GetItemChecked(i))
                    {
                        this.kryCheckBoxAll.Checked = true;
                    }
                    else
                    {
                        this.kryCheckBoxAll.Checked = false;
                        IsTrigCheckAllFunction = true;
                        return;
                    }
                }
            }
            IsTrigCheckAllFunction = true;
        }

        private void kryButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void kryButtonOK_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < kryCheckedListBox.Items.Count; i++)
            {
                if (kryCheckedListBox.GetItemCheckState(i) == CheckState.Checked)
                {
                    FrmMain.RemoveGroup(kryCheckedListBox.Items[i].ToString());
                }
            }
            this.Close();
            
        }
    }
}
