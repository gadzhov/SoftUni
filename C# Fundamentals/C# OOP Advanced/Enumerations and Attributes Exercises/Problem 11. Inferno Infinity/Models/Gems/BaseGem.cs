using System;
using Problem_11.Inferno_Infinity.Interfaces;
using Problem_11.Inferno_Infinity.Models.Enums;
using Problem_11.Inferno_Infinity.Models.Utilities;

namespace Problem_11.Inferno_Infinity.Models.Gems
{
    public abstract class BaseGem : IBaseGem
    {
        public BaseGem(string clarity)
        {
            this.Clarity = (Clarity)Enum.Parse(typeof(Clarity), clarity);
        }

        public int AgilityBonus { get; protected set; }
        public Clarity Clarity { get; protected set; }
        public int StrengthBonus { get; protected set; }
        public int VitalityBonus { get; protected set; }

        public void AddClarityBonuses()
        {
            this.StrengthBonus += (int)this.Clarity;
            this.AgilityBonus += (int)this.Clarity;
            this.VitalityBonus += (int)this.Clarity;
        }

        public DmgBoost CalculateDamageBoost()
        {
            int minDmgBoost;
            int maxDmgBoost;

            minDmgBoost = this.StrengthBonus * 2;
            maxDmgBoost = this.StrengthBonus * 3;
            minDmgBoost += this.AgilityBonus * 1;
            maxDmgBoost += this.AgilityBonus * 4;

            return new DmgBoost(minDmgBoost, maxDmgBoost);
        }
    }
}
