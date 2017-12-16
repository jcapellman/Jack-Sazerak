using JackSazerak.UWP.Enums;
using JackSazerak.UWP.Objects.Containers;

namespace JackSazerak.UWP.GameObjects.Static
{
    public class BackgroundTile : BaseGameObject
    {
        public BackgroundTile(string textureName, int positionX, int positionY, int width, int height, GameWrapper wrapper) : base(textureName, TILE_TYPE.TILES, wrapper)
        {
            Height = height;
            Width = width;

            PositionY = positionY;
            PositionX = positionX;            
        }
    }
}