using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TestyProjekt.Data;
namespace TestyProjekt.UC_Pages
{
	/// <summary>
	/// Interaction logic for UC_ConstructionProgress.xaml
	/// </summary>
	public partial class UC_ConstructionProgress : UserControl
	{
		public UC_ConstructionProgress()
		{
			InitializeComponent();
		}
		private ConstructionProgressConnection dataKeeper = new ConstructionProgressConnection();
		private void CPLT(object sender, RoutedEventArgs e)
		{
			ShowData();
		}
		public async Task ShowData()
		{
			var data = await dataKeeper.MakeObjects();
			FP.Text = "Fomorian progress: " + data.FomorianProgress.ToString() + "%";
			PB_FP.Value = data.FomorianProgress;
			RP.Text = "Razorback progress: " + data.RazorbackProgress.ToString() + "%";
			PB_RP.Value = data.RazorbackProgress;
			header.Text = "Construction progress";
		}
	}
}