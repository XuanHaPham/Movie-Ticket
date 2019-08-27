using MovieTicket.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.DTO
{
    public class BasketFilm
    {
        public Schedule schedule { get; set; }
        public int Number { get; set; }
    }
}
