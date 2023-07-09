using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
using DatabaseManager2.AnalogInputReference;

namespace DatabaseManager2.TagManagment
{
	/// <summary>
	/// Interaction logic for InputTagsPage.xaml
	/// </summary>
	public partial class InputTagsPage : Page
	{
		public static AnalogInputServiceClient analogClient = new AnalogInputServiceClient();

		public static List<AnalogInput> IanalogInputs;
		private ObservableCollection<AnalogInput> analogInputs = new ObservableCollection<AnalogInput>();
		private string tagName = "tagName";
		private string description = "Description";
		private string iOAddress = "IOAddress";
		private string units = "Units";
		private string scanTime = "Scan time";
		private string low = "Low";
		private string high = "High";


		public InputTagsPage()
		{
			DataContext = this;
			InitializeComponent();
			IanalogInputs = analogClient.GetAll().ToList();
			foreach (AnalogInput analogInput in IanalogInputs) {
				AnalogInputs.Add(analogInput);
			}
		}

		public ObservableCollection<AnalogInput> AnalogInputs { get => analogInputs; set => analogInputs = value; }
		public string TagName { get => tagName; set => tagName = value; }
		public string Description { get => description; set => description = value; }
		public string IOAddress { get => iOAddress; set => iOAddress = value; }
		public string Units { get => units; set => units = value; }
		public string ScanTime { get => scanTime; set => scanTime = value; }
		public string Low { get => low; set => low = value; }
		public string High { get => high; set => high = value; }

		private void AddBtn_Click(object sender, RoutedEventArgs e)
		{

		}

		private void DeleteBtn_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				AnalogInput analogInput = (AnalogInput)analogInputDataGrid.SelectedItem;
				if (MessageBox.Show("Delete tag " + analogInput.TagName + "?", "Delete", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.Cancel)
				{
					return;
				}
				analogClient.Delete(analogInput.TagName);
				AnalogInputs.Remove(analogInput);
			}
			catch { }
		}

		private void ChangeScanningBtn_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				AnalogInput analogInput = (AnalogInput)analogInputDataGrid.SelectedItem;
				if (MessageBox.Show("Change scanning tag " + analogInput.TagName + "to " + !analogInput.IsScanning + "?", "Delete", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.Cancel)
				{
					return;
				}
				analogClient.Edit(analogInput.TagName, !analogInput.IsScanning);
				AnalogInputs.Remove(analogInput);
				analogInput.IsScanning = !analogInput.IsScanning;
				AnalogInputs.Add(analogInput);
			}
			catch { }
		}
	}
}
