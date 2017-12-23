using JackSazerak.UWP.Enums;
using JackSazerak.UWP.Objects.Containers;

using Microsoft.Xna.Framework.Input;

namespace JackSazerak.UWP.States.MainMenu
{
    public class OptionsMainMenuState : BaseMenuState
    {
        public override GAME_STATES GameState => GAME_STATES.MAIN_MENU_OPTIONS;

        public OptionsMainMenuState(GameWrapper gameWrapper)
        {
            SetHeader("OPTIONS", gameWrapper);
            SetBackground("options_menu", gameWrapper);            
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