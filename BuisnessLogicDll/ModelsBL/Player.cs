using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BuisnessLogicDll.Models
{
    partial class Player
    {
        public Animal GetActiveAnimal() => this.ActiveAnimalNavigation;
        public List<Animal> GetPlayerAnimals(int amount) => this.Animals.OrderByDescending(a => a.DateOfBirth).Take(amount).ToList();
        public List<Animal> GetPlayerAnimals() => this.Animals.ToList();
        public int GetAgeInYears() => (DateTime.Now - this.DateOfBirth).Days / 365;
        public int GetSuccessRate()
        {
            if(this.Animals.Count(x => x.AnimalStatusId == 4 && x.AnimalId != this.ActiveAnimal) > 0)
                return (this.Animals.Count(x => x.Age == 204 && x.AnimalStatusId == 4) / this.Animals.Count(x => x.AnimalStatusId == 4 && x.AnimalId != this.ActiveAnimal)) * 100;
            return -1;
        }
        public void SetActiveAnimal(Animal a, TamagotchiContext db)
        {
            this.ActiveAnimal = a.AnimalId;
            this.ActiveAnimalNavigation = a;
            this.ActiveAnimalNavigation.LifeStage = db.LifeStages.Where(x => x.StageId == this.ActiveAnimalNavigation.LifeStageId).FirstOrDefault();
            this.ActiveAnimalNavigation.AnimalStatus = db.AnimalStatuses.Where(x => x.StatusId == this.ActiveAnimalNavigation.AnimalStatusId).FirstOrDefault();
            db.SaveChanges();
        }

        





        }
}
