﻿using System.Collections.Generic;
using System.Linq;

using JackSazerak.Library.Enums;

using JackSazerak.Library.Objects.Containers;

using static JackSazerak.Library.Managers.EventManager;

using Microsoft.Xna.Framework.Audio;

namespace JackSazerak.Library.Managers
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

        private SoundEffect GetSound(string soundName) => sounds.FirstOrDefault(a => a.Name == $"Sounds/{soundName}");

        private void EventManager_EventOccurred(object sender, EventWrapper eventWrapper)
        {
            switch (eventWrapper.ActionFired)
            {
                case EventAction.PLAYER_MOVE_DOWN:
                case EventAction.PLAYER_MOVE_LEFT:
                case EventAction.PLAYER_MOVE_RIGHT:
                case EventAction.PLAYER_MOVE_UP:
                    GetSound(SND_FOOTSTEP).Play();
                    break;
            }
        }
    }
}