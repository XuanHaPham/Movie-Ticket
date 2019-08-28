using MovieTicket.Models;
using MovieTicket.DB;
using MovieTicket.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace MovieTicket.ViewModel
{
    public class ScheduleViewModel : BaseViewModel
    {
        #region command
        public ICommand PlusCommand { get; set; }
        public ICommand MinusCommand { get; set; }

        #endregion
        private ObservableCollection<ScheduleModel> _ListSchedule;

        public ObservableCollection<ScheduleModel> ListSchedule {
            get => _ListSchedule;
            set
            {
                _ListSchedule = value; OnPropertyChanged("ListSchedule");
            }
        }

        private string _TicketCounter;
        public string TicketCounter { get => _TicketCounter; set { _TicketCounter = value; OnPropertyChanged(); } }

        private ScheduleModel _SelectedItem;

        public ScheduleModel SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }
        private Film _film;
        public Film film { get => _film; set { _film = value; OnPropertyChanged(); } }

        private CollectionViewSource _filmCollection;
        public ICollectionView SourceCollection
        {
            get
            {
                return _filmCollection.View;
            }
        }

        public ScheduleViewModel(Film f)
        {
            film = f;
            var schedules = DataProvider.ins.DB.Schedules.AsEnumerable().Where(p => p.FilmID == film.Id.ToString());
            ListSchedule = new ObservableCollection<ScheduleModel>();
            foreach(var schedule in schedules)
            {
                ListSchedule.Add(new ScheduleModel()
                {
                    Id = schedule.Id,
                    FilmID = schedule.FilmID,
                    MovieDate = schedule.MovieDate,
                    MovieTime = schedule.MovieTime,
                    Status = schedule.Status,
                    Stock = schedule.Stock,
                    Film = schedule.Film
                });
            }

            _filmCollection = new CollectionViewSource() { Source = ListSchedule };
            foreach (var item in ListSchedule)
            {
                if (GlobalData.Instance.BasketFilms.FirstOrDefault(p => p.Id == item.Id) != null)
                    item.Stock = GlobalData.Instance.BasketFilms.FirstOrDefault(p => p.Id == item.Id).Stock;
                else
                    item.Stock = 0;
            }
            PlusCommand = new RelayCommand<object>((p) => { return true; }, (p) => { addSticket(p); });
            MinusCommand = new RelayCommand<object>((p) => { return true; }, (p) => { minusSticket(p); });
        }

        private void addSticket(object obj)
        {
            var currentId = Guid.Parse(obj.ToString());
            ScheduleModel currentSchedule = ListSchedule.FirstOrDefault(p => p.Id == currentId);
            int currentStock = DataProvider.ins.DB.Schedules.AsEnumerable().Where(p => p.Id == currentId).FirstOrDefault().Stock;
            if (currentSchedule != null && currentSchedule.Stock < currentStock)
            {
                if(GlobalData.Instance.BasketFilms.FirstOrDefault(p=>p.Id == currentSchedule.Id) == null)
                {
                    ScheduleModel tmp = new ScheduleModel()
                    {
                        Id = currentSchedule.Id,
                        FilmID = currentSchedule.FilmID,
                        MovieDate = currentSchedule.MovieDate,
                        MovieTime = currentSchedule.MovieTime,
                        Status = currentSchedule.Status,
                        Stock = currentSchedule.Stock,
                        Film = currentSchedule.Film
                    };
                    GlobalData.Instance.BasketFilms.Add(tmp);

                    currentSchedule.Stock++;
                }
                else
                {
                    GlobalData.Instance.BasketFilms.FirstOrDefault(p => p.Id == currentSchedule.Id).Stock++;
                    currentSchedule.Stock++;
                }
            }

        }
        private void minusSticket(object obj)
        {
            var currentId = Guid.Parse(obj.ToString());
            ScheduleModel currentSchedule = ListSchedule.FirstOrDefault(p => p.Id == currentId);
            int currentStock = DataProvider.ins.DB.Schedules.AsEnumerable().FirstOrDefault(p => p.Id == currentId).Stock;
            if (currentSchedule != null && currentSchedule.Stock > 0 )
            {
                if(GlobalData.Instance.BasketFilms.FirstOrDefault(p => p.Id == currentSchedule.Id).Stock >0)
                GlobalData.Instance.BasketFilms.FirstOrDefault(p => p.Id == currentSchedule.Id).Stock--;
                currentSchedule.Stock--;
            }
        }

    }
}
