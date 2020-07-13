using System;
using System.Collections.Generic;
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
using TestyProjekt.Data;

namespace TestyProjekt.UC_Pages
{
	/// <summary>
	/// Interaction logic for UC_Nightwave.xaml
	/// </summary>
	public partial class UC_Nightwave : UserControl
	{
		NightwaveConnection dataKeeper = new NightwaveConnection();

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
			DataList.ItemsSource = data.ActiveChallenges;
			header.Text = "Nightwave";
			title.Text = "Expiry at: " + data.Expiry.LocalDateTime.ToString();
			
		}
	}
}
