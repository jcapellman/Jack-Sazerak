using JackSazerak.UWP.Enums;
using JackSazerak.UWP.Objects.Containers;

namespace JackSazerak.UWP.GameObjects.Weapon
{
    public abstract class BaseWeapon : BaseGameObject
    {
        protected BaseWeapon(string textureName, GameWrapper wrapper) : base(textureName, TILE_TYPE.WEAPONS, wrapper)
        {        
        }
        
        protected abstract int RateOfFire { get; }

        protected abstract int Damage { get; }
    }
}