using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using JackSazerak.Library.PlatformInterfaces;
using JackSazerak.Library.Common;
using JackSazerak.Library.Enums;
using JackSazerak.Library.Objects.JSONObjects;

using Newtonsoft.Json;

namespace JackSazerak.Library.Managers
{
    public class GameSaveManager
    {
        private IFileStorage fileStorage;

        public GameSaveManager(IFileStorage fileStorage)
        {
            this.fileStorage = fileStorage;
        }
        
        public async Task<List<GameSave>> GetSavedGamesAsync()
        {
            var files = await fileStorage.GetFilesAsync(Constants.FOLDER_NAME_SAVES);
            
            if (files.HasException)
            {
                EventManager.FireEvent(EventAction.ERROR_CRITICAL, EventAction.LOADGAME_GETGAMES, files.ReturnException);

                return new List<GameSave>();
            }

            var saveGames = new List<GameSave>();

            foreach (var fileName in files.Object.Where(a => a.EndsWith(Constants.FILE_SAVE_EXTENSION)))
            {
                var fileContent = await fileStorage.ReadTextFileAsync(fileName);

                if (fileContent.HasException)
                {
                    EventManager.FireEvent(EventAction.ERROR_WARNING, EventAction.LOADGAME_READINGGAME, fileContent.ReturnException);

                    continue;
                }

                saveGames.Add((GameSave)JsonConvert.DeserializeObject(fileContent.Object));
            }

            return saveGames;
        }

        private string BuildSaveFileName(string gameName) => $"{gameName}{Constants.FILE_SAVE_EXTENSION}";

        public async Task<bool> SaveGameAsync(GameSave gameSave, bool overwrite = false)
        {
            var saveFileName = BuildSaveFileName(gameSave.GameName);

            if (!overwrite)
            {
                var result = await fileStorage.FileExistsAsync(saveFileName);

                if (result.HasException)
                {
                    EventManager.FireEvent(EventAction.ERROR_CRITICAL, EventAction.SAVEGAME, result.ReturnException);
                }
                
                return false;
            }

            await fileStorage.WriteTextFileAsync(saveFileName, JsonConvert.SerializeObject(gameSave));

            return true;
        }
    }
}