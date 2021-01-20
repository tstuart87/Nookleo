using Nookleo.Data;
using Nookleo.Data.PeopleClasses;
using Nookleo.Models.ModelsContact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nookleo.Services.ServicesContact
{
    public class EmployeeService
    {
        private readonly Guid _userId;

        public EmployeeService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateEmployee(EmployeeCreate model)
        {
            var entity = new Employee()
            {
                OwnerId = _userId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Phone = model.Phone,
                ContactType = ContactType.Employee
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Employees.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<EmployeeListItem> GetEmployees()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Employees
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                            new EmployeeListItem
                            {
                                EmployeeId = e.EmployeeId,
                                FirstName = e.FirstName,
                                LastName = e.LastName,
                                Email = e.Email,
                                Phone = e.Phone,
                                ContactType = e.ContactType,
                            }
                     );

                return query.ToArray();
            }
        }

        public EmployeeDetail GetEmployeeById(int employeeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Employees
                    .Single(e => e.EmployeeId == employeeId && e.OwnerId == _userId);

                return new EmployeeDetail
                {
                    EmployeeId = entity.EmployeeId,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    Email = entity.Email,
                    Phone = entity.Phone,
                };
            }
        }

        public bool UpdateEmployee(EmployeeEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Employees
                    .Single(e => e.EmployeeId == model.EmployeeId && e.OwnerId == _userId);

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.Email = model.Email;
                entity.Phone = model.Phone;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteEmployee(int employeeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Employees
                    .Single(e => e.EmployeeId == employeeId && e.OwnerId == _userId);

                ctx.Employees.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
