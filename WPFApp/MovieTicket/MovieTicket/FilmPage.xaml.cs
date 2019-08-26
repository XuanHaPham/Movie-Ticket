using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MovieTicket
{
    /// <summary>
    /// Interaction logic for FilmPage.xaml
    /// </summary>
    public partial class FilmPage : Page
    {
        public FilmPage()
        {
            InitializeComponent();
            this.TvBox.ItemsSource = new MovieData[]
        {
            new MovieData{Title="Movie 1"},
            new MovieData{Title="Movie 2"},
            new MovieData{Title="Movie 3"},
            new MovieData{Title="Movie 4"},
            new MovieData{Title="Movie 5"},
            new MovieData{Title="Movie 6"}
        };
        }
        private BitmapImage LoadImage(string filename)
        {
            return new BitmapImage(new Uri(".\\Image" + filename));
        }
    }
    public class MovieData
    {
        private string _Title;
        public string Title
        {
            get { return this._Title; }
            set { this._Title = value; }
        }


    }
}
