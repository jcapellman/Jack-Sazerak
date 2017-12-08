using JackSazerak.UWP.Objects.Containers;

namespace JackSazerak.UWP.GameObjects.Weapon
{
    public class Sidewinder : BaseWeapon
    {
        protected Sidewinder(GameWrapper wrapper) : base("Sidewinder", wrapper)
        {
        }

        protected override int RateOfFire => 2;

        protected override int Damage => 30;
    }
}