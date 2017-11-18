using JackSazerak.UWP.Objects;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace JackSazerak.UWP.Managers
{
    public class LevelManager
    {
        public static LevelContainer LoadLevel(ContentManager content, string name = "E1M1")
        {
            var level = new LevelContainer();

            var tile = new Tile();

            tile.Color = Color.White;

            tile.Rect = new Rectangle(0, 0, 1920, 1080);

            tile.Texture = content.Load<Texture2D>("Backgrounds/main");

            level.Tiles.Add(tile);
            
            return level;
        }
    }
}