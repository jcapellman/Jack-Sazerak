﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using JackSazerak.Library.Objects.Containers;
using JackSazerak.Library.Effects.Transitions;

using JackSazerak.Library.Enums;
using JackSazerak.Library.States;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace JackSazerak.Library.Managers
{
    public class StateManager
    {
        private BaseState currentState;
        private Fade fade;
        private bool transitionCompleted = false;
        private readonly Fade baseFade;

        private List<BaseGameState> gameStates;
        private List<BaseMenuState> mainMenuStates;

        public StateManager(GameWrapper gameWrapper)
        {
            baseFade = new Fade(Fade.FADE_TYPE.FADE_IN, 1, Color.Black, gameWrapper);

            LoadGameStates(gameWrapper);
        }

        private void LoadGameStates(GameWrapper gameWrapper)
        {
            mainMenuStates = Assembly.GetExecutingAssembly().GetTypes().Where(a => 
                a.BaseType == typeof(BaseMenuState) && !a.IsAbstract).Select(b => (BaseMenuState)Activator.CreateInstance(b)).ToList();
            
            gameStates = Assembly.GetExecutingAssembly().GetTypes().Where(a =>
                a.BaseType == typeof(BaseGameState) && !a.IsAbstract).Select(b => (BaseGameState)Activator.CreateInstance(b)).ToList();
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

        private void HandleTransition(Fade.FADE_TYPE fadeType)
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

                HandleTransition(Fade.FADE_TYPE.FADE_IN);
            }
            else
            {
                transitionCompleted = true;

                HandleTransition(Fade.FADE_TYPE.FADE_OUT);
            }

            currentState = mainMenuStates.FirstOrDefault(a => a.GameState == gameState);
            
            if (currentState == null)
            {
                currentState = gameStates.FirstOrDefault(a => a.GameState == gameState);
            }

            if (currentState == null)
            {
                throw new Exception($"Could not find implementation of {gameState}");
            }

            currentState.InitState(gameWrapper);

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