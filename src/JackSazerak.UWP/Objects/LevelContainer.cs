using JackSazerak.UWP.Objects.JSONObjects;

using Microsoft.Xna.Framework.Content;

using System.Collections.Generic;

namespace JackSazerak.UWP.Objects
{
    public class LevelContainer : BaseObject<Level, LevelContainer>
    {
        public List<Tile> Tiles { get; set; }

        public Player CurrentPlayer { get; set; }

        public LevelContainer(Level jsonObject, ContentManager contentManager)
        {
            foreach (var tile in jsonObject.Tiles)
            {
                Tiles.Add(new Tile(tile, contentManager));
            }
        }
    }
}