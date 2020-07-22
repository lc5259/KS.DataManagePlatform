using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;

namespace KS.DataManage.Utils
{
    #region TDbfTable（TDbfReader）更新历史
    //-----------------------------------------------------------------------------------------------  
    // 1) 2013-06-10: (1) 自 ReadDbf.cs 移植过来  
    //                (2) 读记录时, 首先读删除标志字节, 然后读记录. 原代码这个地方忽略了删除标志字节.  
    //                (3) 原代码 MoveNext() 后没有再判是否文件尾, 在读修改结构后的表时报错误.  
    // 2) 2013-06-11: (1) int.money.decimal.double 直接用 BitConverter 转换函数  
    //                (2) Date类型转换时, 如果字符串为空, 则为1000-01-01日.  
    //                (3) Time类型转换时, 如果天数和毫秒数全为0, 则为1000-01-01日.  
    //                (4) Time类型转换时, 毫秒数存在误差, 有1000以下的整数数, 需要+1秒.  
    //                (5) 读记录值时,  在定位首指针后, 顺序读每个记录数组.  
    // 3) 2013-06-17  (1) 打开文件后需要关闭文件流, 增加一个 CloseFileStream() 方法  
    // 4) 2013-06-18  (1) 把 CloseFileStream() 放到 try{}finally{} 结构中  
    //-----------------------------------------------------------------------------------------------------  
    #endregion  
  
    public class TDbfHeader  //DBF文件头结构(32字节)
    {  
        public const int HeaderSize = 32;  
        public sbyte Version;               
        public byte LastModifyYear;     
        public byte LastModifyMonth;  
        public byte LastModifyDay;  
        public int RecordCount;        
        public ushort HeaderLength;  
        public ushort RecordLength;  
        public byte[] Reserved = new byte[16];  
        public sbyte TableFlag;  
        public sbyte CodePageFlag;  
        public byte[] Reserved2 = new byte[2];  
    }  
  
    public class TDbfField  //DBF字段描述结构(32字节)
    {  
        public const int FieldSize = 32;  
        public byte[] NameBytes = new byte[11]; 
        public byte TypeChar;                              
        public byte Length;
        public byte Precision;
        public byte[] Reserved = new byte[2];  
        public sbyte DbaseivID;  
        public byte[] Reserved2 = new byte[10];  
        public sbyte ProductionIndex;  
  
        public bool IsString  
        {  
            get  
            {  
                if (TypeChar == 'C')  
                {  
                    return true;  
                }  
                return false;  
            }  
        }  
  
        public bool IsMoney  
        {  
            get  
            {  
                if(TypeChar == 'Y')  
                {  
                    return true;  
                }  
                return false;  
            }  
        }  
  
        public bool IsNumber  
        {  
            get  
            {  
                if (TypeChar == 'N')  
                {  
                    return true;  
                }  
                return false;  
            }  
        }  
  
        public bool IsFloat  
        {  
            get  
            {  
                if (TypeChar == 'F')  
                {  
                    return true;  
                }  
                return false;  
            }  
        }  
  
        public bool IsDate  
        {  
            get  
            {  
                if (TypeChar == 'D')  
                {  
                    return true;  
                }  
                return false;  
            }  
        }  
  
        public bool IsTime  
        {  
            get  
            {  
                if (TypeChar == 'T')  
                {  
                    return true;  
                }  
                return false;  
            }  
        }  
  
        public bool IsDouble  
        {  
            get  
            {  
                if (TypeChar == 'B')  
                {  
                    return true;  
                }  
                return false;  
            }  
        }  
  
        public bool IsInt  
        {  
            get  
            {  
                if (TypeChar == 'I')  
                {  
                    return true;  
                }  
                return false;  
            }  
        }  
  
        public bool IsLogic  
        {  
            get  
            {  
                if (TypeChar == 'L')  
                {  
                    return true;  
                }  
                return false;  
            }  
        }  
  
        public bool IsMemo  
        {  
            get  
            {  
                if (TypeChar == 'M')  
                {  
                    return true;  
                }  
                return false;  
            }  
        }  
  
        public bool IsGeneral  
        {  
            get  
            {  
                if (TypeChar == 'G')  
                {  
                    return true;  
                }  
                return false;  
            }  
        }  
  
