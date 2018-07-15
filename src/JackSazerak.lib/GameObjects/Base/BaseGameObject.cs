using JackSazerak.lib.Objects;
using JackSazerak.lib.RenderableObjects.Base;

namespace JackSazerak.lib.GameObjects.Base
{
    public abstract class BaseGameObject
    {
        protected Point _currentPosition;

        public BaseRenderableObject RenderObject;

        public void UpdatePosition(Point point)
        {
            _currentPosition = point;

            RenderObject.UpdatePosition(point);
        }

        public abstract void Render();
    }
}