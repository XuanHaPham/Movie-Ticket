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
        public ICommand BasketCommand { get; set; }
        public ICommand FoodCommand { get; set; }
        public ICommand UserCommand { get; set; }

        #endregion
        public HomePageViewModel()
        {
            FilmCommand = new RelayCommand<FrameworkElement>((p) => { return true; }, (p) => { MainWindow.MainWindowInstance.NavigationService.Navigate(new FilmPage()); });
            BasketCommand = new RelayCommand<FrameworkElement>((p) => { return true; }, (p) => { MainWindow.MainWindowInstance.NavigationService.Navigate(new BasketPage()); });
            FoodCommand = new RelayCommand<FrameworkElement>((p) => { return true; }, (p) => { MainWindow.MainWindowInstance.NavigationService.Navigate(new FoodPage()); });
            UserCommand = new RelayCommand<FrameworkElement>((p) => { return true; }, (p) => { MainWindow.MainWindowInstance.NavigationService.Navigate(new UserPage()); });
        }

    }
}
