using JackSazerak.UWP.GameObjects.Weapon;
using JackSazerak.UWP.Objects.Containers;

namespace JackSazerak.UWP.GameObjects.Aircraft
{
    public class J20 : BaseAircraft
    {
        protected J20(GameWrapper wrapper) : base("J20", new VulkanGun(wrapper), wrapper)
        {
        }

        public override string Name => "J20";

        protected override int AgilityHorizontal => 40;

        protected override int AgilityVertical => 50;

        protected override int HitPoints => 70;

        protected override int UnlockedLevel => 0;

        protected override int Cost => 0;
    }
}