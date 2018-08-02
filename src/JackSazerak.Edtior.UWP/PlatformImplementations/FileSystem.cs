using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using JackSazerak.Editor.lib.PlatformInterfaces;

namespace JackSazerak.Editor.UWP.PlatformImplementations
{
    public class FileSystem : IFileSystem
    {
        public async Task<string> OpenFilePickerAsync(string filter = null)
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker
            {
                ViewMode = Windows.Storage.Pickers.PickerViewMode.List,
                SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary
            };

            if (!string.IsNullOrEmpty(filter))
            {
                picker.FileTypeFilter.Add(filter);
            }

            var file = await picker.PickSingleFileAsync();

            return file?.Path;
        }

        public async Task<string> SaveFilePickerAsync(string suggestedFileName, string filter)
        {
            var savePicker = new Windows.Storage.Pickers.FileSavePicker
            {
                SuggestedStartLocation =
                    Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary
            };

            savePicker.FileTypeChoices.Add(suggestedFileName, new List<string>() { filter });

            savePicker.SuggestedFileName = suggestedFileName;

            var file = await savePicker.PickSaveFileAsync();

            return file?.Path;
        }
    }
}