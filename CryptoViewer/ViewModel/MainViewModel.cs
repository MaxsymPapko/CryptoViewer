using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using CryptoViewer.Models;
using CryptoViewer.Services;

namespace CryptoViewer.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Currency> _currencies;
        public ObservableCollection<Currency> Currencies
        {
            get => _currencies;
            set { _currencies = value; OnPropertyChanged(nameof(Currencies)); }
        }

        public MainViewModel()
        {
            LoadCurrencies();
        }

        private async void LoadCurrencies()
        {
            var list = await CoinGeckoService.GetTopCurrenciesAsync();
            Currencies = new ObservableCollection<Currency>(list);
        }

        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}