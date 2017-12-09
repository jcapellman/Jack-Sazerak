using JackSazerak.UWP.Objects.Containers;

namespace JackSazerak.UWP.GameObjects.Weapon
{
    public class VulkanGun : BaseWeapon
    {
        public VulkanGun(GameWrapper wrapper) : base("vulkangun", wrapper)
        {
        }

        protected override int RateOfFire => 10;

        protected override int Damage => 5;
    }
}