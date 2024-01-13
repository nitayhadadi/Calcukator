using Calcukator.Commands;
using Calcukator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Calcukator.ViewModels
{
    internal class LoginVM  : ViewModelBase

    {
        private User user;
        private string userName;
        public ICommand LoginCommand { get; }
        public LoginVM()
        {
            user = new User();
            LoginCommand = new RelayCommand((param) => LoggedIn(param));

        }

       

        public string UserName
        {
            get =>user.UserName;
            set
            {
                user.UserName = value;
                OnPropertyChanged(nameof(UserName));

            }
        }
        public string Password
        {
            get =>user.Password;
            set
            {
                user.Password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        private void LoggedIn(object param)
        {
            MessageBox.Show($"Logged in SuccessFull as{param}");
        }

    }
}
