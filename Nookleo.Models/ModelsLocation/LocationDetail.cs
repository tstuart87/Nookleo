﻿using Nookleo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nookleo.Models.ModelsLocation
{
    public class LocationDetail
    {
        public int LocationId { get; set; }
        public Guid OwnerId { get; set; }
        public string LocationCode { get; set; }
        public string City { get; set; }
        public State State { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public DateTimeOffset? PlantingDate { get; set; }
        public DateTimeOffset? HarvestDate { get; set; }

    }
}
