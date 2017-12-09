using JackSazerak.UWP.Objects.Containers;

namespace JackSazerak.UWP.GameObjects.Weapon
{
    public class Sidewinder : BaseWeapon
    {
        public Sidewinder(GameWrapper wrapper) : base("sidewinder", wrapper)
        {
        }

        protected override int RateOfFire => 2;

        protected override int Damage => 30;
    }
}