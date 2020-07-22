using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;
using System.Collections.Specialized;


namespace KS.DataManage.Utils
{
    //using DispatchFileKey = String;
    public class DispatchFile
    {
        public DispatchFile(string seatNo, string fileType, string fileExtension, bool isSpecific, int contentSeparateType, string contentSeparateString, string convertSeparateString, string moveheadFilter, int moveHeadRowsCount, int moveCustomcount, int columnTextRowIndex, string breakRowFlag, string endflag, int matchType, string matchRule, List<DispatchColumn> columns = null, List<Column> manalColumns = null, int readRowType = 0, string addPlusValue = "")
        {
            SeatNo = seatNo;
            FileType = fileType;
            FileExtension = fileExtension;
            IsSpecific = isSpecific;
            ContentSeparateType = contentSeparateType;
            ContentSeparateString = contentSeparateString;
            ConvertSeparateString = convertSeparateString;
            MoveheadFilter = moveheadFilter;
            MoveHeadrowsCount = moveHeadRowsCount;
            MoveCustomcount = moveCustomcount;
            ColumnTextRowIndex = columnTextRowIndex;
            Breakrowflag = breakRowFlag;
            Endflag = endflag;
            MatchType = matchType;
            MatchRule = matchRule;
            Columns = columns;
            ManalColumns = manalColumns;
            ReadRowType = readRowType;
            AddPlusValue = addPlusValue;
        }
        //public string DispatchType;
        public string SeatNo;              //席位代码
        public string FileType;            //
        public string FileExtension;       //文件后缀名
        public bool IsSpecific;            //是否需要特殊处理
        public int ContentSeparateType;     //内容分隔类型:0-空格分隔,1-特殊字符分隔,2-长度分隔
        public string ContentSeparateString;//内容分隔字符串
        public string ConvertSeparateString;//转换后的内容分隔字符串
        public string MoveheadFilter;       //文件头筛选条件
        public int MoveHeadrowsCount;       //除去文件头部行数
        public int MoveCustomcount;         //除去列名和内容之间的多余行数
        public int ColumnTextRowIndex;      //列标题所在的行号
        public string Breakrowflag;         //跳过行标志
        public string Endflag;         //文件内容结束标志
        public int MatchType;              //匹配类型:0-文件名匹配;1-文件标题匹配;2-文件列名匹配(顺序)
        public int ReadRowType;           //读取行的方式ReadRowType:0-以列头的右边为该列的终点  1-以下一列的开始作为上一列的结束进行读取
        public string MatchRule;         //匹配规则
        public List<DispatchColumn> Columns;  //列集合
        public List<Column> ManalColumns;     //自定义列集合，处理没有列的表格
        public string AddPlusValue;    //添加额外列值
    }

    public class DispatchColumn
    {
        public DispatchColumn(string columnName, int columnIndex, bool isEnum, Dictionary<string, string> enumKeyValueDic, bool isHaveDefaultValue, string defaultValue, string replaceValue, string assValue, bool needSplit)
        {
            this.ColumnName = columnName;
            this.ColumnIndex = columnIndex;
            this.IsEnum = isEnum;
            EnumKeyValueDic = enumKeyValueDic;
            this.IsHaveDefaultValue = isHaveDefaultValue;
            this.DefaultValue = defaultValue;
            this.ReplaceValue = replaceValue;
            this.AssValue = assValue;
            this.NeedSplit = needSplit;
        }
        public string ColumnName;
        public int ColumnIndex;
        public bool IsEnum;
        public Dictionary<string, string> EnumKeyValueDic;
        public bool IsHaveDefaultValue;
        public string DefaultValue;
        public string ReplaceValue;
        public string AssValue;
        public bool NeedSplit;//用来处理列名连在一起的情况
    }

    public static class DispatchFileConfig
    {
        private static Dictionary<string, DispatchFile> _dispatchFileDictionary = new Dictionary<string, DispatchFile>();



