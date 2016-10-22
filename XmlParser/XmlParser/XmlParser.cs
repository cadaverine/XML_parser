using System;
using System.Collections.Generic;

namespace XmlParser
{
    class XmlParser
    {
        public static XmlDocument Parse(string xmlStr)
        {
            XmlDocument xmlDoc = new XmlDocument();

            Stack<XmlTag> stack = new Stack<XmlTag>();

            for (int index = 0; index < xmlStr.LastIndexOf('>') && xmlDoc.Root == null;)
            {
                string tagStr = TagToString(xmlStr, ref index);

                if (tagStr[0] != '/')
                {
                    stack.Push(new XmlTag());
                    FillXmlTag(stack.Peek(), tagStr);
                }
                else
                {
                    XmlTag temp = stack.Pop();
                    if (stack.Count != 0)
                    {
                        temp.Parent = stack.Peek();
                        stack.Peek().Children.Add(temp);
                    }
                    else
                    {
                        xmlDoc.Root = temp;
                    }
                }
            }
            return xmlDoc;
        }
  
        protected static string TagToString(string xmlStr, ref int i)
        {
            i = xmlStr.IndexOf('<', i);
            int j = xmlStr.IndexOf('>', ++i);

            string tagStr = xmlStr.Substring(i, j - i);
            i = ++j;

            return tagStr;
        }

        // Вспомогательный метод для заполнения полей класса XmlTag
        protected static void FillXmlTag(XmlTag xmlTag, string tagStr)
        {
            string[] tempStrArr = tagStr.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            xmlTag.Name = tempStrArr[0];

            for (int i = 1; i < tempStrArr.Length; i++)
            {
                string[] attribute = tempStrArr[i].Split('=');
                xmlTag.Attributes.Add(attribute[0], attribute[1].Trim('"'));
            }
        }
    }
}
