using JackSazerak.UWP.Enums;
using JackSazerak.UWP.GameObjects.Weapon;
using JackSazerak.UWP.Objects.Containers;

namespace JackSazerak.UWP.GameObjects.Aircraft
{
    public abstract class BaseAircraft : BaseGameObject
    {
        protected BaseAircraft(string textureName, BaseWeapon primaryWeapon, GameWrapper wrapper) : base(textureName, TILE_TYPE.SPRITES, wrapper)
        {
            PrimaryWeapon = primaryWeapon;
        }

        protected BaseWeapon PrimaryWeapon { get; }

        public abstract string Name { get; }

        protected abstract int AgilityHorizontal { get; }

        protected abstract int AgilityVertical { get; }

        protected abstract int HitPoints { get; }

        protected abstract int UnlockedLevel { get; }

        protected abstract int Cost { get; }

        public void Move(MOVEMENT movementOption)
        {
            switch (movementOption)
            {
                case MOVEMENT.RIGHT:
                    UpdatePosition(AgilityHorizontal);
                    break;
                case MOVEMENT.LEFT:
                    UpdatePosition(AgilityHorizontal * -1);
                    break;
                case MOVEMENT.UP:
                    UpdatePosition(0, AgilityVertical * -1);
                    break;
                case MOVEMENT.DOWN:
                    UpdatePosition(0, AgilityVertical);
                    break;
            }
        }
    }
}