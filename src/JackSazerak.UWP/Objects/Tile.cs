using JackSazerak.UWP.Objects.JSONObjects;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JackSazerak.UWP.Objects
{
    public class Tile : BaseObject<LevelTile, Tile>
    {
        public Vector2 TilePosition { get; private set; }

        public Texture2D Texture { get; set; }

        public Rectangle Rect { get; set; }

        public Color Color { get; set; }

        public void UpdatePosition(int x = 0, int y = 0)
        {
            TilePosition = new Vector2(TilePosition.X + x, TilePosition.Y + y);            
        }

        public void Render(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, TilePosition, Rect, Color);
        }

        public override Tile FromJSON(LevelTile jsonObject)
        {
            return this;
        }
    }
}