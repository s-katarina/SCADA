using DatabaseManager2.AlarmCrudReference;
using DatabaseManager2.AnalogInputReference;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
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

namespace DatabaseManager2.AlarmManagment
{
    /// <summary>
    /// Interaction logic for AlarmCRUDPage.xaml
    /// </summary>
    public partial class AlarmCRUDPage : Page
    {

        public static AnalogInputServiceClient analogClient = new AnalogInputServiceClient();
        public static AlarmCRUDServiceClient alarmClient = new AlarmCRUDServiceClient();

        private string tagName = "tagName";
        public string TagName { get => tagName; set => tagName = value; }
        private string limit = "limit";
        public string Limit { get => limit; set => limit = value; }

        private ObservableCollection<AlarmDTO> alarms = new ObservableCollection<AlarmDTO>();
        public ObservableCollection<AlarmDTO> Alarms { get => alarms; set => alarms = value; }

        private ObservableCollection<AnalogInputReference.AnalogInput> analogInputs = new ObservableCollection<AnalogInputReference.AnalogInput>();
        public ObservableCollection<AnalogInputReference.AnalogInput> AnalogInputs { get => analogInputs; set => analogInputs = value; }

        public AlarmCRUDPage()
        {
            DataContext = this;
            InitializeComponent();

            foreach (AnalogInputReference.AnalogInput analogInput in analogClient.GetAll().ToList())
            {
                AnalogInputs.Add(analogInput);
            }
            
            var columnToHide = dataGrid.Columns[0];
            columnToHide.Visibility = Visibility.Collapsed;

            RefreshAlarmsDataGrid();
        }

        private void RefreshAlarmsDataGrid()
        {
            Alarms.Clear();
            List<AlarmDTO> receivedAlarms = alarmClient.GetAll().ToList();
            foreach (AlarmCrudReference.AlarmDTO alarm in receivedAlarms)
            {
                Alarms.Add(alarm);
                //Alarms.Add(new AlarmCrudReference.Alarm() { Id = alarm.Id, InputTagName = alarm.InputTagName, Limit = alarm.Limit, Priority = alarm.Priority, Type = alarm.Type});
            }
        }

        private bool CorrectNumberValue(string fieldName, string value)
        {
            if (int.TryParse(value, out int intValue)) return true;
            MessageBox.Show("Field " + fieldName + " must be a number");
            return false;
        }

        private bool TagExists(string tagName)
        {
            foreach (AnalogInputReference.AnalogInput analogInput in AnalogInputs)
            {
                if (analogInput.TagName.Equals(tagName))
                {
                    return true;
                }
            }
            return false;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!TagExists(tagName))
            {
                MessageBox.Show("Tag doesn't exist.");
                return;
            }
            if (!CorrectNumberValue("Limit", limit)) return;

            ComboBoxItem priorityItem = (ComboBoxItem)cbPriority.SelectedItem;
            string priority = priorityItem.Content.ToString();
            ComboBoxItem typeItem = (ComboBoxItem)cbType.SelectedItem;
            string type = typeItem.Content.ToString();
            Enum.TryParse(type, out AlarmCrudReference.AlarmType alarmType);
            Enum.TryParse(type, out AlarmCrudReference.Priority alarmPriority);
            double l = double.Parse(limit);

            AlarmCrudReference.Alarm alarm = new AlarmCrudReference.Alarm()
            {
                Priority = alarmPriority,
                Type = alarmType,
                Limit = l
            };
            alarmClient.Add(alarm, tagName);
            RefreshAlarmsDataGrid();
        }
    }
}
