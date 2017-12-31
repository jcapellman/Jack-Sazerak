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

        public override GAME_STATES GameState => GAME_STATES.LEVEL;

        public LevelState(GameWrapper gameWrapper)
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
                        EventManager.FireEvent(ACTION.PLAYER_MOVE_RIGHT, ACTION.HUMAN_MOVEMENT);
                        break;
                    case Keys.Left:
                        EventManager.FireEvent(ACTION.PLAYER_MOVE_LEFT, ACTION.HUMAN_MOVEMENT);
                        break;
                    case Keys.Up:
                        EventManager.FireEvent(ACTION.PLAYER_MOVE_UP, ACTION.HUMAN_MOVEMENT);
                        break;
                    case Keys.Down:
                        EventManager.FireEvent(ACTION.PLAYER_MOVE_DOWN, ACTION.HUMAN_MOVEMENT);
                        break;
                    case Keys.Escape:
                        OnSwitchState(GAME_STATES.MAIN_MENU);
                        break;
                }
            }
        }
    }
}