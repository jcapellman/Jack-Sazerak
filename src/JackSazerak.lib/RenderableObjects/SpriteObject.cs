using JackSazerak.lib.Enums;
using JackSazerak.lib.Objects;
using JackSazerak.lib.RenderableObjects.Base;

namespace JackSazerak.lib.RenderableObjects
{
    public class SpriteObject : BaseRenderableObject
    {
        private float _scale;

        public SpriteObject(string resourceFileName, float xPosition, float yPosition, float scale)
        {
            UpdatePosition(new Point(xPosition, yPosition));

            _scale = scale;

            ResourceObject = new Objects.ResourceObject(resourceFileName, ResourceTypes.SPRITE);
        }
        
        public override void Render()
        {
            IoC.IOCContainer.GfxRenderer.DrawTexture(ResourceObject.Resource, _currentPosition.X, _currentPosition.Y, _scale);
        }
    }
}