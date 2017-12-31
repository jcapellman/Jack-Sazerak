using JackSazerak.Library.Enums;
using JackSazerak.Library.Objects.Containers;

using Microsoft.Xna.Framework;

namespace JackSazerak.Library.GameObjects.Static
{
    public class TextLabel : BaseTextGameObject
    {
        public TextLabel(string textStr, Color color, FontName fontName, HorizontalAlignment hAlignment, VerticalAlignment vAlignment, GameWrapper wrapper, Vector2? position = null, float? offsetX = null, float? offsetY = null) : base(textStr, color, fontName, hAlignment, vAlignment, wrapper, position, offsetX, offsetY)
        {  
        }        
    }
}