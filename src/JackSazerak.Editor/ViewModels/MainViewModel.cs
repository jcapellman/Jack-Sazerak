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
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

using JackSazerak.Editor.Common;
using JackSazerak.Editor.Objects;
using JackSazerak.lib.Common;
using JackSazerak.lib.Enums;
using JackSazerak.lib.JSONObjects;

using Microsoft.Win32;

using Newtonsoft.Json;

namespace JackSazerak.Editor.ViewModels
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

            // TODO: Prompt User for dimension of map
            for (var x = 0; x < 100; x++)
            {
                for (var y = 0; y < 3; y++)
                {
                    Tiles.Add(new Tile
                    {
                        Texture = TileImages.FirstOrDefault(),
                        IsSet = false,
                        TextureName = "Test",
                        XPosition = x,
                        YPosition = y
                    });
                }
            }
        }

        #region New Level Command
        private ICommand newLevelMenuCommand;

        public ICommand NewLevelMenuCommand => newLevelMenuCommand ?? (newLevelMenuCommand = new CommandHandler(NewLevel));

        public void NewLevel()
        {
            // TODO: Reset Map and prompt user to save
        }
        #endregion

        #region Load Level Command
        private ICommand loadLevelMenuCommand;

        public ICommand LoadLevelMenuCommand => loadLevelMenuCommand ?? (loadLevelMenuCommand = new CommandHandler(LoadLevel));

        public void LoadLevel()
        {
            // TODO: Prompt User to select level and Load Map
        }
        #endregion

        #region Save Level Command
        private ICommand saveLevelMenuCommand;

        public ICommand SaveLevelMenuCommand => saveLevelMenuCommand ?? (saveLevelMenuCommand = new CommandHandler(SaveLevel));

        public void SaveLevel()
        {
            var fileName = string.Empty;

            if (LevelObject == null)
            {
                SaveFileDialog sfDialog = new SaveFileDialog();

                sfDialog.Filter = "Level|*.map";
                sfDialog.Title = "Save Level";

                sfDialog.ShowDialog();

                if (!string.IsNullOrEmpty(sfDialog.FileName))
                {
                    fileName = sfDialog.FileName;
                }
            } else
            {
                fileName = LevelObject.FileName;
            }

            if (string.IsNullOrEmpty(fileName))
            {
                return;
            }

            File.WriteAllText(fileName, JsonConvert.SerializeObject(LevelObject));

            MessageBox.Show("Saved Level");
        }
        #endregion

        #region Exit Command
        private ICommand exitMenuCommand;

        public ICommand ExitMenuCommand => exitMenuCommand ?? (exitMenuCommand = new CommandHandler(ExitEditor));
        
        public void ExitEditor()
        {
            App.Current.Shutdown();
        }
        #endregion
    }
}