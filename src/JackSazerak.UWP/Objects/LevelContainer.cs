using System.Collections.Generic;

namespace JackSazerak.UWP.Objects
{
    public class LevelContainer
    {
        public List<Tile> Tiles { get; set; }

        public LevelContainer()
        {
            Tiles = new List<Tile>();
        }
    }
}