using JackSazerak.Library.Enums;
using JackSazerak.Library.Objects.Containers;

namespace JackSazerak.Library.GameObjects.Static
{
    public class MenuSelector : BaseGameObject
    {
        public MenuSelector(string textureName, GameWrapper wrapper) : base(textureName, TileType.SPRITES, wrapper)
        {            
        }
    }
}