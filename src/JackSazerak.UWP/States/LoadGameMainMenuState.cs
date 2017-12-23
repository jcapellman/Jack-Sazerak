﻿using JackSazerak.UWP.Enums;
using JackSazerak.UWP.GameObjects.Static;
using JackSazerak.UWP.Objects.Containers;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace JackSazerak.UWP.States
{
    public class LoadGameMainMenuState : BaseState
    {
        private readonly Background background;

        public override GAME_STATES GameState => GAME_STATES.MAIN_MENU_LOADGAME;

        public LoadGameMainMenuState(GameWrapper gameWrapper)
        {
            background = new Background("loadgame_menu", gameWrapper);
        }

        public override void Render(SpriteBatch spriteBatch)
        {
            background.Render(spriteBatch);
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