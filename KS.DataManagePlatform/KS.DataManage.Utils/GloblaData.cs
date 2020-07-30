using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace KS.DataManage.Utils
{
    public static class GlobalData
    {
        public static string SysConfigPath
        {
            get
            {
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Config\SysConfig.xml"); 
            }
        }

        public static string GetGeneConfigPath(string grp)
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Config\\{0}_UserConfig.xml", grp));
        }

        public static string GetDataConfigPath(string account)
        {
             return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Config\\{0}_ListCfg.xml", account));
        }

        private static List<string> _AccountGroup = new List<string>();
        public static List<string> AccountGroup
        {
            get
            {
                return _AccountGroup;
            }
            set
            {
                _AccountGroup = value;
            }
        }
        private static XElement _TemplateConfigInfo;
        public static XElement TemplateConfigInfo
        {
            get
            {
                return _TemplateConfigInfo;
            }
            set
            {
                _TemplateConfigInfo = value;
            }
        }
        private static string _TargetFileTitle;
        public static string GlobaTargetFileTitle
        {
            get
            {
                return _TargetFileTitle;
            }
            set
            {
                _TargetFileTitle = value;
            }
        }
        private static string _TSourceFileName;
        public static string GlobaSourceFileName
        {
            get
            {
                return _TSourceFileName;
            }
            set
            {
                _TSourceFileName = value;
            }
        }
        private static string _SeatNo;
        public static string SeatNo
        {
            get
            {
                return _SeatNo;
            }
            set
            {
                _SeatNo = value;
            }
        }
        private static string _CompanyName;
        public static string CompanyName
        {
            get
            {
                return _CompanyName;
            }
            set
            {
                _CompanyName = value;
            }
        }
        private static string _SGMemberID;  //中金所会员号
        public static string SGMemberID
        {
            get
            {
                return _SGMemberID;
            }
            set
            {
                _SGMemberID = value;
            }
        }
    }
}
