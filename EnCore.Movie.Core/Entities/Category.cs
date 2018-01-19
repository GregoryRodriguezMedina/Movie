using System.Collections.Generic;

namespace EnCore.Movie.Core
{
    /*
        public class Address
        {
            public int AddressId { get; set; }
            public string LineOne { get; set; }
            public string LineTwo { get; set; }
            public string City { get; set; }
            public string Province { get; set; }
            public string ZipCode { get; set; }
        }
        */
    public class Category
    {
        public Category()
        {
           // this.Movies = new HashSet<Movie>();
        }

        public int CategoryId { get; set; }
        public string Description { get; set; }
       // public virtual ICollection<Movie> Movies { get; set; }
    }
}
