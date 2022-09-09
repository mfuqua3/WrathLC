﻿using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WrathLC.DataEngine.WowHead
{
    public class WowheadJson
    {
        [JsonPropertyName("classs")] 
        public int ItemClass { get; set; }
        public int Id { get; set; }
        [JsonPropertyName("level")] 
        public int ItemLevel { get; set; }
        public string Name { get; set; }
        public int Quality { get; set; }
        public int ReqLevel { get; set; }
        public int Slot { get; set; }
        public List<int> Source { get; set; }
        
        public override string ToString()
        {
            return $"{Id}: {Name}";
        }
    }
}