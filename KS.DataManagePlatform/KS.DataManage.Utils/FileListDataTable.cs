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
            DataColumn TName = new DataColumn(); TName.Caption = "TName"; TName.ColumnName = "机构名称";
            DataColumn CheckBox = new DataColumn(); CheckBox.Caption = "CheckBox"; CheckBox.ColumnName = ""; CheckBox.DataType = typeof(bool);
            dt.Columns.AddRange(new DataColumn[] { CheckBox, TName });
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
            //dt.Columns.Add("TargetFileIsIEachAccountOutTitle", typeof(System.String));
            //xml;
            foreach (XElement item in xml.Descendants("OrganCode"))
            {
                foreach (XElement file in item.Nodes())
                {
                    //DataRow dr = dt.NewRow();
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
                    //fid="1" filetitle="成交单" filename="{accountid}_SG01_{tradingday}_1_Trade" fileext="TXT" isallsame="是" 
                    //arrangeType ="纵向" IsOutTitle="是" IsOutColName="是" splitc=" " IsSum="否" IsOutPut="是" IsDispAccId="否" IsOutLineTitle="否">
                    dt.Rows.Add(file.Attribute("IsDispAccId").Value.Equals("是") ? true : false, item.Attribute("name").Value);
                        //,
                        //item.Attribute("name").Value,
                        //file.Attribute("fid").Value,
                        //file.Attribute("filetitle").Value,
                        //file.Attribute("filename").Value,
                        //file.Attribute("fileext").Value,
                        //file.Attribute("isallsame").Value,
                        //file.Attribute("arrangeType").Value,
                        //file.Attribute("IsOutTitle").Value,
                        //file.Attribute("IsOutColName").Value,
                        //file.Attribute("splitc").Value,
                        //file.Attribute("IsSum").Value,
                        //file.Attribute("IsDispAccId").Value,
                        //file.Attribute("IsDispAccId").Value
                        //);
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
            dt.Columns.Add("SourceFileNo", typeof(System.String));
            dt.Columns.Add("SourceFileName", typeof(System.String));
            dt.Columns.Add("SourceFileNameFunfAccountNoIndex", typeof(System.String));
            dt.Columns.Add("SourceFileFrom", typeof(System.String));
            dt.Columns.Add("SourceFileSeparator", typeof(System.String));
            dt.Columns.Add("SourceFileMergeType", typeof(System.String));

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
            dt.Columns.Add("GenerateFileKeywordNo", typeof(System.String));
            dt.Columns.Add("GenerateFileKeywordName", typeof(System.String));
            dt.Columns.Add("GenerateFileKeywordIndex", typeof(System.String));

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
