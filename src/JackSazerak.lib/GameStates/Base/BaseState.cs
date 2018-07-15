using System;
using System.Collections.Generic;
using System.Linq;

using JackSazerak.lib.GameObjects.Base;
using JackSazerak.lib.IoC;
using JackSazerak.lib.Objects;

namespace JackSazerak.lib.GameStates.Base
{
    public abstract class BaseState
    {
        private double _mousePositionX;
        private double _mousePositionY;

        private List<BaseGameObject> _stateObjects;

        protected event EventHandler<Point> MousePositionChanged;

        public List<BaseGameObject> ResourceRenderables =>
            _stateObjects.Where(a => !string.IsNullOrEmpty(a.RenderObject.ResouceFileName)).ToList();

        protected BaseState()
        {
            _stateObjects = new List<BaseGameObject>();
        }
        
        protected BaseGameObject GetStateObject(Type type) => _stateObjects.FirstOrDefault(a => a.GetType() == type);

        protected void AddObject(BaseGameObject gameObject)
        {
            _stateObjects.Add(gameObject);
        }
        
        public void Render(object renderObject)
        {
            IOCContainer.GfxRenderer.Render(renderObject, _stateObjects);
        }

        public void UpdateMousePosition(double positionX, double positionY)
        {
            _mousePositionX = positionX;
            _mousePositionY = positionY;

            MousePositionChanged?.Invoke(null, new Point((float) _mousePositionX, (float) _mousePositionY));
        }
    }
}