using System.Windows;
using System.Windows.Input;
using TestyProjekt.UC_Pages;

namespace TestyProjekt
{
	/// <summary>
	/// Główna logika aplikacji
	/// </summary>
	public partial class MainWindow : Window
	{
		/// Inicjalizuje komponenty aplikacji
		public MainWindow()
		{
			InitializeComponent();
		}

		/// Wywołanie zdażenia wczytujacego zakładkę "Sortie".
		private void ListViewItem_Sortie(object sender, RoutedEventArgs e)
		{
			DataContext = new UC_Sortie();
		}

		/// Wywołanie zdażenia wczytujacego zakładkę "Construction progress".
		private void ListViewItem_ConstructionProgress(object sender, RoutedEventArgs e)
		{
			DataContext = new UC_ConstructionProgress();
		}

		/// Wywołanie zdażenia wczytujacego zakładkę "Nightwave".
		private void ListViewItem_Nightwave(object sender, RoutedEventArgs e)
		{
			DataContext = new UC_Nightwave();
		}

		/// Wywołanie zdażenia wczytujacego zakładkę początkową.
		private void loaded_Start(object sender, RoutedEventArgs e)
		{
			DataContext = new UC_Start();
		}

		///Logika tooltipów w menu
		private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
		{
			if (Tg_Btn.IsChecked == true)
			{
				tt_home.Visibility = Visibility.Collapsed;
				tt_contacts.Visibility = Visibility.Collapsed;
				tt_messages.Visibility = Visibility.Collapsed;
			}
			else
			{
				tt_home.Visibility = Visibility.Visible;
				tt_contacts.Visibility = Visibility.Visible;
				tt_messages.Visibility = Visibility.Visible;
			}
		}

		/// Logika odpowiadająca za wygląd aplikacji w momęcie gdy menu jest schowane
		private void Tg_Btn_Unchecked(object sender, RoutedEventArgs e)
		{
			bc_Main.Opacity = 1;
		}

		/// Logika odpowiadająca za wygląd aplikacji w momęcie gdy menu jest wysunięte
		private void Tg_Btn_Checked(object sender, RoutedEventArgs e)
		{
			bc_Main.Opacity = 0.3;
		}

		/// Logika odpowiadająca za wygląd ikony "hamburger" w momęcie gdy menu jest wysunięte
		private void BG_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			Tg_Btn.IsChecked = false;
		}
	}
}