using System;

using Microsoft.Xna.Framework.Graphics;

namespace JackSazerak.UWP.Effects.Transitions
{
    public abstract class BaseTransitions
    {
        public event EventHandler TransitionCompleted;

        protected void OnTransitionCompleted()
        {
            TransitionCompleted?.Invoke(null, null);
        }

        public abstract void Render(SpriteBatch spriteBatch);
    }
}