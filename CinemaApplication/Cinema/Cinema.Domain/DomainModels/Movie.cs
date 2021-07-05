using Cinema.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.Domain.DomainModels
{
    public class Movie: BaseEntity
    {
        public Movie()
        {
            Tickets = new List<Ticket>();
        }
        public string Title { get; set; }
        public int Length { get; set; }
        public string Image { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
        public Genre Genre { get; set; }
    }
}
