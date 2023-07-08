﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ReportManager.UserServiceRef;

namespace ReportManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UserServiceClient usClient = new UserServiceClient();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            if (usClient.Login(username, password))
            {
                ReportWindow report = new ReportWindow();
                report.Show();

                AlarmReportWindow alarmReport = new AlarmReportWindow();
                alarmReport.Show();
            }
            else
            {
                message.Text = "Wrong credentials.";
            }
        }
    }
}
