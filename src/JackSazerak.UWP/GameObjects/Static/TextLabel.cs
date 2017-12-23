using JackSazerak.UWP.Enums;
using JackSazerak.UWP.Objects.Containers;

using Microsoft.Xna.Framework;

namespace JackSazerak.UWP.GameObjects.Static
{
    public class TextLabel : BaseTextGameObject
    {
        public TextLabel(string textStr, Color color, FONT_NAME fontName, HORIZONTAL_ALIGNMENT hAlignment, VERTICAL_ALIGNMENT vAlignment, GameWrapper wrapper, Vector2? position = null) : base(textStr, color, fontName, hAlignment, vAlignment, wrapper, position)
        {  
        }        
    }
}