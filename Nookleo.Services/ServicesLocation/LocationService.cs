using Nookleo.Data;
using Nookleo.Models.ModelsLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nookleo.Services.ServicesLocation
{
    public class LocationService
    {
        private readonly Guid _userId;

        public LocationService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateLocation(LocationCreate model)
        {
            var entity = new Location()
            {
                OwnerId = _userId,
                LocationCode = model.LocationCode,
                City = model.City,
                State = model.State,
                Latitude = model.Latitude,
                Longitude = model.Longitude
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Locations.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<LocationListItem> GetLocations()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Locations
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                            new LocationListItem
                            {
                                LocationId = e.LocationId,
                                LocationCode = e.LocationCode,
                                City = e.City,
                                State = e.State,
                                Latitude = e.Latitude,
                                Longitude = e.Longitude,
                                PlantingDate = e.PlantingDate,
                                HarvestDate = e.HarvestDate,
                                Cooperator = e.Cooperator,
                                TestingEmployee = e.TestingEmployee,
                                ProductDevelopmentEmployee = e.ProductDevelopmentEmployee,
                                BreedingEmployee = e.BreedingEmployee,
                                Tasks = ctx.CornTasks.Where(c => c.LocationId == e.LocationId && c.OwnerId == _userId)
                            }
                    );

                return query.ToArray();
            }
        }

        public LocationDetail GetLocationById(int locationId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Locations
                    .Single(e => e.LocationId == locationId && e.OwnerId == _userId);

                return new LocationDetail
                {
                    LocationId = entity.LocationId,
                    OwnerId = entity.OwnerId,
                    LocationCode = entity.LocationCode,
                    City = entity.City,
                    State = entity.State,
                    Latitude = entity.Latitude,
                    Longitude = entity.Longitude,
                    PlantingDate = entity.PlantingDate,
                    HarvestDate = entity.HarvestDate,
                    Cooperator = entity.Cooperator,
                    TestingEmployee = entity.TestingEmployee,
                    ProductDevelopmentEmployee = entity.ProductDevelopmentEmployee,
                    BreedingEmployee = entity.BreedingEmployee,
                    Tasks = ctx.CornTasks.Where(c => c.LocationId == entity.LocationId && c.OwnerId == _userId)
                };
            }
        }

        public bool UpdateLocation(LocationEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Locations
                    .Single(e => e.LocationId == model.LocationId && e.OwnerId == _userId);

                entity.LocationCode = model.LocationCode;
                entity.City = model.City;
                entity.State = model.State;
                entity.Latitude = model.Latitude;
                entity.Longitude = model.Longitude;
                entity.PlantingDate = model.PlantingDate;
                entity.HarvestDate = model.HarvestDate;
                entity.CooperatorId = model.CooperatorId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteLocation(int locationId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Locations
                    .Single(e => e.LocationId == locationId && e.OwnerId == _userId);

                ctx.Locations.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
