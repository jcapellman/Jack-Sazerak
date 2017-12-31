using System.Collections.Generic;
using System.Linq;

using JackSazerak.UWP.Objects.Containers;
using static JackSazerak.UWP.Managers.EventManager;

using Microsoft.Xna.Framework.Audio;

namespace JackSazerak.UWP.Managers
{
    public class SoundManager
    {
        private string SND_FOOTSTEP = "Footstep";

        private readonly List<SoundEffect> sounds;

        public SoundManager(GameWrapper gameWrapper)
        {
            EventManager.EventOccurred += EventManager_EventOccurred;

            sounds = new List<SoundEffect> {
                gameWrapper.ContentManager.Load<SoundEffect>($"Sounds/{SND_FOOTSTEP}")
            };
        }

        private SoundEffect getSound(string soundName) => sounds.FirstOrDefault(a => a.Name == $"Sounds/{soundName}");

        private void EventManager_EventOccurred(object sender, EventWrapper eventWrapper)
        {
            switch (eventWrapper.ActionFired)
            {
                case Enums.ACTION.PLAYER_MOVE_DOWN:
                case Enums.ACTION.PLAYER_MOVE_LEFT:
                case Enums.ACTION.PLAYER_MOVE_RIGHT:
                case Enums.ACTION.PLAYER_MOVE_UP:
                    getSound(SND_FOOTSTEP).Play();
                    break;
            }
        }
    }
}