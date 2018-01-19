using System;

namespace EnCore.Movie.Core
{
    public class Session
    {
  
        public int SessionId { get; set; }
        public Guid? Token { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
