using JackSazerak.Library.Enums;

namespace JackSazerak.Library.Objects
{
    public abstract class BaseObject<T, K>
    {
        public TileType TileType { get; set; }
    }
}