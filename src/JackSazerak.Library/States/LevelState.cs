using JackSazerak.Library.Enums;

using JackSazerak.Library.Managers;
using JackSazerak.Library.Objects;
using JackSazerak.Library.Objects.Containers;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace JackSazerak.Library.States
{
    public class LevelState : BaseState
    {
        private LevelContainer level;

        public override GameStates GameState => GameStates.LEVEL;

        public override void InitState(GameWrapper gameWrapper)
        {
            level = LevelManager.LoadLevel(gameWrapper, "E1M1");
        }

        public override void Render(SpriteBatch spriteBatch)
        {
            foreach (var tile in level.Tiles)
            {
                tile.Render(spriteBatch);
            }

            level.CurrentPlayer.Render(spriteBatch);

            foreach (var text in level.TextElements)
            {
                text.Render(spriteBatch);
            }
        }

        public override void HandleInputs(KeyboardState state)
        {
            foreach (var keyPressed in state.GetPressedKeys())
            {
                switch (keyPressed)
                {
                    case Keys.Right:
                        EventManager.FireEvent(EventAction.PLAYER_MOVE_RIGHT, EventAction.HUMAN_MOVEMENT);
                        break;
                    case Keys.Left:
                        EventManager.FireEvent(EventAction.PLAYER_MOVE_LEFT, EventAction.HUMAN_MOVEMENT);
                        break;
                    case Keys.Up:
                        EventManager.FireEvent(EventAction.PLAYER_MOVE_UP, EventAction.HUMAN_MOVEMENT);
                        break;
                    case Keys.Down:
                        EventManager.FireEvent(EventAction.PLAYER_MOVE_DOWN, EventAction.HUMAN_MOVEMENT);
                        break;
                    case Keys.Escape:
                        OnSwitchState(GameStates.MAIN_MENU);
                        break;
                }
            }
        }
    }
}