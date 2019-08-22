namespace MovieTicket.DB
{
    using MovieTicket.DB.Infrastructure;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class Schedule : Entity<Guid>
    {
        public int? FilmID { get; set; }

        public string MovieDate { get; set; }

        public string MovieTime { get; set; }

        public int? Stock { get; set; }

        public bool? Status { get; set; }

        public virtual Film Film { get; set; }
    }
}
