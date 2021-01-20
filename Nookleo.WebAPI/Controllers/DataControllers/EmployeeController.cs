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
    public class EmployeeController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetAllEmployees()
        {
            EmployeeService employeeService = CreateEmployeeService();
            var employees = employeeService.GetEmployees();
            return Ok(employees);
        }

        [HttpGet]
        public IHttpActionResult GetEmployeeById(int employeeId)
        {
            EmployeeService employeeService = CreateEmployeeService();
            var employee = employeeService.GetEmployeeById(employeeId);
            return Ok(employee);
        }

        [HttpPost]
        public IHttpActionResult CreateEmployee(EmployeeCreate model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employeeService = CreateEmployeeService();

            if (!employeeService.CreateEmployee(model))
            {
                return InternalServerError();
            }

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult EditEmployee(EmployeeEdit employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employeeService = CreateEmployeeService();

            if (!employeeService.UpdateEmployee(employee))
            {
                return InternalServerError();
            }

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteEmployee(int employeeId)
        {
            var employeeService = CreateEmployeeService();

            if (!employeeService.DeleteEmployee(employeeId))
            {
                return InternalServerError();
            }

            return Ok();
        }

        private EmployeeService CreateEmployeeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var employeeService = new EmployeeService(userId);
            return employeeService;
        }
    }
}
