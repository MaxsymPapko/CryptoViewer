using CryptoViewer.Models;
using CryptoViewer.ViewModel;
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
    }
}