using System;
using Problem_3.BarracksWars.Contracts;

namespace Problem_3.BarracksWars.Core.Factories
{
    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            var typeInfo =
                Type.GetType("Problem_3.BarracksWars.Models.Units." + unitType);

            var iunit = Activator.CreateInstance(typeInfo) as IUnit;

            return iunit;
        }
    }
}
