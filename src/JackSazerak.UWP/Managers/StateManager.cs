using System;

using JackSazerak.UWP.Effects.Transitions;
using JackSazerak.UWP.Enums;
using JackSazerak.UWP.Objects.Containers;
using JackSazerak.UWP.States;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace JackSazerak.UWP.Managers
{
    public class StateManager
    {
        private BaseState currentState;
        private Fade fade;
        private bool transitionCompleted = false;
        private readonly Fade baseFade;

        public StateManager(GameWrapper gameWrapper)
        {
            baseFade = new Fade(Fade.FADE_TYPE.FADE_IN, 3, Color.Black, gameWrapper);
        }

        public void HandleInput(KeyboardState state)
        {
            currentState.HandleInputs(state);
        }

        public void RenderState(SpriteBatch spriteBatch)
        {
            currentState.Render(spriteBatch);
            
            fade?.Render(spriteBatch);
        }

        public event EventHandler<GAME_STATES> SwitchState;

        public void OnSwitchState(GAME_STATES gameState)
        {
            var handler = SwitchState;

            handler?.Invoke(this, gameState);
        }

        private void handleTransition(Fade.FADE_TYPE fadeType)
        {
            fade = baseFade;

            fade.Reset(fadeType);

            fade.TransitionCompleted += Fade_TransitionCompleted;
        }

        public void SetState(GAME_STATES gameState, GameWrapper gameWrapper, object payload = null)
        {
            if (currentState != null)
            {
                transitionCompleted = false;

                handleTransition(Fade.FADE_TYPE.FADE_IN);
            }
            else
            {                
                transitionCompleted = true;

                handleTransition(Fade.FADE_TYPE.FADE_OUT);
            }

            switch (gameState)
            {
                case GAME_STATES.MAIN_MENU:
                    currentState = new MainMenuState(gameWrapper);                    
                    break;
                case GAME_STATES.LEVEL:
                    currentState = new LevelState("E1M1", gameWrapper);
                    break;
                case GAME_STATES.MAIN_MENU_OPTIONS:
                    currentState = new OptionsMainMenuState(gameWrapper);
                    break;
                case GAME_STATES.MAIN_MENU_ABOUT:
                    currentState = new AboutMainMenuState(gameWrapper);
                    break;
            }

            currentState.SwitchState += CurrentState_SwitchState;
        }

        private void Fade_TransitionCompleted(object sender, EventArgs e)
        {
            if (transitionCompleted)
            {
                fade = null;

                return;
            }

            fade.Reset(Fade.FADE_TYPE.FADE_IN);

            transitionCompleted = true;
        }

        private void CurrentState_SwitchState(object sender, GAME_STATES e)
        {
            OnSwitchState(e);
        }
    }
}