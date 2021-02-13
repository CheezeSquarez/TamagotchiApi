using System;
using System.Collections.Generic;
using System.Text;

namespace BuisnessLogicDll.Models
{
    partial class Function
    {
        public FunctionsType GetFunctionType() => this.FunctionType;
        public string GetFunctionTypeString() => this.GetFunctionType().FunctionType;
        public int GetFunctionTypeId() => this.GetFunctionType().FunctionTypeId;
        public string PrintStats()
        {
             return ($"Hunger Impact : {this.HungerImpact}\n" +
                $"Happiness Impact : {this.HappinessImpact}\n" +
                $"Hygiene Impact : {this.HygieneImpact}\n");
        }
        public override string ToString()
        {
            return $"{this.FunctionName}:\n{PrintStats()}";
        }
    }
}
