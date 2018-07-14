using System.Collections.Generic;
using System.Drawing;

using JackSazerak.lib.BaseImplementations;
using JackSazerak.lib.RenderableObjects.Base;

using Microsoft.Graphics.Canvas;

namespace JackSazerak.UWP.Implementations
{
    public class Win2DGraphicsRenderer : BaseGraphicsRenderer
    {
        private CanvasDrawingSession _session;

        public  override void DrawText(string text, float xPosition, float yPosition, Color color)
        {
            _session.DrawText(text, xPosition, yPosition, Windows.UI.Color.FromArgb(color.A, color.R, color.G, color.B));
        }

        public override void Render(object renderObject, List<BaseRenderableObject> renderables)
        {
            _session = (CanvasDrawingSession) renderObject;

            base.Render(null, renderables);
        }
    }
}