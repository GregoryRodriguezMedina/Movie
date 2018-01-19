namespace EnCore.Movie.Core
{
    public class RentalDetail
    {
        public int RentalDetailId { get; set; }
        public int RentalId { get; set; }
        public Rental Rental { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        //public DateTime? DateFrom { get; set; }
        //public DateTime? DateTo { get; set; }       
    }
}
