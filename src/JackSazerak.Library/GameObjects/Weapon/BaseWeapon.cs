using JackSazerak.Library.Enums;

using JackSazerak.Library.Objects.Containers;

namespace JackSazerak.Library.GameObjects.Weapon
{
    public abstract class BaseWeapon : BaseGameObject
    {
        protected BaseWeapon(string textureName, GameWrapper wrapper) : base(textureName, TileType.WEAPONS, wrapper)
        {        
        }
        
        protected abstract int RateOfFire { get; }

        protected abstract int Damage { get; }
    }
}