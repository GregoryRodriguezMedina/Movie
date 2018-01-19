namespace EnCore.Movie.Core
{
    public class Phone
    {
        public int PhoneId { get; set; }
        public int PhoneTypeId { get; set; }
        public int CustomerId { get; set; }
        public string Number { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
