using System.Threading.Tasks;
using System.Windows.Controls;
using Projekt_Grupa_24.Data;

namespace Projekt_Grupa_24.UC_Pages
{
	/// <summary>
	/// Główna logika zakładki UC_ConstructionProgress.xaml
	/// </summary>
	public partial class UC_ConstructionProgress : UserControl
	{
		private ConstructionProgressConnection dataKeeper = new ConstructionProgressConnection();

		/// Inicjalizuje komponenty zakładki
		public UC_ConstructionProgress()
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
				FP.Text = "Fomorian progress: " + data.FomorianProgress.ToString() + "%";
				PB_FP.Value = data.FomorianProgress;
				RP.Text = "Razorback progress: " + data.RazorbackProgress.ToString() + "%";
				PB_RP.Value = data.RazorbackProgress;
				header.Text = "Construction progress";
			}
			else { header.Text = "Check your internet connections"; }
		}
	}
}