        public Type FieldType  
        {  
            get  
            {  
                if (this.IsString == true)  
                {  
                    return typeof(string);  
                }  
                else if (this.IsMoney == true || this.IsNumber == true || this.IsFloat == true)  
                {  
                    return typeof(decimal);  
                }  
                else if (this.IsDate == true || this.IsTime == true)  
                {  
                    return typeof(System.DateTime);  
                }  
                else if (this.IsDouble == true)  
                {  
                    return typeof(double);  
                }  
                else if (this.IsInt == true)  
                {  
                    return typeof(System.Int32);  
                }  
                else if (this.IsLogic == true)  
                {  
                    return typeof(bool);  
                }  
                else if (this.IsMemo == true)  
                {  
                    return typeof(string);  
                }  
                else  
                {  
                    return typeof(string);  
                }  
            }  
        }  
  
        public string GetFieldName()  
        {
            return GetFieldName(System.Text.Encoding.UTF8);  
        }

        public string GetFieldName(System.Text.Encoding encoding)  
        {  
            string fieldName = encoding.GetString(NameBytes);  
            int i = fieldName.IndexOf('\0');  
            if (i > 0)  
            {  
                return fieldName.Substring(0, i).Trim();  
            }  
  
            return fieldName.Trim();  
        }  
    }  
  
    /// <summary>
    /// TDbfReader
    /// </summary>
    public class TDbfReader : TFileReader
    {  
        private const byte DeletedFlag = 0x2A;  
        private byte[] _recordBuffer;  
        private int _fieldCount = 0;
  
        private TDbfHeader _dbfHeader = null;  
        private TDbfField[] _dbfFields;  
        private System.Data.DataTable _dataTable = null;

        public TDbfReader(string fileName, string encodingName="") : base(fileName, encodingName) { }


        public override bool CheckFileExt()
        {
            return (string.Compare(this._fileInfo.Extension.ToString(), ".dbf", true) == 0);
        }

        public override void CloseFile()  
        {
            base.CloseFile();
  
            _recordBuffer = null;  
            _dbfHeader = null;  
            _dbfFields = null;  
            _fieldCount = 0;  
        }

        public override void OpenFile()  
        {
            this.CloseFile();
            try
            {
                this.GetFileStream();
                this.ReadHeader();
                this.ReadFields();
                this.GetRecordBufferBytes();
                this.CreateDbfTable();
                this.GetDbfRecords();
            }
            catch (Exception e)
            {
                this.CloseFile();
                throw e;

                
            }
        }


        private void ReadHeader()  
        {  
            this._dbfHeader = new TDbfHeader();  
  
            try  
            {  
                this._dbfHeader.Version = this._binaryReader.ReadSByte();         //第1字节  
                this._dbfHeader.LastModifyYear = this._binaryReader.ReadByte();   //第2字节  
                this._dbfHeader.LastModifyMonth = this._binaryReader.ReadByte();  //第3字节  
                this._dbfHeader.LastModifyDay = this._binaryReader.ReadByte();    //第4字节  
                this._dbfHeader.RecordCount = this._binaryReader.ReadInt32();     //第5-8字节  
                this._dbfHeader.HeaderLength = this._binaryReader.ReadUInt16();   //第9-10字节  
                this._dbfHeader.RecordLength = this._binaryReader.ReadUInt16();   //第11-12字节  
                this._dbfHeader.Reserved = this._binaryReader.ReadBytes(16);      //第13-14字节  
                this._dbfHeader.TableFlag = this._binaryReader.ReadSByte();       //第15字节  
                this._dbfHeader.CodePageFlag = this._binaryReader.ReadSByte();    //第16字节  
                this._dbfHeader.Reserved2 = this._binaryReader.ReadBytes(2);      //第17-18字节  
  
                this._fieldCount = GetFieldCount();  
            }  
            catch  
            {  
                throw new Exception("fail to read file header.");  
            }  
        }  
  
        private int GetFieldCount()  
        {  
            // 由于有些dbf文件的文件头最后有附加区段，但是有些文件没有，在此使用笨方法计算字段数目  
            // 就是测试每一个存储字段结构区域的第一个字节的值，如果不为0x0D，表示存在一个字段  
            // 否则从此处开始不再存在字段信息  
  
            int fCount = (this._dbfHeader.HeaderLength - TDbfHeader.HeaderSize - 1) / TDbfField.FieldSize;  
  
            for (int k = 0; k < fCount; k++)  
            {  
                _fileStream.Seek(TDbfHeader.HeaderSize + k * TDbfField.FieldSize, SeekOrigin.Begin);  // 定位到每个字段结构区，获取第一个字节的值  
                byte flag = this._binaryReader.ReadByte();  
  
                if (flag == 0x0D)  // 如果获取到的标志不为0x0D，则表示该字段存在；否则从此处开始后面再没有字段信息  
                {  
                    return k;  
                }  
            }  
  
            return fCount;  
        }  
  
