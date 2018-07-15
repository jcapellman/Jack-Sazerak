using System.Collections.Generic;
using System.Linq;

using JackSazerak.lib.IoC;
using JackSazerak.lib.RenderableObjects.Base;

namespace JackSazerak.lib.GameStates.Base
{
    public abstract class BaseState
    {
        private List<BaseRenderableObject> _renderables;

        public List<BaseRenderableObject> ResourceRenderables =>
            _renderables.Where(a => !string.IsNullOrEmpty(a.ResouceFileName)).ToList();

        protected BaseState()
        {
            _renderables = new List<BaseRenderableObject>();
        }
        
        protected void AddObject(BaseRenderableObject renderableObject)
        {
            _renderables.Add(renderableObject);
        }
        
        public void Render(object renderObject)
        {
            IOCContainer.GfxRenderer.Render(renderObject, _renderables);
        }
    }
}