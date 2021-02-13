using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BuisnessLogicDll.Models
{
    partial class FunctionsType
    {
        public List<Function> GetAllFunctions() => this.Functions.ToList();
        
    }
}
