﻿using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TestyProjekt.Data;

namespace TestyProjekt.UC_Pages
{
	/// <summary>
	/// Interaction logic for UC_Nightwave.xaml
	/// </summary>
	public partial class UC_Nightwave : UserControl
	{
		private NightwaveConnection dataKeeper = new NightwaveConnection();

		public UC_Nightwave()
		{
			InitializeComponent();
		}

		private void NWLT(object sender, RoutedEventArgs e)
		{
			ShowData();
		}

		public async Task ShowData()
		{
			var data = await dataKeeper.MakeObjects();
			if (data != null)
			{
				DataList.ItemsSource = data.ActiveChallenges;
				header.Text = "Nightwave";
				title.Text = "Expiry at: " + data.Expiry.LocalDateTime.ToString();
			}
			else { header.Text = "Check your internet connections"; }
		}
	}
}