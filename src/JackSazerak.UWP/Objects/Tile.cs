using JackSazerak.UWP.Objects.Containers;
using JackSazerak.UWP.Objects.JSONObjects;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JackSazerak.UWP.Objects
{
    public class Tile : BaseObject<LevelTile, Tile>
    {
        public Tile(LevelTile levelTile, GameWrapper wrapper)
        {
            Color = Color.White;
            
            Texture = wrapper.ContentManager.Load<Texture2D>($"{levelTile.TileType}/{levelTile.TextureName}");
            
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
                    Rect = new Rectangle(0, 0, Texture.Width, Texture.Height);

                    UpdatePosition(0, wrapper.Window_Height - Texture.Height);
                    break;
            }
        }

        private Vector2 TilePosition { get; set; }

        private Texture2D Texture { get; set; }

        private Rectangle Rect { get; set; }

        private Color Color { get; set; }

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