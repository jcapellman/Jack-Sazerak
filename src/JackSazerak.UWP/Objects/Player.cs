using Microsoft.Xna.Framework.Content;

namespace JackSazerak.UWP.Objects
{
    public class Player : Tile
    {
        public Player(Tile tile)
        {
            Texture = tile.Texture;
            Rect = tile.Rect;
            Color = tile.Color;

            UpdatePosition(0, 900 - Texture.Height);
        }
    }
}