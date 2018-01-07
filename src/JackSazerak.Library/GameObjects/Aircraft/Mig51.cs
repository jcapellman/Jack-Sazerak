using JackSazerak.Library.GameObjects.Weapon;
using JackSazerak.Library.Objects.Containers;

namespace JackSazerak.Library.GameObjects.Aircraft
{
    public class Mig51 : BaseAircraft
    {
        public Mig51(GameWrapper wrapper) : base("Mig51", new VulkanGun(wrapper), wrapper)
        {
        }

        public override string Name => "Mig51";

        protected override int AgilityHorizontal => 50;

        protected override int AgilityVertical => 50;
        
        protected override int HitPoints => 130;

        protected override int UnlockedLevel => 0;

        protected override int Cost => 0;
    }
}