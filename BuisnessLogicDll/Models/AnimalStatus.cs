using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BuisnessLogicDll.Models
{
    [Table("AnimalStatus")]
    [Index(nameof(StatusId), Name = "I_AnimalStatusId")]
    [Index(nameof(AnimalStatus1), Name = "I_AnimalStatusName")]
    [Index(nameof(AnimalStatus1), Name = "U_AnimalStatus", IsUnique = true)]
    public partial class AnimalStatus
    {
        public AnimalStatus()
        {
            Animals = new HashSet<Animal>();
            Histories = new HashSet<History>();
        }

        [Key]
        public int StatusId { get; set; }
        [Required]
        [Column("AnimalStatus")]
        [StringLength(30)]
        public string AnimalStatus1 { get; set; }

        [InverseProperty(nameof(Animal.AnimalStatus))]
        public virtual ICollection<Animal> Animals { get; set; }
        [InverseProperty(nameof(History.AnimalStatus))]
        public virtual ICollection<History> Histories { get; set; }
    }
}
