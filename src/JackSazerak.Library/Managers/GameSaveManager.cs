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
            try
            {
                var files = await fileStorage.GetFilesAsync(Constants.FOLDER_NAME_SAVES);

                if (files.HasException)
                {
                    throw new JackException(ExceptionTypes.GAMESAVEMANAGER_LOADGAMES, files.ReturnException, "Could not load save game folder");
                }

                var saveGames = new List<GameSave>();

                foreach (var fileName in files.Object.Where(a => a.EndsWith(Constants.FILE_SAVE_EXTENSION)))
                {
                    var fileContent = await fileStorage.ReadTextFileAsync(fileName);

                    if (fileContent.HasException)
                    {
                        throw new JackException(ExceptionTypes.GAMESAVEMANAGER_READGAME, files.ReturnException, $"Could not load save game ({fileName})");
                    }
                
                    saveGames.Add((GameSave)JsonConvert.DeserializeObject(fileContent.Object));
                }

                return saveGames;
            } catch (JackException ex)
            {
                EventManager.FireEvent(EventAction.ERROR_CRITICAL, EventAction.LOADGAME_GETGAMES, ex);

                return new List<GameSave>();
            }
        }

        private string BuildSaveFileName(string gameName) => $"{gameName}{Constants.FILE_SAVE_EXTENSION}";

        public async Task<bool> SaveGameAsync(GameSave gameSave, bool overwrite = false)
        {
            try
            {
                var saveFileName = BuildSaveFileName(gameSave.GameName);

                if (!overwrite)
                {
                    var result = await fileStorage.FileExistsAsync(saveFileName);

                    if (result.HasException)
                    {
                        throw new JackException(ExceptionTypes.GAMESAVEMANAGER_READGAME, result.ReturnException, $"{saveFileName} already exists");
                    }
                
                    return false;
                }

                await fileStorage.WriteTextFileAsync(saveFileName, JsonConvert.SerializeObject(gameSave));

                return true;
            } catch (JackException ex)
            {
                EventManager.FireEvent(EventAction.ERROR_CRITICAL, EventAction.SAVEGAME, ex);

                return false;
            }
        }
    }
}