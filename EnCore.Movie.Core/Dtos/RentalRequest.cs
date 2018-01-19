using System;
using System.Collections.Generic;

namespace EnCore.Movie.Core
{
    public class RentalRequest
    {        
        public int CustomerId { get; set; }
       // public DateTime DateFrom { get; set; }
        public string DateTo { get; set; }
        public IEnumerable<int> Movies { get; set; }
    }
}
