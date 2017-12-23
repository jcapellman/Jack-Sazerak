using System.Collections.Generic;

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
        private Background bMain;

        private readonly List<TextLabel> textLabels;

        public BaseMenuState()
        {
            textLabels = new List<TextLabel>();
        }

        protected void AddTextLabel(string str, Color color, HORIZONTAL_ALIGNMENT hAlignment,
            VERTICAL_ALIGNMENT vAlignment, GameWrapper gameWrapper, Vector2? position = null, float? offsetX = null, float? offsetY = null)
        {
            textLabels.Add(new TextLabel(str, color, FONT_NAME.MAINMENU, hAlignment, vAlignment, gameWrapper, position, offsetX, offsetY));
        }

        protected void SetHeader(string headerStr, GameWrapper gameWrapper)
        {
            if (!string.IsNullOrEmpty(headerStr))
            {
                AddTextLabel(headerStr, Color.White, HORIZONTAL_ALIGNMENT.CENTER, VERTICAL_ALIGNMENT.TOP, gameWrapper);                
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

            foreach (var textLabel in textLabels)
            {
                textLabel.Render(spriteBatch);
            }
        }

        public override void HandleInputs(KeyboardState state)
        {
            throw new System.NotImplementedException();
        }
    }
}