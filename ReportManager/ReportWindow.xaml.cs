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
using System.Windows.Shapes;
using ReportManager.RecordServiceRef;
using ReportManager.AnalogInputServiceRef;
using ReportManager.DigitalInputServiceRef;

namespace ReportManager
{
    /// <summary>
    /// Interaction logic for ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        public static RecordServiceClient recordClient = new RecordServiceClient();
        public static AnalogInputServiceClient analogClient = new AnalogInputServiceClient();
        public static DigitalInputServiceClient digitalClient = new DigitalInputServiceClient();

        public ObservableCollection<Record> Records { get; set; }

        public static DataGrid recordGrid;
        public static DataGrid alarmGrid;

        public ReportWindow()
        {
            InitializeComponent();
            DataContext = this;
            Records = new ObservableCollection<Record>();
        }

        private void MostRecentAI_Click(object sender, RoutedEventArgs e)
        {
            Records.Clear();
            List<Record> records = recordClient.MostRecentAI().ToList();
            foreach (Record r in records)
                Records.Add(r);
        }

        private void MostRecentDI_Click(object sender, RoutedEventArgs e)
        {
            Records.Clear();
            List<Record> records = recordClient.MostRecentDI().ToList();
            foreach (Record r in records)
                Records.Add(r); 
        }

        private void RecordsForTag_Click(object sender, RoutedEventArgs e)
        {
            Records.Clear();

            string tag = txtTag.Text;
            if (tag.Length == 0)
                return;

            List<Record> records = recordClient.GetAllForTag(tag).ToList();
            foreach (Record r in records)
                Records.Add(r);
        }

        private void RecordsForPeriod_Click(object sender, RoutedEventArgs e)
        {
            Records.Clear();

            string start = txtStartDate.Text;
            string end = txtEndDate.Text;
            if (start.Length == 0 || end.Length == 0)
                return;

            DateTime startDate;
            DateTime endDate;
            bool parsed;

            parsed = DateTime.TryParse(start, out startDate);
            if (!parsed)
            {
                message.Text = "Wrong format for start date.";
                return;
            }

            parsed = DateTime.TryParse(end, out endDate);
            if (!parsed)
            {
                message.Text = "Wrong format for end date.";
                return;
            }

            List<Record> records = recordClient.GetAllInPeriod(startDate, endDate).ToList();
            foreach (Record r in records)
                Records.Add(r);
        }
    }
}
