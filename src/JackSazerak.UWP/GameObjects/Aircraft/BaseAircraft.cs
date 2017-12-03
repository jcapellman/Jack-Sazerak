using JackSazerak.UWP.Enums;
using JackSazerak.UWP.Objects.Containers;

namespace JackSazerak.UWP.GameObjects.Aircraft
{
    public abstract class BaseAircraft : BaseGameObject
    {
        protected BaseAircraft(string textureName, GameWrapper wrapper) : base(textureName, TILE_TYPE.SPRITES, wrapper)
        {
        }

        protected abstract int AgilityHorizontal();

        protected abstract int AgilityVertical();

        public void Move(MOVEMENT movementOption)
        {
            switch (movementOption)
            {
                case MOVEMENT.RIGHT:
                    UpdatePosition(AgilityHorizontal(), 0);
                    break;
                case MOVEMENT.LEFT:
                    UpdatePosition(AgilityHorizontal() * -1, 0);
                    break;
                case MOVEMENT.UP:
                    UpdatePosition(0, AgilityVertical() * -1);
                    break;
                case MOVEMENT.DOWN:
                    UpdatePosition(0, AgilityVertical());
                    break;
            }
        }
    }
}