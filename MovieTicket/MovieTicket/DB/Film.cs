namespace MovieTicket.DB
{
    using MovieTicket.DB.Infrastructure;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class Film : Entity<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public string TimeCreate { get; set; }

        public bool? Status { get; set; }

        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
