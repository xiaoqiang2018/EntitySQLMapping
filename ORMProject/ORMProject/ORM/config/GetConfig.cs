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
        public static string Config(string Path,Encoding encoding,string ElementName)
        {
            string FileText = File.ReadAllText(Path, encoding);
            XElement element = XElement.Load(FileText);
            XElement CmdElement = element.Element("cmd");
            return CmdElement.Element(ElementName).Attribute("Value").Value;
        }
    }
}
