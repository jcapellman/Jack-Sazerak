using JackSazerak.UWP.Enums;
using JackSazerak.UWP.Objects.Containers;
using JackSazerak.UWP.Objects.JSONObjects;

namespace JackSazerak.UWP.Objects
{
    public class Player : Tile
    {
        public Player(string spriteName, GameWrapper gameWrapper) : base(new LevelTile
        {
            TextureName = spriteName, TileType = TILE_TYPE.SPRITES
        }, gameWrapper) { }                
    }
}