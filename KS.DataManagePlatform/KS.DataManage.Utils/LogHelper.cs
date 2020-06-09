using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using log4net;
namespace KS.DataManage.Utils
{
    /// <summary>
    /// 日志操作
    /// </summary>
    public static class LogHelper
    {
        public static readonly log4net.ILog loginfo = log4net.LogManager.GetLogger("loginfo");

        public static readonly log4net.ILog logerror = log4net.LogManager.GetLogger("logerror");

        public static void WriteLog(string info)
        {
            if (loginfo.IsInfoEnabled)
            {
                loginfo.Info(info);
            }
        }

        public static void WriteLog(string info, Exception se)
        {
            if (logerror.IsErrorEnabled)
            {
                logerror.Error(info, se);
            }
        }

        public static void WriteLog<T>(T model, string remark = null)
        {
            Type t = model.GetType();
            var info = new System.Text.StringBuilder(remark);

            foreach (System.Reflection.PropertyInfo p in t.GetProperties())
            {
                info.AppendFormat(" {0}={1},", p.Name, p.GetValue(model, null));
            }

            if (loginfo.IsInfoEnabled)
            {
                loginfo.Info(info.ToString());
            }
        }
    }
}
