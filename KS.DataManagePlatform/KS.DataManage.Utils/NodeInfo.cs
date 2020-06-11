using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KS.DataManage.Utils
{
    public class NodeInfo
    {
        public NodeInfo()
        {

        }
        public NodeInfo(string name, string text, string tag)
        {
            this.NodeName = name;
            this.NodeText = text;
            this.NodeTag = tag;
        }

        public string NodeName { get; set; }
        public string NodeText { get; set; }
        public string NodeTag { get; set; }
    }

}
