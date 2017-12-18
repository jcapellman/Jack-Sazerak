using System;
using System.Globalization;
using JackSazerak.UWP.Objects.Containers;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JackSazerak.UWP.Effects
{
    public class Fade
    {
        public enum FADE_TYPE
        {
            FADE_IN,
            FADE_OUT
        };

        private FADE_TYPE fadeType;

        private int durationSeconds;
        
        private Texture2D texture;

        private float changePerFrame;

        private float opacity;

        public event EventHandler TransitionCompleted;

        public void OnTransitionCompleted()
        {
            TransitionCompleted?.Invoke(null, null);
        }

        public Fade(FADE_TYPE fadeType, int durationSeconds, Color color, GameWrapper gameWrapper)
        {
            texture = new Texture2D(gameWrapper.GraphicsDevice, gameWrapper.Window_Width, gameWrapper.Window_Height);

            var data = new Color[gameWrapper.Window_Height * gameWrapper.Window_Width];

            for (var i = 0; i < data.Length; ++i)
            {
                data[i] = color;
            }

            texture.SetData(data);
            
            this.fadeType = fadeType;
            this.durationSeconds = durationSeconds;

            Reset(fadeType);
        }
        
        public void Reset(FADE_TYPE fadeType)
        {
            changePerFrame = 1.0f / (durationSeconds * 30);

            switch (fadeType)
            {
                case FADE_TYPE.FADE_IN:
                    opacity = 1.0f;
                    break;
                case FADE_TYPE.FADE_OUT:
                    opacity = 0.0f;
                    break;
            }
        }

        public void Render(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Vector2(0,0), Color.White * opacity);

            switch (fadeType)
            {
                case FADE_TYPE.FADE_IN:
                    if (opacity <= 0.0f)
                    {
                        OnTransitionCompleted();
                        break;
                    }

                    opacity -= changePerFrame;
                    break;
                case FADE_TYPE.FADE_OUT:
                    if (opacity >= 1.0f)
                    {
                        OnTransitionCompleted();
                        break;
                    }

                    opacity += changePerFrame;
                    break;
            }            
        }
    }
}