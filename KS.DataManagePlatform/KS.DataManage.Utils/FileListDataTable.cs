using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KS.DataManage.Utils
{
    public static class FileDataTable
    {
        public static DataTable FildListDT(string xml)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("TName", typeof(System.String));
            dt.Columns.Add("TargetFileNo", typeof(System.String));
            dt.Columns.Add("TargetFileTitle", typeof(System.String));
            dt.Columns.Add("TargetFileName", typeof(System.String));
            dt.Columns.Add("TargetFileFormat", typeof(System.String));
            dt.Columns.Add("TargetFileTXTEqueDBF", typeof(System.String));
            dt.Columns.Add("TargetFileColumnDirection", typeof(System.String));
            dt.Columns.Add("TargetFileIsOutTitle", typeof(System.String));
            dt.Columns.Add("TargetFileIsOutColumnName", typeof(System.String));
            dt.Columns.Add("TargetFileIsConnector", typeof(System.String));
            dt.Columns.Add("TargetFileIsIsSummary", typeof(System.String));
            dt.Columns.Add("TargetFileIsIsShowFundAccountNo", typeof(System.String));
            dt.Columns.Add("TargetFileIsIEachAccountOutTitle", typeof(System.String));
            dt.Columns.Add("TargetFileIsOutTitle", typeof(System.String));

            return dt;
        }


    }
}
