using System;

namespace XmlParser
{
    class Program
    {
        static void Main(string[] args)
        {
            string xmlString = @"
            <Company>
                <Direction>
                    <Person Surname=""Петров"" Name=""Иван""></Person>
                </Direction>
                <Staff>
                    <Person Surname=""Сидоров"" Name=""Андрей""></Person>
                    <Person Surname=""Иванова"" Name=""Мария""></Person>
                </Staff>
            </Company>
            ";

            XmlDocument xmlDoc = XmlParser.Parse(xmlString);

            Console.WriteLine(     xmlDoc.Root.Name + '.');
            Console.WriteLine(     xmlDoc.Root.Children[0].Name + ':');
            Console.Write("    " + xmlDoc.Root.Children[0].Children[0].Name + " - ");
            Console.WriteLine(     xmlDoc.Root.Children[0].Children[0].Attributes[0] + " "
                                 + xmlDoc.Root.Children[0].Children[0].Attributes[1]);

            Console.WriteLine(     xmlDoc.Root.Children[1].Name + ':');
            Console.Write("    " + xmlDoc.Root.Children[1].Children[0].Name + " - ");
            Console.WriteLine(     xmlDoc.Root.Children[1].Children[0].Attributes[0] + " "
                                 + xmlDoc.Root.Children[1].Children[0].Attributes[1]);

            Console.Write("    " + xmlDoc.Root.Children[1].Children[1].Name + " - ");
            Console.WriteLine(     xmlDoc.Root.Children[1].Children[1].Attributes[0] + " "
                                 + xmlDoc.Root.Children[1].Children[1].Attributes[1]);
        }
    }
}
