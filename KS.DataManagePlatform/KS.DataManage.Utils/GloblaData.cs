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
      
    }
}
