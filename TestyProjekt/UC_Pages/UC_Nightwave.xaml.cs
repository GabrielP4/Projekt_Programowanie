using System.Threading.Tasks;
using System.Windows.Controls;
using Projekt_Grupa_24.Data;

namespace Projekt_Grupa_24.UC_Pages
{
	/// <summary>
	/// Główna logika zakładki UC_Nightwave.xaml
	/// </summary>
	public partial class UC_Nightwave : UserControl
	{
		private NightwaveConnection dataKeeper = new NightwaveConnection();

		/// Inicjalizuje komponenty zakładki
		public UC_Nightwave()
		{
			InitializeComponent();
			ShowData();
		}

		/// Logika wyświetlania danych w zakładce
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