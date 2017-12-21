using JackSazerak.UWP.Enums;
using JackSazerak.UWP.GameObjects.Static;
using JackSazerak.UWP.Objects.Containers;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace JackSazerak.UWP.States
{
    public class MainMenuState : BaseState
    {
        private readonly Background background;
        private readonly MenuSelector selector;

        private int selectedIndex = 0;

        public MainMenuState(GameWrapper gameWrapper)
        {
            background = new Background("mainmenu", gameWrapper);

            selector = new MenuSelector("F45", gameWrapper);

            selectedIndex = 0;
        }

        public override void Render(SpriteBatch spriteBatch)
        {
            background.Render(spriteBatch);

            selector.Render(spriteBatch);
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

                selector.UpdatePosition(0, (selectedIndex * 128), true);

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

                selector.UpdatePosition(0, (selectedIndex * 128), true);

                return;
            }
        }
    }
}