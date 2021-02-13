using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BuisnessLogicDll.Models;


#nullable disable

namespace TamagotchiWebAPI.DataTransferObjects
{
    public partial class AnimalDTO
    {
        public AnimalDTO(Animal a)
        {
            AnimalId = a.AnimalId;
            AnimalName = a.AnimalName;
            DateOfBirth = a.DateOfBirth;
            AnimalWeight = a.AnimalWeight;
            Age = a.Age;
            Hunger = a.Hunger;
            Hygiene = a.Hygiene;
            Happiness = a.Happiness;
            PlayerId = a.PlayerId;
            LifeStageId = a.LifeStageId;
            AnimalStatusId = a.AnimalStatusId;
        }

        public int AnimalId { get; set; }
        
        public string AnimalName { get; set; }
        
        public DateTime DateOfBirth { get; set; }
        public int AnimalWeight { get; set; }
        public int Age { get; set; }
        public int Hunger { get; set; }
        public int Hygiene { get; set; }
        public int Happiness { get; set; }
        public int? PlayerId { get; set; }
        public int? LifeStageId { get; set; }
        public int? AnimalStatusId { get; set; }

    }
}
