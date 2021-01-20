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
    public class CooperatorService
    {
        private readonly Guid _userId;

        public CooperatorService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCooperator(CooperatorCreate model)
        {
            var entity = new Cooperator()
            {
                OwnerId = _userId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Phone = model.Phone,
                StreetAddressOne = model.StreetAddressOne,
                StreetAddressTwo = model.StreetAddressTwo,
                City = model.City,
                State = model.State,
                ZipCode = model.ZipCode,
                ContactType = ContactType.Cooperator
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Cooperators.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CooperatorListItem> GetCooperators()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Cooperators
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                            new CooperatorListItem
                            {
                                CooperatorId = e.CooperatorId,
                                FirstName = e.FirstName,
                                LastName = e.LastName,
                                Email = e.Email,
                                Phone = e.Phone,
                                ContactType = e.ContactType,
                                StreetAddressOne = e.StreetAddressOne,
                                StreetAddressTwo = e.StreetAddressTwo,
                                City = e.City,
                                State = e.State,
                                ZipCode = e.ZipCode
                            }
                     );

                return query.ToArray();
            }
        }

        public CooperatorDetail GetCooperatorById(int cooperatorId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Cooperators
                    .Single(e => e.CooperatorId == cooperatorId && e.OwnerId == _userId);

                return new CooperatorDetail
                {
                    CooperatorId = entity.CooperatorId,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    Email = entity.Email,
                    Phone = entity.Phone,
                    StreetAddressOne = entity.StreetAddressOne,
                    StreetAddressTwo = entity.StreetAddressTwo,
                    City = entity.City,
                    State = entity.State,
                    ZipCode = entity.ZipCode
                };
            }
        }

        public bool UpdateCooperator(CooperatorEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Cooperators
                    .Single(e => e.CooperatorId == model.CooperatorId && e.OwnerId == _userId);

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.Email = model.Email;
                entity.Phone = model.Phone;
                entity.StreetAddressOne = model.StreetAddressOne;
                entity.StreetAddressTwo = model.StreetAddressTwo;
                entity.City = model.City;
                entity.State = model.State;
                entity.ZipCode = model.ZipCode;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCooperator(int cooperatorId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Cooperators
                    .Single(e => e.CooperatorId == cooperatorId && e.OwnerId == _userId);

                ctx.Cooperators.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
