using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using DatabaseManager2.DigitalInputReference;
using DatabaseManager2.DigitalOutputReference;

namespace DatabaseManager2.TagManagment
{
	/// <summary>
	/// Interaction logic for DigitalTagsPage.xaml
	/// </summary>
	public partial class DigitalTagsPage : Page
	{
		public static DigitalInputServiceClient analogClient = new DigitalInputServiceClient();
		public static DigitalOutputServiceClient analogOutputClient = new DigitalOutputServiceClient();

		public static List<DigitalInput> IanalogInputs;
		public static List<DigitalOutput> IanalogOutputs;
		private ObservableCollection<DigitalInput> analogInputs = new ObservableCollection<DigitalInput>();
		private ObservableCollection<DigitalOutput> analogOutputs = new ObservableCollection<DigitalOutput>();
		private string tagName = "tagName";
		private string description = "Description";
		private string iOAddress = "IOAddress";
		private string scanTime = "Scan time";

		private string outpuTtagName = "tagName2";
		private string outputIOAddress = "IOAddress2";
		private string outputInitial = "Initial val2";
		private string outputDes = "Description2";
		public DigitalTagsPage()
		{
			DataContext = this;
			InitializeComponent();
			IanalogInputs = analogClient.GetAll().ToList();
			foreach (DigitalInput analogInput in IanalogInputs)
			{
				AnalogInputs.Add(analogInput);
			}

			IanalogOutputs = analogOutputClient.GetAll().ToList();
			foreach (DigitalOutput analogInput in IanalogOutputs)
			{
				AnalogOutputs.Add(analogInput);
			}
		}

		public ObservableCollection<DigitalInput> AnalogInputs { get => analogInputs; set => analogInputs = value; }
		public ObservableCollection<DigitalOutput> AnalogOutputs { get => analogOutputs; set => analogOutputs = value; }
		public string TagName { get => tagName; set => tagName = value; }
		public string Description { get => description; set => description = value; }
		public string IOAddress { get => iOAddress; set => iOAddress = value; }
		public string OutpuTtagName { get => outpuTtagName; set => outpuTtagName = value; }
		public string ScanTime { get => scanTime; set => scanTime = value; }
		public string OutputIOAddress { get => outputIOAddress; set => outputIOAddress = value; }
		public string OutputInitial { get => outputInitial; set => outputInitial = value; }
		public string OutputDes { get => outputDes; set => outputDes = value; }

		private bool CorrectStringValue(string fieldName, string value)
		{
			if (value.Length >= 1) return true;
			MessageBox.Show("Field " + fieldName + " must be filled");
			return false;
		}

		private bool CorrectNumberValue(string fieldName, string value)
		{
			if (int.TryParse(value, out int intValue)) return true;
			MessageBox.Show("Field " + fieldName + " must be a number");
			return false;
		}

		private void AddBtn_Click(object sender, RoutedEventArgs e)
		{
			if (!CorrectStringValue("Tag name", tagName)) return;
			if (!CorrectStringValue("Description", description)) return;
			if (!CorrectStringValue("IOaddress", IOAddress)) return;
			if (!CorrectNumberValue("Scan Time", scanTime)) return;
			if (!UniqueInputTagName(tagName)) return;

			Enum.TryParse(ComboBox1.SelectedItem.ToString(), out DigitalInputReference.DriverType driverTypee);
			int st = int.Parse(scanTime);
			DigitalInput analogInput = new DigitalInput()
			{
				TagName = tagName,
				Description = description,
				Driver = driverTypee,
				IOAddress = iOAddress,
				IsScanning = (bool)McCheckBox.IsChecked,
				ScanTime = st,
			};
			analogClient.Add(analogInput);
			AnalogInputs.Add(analogInput);

		}

		private bool UniqueInputTagName(string tagName)
		{
			foreach (DigitalInput analogInput in AnalogInputs)
			{
				if (analogInput.TagName.Equals(tagName))
				{
					MessageBox.Show("Tag with his name exists already");
					return false;
				}
			}
			return true;
		}

		private bool UniqueOutputTagName(string tagName)
		{
			foreach (DigitalOutput analogOutput in AnalogOutputs)
			{
				if (analogOutput.TagName.Equals(tagName))
				{
					MessageBox.Show("Tag with his name exists already");
					return false;
				}
			}
			return true;
		}

		private void DeleteBtn_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				DigitalInput analogInput = (DigitalInput)analogInputDataGrid.SelectedItem;
				if (analogInput == null) return;
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
				DigitalInput analogInput = (DigitalInput)analogInputDataGrid.SelectedItem;
				if (analogInput == null) return;
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

		private void AddOutputBtn_Click(object sender, RoutedEventArgs e)
		{
			if (!CorrectStringValue("Tag name", outpuTtagName)) return;
			if (!CorrectStringValue("Description", outputDes)) return;
			if (!CorrectStringValue("IOaddress", outputIOAddress)) return;
			if (!CorrectNumberValue("Initial Value", outputInitial)) return;
			if (!UniqueOutputTagName(OutpuTtagName)) return;

			int st = int.Parse(outputInitial);
			DigitalOutput analogOutput = new DigitalOutput()
			{
				TagName = outpuTtagName,
				Description = outputDes,
				IOAddress = outputIOAddress,
				InitialValue = st
			};
			analogOutputClient.Add(analogOutput);
			AnalogOutputs.Add(analogOutput);
		}

		private void DeleteOutputBtn_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				DigitalOutput analogInput = (DigitalOutput)analogOutputDataGrid.SelectedItem;
				if (analogInput == null) return;
				if (MessageBox.Show("Delete tag " + analogInput.TagName + "?", "Delete", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.Cancel)
				{
					return;
				}
				analogOutputClient.Delete(analogInput.TagName);
				AnalogOutputs.Remove(analogInput);
			}
			catch { }
		}

		private void ChangeOutputValueBtn_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				DigitalOutput analogInput = (DigitalOutput)analogOutputDataGrid.SelectedItem;
				if (analogInput == null) return;

				if (MessageBox.Show("Change scanning tag " + analogInput.TagName + "to " + analogInput.InitialValue + "?", "Delete", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.Cancel)
				{
					return;
				}
				analogOutputClient.Edit(analogInput.TagName, analogInput.InitialValue);

			}
			catch { }
		}
	}
}
