using System.Collections.Generic;
using System.Runtime.Serialization;

namespace JackSazerak.UWP.JSONObjects
{
    [DataContract]
    public class Level
    {
        [DataMember]
        public string LevelName { get; set; }

        [DataMember]
        public string Background { get; set; }

        [DataMember]
        public List<LevelTile> Tiles { get; set; }
    }
}