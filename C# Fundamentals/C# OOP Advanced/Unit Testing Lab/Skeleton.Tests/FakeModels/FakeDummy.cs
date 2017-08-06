using Skeleton.Contracts;

namespace Skeleton.Tests.FakeModels
{
    public class FakeDummy : ITarget
    {
        public int Health => 20;

        public void TakeAttack(int attackPoints)
        {
        }

        public int GiveExperience()
        {
            return 20;
        }

        public bool IsDead()
        {
            return true;
        }
    }
}
