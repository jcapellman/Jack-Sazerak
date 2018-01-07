using JackSazerak.Library.GameObjects.Weapon;
using JackSazerak.Library.Objects.Containers;

namespace JackSazerak.Library.GameObjects.Aircraft
{
    public class F45 : BaseAircraft
    {
        public F45(GameWrapper wrapper) : base("F45", new VulkanGun(wrapper), wrapper) { }

        public override string Name => "F45";

        protected override int AgilityHorizontal => 50;

        protected override int AgilityVertical => 30;
        
        protected override int HitPoints => 120;

        protected override int UnlockedLevel => 12;

        protected override int Cost => 40000;
    }
}