using System;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using Animal_;


namespace lab7_CS
{
    internal class Program
    {
       

        public static XElement GenerateClassDiagramXml()
        {
            var diagramXml = new XElement("ClassDiagram");
            var assembly = Assembly.GetAssembly(typeof(Animal));

            foreach (var type in assembly.GetTypes())
            {
                var typeXml = new XElement("Class");
                var typeName = type.Name;

                var customCommentAttribute = type.GetCustomAttribute<Animal_.CustomCommentAttribute>();
                if (customCommentAttribute != null)
                {
                    typeXml.Add(new XElement("Comment", customCommentAttribute.Comment));
                }

                typeXml.Add(new XElement("Name", typeName));

                var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (var property in properties)
                {
                    var propertyXml = new XElement("Property");
                    propertyXml.Add(new XElement("Name", property.Name));
                    propertyXml.Add(new XElement("Type", property.PropertyType.Name));
                    typeXml.Add(propertyXml);
                }

                var methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                    .Where(m => !m.IsSpecialName); // Exclude getter and setter methods
                foreach (var method in methods)
                {
                    var methodXml = new XElement("Method");
                    methodXml.Add(new XElement("Name", method.Name));
                    methodXml.Add(new XElement("ReturnType", method.ReturnType.Name));
                    typeXml.Add(methodXml);
                }

                diagramXml.Add(typeXml);
            }

            return diagramXml;
        }

        public static void Main(string[] args)
        {

            var diagramXml = GenerateClassDiagramXml();
            diagramXml.Save("ClassDiagram.xml");

            Console.WriteLine("Class diagram XML generated successfully.");
        }
    }
}
