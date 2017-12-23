using JackSazerak.UWP.Enums;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace JackSazerak.UWP.Objects
{
    public class Text
    {
        private readonly string textStr;
        private readonly Color color;
        private readonly SpriteFont spriteFont;
        private Vector2 position;

        public Text(string str, Color color, Vector2? position, FONT_NAME fontName, ContentManager contentManager)
        {
            textStr = str;

            this.color = color;
            
            spriteFont = contentManager.Load<SpriteFont>($"Fonts/{fontName}");

            if (position.HasValue) { 
                this.position = position.Value;
            }
        }

        protected float Width => spriteFont.MeasureString(textStr).X;

        protected float Height => spriteFont.MeasureString(textStr).Y;

        protected void UpdatePosition(Vector2 position)
        {
            this.position = position;
        }

        public void Render(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(spriteFont, textStr, position, color);
        }
    }
}