using JackSazerak.UWP.Enums;
using JackSazerak.UWP.Objects.Containers;

using Microsoft.Xna.Framework;

namespace JackSazerak.UWP.GameObjects.Static
{
    public class BackgroundTile : BaseGameObject
    {
        public BackgroundTile(string textureName, int positionX, int positionY, int width, int height, GameWrapper wrapper) : base(textureName, TILE_TYPE.TILES, wrapper, new Vector2(width, height), new Vector2(positionX, positionY))
        {
        }
    }
}