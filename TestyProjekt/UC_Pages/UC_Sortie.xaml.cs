using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TestyProjekt.Data;
namespace TestyProjekt
{
	/// <summary>
	/// Interaction logic for UC_Sortie.xaml
	/// </summary>
	public partial class UC_Sortie : UserControl
	{
		private SortieConection dataKeeper = new SortieConection();
		public UC_Sortie()
		{
			InitializeComponent();
		}
		private void SLT(object sender, RoutedEventArgs e)
		{
			ShowData();
		}
		public async Task ShowData()
		{
			var data = await dataKeeper.MakeObjects();
			header.Text = "Sortie";
			title.Text = "Expiry at: " + data.Expiry.LocalDateTime.ToString();
			h_boss.Text = "Boss: " + data.Boss;
			h_faction.Text = "Faction: " + data.Faction;
			h_reward_pool.Text = "Reward pool: " + data.RewardPool;
			DataList.ItemsSource = data.Variants;
		}
	}
}