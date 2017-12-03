using JackSazerak.UWP.Enums;
using JackSazerak.UWP.Managers;
using JackSazerak.UWP.Objects;
using JackSazerak.UWP.Objects.Containers;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace JackSazerak.UWP.States
{
    public class LevelState : BaseState
    {
        private readonly LevelContainer level;

        public LevelState(string levelName, GameWrapper gameWrapper)
        {
            level = LevelManager.LoadLevel(gameWrapper, levelName);
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
                        EventManager.FireEvent(ACTION.PLAYER_MOVE_RIGHT);
                        break;
                    case Keys.Left:
                        EventManager.FireEvent(ACTION.PLAYER_MOVE_LEFT);
                        break;
                    case Keys.Up:
                        EventManager.FireEvent(ACTION.PLAYER_MOVE_UP);
                        break;
                    case Keys.Down:
                        EventManager.FireEvent(ACTION.PLAYER_MOVE_DOWN);
                        break;
                    case Keys.Escape:
                        OnSwitchState(GAME_STATES.MAIN_MENU);
                        break;
                }
            }
        }
    }
}