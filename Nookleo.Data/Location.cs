using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nookleo.Data
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; } //PrimaryKey - not LocId
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string LocationCode { get; set; } //LocId to the User
        public string City { get; set; }
        public State State { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public DateTimeOffset? PlantingDate { get; set; }
        public DateTimeOffset? HarvestDate { get; set; }
    }

    public enum State
    {
        AK, AL, AR, AS, AZ, CA, CO, CT, DC, DE, FL, GA, GU, HI, IA, ID, IL, IN, KS, KY, LA, MA, MD, ME, MI, MN, MO, MP, MS, MT, NC, ND, NE, NH, NJ, NM, NV, NY, OH, OK, OR, PA, PR, RI, SC, SD, TN, TX, UM, UT, VA, VI, VT, WA, WI, WV, WY
    }
}
