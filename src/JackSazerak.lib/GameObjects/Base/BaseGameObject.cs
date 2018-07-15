using JackSazerak.lib.Objects;
using JackSazerak.lib.RenderableObjects.Base;

namespace JackSazerak.lib.GameObjects.Base
{
    public abstract class BaseGameObject
    {
        public BaseRenderableObject RenderObject;

        public void UpdatePosition(Point point)
        {
            RenderObject.UpdatePosition(point);
        }

        public abstract void Render();
    }
}