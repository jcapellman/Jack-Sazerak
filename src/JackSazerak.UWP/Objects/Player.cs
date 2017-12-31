using JackSazerak.Library.Enums;

using JackSazerak.UWP.GameObjects.Aircraft;
using JackSazerak.UWP.Managers;
using static JackSazerak.UWP.Managers.EventManager;

using Microsoft.Xna.Framework.Graphics;

namespace JackSazerak.UWP.Objects
{
    public class Player
    {
        private readonly BaseAircraft aircraft;

        public Player(BaseAircraft aircraft)
        {
            this.aircraft = aircraft;

            EventManager.EventOccurred += EventManager_EventOccurred;
        }

        public void Render(SpriteBatch spriteBatch)
        {
            aircraft.Render(spriteBatch);
        }

        private void EventManager_EventOccurred(object sender, EventWrapper eventWrapper)
        {
            switch (eventWrapper.ActionFired)
            {
                case EventAction.PLAYER_MOVE_RIGHT:
                    aircraft.Move(Movement.RIGHT);
                    break;
                case EventAction.PLAYER_MOVE_LEFT:
                    aircraft.Move(Movement.LEFT);
                    break;
                case EventAction.PLAYER_MOVE_UP:
                    aircraft.Move(Movement.UP);
                    break;
                case EventAction.PLAYER_MOVE_DOWN:
                    aircraft.Move(Movement.DOWN);
                    break;
            }
        }
    }
}