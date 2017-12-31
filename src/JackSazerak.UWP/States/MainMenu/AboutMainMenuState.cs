﻿using JackSazerak.Library.Enums;

using JackSazerak.UWP.Objects.Containers;

using Microsoft.Xna.Framework.Input;

namespace JackSazerak.UWP.States.MainMenu
{
    public class AboutMainMenuState : BaseMenuState
    {
        public override GameStates GameState => GameStates.MAIN_MENU_ABOUT;

        public AboutMainMenuState(GameWrapper gameWrapper)
        {
            SetBackground("about_menu", gameWrapper);
            SetHeader("ABOUT", gameWrapper);
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