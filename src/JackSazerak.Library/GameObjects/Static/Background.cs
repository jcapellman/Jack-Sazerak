using JackSazerak.Library.Enums;
using JackSazerak.Library.Objects.Containers;

namespace JackSazerak.Library.GameObjects.Static
{
    public class Background : BaseGameObject
    {
        public Background(string textureName, GameWrapper wrapper) : base(textureName, TileType.BACKGROUNDS, wrapper)
        {            
        }
    }
}