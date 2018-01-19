using EnCore.Movie.Core;
using Microsoft.EntityFrameworkCore;

namespace EnCore.Movie.Data
{
    public partial interface IRentalDetailRepository : EnCore.Core.IEfRepositoryBase<int, RentalDetail>
    {
    }

    public class RentalDetailRepository : EnCore.Core.EfRepositoryBase<int, RentalDetail>, IRentalDetailRepository
    {
        public RentalDetailRepository(DbContext context) : base(context)
        {
        }
    }
}