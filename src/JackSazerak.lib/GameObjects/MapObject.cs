using System.Collections.Generic;

using JackSazerak.lib.GameObjects.Base;
using JackSazerak.lib.GameObjects.Tile;

namespace JackSazerak.lib.GameObjects
{
    public class MapObject : BaseGameObject
    {
        public MapObject(string mapName)
        {
            var staticTiles = new List<StaticTile>();

            for (var y = 0; y < 100; y++)
            {
                for (var x = 1; x < 4; x++)
                {
                    staticTiles.Add(new StaticTile("Water.jpg", x, y));
                }
            }

            RenderObject = new RenderableObjects.MapObject(staticTiles);
        }

        public override void Render()
        {
            RenderObject.Render();
        }
    }
}