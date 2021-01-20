using Microsoft.AspNet.Identity;
using Nookleo.Models.ModelsLocation;
using Nookleo.Services.ServicesLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Nookleo.WebAPI.Controllers.DataControllers
{
    [Authorize]
    public class LocationController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetAllLocations()
        {
            LocationService locationService = CreateLocationService();
            var locations = locationService.GetLocations();
            return Ok(locations);
        }

        [HttpGet]
        public IHttpActionResult GetLocationById(int locationId)
        {
            LocationService locationService = CreateLocationService();
            var location = locationService.GetLocationById(locationId);
            return Ok(location);
        }

        [HttpPost]
        public IHttpActionResult CreateLocation(LocationCreate model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var locationService = CreateLocationService();

            if (!locationService.CreateLocation(model))
            { 
                return InternalServerError(); 
            }

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult EditLocation(LocationEdit location)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var locationService = CreateLocationService();

            if (!locationService.UpdateLocation(location))
            {
                return InternalServerError();
            }

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteLocation(int locationId)
        {
            var locationService = CreateLocationService();

            if (!locationService.DeleteLocation(locationId))
            {
                return InternalServerError();
            }

            return Ok();
        }

        private LocationService CreateLocationService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var locationService = new LocationService(userId);
            return locationService;
        }
    }
}