        private void ReadFields()  
        {  
            _dbfFields = new TDbfField[_fieldCount];  
  
            try  
            {  
                _fileStream.Seek(TDbfHeader.HeaderSize, SeekOrigin.Begin);  
                for (int k = 0; k < _fieldCount; k++)  
                {  
                    this._dbfFields[k] = new TDbfField();  
                    this._dbfFields[k].NameBytes = this._binaryReader.ReadBytes(11);  
                    this._dbfFields[k].TypeChar = this._binaryReader.ReadByte();  
  
                    this._binaryReader.ReadBytes(4);  // 保留, 源代码是读 UInt32()给 Offset  
                      
                    this._dbfFields[k].Length = this._binaryReader.ReadByte();  
                    this._dbfFields[k].Precision = this._binaryReader.ReadByte();  
                    this._dbfFields[k].Reserved = this._binaryReader.ReadBytes(2);  
                    this._dbfFields[k].DbaseivID = this._binaryReader.ReadSByte();  
                    this._dbfFields[k].Reserved2 = this._binaryReader.ReadBytes(10);  
                    this._dbfFields[k].ProductionIndex = this._binaryReader.ReadSByte();  
                }  
            }  
            catch  
            {  
                throw new Exception("fail to read field information.");  
            }  
        }  
  
        private void GetRecordBufferBytes()  
        {  
            this._recordBuffer = new byte[this._dbfHeader.RecordLength];  
  
            if (this._recordBuffer == null)  
            {  
                throw new Exception("fail to allocate memory .");  
            }  
        }  
  
        private void CreateDbfTable()  
        {  
            if (_dataTable != null)  
            {  
                _dataTable.Clear();  
                _dataTable = null;  
            }  
  
            _dataTable = new System.Data.DataTable();
            _dataTable.TableName = Path.GetFileNameWithoutExtension(_fileName); 
  
            for (int k = 0; k < this._fieldCount; k++)  
            {  
                System.Data.DataColumn col = new System.Data.DataColumn();  
                string colText = this._dbfFields[k].GetFieldName(_encoding);  
  
                if (string.IsNullOrEmpty(colText) == true)  
                {  
                    throw new Exception("the " + (k + 1) + "th column name is null.");  
                }  
  
                col.ColumnName = colText;
                col.Caption = colText; 
                col.DataType = this._dbfFields[k].FieldType;  
                _dataTable.Columns.Add(col);  
            }  
        }  
  
        public void GetDbfRecords()  
        {  
            try  
            {  
                this._fileStream.Seek(this._dbfHeader.HeaderLength, SeekOrigin.Begin);  
  
                for (int k = 0; k < this.RecordCount; k++)  
                {  
                    if (ReadRecordBuffer(k) != DeletedFlag)  
                    {  
                        System.Data.DataRow row = _dataTable.NewRow();  
                        for (int i = 0; i < this._fieldCount; i++)  
                        {  
                            row[i] = this.GetFieldValue(i);  
                        }  
                        _dataTable.Rows.Add(row);  
                    }  
                }  
            }  
            catch (ArgumentOutOfRangeException e)  
            {  
                throw e;  
            }  
            catch  
            {  
                throw new Exception("fail to get dbf table.");  
            }  
        }  
  
        private byte ReadRecordBuffer(int recordIndex)  
        {  
            byte deleteFlag = this._binaryReader.ReadByte();  // 删除标志  
            this._recordBuffer = this._binaryReader.ReadBytes(this._dbfHeader.RecordLength - 1);  // 标志位已经读取  
            return deleteFlag;  
        }  
  
