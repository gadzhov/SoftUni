using System.Collections.Generic;

namespace Paw_Inc.Entities.Centers
{
    public class CleansingCenter : Center
    {
        public CleansingCenter(string name)
            : base(name)
        {
        }

        public void GetAnimalsForCleansing(string adoptionCenterName, List<Animal> animals)
        {
            if (!base.Animals.ContainsKey(adoptionCenterName))
            {
                base.Animals.Add(adoptionCenterName, new List<Animal>());
                base.Animals[adoptionCenterName].AddRange(animals);
            }
            else
            {
                base.Animals[adoptionCenterName].AddRange(animals);
            }
        }

        public Dictionary<string, List<Animal>> CleanAnimals()
        {
            var animalsToTransfer = new Dictionary<string, List<Animal>>();
            foreach (var animal in base.Animals)
            {
                animalsToTransfer.Add(animal.Key, new List<Animal>());
                foreach (var a in animal.Value)
                {
                    animalsToTransfer[animal.Key].Add(a);
                    a.IsClean = true;
                }
            }
            base.Animals.Clear();

            return animalsToTransfer;
        }
    }
}
