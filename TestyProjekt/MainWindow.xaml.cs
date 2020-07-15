using System.Windows;
using System.Windows.Input;
using TestyProjekt.UC_Pages;

namespace TestyProjekt
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void ListViewItem_Sortie(object sender, RoutedEventArgs e)
		{
			DataContext = new UC_Sortie();
		}

		private void ListViewItem_ConstructionProgress(object sender, RoutedEventArgs e)
		{
			DataContext = new UC_ConstructionProgress();
		}

		private void ListViewItem_Nightwave(object sender, RoutedEventArgs e)
		{
			DataContext = new UC_Nightwave();
		}

		private void loaded_Start(object sender, RoutedEventArgs e)
		{
			DataContext = new UC_Start();
		}

		//GUI  ListViewItem_ConstructionProgress
		private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
		{
			// Set tooltip visibility
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

		private void Tg_Btn_Unchecked(object sender, RoutedEventArgs e)
		{
			bc_Main.Opacity = 1;
		}

		private void Tg_Btn_Checked(object sender, RoutedEventArgs e)
		{
			bc_Main.Opacity = 0.3;
		}

		private void BG_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			Tg_Btn.IsChecked = false;
		}
	}
}