using JackSazerak.Library.Objects.Containers;

namespace JackSazerak.Library.GameObjects.Weapon
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