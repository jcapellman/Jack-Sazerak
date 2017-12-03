using JackSazerak.UWP.Enums;
using JackSazerak.UWP.Objects;
using JackSazerak.UWP.Objects.Containers;
using JackSazerak.UWP.Objects.JSONObjects;

namespace JackSazerak.UWP.GameObjects
{
    public class BaseGameObject : Tile
    {
        public BaseGameObject(string textureName, TILE_TYPE tileType, GameWrapper wrapper) : base(new LevelTile { TextureName = textureName, TileType = tileType}, wrapper)
        {
        }
    }
}