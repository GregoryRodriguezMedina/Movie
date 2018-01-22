using System;

namespace EnCore.Movie.Core
{
   // [System.ComponentModel.DataAnnotations.Schema.Table("Sessions")]
    public class Session
    {
  
        public int SessionId { get; set; }
        public Guid? Token { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public string Machine { get; set; }
    }
}
