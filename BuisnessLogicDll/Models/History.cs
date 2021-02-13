using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BuisnessLogicDll.Models
{
    [Table("History")]
    [Index(nameof(Age), Name = "I_AgiInHistory")]
    [Index(nameof(LifeStageId), Name = "I_LifeStageInHistory")]
    public partial class History
    {
        [Key]
        [Column(TypeName = "datetime")]
        public DateTime FunctionTime { get; set; }
        public int AnimalWeight { get; set; }
        public int Age { get; set; }
        public int Hunger { get; set; }
        public int Hygiene { get; set; }
        public int Happiness { get; set; }
        [Key]
        public int AnimalId { get; set; }
        public int? FunctionId { get; set; }
        public int? LifeStageId { get; set; }
        public int? AnimalStatusId { get; set; }

        [ForeignKey(nameof(AnimalId))]
        [InverseProperty("Histories")]
        public virtual Animal Animal { get; set; }
        [ForeignKey(nameof(AnimalStatusId))]
        [InverseProperty("Histories")]
        public virtual AnimalStatus AnimalStatus { get; set; }
        [ForeignKey(nameof(FunctionId))]
        [InverseProperty("Histories")]
        public virtual Function Function { get; set; }
        [ForeignKey(nameof(LifeStageId))]
        [InverseProperty("Histories")]
        public virtual LifeStage LifeStage { get; set; }
    }
}
