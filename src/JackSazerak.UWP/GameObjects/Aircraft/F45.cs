using JackSazerak.UWP.Objects.Containers;

namespace JackSazerak.UWP.GameObjects.Aircraft
{
    public class F45 : BaseAircraft
    {
        public F45(GameWrapper wrapper) : base("F45", wrapper) { }

        public override string Name => "F45";

        protected override int AgilityHorizontal => 50;

        protected override int AgilityVertical => 30;
    }
}