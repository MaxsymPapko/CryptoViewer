using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CryptoViewer.Models;
using CryptoViewer.Services;

namespace CryptoViewer.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Currency> Currencies { get; set; }
        public MainViewModel()
        {
            // Тимчасові дані для перевірки
            Currencies = new ObservableCollection<Currency>
            {
                new Currency { Name = "Bitcoin", Symbol = "BTC", CurrentPrice = 64000 },
                new Currency { Name = "Ethereum", Symbol = "ETH", CurrentPrice = 3200 }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }


    /*public event PropertyChangedEventHandler PropertyChanged;

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
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));*/
}
