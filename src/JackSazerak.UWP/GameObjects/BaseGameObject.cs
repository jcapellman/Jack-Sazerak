using JackSazerak.UWP.Enums;
using JackSazerak.UWP.Objects;
using JackSazerak.UWP.Objects.Containers;

using Microsoft.Xna.Framework;

namespace JackSazerak.UWP.GameObjects
{
    public abstract class BaseGameObject : Tile
    {
        protected BaseGameObject(string textureName, TILE_TYPE tileType, GameWrapper wrapper, Vector2? size = null, Vector2? position = null) : base(textureName, tileType, wrapper, size, position)
        {
        }
    }
}