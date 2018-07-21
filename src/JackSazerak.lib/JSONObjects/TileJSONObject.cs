using System.Runtime.Serialization;

using JackSazerak.lib.Enums;

namespace JackSazerak.lib.JSONObjects
{
    [DataContract]
    public class TileJSONObject
    {
        [DataMember]
        public MapLayers Layer { get; set; }

        [DataMember]
        public string TextureName { get; set; }

        [DataMember]
        public int XPosition { get; set; }

        [DataMember]
        public int YPosition { get; set; }
    }
}