using JackSazerak.UWP.Objects.JSONObjects;

using System.Collections.Generic;

namespace JackSazerak.UWP.Objects
{
    public class LevelContainer : BaseObject<Level, LevelContainer>
    {
        public List<Tile> Tiles { get; set; }

        public Player CurrentPlayer { get; set; }

        public LevelContainer()
        {
            Tiles = new List<Tile>();
        }

        public override LevelContainer FromJSON(Level jsonObject)
        {
            foreach (var tile in jsonObject.Tiles)
            {
                Tiles.Add(new Tile().FromJSON(tile));
            }

            return this;
        }
    }
}