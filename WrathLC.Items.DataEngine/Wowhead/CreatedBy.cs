using System.Xml.Serialization;

namespace WrathLC.Items.DataEngine.Wowhead
{
    [XmlRoot(ElementName = "createdBy")]
    public class CreatedBy
    {
        [XmlElement(ElementName = "spell")]
        public Spell Spell { get; set; }
    }
}