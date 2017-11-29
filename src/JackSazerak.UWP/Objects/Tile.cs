using JackSazerak.UWP.Objects.JSONObjects;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace JackSazerak.UWP.Objects
{
    public class Tile : BaseObject<LevelTile, Tile>
    {
        public Tile(LevelTile levelTile, ContentManager contentManager)
        {
            Color = Color.White;
            
            Texture = contentManager.Load<Texture2D>($"{levelTile.TileType}/{levelTile.TextureName}");
            
            switch (levelTile.TileType)
            {
                case Enums.TILE_TYPE.BACKGROUNDS:
                    Rect = new Rectangle(0, 0, Texture.Width, Texture.Height);
                    break;
                case Enums.TILE_TYPE.REGULAR:
                    Rect = new Rectangle(0, 0, levelTile.Width, levelTile.Height);

                    UpdatePosition(levelTile.PositionX, levelTile.PositionY);
                    break;
                case Enums.TILE_TYPE.SPRITES:
                    Rect = new Rectangle(0, 0, levelTile.Width, levelTile.Height);

                    UpdatePosition(0, 900 - levelTile.PositionY);
                    break;
            }
        }

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
    }
}