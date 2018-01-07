using JackSazerak.Library.Enums;
using JackSazerak.Library.Objects;

using JackSazerak.Library.Objects.Containers;

using Microsoft.Xna.Framework;

namespace JackSazerak.Library.GameObjects
{
    public abstract class BaseGameObject : Tile
    {
        protected BaseGameObject(string textureName, TileType tileType, GameWrapper wrapper, Vector2? size = null, Vector2? position = null) : base(textureName, tileType, wrapper, size, position)
        {
        }
    }
}