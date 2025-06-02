using System.Windows.Controls;
using CryptoViewer.Models;
using System.Windows.Input;
using CryptoViewer.ViewModel;

namespace CryptoViewer.View
{
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
        private void CurrencyList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (CurrencyList.SelectedItem is Currency selectedCurrency)
            {
                NavigationService.Navigate(new CurrencyDetailsPage(selectedCurrency));
            }
        }

    }
}
