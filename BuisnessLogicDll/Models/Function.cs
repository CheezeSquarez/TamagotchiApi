using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BuisnessLogicDll.Models
{
    [Index(nameof(FunctionId), Name = "I_FunctionId")]
    [Index(nameof(FunctionName), Name = "I_FunctionName")]
    [Index(nameof(FunctionTypeId), Name = "I_FunctionTypeIdInFunctionsTable")]
    public partial class Function
    {
        public Function()
        {
            Histories = new HashSet<History>();
        }

        [Key]
        public int FunctionId { get; set; }
        [Required]
        [StringLength(30)]
        public string FunctionName { get; set; }
        public int HungerImpact { get; set; }
        public int HygieneImpact { get; set; }
        public int HappinessImpact { get; set; }
        public int? FunctionTypeId { get; set; }

        [ForeignKey(nameof(FunctionTypeId))]
        [InverseProperty(nameof(FunctionsType.Functions))]
        public virtual FunctionsType FunctionType { get; set; }
        [InverseProperty(nameof(History.Function))]
        public virtual ICollection<History> Histories { get; set; }
    }
}
