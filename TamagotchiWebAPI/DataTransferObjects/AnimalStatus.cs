using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BuisnessLogicDll.Models;


#nullable disable

namespace TamagotchiWebAPI.DataTransferObjects
{
    
    public partial class AnimalStatusDTO
    {
        public AnimalStatusDTO(AnimalStatus animalStatus)
        {
            StatusId = animalStatus.StatusId;
            AnimalStatus1 = animalStatus.AnimalStatus1;
        }
        public int StatusId { get; set; }
        
        public string AnimalStatus1 { get; set; }
    }
}
