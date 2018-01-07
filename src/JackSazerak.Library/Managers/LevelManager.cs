using System.IO;

using JackSazerak.Library.Objects;
using JackSazerak.Library.Objects.Containers;
using JackSazerak.Library.Objects.JSONObjects;

namespace JackSazerak.Library.Managers
{
    public static class LevelManager
    {
        private static Level LoadJSON(string name) => Newtonsoft.Json.JsonConvert.DeserializeObject<Level>(File.ReadAllText(name));
        
        public static LevelContainer LoadLevel(GameWrapper gameWrapper, string name = "E1M1")
        {
            var levelObject = LoadJSON($"Levels/{name}");

            return new LevelContainer(levelObject, gameWrapper);
        }
    }
}