        private string GetFieldValue(int fieldIndex)  
        {  
            string fieldValue = null;  
  
            int offset = 0;  
            for (int i = 0; i < fieldIndex; i++)  
            {  
                offset += _dbfFields[i].Length;  
            }  
  
            byte[] tmp = CopySubBytes(this._recordBuffer, offset, this._dbfFields[fieldIndex].Length);  
  
            if (this._dbfFields[fieldIndex].IsInt == true)  
            {  
                int val = System.BitConverter.ToInt32(tmp,0);  
                fieldValue = val.ToString();  
            }  
            else if (this._dbfFields[fieldIndex].IsDouble == true)  
            {  
                double val = System.BitConverter.ToDouble(tmp,0);  
                fieldValue = val.ToString();  
            }  
            else if (this._dbfFields[fieldIndex].IsMoney == true)  
            {  
                long val = System.BitConverter.ToInt64(tmp, 0);  // 将字段值放大10000倍，变成long型存储，然后缩小10000倍。  
                fieldValue = ((decimal)val / 10000).ToString();  
            }  
            else if (this._dbfFields[fieldIndex].IsDate == true)  
            {  
                DateTime date = ToDate(tmp);  
                fieldValue = date.ToString();  
            }  
            else if (this._dbfFields[fieldIndex].IsTime == true)  
            {  
                DateTime time = ToTime(tmp);  
                fieldValue = time.ToString();  
            }  
            else  
            {  
                fieldValue = this._encoding.GetString(tmp);  
            }  
  
            fieldValue = fieldValue.Trim();  
  
            // 如果本子段类型是数值相关型，进一步处理字段值  
            if (this._dbfFields[fieldIndex].IsNumber == true || this._dbfFields[fieldIndex].IsFloat == true)    // N - 数值型, F - 浮点型                      
            {  
                if (fieldValue.Length == 0)  
                {  
                    fieldValue = "0";  
                }  
                else if (fieldValue == ".")  
                {  
                    fieldValue = "0";  
                }  
                else  
                {                     
                    decimal val = 0;  
  
                    if(decimal.TryParse(fieldValue, out val) == false)  // 将字段值先转化为Decimal类型然后再转化为字符串型，消除类似“.000”的内容, 如果不能转化则为0  
                    {  
                        val = 0;  
                    }  
  
                    fieldValue = val.ToString();  
                }  
            }  
            else if (this._dbfFields[fieldIndex].IsLogic == true)    // L - 逻辑型  
            {  
                if (fieldValue != "T" && fieldValue != "Y")  
                {  
                    fieldValue = "false";  
                }  
                else  
                {  
                    fieldValue = "true";  
                }  
            }  
            else if (this._dbfFields[fieldIndex].IsDate == true|| this._dbfFields[fieldIndex].IsTime == true)   // D - 日期型  T - 日期时间型                      
            {  
                // 暂时不做任何处理  
            }  
  
            return fieldValue;  
        }


        public void SaveToCSV(string csvName = "", bool addTitle = true)
        {
            string separator = ",";
            this._csvName = csvName;
            if (string.IsNullOrWhiteSpace(this._csvName))
            {
                _csvName = string.Format(@"{0}\csv\{1}.csv", _fileInfo.DirectoryName, _fileInfo.Name.Substring(0,_fileInfo.Name.IndexOf('.')));
            }

            SaveDataTableToCSV(_dataTable, this._csvName, addTitle, separator);
        }

        public void SaveToTXT(DispatchFile dispatchFile, string txtName = "", bool addColumn = false)
        {
            string separator = "@";
            this._txtName = txtName;
            if (string.IsNullOrWhiteSpace(this._txtName))
            {
                //_txtName = string.Format(@"{0}\output\{1}.txt", _fileInfo.DirectoryName, _fileInfo.Name.Substring(0, _fileInfo.Name.IndexOf('.')));
                _txtName = string.Format(@"{0}\output\{1}.txt", _fileInfo.DirectoryName, dispatchFile.FileType);
            }

            SaveDataTableToTXT(dispatchFile, _dataTable, this._txtName, addColumn);
            
        }


        public override void GetDispatchFileType()
        {
            //此方法现在用不到
            if (IsFileOpened == false) return;

            string columnNames = "";
            for (int i = 0; i < _dataTable.Columns.Count; i++)
            {
                columnNames += _dataTable.Columns[i].ColumnName.ToString().Trim();
                if (i < _dataTable.Columns.Count - 1)
                {
                    columnNames += ",";
                }
            }
          
            _dispatchFileType = DispatchFileConfig.GetDispatchFileType(_fileName, "", columnNames);
        }


        /// <summary>
        /// 公开的一些属性
        /// </summary>
        public int RecordLength  
        {  
            get  
            {  
                if (IsFileOpened == false)  
                {  
                    return 0;  
                }  
  
                return _dbfHeader.RecordLength;  
            }  
        }  
  
        public int FieldCount  
        {  
            get  
            {  
                if (IsFileOpened == false)  
                {  
                    return 0;  
                }  
  
                return _dbfFields.Length;  
            }  
        }  
  
        public int RecordCount  
        {  
            get  
            {  
                if (IsFileOpened == false || _dbfHeader == null)  
                {  
                    return 0;  
                }  
  
                return _dbfHeader.RecordCount;  
            }  
        }  
  
        public System.Data.DataTable Table  
        {  
            get   
            {
                if (IsFileOpened == false)  
                {  
                    return null;  
                }  
                return _dataTable;   
            }  
        }  
  
        public TDbfField[] DbfFields  
        {  
            get  
            {
                if (this.IsFileOpened == false)  
                {  
                    return null;  
                }  
  
                return _dbfFields;  
            }  
        }

        

    }  
}  