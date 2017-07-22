using System.Collections.Generic;
using System.Linq;

namespace Paw_Inc.Entities.Centers
{
    public class AdoptionCenter : Center
    {
        public AdoptionCenter(string name) 
            : base(name)
        {
            base.Animals.Add(this.Name, new List<Animal>());
        }

        public void RegisterAnimal(Animal animal)
        {
            base.Animals[this.Name].Add(animal);
        }

        public List<Animal> GetForClean()
        {
            var animalsToSendForClean = base.Animals[this.Name].Where(a => !a.IsClean).ToList();
            foreach (var animal in animalsToSendForClean)
            {
                base.Animals[this.Name].Remove(animal);
            }

            return animalsToSendForClean;
        }

        public void GetFromCleaningCenter(List<Animal> cleansedAnimals)
        {
            base.Animals[base.Name].AddRange(cleansedAnimals);
        }

        public List<Animal> Adopt()
        {
            var animalsNotToAdopt = base.Animals[base.Name].Where(a => !a.IsClean).ToList();
            var animalsToAdopt = base.Animals[base.Name].Where(a => a.IsClean).ToList();
            base.Animals[base.Name].Clear();
            base.Animals[base.Name].AddRange(animalsNotToAdopt);

            return animalsToAdopt;
        }

        public List<Animal> GetForCastration()
        {
            var animalsForCastration = new List<Animal>();
            animalsForCastration.AddRange(base.Animals[this.Name]);
            base.Animals[base.Name].Clear();

            return animalsForCastration;
        }
    }
}
