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
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Input;

using JackSazerak.Editor.UWP.Common;
using JackSazerak.Editor.UWP.Extensions;
using JackSazerak.Editor.Objects;
using JackSazerak.lib.Common;
using JackSazerak.lib.Enums;
using JackSazerak.lib.JSONObjects;

using Newtonsoft.Json;

using Windows.UI.Xaml.Media.Imaging;

namespace JackSazerak.Editor.UWP.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private BitmapImage _selectedTileImage;

        public BitmapImage SelectedTileImage
        {
            get => _selectedTileImage;

            set
            {
                _selectedTileImage = value;
                OnPropertyChanged();
            }
        }

        private string _selectedLayer;

        public string SelectedLayer
        {
            get => _selectedLayer;

            set
            {
                _selectedLayer = value;
                OnPropertyChanged();
            }
        }

        private List<string> _mapLayers;

        public List<string> MapLayers
        {
            get => _mapLayers;

            set {
                _mapLayers = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<BitmapImage> _tileImages;

        public ObservableCollection<BitmapImage> TileImages
        {
            get => _tileImages;

            set
            {
                _tileImages = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Tile> _tiles;

        public ObservableCollection<Tile> Tiles
        {
            get => _tiles;

            set
            {
                _tiles = value;
                OnPropertyChanged();
            }
        }

        private LevelJSONObject _levelObject;

        public LevelJSONObject LevelObject
        {
            get => _levelObject;

            set
            {
                _levelObject = value;

                OnPropertyChanged();
            }
        }

        public void LoadImages()
        {
            MapLayers = Enum.GetNames(typeof(MapLayers)).OrderBy(a => a).ToList();

            SelectedLayer = MapLayers.FirstOrDefault();

            TileImages = new ObservableCollection<BitmapImage>();

            var imageFiles = Directory.GetFiles(Constants.PATH_ASSET_TILES);

            foreach (var imageFile in imageFiles)
            {
                var image = new BitmapImage(new Uri(Path.Combine(AppContext.BaseDirectory, imageFile), UriKind.Absolute));

                TileImages.Add(image);
            }

            Tiles = new ObservableCollection<Tile>();

            NewLevel();
        }

        #region New Level Command
        private ICommand newLevelMenuCommand;

        public ICommand NewLevelMenuCommand => newLevelMenuCommand ?? (newLevelMenuCommand = new CommandHandler(NewLevel));

        private void NewLevel()
        {
            Tiles.Clear();

            LevelObject = null;
        }
        #endregion

        #region Load Level Command
        private ICommand loadLevelMenuCommand;

        public ICommand LoadLevelMenuCommand => loadLevelMenuCommand ?? (loadLevelMenuCommand = new CommandHandler(LoadLevel));

        public async void LoadLevel()
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker
            {
                ViewMode = Windows.Storage.Pickers.PickerViewMode.List,
                SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary
            };

            picker.FileTypeFilter.Add(".map");
            
            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            
            if (file == null)
            {
                return;
            }

            try
            {
                var jsonObject = JsonConvert.DeserializeObject<LevelJSONObject>(File.ReadAllText(file.Path));

                LevelObject = jsonObject;
            }
            catch (Exception)
            {
                // TODO: Log Exception
                ShowMessage($"Could not load {file.Path}, it may be corrupt");
            }
        }

        #endregion

        #region Save Level Command
        private ICommand saveLevelMenuCommand;

        public ICommand SaveLevelMenuCommand => saveLevelMenuCommand ?? (saveLevelMenuCommand = new CommandHandler(SaveLevel));

        private async void SaveLevel()
        {
            if (LevelObject == null)
            {
                var savePicker = new Windows.Storage.Pickers.FileSavePicker
                {
                    SuggestedStartLocation =
                    Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary
                };

                savePicker.FileTypeChoices.Add("Level", new List<string>() { ".map" });

                savePicker.SuggestedFileName = "Level";

                Windows.Storage.StorageFile file = await savePicker.PickSaveFileAsync();

                if (file != null)
                {
                    LevelObject = new LevelJSONObject
                    {
                        Tiles = Tiles.Select(a => a.TileJsonObject()).ToList(),
                        FileName = file.Path,
                        Name = file.Name
                    };
                }
            }

            if (string.IsNullOrEmpty(LevelObject?.FileName))
            {
                return;
            }

            File.WriteAllText(LevelObject.FileName, JsonConvert.SerializeObject(LevelObject));

            ShowMessage($"Saved Level to {LevelObject.FileName}");
        }
        #endregion

        #region New Tile Command
        private ICommand newTileCommand;

        public ICommand NewTileCommand => newTileCommand ?? (newTileCommand = new CommandHandler(NewTile));

        private void NewTile()
        {
            var tile = new Tile()
            {
                Chance = 0.0,
                Layer = SelectedLayer.ToMapLayer(),
                Texture = SelectedTileImage,
                TextureName = "test"
            };

            Tiles.Add(tile);
        }
        #endregion
    }
}