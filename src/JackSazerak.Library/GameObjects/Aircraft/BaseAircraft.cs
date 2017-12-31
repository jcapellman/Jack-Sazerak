using JackSazerak.Library.Enums;
using JackSazerak.Library.GameObjects.Weapon;
using JackSazerak.Library.Objects.Containers;

namespace JackSazerak.Library.GameObjects.Aircraft
{
    public abstract class BaseAircraft : BaseGameObject
    {
        protected BaseAircraft(string textureName, BaseWeapon primaryWeapon, GameWrapper wrapper) : base(textureName, TileType.SPRITES, wrapper)
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

        public void Move(Movement movementOption)
        {
            switch (movementOption)
            {
                case Movement.RIGHT:
                    UpdatePosition(AgilityHorizontal);
                    break;
                case Movement.LEFT:
                    UpdatePosition(AgilityHorizontal * -1);
                    break;
                case Movement.UP:
                    UpdatePosition(0, AgilityVertical * -1);
                    break;
                case Movement.DOWN:
                    UpdatePosition(0, AgilityVertical);
                    break;
            }
        }
    }
}