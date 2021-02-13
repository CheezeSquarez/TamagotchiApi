using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BuisnessLogicDll.Models
{
    [Table("FunctionsType")]
    [Index(nameof(FunctionTypeId), Name = "I_FunctionTypeId")]
    public partial class FunctionsType
    {
        public FunctionsType()
        {
            Functions = new HashSet<Function>();
        }

        [Key]
        public int FunctionTypeId { get; set; }
        [Required]
        [StringLength(30)]
        public string FunctionType { get; set; }

        [InverseProperty(nameof(Function.FunctionType))]
        public virtual ICollection<Function> Functions { get; set; }
    }
}
