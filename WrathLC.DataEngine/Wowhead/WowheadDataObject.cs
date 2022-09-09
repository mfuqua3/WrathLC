using System.Xml.Serialization;

namespace WrathLC.DataEngine.WowHead
{

    [XmlRoot(ElementName = "wowhead")]
    public class WowheadDataObject
    {
        [XmlElement(ElementName = "item")]
        public XmlWarcraftItem Item { get; set; }
    }
}