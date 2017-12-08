using JackSazerak.UWP.Objects.Containers;

namespace JackSazerak.UWP.GameObjects.Weapon
{
    public class VulkanGun : BaseWeapon
    {
        protected VulkanGun(GameWrapper wrapper) : base("VulkanGun", wrapper)
        {
        }

        protected override int RateOfFire => 10;

        protected override int Damage => 5;
    }
}