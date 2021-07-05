using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cinema.Domain.DomainModels
{

    public class BaseEntity
    {
        //todo: every class in Domain must be public 
        [Key]
        public Guid Id { get; set; }
    }
}
