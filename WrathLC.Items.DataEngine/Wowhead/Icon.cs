using System.Xml.Serialization;

namespace WrathLC.Items.DataEngine.Wowhead
{
    public class Icon
    {
        [XmlAttribute(AttributeName = "displayId")]
        public int DisplayId { get; set; }
        [XmlText]
        public string IconName { get; set; }
    }
}