namespace MovieTicket.DB
{
    using MovieTicket.DB.Infrastructure;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class User : Entity<Guid>
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string RoleName { get; set; }

        public string TimeCreate { get; set; }

        public bool? Status { get; set; }

        public virtual ICollection<Basket> Baskets { get; set; }
    }
}
