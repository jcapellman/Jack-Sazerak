using JackSazerak.UWP.Enums;

namespace JackSazerak.UWP.Objects
{
    public abstract class BaseObject<T, K>
    {
        public TILE_TYPE TileType { get; set; }
    }
}