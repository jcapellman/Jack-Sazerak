using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Microsoft.Xna.Framework;

using JackSazerak.UWP.Objects.JSONObjects;
using JackSazerak.UWP.Objects.Containers;
using JackSazerak.UWP.GameObjects.Aircraft;
using JackSazerak.UWP.GameObjects.Static;

namespace JackSazerak.UWP.Objects
{
    public class LevelContainer : BaseObject<Level, LevelContainer>
    {
        public Vector2 Camera { get; set; }

        public List<Text> TextElements { get; set; }

        public List<BackgroundTile> Tiles { get; set; }

        public Player CurrentPlayer { get; set; }

        private List<BaseAircraft> GetAllAircraft(GameWrapper gameWrapper) => Assembly.GetExecutingAssembly().GetTypes().Where(a => a.BaseType == typeof(BaseAircraft) && !a.IsAbstract).Select(b => (BaseAircraft)Activator.CreateInstance(b, gameWrapper)).ToList();        

        public LevelContainer(Level jsonObject, GameWrapper gameWrapper)
        {
            var aircraft = GetAllAircraft(gameWrapper);

            Tiles = new List<BackgroundTile>();

            // Swap out temporary code when level editor is done
            for (var x = 0; x < 100; x++)
            {
                Tiles.Add(new BackgroundTile("Water", 100, x * - 128, 128, 128, gameWrapper));
            }

            foreach (var tile in jsonObject.Tiles)
            {
                Tiles.Add(new BackgroundTile(tile.TextureName, tile.PositionX, tile.PositionY, tile.Width, tile.Height, gameWrapper));
            }

            CurrentPlayer = new Player(aircraft.FirstOrDefault(a => a.Name == jsonObject.CurrentPlayer));
        }
    }
}