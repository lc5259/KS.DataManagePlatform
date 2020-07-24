using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;


namespace KS.DataManage.Utils
{
    public class Column
    {
        public Column(string name, int index, int amendatoryStartPosition, int chineseCharactorsCount)
        {
            this.Name = name;
            this.Index = index;
            this.AmendatoryStartPosition = amendatoryStartPosition;
            this.ChineseCharactorsCount = chineseCharactorsCount;
        }
        public Column(string name, int index, int amendatoryStartPosition, int lastPosition, int chineseCharactorsCount)
        {
            this.Name = name;
            this.Index = index;
            this.AmendatoryStartPosition = amendatoryStartPosition;
            this.LastPosition = lastPosition;
            this.ChineseCharactorsCount = chineseCharactorsCount;
        }
        public string Name;
        public int Index;

        public int AmendatoryStartPosition;
        public int LastPosition;
        /// <summary>
        /// 一个中文字符为2个空格
        /// </summary>
        public int ChineseCharactorsCount;
    }

    public class TFileReader : IDisposable
    {
        const char SPACEINGCHAR = ' ';
        const char BACKSLASHR = '\r';
        const char BACKSLASHN = '\n';
        const string ENTERSTING = "|\n";
        const int MAXCOLUMNNAMELENGTH = 255;
        const string PREVIOUS = "previous";
        const string PREVIOUSOPPOSITE = "previousopposite";


        public static DateTime NullDateTime = new DateTime(1000, 01, 01);  // odbc中空日期对应的转换日期  
        protected FileInfo _fileInfo = null;
        protected string _fileName = null;  //文件名

        protected System.Text.Encoding _encoding = System.Text.Encoding.Default;
        protected System.IO.FileStream _fileStream = null;
        protected System.IO.BinaryReader _binaryReader = null;
        protected System.IO.StreamReader _streamReader = null;

        private bool _isFileOpened;
        public bool IsFileOpened
        {
            get
            {
                return this._isFileOpened;
            }
        }

        protected string _dispatchFileType = null;
        public string DispatchFileType
        {
            get
            {
                return this._dispatchFileType;
            }
        }

        protected string _csvName = null;
        public string CSVName
        {
            get
            {
                return this._csvName;
            }
        }

        protected string _txtName = null;
        public string TXTName
        {
            get
            {
                return this._txtName;
            }
        }

        public TFileReader()
        {

        }
        public TFileReader(string fileName, string encodingName = "")
        {
            this._fileName = fileName.Trim();
            this._encoding = GetEncoding(encodingName);
            this.CheckFile();

            try
            {
                this.OpenFile();
                //下面这步用不着。现在都是通过自动匹配找到对应的配置信息项
                //this.GetDispatchFileType();
            }
            finally
            {
                this.CloseStream();  //不能CloseFile,否则IsFileOpened为False后一些属性无效
            }
        }

        void System.IDisposable.Dispose()
        {
            this.Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing == true)
            {
                this.CloseFile();
            }
        }

        private void CloseStream()
        {
            if (_fileStream != null)
            {
                _fileStream.Close();
                _fileStream = null;
            }

            if (_binaryReader != null)
            {
                _binaryReader.Close();
                _binaryReader = null;
            }

            if (_streamReader != null)
            {
                _streamReader.Close();
                _streamReader = null;
            }
        }

        public virtual void CloseFile()
        {
            this.CloseStream();
            _isFileOpened = false;
        }

        public virtual void OpenFile()
        {
        }

        public virtual bool CheckFileExt()
        {
            return true;
        }

        public virtual void GetDispatchFileType()
        {
        }


        public void CheckFile()
        {
            if (string.IsNullOrEmpty(_fileName) == true)
            {
                throw new Exception("filename is empty or null.");
            }

            if (System.IO.File.Exists(_fileName) == false)
            {
                throw new Exception(this._fileName + " does not exist.");
            }

            this._fileInfo = new FileInfo(this._fileName);
            if (CheckFileExt() == false)
            {
                throw new Exception(string.Format("file extension of {0} is illegal to {1}.", this._fileName, this.GetType().Name));
            }
        }

        public void GetFileStream()
        {
            try
            {
                this._fileStream = File.Open(this._fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                this._binaryReader = new BinaryReader(this._fileStream, _encoding);
                this._streamReader = new StreamReader(this._fileStream, _encoding);
                this._isFileOpened = true;
            }
            catch (IOException)
            {
                throw new Exception(this._fileName + "文件被占用,无法进行操作");

            }
            catch
            {
                throw new Exception("fail to read  " + this._fileName + ".");
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="csvName"></param>
        /// <param name="addColumns"></param>
        /// <param name="separator"></param>
        public static void SaveDataTableToCSV(DataTable dataTable, string csvName, bool addTitle, string separator)
        {
            if (string.IsNullOrEmpty(csvName))
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(separator))
            {
                separator = ",";
            }

            if (!Directory.Exists(Path.GetDirectoryName(csvName)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(csvName));
            }

            FileStream fs = new FileStream(csvName, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);   //System.Text.Encoding.UTF8
            try
            {
                string title = "", content = "";
                if (addTitle)
                {
                    for (int i = 0; i < dataTable.Columns.Count; i++)
                    {
                        title += dataTable.Columns[i].ColumnName.ToString();
                        if (i < dataTable.Columns.Count - 1)
                        {
                            title += separator;
                        }
                    }
                    sw.WriteLine(title);
                }

                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    content = "";
                    for (int j = 0; j < dataTable.Columns.Count; j++)
                    {
                        content += dataTable.Rows[i][j].ToString();
                        if (j < dataTable.Columns.Count - 1)
                        {
                            content += separator;
                        }
                    }
                    sw.WriteLine(content);
                }
            }
            finally
            {
                sw.Close();
                fs.Close();
            }
        }

        public static void SaveDataTableToTXT(DispatchFile dispatchFile, DataTable dataTable, string txtName, bool addColumns)
        {
            if (string.IsNullOrEmpty(txtName))
            {
                return;
            }
            if (!Directory.Exists(Path.GetDirectoryName(txtName)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(txtName));
            }
            FileStream fs = new FileStream(txtName, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);   //System.Text.Encoding.UTF8
            try
            {
                string columns = "", content = "", columnName = "";
                if (addColumns)
                {
                    for (int i = 0; i < dataTable.Columns.Count; i++)
                    {
                        columns += dataTable.Columns[i].ColumnName.ToString();
                        if (i < dataTable.Columns.Count - 1)
                        {
                            columns += dispatchFile.ConvertSeparateString;
                        }
                    }
                    sw.WriteLine(columns);
                }

                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    content = "";
                    if (dispatchFile.FileType.Equals("cffex_Capital"))
                    {
                        //&& columnName.ToUpper().Equals("TRADEID")
                        content = dataTable.Rows[i]["ACCOUNTID"].ToString() + dispatchFile.ConvertSeparateString +
                            dataTable.Rows[i]["ITEMDESC"].ToString() + dispatchFile.ConvertSeparateString +
                            dataTable.Rows[i]["ITEMVALUE"].ToString() + dispatchFile.ConvertSeparateString;
                    }
                    else if (dispatchFile.FileType.Equals("cffex_NewCapital"))
                    {
                        content = dataTable.Rows[i]["ACCOUNTID"].ToString() + dispatchFile.ConvertSeparateString +
                            dataTable.Rows[i]["ITEMDESC"].ToString() + dispatchFile.ConvertSeparateString +
                            dataTable.Rows[i]["ITEMVALUE"].ToString() + dispatchFile.ConvertSeparateString;
                    }
                    else
                    {
                        for (int j = 0; j < dataTable.Columns.Count; j++)
                        {
                            columnName = dataTable.Columns[j].ColumnName;
                            DispatchColumn dispatchColumn = dispatchFile.Columns.Find(v => v.ColumnName.ToUpper() == columnName.ToUpper());
                            if (dispatchColumn != null && dispatchColumn.IsEnum)
                            {
                                content += dispatchColumn.EnumKeyValueDic[dataTable.Rows[i][j].ToString()];
                            }
                            else
                            {
                                if (dispatchColumn != null && dispatchColumn.IsHaveDefaultValue && content.Trim() == string.Empty && dispatchColumn.DefaultValue != null)
                                {
                                    content = dispatchColumn.DefaultValue;
                                }
                                else if (dispatchFile.FileType.Equals("cffex_Trade") && columnName.ToUpper().Equals("TRADEID"))
                                {
                                    content += dataTable.Rows[i][j].ToString().TrimStart('0');
                                }
                                else
                                {
                                    content += dataTable.Rows[i][j].ToString();
                                }
                            }

                            if (j < dataTable.Columns.Count - 1)
                            {
                                content += dispatchFile.ConvertSeparateString;
                            }
                        }
                    }

                    sw.Write(content + ENTERSTING);
                }
            }
            catch (Exception ex)
            {
               // FuturesLogService.Error(string.Format("{0}-{1}预处理出错！", dispatchFile.SeatNo, dispatchFile.MatchRule));
                //FuturesMessageBox.ShowError(string.Format("{0}-{1}预处理出错！", dispatchFile.SeatNo, dispatchFile.MatchRule));

            }
            finally
            {
                sw.Close();
                fs.Close();
            }
        }
   
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dispatchFile"></param>
        /// <param name="sourceFileInfo"></param>
        /// <param name="_txtName"></param>
        /// <returns>是否处理txt成功</returns>
        public static bool SaveTxtFileToTxt(DispatchFile dispatchFile, FileInfo sourceFileInfo, string _txtName = "")
        {
            if (!dispatchFile.IsSpecific)
            {
                if (!ConvertTxtFileToTXT(dispatchFile, sourceFileInfo, _txtName))
                    return false;
            }
            else if (dispatchFile.SeatNo.ToLower() == "czce")//特殊处理的郑州表
            {
                if (dispatchFile.MatchRule == "组合持仓表")
                {
                    if (!Convert_czce_comb_position_ToTxt(dispatchFile, sourceFileInfo, _txtName))
                        return false;
                }
                if (dispatchFile.MatchRule.Contains("资金表"))
                {
                    if (!Convert_czce_capital_ToTxt(dispatchFile, sourceFileInfo, _txtName))
                        return false;
                }
            }
            //20200608  大商所pg天然气合约处理bug
            if (dispatchFile.SeatNo.ToLower().Equals("dce") && dispatchFile.FileType.Equals("dce_opt_pos_dtl"))
            {
                if (string.IsNullOrWhiteSpace(_txtName))
                {
                    _txtName = string.Format(@"{0}\output\{1}.txt", sourceFileInfo.DirectoryName, dispatchFile.FileType);
                }
                string _txtNameTemp = _txtName + "copy";
                try
                {
                    File.Copy(_txtName, _txtNameTemp);
                    string[] templine = File.ReadAllLines(_txtName);
                    for (int i = 0; i < templine.Length; i++)
                    {
                        string[] line = templine[i].Split('@');

                        if (line[4].ToLower().StartsWith("pg") && line[4].Length <= ("m1909-P-2550").Length)
                        {
                            line[4] = line[4] + "0";
                        }
                        templine[i] = string.Join("@", line);
                    }
                    if (File.Exists(_txtName))
                    {
                        File.Delete(_txtName);
                    }
                    using (FileStream fs = new FileStream(_txtName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write))
                    {
                        StreamWriter sw = new StreamWriter(fs);
                        foreach (var item in templine)
                        {
                            sw.Write(item + "\n");
                        }
                        sw.Flush();
                        sw.Close();
                        fs.Close();
                    }

                    if (File.Exists(_txtNameTemp))
                    {
                        File.Delete(_txtNameTemp);
                    }
                }
                catch (Exception ex)
                {
                    //FuturesLogService.Error(ex.StackTrace);
                    throw;
                }
            }
            return true;
        }

