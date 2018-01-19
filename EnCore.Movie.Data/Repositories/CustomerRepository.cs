using EnCore.Movie.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EnCore.Movie.Data
{
    public partial interface ICustomerRepository : EnCore.Core.IEfRepositoryBase<int, Customer>
    {
        bool Exists(int id);
    }

    public class CustomerRepository : EnCore.Core.EfRepositoryBase<int, Customer>, ICustomerRepository
    {
        public CustomerRepository(DbContext context) : base(context)
        {
        }

        public override void Insert(Customer entity)
        {
            base.Insert(entity);

            this.SaveChanges();
        }

        public override void Update(Customer entity)
        {
            base.Update(entity);
            //Quitar el autosave
            base.SaveChanges();
        }

        public override void Delete(Customer entity)
        {
            base.Delete(entity);

            base.SaveChanges();
        }

        public bool Exists(int id)
        {
            return this.Entity.Any(a => a.CustomerId == id);
        }
    }
}