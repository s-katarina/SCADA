using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using DatabaseManager2.UserReference;

namespace DatabaseManager2.UsersManagment
{
	/// <summary>
	/// Interaction logic for RegistrationPage.xaml
	/// </summary>
	public partial class RegistrationPage : Page
	{
		private string name;
		private string surname;
		private string password;
		private string username;
		public UserServiceClient UserServiceClient = new UserServiceClient();
		public RegistrationPage()
		{
			InitializeComponent();
			DataContext = this;
		}

		public string Namee { get => name; set => name = value; }
		public string Surname { get => surname; set => surname = value; }
		public string Password { get => password; set => password = value; }
		public string Username { get => username; set => username = value; }
		private bool CorrectStringValue(string fieldName, string value)
		{
			if (value != null && value.Length >= 1) return true;
			MessageBox.Show("Field " + fieldName + " must be filled");
			return false;
		}
		private void RegisteBtn_Click(object sender, RoutedEventArgs e)
		{
			if (!CorrectStringValue("Name", Namee)) return; 
			if (!CorrectStringValue("Surname", Surname)) return;
			if (!CorrectStringValue("Password", Password)) return;
			if (!CorrectStringValue("Username", Username)) return;
			User user = new User() { Name = Namee, Surname = Surname, Username = Username, Password = Password };
			UserServiceClient.Add(user);
			MessageBox.Show("Saved user");
		}
	}
}
