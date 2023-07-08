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
using ReportManager.AnalogInputServiceRef;

namespace ReportManager
{
    /// <summary>
    /// Interaction logic for AlarmReportWindow.xaml
    /// </summary>
    public partial class AlarmReportWindow : Window
    {
        public static AnalogInputServiceClient analogClient = new AnalogInputServiceClient();

        public ObservableCollection<AlarmRecordTable> RecordsAlarm { get; set; }

        public AlarmReportWindow()
        {
            InitializeComponent();
            DataContext = this;
            RecordsAlarm = new ObservableCollection<AlarmRecordTable>();
        }

        private void RecordsForPriority_Click(object sender, RoutedEventArgs e)
        {

            RecordsAlarm.Clear();

            string txt = txtPriority.Text;
            if (txt.Length == 0)
                return;

            Priority priority;

            if (txt.Equals("1"))
                priority = Priority.FIRST;
            else if (txt.Equals("2"))
                priority = Priority.SECOND;
            else if (txt.Equals("3"))
                priority = Priority.THIRD;
            else
                return;

            List<RecordAlarm> records = analogClient.GetRecordAlarmsByPriority(priority).ToList();

            System.Diagnostics.Debug.WriteLine(records[0].Alarm == null);
            //foreach (RecordAlarm r in records)
            //    RecordsAlarm.Add(new AlarmRecordTable() { TagName = r.Alarm.AnalogInput.TagName, Priority = r.Alarm.Priority, Timestamp = r.Timestamp, Limit = r.Alarm.Limit, Type = r.Alarm.Type });
        }
    }
}