        /// <summary>
        /// 写入一个字符串
        /// </summary>
        /// <param name="sw"></param>
        /// <param name="s"></param>
        /// <param name="contentIndex"></param>
        /// <param name="contentColumns"></param>
        private static void WriteContent(StreamWriter sw, string s, int contentIndex, int[] contentColumns)
        {
            sw.Write(s);
            contentColumns[contentIndex] = 1;
        }

        /// <summary>
        /// 写入一个字符
        /// </summary>
        /// <param name="sw"></param>
        /// <param name="c"></param>
        /// <param name="contentIndex"></param>
        /// <param name="contentColumns"></param>
        private static void WriteContent(StreamWriter sw, char c, int contentIndex, int[] contentColumns)
        {
            sw.Write(c);
            contentColumns[contentIndex] = 1;
        }

        /// <summary>
        /// 处理换行符
        /// </summary>
        /// <param name="c"></param>
        /// <param name="buff"></param>
        /// <param name="contentIndex"></param>
        /// <param name="isEmptyLine"></param>
        /// <param name="columnsCount"></param>
        /// <param name="rowIndex"></param>
        /// <param name="fileName"></param>
        /// <param name="sw"></param>
        /// <param name="sr"></param>
        /// <param name="isNeedGetDefaultValue"></param>
        /// <param name="contentColumns"></param>
        /// <param name="seperator"></param>
        /// <param name="columns"></param>
        /// <param name="dispatchColumns"></param>
        private static void DealNewLineChar(char c, char[] buff, int contentIndex, bool isEmptyLine, int columnsCount, int rowIndex, string fileName, StreamWriter sw, StreamReader sr, string addPlusValue = null, bool isNeedGetDefaultValue = false, int[] contentColumns = null, string seperator = null, List<Column> columns = null, List<DispatchColumn> dispatchColumns = null)
        {
            if (c == BACKSLASHR)
            {
                sr.Read(buff, 0, 1);//读取BACKSLASHN
            }

            if (!isEmptyLine)
            {
                if (isNeedGetDefaultValue)
                {
                    string value = GetContentDefaultValue(contentColumns, contentIndex, columnsCount, seperator, fileName, columns, dispatchColumns);
                    if (!string.IsNullOrEmpty(value))
                    {
                        sw.Write(value);
                    }
                    if (addPlusValue != null)
                    {
                        if (addPlusValue == "RowNum")
                        {
                            string addplus = seperator + rowIndex.ToString();
                            sw.Write(addplus);
                        }
                    }
                    sw.Write(ENTERSTING);
                }
                else
                {
                    //if (contentIndex != columnsCount - 1)有bug
                    //{
                    //    throw new Exception(string.Format("源文件\"{0}\",第{1}行的内容不全，但配置文件中未配置处理方法", fileName, rowIndex));
                    //}
                    if (addPlusValue != null)
                    {
                        if (addPlusValue == "RowNum")
                        {
                            string addplus = seperator + rowIndex.ToString();
                            sw.Write(addplus);
                        }
                    }
                    sw.Write(ENTERSTING);
                }


            }

        }

        /// <summary>
        /// 处理空格字符
        /// </summary>
        private static void DealSpaceChar(StreamWriter sw, int columnsCount, string seperator, ref int contentIndex, ref bool isBlankSpace)
        {
            if (!isBlankSpace)//遇到第一个空格，则写入分隔符
            {
                if (contentIndex + 1 < columnsCount)//最后一列不需要分隔符
                {
                    sw.Write(seperator);
                }
                contentIndex++;
            }
            isBlankSpace = true;
        }

        /// <summary>
        /// 处理列数据字典的转换
        /// </summary>
        private static bool DealColumnDictionary(StreamReader sr, StreamWriter sw, ref int contentIndex, string seperator, int i, int[] contentColumns, List<Column> columns, DispatchColumn dispatchColumn, string sourceFileName, int rowIndex, ref bool isNeedRead, ref char buff, ref int amendmentCharactorsCounnt)
        {
            bool isBreak = false;
            int charsLength = 0;
            char[] chars = new char[MAXCOLUMNNAMELENGTH];
            for (int j = 0; j < chars.Length; j++)
            {

                if (contentIndex + 1 < columns.Count && i + j + 1 + amendmentCharactorsCounnt == columns[contentIndex + 1].AmendatoryStartPosition)//判断该内容是否已经超过本列所在范围
                {
                    throw new Exception(string.Format("文件\"{0}\"中第{1}行第{2}列的内容超出了该列的最大范围，程序无法正确处理", sourceFileName, rowIndex, contentIndex + 1));
                }
                sr.Read(chars, j, 1);
                if (CheckChar.IsChineseCharactor(chars[j]))
                {
                    amendmentCharactorsCounnt++;
                    //if (chars[j] == '值' && contentIndex == 9 && dispatchColumn.ColumnName == "投/保")
                    //{
                    //    //上期所两列数据粘连特殊处理
                    //    buff = SPACEINGCHAR;
                    //    WriteContent(sw, dispatchColumn.EnumKeyValueDic["保值"], contentIndex, contentColumns);
                    //    sw.Write(seperator);
                    //    contentIndex++;
                    //    return false;
                    //}
                }
                if (contentIndex + 1 != columns.Count)
                {
                    if (chars[j] == SPACEINGCHAR)
                    {
                        //amendmentCharactorsCounnt += j;
                        charsLength = j;
                        isNeedRead = false;
                        break;
                    }
                }
                else//最后一列需要特殊处理
                {
                    if (chars[j] == SPACEINGCHAR)
                    {
                        charsLength = j;
                        isNeedRead = false;
                        sr.ReadLine();
                        break;
                    }
                    else if (chars[j] == BACKSLASHR)
                    {
                        charsLength = j;
                        sr.Read();//读取\n
                        break;
                    }
                    else if (chars[j] == BACKSLASHN)
                    {
                        charsLength = j;
                        break;
                    }
                }
            }

            string key = buff + new string(chars, 0, charsLength);
            buff = SPACEINGCHAR;

            if (dispatchColumn.EnumKeyValueDic.ContainsKey(key))
            {
                WriteContent(sw, dispatchColumn.EnumKeyValueDic[key], contentIndex, contentColumns);

                if (contentIndex + 1 == columns.Count)//一行结束了
                {
                    sw.Write(ENTERSTING);
                    isBreak = true;
                    //break;
                }
            }
            else
            {
                //WriteContent(sw, "", contentIndex, contentColumns);

                //if (contentIndex + 1 == columns.Count)//一行结束了
                //{
                //sw.Write(ENTERSTING);
                //isBreak = true;
                ////break;
                //}
                throw new Exception(string.Format("文件\"{0}\"中第{1}行第{2}列的内容：{3}是配置中数据字典中没有的key", sourceFileName, rowIndex, contentIndex + 1, key));
            }

            return isBreak;
        }


