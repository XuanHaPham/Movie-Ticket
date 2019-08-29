﻿using MovieTicket.ViewModel;
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
    /// Interaction logic for InputProductPage.xaml
    /// </summary>
    public partial class InputProductPage : Page
    {
        public InputProductPage()
        {
            InitializeComponent();
            var vm = new InputPageViewModel();
            this.DataContext = vm;
        }
    }
}