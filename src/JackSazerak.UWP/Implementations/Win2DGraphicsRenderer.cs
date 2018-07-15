using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;

using JackSazerak.lib.BaseImplementations;
using JackSazerak.lib.Enums;
using JackSazerak.lib.RenderableObjects.Base;

using Microsoft.Graphics.Canvas;

namespace JackSazerak.UWP.Implementations
{
    public class Win2DGraphicsRenderer : BaseGraphicsRenderer
    {
        private CanvasDrawingSession _session;

        private UWPResourceManager _resourceManager;

        public Win2DGraphicsRenderer(UWPResourceManager resourceManager)
        {
            _resourceManager = resourceManager;
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

        public override void LoadTexture(string textureName, ResourceTypes resourceType)
        {
            try
            {
                 _resourceManager.LoadTexture(textureName, resourceType);

            } catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void DrawTexture(object textureObject, float xPosition, float yPosition, float scale)
        {
            _session.DrawImage((CanvasBitmap)textureObject, xPosition, yPosition);
        }
    }
}