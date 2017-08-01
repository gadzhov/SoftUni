using Problem_11.Inferno_Infinity.Models.Enums;
using Problem_11.Inferno_Infinity.Models.Utilities;

namespace Problem_11.Inferno_Infinity.Interfaces
{
    public interface IBaseGem
    {
        int AgilityBonus { get; }
        Clarity Clarity { get; }
        int StrengthBonus { get; }
        int VitalityBonus { get; }

        void AddClarityBonuses();

        DmgBoost CalculateDamageBoost();
    }
}