using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KS.DataManage.Utils
{
    public static class AppDatas
    {
         //静态数据成员
         static List<string> listData;
        //静态构造函数
        static AppDatas()
        {
           
        }
        //静态属性
        public static List<string> ListData
        {
            get { return listData; }
            set {
                listData = value;
            }
        }

        //静态属性
        public static string CffexFile
        { get; set; }

        //静态属性
        public static string CfmmcFile
        { get; set; }

        //静态属性
        public static string Cffexext
        { get; set; }

        //静态属性
        public static string Cfmmcext
        { get; set; }



        //静态方法
        public static List<string> GetListData()
        {
            return listData;
        }
    }

}
