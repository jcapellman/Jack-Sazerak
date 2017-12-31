using JackSazerak.Library.GameObjects.Weapon;
using JackSazerak.Library.Objects.Containers;

namespace JackSazerak.Library.GameObjects.Aircraft
{
    public class F55 : BaseAircraft
    {
        public F55(GameWrapper wrapper) : base("F55", new VulkanGun(wrapper), wrapper) { }

        public override string Name => "F55";

        protected override int AgilityHorizontal => 50;

        protected override int AgilityVertical => 50;
        
        protected override int HitPoints => 130;

        protected override int UnlockedLevel => 20;

        protected override int Cost => 100000;
    }
}