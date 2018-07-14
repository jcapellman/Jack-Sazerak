using System.Drawing;

using JackSazerak.lib.IoC;
using JackSazerak.lib.RenderableObjects.Base;

namespace JackSazerak.lib.RenderableObjects
{
    public class TextObject : BaseRenderableObject
    {
        private string _text;
        private float _xPosition;
        private float _yPosition;
        private Color _color;

        public TextObject(string text, float xPosition, float yPosition, Color color)
        {
            _text = text;
            _xPosition = xPosition;
            _yPosition = yPosition;
            _color = color;
        }

        public override void Render()
        {
            IOCContainer.GfxRenderer.DrawText(_text, _xPosition, _yPosition, _color);
        }
    }
}