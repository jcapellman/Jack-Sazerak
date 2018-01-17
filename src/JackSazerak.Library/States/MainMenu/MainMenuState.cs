using System;
using System.Linq;

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
        private KeyboardState previousKeyboardState;

        private int selectedIndex = 0;

        private Guid guidSelector;

        public override GameStates GameState => GameStates.MAIN_MENU;
        
        public override void InitState(GameWrapper gameWrapper)
        {
            SetBackground("mainmenu", gameWrapper);

            guidSelector = AddGameObject(new MenuSelector("F45", gameWrapper), HorizontalAlignment.CENTER, VerticalAlignment.CENTER);

            AddTextLabel("NEW GAME", Color.White, HorizontalAlignment.CENTER, VerticalAlignment.CENTER, gameWrapper, offsetY: -160);
            AddTextLabel("LOAD GAME", Color.White, HorizontalAlignment.CENTER, VerticalAlignment.CENTER, gameWrapper, offsetY: -80);
            AddTextLabel("OPTIONS", Color.White, HorizontalAlignment.CENTER, VerticalAlignment.CENTER, gameWrapper, offsetY: 0);
            AddTextLabel("ABOUT", Color.White, HorizontalAlignment.CENTER, VerticalAlignment.CENTER, gameWrapper, offsetY: 80);

            selectedIndex = 0;
        }

        public override void HandleInputs(KeyboardState state)
        {
            var pressedKeys = from k in state.GetPressedKeys()
                                 where !(previousKeyboardState.GetPressedKeys().Contains(k))
                                 select k;

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

            if (pressedKeys.Contains(Keys.Up))
            {
                if (selectedIndex == 0)
                {
                    selectedIndex = 3;
                }
                else
                {
                    selectedIndex--;
                }
            } else if (pressedKeys.Contains(Keys.Down))
            {
                if (selectedIndex == 3)
                {
                    selectedIndex = 0;
                }
                else
                {
                    selectedIndex++;
                }
            }

            GetGameObject(guidSelector).UpdatePosition(0, (-160 + (80 * selectedIndex)), true);

            previousKeyboardState = state;
        }
    }
}