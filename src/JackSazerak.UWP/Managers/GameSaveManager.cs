using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using JackSazerak.UWP.Common;
using JackSazerak.UWP.Objects.JSONObjects;

using Newtonsoft.Json;

namespace JackSazerak.UWP.Managers
{
    public class GameSaveManager
    {
        private Windows.Storage.StorageFolder Folder => Windows.Storage.ApplicationData.Current.LocalFolder;
        
        public async Task<List<GameSave>> GetSavedGamesAsync()
        {
            var files = await Folder.GetFilesAsync();

            var saveGames = new List<GameSave>();

            foreach (var save in files.Where(a => a.Name.EndsWith(Constants.FILE_SAVE_EXTENSION)))
            {
                var fileContent = await Windows.Storage.FileIO.ReadTextAsync(save);

                saveGames.Add((GameSave)JsonConvert.DeserializeObject(fileContent));
            }

            return saveGames;
        }

        public async Task<bool> SaveGameAsync(GameSave gameSave, bool overwrite = false)
        {
            var file = await Folder.GetFileAsync($"{gameSave.SaveFileName}{Constants.FILE_SAVE_EXTENSION}");

            if (file.IsAvailable && !overwrite)
            {
                return false;
            }

            await Windows.Storage.FileIO.WriteTextAsync(file, JsonConvert.SerializeObject(gameSave));

            return true;
        }
    }
}