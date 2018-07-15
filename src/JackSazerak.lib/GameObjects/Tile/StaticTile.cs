using JackSazerak.lib.GameObjects.Tile.Base;

namespace JackSazerak.lib.GameObjects.Tile
{
    public class StaticTile : BaseTile
    {
        public StaticTile(string spriteFileName, float xRow, float yRow) : base(spriteFileName, xRow, yRow)
        {
        }

        public override void Render()
        {
            RenderObject.Render();
        }
    }
}