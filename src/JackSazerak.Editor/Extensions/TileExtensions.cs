using JackSazerak.Editor.Objects;
using JackSazerak.lib.JSONObjects;

namespace JackSazerak.Editor.Extensions
{
    public static class TileExtensions
    {
        public static TileJSONObject TileJsonObject(this Tile tile) => new TileJSONObject
        {
            TextureName = tile.TextureName,
            YPosition = tile.YPosition,
            XPosition = tile.XPosition,
            Layer = tile.Layer
        };
    }
}