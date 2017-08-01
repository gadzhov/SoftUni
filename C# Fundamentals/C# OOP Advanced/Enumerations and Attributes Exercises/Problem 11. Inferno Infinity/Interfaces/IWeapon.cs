using Problem_11.Inferno_Infinity.Models.Enums;

namespace Problem_11.Inferno_Infinity.Interfaces
{
    public interface IWeapon
    {
        int Agility { get; }
        int MaxDamage { get; }
        int MinDamage { get; }
        Rarity Rarity { get; }
        IBaseGem[] Sockets { get; }
        int Strength { get; }
        int Vitality { get; }
        string WeaponName { get; }
        WeaponType WeaponType { get; }

        void AddGem(int socketIndex, IBaseGem gem);

        void AddRarityBonuses();

        void RemoveGem(int socketIndex);

        string ToString();
    }
}
