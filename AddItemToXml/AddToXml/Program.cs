using System.Xml.Linq;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AddToXml
{
    static class Program
    {
        static void Main(string[] args)
        {
            AddElementDynamic<Student>("Student.xml");

        }
        static void AddElementInXml(string spath, string xDocElement, string xRootElement)
        {
            XDocument doc = XDocument.Load(spath);
            XElement root = new XElement(xRootElement);
            root.Add(new XElement("name", "name goes here"));
            root.Add(new XElement("SnippetCode", "SnippetCode"));
            doc.Element(xDocElement).Add(root);
            doc.Save(spath);
        }
        static void AddElementDynamic<T>( string xPath)
        {
            XDocument xdoc = XDocument.Load(xPath);
            Type type = typeof(T);
            PropertyInfo[] members = type.GetProperties(BindingFlags.Instance
                | BindingFlags.Public
                | BindingFlags.DeclaredOnly);

            members = members
                .ToArray();

            XElement xElement = new XElement(type.Name);
            foreach (var member in members)
            {
                string elementName = member.Name;
                object value =  member.GetValue(member.Name);
                xElement.Add(new XElement(elementName, value));
            }
            xdoc.Save(xPath);
            
        }
    }
}
