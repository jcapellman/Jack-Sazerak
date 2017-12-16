using JackSazerak.UWP.Enums;
using JackSazerak.UWP.Objects;
using JackSazerak.UWP.Objects.Containers;

namespace JackSazerak.UWP.GameObjects
{
    public abstract class BaseGameObject : Tile
    {
        protected BaseGameObject(string textureName, TILE_TYPE tileType, GameWrapper wrapper) : base(textureName, tileType, wrapper)
        {
        }
    }
}