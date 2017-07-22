using System.Collections.Generic;

namespace Paw_Inc.Entities.Centers
{
    public class CastrationCenter : Center
    {
        public CastrationCenter(string name) : base(name)
        {
        }

        public void GetForCastration(string adoptionCenterName, List<Animal> animals)
        {
            if (!base.Animals.ContainsKey(adoptionCenterName))
            {
                base.Animals.Add(adoptionCenterName, new List<Animal>());
            }
            else
            {
                
            }
            base.Animals[adoptionCenterName].AddRange(animals);
        }

        public Dictionary<string, List<Animal>> Castrate()
        {
            var animalsToGoHome = new Dictionary<string, List<Animal>>();
            foreach (var center in base.Animals)
            {
                animalsToGoHome.Add(center.Key, new List<Animal>());
                foreach (var animal in center.Value)
                {
                    animal.IsCastrated = true;
                    animalsToGoHome[center.Key].Add(animal);
                }
            }

            return animalsToGoHome;
        }
    }
}
