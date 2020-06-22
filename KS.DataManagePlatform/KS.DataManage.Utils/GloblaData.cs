using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KS.DataManage.Utils
{
    public static class GloblaData
    {
        public static string SysConfigPath
        {
            get
            {
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Config\SysConfig.xml"); 
            }
        }
    }
}
