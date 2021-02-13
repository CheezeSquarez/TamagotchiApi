using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BuisnessLogicDll.Models
{
    public partial class Animal
    {
        public Animal()
        {
            Histories = new HashSet<History>();
        }

        [Key]
        public int AnimalId { get; set; }
        [Required]
        [StringLength(100)]
        public string AnimalName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateOfBirth { get; set; }
        public int AnimalWeight { get; set; }
        public int Age { get; set; }
        public int Hunger { get; set; }
        public int Hygiene { get; set; }
        public int Happiness { get; set; }
        public int? PlayerId { get; set; }
        public int? LifeStageId { get; set; }
        public int? AnimalStatusId { get; set; }

        [ForeignKey(nameof(AnimalStatusId))]
        [InverseProperty("Animals")]
        public virtual AnimalStatus AnimalStatus { get; set; }
        [ForeignKey(nameof(LifeStageId))]
        [InverseProperty("Animals")]
        public virtual LifeStage LifeStage { get; set; }
        [ForeignKey(nameof(PlayerId))]
        [InverseProperty("Animals")]
        public virtual Player Player { get; set; }
        [InverseProperty("ActiveAnimalNavigation")]
        public virtual Player PlayerNavigation { get; set; }
        [InverseProperty(nameof(History.Animal))]
        public virtual ICollection<History> Histories { get; set; }
    }
}
