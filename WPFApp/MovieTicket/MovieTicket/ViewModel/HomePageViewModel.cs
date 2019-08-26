using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace MovieTicket.ViewModel
{
    public class HomePageViewModel : BaseViewModel
    {
        #region
        public ICommand FilmCommand { get; set; }
        #endregion
        public HomePageViewModel()
        {
            FilmCommand = new RelayCommand<FrameworkElement>((p) => { return true; }, (p) => { NavigateToFilmPage(); });
        }

        private void NavigateToFilmPage()
        {
            FilmPage secPage = new FilmPage();
            MainWindow.MainWindowInstance.NavigationService.Navigate(secPage);
        }
    }
}
