using JackSazerak.Library.Objects.Containers;

namespace JackSazerak.Library.GameObjects.Weapon
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