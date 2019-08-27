using MovieTicket.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.ViewModel
{
    public class MainViewModel: BaseViewModel
    {
        private ObservableCollection<BasketFilm> _basketFilms;

        public ObservableCollection<BasketFilm> basketFilms { get => _basketFilms; set { _basketFilms = value; OnPropertyChanged(); } }

        public MainViewModel()
        {
            if(basketFilms == null)
            {
                basketFilms = new ObservableCollection<BasketFilm>();
            }
        }
    }
}
