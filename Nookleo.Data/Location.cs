using Nookleo.Data.PeopleClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nookleo.Data
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; } //PrimaryKey - NOT Industry Standard equal to LocId
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string LocationCode { get; set; } //Industry Standard equal to LocId
        public string City { get; set; }
        public State State { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public DateTimeOffset? PlantingDate { get; set; }
        public DateTimeOffset? HarvestDate { get; set; }


        [ForeignKey("Cooperator")]
        public int? CooperatorId { get; set; } //FK to Cooperators Table
        public virtual Cooperator Cooperator { get; set; } //Virtual Object Cooperator


        [ForeignKey("TestingEmployee")]
        public int? TestingEmployeeId { get; set; } //FK to Employees Table
        public virtual Employee TestingEmployee { get; set; } //Virtual Object Employee - Testing Primary Contact


        [ForeignKey("ProductDevelopmentEmployee")]
        public int? ProductDevelopmentEmployeeId { get; set; } //FK to Employees Table
        public virtual Employee ProductDevelopmentEmployee { get; set; } //Virtual Object Employee - Product Development Primary Contact


        [ForeignKey("BreedingEmployee")]
        public int? BreedingEmployeeId { get; set; } //FK to Employees Table
        public virtual Employee BreedingEmployee { get; set; } //Virtual Object Employee - Breeding Primary Contact
    }

    public enum State
    {
        AK, AL, AR, AS, AZ, CA, CO, CT, DC, DE, FL, GA, GU, HI, IA, ID, IL, IN, KS, KY, LA, MA, MD, ME, MI, MN, MO, MP, MS, MT, NC, ND, NE, NH, NJ, NM, NV, NY, OH, OK, OR, PA, PR, RI, SC, SD, TN, TX, UM, UT, VA, VI, VT, WA, WI, WV, WY
    }
}
