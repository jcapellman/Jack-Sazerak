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

        public Text(string str, Color color, ContentManager contentManager)
        {
            textStr = str;

            this.color = color;
            
            spriteFont = contentManager.Load<SpriteFont>($"Fonts/HUD");
        }

        public void Render(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(spriteFont, textStr, new Vector2(100, 100), color);
        }
    }
}