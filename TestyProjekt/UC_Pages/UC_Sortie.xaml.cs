using System.Threading.Tasks;
using System.Windows.Controls;
using TestyProjekt.Data;

namespace TestyProjekt.UC_Pages
{
	/// <summary>
	/// Interaction logic for UC_Sortie.xaml
	/// </summary>
	public partial class UC_Sortie : UserControl
	{
		private SortieConection dataKeeper = new SortieConection();

		/// Inicjalizuje komponenty zakładki
		public UC_Sortie()
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
				header.Text = "Sortie";
				title.Text = "Expiry at: " + data.Expiry.LocalDateTime.ToString();
				h_boss.Text = "Boss: " + data.Boss;
				h_faction.Text = "Faction: " + data.Faction;
				h_reward_pool.Text = "Reward pool: " + data.RewardPool;
				DataList.ItemsSource = data.Variants;
			}
			else { header.Text = "Check your internet connections"; }
		}
	}
}