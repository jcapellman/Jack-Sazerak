using System.IO;

using JackSazerak.UWP.JSONObjects;
using JackSazerak.UWP.Objects;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace JackSazerak.UWP.Managers
{
    public class LevelManager
    {
        private static Tile LoadTile(string textureName, ContentManager contentManager)
        {
            var tile = new Tile 
            {
                Color = Color.White,
                Texture = contentManager.Load<Texture2D>(textureName)
            };
            
            tile.Rect = new Rectangle(0, 0, tile.Texture.Width, tile.Texture.Height);

            return tile;
        }

        private Level LoadJSON(string name) => Newtonsoft.Json.JsonConvert.DeserializeObject<Level>(File.ReadAllText(name));
        
        public static LevelContainer LoadLevel(ContentManager contentManager, string name = "E1M1")
        {
            var level = new LevelContainer();
            
            level.Tiles.Add(LoadTile("Backgrounds/main", contentManager));

            level.CurrentPlayer = new Player(LoadTile("Sprites/jack", contentManager));
            
            return level;
        }
    }
}