        /// <summary>
        /// 处理替换默认值
        /// </summary>
        private static bool DealReplaceValue(StreamReader sr, StreamWriter sw, int contentIndex, int i, int[] contentColumns, List<Column> columns, DispatchColumn dispatchColumn, string sourceFileName, int rowIndex, ref bool isNeedRead, ref char buff, ref int amendmentCharactorsCounnt)
        {
            bool isBreak = false;
            int charsLength = 0;
            char[] chars = new char[MAXCOLUMNNAMELENGTH];
            for (int j = 0; j < chars.Length; j++)
            {
                if (contentIndex + 1 < columns.Count && i + j + 1 + amendmentCharactorsCounnt > columns[contentIndex + 1].AmendatoryStartPosition)//判断该内容是否已经超过本列所在范围
                {
                    throw new Exception(string.Format("文件\"{0}\"中第{1}行第{2}列的内容超出了该列的最大范围，程序无法正确处理", sourceFileName, rowIndex, contentIndex + 1));
                }
                sr.Read(chars, j, 1);
                //if (chars[j].IsChineseCharactor())
                if (CheckChar.IsChineseCharactor(chars[j]))
                {
                    amendmentCharactorsCounnt++;
                }
                if (contentIndex + 1 != columns.Count)
                {
                    if (chars[j] == SPACEINGCHAR)
                    {
                        //amendmentCharactorsCounnt += j;
                        charsLength = j;
                        isNeedRead = false;
                        break;
                    }
                }
                else//最后一列需要特殊处理
                {
                    if (chars[j] == SPACEINGCHAR)
                    {
                        charsLength = j;
                        isNeedRead = false;
                        sr.ReadLine();
                        break;
                    }
                    else if (chars[j] == BACKSLASHR)
                    {
                        charsLength = j;
                        sr.Read();//读取\n
                        break;
                    }
                    else if (chars[j] == BACKSLASHN)
                    {
                        charsLength = j;
                        break;
                    }
                }
            }

            string replaceV = buff + new string(chars, 0, charsLength);
            buff = SPACEINGCHAR;

            if (dispatchColumn.ReplaceValue == replaceV || dispatchColumn.ReplaceValue == "*")
            {
                WriteContent(sw, dispatchColumn.DefaultValue, contentIndex, contentColumns);
            }
            else
            {
                WriteContent(sw, replaceV, contentIndex, contentColumns);
                //throw new Exception(string.Format("文件\"{0}\"中第{1}行第{2}列的内容：{3}不符合替换要求", sourceFileName, rowIndex, contentIndex + 1, replaceV));
            }
            if (contentIndex + 1 == columns.Count)//一行结束了
            {
                sw.Write(ENTERSTING);
                isBreak = true;

            }
            return isBreak;
        }


        /// <summary>
        /// 读取一个字符并统计中文字符
        /// </summary>
        /// <param name="sr"></param>
        /// <param name="buff"></param>
        /// <param name="isNeedRead"></param>
        /// <param name="amendmentCharactorsCounnt"></param>
        private static void ReadContent(StreamReader sr, char[] buff, ref bool isNeedRead, ref int amendmentCharactorsCounnt)
        {
            if (isNeedRead)
            {
                if (!sr.EndOfStream)
                {
                    sr.Read(buff, 0, 1);
                }
                else
                {
                    buff[0] = '\0';
                }
            }
            isNeedRead = true;
            if (CheckChar.IsChineseCharactor(buff[0])) 
            {
                amendmentCharactorsCounnt++;
            }
        }

        /// <summary>
        /// 处理结束和跳过标记
        /// isDeelEndFlag==true，则处理结束标记，为false则处理跳过标记
        /// </summary>
        private static bool DealEndFlagOrBreakFlag(bool isDeelEndFlag, StreamReader sr, StreamWriter sw, char c, string[] flags, int contentIndex, int[] contentColumns, int columnsCount, ref bool isNeedRead, ref bool isEndFlag)
        {
            bool isBreak = false;
           //// int findIndex = flags.FindIndex<string>(s => s == c.ToString());

           // if (!char.IsLetter(c) && !char.IsDigit(c) && !IsChineseCharactor(c))//假如结束标记是分隔符
           // {
           //     if (findIndex >= 0)//找到
           //     {
           //         if (isDeelEndFlag)
           //         {
           //             isEndFlag = true;
           //         }
           //         else
           //         {
           //             sr.ReadLine();//将该行剩余的读完
           //         }
           //         isBreak = true;
           //         //break;
           //     }
           //     else
           //     {
           //         WriteContent(sw, c, contentIndex, contentColumns);
           //     }
           // }
           // else//如果结束标记是中文，数字，字母等则需要完全匹配
           // {
           //     int charsLength = 0;
           //     char[] chars = new char[MAXCOLUMNNAMELENGTH];
           //     for (int j = 0; j < chars.Length; j++)
           //     {
           //         sr.Read(chars, j, 1);
           //         if (contentIndex + 1 != columnsCount)
           //         {
           //             if (chars[j] == SPACEINGCHAR)
           //             {
           //                 charsLength = j;
           //                 isNeedRead = false;
           //                 break;
           //             }
           //         }
           //         else//最后一列需要特殊处理
           //         {
           //             if (chars[j] == SPACEINGCHAR)
           //             {
           //                 charsLength = j;
           //                 isNeedRead = false;
           //                 sr.ReadLine();
           //                 break;
           //             }
           //             else if (chars[j] == BACKSLASHR)
           //             {
           //                 charsLength = j;
           //                 sr.Read();//读取\n
           //                 break;
           //             }
           //             else if (chars[j] == BACKSLASHN)
           //             {
           //                 charsLength = j;
           //                 break;
           //             }
           //         }
           //     }

           //     string match = c + new string(chars, 0, charsLength);
           //     c = SPACEINGCHAR;
           //     findIndex = flags.FindIndex(s => s == match);
           //     if (findIndex >= 0)//找到结束标记
           //     {
           //         if (isDeelEndFlag)
           //         {
           //             isEndFlag = true;
           //         }
           //         else
           //         {
           //             if (!isNeedRead)//假如匹配字符串之后还有字符，则需要将剩下的一行字符全读完，这样下次才会从下一行开始读取
           //             {
           //                 sr.ReadLine();
           //             }
           //         }
           //         isBreak = true;
           //         //break;
           //     }
           //     else
           //     {
           //         isNeedRead = false;//在上一个for循环中已经多读了一个空格，紧接着不需要再次读了，只需要用就可以了
           //         WriteContent(sw, match, contentIndex, contentColumns);
           //         if (contentIndex + 1 == columnsCount)//一行结束了
           //         {
           //             sw.Write(ENTERSTING);
           //             isBreak = true;
           //             //break;
           //         }

           //     }
           // }

            return isBreak = true;
        }

        private static bool DealEndFlagAndBreakFlag(StreamReader sr, StreamWriter sw, char c, string[] breakflags, string[] endflags, int contentIndex, int[] contentColumns, int columnsCount, ref bool isNeedRead, ref bool isEndFlag)
        {
            bool isBreak = false;

            //int findIndex0 = breakflags.IListExtentions.FindIndex<string>(s => s == c.ToString());
            //int findIndex1 = endflags.FindIndex<string>(s => s == c.ToString());
            //if (!char.IsLetter(c) && !char.IsDigit(c) && !IsChineseCharactor(c))//假如结束标记是分隔符
            //{
            //    if (findIndex0 >= 0)//找到
            //    {
            //        sr.ReadLine();//将该行剩余的读完
            //        isBreak = true;
            //        //break;
            //    }
            //    else
            //    {
            //        WriteContent(sw, c, contentIndex, contentColumns);
            //    }
            //    if (findIndex1 >= 0)//找到
            //    {

            //        isEndFlag = true;
            //        sr.ReadLine();//将该行剩余的读完
            //        isBreak = true;
            //    }
            //    else
            //    {
            //        WriteContent(sw, c, contentIndex, contentColumns);
            //    }

            //}
            //else//如果结束标记是中文，数字，字母等则需要完全匹配
            //{
            //    int charsLength = 0;
            //    char[] chars = new char[MAXCOLUMNNAMELENGTH];
            //    for (int j = 0; j < chars.Length; j++)
            //    {
            //        sr.Read(chars, j, 1);
            //        if (contentIndex + 1 != columnsCount)
            //        {
            //            if (chars[j] == SPACEINGCHAR)
            //            {
            //                charsLength = j;
            //                isNeedRead = false;
            //                break;
            //            }
            //        }
            //        else//最后一列需要特殊处理
            //        {
            //            if (chars[j] == SPACEINGCHAR)
            //            {
            //                charsLength = j;
            //                isNeedRead = false;
            //                sr.ReadLine();
            //                break;
            //            }
            //            else if (chars[j] == BACKSLASHR)
            //            {
            //                charsLength = j;
            //                sr.Read();//读取\n
            //                break;
            //            }
            //            else if (chars[j] == BACKSLASHN)
            //            {
            //                charsLength = j;
            //                break;
            //            }
            //        }
            //    }

            //    string match = c + new string(chars, 0, charsLength);
            //    c = SPACEINGCHAR;
            //    findIndex0 = breakflags.FindIndex(s => s == match);
            //    findIndex1 = endflags.FindIndex(s => s == match);
            //    if (findIndex1 >= 0)//找到结束标记
            //    {
            //        isEndFlag = true;
            //        sr.ReadLine();
            //        isBreak = true;
            //        return isBreak;
            //        //break;
            //    }
            //    if (findIndex0 >= 0)//找到结束标记
            //    {
            //        if (!isNeedRead)//假如匹配字符串之后还有字符，则需要将剩下的一行字符全读完，这样下次才会从下一行开始读取
            //        {
            //            sr.ReadLine();
            //        }
            //        isBreak = true;
            //        //break;
            //    }
            //    else
            //    {
            //        isNeedRead = false;//在上一个for循环中已经多读了一个空格，紧接着不需要再次读了，只需要用就可以了
            //        WriteContent(sw, match, contentIndex, contentColumns);
            //        if (contentIndex + 1 == columnsCount)//一行结束了
            //        {
            //            sw.Write(ENTERSTING);
            //            isBreak = true;
            //            //break;
            //        }

            //    }
            //}

            return isBreak =true;
        }


