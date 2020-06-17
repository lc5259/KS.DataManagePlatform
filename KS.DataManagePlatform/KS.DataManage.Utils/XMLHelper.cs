using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace KS.DataManage.Utils
{
    public static class XMLHelper
    {
        /*  例子
        //3.1 新增节点与属性
        public void Create(string xmlPath)
        {
            XDocument xDoc = XDocument.Load(xmlPath);
            XElement xElement = xDoc.Element("BookStore");
            xElement.Add(new XElement("Test", new XAttribute("Name", "Zery")));
            xDoc.Save(xmlPath);
        }
        public void CreateAttribute(string xmlPath)
        {
            XDocument xDoc = XDocument.Load(xmlPath);
            IEnumerable<XElement> xElement = xDoc.Element("BookStore").Elements("Book");
            foreach (var element in xElement)
            {
                element.SetAttributeValue("Name", "Zery");
            }
            xDoc.Save(xmlPath);
        }
        //删除属性
        public void Delete(string xmlPath)
        {
            XDocument xDoc = XDocument.Load(xmlPath);
            XElement element = (XElement)xDoc.Element("BookStore").Element("Book");
            element.Remove();
            xDoc.Save(xmlPath);
        }

        public void DeleteAttribute(string xmlPath)
        {
            XDocument xDoc = XDocument.Load(xmlPath);
            //不能跨级取节点
            XElement element = xDoc.Element("BookStore").Element("Book").Element("Name");
            element.Attribute("BookName").Remove();
            xDoc.Save(xmlPath);
        }

        //修改节点属性
        public void ModifyAttribute(string xmlPath)
        {
            XDocument xDoc = XDocument.Load(xmlPath);
            XElement element = xDoc.Element("BookStore").Element("Book");
            element.SetAttributeValue("BookName", "ZeryTest");
            xDoc.Save(xmlPath);
        }


            /// <summary>
        /// 在文件中查找
        /// </summary>
        /// <param name="xmlfile">包含路径和扩展名的文件名</param>
        //public void SearchInXml(string xmlfile)
        //{
        //    if (File.Exists(xmlfile))
        //    {
        //        XDocument xd = new XDocument();
        //        xd = XDocument.Load(xmlfile);

        //        //获取所有节点
        //        IEnumerable<XNode> nodes = xd.DescendantNodes();
        //        //找到单个节点
        //        IEnumerable<XElement> node = xd.Descendants("class");
        //        //找到特点节点 子节点有element且其属性id值为01
        //        IEnumerable<XElement> element = xd.Descendants("class")
        //            .Where(p => (string)p.Element("student").Attribute("id").Value == "01");
        //        //如果只取一个，可以用下面这个方法 First表示枚举中的第一个
        //        XElement element_first = xd.Descendants("class")
        //            .Where(p => (string)p.Element("student").Attribute("id").Value == "01").First();

        //        //把结果保存到单独的xml文件以进行观察
        //        XDocument xd_nodes = new XDocument(
        //            new XElement("school",
        //               nodes
        //             )
        //        );
        //        xd_nodes.Save("nodes.xml");

        //        XDocument xd_node = new XDocument(
        //            new XElement("school",
        //               node
        //             )
        //        );
        //        xd_node.Save("node.xml");

        //        XDocument xd_element = new XDocument(
        //            new XElement("school",
        //               element
        //             )
        //        );
        //        xd_element.Save("element.xml");


        //        //获取值
        //        var selement = xd.Descendants("class")
        //            .Select(p => new { age = p.Element("student") }); //获得节点

        //        var welement = xd.Descendants("class")
        //            .Where(p => p.Element("student").Attribute("name").Value.Contains("D"))  //条件筛选 寻找student：其name属性的值包含有字母D
        //            .Select(p => new { age = p.Element("student") }); //获得节点

        //        //输出结果
        //        //string strs = "";
        //        //foreach (var a in selement)
        //        //{
        //        //    strs += a.age + "\r\n";
        //        //}

        //        //Console.Write(strs);

        //        //string strw = "";
        //        //foreach (var a in selement)
        //        //{
        //        //    strw += a.age + "\r\n";
        //        //}
        //    }
        //}
        */
        public static void ReadXml(string xmlfile)
        {
            if (File.Exists(xmlfile))
            {
                //省略了判定xml文件存在
                XDocument xd = new XDocument();
                xd = XDocument.Load(xmlfile);
                XElement root = xd.Root;
                ////获取根节点下所有子节点
                //IEnumerable<XElement> xe = root.Elements();
                //foreach (XElement fxe in xe)
                //{
                //    foreach (XElement sxe in fxe.Elements())
                //    {
                //        Console.WriteLine(sxe.Name);
                //        Console.WriteLine(sxe.Attribute("id").Value);
                //    }
                //}
            }
        }

        

        //将xml转为Datable
        public static DataTable XmlToDataTable(string xmlStr)
        {
            if (!string.IsNullOrEmpty(xmlStr))
            {
                StringReader StrStream = null;
                XmlTextReader Xmlrdr = null;
                try
                {
                    DataSet ds = new DataSet();
                    //读取字符串中的信息
                    StrStream = new StringReader(xmlStr);
                    //获取StrStream中的数据
                    Xmlrdr = new XmlTextReader(StrStream);
                    //ds获取Xmlrdr中的数据               
                    ds.ReadXml(Xmlrdr);
                    return ds.Tables[0];
                }
                catch (Exception e)
                {
                    return null;
                }
                finally
                {
                    //释放资源
                    if (Xmlrdr != null)
                    {
                        Xmlrdr.Close();
                        StrStream.Close();
                        StrStream.Dispose();
                    }
                }
            }
            return null;
        }


        //将datatable转为xml
        public static string DataTable2Xml(DataTable vTable)
        {
            if (null == vTable) return string.Empty;
            StringWriter writer = new StringWriter();
            vTable.WriteXml(writer);
            string xmlstr = writer.ToString();
            writer.Close();
            return xmlstr;
        }
    }
}
