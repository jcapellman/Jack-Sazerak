using System.Collections.Generic;
using System.Linq;

using JackSazerak.Library.Enums;

using JackSazerak.UWP.Managers;
using JackSazerak.UWP.Objects.Containers;
using JackSazerak.UWP.Objects.JSONObjects;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace JackSazerak.UWP.States.MainMenu
{
    public class LoadGameMainMenuState : BaseMenuState
    {
        public override GameStates GameState => GameStates.MAIN_MENU_LOADGAME;

        private List<GameSave> gameSaves;

        public LoadGameMainMenuState(GameWrapper gameWrapper)
        {
            SetBackground("loadgame_menu", gameWrapper);
            SetHeader("LOAD GAME", gameWrapper);

            gameSaves = new GameSaveManager(gameWrapper.FileStorage).GetSavedGamesAsync().Result;

            if (!gameSaves.Any())
            {
                AddTextLabel("No Save Games Found", Color.White, HorizontalAlignment.CENTER, VerticalAlignment.CENTER, gameWrapper);

                return;
            }
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