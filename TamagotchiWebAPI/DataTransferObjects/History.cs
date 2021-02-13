using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BuisnessLogicDll.Models;

#nullable disable

namespace TamagotchiWebAPI.DataTransferObjects
{
    public partial class HistoryDTO
    {
        public HistoryDTO(History h)
        {
            FunctionTime = h.FunctionTime;
            AnimalWeight = h.AnimalWeight;
            Age = h.Age;
            Hunger = h.Hunger;
            Hygiene = h.Hygiene;
            Happiness = h.Happiness;
            AnimalId = h.AnimalId;
            FunctionId = h.FunctionId;
            LifeStageId = h.LifeStageId;
            AnimalStatusId = h.AnimalStatusId;
        }
        public DateTime FunctionTime { get; set; }
        public int AnimalWeight { get; set; }
        public int Age { get; set; }
        public int Hunger { get; set; }
        public int Hygiene { get; set; }
        public int Happiness { get; set; }
        public int AnimalId { get; set; }
        public int? FunctionId { get; set; }
        public int? LifeStageId { get; set; }
        public int? AnimalStatusId { get; set; }
    }
}
