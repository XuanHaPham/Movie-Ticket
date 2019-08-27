using MovieTicket.DB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MovieTicket.ViewModel
{
    public class ScheduleViewModel : BaseViewModel
    {
        #region command
        public ICommand PlusCommand { get; set; }
        public ICommand MinusCommand { get; set; }

        #endregion
        private ObservableCollection<Schedule> _ListSchedule;

        public ObservableCollection<Schedule> ListSchedule { get => _ListSchedule; set { _ListSchedule = value; OnPropertyChanged(); } }
        private string _TicketCounter;
        public string TicketCounter { get => _TicketCounter; set { _TicketCounter = value; OnPropertyChanged(); } }

        private Schedule _SelectedItem;

        public Schedule SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
            }
        }
        private Film _film;
        public Film film { get => _film; set { _film = value; OnPropertyChanged(); } }
        public ScheduleViewModel(Film f)
        {
            film = f;
            ListSchedule = new ObservableCollection<Schedule>(DataProvider.ins.DB.Schedules.AsEnumerable().Where(p=> p.FilmID == film.Id.ToString()));
            
        }

        private void addNewProduct(FrameworkElement s)
        {
           
        }


    }
}
