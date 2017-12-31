using JackSazerak.Library.GameObjects.Weapon;

using JackSazerak.Library.Objects.Containers;

namespace JackSazerak.Library.GameObjects.Aircraft
{
    public class F25 : BaseAircraft
    {
        public F25(GameWrapper gameWrapper) : base("F25", new VulkanGun(gameWrapper), gameWrapper) { }

        public override string Name => "F25";

        protected override int AgilityHorizontal => 30;

        protected override int AgilityVertical => 40;

        protected override int HitPoints => 50;

        protected override int UnlockedLevel => 5;

        protected override int Cost => 10000;
    }
}