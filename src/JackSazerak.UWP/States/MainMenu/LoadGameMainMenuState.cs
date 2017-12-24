using System.Collections.Generic;
using System.Linq;

using JackSazerak.UWP.Enums;
using JackSazerak.UWP.Managers;
using JackSazerak.UWP.Objects.Containers;
using JackSazerak.UWP.Objects.JSONObjects;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace JackSazerak.UWP.States.MainMenu
{
    public class LoadGameMainMenuState : BaseMenuState
    {
        public override GAME_STATES GameState => GAME_STATES.MAIN_MENU_LOADGAME;

        private List<GameSave> gameSaves;

        public LoadGameMainMenuState(GameWrapper gameWrapper)
        {
            SetBackground("loadgame_menu", gameWrapper);
            SetHeader("LOAD GAME", gameWrapper);

            gameSaves = GameSaveManager.GetSavedGames();

            if (!gameSaves.Any())
            {
                AddTextLabel("No Save Games Found", Color.White, HORIZONTAL_ALIGNMENT.CENTER, VERTICAL_ALIGNMENT.CENTER, gameWrapper);

                return;
            }
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