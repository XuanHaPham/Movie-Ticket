using MovieTicket.Annotations;
using MovieTicket.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Models
{
    public class ScheduleModel : INotifyPropertyChanged
    {
        private Guid _id;
        public Guid Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        private string _filmID;
        public string FilmID
        {
            get { return _filmID; }
            set
            {
                _filmID = value;
                OnPropertyChanged("FilmID");
            }
        }

        private string _movieDate;
        public string MovieDate
        {
            get { return _movieDate; }
            set
            {
                _movieDate = value;
                OnPropertyChanged("MovieDate");
            }
        }

        private string _movieTime;
        public string MovieTime
        {
            get { return _movieTime; }
            set
            {
                _movieTime = value;
                OnPropertyChanged("MovieTime");
            }
        }

        private int _stock;
        public int Stock
        {
            get { return _stock; }
            set
            {
                _stock = value;
                OnPropertyChanged("Stock");
            }
        }

        private bool? _status;
        public bool? Status
        {
            get { return _status; }
            set
            {
                _status = value;
                OnPropertyChanged("Status");
            }
        }

        private Film _film;
        public Film Film { get => _film; set { _film = value; OnPropertyChanged(); } }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}