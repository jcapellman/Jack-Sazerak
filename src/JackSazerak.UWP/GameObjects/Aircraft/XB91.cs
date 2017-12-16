using JackSazerak.UWP.GameObjects.Weapon;
using JackSazerak.UWP.Objects.Containers;

namespace JackSazerak.UWP.GameObjects.Aircraft
{
    public class XB91 : BaseAircraft
    {
        protected XB91(GameWrapper wrapper) : base("xb91", new VulkanGun(wrapper), wrapper)
        {
        }
        
        public override string Name => "XB91";

        protected override int AgilityHorizontal => 100;

        protected override int AgilityVertical => 100;

        protected override int HitPoints => 30;

        protected override int UnlockedLevel => 0;

        protected override int Cost => 0;
    }
}