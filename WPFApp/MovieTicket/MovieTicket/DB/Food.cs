namespace MovieTicket.DB
{
    using MovieTicket.DB.Infrastructure;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class Food : Entity<Guid>
    {
        public string Name { get; set; }
        public string Image { get; set; }

        public double? Price { get; set; }

        public string Status { get; set; }
    }
}
