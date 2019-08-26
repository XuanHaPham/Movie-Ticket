using MovieTicket.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MovieTicket.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        #region
        public ICommand LoginIcommand { get; set; }
        public ICommand PasswordChangedCommand { get; set; }
        public ICommand CloseLoginIcommand { get; set; }
        private string _UserName;
        public string UserName { get => _UserName; set { _UserName = value; OnPropertyChanged(); } }
        private string _Password;
        public string Password { get => _Password; set { _Password = value; OnPropertyChanged(); } }
        #endregion
        public LoginViewModel()
        {
            InsertData();
            LoginIcommand = new RelayCommand<FrameworkElement>((p) => { return true; }, (p) => { CheckLogin(p); });
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { Password = p.Password; });
            CloseLoginIcommand = new RelayCommand<FrameworkElement>((p) => { return true; }, (p) => { CloseLoginWindow(p); });
        }

        private void CloseLoginWindow(FrameworkElement p)
        {
            while (p.Parent != null)
            {
                p = p.Parent as FrameworkElement;
            }
            Window w = p as Window;
            w.Close();
        }
        private void CheckLogin(FrameworkElement p)
        {
            
            if(string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password))
            {
                MessageBox.Show("Sai Tên đằng nhập hoặc mật khẩu!");
                return;
            }
            string passEncode = MD5Hash(Base64Encode(Password));
            var account = DataProvider.ins.DB.Users.AsEnumerable().Where(u => u.UserName == UserName && u.Password == passEncode).Count();
            if (account > 0)
            {
                while (p.Parent != null)
                {
                    p = p.Parent as FrameworkElement;
                }
                MainWindow mw = new MainWindow();
                HomePageViewModel context = new HomePageViewModel();
                mw.DataContext = context;
                mw.Show();
                Window w = p as Window;
                w.Close();
            }
            else
            {
                MessageBox.Show("Sai Tên đằng nhập hoặc mật khẩu!");
            }
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }

        private void InsertData()
        {
            for(int i =0; i <=10; i++)
            {
                Film f = new Film() { Active = true, Deleted = false,
                    Description = "Movie" + i, Id = Guid.NewGuid(), Image= "220px-Nagraj_(film_poster).jpg"};
                DataProvider.ins.DB.Films.Add(f);
                for(int j = 0; j <= 4; j++)
                {
                    Schedule s = new Schedule() { Id = Guid.NewGuid(), Active= true, Stock= 120,Deleted= false,
                        Film = f, MovieDate= "26/8/2019",MovieTime= (6+j)+"h - " + (8+j)+"h", Status= true, FilmID = f.Id.ToString()};
                    DataProvider.ins.DB.Schedules.Add(s);
                }
            }
            DataProvider.ins.DB.SaveChanges();

        }
    }
}
