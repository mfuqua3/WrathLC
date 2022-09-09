using System.Xml.Serialization;

namespace WrathLC.Items.DataEngine.Wowhead
{

    [XmlRoot(ElementName = "wowhead")]
    public class WowheadDataObject
    {
        [XmlElement(ElementName = "item")]
        public XmlWarcraftItem Item { get; set; }
    }
}