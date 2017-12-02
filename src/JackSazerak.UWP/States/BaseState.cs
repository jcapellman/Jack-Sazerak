using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace JackSazerak.UWP.States
{
    public abstract class BaseState
    {
        public abstract void Render(SpriteBatch spriteBatch);

        public abstract void HandleInputs(Keys[] keysPressed);
    }
}