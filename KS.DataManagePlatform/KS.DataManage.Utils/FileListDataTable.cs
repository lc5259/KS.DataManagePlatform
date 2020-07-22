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
            
            dt.Columns.Add("DataTargetFilecheck", typeof(System.Boolean));
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

                    if (!string.IsNullOrEmpty(file.Attribute("IsOutPut").Value) && file.Attribute("IsOutPut").Value == "是")
                    {
                        dr["DataTargetFilecheck"] = true;
                    }
                    else
                    {
                        dr["DataTargetFilecheck"] = false;
                    }
                    //dr["DataTargetFilecheck"] = item.Attribute("IsOutPut").Value;
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
            dt.Columns.Add("DataFileFieldNo", typeof(System.String));
            dt.Columns.Add("DataFileFieldTXTColumnName", typeof(System.String));
            dt.Columns.Add("DataFileFieldDBFColumnName", typeof(System.String));
            dt.Columns.Add("DataFileFieldColumnNameDigit", typeof(System.String));
            dt.Columns.Add("DataFileFieldColumnValueDigit", typeof(System.String));
            dt.Columns.Add("DataFileFieldColumnValueAccuracy", typeof(System.String));
            dt.Columns.Add("DataFileFieldAlignment", typeof(System.String));
            dt.Columns.Add("DataFileFieldIsOut", typeof(System.String));
            dt.Columns.Add("DataFileFieldNotNull", typeof(System.String));
            dt.Columns.Add("DataFileFieldCalculationSymbols", typeof(System.String));
            dt.Columns.Add("DataFileFieldFixedValue", typeof(System.String));
            dt.Columns.Add("DataFileFieldIsSummary", typeof(System.String));
            dt.Columns.Add("DataFileFieldIsComplementCharacter", typeof(System.String));
            dt.Columns.Add("DataFileFieldIsFiledIndex", typeof(System.String));
            dt.Columns.Add("DataFileFieldIsDefaultValue", typeof(System.String));
            dt.Columns.Add("DataFileFieldIsAbsoluteValue", typeof(System.String));
            dt.Columns.Add("DataFileFieldIsAbsoluteValueOut", typeof(System.String));

            foreach (XElement item in xml.Descendants("filecols"))
            {
                DataRow dr = dt.NewRow();

                dr["DataFileFieldNo"] = item.Attribute("cid").Value;
                dr["DataFileFieldTXTColumnName"] = item.Attribute("label").Value;
                dr["DataFileFieldDBFColumnName"] = item.Attribute("code").Value;
                dr["DataFileFieldColumnNameDigit"] = item.Attribute("tlength").Value;
                dr["DataFileFieldColumnValueDigit"] = item.Attribute("vlength").Value;
                dr["DataFileFieldColumnValueAccuracy"] = item.Attribute("precision").Value;
                dr["DataFileFieldAlignment"] = item.Attribute("align").Value;
                dr["DataFileFieldIsOut"] = item.Attribute("isout").Value;
                dr["DataFileFieldNotNull"] = item.Attribute("notnull").Value;
                dr["DataFileFieldCalculationSymbols"] = item.Attribute("express").Value;
                dr["DataFileFieldFixedValue"] = item.Attribute("FixValue").Value;
                dr["DataFileFieldIsSummary"] = item.Attribute("IsSum").Value;
                dr["DataFileFieldIsComplementCharacter"] = item.Attribute("padstr").Value;
                dr["DataFileFieldIsFiledIndex"] = item.Attribute("colIndex").Value;
                dr["DataFileFieldIsDefaultValue"] = item.Attribute("default").Value;
                dr["DataFileFieldIsAbsoluteValue"] = item.Attribute("isAbs").Value;

                dr["DataFileFieldIsAbsoluteValueOut"] = (item.LastAttribute.Name.Equals("isAbs_output")) ? (item.Attribute("isAbs_output").Value) : ("");
                //dr["DataFileFieldIsAbsoluteValueOut"] = item.Attribute("isAbs_output").Value;


                dt.Rows.Add(dr);
            }

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
            dt.Columns.Add("DataFilterConditionsNo", typeof(System.String));
            dt.Columns.Add("DataFilterConditionsColumnName", typeof(System.String));
            dt.Columns.Add("DataFilterConditionsColumnIndex", typeof(System.String));
            dt.Columns.Add("DataFilterConditionseConditionvalue", typeof(System.String));
            dt.Columns.Add("DataFilterConditionseConditionalSymbol", typeof(System.String));

            foreach (XElement item in xml.Nodes())
            {
                DataRow dr = dt.NewRow();
                if (item.Name == "filter")
                {
                    dr["DataFilterConditionsNo"] = item.Attribute("filtId").Value;
                    dr["DataFilterConditionsColumnName"] = item.Attribute("colname").Value;
                    dr["DataFilterConditionsColumnIndex"] = item.Attribute("colIndex").Value;
                    dr["DataFilterConditionseConditionvalue"] = item.Attribute("value").Value;
                    dr["DataFilterConditionseConditionalSymbol"] = item.Attribute("andor").Value;

                    dt.Rows.Add(dr);
                }
                
            }
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

            foreach (XElement item in xml.Nodes())
            {
                DataRow dr = dt.NewRow();
                if (item.Name == "dict")
                {
                    dr["DataDictionaryNo"] = item.Attribute("dictid").Value;
                    dr["DataDictionarySourceValue"] = item.Attribute("src").Value;
                    dr["DataDictionaryTargetValue"] = item.Attribute("tag").Value;
                  
                    dt.Rows.Add(dr);
                }

            }
            return dt;
        }

    }
}
