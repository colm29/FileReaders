using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;

namespace FileParser
{
    class XMLReader
    {
        string Path;

        public XMLReader(string path)
        {
            this.Path = path;
        }

        public string[] ReadXML()
        {
            XDocument X = XDocument.Load(Path);
            List<string> els = new List<string>();

            IEnumerable<XElement> list = X.XPathSelectElements("/InputDocument/DeclarationList/Declaration/DeclarationHeader/Reference").Where(c => c.Attribute("RefCode").Value == "MWB").Select(c => c.Element("RefText"));
            foreach (XElement el in list)
                els.Add(el.Value);


            IEnumerable<XElement> list1 = X.XPathSelectElements("/InputDocument/DeclarationList/Declaration/DeclarationHeader/Reference").Where(c => c.Attribute("RefCode").Value == "TRV").Select(c => c.Element("RefText"));
            foreach (XElement el in list1)
                els.Add(el.Value); 

            IEnumerable<XElement> list2 = X.XPathSelectElements("/InputDocument/DeclarationList/Declaration/DeclarationHeader/Reference").Where(c => c.Attribute("RefCode").Value == "CAR").Select(c => c.Element("RefText"));
            foreach (XElement el in list2)
                els.Add(el.Value);


            return els.ToArray();
        }
    }
}
