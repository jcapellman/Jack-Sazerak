using JackSazerak.Library.GameObjects.Weapon;
using JackSazerak.Library.Objects.Containers;

namespace JackSazerak.Library.GameObjects.Aircraft
{
    public class Su51 : BaseAircraft
    {
        public Su51(GameWrapper wrapper) : base("Su51", new VulkanGun(wrapper), wrapper) { }

        public override string Name => "Su51";

        protected override int AgilityHorizontal => 40;

        protected override int AgilityVertical => 40;
        
        protected override int HitPoints => 140;

        protected override int UnlockedLevel => 0;

        protected override int Cost => 0;
    }
}