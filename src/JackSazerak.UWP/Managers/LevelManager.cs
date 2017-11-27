using System.IO;

using JackSazerak.UWP.Objects;
using JackSazerak.UWP.Objects.JSONObjects;

using Microsoft.Xna.Framework.Content;

namespace JackSazerak.UWP.Managers
{
    public class LevelManager
    {
        private static Level LoadJSON(string name) => Newtonsoft.Json.JsonConvert.DeserializeObject<Level>(File.ReadAllText(name));
        
        public static LevelContainer LoadLevel(ContentManager contentManager, string name = "E1M1")
        {
            var levelObject = LoadJSON(name);

            return new LevelContainer(levelObject, contentManager);
        }
    }
}