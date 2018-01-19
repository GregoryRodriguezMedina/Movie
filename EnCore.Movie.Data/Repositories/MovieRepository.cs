using EnCore.Movie.Core;
using Microsoft.EntityFrameworkCore;

using System.Linq;

namespace EnCore.Movie.Data
{
     
     public partial interface IMovieRepository : EnCore.Core.IEfRepositoryBase<Core.Movie>
    {
        decimal GetRentalPrice(int id);
    }

    public class MovieRepository : EnCore.Core.EfRepositoryBase<Core.Movie>, IMovieRepository
    {
        public MovieRepository(DbContext context) : base(context)
        {
        }

        public decimal GetRentalPrice(int id)
        {
            var result= from busq in this.Entity
                        where busq.MovieId == id
                        select  busq.RentalPrice;

            return result.FirstOrDefault();
        }
        /*
        public override void Insert(Core.Movie entity)
        {
            base.Insert(entity);

            base.SaveChanges();
        }

        public override void Update(Core.Movie entity)
        {
            base.Update(entity);

          //  base.SaveChanges();
        }

        public override void Delete(Core.Movie entity)
        {
            base.Delete(entity);

            base.SaveChanges();
        }
        */
    }
}
