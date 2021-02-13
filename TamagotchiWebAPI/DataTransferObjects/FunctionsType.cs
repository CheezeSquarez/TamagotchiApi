using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BuisnessLogicDll.Models;

#nullable disable

namespace TamagotchiWebAPI.DataTransferObjects
{
    
    public partial class FunctionsTypeDTO
    {
        public FunctionsTypeDTO(FunctionsType functionType)
        {
            FunctionTypeId = functionType.FunctionTypeId;
            FunctionType = functionType.FunctionType;
        }
        public int FunctionTypeId { get; set; }
        public string FunctionType { get; set; }
    }
}