        //读配置文件到其中
        public static void Init()
        {
            string rule = "";
            var query_where1 = from a in _dispatchFileDictionary.Values
                               where rule.EndsWith(a.MatchRule)
                               select a;

            string dispatchConfigFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Config\ClearFileConfig.xml");
            if (!File.Exists(dispatchConfigFileName))
            {
                throw new Exception(string.Format("数据分发配置文件 {0} 不存在！", dispatchConfigFileName));
            }

            _dispatchFileDictionary.Clear();
            try
            {

                XDocument configDocument = XDocument.Load(dispatchConfigFileName);
                XElement configRoot = configDocument.Root;
                foreach (XElement dispType in configRoot.Elements())
                {
                    string seatNo = dispType.Attribute("seatno").Value;
                    foreach (XElement dispFile in dispType.Elements())
                    {
                        string fileType = dispFile.Attribute("FileType") != null ? dispFile.Attribute("FileType").Value : null;
                        string fileExtension = dispFile.Attribute("fileextension") != null ? dispFile.Attribute("fileextension").Value : null;
                        bool isSpecific = dispFile.Attribute("isspecific") != null ? dispFile.Attribute("isspecific").Value.ToLower() == "true" ? true : false : false;
                        int contentSeparateType = dispFile.Attribute("contentseparatetype") != null ? Int32.Parse(dispFile.Attribute("contentseparatetype").Value) : 0;
                        string contentSeparateString = dispFile.Attribute("contentseparatestring") != null ? dispFile.Attribute("contentseparatestring").Value : null;
                        string convertSeparateString = dispFile.Attribute("convertseparatestring") != null ? dispFile.Attribute("convertseparatestring").Value : null;
                        string moveheadFilter = dispFile.Attribute("moveheadFilter") != null ? dispFile.Attribute("moveheadFilter").Value : null;
                        int moveHeadRowsCount = dispFile.Attribute("moveheadrowscount") != null ? Int32.Parse(dispFile.Attribute("moveheadrowscount").Value) : 1;
                        int moveCustomcount = dispFile.Attribute("movecustomcount") != null ? Int32.Parse(dispFile.Attribute("movecustomcount").Value) : 0;
                        int columnTextRowIndex = dispFile.Attribute("columntextrowindex") != null ? Int32.Parse(dispFile.Attribute("columntextrowindex").Value) : 0;
                        string breakRowFlag = dispFile.Attribute("breakrowflag") != null ? dispFile.Attribute("breakrowflag").Value : null;
                        string endFlag = dispFile.Attribute("endflag") != null ? dispFile.Attribute("endflag").Value : null;
                        int readRowType = dispFile.Attribute("readrowtype") != null ? Int32.Parse(dispFile.Attribute("readrowtype").Value) : 0;
                        string matchRule = "";
                        string addPlusValue = dispFile.Attribute("AddPlusValue") != null ? dispFile.Attribute("AddPlusValue").Value : null;
                        List<DispatchColumn> columnList = null;
                        List<Column> manalColumnList = null;
                        int matchType = 0;


                        foreach (XElement dispConfig in dispFile.Elements())
                        {
                            switch (dispConfig.Name.ToString())
                            {
                                case "MatchType": matchType = Convert.ToInt32(dispConfig.Value); break;
                                case "MatchRule": matchRule = dispConfig.Value; break;
                                case "Columns":
                                    {
                                        columnList = new List<DispatchColumn>();
                                        string columnName = "", defaultValue = null, replaceValue = "", assValue = "";
                                        bool isEnum, isHaveDefaultValue, NeedSplit;
                                        int columnIndex;
                                        Dictionary<string, string> enumKeyValueDic = null;
                                        foreach (XElement column in dispConfig.Elements())
                                        {
                                            replaceValue = "";
                                            assValue = "";
                                            defaultValue = null;
                                            NeedSplit = false;
                                            columnName = column.Attribute("Name").Value;
                                            columnIndex = Int32.Parse(column.Attribute("Index").Value);
                                            isEnum = column.Attribute("IsEnum").Value == "true";
                                            if (column.Attribute("NeedSplit") != null)
                                                NeedSplit = column.Attribute("NeedSplit").Value == "true";

                                            isHaveDefaultValue = column.Attribute("IsHaveDefaultValue").Value == "true";
                                            if (isHaveDefaultValue)
                                            {
                                                defaultValue = column.Attribute("DefaultValue").Value;
                                                if (column.Attribute("ReplaceValue") != null)
                                                {
                                                    replaceValue = column.Attribute("ReplaceValue").Value;
                                                }
                                                if (column.Attribute("AssValue") != null)
                                                {
                                                    assValue = column.Attribute("AssValue").Value;
                                                }

                                            }

                                            if (isEnum)
                                            {
                                                enumKeyValueDic = new Dictionary<string, string>();
                                                foreach (var enums in column.Elements())
                                                {
                                                    foreach (var enumItem in enums.Elements())
                                                    {
                                                        string key = enumItem.Attribute("key").Value;
                                                        string value = enumItem.Attribute("value").Value;
                                                        enumKeyValueDic.Add(key, value);
                                                    }
                                                }
                                            }

                                            columnList.Add(new DispatchColumn(columnName, columnIndex, isEnum, enumKeyValueDic, isHaveDefaultValue, defaultValue, replaceValue, assValue, NeedSplit));
                                        }

                                        break;
                                    }

                                case "ManalColumns":
                                    {
                                        manalColumnList = new List<Column>();
                                        string columnName = "";
                                        int columnIndex, amendatoryStartPosition, lastpos, chineseCharactorsCount;
                                        foreach (XElement manalcolumn in dispConfig.Elements())
                                        {
                                            columnName = manalcolumn.Attribute("Name").Value;
                                            columnIndex = Int32.Parse(manalcolumn.Attribute("Index").Value);
                                            amendatoryStartPosition = Int32.Parse(manalcolumn.Attribute("amendatory").Value);
                                            lastpos = Int32.Parse(manalcolumn.Attribute("lastpos").Value);
                                            chineseCharactorsCount = Int32.Parse(manalcolumn.Attribute("chineseCharactorsCount").Value);
                                            manalColumnList.Add(new Column(columnName, columnIndex, amendatoryStartPosition, lastpos, chineseCharactorsCount));
                                        }

                                        break;
                                    }

                                default: break;
                            }
                        }
                        _dispatchFileDictionary.Add(fileType,
                                new DispatchFile(seatNo, fileType, fileExtension, isSpecific, contentSeparateType, contentSeparateString, convertSeparateString, moveheadFilter, moveHeadRowsCount, moveCustomcount, columnTextRowIndex, breakRowFlag, endFlag, matchType, matchRule, columnList, manalColumnList, readRowType, addPlusValue));
                    }
                }
            }
            catch (System.Exception ex)
            {
                //FuturesMessageBox.ShowError(string.Format("读取数据分发配置文件失败:{0}！", ex.Message));
                throw new Exception(string.Format("读取数据分发配置文件失败:{0}！", ex.Message));
            }
        }

