using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.DB.Infrastructure
{
    public abstract class BaseEntity
    {
        [DefaultValue(false)] public bool Deleted { get; set; }

        [DefaultValue(true)] public bool Active { get; set; }
    }

    public abstract class Entity<T> : BaseEntity, IEntity<T>
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual T Id { get; set; }
    }
}
