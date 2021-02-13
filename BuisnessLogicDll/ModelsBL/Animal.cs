using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuisnessLogicDll.Models
{
    partial class Animal
    {
        public static Animal CreateAnimal(string name, int id)
        {
            return new Animal() { AnimalName = name, PlayerId = id };
        }

        public List<Function> GetPreviousFunctions(int amount)
        {
            return this.Histories
            .OrderByDescending(h => h.FunctionTime)
            .Select(h => h.Function)
            .Take(amount)
            .ToList();
        }
        public void UpdateStat(Function f, TamagotchiContext db)
        {
            db.Histories.Add(new History() { Function = f, Age = this.Age, FunctionId = f.FunctionId, AnimalId = this.AnimalId, Animal = this, AnimalStatus = this.AnimalStatus, AnimalWeight = this.AnimalWeight, Happiness = this.Happiness, Hunger = this.Hunger, Hygiene = this.Hygiene, AnimalStatusId = this.AnimalStatusId, LifeStage = this.LifeStage, LifeStageId = this.LifeStageId });
            this.Hunger += f.HungerImpact;
            this.Hygiene += f.HygieneImpact;
            this.Happiness += f.HappinessImpact;

            if (this.Hunger > 100)
                this.Hunger = 100;
            if (this.Hygiene > 100)
                this.Hygiene = 100;
            if (this.Happiness > 100)
                this.Happiness = 100;

            if (this.Hunger < 0)
                this.Hunger = 0;
            if (this.Hygiene < 0)
                this.Hygiene = 0;
            if (this.Happiness < 0)
                this.Happiness = 0;
        }
        public string GetStatusString() => this.AnimalStatus.AnimalStatus1;
        public string GetLifeStageString() => this.LifeStage.Stage;
        public void FullPrintAnimal()
        {
            string date = this.DateOfBirth.ToString("d");
            Console.WriteLine($"Name: {this.AnimalName}\n" +
                $"Date of Birth: {date}\n" +
                $"Age: {this.Age}\n" +
                $"Weight: {this.AnimalWeight}\n" +
                $"Life Stage: {this.LifeStage.Stage}\n" +
                $"Animal Status: {this.AnimalStatus.AnimalStatus1}\n" +
                $"-Stats-\n" +
                $"Happiness: {this.Happiness}\n" +
                $"Hygiene: {this.Hygiene}\n" +
                $"Hunger: {this.Hunger}");
        }

        public override string ToString()
        {
            return $"{this.AnimalName}\nThey Are {this.GetStatusString()}\n{this.Age} hours old";
        }


    }
}
