using EnCore.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnCore.Movie.Core
{
    public class RentalResponse
    {
        public RentalResponse()
        {
            Customer = new CustomerResponse();
            Movies = new HashSet<KeyNamePair>();
        }
        public int Id { get; set; }
        public CustomerResponse Customer { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public decimal Total { get; set; }
        public Int16 StatusId { get; set; }
        public string Status { get; set; }
        public decimal? Penalty { get; set; }
        public IEnumerable<KeyNamePair> Movies { get; set; }
    }
}
