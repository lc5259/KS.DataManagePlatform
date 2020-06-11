using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KS.DataManage.Entity
{
    /// <summary>
    /// 配置1级AccountID
    /// </summary>
    public class AccountID
    {
        public string value { get; set; }
        public string cffexFile { get; set; }
        public string cfmmcFile { get; set; }
        public string cffexext { get; set; }
        public string cfmmcext { get; set; }
        public string outType { get; set; }
        public string cffexpath1 { get; set; }
        public string cffexpath2 { get; set; }
        public string cfmmcpath1 { get; set; }
        public string cfmmcpath2 { get; set; }

        public class DlgConfigSettings
        {
            public class CConfigDlgField
            {
                public List<ChildNode> child = new List<ChildNode>();
            }

            public class CConfigDlgExtract
            {
                public List<ChildNode> child = new List<ChildNode>();
            }

            public class CConfigDlgOutput
            {
                public List<ChildNode> child = new List<ChildNode>();
            }

            public class CConfigDlgEmail
            {
                public List<ChildNode> child = new List<ChildNode>();
            }

            public class CconfigDlgFilePath
            {
                public List<ChildNode> child = new List<ChildNode>();
            }

            public class CConfigDlgFileExtract
            {
                public List<ChildNode> child = new List<ChildNode>();
            }

        }
        public List<OrganCode> listOrganCode = new List<OrganCode>();
    }


    public class ChildNode
    {
        public string INFO { get; set; }
        public string id { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public string value { get; set; }
        public string defaultvalue { get; set; }
        public string controlvalue { get; set; }
    }
}
