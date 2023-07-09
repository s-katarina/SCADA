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
using Trending.AnalogInputServiceRef;
using Trending.DigitalInputServiceRef;
using Trending.RecordServiceRef;
using Trending.Models;
using System.ServiceModel;
using System.Threading;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Trending
{
    /// <summary>
    /// Interaction logic for TrendingWindow.xaml
    /// </summary>
    public partial class TrendingWindow : Window
    {
        public class Callback : PubSubService.ISubCallback
        {
            public void MessageArrived(Dictionary<string, double> current)
            {
                Debug.WriteLine(current);
                MakeInputTableRecords(analogInputs, digitalInputs, current);
            }
        }
        public static PubSubService.SubClient subclient;
        public static AnalogInputServiceClient analogClient = new AnalogInputServiceClient();
        public static DigitalInputServiceClient digitalClient = new DigitalInputServiceClient();
        public static RecordServiceClient recordClient = new RecordServiceClient();
        public static ScanServiceClient scanClient = new ScanServiceClient(new InstanceContext(new AnalogScanArrivedCallback()));

        public static IEnumerable<AnalogInputServiceRef.AnalogInput> analogInputs;
        public static IEnumerable<DigitalInput> digitalInputs;
        public static Dictionary<string, double> current;

        public static ObservableCollection<InputTableRecord> InputTableRecords { get; set; }

        public TrendingWindow()
        {
            InitializeComponent();

            analogInputs = analogClient.GetAll();
            digitalInputs = digitalClient.GetAll();
            current = recordClient.GetCurrent();
            InputTableRecords = new ObservableCollection<InputTableRecord>();

            InstanceContext ic = new InstanceContext(new Callback());
            subclient = new PubSubService.SubClient(ic);
            subclient.InitSub();
            Console.Read();

            MakeInputTableRecords(analogInputs, digitalInputs, current);

            DataContext = this;

            RefreshTable();
        }

        public static void RefreshTable()
        {
            current = recordClient.GetCurrent();
            MakeInputTableRecords(analogInputs, digitalInputs, current);
        }

        public static void MakeInputTableRecords(IEnumerable<AnalogInputServiceRef.AnalogInput> analogInputs, IEnumerable<DigitalInput> digitalInputs, Dictionary<string, double> current)
        {
            InputTableRecords.Clear();

            foreach (AnalogInputServiceRef.AnalogInput analogInput in analogInputs)
            {
                double value = 9999999;

                if (current.ContainsKey(analogInput.IOAddress))
                    value = current[analogInput.IOAddress];

                InputTableRecords.Add(new InputTableRecord() { TagName = analogInput.TagName, IOAddress = analogInput.IOAddress, IsScanning = analogInput.IsScanning, Value = value, Type = "Analog" });
            }


            foreach (DigitalInput digitalInput in digitalInputs)
            {
                double value = 9999999;

                if (current.ContainsKey(digitalInput.IOAddress))
                    value = current[digitalInput.IOAddress];

                InputTableRecords.Add(new InputTableRecord() { TagName = digitalInput.TagName, IOAddress = digitalInput.IOAddress, IsScanning = digitalInput.IsScanning, Value = value, Type = "Digital" });
            }

        }
    }

    public class AnalogScanArrivedCallback : IScanServiceCallback
    {
        public void ScanDone(Dictionary<string, double> current)
        {
            System.Diagnostics.Debug.WriteLine("nesto");
            System.Diagnostics.Debug.WriteLine(current);
        }
    }
}
