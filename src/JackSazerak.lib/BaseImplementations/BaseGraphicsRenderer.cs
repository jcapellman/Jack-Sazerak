using System.Collections.Generic;
using System.Drawing;

using JackSazerak.lib.Enums;
using JackSazerak.lib.RenderableObjects.Base;

namespace JackSazerak.lib.BaseImplementations
{
    public abstract class BaseGraphicsRenderer
    {
        public abstract void DrawText(string text, float xPosition, float yPosition, Color color);
        
        public abstract void DrawTexture(object textureObject, float xPosition, float yPosition, float scale);

        public virtual void Render(object renderObject, List<BaseRenderableObject> renderables)
        {
            foreach (var renderable in renderables)
            {
                renderable.Render();
            }
        }
    }
}