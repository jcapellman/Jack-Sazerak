using System.Runtime.Serialization;

namespace JackSazerak.UWP.Objects.JSONObjects
{
    [DataContract]
    public class LevelTile
    {
        [DataMember]
        public string TextureName { get; set; }

        [DataMember]
        public int PositionX { get; set; }

        [DataMember]
        public int PositionY { get; set; }

        [DataMember]
        public int Width { get; set; }

        [DataMember]
        public int Height { get; set; }
    }
}