using JackSazerak.Library.GameObjects.Weapon;

using JackSazerak.Library.Objects.Containers;

namespace JackSazerak.Library.GameObjects.Aircraft
{
    public class F28 : BaseAircraft
    {
        public F28(GameWrapper wrapper) : base("F28", new VulkanGun(wrapper), wrapper)
        {            
        }
        
        public override string Name => "F28";

        protected override int AgilityHorizontal => 40;

        protected override int AgilityVertical => 50;

        protected override int HitPoints => 60;

        protected override int UnlockedLevel => 10;

        protected override int Cost => 20000;
    }
}