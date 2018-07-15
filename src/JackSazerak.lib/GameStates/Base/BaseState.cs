using System.Collections.Generic;

using JackSazerak.lib.IoC;
using JackSazerak.lib.RenderableObjects.Base;

namespace JackSazerak.lib.GameStates.Base
{
    public abstract class BaseState
    {
        public List<BaseRenderableObject> Renderables;

        protected BaseState()
        {
            Renderables = new List<BaseRenderableObject>();
        }
        
        protected void AddObject(BaseRenderableObject renderableObject)
        {
            Renderables.Add(renderableObject);
        }
        
        public void Render(object renderObject)
        {
            IOCContainer.GfxRenderer.Render(renderObject, Renderables);
        }
    }
}