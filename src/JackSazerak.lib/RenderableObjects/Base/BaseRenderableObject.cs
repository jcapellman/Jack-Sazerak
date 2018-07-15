using JackSazerak.lib.Enums;
using JackSazerak.lib.Objects;

namespace JackSazerak.lib.RenderableObjects.Base
{
    public abstract class BaseRenderableObject
    {
        public abstract void Render();

        protected ResourceObject _resourceObject;

        public string ResouceFileName => _resourceObject?.FileName;

        public ResourceTypes ResourceType => _resourceObject.ResourceType;

        public object Resource {
            get
            {
                return _resourceObject.Resource;
            }

            set
            {
                _resourceObject.Resource = value;
            }
        }
    }
}