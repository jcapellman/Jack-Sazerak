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

using JackSazerak.Editor.lib.Enums;
using JackSazerak.Editor.lib.PlatformInterfaces;

namespace JackSazerak.Editor.UWP.PlatformImplementations
{
    public class EditorSettings : IEditorSettings
    {
        private readonly Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

        public T GetValue<T>(EditorSettingsOptions editorSettings)
        {
            if (localSettings.Values.ContainsKey(editorSettings.ToString()))
            {
                return default;
            }

            return (T)Convert.ChangeType(localSettings.Values[editorSettings.ToString()], typeof(T));
        }

        public bool SetValue<T>(EditorSettingsOptions editorSettings, T value)
        {
            localSettings.Values[editorSettings.ToString()] = value;

            // TODO Error Handling

            return true;
        }
    }
}