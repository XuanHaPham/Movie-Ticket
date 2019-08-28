using MovieTicket.Utils;
using MovieTicket.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Utils
{
    public class GlobalData
    {
        private static GlobalData _instance;
        public static GlobalData Instance
        {
            get
            {
                if (_instance != null)
                    return _instance;
                _instance = new GlobalData();
                return _instance;
            }
        }

        private GlobalData()
        {
        }

        private List<ScheduleModel> _scheduleModels;
        public List<ScheduleModel> BasketFilms
        {
            get
            {
                if (_scheduleModels != null)
                    return _scheduleModels;
                _scheduleModels = new List<ScheduleModel>();
                return _scheduleModels;
            }
            set
            {
                _scheduleModels = value;
            }
        }
    }
}
