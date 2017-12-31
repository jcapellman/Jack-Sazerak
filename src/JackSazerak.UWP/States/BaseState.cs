using System;

using JackSazerak.Library.Enums;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace JackSazerak.UWP.States
{
    public abstract class BaseState
    {
        public abstract void Render(SpriteBatch spriteBatch);

        public abstract GameStates GameState { get; }

        public abstract void HandleInputs(KeyboardState state);

        public event EventHandler<GameStates> SwitchState;

        protected void OnSwitchState(GameStates gameState)
        {
            var handler = SwitchState;

            SwitchState?.Invoke(this, gameState);
        }
    }
}