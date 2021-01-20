using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nookleo.Data.TaskClasses
{
    public class CornTask : Task
    {
        [Key]
        public int CornTaskId { get; set; }
        public CornGrowthStage GrowthStage { get; set; }
        public CornTaskType TaskOne { get; set; }
        public CornTaskType TaskTwo { get; set; }
        public CornTaskType TaskThree { get; set; }

        public int EmployeeId { get; set; }
        public int LocationId { get; set; }
    }

    public enum CornTaskType 
    {
        [Display(Name = " ")]
        blank,
        Cultivating,
        [Display(Name = "Drone Flight")]
        DroneFlight,
        Harvest,
        [Display(Name = "Herbicide Application")]
        HerbicideApplication,
        [Display(Name = "Insecticide Application")]
        InsecticideApplication,
        [Display(Name = "Lodging Notes")]
        LodgingNotes,
        [Display(Name = "Nitrogen Application")]
        NitrogenApplication,
        [Display(Name = "Note Taking")]
        Notes,
        [Display(Name = "Plant & Ear Heights")]
        PlantEarHeights,
        Planting,
        Rowbanding,
        Staking,
        [Display(Name = "Stand Counts")]
        StandCounts,
        [Display(Name = "Weed Management")]
        WeedManagement
    }

    public enum CornGrowthStage
    {
        [Display(Name = " ")]
        blank,
        V0, 
        VE, 
        V1, 
        V2, 
        V3, 
        V4, 
        V5, 
        V6, 
        V7, 
        V8, 
        V9, 
        V10, 
        V11, 
        V12, 
        V13, 
        V14, 
        V15, 
        VT, 
        R1, 
        R2, 
        R3, 
        R4, 
        R5, 
        R6
    }
}
