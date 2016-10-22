using System.Collections.Generic;
using System.Collections.Specialized;

namespace XmlParser
{
    class XmlTag
    {
        public OrderedDictionary Attributes { get; set; }
        public List<XmlTag> Children { get; set; }
        public XmlTag Parent { get; set; }
        public string Name { get; set; }

        public XmlTag()
        {
            Attributes = new OrderedDictionary();
            Children = new List<XmlTag>();
        }
    }
}
