using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BuisnessLogicDll.Models
{
    partial class TamagotchiContext
    {
        public void AddPlayer(Player p)
        {
                this.Players.Add(p);
                this.SaveChanges();
        }
        public void AddAnimal(Animal a)
        {
            this.Animals.Add(a);
            this.SaveChanges();
        }

        public void KillActiveAnimal(int pId)
        {
            Animal a = GetActiveAnimal(pId);
            a.AnimalStatusId = 4;
            SaveChanges();
        }
        public void SetActiveAnimal(Animal a, int pId)
        {
            Player p = this.Players.FirstOrDefault(x => x.PlayerId == pId);

            p.ActiveAnimal = a.AnimalId;
            p.ActiveAnimalNavigation = a;
            p.ActiveAnimalNavigation.LifeStage = this.LifeStages.Where(x => x.StageId == p.ActiveAnimalNavigation.LifeStageId).FirstOrDefault();
            p.ActiveAnimalNavigation.AnimalStatus = this.AnimalStatuses.Where(x => x.StatusId == p.ActiveAnimalNavigation.AnimalStatusId).FirstOrDefault();
            SaveChanges();
        }

        public Animal GetActiveAnimal(int playerId) => this.Players.FirstOrDefault(x => x.PlayerId == playerId).GetActiveAnimal();
        public bool DoesExist(string username, string email) => this.Players.Any(x => x.Username == username || x.Email == email);
        public Player Login(string uName, string pass) => this.Players.FirstOrDefault(p => p.Username == uName && p.PWord == pass);
        public Animal FindAnimalById(int id) => this.Animals.FirstOrDefault(x => x.AnimalId == id);
        public FunctionsType GetFunctionsTypeById(int id) => this.FunctionsTypes.FirstOrDefault(x => x.FunctionTypeId == id);





    }
}
