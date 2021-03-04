using Nookleo.Data;
using Nookleo.Data.PeopleClasses;
using Nookleo.Data.TaskClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nookleo.Models.ModelsLocation
{
    public class LocationListItem
    {
        public int LocationId { get; set; } //PrimaryKey - not LocId
        public string LocationCode { get; set; } //LocId to the User
        public string City { get; set; }
        public State State { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public DateTimeOffset? PlantingDate { get; set; }
        public DateTimeOffset? HarvestDate { get; set; }
        public Cooperator Cooperator { get; set; }
        public Employee TestingEmployee { get; set; }
        public Employee ProductDevelopmentEmployee { get; set; }
        public Employee BreedingEmployee { get; set; }
        public IEnumerable<CornTask> Tasks { get; set; }
    }
}
