using System;
using System.Collections.Generic;
using Problem_11.Inferno_Infinity.Interfaces;
using Problem_11.Inferno_Infinity.Models.Weapons;

namespace Problem_11.Inferno_Infinity.Core.Factories
{
    public class WeaponFactory : IWeaponFactory
    {
        public IWeapon Create(IList<string> tokens)
        {
            string weaponType = tokens[1];
            string rarity = tokens[0];
            string name = tokens[2];

            IWeapon weapon = null;

            switch (weaponType)
            {
                case "Axe":
                    weapon = new Axe(weaponType, rarity, name);
                    break;

                case "Knife":
                    weapon = new Knife(weaponType, rarity, name);
                    break;

                case "Sword":
                    weapon = new Sword(weaponType, rarity, name);
                    break;

                default:
                    throw new ArgumentException($"Invalid weapon type!");
            }

            return weapon;
        }
    }
}