        /// <summary>
        /// 处理内容为空的列
        /// </summary>
        private static void DealEmptyContent(StreamWriter sw, DispatchFile dispatchFile, string seperator, string sourceFileName, string columnName, int[] contentColumns, ref int contentIndex)
        {
            //则认为该行列内容为空，设置为默认值
            int index = contentIndex;
            DispatchColumn dispatchColumn = dispatchFile.Columns.Find(v => v.ColumnIndex == index);
            if (dispatchColumn == null)
            {
                throw new Exception(string.Format("源文件\"{0}\",列\"{1}\"需要设置默认值，配置文件中没有配置该列", sourceFileName, columnName));
            }
            else
            {
                if (dispatchColumn.DefaultValue != null)
                {

                    string value = dispatchColumn.DefaultValue + seperator;
                    WriteContent(sw, value, contentIndex, contentColumns);
                    contentIndex++;
                }
                else if (dispatchColumn.DefaultValue == null && dispatchColumn.IsHaveDefaultValue == false)
                {
                    string value = string.Empty;
                    WriteContent(sw, value, contentIndex, contentColumns);
                    contentIndex++;
                }
                else
                {
                    throw new Exception(string.Format("源文件\"{0}\",列\"{1}\"需要设置默认值，配置文件中没有配置该列的默认值", sourceFileName, columnName));
                }
            }
        }

