using EnCore.Core;
using EnCore.Movie.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

using System.Linq;

namespace EnCore.Movie.Data
{
    public partial interface IPhoneRepository : EnCore.Core.IEfRepositoryBase<int, Phone>
    {
        IEnumerable<Phone> GetByCustomer(int id);
    }

    public class PhoneRepository : EnCore.Core.EfRepositoryBase<int, Phone>, IPhoneRepository
    {
        public PhoneRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Phone> GetByCustomer(int id)
        {
            return from busq in this.Entity
                   where busq.CustomerId == id
                   select busq;
        }

        public override void Insert(Phone entity)
        {
            base.Insert(entity);

            this.SaveChanges();
        }
    }
}