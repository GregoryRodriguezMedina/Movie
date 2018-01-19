using System.Collections.Generic;

namespace EnCore.Movie.Core
{
    public class Customer
    {

        public Customer()
        {
          //  this.Phones = new HashSet<Phone>();
            this.Rentals = new HashSet<Rental>();
        }

        public int CustomerId {get; set;}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string Address { get; set; }
        public string MobilPhone { get; set; }
        public string HomePhone { get; set; }

        public string Email { get; set; }
        //   public string AddressRef { get; set; }
        //  public string City { get; set; }
        //public string Province { get; set; }
        //  public string ZipCode { get; set; }
        /*Inclui los datos de la direcion dentro del cliente 
         * para poder trabjar mas rapido la app, lo ideal es tener
         * la clase aparte y poder crear varias direciones para un cliente*/
        // public virtual ICollection<Phone> Phones { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
