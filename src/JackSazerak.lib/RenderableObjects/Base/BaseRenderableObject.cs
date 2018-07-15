using JackSazerak.lib.Enums;
using JackSazerak.lib.Objects;

namespace JackSazerak.lib.RenderableObjects.Base
{
    public abstract class BaseRenderableObject
    {
        protected Point _currentPosition;

        public abstract void Render();

        protected ResourceObject ResourceObject;

        public string ResouceFileName => ResourceObject?.FileName;

        public ResourceTypes ResourceType => ResourceObject.ResourceType;

        public object Resource {
            get => ResourceObject.Resource;

            set => ResourceObject.Resource = value;
        }

        protected BaseRenderableObject()
        {
            _currentPosition = new Point(0.0f, 0.0f);
        }

        public void UpdatePosition(Point point)
        {
            _currentPosition = point;
        }
    }
}