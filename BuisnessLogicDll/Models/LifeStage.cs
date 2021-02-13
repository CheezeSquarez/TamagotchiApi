using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BuisnessLogicDll.Models
{
    [Table("LifeStage")]
    [Index(nameof(Stage), Name = "I_Stage")]
    [Index(nameof(StageDuration), Name = "I_StageDuration")]
    [Index(nameof(StageId), Name = "I_StageId")]
    [Index(nameof(Stage), Name = "U_Stage", IsUnique = true)]
    public partial class LifeStage
    {
        public LifeStage()
        {
            Animals = new HashSet<Animal>();
            Histories = new HashSet<History>();
        }

        [Key]
        public int StageId { get; set; }
        [Required]
        [StringLength(50)]
        public string Stage { get; set; }
        public int StageDuration { get; set; }

        [InverseProperty(nameof(Animal.LifeStage))]
        public virtual ICollection<Animal> Animals { get; set; }
        [InverseProperty(nameof(History.LifeStage))]
        public virtual ICollection<History> Histories { get; set; }
    }
}
