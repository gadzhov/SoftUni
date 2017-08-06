using Moq;
using NUnit.Framework;
using Skeleton.Contracts;
using Skeleton.Tests.FakeModels;

namespace Skeleton.Tests
{
    [TestFixture]
    public class HeroTest
    {
        private const string HeroName = "Vladimir";

        [Test]
        public void HeroGainsExperienceAfterAttackIfTargetDies()
        {
            var fakeTarget = new FakeDummy();
            var fakeWeapon = new FakeWeapon();

            var hero = new Hero(HeroName, fakeWeapon);
            hero.Attack(fakeTarget);

            Assert.AreEqual(20, hero.Experience, "Hero Doesn't Gain Experience.");
        }

        [Test]
        public void HeroGainsExperienceAfterAttackIfTargetDiesWithMoq()
        {
            var fakeTarget = new Mock<ITarget>();
            fakeTarget.Setup(p => p.Health).Returns(0);
            fakeTarget.Setup(p => p.GiveExperience()).Returns(20);
            fakeTarget.Setup(p => p.IsDead()).Returns(true);
            var fakeWeapon = new Mock<IWeapon>();
            var hero = new Hero("Pesho", fakeWeapon.Object);

            hero.Attack(fakeTarget.Object);

            Assert.AreEqual(20, hero.Experience, "Hero doesn't gain experience.");
        }
    }
}
