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
using CORE.Models;

namespace DatabaseManager.TagManagment
{
	/// <summary>
	/// Interaction logic for SenzoresPage.xaml
	/// </summary>
	public partial class SenzoresPage : Page
	{
		static DigitalInputServiceRef.DigitalInputServiceClient digitalClient = new();
		public static IEnumerable<DigitalInput> digitalInputs;

		public SenzoresPage()
		{
			InitializeComponent();
			digitalInputs = digitalClient.;
		}
	}
}
