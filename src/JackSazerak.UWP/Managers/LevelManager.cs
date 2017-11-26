using System.IO;

using JackSazerak.UWP.Objects;
using JackSazerak.UWP.Objects.JSONObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace JackSazerak.UWP.Managers
{
    public class LevelManager
    {
        private static Tile LoadBackgroundTile(string textureName, ContentManager contentManager)
        {
            var tile = new Tile 
            {
                Color = Color.White,
                Texture = contentManager.Load<Texture2D>($"Backgrounds/{textureName}")
            };
            
            tile.Rect = new Rectangle(0, 0, tile.Texture.Width, tile.Texture.Height);

            return tile;
        }

        private static Tile LoadTile(LevelTile levelTile, ContentManager contentManager)
        {
            var tile = new Tile
            {
                Color = Color.White,
                Texture = contentManager.Load<Texture2D>($"Tiles/{levelTile.TextureName}")
            };

            tile.Rect = new Rectangle(0, 0, levelTile.Width, levelTile.Height);

            tile.UpdatePosition(levelTile.PositionX, levelTile.PositionY);

            return tile;
        }

        private static Tile LoadSprite(string spriteName, ContentManager contentManager)
        {
            var tile = new Tile
            {
                Color = Color.White,
                Texture = contentManager.Load<Texture2D>($"Sprites/{spriteName}")
            };

            tile.Rect = new Rectangle(0, 0, tile.Texture.Width, tile.Texture.Height);
            
            return tile;
        }

        private static Level LoadJSON(string name) => Newtonsoft.Json.JsonConvert.DeserializeObject<Level>(File.ReadAllText(name));
        
        public static LevelContainer LoadLevel(ContentManager contentManager, string name = "E1M1")
        {
            var levelObject = LoadJSON(name);

            var level = new LevelContainer().FromJSON(levelObject);
            
            level.Tiles.Add(LoadBackgroundTile(levelObject.Background, contentManager));

            foreach (var tile in levelObject.Tiles)
            {
                level.Tiles.Add(LoadTile(tile, contentManager));
            }

            level.CurrentPlayer = new Player(LoadSprite("jack", contentManager));
            
            return level;
        }
    }
}