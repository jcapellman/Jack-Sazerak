﻿using System;

using JackSazerak.UWP.Enums;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace JackSazerak.UWP.States
{
    public abstract class BaseState
    {
        public abstract void Render(SpriteBatch spriteBatch);

        public abstract void HandleInputs(Keys[] keysPressed);

        public event EventHandler<GAME_STATES> SwitchState;

        public void OnSwitchState(GAME_STATES gameState)
        {
            var handler = SwitchState;

            SwitchState?.Invoke(this, gameState);
        }
    }
}