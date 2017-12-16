using JackSazerak.UWP.GameObjects.Weapon;
using JackSazerak.UWP.Objects.Containers;

namespace JackSazerak.UWP.GameObjects.Aircraft
{
    public class F19 : BaseAircraft
    {
        public F19(GameWrapper wrapper) : base("F19", new VulkanGun(wrapper), wrapper) { }

        public override string Name => "F19";

        protected override int AgilityHorizontal => 80;

        protected override int AgilityVertical => 80;

        protected override int HitPoints => 100;

        protected override int UnlockedLevel => 2;

        protected override int Cost => 2500;
    }
}