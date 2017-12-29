using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using JackSazerak.Library.PlatformInterfaces;

namespace JackSazerak.UWP.PlatformImplementations
{
    public class FileStorage : IFileStorage
    {
        private Windows.Storage.StorageFolder Folder => Windows.Storage.ApplicationData.Current.LocalFolder;

        async Task<List<string>> IFileStorage.GetFilesAsync()
        {
            var files = await Folder.GetFilesAsync();

            return files.Select(a => a.Name).ToList();
        }

        async Task<bool> IFileStorage.FileExistsAsync(string fileName)
        {
            var existingFile = await Folder.TryGetItemAsync(fileName);

            return existingFile != null;
        }

        async Task<string> IFileStorage.ReadTextFileAsync(string fileName)
        {
            var file = await Folder.GetFileAsync(fileName);

            if (!file.IsAvailable)
            {
                return null;
            }

            return await Windows.Storage.FileIO.ReadTextAsync(file);
        }

        async Task<bool> IFileStorage.WriteTextFileAsync(string fileName, string content)
        {
            var file = await Folder.GetFileAsync(fileName);

            await Windows.Storage.FileIO.WriteTextAsync(file, content);

            return true;
        }
    }
}