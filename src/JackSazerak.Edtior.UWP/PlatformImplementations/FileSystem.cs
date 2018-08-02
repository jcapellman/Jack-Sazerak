// Copyright (c) 2018 Jarred Capellman
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Windows.Storage.Pickers;

using JackSazerak.Editor.lib.PlatformInterfaces;

namespace JackSazerak.Editor.UWP.PlatformImplementations
{
    public class FileSystem : IFileSystem
    {
        private const PickerLocationId FileLocation = PickerLocationId.DocumentsLibrary;

        public async Task<string> OpenFilePickerAsync(string filter = null)
        {
            var picker = new FileOpenPicker
            {
                ViewMode = PickerViewMode.List,
                SuggestedStartLocation = FileLocation
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
            var savePicker = new FileSavePicker
            {
                SuggestedStartLocation = FileLocation
            };

            savePicker.FileTypeChoices.Add(suggestedFileName, new List<string>() { filter });

            savePicker.SuggestedFileName = suggestedFileName;

            var file = await savePicker.PickSaveFileAsync();

            return file?.Path;
        }
    }
}