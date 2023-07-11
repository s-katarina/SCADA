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
using System.Windows.Shapes;

namespace DatabaseManager2.UsersManagment
{
	/// <summary>
	/// Interaction logic for LoginWindow.xaml
	/// </summary>
	public partial class LoginWindow : Window
	{
        UserReference.UserServiceClient userClient = new UserReference.UserServiceClient();
		public LoginWindow()
		{
			InitializeComponent();
		}

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            if (userClient.Login(username, password))
            {
                MainWindow trending = new MainWindow();
                trending.Show();
            }
            else
            {
                message.Text = "Wrong credentials.";
            }
        }
    }
}
