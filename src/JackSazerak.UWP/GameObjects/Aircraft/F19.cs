using JackSazerak.UWP.Objects.Containers;

namespace JackSazerak.UWP.GameObjects.Aircraft
{
    public class F19 : BaseAircraft
    {
        public F19(GameWrapper wrapper) : base("F19", wrapper) { }

        public override string GetName() => "F19";

        protected override int AgilityHorizontal() => 80;

        protected override int AgilityVertical() => 80;
    }
}