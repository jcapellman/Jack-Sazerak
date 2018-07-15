using JackSazerak.lib.Enums;
using JackSazerak.lib.RenderableObjects.Base;

namespace JackSazerak.lib.RenderableObjects
{
    public class SpriteObject : BaseRenderableObject
    {
        private float _xPosition;
        private float _yPosition;
        private float _scale;

        public SpriteObject(string resourceFileName, float xPosition, float yPosition, float scale)
        {
            _xPosition = xPosition;
            _yPosition = yPosition;
            _scale = scale;

            _resourceObject = new Objects.ResourceObject(resourceFileName, ResourceTypes.SPRITE);
        }
        
        public override void Render()
        {
            IoC.IOCContainer.GfxRenderer.DrawTexture(_resourceObject.Resource, _xPosition, _yPosition, _scale);
        }
    }
}