using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using JackSazerak.UWP.Effects.Transitions;
using JackSazerak.Library.Enums;
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

        private List<BaseMenuState> mainMenuStates;

        public StateManager(GameWrapper gameWrapper)
        {
            baseFade = new Fade(Fade.FADE_TYPE.FADE_IN, 1, Color.Black, gameWrapper);

            LoadGameStates(gameWrapper);
        }

        private void LoadGameStates(GameWrapper gameWrapper)
        {
            mainMenuStates = Assembly.GetExecutingAssembly().GetTypes().Where(a => 
                a.BaseType == typeof(BaseMenuState) && !a.IsAbstract).Select(b => (BaseMenuState)Activator.CreateInstance(b, gameWrapper)).ToList();
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

        public event EventHandler<GameStates> SwitchState;

        public void OnSwitchState(GameStates gameState)
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

        public void SetState(GameStates gameState, GameWrapper gameWrapper, object payload = null)
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
            
            currentState = mainMenuStates.FirstOrDefault(a => a.GameState == gameState) ?? throw new Exception($"Could not find implementation of {gameState}");

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

        private void CurrentState_SwitchState(object sender, GameStates e)
        {
            OnSwitchState(e);
        }
    }
}