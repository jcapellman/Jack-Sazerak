using JackSazerak.UWP.Enums;
using JackSazerak.UWP.GameObjects.Static;
using JackSazerak.UWP.Objects.Containers;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace JackSazerak.UWP.States
{
    public abstract class BaseMenuState : BaseState
    {
        private TextLabel tlHeader;
        private Background bMain;
        
        protected void SetHeader(string headerStr, GameWrapper gameWrapper)
        {
            if (!string.IsNullOrEmpty(headerStr))
            {
                tlHeader = new TextLabel(headerStr, Color.White, FONT_NAME.MAINMENU, HORIZONTAL_ALIGNMENT.CENTER, VERTICAL_ALIGNMENT.TOP, gameWrapper);
            }
        }

        protected void SetBackground(string backgroundName, GameWrapper gameWrapper)
        {
            if (!string.IsNullOrEmpty(backgroundName))
            {
                bMain = new Background(backgroundName, gameWrapper);
            }
        }
        
        public override void Render(SpriteBatch spriteBatch)
        {
            bMain?.Render(spriteBatch);

            tlHeader?.Render(spriteBatch);
        }

        public override void HandleInputs(KeyboardState state)
        {
            throw new System.NotImplementedException();
        }
    }
}