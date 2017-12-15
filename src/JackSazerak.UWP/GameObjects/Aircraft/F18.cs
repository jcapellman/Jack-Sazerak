using JackSazerak.UWP.GameObjects.Weapon;
using JackSazerak.UWP.Objects.Containers;

namespace JackSazerak.UWP.GameObjects.Aircraft
{
    public class F18 : BaseAircraft
    {
        public F18(GameWrapper wrapper) : base("F18", new VulkanGun(wrapper), wrapper) { }

        public override string Name => "F18";

        protected override int AgilityHorizontal => 40;

        protected override int AgilityVertical => 40;

        protected override int HitPoints => 20;
    }
}