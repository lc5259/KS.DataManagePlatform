using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace KS.DataManage.Utils
{
    public static class FileDataTable
    {
        /// <summary>
        /// 文件列表
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static DataTable FildListDT(XElement xml)
        {
            //DataTable dt = new DataTable();
            //dt.Columns.Add("TName", typeof(System.String));
            //dt.Columns.Add("TargetFileNo", typeof(System.String));
            //dt.Columns.Add("TargetFileTitle", typeof(System.String));
            //dt.Columns.Add("TargetFileName", typeof(System.String));
            //dt.Columns.Add("TargetFileFormat", typeof(System.String));
            //dt.Columns.Add("TargetFileTXTEqueDBF", typeof(System.String));
            //dt.Columns.Add("TargetFileColumnDirection", typeof(System.String));
            //dt.Columns.Add("TargetFileIsOutTitle", typeof(System.String));
            //dt.Columns.Add("TargetFileIsOutColumnName", typeof(System.String));
            //dt.Columns.Add("TargetFileIsConnector", typeof(System.String));
            //dt.Columns.Add("TargetFileIsIsSummary", typeof(System.String));
            //dt.Columns.Add("TargetFileIsIsShowFundAccountNo", typeof(System.String));
            //dt.Columns.Add("TargetFileIsIEachAccountOutTitle", typeof(System.String));
            ////xml;
            //foreach (XElement item in xml.Descendants("OrganCode"))
            //{
            //    foreach (XElement file in item.Nodes())
            //    {
            //        DataRow dr = dt.NewRow();
            //        dr["TName"] = item.Attribute("name").Value;
            //        dr["TargetFileNo"] = file.Attribute("fid").Value;
            //        dr["TargetFileTitle"] = file.Attribute("filetitle").Value;
            //        dr["TargetFileName"] = file.Attribute("filename").Value;
            //        dr["TargetFileFormat"] = file.Attribute("fileext").Value;
            //        dr["TargetFileTXTEqueDBF"] = file.Attribute("isallsame").Value;
            //        dr["TargetFileColumnDirection"] = file.Attribute("arrangeType").Value;
            //        dr["TargetFileIsOutTitle"] = file.Attribute("IsOutTitle").Value;
            //        dr["TargetFileIsOutColumnName"] = file.Attribute("IsOutColName").Value;
            //        dr["TargetFileIsConnector"] = file.Attribute("splitc").Value;
            //        dr["TargetFileIsIsSummary"] = file.Attribute("IsSum").Value;
            //        dr["TargetFileIsIsShowFundAccountNo"] = file.Attribute("IsDispAccId").Value;
            //        dr["TargetFileIsIEachAccountOutTitle"] = file.Attribute("IsDispAccId").Value;
            //        //fid="1" filetitle="成交单" filename="{accountid}_SG01_{tradingday}_1_Trade" fileext="TXT" isallsame="是" 
            //        //arrangeType ="纵向" IsOutTitle="是" IsOutColName="是" splitc=" " IsSum="否" IsOutPut="是" IsDispAccId="否" IsOutLineTitle="否">
            //        dt.Rows.Add(dr);
            //    }
            //}TargetFileOrganizationName
            DataTable dt = new DataTable();
            //DataColumn TName = new DataColumn(); TName.Caption = "TName"; TName.ColumnName = "机构名称";
            //DataColumn CheckBox = new DataColumn(); CheckBox.Caption = "CheckBox"; CheckBox.ColumnName = ""; CheckBox.DataType = typeof(bool);
            //dt.Columns.AddRange(new DataColumn[] { CheckBox, TName });
            //DataColumn TName = new DataColumn(); TName.Caption = "机构名称"; TName.ColumnName = "TName";
            //DataColumn TName = new DataColumn(); TName.Caption = "机构名称"; TName.ColumnName = "TName";
            //DataColumn TName = new DataColumn(); TName.Caption = "机构名称"; TName.ColumnName = "TName";
            //DataColumn TName = new DataColumn(); TName.Caption = "机构名称"; TName.ColumnName = "TName";
            //DataColumn dataComboBox;
            //DataColumn dataTextBox;
            //DataColumn dataMaskedTextBox;
            //DataColumn dataDomainUpDown;
            //DataColumn dataNumericUpDown;
            //DataColumn dataButton;
            //DataColumn dataCheckBox;
            //DataColumn dataDateTime;
            //DataColumn dataComboBox;
            //DataColumn dataTextBox;
            //DataColumn dataMaskedTextBox;
            //DataColumn dataDomainUpDown;
            //DataColumn dataNumericUpDown;
            //DataColumn dataButton;
            //DataColumn dataCheckBox;

            //dt.Columns.Add("机构名称", typeof(System.String)); //var s = new DataColumn(); s.
            //dt.Columns.Add("TargetFileNo", typeof(System.String));
            //dt.Columns.Add("TargetFileTitle", typeof(System.String));
            //dt.Columns.Add("TargetFileName", typeof(System.String));
            //dt.Columns.Add("TargetFileFormat", typeof(System.String));
            //dt.Columns.Add("TargetFileTXTEqueDBF", typeof(System.String));
            //dt.Columns.Add("TargetFileColumnDirection", typeof(System.String));
            //dt.Columns.Add("TargetFileIsOutTitle", typeof(System.String));
            //dt.Columns.Add("TargetFileIsOutColumnName", typeof(System.String));
            //dt.Columns.Add("TargetFileIsConnector", typeof(System.String));
            //dt.Columns.Add("TargetFileIsIsSummary", typeof(System.String));
            //dt.Columns.Add("TargetFileIsIsShowFundAccountNo", typeof(System.String));
            //dt.Columns.Add("TargetFileIsIEachAccountOutTitle", typeof(System.String)); TargetOrganizationName
            //xml;

            dt.Columns.Add("DataTargetOrganizationName", typeof(System.String)); //var s = new DataColumn(); s.
            dt.Columns.Add("DataTargetFileNo", typeof(System.String));
            dt.Columns.Add("DataTargetFileTitle", typeof(System.String));
            dt.Columns.Add("DataTargetFileName", typeof(System.String));
            dt.Columns.Add("DataTargetFileFormat", typeof(System.String));
            dt.Columns.Add("DataTargetFileTXTEqueDBF", typeof(System.String));
            dt.Columns.Add("DataTargetFileColumnDirection", typeof(System.String));
            dt.Columns.Add("DataTargetFileIsOutTitle", typeof(System.String));
            dt.Columns.Add("DataTargetFileIsOutColumnName", typeof(System.String));
            dt.Columns.Add("DataTargetFileIsConnector", typeof(System.String));
            dt.Columns.Add("DataTargetFileIsIsSummary", typeof(System.String));
            dt.Columns.Add("DataTargetFileIsIsShowFundAccountNo", typeof(System.String));
            dt.Columns.Add("DataTargetFileIsIEachAccountOutTitle", typeof(System.String));
            foreach (XElement item in xml.Descendants("OrganCode"))
            {
                foreach (XElement file in item.Nodes())
                {
                    DataRow dr = dt.NewRow();
                    //dr["机构名称"] = item.Attribute("name").Value;
                    //dr["TargetFileNo"] = file.Attribute("fid").Value;
                    //dr["TargetFileTitle"] = file.Attribute("filetitle").Value;
                    //dr["TargetFileName"] = file.Attribute("filename").Value;
                    //dr["TargetFileFormat"] = file.Attribute("fileext").Value;
                    //dr["TargetFileTXTEqueDBF"] = file.Attribute("isallsame").Value;
                    //dr["TargetFileColumnDirection"] = file.Attribute("arrangeType").Value;
                    //dr["TargetFileIsOutTitle"] = file.Attribute("IsOutTitle").Value;
                    //dr["TargetFileIsOutColumnName"] = file.Attribute("IsOutColName").Value;
                    //dr["TargetFileIsConnector"] = file.Attribute("splitc").Value;
                    //dr["TargetFileIsIsSummary"] = file.Attribute("IsSum").Value;
                    //dr["TargetFileIsIsShowFundAccountNo"] = file.Attribute("IsDispAccId").Value;
                    //dr["TargetFileIsIEachAccountOutTitle"] = file.Attribute("IsDispAccId").Value;

                    dr["DataTargetOrganizationName"] = item.Attribute("name").Value;
                    dr["DataTargetFileNo"] = file.Attribute("fid").Value;
                    dr["DataTargetFileTitle"] = file.Attribute("filetitle").Value;
                    dr["DataTargetFileName"] = file.Attribute("filename").Value;
                    dr["DataTargetFileFormat"] = file.Attribute("fileext").Value;
                    dr["DataTargetFileTXTEqueDBF"] = file.Attribute("isallsame").Value;
                    dr["DataTargetFileColumnDirection"] = file.Attribute("arrangeType").Value;
                    dr["DataTargetFileIsOutTitle"] = file.Attribute("IsOutTitle").Value;
                    dr["DataTargetFileIsOutColumnName"] = file.Attribute("IsOutColName").Value;
                    dr["DataTargetFileIsConnector"] = file.Attribute("splitc").Value;
                    dr["DataTargetFileIsIsSummary"] = file.Attribute("IsSum").Value;
                    dr["DataTargetFileIsIsShowFundAccountNo"] = file.Attribute("IsDispAccId").Value;
                    dr["DataTargetFileIsIEachAccountOutTitle"] = file.Attribute("IsDispAccId").Value;

                    //fid="1" filetitle="成交单" filename="{accountid}_SG01_{tradingday}_1_Trade" fileext="TXT" isallsame="是" 
                    //arrangeType ="纵向" IsOutTitle="是" IsOutColName="是" splitc=" " IsSum="否" IsOutPut="是" IsDispAccId="否" IsOutLineTitle="否">
                    //dt.Rows.Add(file.Attribute(//"IsDispAccId").Value.Equals("是") ? true : false, 
                    //    item.Attribute("name").Value//);
                    //    ,
                    //    item.Attribute("name").Value,
                    //    file.Attribute("fid").Value,
                    //    file.Attribute("filetitle").Value,
                    //    file.Attribute("filename").Value,
                    //    file.Attribute("fileext").Value,
                    //    file.Attribute("isallsame").Value,
                    //    file.Attribute("arrangeType").Value,
                    //    file.Attribute("IsOutTitle").Value,
                    //    file.Attribute("IsOutColName").Value,
                    //    file.Attribute("splitc").Value,
                    //    file.Attribute("IsSum").Value,
                    //    file.Attribute("IsDispAccId").Value,
                    //    file.Attribute("IsDispAccId").Value
                    //    ));
                    dt.Rows.Add(dr);
                }
            }



            return dt;
        }


        //DataRow dr = dt.NewRow();
        //dr[""] = item.Attribute("name").Value;
        //            dr[""] = item.Attribute("name").Value;
        //            dr[""] = item.Attribute("name").Value;
        //            dr[""] = item.Attribute("name").Value;
        //            dr[""] = item.Attribute("name").Value;
        //            dr[""] = item.Attribute("name").Value;
        //            dr[""] = item.Attribute("name").Value;
        //            dr[""] = item.Attribute("name").Value;
        //            dr[""] = item.Attribute("name").Value;
        //            dr[""] = item.Attribute("name").Value;
        //            dr[""] = item.Attribute("name").Value;
        //            dr[""] = item.Attribute("name").Value;
        //            dr[""] = item.Attribute("name").Value;
        //            dr[""] = item.Attribute("name").Value;
        //            dr[""] = item.Attribute("name").Value;
        //            dr[""] = item.Attribute("name").Value;
        //            dr[""] = item.Attribute("name").Value;
        //            dr[""] = item.Attribute("name").Value;
        /// <summary>
        /// 原文件列表
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static DataTable SourceFileListDT(XElement xml)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("DataSourceFileNo", typeof(System.String));
            dt.Columns.Add("DataSourceFileName", typeof(System.String));
            dt.Columns.Add("DataSourceFileFunfAccountNoIndex", typeof(System.String));
            dt.Columns.Add("DataSourceFileFrom", typeof(System.String));
            dt.Columns.Add("DataSourceFileSeparator", typeof(System.String));
            dt.Columns.Add("DataSourceFileMergeType", typeof(System.String));

            foreach (XElement item in xml.Descendants("fileSrc"))
            {
                DataRow dr = dt.NewRow();

                dr["DataSourceFileNo"] = item.Attribute("srcid").Value;
                dr["DataSourceFileName"] = item.Attribute("srcfile").Value;
                dr["DataSourceFileFunfAccountNoIndex"] = item.Attribute("AccIdIndex").Value;
                dr["DataSourceFileFrom"] = item.Attribute("srcfileType").Value;
                dr["DataSourceFileSeparator"] = item.Attribute("splitc").Value;
                dr["DataSourceFileMergeType"] = item.Attribute("combtype").Value;

                dt.Rows.Add(dr);
            }
            return dt;
        }
        /// <summary>
        /// 生成文件关键字
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static DataTable KeyWordstDT(XElement xml)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("DataGenerateFileKeywordNo", typeof(System.String));
            dt.Columns.Add("DataGenerateFileKeywordName", typeof(System.String));
            dt.Columns.Add("DataGenerateFileKeywordIndex", typeof(System.String));

            foreach (XElement item in xml.Descendants("filepkg"))
            {
                DataRow dr = dt.NewRow();

                dr["DataGenerateFileKeywordNo"] = item.Attribute("pkid").Value;
                dr["DataGenerateFileKeywordName"] = item.Attribute("name").Value;
                dr["DataGenerateFileKeywordIndex"] = item.Attribute("pkgColIndex").Value;

                dt.Rows.Add(dr);
            }
            return dt;
        }
        /// <summary>
        /// 文件字段列表
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static DataTable FildWordsListDT(XElement xml)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("FileFieldNo", typeof(System.String));
            dt.Columns.Add("FileFieldTXTColumnName", typeof(System.String));
            dt.Columns.Add("FileFieldDBFColumnName", typeof(System.String));
            dt.Columns.Add("FileFieldColumnNameDigit", typeof(System.String));
            dt.Columns.Add("FileFieldColumnValueDigit", typeof(System.String));
            dt.Columns.Add("FileFieldColumnValueAccuracy", typeof(System.String));
            dt.Columns.Add("FileFieldAlignment", typeof(System.String));
            dt.Columns.Add("FileFieldIsOut", typeof(System.String));
            dt.Columns.Add("FileFieldNotNull", typeof(System.String));
            dt.Columns.Add("FileFieldCalculationSymbols", typeof(System.String));
            dt.Columns.Add("FileFieldFixedValue", typeof(System.String));
            dt.Columns.Add("FileFieldIsSummary", typeof(System.String));
            dt.Columns.Add("FileFieldIsComplementCharacter", typeof(System.String));
            dt.Columns.Add("FileFieldIsFiledIndex", typeof(System.String));
            dt.Columns.Add("FileFieldIsDefaultValue", typeof(System.String));
            dt.Columns.Add("FileFieldIsAbsoluteValue", typeof(System.String));
            dt.Columns.Add("FileFieldIsAbsoluteValueOut", typeof(System.String));

            return dt;
        }
        /// <summary>
        /// 过滤条件
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static DataTable FilterDT(XElement xml)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("FilterConditionsNo", typeof(System.String));
            dt.Columns.Add("FilterConditionsColumnName", typeof(System.String));
            dt.Columns.Add("FilterConditionsColumnIndex", typeof(System.String));
            dt.Columns.Add("FilterConditionseConditionvalue", typeof(System.String));
            dt.Columns.Add("FilterConditionseConditionalSymbol", typeof(System.String));


            return dt;
        }
        /// <summary>
        /// 数据字典
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static DataTable DictDT(XElement xml)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("DataDictionaryNo", typeof(System.String));
            dt.Columns.Add("DataDictionarySourceValue", typeof(System.String));
            dt.Columns.Add("DataDictionaryTargetValue", typeof(System.String));

            return dt;
        }

    }
}
