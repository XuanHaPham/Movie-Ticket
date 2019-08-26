using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.DB
{
    public class DataProvider
    {
        private static DataProvider _ins;
        public static DataProvider ins
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new DataProvider();
                }
                return _ins;
            }
        }
        public MovieTicketDBContext DB { get; set; }
        private DataProvider()
        {
            DB = new MovieTicketDBContext();
        }
    }
}
