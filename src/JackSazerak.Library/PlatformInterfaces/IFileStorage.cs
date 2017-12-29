using System.Collections.Generic;
using System.Threading.Tasks;

namespace JackSazerak.Library.PlatformInterfaces
{
    public interface IFileStorage
    {
        Task<bool> FileExistsAsync(string fileName);

        Task<string> ReadTextFileAsync(string fileName);

        Task<List<string>> GetFilesAsync();

        Task<bool> WriteTextFileAsync(string fileName, string content);
    }
}