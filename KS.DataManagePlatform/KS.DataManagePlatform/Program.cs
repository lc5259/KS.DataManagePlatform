using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;
using KS.DataManage.Utils;

namespace KS.DataManagePlatform
{
    static class Program
    {
        private static IntPtr handle = IntPtr.Zero;
        private static Form mainForm = null;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            MethodInfo method2 = null;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string processName = Process.GetCurrentProcess().ProcessName;
            if (Process.GetProcessesByName(processName).Length > 1)
            {
                MessageBox.Show("程序实例已经运行", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Environment.Exit(0);
                return;
            }
            try
            {
                //处理未捕获的异常   
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                //处理UI线程异常   
                Application.ThreadException += Application_ThreadException;
                //处理非UI线程异常   
                AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

                AppStartLogoForm appStartLogoForm = new AppStartLogoForm();
                //appStartLogoForm.Show();
                Application.DoEvents();
                if (appStartLogoForm.Run())
                {
                    appStartLogoForm.Close();
                }
                Assembly assembly = Assembly.Load(@"KS.DataManage.Client");
                Type type = assembly.GetType("KS.DataManage.Client.ApplicationInitializer");
                MethodInfo method = type.GetMethod("GetMainForm", BindingFlags.Static | BindingFlags.Public);
                Program.mainForm = (Form)method.Invoke(method, null);
                Program.handle = Program.mainForm.Handle;
                method = type.GetMethod("CallLogin", BindingFlags.Static | BindingFlags.Public);
                if ((bool)method.Invoke(method, null))
                {
                    method = type.GetMethod("SuccessLogin", BindingFlags.Static | BindingFlags.Public);
                    method.Invoke(method, null);
                    Application.Run(Program.mainForm);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Log.Error(ex.Message + "; " + ex.StackTrace);
            }
            finally
            {
                try
                {
                    if (method2 != null)
                    {
                        method2.Invoke(method2, new object[]
                            {
                                "系统关闭"
                            });
                    }
                    Process.GetCurrentProcess().Kill();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            //LogHelper.WriteLog(e.Exception.Message, e.Exception);

            Log.Error(e.Exception.Message);
            MessageBox.Show("操作中出现错误！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        static void AppDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            //可以记录日志并转向错误bug窗口友好提示用户
            Exception ex = e.ExceptionObject as Exception;

            Log.Error(ex.Message);
            //LogHelper.WriteLog(ex.Message, ex);
            MessageBox.Show("操作中出现错误！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var ex = e.ExceptionObject as Exception;
            if (ex != null)
            {
                //LogHelper.Log(ex);
                MessageBox.Show(ex.ToString());
            }

            MessageBox.Show("系统出现未知异常，请重启系统！");
        }
    }
}
