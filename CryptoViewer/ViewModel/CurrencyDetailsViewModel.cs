using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoViewer.Models;
using System.ComponentModel;
using CryptoViewer.Services;
using System.Collections.ObjectModel;
using System.Windows;


namespace CryptoViewer.ViewModel
{
    class CurrencyDetailsViewModel:INotifyPropertyChanged
    {
        private Currency _selectedCurrency;

        public Currency SelectedCurrency
        {
            get => _selectedCurrency;
            set
            {
                if (_selectedCurrency != value)
                {
                    _selectedCurrency = value;
                    OnPropertyChanged(nameof(SelectedCurrency));
                }
            }
        }

        public CurrencyDetailsViewModel(Currency currency)
        {
            SelectedCurrency = currency;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public ObservableCollection<Market> Markets { get; } = new();

        public async Task LoadMarketsAsync(string currencyId)
        {
            var service = new CoinGeckoService();
            var markets = await service.GetMarketsForCurrencyAsync(currencyId);
            Application.Current.Dispatcher.Invoke(() =>
            {
                Markets.Clear();
                foreach (var market in markets)
                    Markets.Add(market);
            });
        }

    }
}
