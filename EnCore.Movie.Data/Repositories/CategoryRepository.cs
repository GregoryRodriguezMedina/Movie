using EnCore.Core;
using EnCore.Movie.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

using System.Linq;

namespace EnCore.Movie.Data
{
    public partial interface ICategoryRepository : EnCore.Core.IEfRepositoryBase<int, Category>
    {
        new IEnumerable<KeyNamePair> Get();
    }

    public class CategoryRepository : EnCore.Core.EfRepositoryBase<int, Category>, ICategoryRepository
    {
        public CategoryRepository(DbContext context) : base(context)
        {
        }

        public new IEnumerable<KeyNamePair> Get()
        {
            return from busq in this.Entity
                   select new KeyNamePair
                   {
                       Key = busq.CategoryId,
                       Name = busq.Description
                   };
        }

        public override void Insert(Category entity)
        {
            base.Insert(entity);

            this.SaveChanges();
        }
    }
}