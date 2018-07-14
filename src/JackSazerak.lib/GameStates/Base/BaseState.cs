using System.Collections.Generic;

using JackSazerak.lib.IoC;
using JackSazerak.lib.RenderableObjects.Base;

namespace JackSazerak.lib.GameStates.Base
{
    public abstract class BaseState
    {
        private readonly List<BaseRenderableObject> _renderables;

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