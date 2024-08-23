using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Frontend.Pages
{

    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void textEmail_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtUserName.Focus();
        }

        private void txtUserName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUserName.Text) && txtUserName.Text.Length>0)
            {
                textEmail.Visibility = Visibility.Collapsed;
            }
            else
            {
                textEmail.Visibility = Visibility.Visible;
            }

        }
    }
}
