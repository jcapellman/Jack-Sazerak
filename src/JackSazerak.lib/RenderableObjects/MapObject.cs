using System.Collections.Generic;

using JackSazerak.lib.Enums;
using JackSazerak.lib.GameObjects.Tile;
using JackSazerak.lib.RenderableObjects.Base;

namespace JackSazerak.lib.RenderableObjects
{
    public class MapObject : BaseRenderableObject
    {
        private List<StaticTile> _tiles;

        public MapObject(List<StaticTile> tiles)
        {
            _tiles = tiles;

            ResourceObject = new Objects.ResourceObject("Water.jpg", ResourceTypes.TILE);
        }

        public override void Render()
        {
            foreach (var tile in _tiles)
            {
                if (tile.RenderObject?.Resource == null)
                {
                    tile.RenderObject.Resource = ResourceObject.Resource;
                }

                tile.Render();
            }
        }
    }
}
