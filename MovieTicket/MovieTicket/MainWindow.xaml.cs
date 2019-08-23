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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public  partial class MainWindow : Window
    {
        public  MainWindow()
        {
            InitializeComponent();
            
            this.Loaded += MainWindow_Loaded;

        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            NavigationService = MainFrame.NavigationService;
        }
        public NavigationService NavigationService { get; set; }

        private static MainWindow _instance;
        public static MainWindow MainWindowInstance
        {
            get
            {
                if (_instance != null)
                    return _instance;
                _instance = new MainWindow();
                return _instance;
            }
        }
        private void ControlBarUC_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
