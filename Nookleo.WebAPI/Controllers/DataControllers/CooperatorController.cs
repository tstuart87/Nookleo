using Microsoft.AspNet.Identity;
using Nookleo.Models.ModelsContact;
using Nookleo.Services.ServicesContact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Nookleo.WebAPI.Controllers.DataControllers
{
    [Authorize]
    public class CooperatorController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetAllCooperators()
        {
            CooperatorService cooperatorService = CreateCooperatorService();
            var cooperators = cooperatorService.GetCooperators();
            return Ok(cooperators);
        }

        [HttpGet]
        public IHttpActionResult GetCooperatorById(int cooperatorId)
        {
            CooperatorService cooperatorService = CreateCooperatorService();
            var cooperator = cooperatorService.GetCooperatorById(cooperatorId);
            return Ok(cooperator);
        }

        [HttpPost]
        public IHttpActionResult CreateCooperator(CooperatorCreate model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cooperatorService = CreateCooperatorService();

            if (!cooperatorService.CreateCooperator(model))
            {
                return InternalServerError();
            }

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult EditCooperator(CooperatorEdit cooperator)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cooperatorService = CreateCooperatorService();

            if (!cooperatorService.UpdateCooperator(cooperator))
            {
                return InternalServerError();
            }

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteCooperator(int cooperatorId)
        {
            var cooperatorService = CreateCooperatorService();

            if (!cooperatorService.DeleteCooperator(cooperatorId))
            {
                return InternalServerError();
            }

            return Ok();
        }

        private CooperatorService CreateCooperatorService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var cooperatorService = new CooperatorService(userId);
            return cooperatorService;
        }
    }
}
