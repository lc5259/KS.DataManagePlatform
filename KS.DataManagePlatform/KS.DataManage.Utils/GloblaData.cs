using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
