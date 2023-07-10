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
using DatabaseManager2.AnalogOutputServiceReference;

namespace DatabaseManager2.TagManagment
{
	/// <summary>
	/// Interaction logic for InputTagsPage.xaml
	/// </summary>
	public partial class InputTagsPage : Page
	{
		public static AnalogInputServiceClient analogClient = new AnalogInputServiceClient();
		public static AnalogOutputServiceClient analogOutputClient = new AnalogOutputServiceClient();

		public static List<AnalogInput> IanalogInputs;
		public static List<AnalogOutput> IanalogOutputs;
		private ObservableCollection<AnalogInput> analogInputs = new ObservableCollection<AnalogInput>();
		private ObservableCollection<AnalogOutput> analogOutputs= new ObservableCollection<AnalogOutput>();
		private string tagName = "tagName";
		private string description = "Description";
		private string iOAddress = "IOAddress";
		private string units = "Units";
		private string scanTime = "Scan time";
		private string low = "Low";
		private string high = "High";

		private string outpuTtagName = "tagName2";
		private string outputIOAddress = "IOAddress2";
		private string outputUnits = "Units2";
		private string outputInitial = "Initial val2";
		private string outputLow = "Low2";
		private string outputHigh = "High2";
		private string outputDes = "Description2";


		public InputTagsPage()
		{
			DataContext = this;
			InitializeComponent();
			IanalogInputs = analogClient.GetAll().ToList();
			foreach (AnalogInput analogInput in IanalogInputs) {
				AnalogInputs.Add(analogInput);
			}

			IanalogOutputs = analogOutputClient.GetAll().ToList();
			foreach (AnalogOutput analogInput in IanalogOutputs)
			{
				AnalogOutputs.Add(analogInput);
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
		public ObservableCollection<AnalogOutput> AnalogOutputs { get => analogOutputs; set => analogOutputs = value; }
		public string OutpuTtagName { get => outpuTtagName; set => outpuTtagName = value; }
		public string OutputIOAddress { get => outputIOAddress; set => outputIOAddress = value; }
		public string OutputUnits { get => outputUnits; set => outputUnits = value; }
		public string OutputInitial { get => outputInitial; set => outputInitial = value; }
		public string OutputLow { get => outputLow; set => outputLow = value; }
		public string OutputHigh { get => outputHigh; set => outputHigh = value; }
		public string OutputDes { get => outputDes; set => outputDes = value; }

		private bool CorrectStringValue(string fieldName, string value) {
			if (value.Length >= 1) return true;
			MessageBox.Show("Field " + fieldName + " must be filled");
			return false;
		}

		private bool CorrectNumberValue(string fieldName, string value) {
			if (int.TryParse(value, out int intValue)) return true;
			MessageBox.Show("Field " + fieldName + " must be a number");
			return false;
		}

		private void AddBtn_Click(object sender, RoutedEventArgs e)
		{
			if (!CorrectStringValue("Tag name", tagName)) return;
			if (!CorrectStringValue("Description", description)) return;
			if (!CorrectStringValue("IOaddress", IOAddress)) return;
			if (!CorrectStringValue("Units", units)) return;
			if (!CorrectNumberValue("High Limit", high)) return;
			if (!CorrectNumberValue("Low Limit", low)) return;
			if (!CorrectNumberValue("Scan Time", scanTime)) return;
			if (!UniqueInputTagName(tagName)) return;

			Enum.TryParse(ComboBox1.SelectedItem.ToString(), out DriverType driverTypee);
			int h = int.Parse(high);
			int l = int.Parse(low);
			int st = int.Parse(scanTime);
			AnalogInput analogInput = new AnalogInput()
			{
				TagName = tagName,
				Description = description,
				Driver = driverTypee,
				HighLimit = h,
				LowLimit = l,
				IOAddress = iOAddress,
				IsScanning = (bool)McCheckBox.IsChecked,
				ScanTime = st,
				Units = units,
				Alarms = new Alarm[0]
			};
			analogClient.Add(analogInput);
			AnalogInputs.Add(analogInput);
			
		}

		private bool UniqueInputTagName(string tagName)
		{
			foreach (AnalogInput analogInput in AnalogInputs) {
				if (analogInput.TagName.Equals(tagName)) {
					MessageBox.Show("Tag with his name exists already");
					return false;
				}
			}
			return true;
		}

		private bool UniqueOutputTagName(string tagName)
		{
			foreach (AnalogOutput analogOutput in AnalogOutputs)
			{
				Debug.WriteLine(analogOutput.TagName);
				if (analogOutput.TagName.Equals(tagName))
				{
					Debug.WriteLine("AAAAAAAAAAAAA");
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
				AnalogInput analogInput = (AnalogInput)analogInputDataGrid.SelectedItem;
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
				AnalogInput analogInput = (AnalogInput)analogInputDataGrid.SelectedItem;
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
			if (!CorrectStringValue("Units", outputUnits)) return;
			if (!CorrectNumberValue("High Limit", outputHigh)) return;
			if (!CorrectNumberValue("Low Limit", outputLow)) return;
			if (!CorrectNumberValue("Initial Value", outputInitial)) return;
			if (!UniqueOutputTagName(OutpuTtagName)) return;

			Enum.TryParse(ComboBox1.SelectedItem.ToString(), out DriverType driverTypee);
			int h = int.Parse(outputHigh);
			int l = int.Parse(outputLow);
			int st = int.Parse(outputInitial);
			AnalogOutput analogOutput = new AnalogOutput()
			{
				TagName = outpuTtagName,
				Description = outputDes,
				HighLimit = h,
				LowLimit = l,
				IOAddress = outputIOAddress,
				Units = outputUnits,
				InitialValue = st
			};
			analogOutputClient.Add(analogOutput);
			AnalogOutputs.Add(analogOutput);
		}

		private void DeleteOutputBtn_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				AnalogOutput analogInput = (AnalogOutput)analogOutputDataGrid.SelectedItem;
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
				AnalogOutput analogInput = (AnalogOutput)analogOutputDataGrid.SelectedItem;
				if (analogInput == null) return;
				if (!(analogInput.LowLimit <= analogInput.InitialValue && analogInput.InitialValue <= analogInput.HighLimit)) {
					MessageBox.Show("Initial value is not between the low and high value");
					return;
				}

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
