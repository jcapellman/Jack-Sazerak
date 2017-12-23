using JackSazerak.UWP.Enums;
using JackSazerak.UWP.Objects.Containers;

using Microsoft.Xna.Framework.Input;

namespace JackSazerak.UWP.States.MainMenu
{
    public class LoadGameMainMenuState : BaseMenuState
    {
        public override GAME_STATES GameState => GAME_STATES.MAIN_MENU_LOADGAME;

        public LoadGameMainMenuState(GameWrapper gameWrapper)
        {
            SetBackground("loadgame_menu", gameWrapper);
            SetHeader("LOAD GAME", gameWrapper);
        }

        public override void HandleInputs(KeyboardState state)
        {
            if (state.IsKeyDown(Keys.Escape))
            {
                OnSwitchState(GAME_STATES.MAIN_MENU);

                return;
            }
        }
    }
}