using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BuisnessLogicDll.Models;


#nullable disable

namespace TamagotchiWebAPI.DataTransferObjects
{
    public partial class FunctionDTO
    {
        public FunctionDTO(Function f)
        {
            FunctionId = f.FunctionId;
            FunctionName = f.FunctionName;
            HungerImpact = f.HungerImpact;
            HappinessImpact = f.HappinessImpact;
            HygieneImpact = f.HygieneImpact;
            FunctionTypeId = f.FunctionTypeId;
        }
        public int FunctionId { get; set; }
        public string FunctionName { get; set; }
        public int HungerImpact { get; set; }
        public int HygieneImpact { get; set; }
        public int HappinessImpact { get; set; }
        public int? FunctionTypeId { get; set; }

    }
}
