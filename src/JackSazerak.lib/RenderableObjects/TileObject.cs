using JackSazerak.lib.Enums;
using JackSazerak.lib.Objects;
using JackSazerak.lib.RenderableObjects.Base;

namespace JackSazerak.lib.RenderableObjects
{
    public class TileObject : BaseRenderableObject
    {
        private readonly float _scale;

        public TileObject(string resourceFileName, float xPosition, float yPosition, float scale)
        {
            UpdatePosition(new Point(xPosition, yPosition));

            _scale = scale;

            ResourceObject = new ResourceObject(resourceFileName, ResourceTypes.TILE);
        }

        public override void Render()
        {
            IoC.IOCContainer.GfxRenderer.DrawTexture(ResourceObject.Resource, _currentPosition.X, _currentPosition.Y, _scale);
        }
    }
}