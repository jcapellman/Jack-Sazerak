using JackSazerak.UWP.Enums;
using JackSazerak.UWP.Objects.Containers;

namespace JackSazerak.UWP.GameObjects.Weapon
{
    public abstract class BaseWeapon : BaseGameObject
    {
        protected BaseWeapon(string textureName, GameWrapper wrapper) : base(textureName, TILE_TYPE.SPRITES, wrapper)
        {
        }
    }
}