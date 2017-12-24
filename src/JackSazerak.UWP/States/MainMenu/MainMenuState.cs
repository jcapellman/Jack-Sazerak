using System;

using JackSazerak.UWP.Enums;
using JackSazerak.UWP.GameObjects.Static;
using JackSazerak.UWP.Objects.Containers;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace JackSazerak.UWP.States.MainMenu
{
    public class MainMenuState : BaseMenuState
    {
        private int selectedIndex = 0;

        private Guid guidSelector;

        public override GAME_STATES GameState => GAME_STATES.MAIN_MENU;

        public MainMenuState(GameWrapper gameWrapper)
        {
            SetBackground("mainmenu", gameWrapper);

            guidSelector = AddGameObject(new MenuSelector("F45", gameWrapper));

            AddTextLabel("NEW GAME", Color.White, HORIZONTAL_ALIGNMENT.CENTER, VERTICAL_ALIGNMENT.CENTER, gameWrapper, offsetY: -160);
            AddTextLabel("LOAD GAME", Color.White, HORIZONTAL_ALIGNMENT.CENTER, VERTICAL_ALIGNMENT.CENTER, gameWrapper, offsetY: -80);
            AddTextLabel("OPTIONS", Color.White, HORIZONTAL_ALIGNMENT.CENTER, VERTICAL_ALIGNMENT.CENTER, gameWrapper, offsetY: 0);
            AddTextLabel("ABOUT", Color.White, HORIZONTAL_ALIGNMENT.CENTER, VERTICAL_ALIGNMENT.CENTER, gameWrapper, offsetY: 80);
            
            selectedIndex = 0;
        }

        public override void HandleInputs(KeyboardState state)
        {
            if (state.IsKeyDown(Keys.Q)) {             
                OnSwitchState(GAME_STATES.LEVEL);

                return;
            }

            if (state.IsKeyDown(Keys.W))
            {
                OnSwitchState(GAME_STATES.MAIN_MENU_OPTIONS);

                return;
            }

            if (state.IsKeyDown(Keys.E))
            {
                OnSwitchState(GAME_STATES.MAIN_MENU_ABOUT);

                return;
            }

            if (state.IsKeyDown(Keys.T))
            {
                OnSwitchState(GAME_STATES.MAIN_MENU_LOADGAME);

                return;
            }

            if (state.IsKeyDown(Keys.R))
            {
                OnSwitchState(GAME_STATES.MAIN_MENU_NEWGAME);

                return;
            }

            if (state.IsKeyDown(Keys.Up))
            {
                if (selectedIndex == 0)
                {
                    selectedIndex = 3;
                }
                else
                {
                    selectedIndex--;
                }

                GetGameObject(guidSelector).UpdatePosition(0, (selectedIndex * 128), true);

                return;
            }

            if (state.IsKeyDown(Keys.Down))
            {
                if (selectedIndex == 3)
                {
                    selectedIndex = 0;
                }
                else
                {
                    selectedIndex++;
                }

                GetGameObject(guidSelector).UpdatePosition(0, (selectedIndex * 128), true);

                return;
            }
        }
    }
}