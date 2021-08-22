using System.Collections.Generic;
using System.Xml.Serialization;

namespace csExemple.xml_Read_Write
{
   
    [XmlRoot(ElementName = "Werte")]
    public class xmlWerte_all
    {
        [XmlAttribute(AttributeName = "Name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "xx")]
        public string xx { get; set; }
        [XmlAttribute(AttributeName = "wert")]
        public string wert { get; set; }
        [XmlAttribute(AttributeName = "Default")]
        public string Default { get; set; }
        [XmlAttribute(AttributeName = "Min")]
        public string Min { get; set; }
        [XmlAttribute(AttributeName = "Max")]
        public string Max { get; set; }
        [XmlAttribute(AttributeName = "Show")]
        public string Show { get; set; }
    }

    [XmlRoot(ElementName = "BeispielWerte")]
    public class xmlWerte
    {
        [XmlElement(ElementName = "Werte")]
        public List<xmlWerte_all> Parameter { get; set; }
        [XmlAttribute(AttributeName = "Fingerprint")]
        public string Fingerprint { get; set; }
    }


}
