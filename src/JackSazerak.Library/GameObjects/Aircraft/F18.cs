using JackSazerak.Library.GameObjects.Weapon;
using JackSazerak.Library.Objects.Containers;

namespace JackSazerak.Library.GameObjects.Aircraft
{
    public class F18 : BaseAircraft
    {
        public F18(GameWrapper wrapper) : base("F18", new VulkanGun(wrapper), wrapper) { }

        public override string Name => "F18";

        protected override int AgilityHorizontal => 40;

        protected override int AgilityVertical => 40;

        protected override int HitPoints => 20;

        protected override int UnlockedLevel => 1;

        protected override int Cost => 1000;
    }
}