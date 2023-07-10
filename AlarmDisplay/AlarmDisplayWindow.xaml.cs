using AlarmDisplay.AlarmServiceRef;
using AlarmDisplay.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AlarmDisplay
{
    /// <summary>
    /// Interaction logic for AlarmDisplayWindow.xaml
    /// </summary>
    public partial class AlarmDisplayWindow : Window
    {
        public class Callback : ISubAlarmCallback
        {
            public DataGrid dg;
            public void MessageArrived(Dictionary<string, Alarm> current)
            {
                Debug.WriteLine("Message has arrived");
                Application.Current.Dispatcher.Invoke((() =>
                {
                    FillTable(current);
                    ApplyBlinkingEffect(dg, new SolidColorBrush(Colors.Red), TimeSpan.FromMilliseconds(700));
                }));
                //Thread.Sleep(3000);
                //lock (dataGridLock)
                //{
                //    //Task.Delay(100).ContinueWith(_ =>
                //    //{
                //    //});

                //}

            }
        }

        private SubAlarmClient subClient;
        public static ObservableCollection<AlarmTableItem> AlarmTableItems = new ObservableCollection<AlarmTableItem>();
        public static object dataGridLock = new object();

        public AlarmDisplayWindow()
        {
            InitializeComponent();
            dataGrid.ItemsSource = AlarmTableItems;

            Callback cb = new Callback();
            cb.dg = dataGrid;
            InstanceContext ic = new InstanceContext(cb);
            subClient = new SubAlarmClient(ic);
            subClient.InitSub();
        }

        public static void FillTable(Dictionary<string, Alarm> current)
        {
            AlarmTableItems.Clear();
            Debug.WriteLine(current.Count);
            foreach (var kvp in current)
            {
                AlarmTableItems.Add(new AlarmTableItem()
                {
                    TagName = kvp.Key,
                    AlarmPriority = kvp.Value.Priority.ToString(),
                    AlarmType = kvp.Value.Type.ToString(),
                    TimeStamp = DateTime.Now.ToLongDateString(),
                });
            }
            //AlarmTableItems.Add(new AlarmTableItem() { TagName = "a", AlarmPriority = "b", AlarmType = "c", Value = 12.4 });

        }

        private static async void BlinkRow(DataGridRow row, Brush color, int blinkCount, TimeSpan blinkInterval)
        {
            for (int i = 0; i < blinkCount; i++)
            {
                row.Background = color;
                await Task.Delay(blinkInterval);
                row.Background = Brushes.Transparent;
                await Task.Delay(blinkInterval);
            }
        }

        public static void ApplyBlinkingEffect(DataGrid dataGrid, Brush blinkColor, TimeSpan blinkInterval)
        {
            foreach (var item in dataGrid.Items)
            {
                if (item is AlarmTableItem rowItem) 
                {
                    dataGrid.UpdateLayout(); // Ensure the DataGrid is fully rendered

                    DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromItem(rowItem);

                    var cellContent = dataGrid.Columns[2].GetCellContent(row);
                    if (cellContent is TextBlock textBlock && textBlock.Text == "FIRST")
                    {
                        BlinkRow(row, blinkColor, 3, blinkInterval);
                    }
                    else if (cellContent is TextBlock tb && tb.Text == "SECOND")
                    {
                        BlinkRow(row, blinkColor, 2, blinkInterval);
                    }
                    else if (cellContent is TextBlock tbb && tbb.Text == "THIRD")
                    {
                        BlinkRow(row, blinkColor, 3, blinkInterval);
                    }
                }
            }
        }

    }
}
