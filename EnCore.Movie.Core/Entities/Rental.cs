using System;
using System.Collections.Generic;

namespace EnCore.Movie.Core
{
    public class Rental
    {
        public Rental()
        {
            this.RentalDetails = new HashSet<RentalDetail>();
        }

        public int RentalId { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public decimal Total { get; set; }
        public Int16 Status { get; set; }
        public DateTime CreatedOn { get; set; }

        public DateTime? Returned { get; set; }
        public virtual ICollection<RentalDetail> RentalDetails { get; set; }
        public decimal? Penalty { get; set; }
    }
}
