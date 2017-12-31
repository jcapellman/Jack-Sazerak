using JackSazerak.Library.Enums;
using JackSazerak.Library.Objects.Containers;

using Microsoft.Xna.Framework.Input;

namespace JackSazerak.Library.States.MainMenu
{
    public class OptionsMainMenuState : BaseMenuState
    {
        public override GameStates GameState => GameStates.MAIN_MENU_OPTIONS;

        public OptionsMainMenuState(GameWrapper gameWrapper)
        {
            SetHeader("OPTIONS", gameWrapper);
            SetBackground("options_menu", gameWrapper);            
        }
        
        public override void HandleInputs(KeyboardState state)
        {
            if (state.IsKeyDown(Keys.Escape))
            {
                OnSwitchState(GameStates.MAIN_MENU);

                return;
            }
        }
    }
}