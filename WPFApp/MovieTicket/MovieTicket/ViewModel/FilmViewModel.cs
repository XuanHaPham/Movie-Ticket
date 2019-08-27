using MovieTicket.DB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.ViewModel
{
    public class FilmViewModel : BaseViewModel
    {
        private ObservableCollection<Film> _List;

        public ObservableCollection<Film> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private Film _SelectedItem;
        public Film SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if(SelectedItem != null)
                {
                    MainWindow.MainWindowInstance.NavigationService.Navigate(new SchedulePage(value));
                }
            }
        }
        public FilmViewModel()
        {
            List = new ObservableCollection<Film>(DataProvider.ins.DB.Films);

        }
    }
}
