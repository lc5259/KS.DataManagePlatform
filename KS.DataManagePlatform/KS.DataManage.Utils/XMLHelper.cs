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
        */

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
