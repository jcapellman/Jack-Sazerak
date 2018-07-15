using JackSazerak.lib.GameObjects.Base;
using JackSazerak.lib.RenderableObjects;

namespace JackSazerak.lib.GameObjects.Tile.Base
{
    public abstract class BaseTile : BaseGameObject
    {
        protected BaseTile(string spriteFileName, float xRow, float yRow)
        {
            RenderObject = new TileObject(spriteFileName, xRow * 512, yRow * 512, 1.0f);
        }
    }
}