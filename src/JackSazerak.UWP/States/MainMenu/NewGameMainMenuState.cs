using JackSazerak.Library.Enums;
using JackSazerak.UWP.Objects.Containers;

using Microsoft.Xna.Framework.Input;

namespace JackSazerak.UWP.States.MainMenu
{
    public class NewGameMainMenuState : BaseMenuState
    {
        public override GameStates GameState => GameStates.MAIN_MENU_NEWGAME;

        public NewGameMainMenuState(GameWrapper gameWrapper)
        {
            SetHeader("NEW GAME", gameWrapper);
            SetBackground("newgame_menu", gameWrapper);
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