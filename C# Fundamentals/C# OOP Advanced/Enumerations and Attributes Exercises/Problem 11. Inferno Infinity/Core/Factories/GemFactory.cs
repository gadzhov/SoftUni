using System;
using System.Collections.Generic;
using Problem_11.Inferno_Infinity.Interfaces;
using Problem_11.Inferno_Infinity.Models.Gems;

namespace Problem_11.Inferno_Infinity.Core.Factories
{
    public class GemFactory : IGemFactory
    {
        public IBaseGem Create(IList<string> tokens)
        {
            string clarity = tokens[0];
            string gemType = tokens[1];

            IBaseGem gem = null;

            switch (gemType)
            {
                case "Ruby":
                    gem = new Ruby(clarity);
                    break;

                case "Emerald":
                    gem = new Emerald(clarity);
                    break;

                case "Amethyst":
                    gem = new Amethyst(clarity);
                    break;

                default:
                    throw new ArgumentException("Invalid gem type!");
            }

            return gem;
        }
    }
}
