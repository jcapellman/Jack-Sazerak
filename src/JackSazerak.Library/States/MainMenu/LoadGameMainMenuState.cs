using System.Collections.Generic;
using System.Linq;

using JackSazerak.Library.Enums;
using JackSazerak.Library.Managers;
using JackSazerak.Library.Objects.Containers;
using JackSazerak.Library.Objects.JSONObjects;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace JackSazerak.Library.States.MainMenu
{
    public class LoadGameMainMenuState : BaseMenuState
    {
        public override GameStates GameState => GameStates.MAIN_MENU_LOADGAME;

        private List<GameSave> gameSaves;

        public override void InitState(GameWrapper gameWrapper)
        {
            SetBackground("loadgame_menu", gameWrapper);
            SetHeader("LOAD GAME", gameWrapper);

            gameSaves = new GameSaveManager(gameWrapper.FileStorage).GetSavedGamesAsync().Result;

            if (!gameSaves.Any())
            {
                AddTextLabel("No Save Games Found", Color.White, HorizontalAlignment.CENTER, VerticalAlignment.CENTER, gameWrapper);

                return;
            }

            var index = 0;

            foreach (var saveGame in gameSaves)
            {
                AddTextLabel(saveGame.GameName, Color.White, HorizontalAlignment.CENTER, VerticalAlignment.CENTER, gameWrapper, offsetY: index * 90);
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