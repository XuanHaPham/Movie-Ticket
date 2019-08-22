namespace MovieTicket.DB
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using SQLite.CodeFirst;

    public class MovieTicketDBContext : DbContext
    {
      
        public virtual DbSet<Basket> Baskets { get; set; }
        public virtual DbSet<Film> Films { get; set; }
        public virtual DbSet<Food> Foods { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<MovieTicketDBContext>(modelBuilder);
            Database.SetInitializer(sqliteConnectionInitializer);
        }
    }
}
