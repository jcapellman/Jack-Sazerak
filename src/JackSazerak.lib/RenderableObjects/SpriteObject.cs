using JackSazerak.lib.Enums;
using JackSazerak.lib.Objects;
using JackSazerak.lib.RenderableObjects.Base;

namespace JackSazerak.lib.RenderableObjects
{
    public class SpriteObject : BaseRenderableObject
    {
        private readonly float _scale;

        public SpriteObject(string resourceFileName, float xPosition, float yPosition, float scale, bool restrictToWindow = false)
        {
            UpdatePosition(new Point(xPosition, yPosition));

            _scale = scale;

            ResourceObject = new ResourceObject(resourceFileName, ResourceTypes.SPRITE, restrictToWindow);
        }
        
        public override void Render()
        {
            IoC.IOCContainer.GfxRenderer.DrawTexture(ResourceObject.Resource, _currentPosition.X, _currentPosition.Y, _scale);
        }
    }
}