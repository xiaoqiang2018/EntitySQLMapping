using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ORMProject.ORM.config
{
    public class GetConfig
    {
        public static string Config(string Path,Encoding encoding,string ElementName,out string error_msg)
        {
            string AppDomain_Path = AppDomain.CurrentDomain.BaseDirectory;
            //string FileText = File.ReadAllText(AppDomain_Path+@"Config\"+Path, encoding);
            XElement CmdElement = null;
            error_msg = "";
            try
            {
                XElement element = XElement.Load(AppDomain_Path + @"Config\" + Path);
                CmdElement = element.Element("cmd");
            }
            catch(Exception ex)
            {
                error_msg =  ex.Message;
            }
            return CmdElement.Element(ElementName).Attribute("Value").Value;
        }
    }
}
