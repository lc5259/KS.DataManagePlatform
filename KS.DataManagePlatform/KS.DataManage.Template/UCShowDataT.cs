using KS.DataManage.Templete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KS.Zero.Client.Controls
{
    public class UCShowDataT<T> : UCShowData
    {
        public T model { get; set; }

        public UCShowDataT( T t)
        {
            this.model = t;
        }
        public UCShowDataT(List<T> list, string lbl1, List<string> list1,
            string lbl2, List<string> list2,
            string lbl3, List<string> list3,
            bool flgoutput, bool flgsearch, bool flginsert, bool flgupdate, bool flgcopy, bool flgdelete,T t)
        {
            this.model = t;

            this.kbtnOutput.Visible = flgoutput;
            this.kbtnSearch.Visible = flgsearch;
            this.kbtnInsert.Visible = flginsert;
            this.kbtnUpdate.Visible = flgupdate;
            this.kbtnCopy.Visible = flgcopy;
            this.kbtnDelete.Visible = flgdelete;

            this.kDGV.DataSource = list;
        }
    }
}
