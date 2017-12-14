﻿using JackSazerak.UWP.GameObjects.Weapon;
using JackSazerak.UWP.Objects.Containers;

namespace JackSazerak.UWP.GameObjects.Aircraft
{
    public class F25 : BaseAircraft
    {
        public F25(GameWrapper gameWrapper) : base("F25", new VulkanGun(gameWrapper), gameWrapper) { }

        public override string Name => "F25";

        protected override int AgilityHorizontal => 30;

        protected override int AgilityVertical => 40;

        protected override int HitPoints => 50;
    }
}