using JackSazerak.UWP.Objects.JSONObjects;
using JackSazerak.UWP.Enums;
using JackSazerak.UWP.Objects.Containers;

using System.Collections.Generic;

using Microsoft.Xna.Framework;

namespace JackSazerak.UWP.Objects
{
    public class LevelContainer : BaseObject<Level, LevelContainer>
    {
        public List<Text> TextElements { get; set; }

        public List<Tile> Tiles { get; set; }

        public Player CurrentPlayer { get; set; }

        public LevelContainer(Level jsonObject, GameWrapper gameWrapper)
        {
            Tiles = new List<Tile>
            {
                new Tile(new LevelTile
                {
                    TileType = TILE_TYPE.BACKGROUNDS,
                    TextureName = jsonObject.Background
                }, gameWrapper)
            };

            foreach (var tile in jsonObject.Tiles)
            {
                Tiles.Add(new Tile(tile, gameWrapper));
            }

            CurrentPlayer = new Player(jsonObject.CurrentPlayer, gameWrapper);

            TextElements = new List<Text>
            {
                new Text(jsonObject.LevelName, Color.White, gameWrapper.ContentManager)
            };
        }
    }
}