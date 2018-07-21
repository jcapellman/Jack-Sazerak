using System.Windows.Media.Imaging;

using JackSazerak.lib.Enums;

namespace JackSazerak.Editor.Objects
{
    public class Tile
    {
        public BitmapImage Texture { get; set; }

        public bool IsSet { get; set; }

        public string TextureName { get; set; }

        public int XPosition { get; set; }

        public int YPosition { get; set; }

        public MapLayers Layer { get; set; }
    }
}