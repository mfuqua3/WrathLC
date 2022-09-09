﻿using System.Xml.Serialization;

namespace WrathLC.Items.DataEngine.Wowhead
{
    [XmlRoot(ElementName = "quality")]
    public class Quality
    {
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlText]
        public string Text { get; set; }
    }
}