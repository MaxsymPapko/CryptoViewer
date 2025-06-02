using CryptoViewer.Models;
using CryptoViewer.ViewModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace CryptoViewer.View
{
    public partial class CurrencyDetailsPage : Page
    {
        public CurrencyDetailsPage(Currency selectedCurrency)
        {
            InitializeComponent();
            DataContext = new CurrencyDetailsViewModel(selectedCurrency);
        }

        private void Back_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        private void OpenMarket_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.CommandParameter is string url && !string.IsNullOrEmpty(url))
            {
                try
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = url,
                        UseShellExecute = true
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cannot open URL: " + ex.Message);
                }
            }
        }

    }
}