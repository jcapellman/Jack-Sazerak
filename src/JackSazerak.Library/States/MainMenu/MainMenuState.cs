using System;

using JackSazerak.Library.Enums;
using JackSazerak.Library.GameObjects.Static;
using JackSazerak.Library.Objects.Containers;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace JackSazerak.Library.States.MainMenu
{
    public enum MENU
    {
        NEW_GAME = 0,
        LOAD_GAME = 1,
        OPTIONS = 2,
        ABOUT = 3
    }

    public class MainMenuState : BaseMenuState
    {
        private int selectedIndex = 0;

        private Guid guidSelector;

        public override GameStates GameState => GameStates.MAIN_MENU;
        
        public override void InitState(GameWrapper gameWrapper)
        {
            SetBackground("mainmenu", gameWrapper);

            guidSelector = AddGameObject(new MenuSelector("F45", gameWrapper));

            AddTextLabel("NEW GAME", Color.White, HorizontalAlignment.CENTER, VerticalAlignment.CENTER, gameWrapper, offsetY: -160);
            AddTextLabel("LOAD GAME", Color.White, HorizontalAlignment.CENTER, VerticalAlignment.CENTER, gameWrapper, offsetY: -80);
            AddTextLabel("OPTIONS", Color.White, HorizontalAlignment.CENTER, VerticalAlignment.CENTER, gameWrapper, offsetY: 0);
            AddTextLabel("ABOUT", Color.White, HorizontalAlignment.CENTER, VerticalAlignment.CENTER, gameWrapper, offsetY: 80);

            selectedIndex = 0;
        }

        public override void HandleInputs(KeyboardState state)
        {
            if (state.IsKeyDown(Keys.Enter))
            {
                switch ((MENU)selectedIndex) {
                    case MENU.NEW_GAME:
                        OnSwitchState(GameStates.MAIN_MENU_NEWGAME);
                        break;
                    case MENU.LOAD_GAME:
                        OnSwitchState(GameStates.MAIN_MENU_LOADGAME);
                        break;
                    case MENU.OPTIONS:
                        OnSwitchState(GameStates.MAIN_MENU_OPTIONS);
                        break;
                    case MENU.ABOUT:
                        OnSwitchState(GameStates.MAIN_MENU_ABOUT);
                        break;
                }

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