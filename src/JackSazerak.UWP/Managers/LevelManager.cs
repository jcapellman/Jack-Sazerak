using System.IO;

using JackSazerak.UWP.Objects;
using JackSazerak.UWP.Objects.Containers;
using JackSazerak.UWP.Objects.JSONObjects;

namespace JackSazerak.UWP.Managers
{
    public class LevelManager
    {
        private static Level LoadJSON(string name) => Newtonsoft.Json.JsonConvert.DeserializeObject<Level>(File.ReadAllText(name));
        
        public static LevelContainer LoadLevel(GameWrapper gameWrapper, string name = "E1M1")
        {
            var levelObject = LoadJSON($"Levels/{name}");

            return new LevelContainer(levelObject, gameWrapper);
        }
    }
}