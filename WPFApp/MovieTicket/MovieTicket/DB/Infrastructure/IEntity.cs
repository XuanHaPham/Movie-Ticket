using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.DB.Infrastructure
{
    public interface IBaseEntity
    {
        bool Deleted { get; set; }
        bool Active { get; set; }
    }

    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
