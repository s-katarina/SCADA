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
using RecordServiceRef;
using AnalogInputServiceRef;
using DigitalInputServiceRef;

namespace Trending
{
    /// <summary>
    /// Interaction logic for TrendingWindow.xaml
    /// </summary>
    public partial class TrendingWindow : Window
    {
        public AnalogInputServiceClient analogClient = new AnalogInputServiceClient();
        public DigitalInputServiceClient digitalClient = new DigitalInputServiceClient();
        public RecordServiceClient recordClient = new RecordServiceClient();

        public static IEnumerable<AnalogInput> analogInputs;
        public static IEnumerable<DigitalInput> digitalInputs;
        public static Dictionary<string, double> current;

        public static List<InputTableRecord> InputTableRecords { get; set; }

        public TrendingWindow()
        {
            InitializeComponent();

            analogInputs = analogClient.GetAll();
            digitalInputs = digitalClient.GetAll();
            current = recordClient.GetCurrent();

            InputTableRecords = MakeInputTableRecords(analogInputs, digitalInputs, current);

            DataContext = this;
        }

        public static List<InputTableRecord> MakeInputTableRecords(IEnumerable<AnalogInput> analogInputs, IEnumerable<DigitalInput> digitalInputs, Dictionary<string, double> current)
        {
            List<InputTableRecord> ret = new List<InputTableRecord>();

            foreach (AnalogInput analogInput in analogInputs)
            {
                double value = 9999999;

                if (current.ContainsKey(analogInput.IOAddress))
                    value = current[analogInput.IOAddress];

                ret.Add(new InputTableRecord() { TagName = analogInput.TagName, IOAddress = analogInput.IOAddress, IsScanning = analogInput.IsScanning, Value = value, Type = "Analog" });
            }


            foreach (DigitalInput digitalInput in digitalInputs)
            {
                double value = 9999999;

                if (current.ContainsKey(digitalInput.IOAddress))
                    value = current[digitalInput.IOAddress];

                ret.Add(new InputTableRecord() { TagName = digitalInput.TagName, IOAddress = digitalInput.IOAddress, IsScanning = digitalInput.IsScanning, Value = value, Type = "Digital" });
            }

            return ret;
        }
    }
}
