using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using JackSazerak.Library.Common;
using JackSazerak.Library.PlatformInterfaces;

using Windows.Storage;

namespace JackSazerak.UWP.PlatformImplementations
{
    public class FileStorage : IFileStorage
    {
        private Windows.Storage.StorageFolder Folder => ApplicationData.Current.LocalFolder;

        async Task<ReturnWrapper<List<string>>> IFileStorage.GetFilesAsync(string folderName)
        {
            try
            {
                var folder = await Folder.GetFolderAsync(folderName);

                if (folder == null)
                {
                    return new ReturnWrapper<List<string>>(new List<string>());
                }

                var files = await folder.GetFilesAsync();

                return new ReturnWrapper<List<string>>(files.Select(a => a.Name).ToList());
            } catch (Exception ex)
            {
                return new ReturnWrapper<List<string>>(ex);
            }
        }

        async Task<ReturnWrapper<bool>> IFileStorage.FileExistsAsync(string fileName)
        {
            try
            {
                var existingFile = await Folder.TryGetItemAsync(fileName);

                return new ReturnWrapper<bool>(existingFile != null);
            } catch (Exception ex)
            {
                return new ReturnWrapper<bool>(ex);
            }
        }

        async Task<ReturnWrapper<string>> IFileStorage.ReadTextFileAsync(string fileName)
        {
            var file = await Folder.GetFileAsync(fileName);

            if (!file.IsAvailable)
            {
                return new ReturnWrapper<string>(string.Empty);
            }

            return new ReturnWrapper<string>(await Windows.Storage.FileIO.ReadTextAsync(file));
        }

        async Task<ReturnWrapper<bool>> IFileStorage.WriteTextFileAsync(string fileName, string content)
        {
            try
            {
                var file = await Folder.GetFileAsync(fileName);

                await FileIO.WriteTextAsync(file, content);

                return new ReturnWrapper<bool>(true);
            } catch (Exception ex)
            {
                return new ReturnWrapper<bool>(ex);
            }
        }
    }
}