using System.Collections.Generic;
using System.Threading.Tasks;

using JackSazerak.Library.Common;

namespace JackSazerak.Library.PlatformInterfaces
{
    public interface IFileStorage
    {
        Task<ReturnWrapper<bool>> FileExistsAsync(string fileName);

        Task<ReturnWrapper<string>> ReadTextFileAsync(string fileName);

        Task<ReturnWrapper<List<string>>> GetFilesAsync(string folderName);

        Task<ReturnWrapper<bool>> WriteTextFileAsync(string fileName, string content);
    }
}