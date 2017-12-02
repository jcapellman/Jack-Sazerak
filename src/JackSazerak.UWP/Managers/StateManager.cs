using System;

using JackSazerak.UWP.Enums;
using JackSazerak.UWP.Objects.Containers;
using JackSazerak.UWP.States;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace JackSazerak.UWP.Managers
{
    public class StateManager
    {
        private BaseState currentState;

        public void HandleInput(Keys[] keysPressed)
        {
            currentState.HandleInputs(keysPressed);
        }

        public void RenderState(SpriteBatch spriteBatch)
        {
            currentState.Render(spriteBatch);
        }

        public event EventHandler<GAME_STATES> SwitchState;

        public void OnSwitchState(GAME_STATES gameState)
        {
            var handler = SwitchState;

            handler?.Invoke(this, gameState);
        }

        public void SetState(GAME_STATES gameState, GameWrapper gameWrapper, object payload = null)
        {
            switch (gameState)
            {
                case GAME_STATES.MAIN_MENU:
                    currentState = new MainMenuState(gameWrapper);                    
                    break;
                case GAME_STATES.LEVEL:
                    currentState = new LevelState("E1M1", gameWrapper);
                    break;
            }

            currentState.SwitchState += CurrentState_SwitchState;
        }

        private void CurrentState_SwitchState(object sender, GAME_STATES e)
        {
            OnSwitchState(e);
        }
    }
}