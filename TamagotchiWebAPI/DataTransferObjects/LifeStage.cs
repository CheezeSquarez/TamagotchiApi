using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BuisnessLogicDll.Models;


#nullable disable

namespace TamagotchiWebAPI.DataTransferObjects
{
   
    public partial class LifeStageDTO
    {
        public LifeStageDTO(LifeStage lifeStage)
        {
            StageId = lifeStage.StageId;
            Stage = lifeStage.Stage;
            StageDuration = lifeStage.StageDuration;
        }
        public int StageId { get; set; }
        public string Stage { get; set; }
        public int StageDuration { get; set; }
    }
}
