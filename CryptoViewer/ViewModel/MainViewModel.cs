using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CryptoViewer.Models;
using CryptoViewer.Services;
using System.Windows;

namespace CryptoViewer.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Currency> _currencies;
        public ObservableCollection<Currency> Currencies
        {
            get => _currencies;
            set
            {
                _currencies = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            LoadCurrencies();
        }

        private async void LoadCurrencies()
        {
            var service = new CoinGeckoService();
            var result = await service.GetTopCurrenciesAsync(10);

            if (result == null || result.Count == 0)
            {
                MessageBox.Show("❌ CoinGecko API не повернув валют.");
                return;
            }

            Currencies = new ObservableCollection<Currency>(result);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}