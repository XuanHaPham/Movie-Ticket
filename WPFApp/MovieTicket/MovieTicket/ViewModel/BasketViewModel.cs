using MovieTicket.DB;
using MovieTicket.Models;
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
using System.Windows.Forms;
using System.Windows.Input;

namespace MovieTicket.ViewModel
{
    public class BasketViewModel: BaseViewModel
    {
        #region command
        public ICommand PlusCommand { get; set; }
        public ICommand MinusCommand { get; set; }
        public ICommand BuyCommand { get; set; }
        public ICommand ClearCommand { get; set; }
        #endregion
        private ObservableCollection<ScheduleModel> _basketFilms;

        public ObservableCollection<ScheduleModel> BasketFilms
        {
            get => _basketFilms;
            set
            {
                _basketFilms = value; OnPropertyChanged("BasketFilm");
            }
        }


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

        private float _total;
        public float Total { get => _total;
            set
            {
                _total = value;
                OnPropertyChanged();

            }
        }
        private CollectionViewSource _basketCollection;
        public ICollectionView SourceCollection
        {
            get
            {
                return _basketCollection.View;
            }
        }

        public BasketViewModel()
        {
            var baskets = GlobalData.Instance.BasketFilms;
            BasketFilms = new ObservableCollection<ScheduleModel>(baskets);
            _basketCollection = new CollectionViewSource() { Source = BasketFilms };
            PlusCommand = new RelayCommand<object>((p) => { return true; }, (p) => { addSticket(p); });
            MinusCommand = new RelayCommand<object>((p) => { return true; }, (p) => { minusSticket(p); });
            BuyCommand = new RelayCommand<object>((p) => { return true; }, (p) => { BuyBasket(); });
            ClearCommand = new RelayCommand<object>((p) => { return true; }, (p) => { ClearBasket(); });
            _total = BasketFilms.Sum(item => item.Stock) * 5;
        }
        private void addSticket(object obj)
        {
            var currentId = Guid.Parse(obj.ToString());
            ScheduleModel currentSchedule = BasketFilms.FirstOrDefault(p => p.Id == currentId);
            int currentStock = DataProvider.ins.DB.Schedules.AsEnumerable().Where(p => p.Id == currentId).FirstOrDefault().Stock;
            if (currentSchedule != null && currentSchedule.Stock < currentStock)
            {
                currentSchedule.Stock++;
                Total = BasketFilms.Sum(item => item.Stock) * 5;
            }

        }
        private void minusSticket(object obj)
        {
            var currentId = Guid.Parse(obj.ToString());
            ScheduleModel currentSchedule = BasketFilms.FirstOrDefault(p => p.Id == currentId);
            int currentStock = DataProvider.ins.DB.Schedules.AsEnumerable().FirstOrDefault(p => p.Id == currentId).Stock;
            if (currentSchedule != null && currentSchedule.Stock > 0)
            {
                currentSchedule.Stock--;
                Total = BasketFilms.Sum(item => item.Stock) * 5;
            }
        }

        private void BuyBasket()
        {
            MessageBoxResult result = System.Windows.MessageBox.Show("Are you sure ?", "Buy basket", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    foreach (var item in BasketFilms)
                    {
                        if(DataProvider.ins.DB.Schedules.AsEnumerable().FirstOrDefault(p => p.Id == item.Id) != null)
                        DataProvider.ins.DB.Schedules.AsEnumerable().FirstOrDefault(p => p.Id == item.Id).Stock -= item.Stock;
                    }
                    DataProvider.ins.DB.SaveChanges();
                    BasketFilms.Clear();
                    GlobalData.Instance.BasketFilms.Clear();
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }
        private void ClearBasket()
        {
            MessageBoxResult result = System.Windows.MessageBox.Show("Are you sure ?", "Buy basket", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    BasketFilms.Clear();
                    GlobalData.Instance.BasketFilms.Clear();
                    Total = 0;
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }
    }
}
