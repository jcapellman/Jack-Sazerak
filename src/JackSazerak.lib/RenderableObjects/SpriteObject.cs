using JackSazerak.lib.RenderableObjects.Base;

namespace JackSazerak.lib.RenderableObjects
{
    public class SpriteObject : BaseRenderableObject
    {
        private object _texture;
        private float _xPosition;
        private float _yPosition;
        private float _scale;

        public SpriteObject(string textureName, float xPosition, float yPosition, float scale)
        {
            _xPosition = xPosition;
            _yPosition = yPosition;
            _scale = scale;

            IoC.IOCContainer.GfxRenderer.LoadTexture(textureName, Enums.ResourceTypes.SPRITE);
        }

        public override void Render()
        {
            IoC.IOCContainer.GfxRenderer.DrawTexture(_texture, _xPosition, _yPosition, _scale);
        }
    }
}