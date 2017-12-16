using JackSazerak.UWP.Enums;
using JackSazerak.UWP.Objects.Containers;

namespace JackSazerak.UWP.GameObjects.Static
{
    public class MenuSelector : BaseGameObject
    {
        public MenuSelector(string textureName, GameWrapper wrapper) : base(textureName, TILE_TYPE.SPRITES, wrapper)
        {            
        }
    }
}