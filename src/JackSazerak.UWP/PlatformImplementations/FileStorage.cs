using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using JackSazerak.Library.PlatformInterfaces;

using Windows.Storage;

namespace JackSazerak.UWP.PlatformImplementations
{
    public class FileStorage : IFileStorage
    {
        private Windows.Storage.StorageFolder Folder => ApplicationData.Current.LocalFolder;

        async Task<List<string>> IFileStorage.GetFilesAsync(string folderName)
        {
            try
            {
                var folder = await Folder.GetFolderAsync(folderName);

                if (folder == null)
                {
                    return new List<string>();
                }

                var files = await folder.GetFilesAsync();

                return files.Select(a => a.Name).ToList();
            } catch (Exception)
            {
                return new List<string>();
            }
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