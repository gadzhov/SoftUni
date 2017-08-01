namespace Problem_11.Inferno_Infinity.Models.Gems
{
    public class Amethyst : BaseGem
    {
        public Amethyst(string clarity) : base(clarity)
        {
            this.StrengthBonus = 2;
            this.AgilityBonus = 8;
            this.VitalityBonus = 4;
            this.AddClarityBonuses();
        }
    }
}
