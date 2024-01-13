using System.Windows;
using System.Windows.Controls;

namespace Calcukator.View
{
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            string userName = UserNameTextBox.Text;
            string password = PasswordTextBox.Password;

            // Your authentication logic here
        }
    }
}
