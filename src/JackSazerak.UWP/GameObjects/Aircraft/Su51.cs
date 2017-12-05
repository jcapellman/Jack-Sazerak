using JackSazerak.UWP.Objects.Containers;

namespace JackSazerak.UWP.GameObjects.Aircraft
{
    public class Su51 : BaseAircraft
    {
        public Su51(GameWrapper wrapper) : base("Su51", wrapper) { }

        public override string GetName() => "Su51";

        protected override int AgilityHorizontal() => 40;

        protected override int AgilityVertical() => 40;
    }
}