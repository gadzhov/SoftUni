using System;
using NUnit.Framework;

[TestFixture]
public class AxeTests
{
    private const int Atack = 10;
    private const int Durability = 10;
    private const int Health = 10;
    private const int Expirience = 10;
    private Axe axe;
    private Dummy dummy;

    [SetUp]
    public void SetUp()
    {
        this.axe = new Axe(Atack, Durability);
        this.dummy = new Dummy(Health, Expirience);
    }

    [Test]
    public void AxeLosesDurabilityAfterEachAtack()
    {
        this.axe.Attack(this.dummy);

        Assert.AreEqual(9, this.axe.DurabilityPoints, "Axe Durability doesn't change after atack.");
    }

    [Test]
    public void AtackWithBrokenAxe()
    {
        this.axe = new Axe(Atack, 0);

        var ex = Assert.Catch<InvalidOperationException>(() => this.axe.Attack(this.dummy));

        Assert.AreEqual("Axe is broken.", ex.Message, "Atac With Broken Axe.");
    }
}
