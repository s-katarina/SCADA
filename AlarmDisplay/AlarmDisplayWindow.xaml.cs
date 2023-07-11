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

            public void MessageArrived(TriggeredAlarm[] current)
            {
                Debug.WriteLine("Message has arrived");
                Application.Current.Dispatcher.Invoke((() =>
                {
                    FillTable(current.ToList());
                    ApplyBlinkingEffect(current.ToList().Count, dg, new SolidColorBrush(Colors.Red), TimeSpan.FromMilliseconds(700));
                }));
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

        public static void FillTable(List<TriggeredAlarm> current)
        {
            Debug.WriteLine(current.Count);
            foreach (var a in current)
            {
                AlarmTableItems.Insert(0, new AlarmTableItem()
                {
                    TagName = a.InputTagName,
                    AlarmPriority = a.Priority,
                    AlarmType = a.Type,
                    Timestamp = a.Timestamp,
                    Value = a.Value,
                    Limit = a.Limit
                });
            }
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

        public static void ApplyBlinkingEffect(int count, DataGrid dataGrid, Brush blinkColor, TimeSpan blinkInterval)
        {
            for (int i = 0; i < count;  i++)
            //for (int i = AlarmTableItems.Count-1; i > AlarmTableItems.Count-1-count;  i--)
            {
                var item = dataGrid.Items[i];
                if (item is AlarmTableItem rowItem)
                {
                    dataGrid.UpdateLayout(); // Ensure the DataGrid is fully rendered

                    DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromItem(rowItem);

                    if (row != null)
                    {
                        var cellContent = dataGrid.Columns[1].GetCellContent(row);
                        if (cellContent is TextBlock textBlock && textBlock.Text == "FIRST")
                        {
                            BlinkRow(row, blinkColor, 3, blinkInterval);
                        }
                        else if (cellContent is TextBlock tb && (tb.Text == "SECOND" || tb.Text == "2"))
                        {
                            BlinkRow(row, blinkColor, 2, blinkInterval);
                        }
                        else if (cellContent is TextBlock tbb && (tbb.Text == "THIRD" || tbb.Text == "3"))
                        {
                            BlinkRow(row, blinkColor, 1, blinkInterval);
                        }
                    }
                }
            }
        }

    }
}