        private static bool ConvertTxtFileToTXT(DispatchFile dispatchFile, FileInfo sourceFileInfo, string _txtName = "")
        {
            bool isConvertSuccess = false;//是否转换成功

            if (string.IsNullOrWhiteSpace(_txtName))
            {
                _txtName = string.Format(@"{0}\output\{1}.txt", sourceFileInfo.DirectoryName, dispatchFile.FileType);
            }
            FileStream fs = null;
            StreamReader sr = null;
            StreamWriter sw = null;
            try
            {

                if (!Directory.Exists(Path.GetDirectoryName(_txtName)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(_txtName));
                }
                fs = new FileStream(_txtName, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                sr = new StreamReader(sourceFileInfo.FullName, Encoding.Default);// Encoding.UTF8);
                sw = new StreamWriter(fs, Encoding.UTF8);   //System.Text.Encoding.UTF8
                if (dispatchFile.ContentSeparateType == 1)//上期南华格式，把@替换为,就可以了,分割符为特殊字符的情况,现在已经需要做对应业务处理了
                {
                    SHFE_ConvertTxtFileToTXT(sw, sr, dispatchFile);
                }
                else
                {
                    #region //其他交易所席位格式
                    if (dispatchFile.MoveheadFilter != null)
                    {
                        //如果存在表头筛选条件，先筛选出表头位置
                        HeadFilter(sr, dispatchFile);
                    }
                    MoveHeadRows(sr, dispatchFile.MoveHeadrowsCount);//移动头部moveheadrowscount行
                    List<Column> columns = new List<Column>();
                    Column column = new Column("", 0, 0, 0);
                    int contentIndex = 0;
                    string seperator = dispatchFile.ConvertSeparateString;//分割符
                    bool isBlankSpace = false;//是否是空格
                    int amendmentCharactorsCounnt = 0;
                    char[] buff;
                    //读取文件内容所有列标题
                    if (dispatchFile.ManalColumns != null && dispatchFile.ManalColumns.Count > 0)
                    {
                        //对应的表格没有列名，用配置文件中的代替
                        foreach (Column col in dispatchFile.ManalColumns)
                        {
                            columns.Add(new Column(col.Name, col.Index, col.AmendatoryStartPosition, col.LastPosition, col.ChineseCharactorsCount));
                        }
                    }
                    else
                    {
                        GetColumns(sr, columns, dispatchFile);
                    }

                    //除去列名和内容之间的多余行数movecustomcount
                    if (dispatchFile.MoveCustomcount != 0)
                    {
                        MoveHeadRows(sr, dispatchFile.MoveCustomcount);
                    }
                    #region 读取内容
                    //该列没有值，为0，有值为1
                    int[] contentColumns = new int[255];  //最多255列
                                                          //读取内容，按照行循环来读取
                    int maxLineCharCount = columns[columns.Count - 1].AmendatoryStartPosition + MAXCOLUMNNAMELENGTH;
                    bool isEmptyLine = true;//该行是否有内容
                    int rowIndex = dispatchFile.ColumnTextRowIndex;
                    bool isEndFlag = false;//是否以某符号结尾
                    string[] endFlags = null;
                    string[] breakFlags = null;
                    if (dispatchFile.Endflag != null)
                    {
                        endFlags = dispatchFile.Endflag.Split('|');
                    }
                    if (dispatchFile.Breakrowflag != null)
                    {
                        breakFlags = dispatchFile.Breakrowflag.Split('|');

                    }
                    #region
                    Column contanctCol = columns.Find(x => x.Name == "合约代码");
                    //string currentDate = GlobalData.PlatformDateAsync;
                   // char currentyear = currentDate[2];
                    int ierror = 0;
                    try
                    {
                        while (!sr.EndOfStream && !isEndFlag)
                        {
                            ierror++;
                            if (ierror == 48)
                            {
                                System.Diagnostics.Trace.WriteLine(ierror);
                            }
                            System.Diagnostics.Trace.WriteLine(ierror);
                            InitIntArray(contentColumns, 0, columns.Count);
                            rowIndex++;
                            int currentLoc = 0;//用来记录处理到的位置
                            buff = new char[1];
                            amendmentCharactorsCounnt = 0;
                            contentIndex = 0;
                            isEmptyLine = true;
                            isBlankSpace = true;
                            bool isNeedRead = true;
                            for (int i = 0; i < maxLineCharCount; i++)
                            {

                                if (dispatchFile.ReadRowType == 0)// 以列头的右边为该列的终点
                                {
                                    if (buff[0] == SPACEINGCHAR)
                                    {
                                        //假如已经读到此列的结束位置还没有读取到内容(必须允许内容列右侧与表头右侧齐平，如上期所order表hb20180207）)
                                        if (contentIndex + 1 < columns.Count && i + amendmentCharactorsCounnt > columns[contentIndex].LastPosition)
                                        //if (contentIndex + 1 < columns.Count && i + amendmentCharactorsCounnt == columns[contentIndex].LastPosition)
                                        {
                                            //则认为该行列内容为空，设置为默认值
                                            DealEmptyContent(sw, dispatchFile, seperator, sourceFileInfo.FullName, columns[contentIndex].Name, contentColumns, ref contentIndex);
                                        }
                                    }
                                }
                                else if (dispatchFile.ReadRowType == 1)//以下一列的开始作为上一列的结束进行读取
                                {
                                    //假如已经读到下一列的开始位置的前一个位置还没有读取到内容(>号比=号处理边界问题更细)

                                    if (contentIndex + 1 < columns.Count && i + amendmentCharactorsCounnt > columns[contentIndex + 1].AmendatoryStartPosition)
                                    {
                                        //则认为该行列内容为空，设置为默认值
                                        DealEmptyContent(sw, dispatchFile, seperator, sourceFileInfo.FullName, columns[contentIndex].Name, contentColumns, ref contentIndex);
                                    }
                                }
                                ReadContent(sr, buff, ref isNeedRead, ref amendmentCharactorsCounnt);
                                if (buff[0] == BACKSLASHR || buff[0] == BACKSLASHN || buff[0] == '\0')
                                {
                                    if (dispatchFile.Columns != null && dispatchFile.Columns.Count == 0)
                                        DealNewLineChar(buff[0], buff, contentIndex, isEmptyLine, columns.Count, rowIndex, sourceFileInfo.FullName, sw, sr, dispatchFile.AddPlusValue, true, contentColumns, seperator, columns, dispatchFile.Columns);
                                    else
                                        DealNewLineChar(buff[0], buff, contentIndex, isEmptyLine, columns.Count, rowIndex, sourceFileInfo.FullName, sw, sr, dispatchFile.AddPlusValue, false, null, seperator, null, null);
                                    break;
                                }
                                if (i == 0)
                                {
                                    //因为sr读取后不能返回原索引再次读取，当breakflag与endflag都存在时必须同时读取判断


                                    int findIndex0 = -1;
                                    int findIndex1 = -1;
                                    //首先判断每行第一个是不是配置中需要跳过的字符
                                    //if (breakFlags != null)
                                    //{
                                    //    findIndex0 = breakFlags.FindIndex(s => s.StartsWith(buff[0].ToString()));

                                    //}
                                    ////判断每行第一个是不是配置中需要结束的字符
                                    //if (endFlags != null)
                                    //{
                                    //    findIndex1 = endFlags.FindIndex(s => s.StartsWith(buff[0].ToString()));
                                    //}

                                    if (findIndex0 > -1 && findIndex1 > -1)
                                    {
                                        if (DealEndFlagAndBreakFlag(sr, sw, buff[0], breakFlags, endFlags, contentIndex, contentColumns, columns.Count, ref isNeedRead, ref isEndFlag))
                                        {
                                            break;
                                        }
                                    }
                                    else if (findIndex0 > -1)
                                    {
                                        if (DealEndFlagOrBreakFlag(false, sr, sw, buff[0], breakFlags, contentIndex, contentColumns, columns.Count, ref isNeedRead, ref isEndFlag))
                                        {
                                            break;
                                        }
                                    }
                                    else if (findIndex1 > -1)
                                    {
                                        if (DealEndFlagOrBreakFlag(true, sr, sw, buff[0], endFlags, contentIndex, contentColumns, columns.Count, ref isNeedRead, ref isEndFlag))
                                        {
                                            break;
                                        }
                                    }


                                }
                                if (buff[0] != SPACEINGCHAR)//是否是空格
                                {
                                    isBlankSpace = false;
                                    isEmptyLine = false;

                                    DispatchColumn dispatchColumn = null;
                                    //判断有没有需要特殊处理的列
                                    if (dispatchFile.Columns != null && dispatchFile.Columns.Count != 0)
                                    {
                                        dispatchColumn = dispatchFile.Columns.Find(v => v.ColumnIndex == contentIndex);
                                    }

                                    //如果该列内容需是数据字典，则需要将该列内容读完才能匹配数据字典
                                    if (dispatchColumn != null && dispatchColumn.IsEnum && dispatchColumn.EnumKeyValueDic != null && dispatchColumn.EnumKeyValueDic.Count > 0)
                                    {
                                        if (DealColumnDictionary(sr, sw, ref contentIndex, seperator, i, contentColumns, columns, dispatchColumn, sourceFileInfo.FullName, rowIndex, ref isNeedRead, ref buff[0], ref amendmentCharactorsCounnt))
                                        {
                                            break;
                                        }
                                    }
                                    //如果该列内容需是替换数据，则需要将该列内容读完才能匹配
                                    else if (dispatchColumn != null && dispatchColumn.IsHaveDefaultValue && !dispatchColumn.IsEnum)
                                    {
                                        if (DealReplaceValue(sr, sw, contentIndex, i, contentColumns, columns, dispatchColumn, sourceFileInfo.FullName, rowIndex, ref isNeedRead, ref buff[0], ref amendmentCharactorsCounnt))
                                        {
                                            break;
                                        }
                                    }
                                    else if (contanctCol != null && contanctCol.Index == contentIndex && dispatchFile.SeatNo.ToLower() == "czce")
                                    {
                                        WriteContent(sw, buff[0], contentIndex, contentColumns);
                                        currentLoc++;

                                        //if (currentLoc == 2)
                                        // {
                                        //  WriteContent(sw, currentyear, contentIndex, contentColumns);

                                        // }
                                        continue;

                                    }

                                    else
                                    {
                                        WriteContent(sw, buff[0], contentIndex, contentColumns);
                                    }


                                }
                                else if (buff[0] == SPACEINGCHAR)
                                {
                                    DealSpaceChar(sw, columns.Count, seperator, ref contentIndex, ref isBlankSpace);
                                }
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        //FuturesMessageBox.ShowError(ex.Message);
                    }
                    #endregion


                    #endregion

                    #endregion
                }
                isConvertSuccess = true;


            }
            catch (Exception ex)
            {

               // FuturesLogService.Error(string.Format("{0}-{1}预处理出错！信息：{2}。", dispatchFile.SeatNo, dispatchFile.MatchRule, ex.Message));
               // FuturesMessageBox.ShowError(string.Format("{0}-{1}预处理出错！", dispatchFile.SeatNo, dispatchFile.MatchRule));

            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
                if (sw != null)
                {
                    sw.Close();
                }
                if (fs != null)
                {

                    fs.Close();
                }
                if (!isConvertSuccess)
                    File.Delete(_txtName);//处理错误则删除文件

            }
            return isConvertSuccess;
        }
        private static bool Convert_czce_comb_position_ToTxt(DispatchFile dispatchFile, FileInfo sourceFileInfo, string _txtName = "")
        {
            bool isConvertSuccess = false;//是否转换成功
            if (string.IsNullOrWhiteSpace(_txtName))
            {
                _txtName = string.Format(@"{0}\output\{1}.txt", sourceFileInfo.DirectoryName, dispatchFile.FileType);
            }
            FileStream fs = null;
            StreamReader sr = null;
            StreamWriter sw = null;
            try
            {
                if (!Directory.Exists(Path.GetDirectoryName(_txtName)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(_txtName));
                }
                fs = new FileStream(_txtName, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                sr = new StreamReader(sourceFileInfo.FullName, Encoding.Default);
                sw = new StreamWriter(fs, Encoding.UTF8);   //System.Text.Encoding.UTF8
                if (dispatchFile.ContentSeparateType == 1)//上期南华格式，把@替换为,就可以了,分割符为特殊字符的情况
                {
                    MoveHeadRows(sr, dispatchFile.MoveHeadrowsCount);
                    SHFE_ConvertTxtFileToTXT(sw, sr, dispatchFile);
                }
                else
                {
                    #region //其他交易所席位格式
                    if (dispatchFile.MoveheadFilter != null)
                    {
                        //如果存在表头筛选条件，先筛选出表头位置
                        HeadFilter(sr, dispatchFile);
                    }
                    MoveHeadRows(sr, dispatchFile.MoveHeadrowsCount);//移动头部moveheadrowscount行
                    List<Column> columns = new List<Column>();
                    Column column = new Column("", 0, 0, 0);
                    int contentIndex = 0;
                    string seperator = dispatchFile.ConvertSeparateString;//分割符
                    bool isBlankSpace = false;//是否是空格
                    int amendmentCharactorsCounnt = 0;
                    char[] buff;
                    //读取文件内容所有列标题
                    if (dispatchFile.ManalColumns != null && dispatchFile.ManalColumns.Count > 0)
                    {
                        //对应的表格没有列名，用配置文件中的代替
                        foreach (Column col in dispatchFile.ManalColumns)
                        {
                            columns.Add(new Column(col.Name, col.Index, col.AmendatoryStartPosition, col.ChineseCharactorsCount));
                        }
                    }
                    else
                    {
                        GetColumns(sr, columns, dispatchFile);
                    }

                    //除去列名和内容之间的多余行数movecustomcount
                    if (dispatchFile.MoveCustomcount != 0)
                    {
                        MoveHeadRows(sr, dispatchFile.MoveCustomcount);
                    }


                    string[] contentString = new string[columns.Count];

                    InitContentStringArray(contentString, string.Empty);

                    #region 读取内容
                    //该列没有值，为0，有值为1
                    int[] contentColumns = new int[255];  //最多255列
                                                          //读取内容，按照行循环来读取
                    int maxLineCharCount = columns[columns.Count - 1].AmendatoryStartPosition + MAXCOLUMNNAMELENGTH;
                    bool isEmptyLine = true;//该行是否有内容
                    int rowIndex = dispatchFile.ColumnTextRowIndex;
                    bool isEndFlag = false;//是否以某符号结尾
                    string[] endFlags = null;
                    string[] breakFlags = null;
                    int SubNo = 1;  //用于组合多腿的计数
                    Column contanctCol = columns.Find(x => x.Name == "合约代码");
                   // string currentDate = GlobalData.PlatformDateAsync;
                    //char currentyear = currentDate[2];

                    if (dispatchFile.Endflag != null)
                    {
                        endFlags = dispatchFile.Endflag.Split('|');
                    }
                    if (dispatchFile.Breakrowflag != null)
                    {
                        breakFlags = dispatchFile.Breakrowflag.Split('|');

                    }
                    #region
                    while (!sr.EndOfStream && !isEndFlag)
                    {
                        InitIntArray(contentColumns, 0, columns.Count);
                        rowIndex++;
                        buff = new char[1];
                        amendmentCharactorsCounnt = 0;
                        contentIndex = 0;
                        int currentLoc = 0;//用来记录处理到的位置
                        isEmptyLine = true;
                        isBlankSpace = true;
                        bool isNeedRead = true;
                        for (int i = 0; i < maxLineCharCount; i++)
                        {

                            if (contentIndex + 1 < columns.Count && i + amendmentCharactorsCounnt == columns[contentIndex + 1].AmendatoryStartPosition)
                            {//假如已经读到下一列的开始位置的前一个位置还没有读取到内容
                             //string previousValue = "";
                             //string previousOppositeValue = "";
                                DispatchColumn dispatchColumn = dispatchFile.Columns.Find(v => v.ColumnIndex == contentIndex);
                                if (dispatchColumn == null)
                                {
                                    throw new Exception(string.Format("源文件\"{0}\",列\"{1}\"需要设置默认值，配置文件中没有配置该列", sourceFileInfo.FullName, columns[contentIndex].Name));
                                }
                                else
                                {
                                    if (dispatchColumn.AssValue == PREVIOUS)
                                    {
                                        dispatchColumn.DefaultValue = contentString[contentIndex];
                                    }
                                    else if (dispatchColumn.AssValue == PREVIOUSOPPOSITE)
                                    {
                                        DispatchColumn combtypeColumn = dispatchFile.Columns.Find(v => v.ColumnName == "组合类型");
                                        switch (combtypeColumn.DefaultValue)
                                        {
                                            case "SPD":
                                                dispatchColumn.DefaultValue = contentString[contentIndex] == "B" ? "1" : "0";
                                                break;
                                            case "IPS":
                                                dispatchColumn.DefaultValue = contentString[contentIndex] == "B" ? "1" : "0";
                                                break;
                                            case "STD":
                                                dispatchColumn.DefaultValue = contentString[contentIndex] == "B" ? "0" : "1";
                                                break;
                                            case "STG":
                                                dispatchColumn.DefaultValue = contentString[contentIndex] == "B" ? "0" : "1";
                                                break;
                                            case "PRT":
                                                dispatchColumn.DefaultValue = "1";
                                                break;
                                            default:
                                                dispatchColumn.DefaultValue = contentString[contentIndex] == "B" ? "1" : "0";
                                                break;
                                        }

                                    }
                                }
                                DealEmptyContent(sw, dispatchFile, seperator, sourceFileInfo.FullName, columns[contentIndex].Name, contentColumns, ref contentIndex);


                            }
                            //else
                            //{
                            ReadContent(sr, buff, ref isNeedRead, ref amendmentCharactorsCounnt);
                            if (buff[0] == BACKSLASHR || buff[0] == BACKSLASHN)
                            {
                                if (contentIndex < columns.Count) //最后两列都是空行的特殊处理
                                {
                                    DealEmptyContent(sw, dispatchFile, seperator, sourceFileInfo.FullName, columns[contentIndex].Name, contentColumns, ref contentIndex);
                                    SubNo++;
                                    sw.Write(SubNo.ToString());
                                }
                                else
                                {
                                    SubNo = 1;
                                    sw.Write(seperator + SubNo.ToString());
                                }
                                //if (++contentRowsCount % 2 == 0)//偶数行结束时重新初始化列内容
                                //{
                                //    InitContentStringArray(contentString, string.Empty);
                                //}
                                DealNewLineChar(buff[0], buff, contentIndex, isEmptyLine, columns.Count, rowIndex, sourceFileInfo.FullName, sw, sr, dispatchFile.AddPlusValue, false, contentColumns, seperator, columns, dispatchFile.Columns);
                                break;
                            }
                            else if (buff[0] != SPACEINGCHAR)
                            {
                                if (i == 0)
                                {
                                    InitContentStringArray(contentString, string.Empty);
                                }
                                if (isBlankSpace)
                                {
                                    if (i + amendmentCharactorsCounnt < columns[contentIndex].AmendatoryStartPosition)
                                    {
                                        columns[contentIndex].AmendatoryStartPosition = i + amendmentCharactorsCounnt;//修正每列内容的开始范围
                                    }
                                    isBlankSpace = false;
                                }

                                isEmptyLine = false;

                                if (contentIndex == 0)//只有第一列才有可能会跳过行,或遇到结束标记机
                                {

                                    int findIndex = -1;
                                    if (breakFlags != null)
                                    {
                                        //findIndex = breakFlags.FindIndex(s => s.StartsWith(buff[0].ToString()));
                                        //if (breakFlags.FindIndex(s => s.StartsWith(buff[0].ToString())) >= 0)
                                        //{
                                        //    if (DealEndFlagOrBreakFlag(false, sr, sw, buff[0], breakFlags, contentIndex, contentColumns, columns.Count, ref isNeedRead, ref isEndFlag))
                                        //    {
                                        //        break;
                                        //    }
                                        //}
                                    }
                                    if (endFlags != null)
                                    {
                                        //findIndex = endFlags.FindIndex(s => s.StartsWith(buff[0].ToString()));
                                        //if (findIndex >= 0)//判断是不是结束标记
                                        //{
                                        //    if (DealEndFlagOrBreakFlag(true, sr, sw, buff[0], endFlags, contentIndex, contentColumns, columns.Count, ref isNeedRead, ref isEndFlag))
                                        //    {
                                        //        break;
                                        //    }
                                        //}
                                    }

                                    if (findIndex < 0)
                                    {
                                        contentString[contentIndex] += buff[0];

                                        DispatchColumn dispatchColumn = dispatchFile.Columns.Find(v => v.ColumnIndex == contentIndex && v.IsEnum == true);
                                        if (dispatchColumn != null && dispatchColumn.EnumKeyValueDic != null && dispatchColumn.EnumKeyValueDic.Count > 0)
                                        {//如果该列内容需是数据字典，则需要将该列内容读完才能匹配数据字典
                                            if (DealColumnDictionary(sr, sw, ref contentIndex, seperator, i, contentColumns, columns, dispatchColumn, sourceFileInfo.FullName, rowIndex, ref isNeedRead, ref buff[0], ref amendmentCharactorsCounnt))
                                            {
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            WriteContent(sw, buff[0], contentIndex, contentColumns);
                                        }
                                    }

                                }
                                else
                                {
                                    contentString[contentIndex] += buff[0];

                                    DispatchColumn dispatchColumn = dispatchFile.Columns.Find(v => v.ColumnIndex == contentIndex && v.IsEnum == true);
                                    if (dispatchColumn != null && dispatchColumn.EnumKeyValueDic != null && dispatchColumn.EnumKeyValueDic.Count > 0)
                                    {//如果该列内容需是数据字典，则需要将该列内容读完才能匹配数据字典
                                        if (DealColumnDictionary(sr, sw, ref contentIndex, seperator, i, contentColumns, columns, dispatchColumn, sourceFileInfo.FullName, rowIndex, ref isNeedRead, ref buff[0], ref amendmentCharactorsCounnt))
                                        {
                                            break;
                                        }
                                    }
                                    else if (contanctCol != null && contanctCol.Index == contentIndex && dispatchFile.SeatNo.ToLower() == "czce")
                                    {


                                        WriteContent(sw, buff[0], contentIndex, contentColumns);
                                        currentLoc++;

                                        //if (currentLoc == 2)
                                        //{


                                        //    WriteContent(sw, currentyear, contentIndex, contentColumns);

                                        //}
                                        continue;

                                    }
                                    else
                                    {
                                        WriteContent(sw, buff[0], contentIndex, contentColumns);
                                    }
                                }

                            }
                            else if (buff[0] == SPACEINGCHAR)
                            {

                                DealSpaceChar(sw, columns.Count, seperator, ref contentIndex, ref isBlankSpace);
                            }

                        }


                    }
                    #endregion


                    #endregion

                    #endregion
                }
                isConvertSuccess = true;


            }
            catch (Exception ex)
            {

              //  FuturesLogService.Error(string.Format("{0}-{1}预处理出错！", dispatchFile.SeatNo, dispatchFile.MatchRule));
               // FuturesMessageBox.ShowError(string.Format("{0}-{1}预处理出错！", dispatchFile.SeatNo, dispatchFile.MatchRule));

            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
                if (sw != null)
                {
                    sw.Close();
                }
                if (fs != null)
                {

                    fs.Close();
                }
                if (!isConvertSuccess)
                    File.Delete(_txtName);//处理错误则删除文件

            }
            return isConvertSuccess;
        }


        private static bool Convert_czce_capital_ToTxt(DispatchFile dispatchFile, FileInfo sourceFileInfo, string _txtName = "")
        {
            //fs = new FileStream(_txtName, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            //sr = new StreamReader(sourceFileInfo.FullName, Encoding.Default);
            //sw = new StreamWriter(fs, Encoding.UTF8);   //System.Text.Encoding.UTF8
            if (string.IsNullOrWhiteSpace(_txtName))
            {
                _txtName = string.Format(@"{0}\output\{1}.txt", sourceFileInfo.DirectoryName, dispatchFile.FileType);
            }
            if (!Directory.Exists(Path.GetDirectoryName(_txtName)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(_txtName));
            }
            StreamReader sr = null;
            FileStream fs = null;
            StreamWriter sw = null;

            bool isConvertSuccess = false;//是否转换成功
            try
            {
                // fs = new FileStream(_txtName, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                // sw = new StreamWriter(fs,Encoding.UTF8);没有的情况怎么办
                sr = new StreamReader(sourceFileInfo.FullName, Encoding.Default);
                DataTable dt = new DataTable("capital");
                dt.Columns.Add("项目", typeof(string));
                dt.Columns.Add("金额", typeof(string));
                dt.Columns.Add("备注", typeof(string));
                string[] breakRows = new string[] { "项目", "小计", "-", "会员编号" };
                string lastKey = "";//当出现主列第一行有值后面的行为空的情况时用有值的行填充后面的行,遇到-----清空(本日减少等的填充)
                int tableBoundCount = 0;//是否是当日资金结算表的开始以==============开始和结尾,此变量为1时代表表开始,2时代表表结束
                int lineCount = 0;//---出现的次数
                while (!sr.EndOfStream)//读数据
                {

                    string txt = sr.ReadLine();//读取一行
                    if (txt.Contains("======"))
                    {
                        tableBoundCount++;
                        lastKey = " ";
                        continue;
                    }
                    if (txt.Contains("-------"))
                    {
                        lineCount++;
                    }

                    if (txt.Contains("郑州商品交易所结算部"))
                        break;
                    txt = txt.Replace((char)12288, ' '); //12288为全角空格替换为半角的
                    if (tableBoundCount > 0 /*&& breakRows.FindIndex((x) => Regex.Replace(txt, @"\s+", "").Contains(x)) >= 0*/)//包含要跳过的字符
                    {
                        lastKey = " ";
                        continue;

                    }
                    else if (tableBoundCount == 1)//处理表主体
                    {
                        txt = Regex.Replace(txt, @"\s+", "");
                        string[] rows = txt.Split('|');//根据前后四个空格划分为五个string,其中index为1,2,3的string为所需元素
                        if (rows.Length != 5)
                            continue;
                        if (rows[1] != "")
                            lastKey = rows[1];
                        else
                            rows[1] = lastKey;
                        if (lineCount == 1)
                        {
                            if (!rows[1].Contains("期初"))
                            {
                                rows[1] = "期初" + rows[1];

                            }

                        }
                        if (lineCount == 6)
                        {
                            if (!rows[1].Contains("期末"))
                            {
                                rows[1] = "期末" + rows[1];

                            }

                        }

                        if (rows[2] == "")//金额默认填0
                            rows[2] = "0.00";
                        if (rows[3] == "")
                            rows[3] = " ";
                        dt.Rows.Add(rows[1], GetNumber(rows[2]), rows[3]);
                    }
                    else if (tableBoundCount == 2)//表结束部分,默认表底下的行会有第一项和第二项
                    {
                        txt = txt.Trim();
                        txt = Regex.Replace(txt, @"\s+", " ");
                        string[] rows = txt.Split(' ');
                        if (rows.Length == 1)//底下的行只有一个元素,则默认该元素是金额
                        {
                            dt.Rows.Add(lastKey, GetNumber(rows[0]), " ");

                        }
                        else if (rows.Length == 2)//底下的行有两个元素,则是项名以及金额
                        {
                            rows[0] = rows[0].Replace(":", "");
                            dt.Rows.Add(rows[0], GetNumber(rows[1]), " ");
                            lastKey = rows[0];

                        }
                        else if (rows.Length == 3)//底下的行有两个元素,则是项名以及金额
                        {
                            rows[0] = rows[0].Replace(":", "");
                            dt.Rows.Add(rows[0], GetNumber(rows[1]), rows[2]);
                            lastKey = rows[0];

                        }
                        else//=======结束后为美元相关（待定） 将所有外汇相关的导入
                        {
                            for (int i = 1; i < rows.Length; i += 2)
                            {
                                dt.Rows.Add(rows[0] + rows[i].Replace(":", ""), GetNumber(rows[i + 1]), "");
                            }
                        }
                    }
                }
                fs = new FileStream(_txtName, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                sw = new StreamWriter(fs, Encoding.UTF8);
                for (int i = 0; i < dt.Rows.Count; ++i)
                {
                    for (int j = 0; j < dt.Rows[i].ItemArray.Length; j++)
                    {
                        sw.Write(dt.Rows[i].ItemArray[j]);
                        if (j != dt.Rows[i].ItemArray.Length - 1)
                            sw.Write(dispatchFile.ConvertSeparateString);//以配置文件分割符进行分割
                        else
                            sw.Write(ENTERSTING);//以配置文件分割符进行分割
                    }
                    //sw.WriteLine();

                }
                isConvertSuccess = true;
            }
            catch
            {

                isConvertSuccess = false;

            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
                if (sw != null)
                {
                    sw.Close();
                }
                if (fs != null)
                {

                    fs.Close();
                }
                if (!isConvertSuccess)
                {
                    File.Delete(_txtName);
                }//处理错误则删除文件

            }

            return isConvertSuccess;





        }
        /// <summary>
        /// 获取字符串中的数字,包含小数点
        /// </summary>
        /// <param name="input">输入字符串</param>
        /// <returns>只有数字的字符串</returns>
        private static string GetNumber(string input)
        {
            return new string(input.Where(x => char.IsNumber(x) || x == '.').ToArray());


        }
        /// <summary>
        /// 初始化int数组
        /// </summary>
        /// <param name="intArray">要填充的数组</param>
        /// <param name="value">要使用的值</param>
        /// <param name="length">要填充的长度</param>
        private static void InitIntArray(int[] intArray, int value, int length)
        {
            int count = intArray.Length < length ? intArray.Length : length;
            for (int i = 0; i < count; i++)
            {
                intArray[i] = value;
            }
        }

        private static void InitContentStringArray(string[] stringArray, string value)
        {
            for (int i = 0; i < stringArray.Length; i++)
            {
                stringArray[i] = value;
            }
        }

        /// <summary>
        /// 读取n行，将sr指针下移
        /// </summary>
        /// <param name="sr"></param>
        /// <param name="rowsCount"></param>
        private static void HeadFilter(StreamReader sr, DispatchFile dispatchFile)
        {
            string temp = string.Empty;
            do
            {
                temp = sr.ReadLine();
                dispatchFile.ColumnTextRowIndex++;
            }
            while (!temp.Contains(dispatchFile.MoveheadFilter));


        }

        /// <summary>
        /// 读取n行，将sr指针下移
        /// </summary>
        /// <param name="sr"></param>
        /// <param name="rowsCount"></param>
        private static void MoveHeadRows(StreamReader sr, int rowsCount)
        {
            for (int i = 0; i < rowsCount; i++)
            {
                sr.ReadLine();
            }
        }

        /// <summary>
        /// 读取文件内容所有列标题
        /// </summary>
        /// <param name="sr"></param>
        private static void GetColumns(StreamReader sr, List<Column> columns, DispatchFile dispatchFile)
        {
            #region 读取文件内容所有列标题
            Column column = new Column("", 0, 0, 0);
            string columnName;
            int MAXCOLUMNNAMELENGTH = 255;
            int columnIndex = 0;
            bool endOfColumnName = false;
            bool isBlankSpace = false;
            do
            {
                int startPosition = 0;
                int amendatoryStartPosition = 0;
                int lastPosition = 0;
                char[] buff = new char[MAXCOLUMNNAMELENGTH];
                int chineseCharactorsCounnt = 0;
                for (int i = 0; i < buff.Length; i++)//获取文件内容所有列
                {
                    sr.Read(buff, i, 1);
                    if (CheckChar.IsChineseCharactor(buff[i]))
                    {
                        chineseCharactorsCounnt++;
                    }
                    if (isBlankSpace)//是空格
                    {
                        if (buff[i] == BACKSLASHR)
                        {
                            endOfColumnName = true;
                            sr.Read(buff, i, 1);
                            break;
                        }
                        else if (buff[i] == BACKSLASHN)
                        {
                            endOfColumnName = true;
                            break;
                        }
                        else if (buff[i] != SPACEINGCHAR)
                        {
                            isBlankSpace = false;
                            if (columnIndex == 0)
                            {
                                //chineseCharactorsCounnt += i;    //加上第一列内容前的空格数
                            }
                            else
                            {
                                column = columns[columnIndex - 1];
                                startPosition = column.AmendatoryStartPosition + column.Name.Length + i + 1;
                            }
                        }

                    }
                    else//不是空格
                    {
                        string rowName = new string(buff);
                        DispatchColumn dc = dispatchFile.Columns.Find((x => rowName.Contains(x.ColumnName)));
                        if (buff[i] == BACKSLASHR)
                        {
                            if (column.Name != "")
                            {
                                int colNameLength = i;
                                int sourceIndex = 0;
                                if (columnIndex != 0)
                                {
                                    colNameLength = i - (startPosition - column.AmendatoryStartPosition - column.Name.Length - 1);
                                    sourceIndex = i - colNameLength;
                                    amendatoryStartPosition = startPosition + columns[columnIndex - 1].ChineseCharactorsCount;
                                    lastPosition = amendatoryStartPosition + colNameLength + chineseCharactorsCounnt;
                                }
                                char[] colName = new char[colNameLength];
                                Array.Copy(buff, sourceIndex, colName, 0, colName.Length);
                                columnName = new string(colName);

                                column = new Column(columnName, columnIndex, amendatoryStartPosition, lastPosition, chineseCharactorsCounnt);
                                columns.Add(column);
                            }
                            endOfColumnName = true;
                            sr.Read(buff, i, 1);
                            break;
                        }
                        else if (buff[i] == BACKSLASHN)
                        {
                            if (column.Name != "")
                            {
                                int colNameLength = i;
                                int sourceIndex = 0;
                                if (columnIndex != 0)
                                {
                                    colNameLength = i - (startPosition - column.AmendatoryStartPosition - column.Name.Length - 1);
                                    sourceIndex = i - colNameLength;
                                    amendatoryStartPosition = startPosition + columns[columnIndex - 1].ChineseCharactorsCount;
                                    lastPosition = amendatoryStartPosition + colNameLength + chineseCharactorsCounnt;
                                }
                                char[] colName = new char[colNameLength];
                                Array.Copy(buff, sourceIndex, colName, 0, colName.Length);
                                columnName = new string(colName);
                                column = new Column(columnName, columnIndex, amendatoryStartPosition, lastPosition, chineseCharactorsCounnt);
                                columns.Add(column);
                            }
                            endOfColumnName = true;
                            break;
                        }
                        //  else if ((buff[i] == SPACEINGCHAR && i!=0) || (dc != null && dc.NeedSplit == true))
                        else if (buff[i] == SPACEINGCHAR || (dc != null && dc.NeedSplit == true))
                        {
                            isBlankSpace = true;
                            int colNameLength = i;
                            int sourceIndex = 0;
                            if (columnIndex != 0)
                            {

                                colNameLength = i - (startPosition - column.AmendatoryStartPosition - column.Name.Length - 1);
                                sourceIndex = i - colNameLength;
                                amendatoryStartPosition = startPosition + columns[columnIndex - 1].ChineseCharactorsCount;
                                lastPosition = amendatoryStartPosition + colNameLength + chineseCharactorsCounnt;
                            }
                            else
                            {
                                lastPosition = amendatoryStartPosition + i + chineseCharactorsCounnt;
                            }
                            char[] colName = new char[colNameLength];
                            Array.Copy(buff, sourceIndex, colName, 0, colName.Length);
                            columnName = new string(colName);
                            if (dc != null && dc.NeedSplit == true)
                            {
                                columnName = dc.ColumnName;

                            }
                            if (!string.IsNullOrEmpty(columnName))
                            {
                                //hb20180207 columnName不能Trim()。因为上期所order表开始列开始有空格
                                column = new Column(columnName, columnIndex, amendatoryStartPosition, lastPosition, chineseCharactorsCounnt);
                                //  column = new Column(columnName.Trim(), columnIndex, amendatoryStartPosition, lastPosition, chineseCharactorsCounnt);
                                columns.Add(column);
                                columnIndex++;
                                break;
                            }
                        }

                    }
                }
                if (sr.Peek() < 0)//用于处理无字符时直接终止循环,没有此代码会处理空文件会死锁
                    break;

            } while (!endOfColumnName);

            #endregion
        }

        private static void SHFE_ConvertTxtFileToTXT(StreamWriter sw, StreamReader sr, DispatchFile dispatchFile)
        {
            if (dispatchFile.FileType == "shfe_Capital" || dispatchFile.FileType == "ine_Capital")
            {
                List<string> lsTitle = new List<string>();
                List<string> lsValue = new List<string>();
                string content = string.Empty;
                string[] lsItems;
                int start = 0;
                while (!sr.EndOfStream)
                {
                    if (start == 0)
                    {
                        content = sr.ReadLine().Trim();
                        lsItems = content.Split('@');
                        foreach (string s in lsItems)
                        {
                            lsTitle.Add(s);
                        }
                    }
                    else
                    {
                        content = sr.ReadLine().Trim();
                        lsItems = content.Split('@');
                        foreach (string s in lsItems)
                        {
                            lsValue.Add(s);
                        }
                    }
                    start++;
                }
                string newItem = string.Empty;
                int endNum = lsTitle.Count - 1;
                for (int i = 0; i <= endNum; i++)
                {
                    newItem = lsTitle[i].Trim() + "@" + lsValue[i].Trim() + ENTERSTING;
                    sw.Write(newItem);
                }
                //TODO:上期所结算文件导入未修改完成 去做复核功能 待修改

                //var sprCount = 0;
                //for (int i = 0; i < lsValue.Count; i++)
                //{
                //    //如果当前行包含 - 跳出当前行 并记录处理了多少个 --行
                //    if (lsValue[i].Contains("--"))
                //    {
                //        sprCount++;
                //        continue;
                //    }
                //    //处理2行---  之后  开始处理数据 大于两行的就不处理
                //    if (sprCount > 2)
                //        break;
                //    if (sprCount == 2)
                //    {
                //        var fileRowArr = lsValue[i].Split(' ');
                //        var newRowArr = fileRowArr.Where(_ => !string.IsNullOrEmpty(_));
                //        if (newRowArr.Count() != 2)
                //            continue;
                //        newItem = newRowArr.FirstOrDefault().Trim() + "@" + newRowArr.LastOrDefault().Trim() + ENTERSTING;
                //        sw.Write(newItem);
                //    }
                //}
            }
            else
            {
                MoveHeadRows(sr, dispatchFile.MoveHeadrowsCount);
                //币种字典项
                //IDictionaryService dictService = ServiceFactory.GetDefaultServiceInstance<IDictionaryService>();
               // CommonDictionary _commonDictCurrencyCode = dictService.GetCommonDictionary(FieldDefine.FIELD_CurrencyCode);
                Dictionary<string, string> currency = new Dictionary<string, string>();

                //foreach (var code in _commonDictCurrencyCode.DictionaryItems.Keys)
                //{
                //    currency.Add(_commonDictCurrencyCode.DictionaryItems[code], code);
                //}

                while (!sr.EndOfStream)
                {
                    string content = sr.ReadLine().Trim();
                    if (content.Equals(string.Empty))
                    {
                        continue;
                    }
                    #region 业务处理
                    if (dispatchFile.Columns.Count > 0)
                    {
                        char spe = Convert.ToChar(dispatchFile.ContentSeparateString);
                        string[] items = content.Split(spe);
                        foreach (DispatchColumn dc in dispatchFile.Columns)
                        {
                            if (dc.IsEnum)
                            {
                                items[dc.ColumnIndex] = dc.EnumKeyValueDic[items[dc.ColumnIndex]];
                            }
                        }
                        content = string.Empty;
                        foreach (string item in items)
                        {
                            content += item + dispatchFile.ContentSeparateString;
                        }
                        content = content.TrimEnd(spe);
                    }
                    //郑州  大连分项资金文件
                    else if (dispatchFile.FileType.Equals("czce_ClientCapitalDetail"))
                    {
                        char spe = Convert.ToChar(dispatchFile.ContentSeparateString);
                        string[] items = content.Split(spe);
                        content = string.Empty;
                        foreach (string item in items)
                        {
                            if (item.Length > 0 && item[0] == '+')
                            {
                                content += item.Substring(1) + dispatchFile.ContentSeparateString;
                            }
                            else
                            {
                                content += item + dispatchFile.ContentSeparateString;
                            }
                        }

                        content = content.TrimEnd(spe);
                    }
                    //大连分项资金文件
                    else if (dispatchFile.FileType.Equals("dce_ClientCapitalDetail"))
                    {
                        char spe = Convert.ToChar(dispatchFile.ContentSeparateString);
                        string[] items = content.Split(spe);
                        content = string.Empty;

                        for (int i = 0; i < items.Length; i++)
                        {
                            if (i < items.Length - 1)
                            {
                                content += items[i] + dispatchFile.ContentSeparateString;
                            }
                            else if (i == items.Length - 1)
                            {
                                foreach (var code in currency.Keys)
                                {
                                    if (items[i].Equals(code))
                                    {
                                        content += currency[code] + dispatchFile.ContentSeparateString;
                                    }
                                }
                            }
                        }

                        content = content.TrimEnd(spe);
                    }
                    #endregion
                    if (content != string.Empty)
                    {
                        sw.Write(content + ENTERSTING);
                    }
                }
            }

        }

        /// <summary>
        /// 当一行内容结束时，获取剩下没读取到列的默认值
        /// </summary>
        /// <param name="contentIndex"></param>
        /// <param name="columnsCount"></param>
        /// <param name="seperator"></param>
        /// <param name="sourceFileName"></param>
        /// <param name="columns"></param>
        /// <param name="dispatchColumns"></param>
        /// <returns></returns>
        private static string GetContentDefaultValue(int[] contentColumns, int contentIndex, int columnsCount, string seperator, string sourceFileName, List<Column> columns, List<DispatchColumn> dispatchColumns)
        {
            string value = null;

            if (contentIndex > 0)
            {
                value = string.Empty;
                for (int i = contentIndex; i < columnsCount; i++)
                {
                    if (contentColumns[i] == 0)
                    {
                        DispatchColumn column = dispatchColumns.Find(v => v.ColumnIndex == i);
                        if (column == null)
                        {
                            throw new Exception(string.Format("源文件\"{0}\",列\"{1}\"需要设置默认值，配置文件中没有配置该列", sourceFileName, columns[contentIndex].Name));
                        }
                        else
                        {
                            if (column.DefaultValue != null)
                            {
                                value += column.DefaultValue + seperator;
                            }
                            else
                            {
                                throw new Exception(string.Format("源文件\"{0}\",列\"{1}\"需要设置默认值，配置文件中没有配置该列的默认值", sourceFileName, columns[contentIndex].Name));
                            }
                        }
                    }

                }

                if (value.EndsWith(","))
                {
                    value = value.Remove(value.Length - 1);
                }
            }

            return value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="encodingName"></param>
        /// <returns></returns>
        public static System.Text.Encoding GetEncoding(string encodingName)
        {
            if (string.IsNullOrEmpty(encodingName) == true)
            {
                return System.Text.Encoding.Default;
            }

            if (encodingName.ToUpper() == "GB2313")
            {
                return System.Text.Encoding.GetEncoding("GB2312");
            }

            if (encodingName.ToUpper() == "UNICODE")
            {
                return System.Text.Encoding.Unicode;
            }

            if (encodingName.ToUpper() == "UTF8")
            {
                return System.Text.Encoding.UTF8;
            }

            if (encodingName.ToUpper() == "UTF7")
            {
                return System.Text.Encoding.UTF7;
            }

            if (encodingName.ToUpper() == "UTF32")
            {
                return System.Text.Encoding.UTF32;
            }

            if (encodingName.ToUpper() == "ASCII")
            {
                return System.Text.Encoding.ASCII;
            }

            return System.Text.Encoding.Default;
        }


        public static DateTime ToDate(byte[] buf)
        {
            if (buf.Length != 8)
            {
                throw new ArgumentException("date array length must be 8.", "buf");
            }

            string dateStr = System.Text.Encoding.ASCII.GetString(buf).Trim();
            if (dateStr.Length < 8)
            {
                return NullDateTime;
            }

            int year = int.Parse(dateStr.Substring(0, 4));
            int month = int.Parse(dateStr.Substring(4, 2));
            int day = int.Parse(dateStr.Substring(6, 2));

            return new DateTime(year, month, day);
        }

        public static DateTime ToTime(byte[] buf)
        {
            if (buf.Length != 8)
            {
                throw new ArgumentException("time array length must be 8.", "buf");
            }

            try
            {
                byte[] tmp = CopySubBytes(buf, 0, 4);
                tmp.Initialize();
                int days = System.BitConverter.ToInt32(tmp, 0);  // ( ToInt32(tmp); // 获取天数                  

                tmp = CopySubBytes(buf, 4, 4);  // 获取毫秒数  
                int milliSeconds = System.BitConverter.ToInt32(tmp, 0);  // ToInt32(tmp);  

                if (days == 0 && milliSeconds == 0)
                {
                    return NullDateTime;
                }

                int seconds = milliSeconds / 1000;
                int milli = milliSeconds % 1000;  // vfp实际上没有毫秒级, 是秒转换来的, 测试时发现2秒钟转换为1999毫秒的情况  
                if (milli > 0)
                {
                    seconds += 1;
                }

                DateTime date = DateTime.MinValue;  // 在最小日期时间的基础上添加刚获取的天数和秒数，得到日期字段数值  
                date = date.AddDays(days - 1721426);
                date = date.AddSeconds(seconds);

                return date;
            }
            catch
            {
                return new DateTime();
            }
        }

        public static byte[] CopySubBytes(byte[] buf, int startIndex, long length)
        {
            if (startIndex >= buf.Length)
            {
                throw new ArgumentOutOfRangeException("startIndex");
            }

            if (length == 0)
            {
                throw new ArgumentOutOfRangeException("length", "length must be great than 0.");
            }

            if (length > buf.Length - startIndex)
            {
                length = buf.Length - startIndex;  // 子数组的长度超过从startIndex起到buf末尾的长度时，修正为剩余长度  
            }

            byte[] target = new byte[length];
            Array.Copy(buf, startIndex, target, 0, length);
            return target;
        }
    }

    public static class CheckChar
    {

        public static bool IsChineseCharactor(this char c)
        {
            int b = (int)c;

            return b > 127;
        }
    }
}

