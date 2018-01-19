using System.Collections.Generic;

namespace EnCore.Movie.Core
{
    public class Movie
    {
        public Movie()
        {
            //Category = new Category();
            this.RentalDetails = new HashSet<RentalDetail>();
        }
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Synopsis { get; set; }
        public decimal Duration { get; set; }
        public int QuantityAvailable { get; set; }
        public int QuantityRented { get; set; }
        public decimal RentalPrice {get; set;}
       // public int CategoryId { get; set; }
      //  public virtual Category Category { get; set; }
        public virtual ICollection<RentalDetail> RentalDetails { get; set; }
    }
}
