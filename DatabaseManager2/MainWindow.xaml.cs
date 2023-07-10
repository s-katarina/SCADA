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
using DatabaseManager2.TagManagment;
using DatabaseManager2.UsersManagment;

namespace DatabaseManager2
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void tagBtn_Click(object sender, RoutedEventArgs e)
		{
			MainFrame.Content = new AnalogTagsPage();
		}

		private void digitalBtn_Click(object sender, RoutedEventArgs e)
		{
			MainFrame.Content = new DigitalTagsPage();
		}

		private void registerBtn_Click(object sender, RoutedEventArgs e)
		{
			MainFrame.Content = new RegistrationPage();
		}

		private void LogoutBtn_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}
