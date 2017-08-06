using Skeleton.Contracts;

namespace Skeleton.Tests.FakeModels
{
    public class FakeWeapon : IWeapon
    {
        public int AttackPoints => 10;

        public int DurabilityPoints => 10;

        public void Attack(ITarget target)
        {
        }
    }
}
