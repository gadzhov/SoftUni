using System;
using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private const int Health = 10;
        private const int Experience = 10;
        private const int Damage = 5;
        private Dummy dummy;

        [SetUp]
        public void SetUp()
        {
            this.dummy = new Dummy(Health, Experience);
        }

        [Test]
        public void DummyLosesHealthIfAtacked()
        {
            

            this.dummy.TakeAttack(Damage);

            Assert.AreEqual(5, this.dummy.Health);
        }

        [Test]
        public void DeadDummyThrowExceptionIfAtacked()
        {
            var deadDummy = new Dummy(0, Experience);

            var ex = Assert.Catch<InvalidOperationException>(delegate { deadDummy.TakeAttack(Damage); });

            Assert.AreEqual("Dummy is dead.", ex.Message);
        }

        [Test]
        public void DeadDummyGiveExperience()
        {
            var deadDummy = new Dummy(0, 10);

            var exp = deadDummy.GiveExperience();

            Assert.AreEqual(10, exp, "Dummy doesn't give experience.");
        }

        [Test]
        public void AliveDummyCannotGiveExperience()
        {
            var aliveDummt = new Dummy(10, Experience);

            var ex = Assert.Catch<InvalidOperationException>(delegate { aliveDummt.GiveExperience(); });

            Assert.AreEqual("Target is not dead.", ex.Message, "Allive Dummy Gives Experience.");
        }
    }
}
