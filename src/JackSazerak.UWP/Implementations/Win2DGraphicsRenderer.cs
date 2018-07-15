using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

using Windows.Foundation;
using Windows.UI.ViewManagement;

using JackSazerak.lib.BaseImplementations;
using JackSazerak.lib.Common;
using JackSazerak.lib.RenderableObjects.Base;

using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Effects;

namespace JackSazerak.UWP.Implementations
{
    public class Win2DGraphicsRenderer : BaseGraphicsRenderer
    {
        private float _scaleWidth;
        private float _scaleHeight;

        private CanvasDrawingSession _session;

        public override void UpdateScale()
        {
            Rect bounds = ApplicationView.GetForCurrentView().VisibleBounds;

            _scaleWidth = (float)bounds.Width / Constants.DESIGN_WIDTH;
            _scaleHeight = (float)bounds.Height / Constants.DESIGN_HEIGHT;
        }

        public override void DrawText(string text, float xPosition, float yPosition, Color color)
        {
            _session.DrawText(text, xPosition, yPosition, Windows.UI.Color.FromArgb(color.A, color.R, color.G, color.B));
        }

        public override void Render(object renderObject, List<BaseRenderableObject> renderables)
        {
            _session = (CanvasDrawingSession) renderObject;

            base.Render(null, renderables);
        }
        
        public override void DrawTexture(object textureObject, float xPosition, float yPosition, float scale)
        {
            var image = new Transform2DEffect
            {
                Source = (CanvasBitmap) textureObject,
                TransformMatrix = Matrix3x2.CreateScale(_scaleWidth, _scaleHeight)
            };

            _session.DrawImage(image, xPosition, yPosition);
        }
    }
}