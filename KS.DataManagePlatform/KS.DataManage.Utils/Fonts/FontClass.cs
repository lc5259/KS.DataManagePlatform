using System;
using System.Drawing;
using System.Drawing.Text;

namespace KS.DataManage.Utils
{
    public class FontClass
    {
        private static readonly PrivateFontCollection Fonts = new PrivateFontCollection();
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
           IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);
        private static void InitialiseFont()
        {
            try
            {
                //unsafe
                //{
                //    fixed (byte* pFontData = Properties.Resources.fontawesome_webfont)
                //    {
                //        uint dummy = 0;
                //        Fonts.AddMemoryFont((IntPtr)pFontData, Properties.Resources.fontawesome_webfont.Length);
                //        AddFontMemResourceEx((IntPtr)pFontData, (uint)Properties.Resources.fontawesome_webfont.Length, IntPtr.Zero, ref dummy);
                //    }
                //}
            }
            catch (Exception ex)
            {
                // log?
            }
        }

        //static string AppPath = Application.StartupPath;
        //public static Font LoadFontFromFile()
        //{
        //    try
        //    {
        //        PrivateFontCollection font = new PrivateFontCollection();
        //        font.AddFontFile(AppPath + @"/Font/fontawesome-webfont.ttf");//字体的路径及名字 
        //        Font myFont = new Font(font.Families[0].Name, 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        //        //设置窗体控件字体，哪些控件要更改都写到下面
        //        return myFont;
        //    }
        //    catch
        //    {
        //        MessageBox.Show("字体不存在或加载失败/n程序将以默认字体显示", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //    }
        //    return null;
        //}
        private static Font GetIconFont(float size = 12F)
        {
            return new Font(Fonts.Families[0], size, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        /// <summary>
        /// 设置button图标
        /// </summary>
        /// <param name="kBtn">kryptonButton</param>
        /// <param name="text">显示名称</param>
        /// <returns></returns>
        //public static bool LoadFont4KBtn(KryptonButton kBtn, string text)
        //{
        //    InitialiseFont();
        //    Font temp =  GetIconFont(12F);
        //    if (temp != null)
        //    {
        //        kBtn.StateNormal.Content.ShortText.Font = temp;
        //        kBtn.StatePressed.Content.ShortText.Font = temp;
        //        kBtn.StateTracking.Content.ShortText.Font = temp;
        //        kBtn.OverrideFocus.Content.ShortText.Font = temp;
        //        kBtn.StateCommon.Content.ShortText.Font = temp;
        //        //kBtn.Values.Text = text;

        //        switch (text)
	       //     {
        //            case "查询":
        //                kBtn.Values.Text = "\uF002 " + text; //查询
        //                break;
        //            case "新增":
        //                kBtn.Values.Text = "\uF067 " + text; //新增
        //                break;
        //            case "删除":
        //                kBtn.Values.Text = "\uF014 " + text; //删除
        //                break;
        //            case "修改":
        //                kBtn.Values.Text = "\uF044 " + text; //修改
        //                break;
        //            case "复制":
        //                kBtn.Values.Text = "\uF0C5 " + text; //复制
        //                break;
        //            case "导入":
        //                kBtn.Values.Text = "\uF019 " + text; //导入
        //                break;
        //            case "导出":
        //                kBtn.Values.Text = "\uF093 " + text; //导出
        //                break;
        //            case "保存":
        //                kBtn.Values.Text = "\uF00C  " + text; //确认保存  //uF058
        //                break;
        //            case "确认":
        //                kBtn.Values.Text = "\uF00C  " + text; //确认保存  //uF058
        //                break;
        //            case "取消":
        //                kBtn.Values.Text = "\uF00D " + text; //取消     //uF059
        //                break;
        //            default:
        //                kBtn.Values.Text = "\uF059 " + text; //默认问号
        //                break;
	       //     }
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

    }
}
