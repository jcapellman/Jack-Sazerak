using JackSazerak.UWP.Enums;
using JackSazerak.UWP.Objects.JSONObjects;

using Microsoft.Xna.Framework.Content;

namespace JackSazerak.UWP.Objects
{
    public class Player : Tile
    {
        public Player(string spriteName, ContentManager contentManager) : base(new LevelTile { TextureName = spriteName, TileType = TILE_TYPE.SPRITES}, contentManager) { }                
    }
}