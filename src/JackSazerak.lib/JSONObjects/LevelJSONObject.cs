using System.Collections.Generic;
using System.Runtime.Serialization;

namespace JackSazerak.lib.JSONObjects
{
    [DataContract]
    public class LevelJSONObject
    {
        [DataMember]
        public string FileName { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public List<string> Tiles { get; set; }
    }
}