        public static void Init(string type, string seatno)
        {
            string rule = "";
            var query_where1 = from a in _dispatchFileDictionary.Values
                               where rule.EndsWith(a.MatchRule)
                               select a;

            string dispatchConfigFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Config\ClearFileConfig.xml");
            if (!File.Exists(dispatchConfigFileName))
            {
                throw new Exception(string.Format("数据分发配置文件 {0} 不存在！", dispatchConfigFileName));
            }

            _dispatchFileDictionary.Clear();
            try
            {

                XDocument configDocument = XDocument.Load(dispatchConfigFileName);
                XElement configRoot = configDocument.Root;
                foreach (XElement dispType in configRoot.Elements())
                {
                    string DisPatchType = dispType.Attribute("value").Value;
                    if (DisPatchType == type)
                    {
                        string seatNo = dispType.Attribute("seatno").Value;//seatno;
                        foreach (XElement dispFile in dispType.Elements())
                        {
                            string fileType = dispFile.Attribute("FileType") != null ? dispFile.Attribute("FileType").Value : null;
                            string fileExtension = dispFile.Attribute("fileextension") != null ? dispFile.Attribute("fileextension").Value : null;
                            bool isSpecific = dispFile.Attribute("isspecific") != null ? dispFile.Attribute("isspecific").Value.ToLower() == "true" ? true : false : false;
                            int contentSeparateType = dispFile.Attribute("contentseparatetype") != null ? Int32.Parse(dispFile.Attribute("contentseparatetype").Value) : 0;
                            string contentSeparateString = dispFile.Attribute("contentseparatestring") != null ? dispFile.Attribute("contentseparatestring").Value : null;
                            string convertSeparateString = dispFile.Attribute("convertseparatestring") != null ? dispFile.Attribute("convertseparatestring").Value : null;
                            string moveheadFilter = dispFile.Attribute("moveheadFilter") != null ? dispFile.Attribute("moveheadFilter").Value : null;
                            int moveHeadRowsCount = dispFile.Attribute("moveheadrowscount") != null ? Int32.Parse(dispFile.Attribute("moveheadrowscount").Value) : 1;
                            int moveCustomcount = dispFile.Attribute("movecustomcount") != null ? Int32.Parse(dispFile.Attribute("movecustomcount").Value) : 0;
                            int columnTextRowIndex = dispFile.Attribute("columntextrowindex") != null ? Int32.Parse(dispFile.Attribute("columntextrowindex").Value) : 0;
                            string breakRowFlag = dispFile.Attribute("breakrowflag") != null ? dispFile.Attribute("breakrowflag").Value : null;
                            string endFlag = dispFile.Attribute("endflag") != null ? dispFile.Attribute("endflag").Value : null;
                            int readRowType = dispFile.Attribute("readrowtype") != null ? Int32.Parse(dispFile.Attribute("readrowtype").Value) : 0;
                            string matchRule = "";
                            string addPlusValue = dispFile.Attribute("AddPlusValue") != null ? dispFile.Attribute("AddPlusValue").Value : null;
                            List<DispatchColumn> columnList = null;
                            List<Column> manalColumnList = null;
                            int matchType = 0;


                            foreach (XElement dispConfig in dispFile.Elements())
                            {
                                switch (dispConfig.Name.ToString())
                                {
                                    case "MatchType": matchType = Convert.ToInt32(dispConfig.Value); break;
                                    case "MatchRule": matchRule = dispConfig.Value; break;
                                    case "Columns":
                                        {
                                            columnList = new List<DispatchColumn>();
                                            string columnName = "", defaultValue = null, replaceValue = "", assValue = "";
                                            bool isEnum, isHaveDefaultValue, NeedSplit;
                                            int columnIndex;
                                            Dictionary<string, string> enumKeyValueDic = null;
                                            foreach (XElement column in dispConfig.Elements())
                                            {
                                                replaceValue = "";
                                                assValue = "";
                                                defaultValue = null;
                                                NeedSplit = false;
                                                columnName = column.Attribute("Name").Value;
                                                columnIndex = Int32.Parse(column.Attribute("Index").Value);
                                                isEnum = column.Attribute("IsEnum").Value == "true";
                                                if (column.Attribute("NeedSplit") != null)
                                                    NeedSplit = column.Attribute("NeedSplit").Value == "true";

                                                isHaveDefaultValue = column.Attribute("IsHaveDefaultValue").Value == "true";
                                                if (isHaveDefaultValue)
                                                {
                                                    defaultValue = column.Attribute("DefaultValue").Value;
                                                    if (column.Attribute("ReplaceValue") != null)
                                                    {
                                                        replaceValue = column.Attribute("ReplaceValue").Value;
                                                    }
                                                    if (column.Attribute("AssValue") != null)
                                                    {
                                                        assValue = column.Attribute("AssValue").Value;
                                                    }

                                                }

                                                if (isEnum)
                                                {
                                                    enumKeyValueDic = new Dictionary<string, string>();
                                                    foreach (var enums in column.Elements())
                                                    {
                                                        foreach (var enumItem in enums.Elements())
                                                        {
                                                            string key = enumItem.Attribute("key").Value;
                                                            string value = enumItem.Attribute("value").Value;
                                                            enumKeyValueDic.Add(key, value);
                                                        }
                                                    }
                                                }

                                                columnList.Add(new DispatchColumn(columnName, columnIndex, isEnum, enumKeyValueDic, isHaveDefaultValue, defaultValue, replaceValue, assValue, NeedSplit));
                                            }

                                            break;
                                        }

                                    case "ManalColumns":
                                        {
                                            manalColumnList = new List<Column>();
                                            string columnName = "";
                                            int columnIndex, amendatoryStartPosition, lastpos, chineseCharactorsCount;
                                            foreach (XElement manalcolumn in dispConfig.Elements())
                                            {
                                                columnName = manalcolumn.Attribute("Name").Value;
                                                columnIndex = Int32.Parse(manalcolumn.Attribute("Index").Value);
                                                amendatoryStartPosition = Int32.Parse(manalcolumn.Attribute("amendatory").Value);
                                                lastpos = Int32.Parse(manalcolumn.Attribute("lastpos").Value);
                                                chineseCharactorsCount = Int32.Parse(manalcolumn.Attribute("chineseCharactorsCount").Value);
                                                manalColumnList.Add(new Column(columnName, columnIndex, amendatoryStartPosition, lastpos, chineseCharactorsCount));
                                            }

                                            break;
                                        }

                                    default: break;
                                }
                            }
                            _dispatchFileDictionary.Add(fileType,
                                    new DispatchFile(seatNo, fileType, fileExtension, isSpecific, contentSeparateType, contentSeparateString, convertSeparateString, moveheadFilter, moveHeadRowsCount, moveCustomcount, columnTextRowIndex, breakRowFlag, endFlag, matchType, matchRule, columnList, manalColumnList, readRowType, addPlusValue));
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                //FuturesMessageBox.ShowError(string.Format("读取数据分发配置文件失败:{0}！", ex.Message));
                throw new Exception(string.Format("读取数据分发配置文件失败:{0}！", ex.Message));
            }
        }


        public static DispatchFile GetDispatchFile(string fileType)
        {
            if (_dispatchFileDictionary.ContainsKey(fileType))
            {
                return _dispatchFileDictionary[fileType];
            }
            return null;
        }

        /// <summary>
        /// 根据席位编码，本地文件名称获取相应的配置信息
        /// </summary>
        /// <param name="seatNo"></param>
        /// <param name="sourceFileName"></param>
        /// <returns></returns>
        public static DispatchFile GetDispatchFile(string seatNo, string sourceFileName)
        {
            DispatchFile dispatchFile = null;
            string name = Path.GetFileNameWithoutExtension(sourceFileName);

            //Path.GetExtension
            //StringComparison
            var query = from a in _dispatchFileDictionary.Values
                        where a.SeatNo == seatNo && name.IndexOf(a.MatchRule) > 0
                        select a;

            foreach (var item in query)
            {
                DispatchFile tmpDispatchFile = item as DispatchFile;
                if (tmpDispatchFile != null && tmpDispatchFile.MatchType == 4)//matchtype==4为去除数字后全字匹配
                {
                    name = System.Text.RegularExpressions.Regex.Replace(name, @"\d", "");
                    if (name != tmpDispatchFile.MatchRule)
                        tmpDispatchFile = null;

                }
                if (tmpDispatchFile != null)
                    dispatchFile = tmpDispatchFile;
            }

            return dispatchFile;
        }

        //根据文件名、文件标题、列名等获取数据分发类型
        public static string GetDispatchFileType(string fileName, string fileCaption, string colNames)
        {
            foreach (var dispFile in _dispatchFileDictionary)
            {
                DispatchFile dispatchFile = dispFile.Value;
                if (dispatchFile.MatchRule.Trim() != "")
                {
                    if ((dispatchFile.MatchType == 0 && fileName.Contains(dispatchFile.MatchRule))   //文件名包含匹配
                        || (dispatchFile.MatchType == 1 && string.Compare(dispatchFile.MatchRule, fileCaption, true) == 0)  //文件标题匹配
                        || (dispatchFile.MatchType == 2 && string.Compare(dispatchFile.MatchRule, colNames, true) == 0)) //文件列名匹配
                    {
                        return dispFile.Key;
                    }
                }
            }

            return "";
        }
    }


    /// <summary>
    /// 
    /// </summary>
    public class DispatchFileInfo
    {
        //席位结算文件数据库配置信息92010101
        public string SeatCode;
        public string DispatchFileType;
        public string DataIFFileName;
        public string TableName;
        public string IsForceDispatch;
        public string Separator;
        public string DataIFColumnsStr;

        //席位结算文件本地配置信息
        public DispatchFile DispFile
        {
            get
            {
                DispatchFile dispFile = DispatchFileConfig.GetDispatchFile(DispatchFileType);
                if (dispFile == null)
                {
                    throw new Exception(string.Format("配置项 {0} 缺失！", DispatchFileType));
                }
                return dispFile;
            }
        }

        //本地文件信息，跟日期有关
        public string SourceFileName;
        public string ConvertFileName;
        public bool FileConverted;
    }

    public static class DispatchFileInfoConfig
    {
        private static Dictionary<string, DispatchFileInfo> _dispatchFileInfoDictionary = new Dictionary<string, DispatchFileInfo>();
        private static string DispFileInfoKey(string seatCode, string dispType)
        {
            return seatCode + "#" + dispType.ToUpper();
        }

        public static void AddDispatchFileInfo(DispatchFileInfo dispFileInfo)
        {
            if (string.IsNullOrWhiteSpace(dispFileInfo.SeatCode) || string.IsNullOrWhiteSpace(dispFileInfo.DispatchFileType))
            {
                return;
            }

            if (_dispatchFileInfoDictionary.ContainsKey(DispFileInfoKey(dispFileInfo.SeatCode, dispFileInfo.DispatchFileType)))
            {
                //throw new Exception(string.Format("唯一索引 {0} 已存在", dispFileKey.DispatchFileType));
                return;
            }
            _dispatchFileInfoDictionary.Add(DispFileInfoKey(dispFileInfo.SeatCode, dispFileInfo.DispatchFileType), dispFileInfo);
        }

        public static void Clear()
        {
            _dispatchFileInfoDictionary.Clear();
        }

        public static DispatchFileInfo GetDispatchFileInfo(string seatCode, string dispType)
        {
            if (_dispatchFileInfoDictionary.ContainsKey(DispFileInfoKey(seatCode, dispType)))
            {
                return _dispatchFileInfoDictionary[DispFileInfoKey(seatCode, dispType)];
            }

            return null;
        }

        public static List<DispatchFileInfo> GetDispatchFileInfoList(string seatCode)
        {
            List<DispatchFileInfo> dispFileInfoList = new List<DispatchFileInfo>();
            foreach (var dispFile in _dispatchFileInfoDictionary)
            {
                DispatchFileInfo dispFileInfo = dispFile.Value;
                if (dispFileInfo.SeatCode == seatCode)
                {
                    dispFileInfoList.Add(dispFileInfo);
                }
            }

            return dispFileInfoList;
        }


        public static void SetDispatchFileName(string seatCode, string dispType, string srcFileName, string destFileName)
        {
            DispatchFileInfo dispFileInfo = GetDispatchFileInfo(seatCode, dispType);
            if (dispFileInfo != null)
            {
                dispFileInfo.SourceFileName = srcFileName;
                dispFileInfo.ConvertFileName = destFileName;
                dispFileInfo.FileConverted = true;
            }
        }

        public static bool CheckDispatchFileConverted(string seatCode)
        {
            foreach (var dispFile in _dispatchFileInfoDictionary)
            {
                DispatchFileInfo dispFileInfo = dispFile.Value;
                if (dispFileInfo.SeatCode == seatCode && dispFileInfo.FileConverted == false)
                {
                    return false;
                }
            }

            return true;
        }

        public static void InitDispatchFileName()
        {
            foreach (var dispFile in _dispatchFileInfoDictionary)
            {
                DispatchFileInfo dispFileInfo = dispFile.Value;
                dispFileInfo.SourceFileName = "";
                dispFileInfo.ConvertFileName = "";
                dispFileInfo.FileConverted = false;
            }
        }

    }


}
