using System;
using System.Windows.Forms;
namespace KS.DataManage.Client
{
	public class ApplicationInitializer
	{
		private static readonly string _currentPath = AppDomain.CurrentDomain.BaseDirectory;
        //private static readonly string _loggingConfigPath = ApplicationInitializer._currentPath + "\\Config\\LoggingConfigure.xml";
        //private static readonly string _resourcePath = ApplicationInitializer._currentPath + "Config\\ResourceConfigure.xml";
        //private static readonly string _exceptionPath = ApplicationInitializer._currentPath + "Config\\ExceptionConfigure.xml";
        //private static readonly string _configurePath = ApplicationInitializer._currentPath + "Config\\Configure.xml";
		private static FrmMain _MainForm = null;
		private static void Update(Form frm)
		{
			frm.Visible = false;
		}
		public static FrmMain GetMainForm()
		{
			return ApplicationInitializer._MainForm;
		}
		public static FrmMain CreateMainForm()
		{
			ApplicationInitializer._MainForm = new FrmMain();
            //有啥用?11
			ApplicationInitializer._MainForm.CreateControl();
			return ApplicationInitializer._MainForm;
		}
		public static void SuccessLogin()
		{
            //Application.AddMessageFilter(new SystemMessageFilter(ApplicationInitializer._MainForm));
            //Kingstar.Core.ApplicationContext.OnApplicationInitialized(null, new ApplicationInitializedEvent(ApplicationInitializer._MainForm));
		}
		public static bool CallLogin()
		{
            ApplicationInitializer._MainForm.Initialize();
            return (ApplicationInitializer._MainForm.DialogResult != DialogResult.Cancel && ApplicationInitializer._MainForm.DialogResult != DialogResult.Abort);
        }

		public static void InvokeInitializeMainForm()
		{
			ApplicationInitializer._MainForm.InvokeInitializeBeforeLoad();
		}
		public static void InitializeMainForm()
		{
			ApplicationInitializer._MainForm.InitializeBeforeLoad();
			//Application.AddMessageFilter(new SystemMessageFilter(ApplicationInitializer._MainForm)); //消息过滤器?
		}
		public static void Run()
		{
            //SystemContext.CreateLoginPlugIn();
            //SystemContext.CreateCommonPlugIn();
		}
	}
}
