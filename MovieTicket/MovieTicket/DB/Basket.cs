namespace MovieTicket.DB
{
    using MovieTicket.DB.Infrastructure;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class Basket : Entity<Guid>
    {
        public int? UserID { get; set; }

        public string TimeCreated { get; set; }

        public bool? Status { get; set; }

        public virtual User User { get; set; }
    }
}
