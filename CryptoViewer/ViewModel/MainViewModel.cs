using CryptoViewer.Models;
using CryptoViewer.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

public class MainViewModel : INotifyPropertyChanged
{
    private readonly ICryptoService _cryptoService;

    public ObservableCollection<Currency> Currencies { get; set; } = new ObservableCollection<Currency>();
    public ObservableCollection<Currency> FilteredCurrencies { get; set; } = new ObservableCollection<Currency>();

    private Currency _selectedCurrency;
    public Currency SelectedCurrency
    {
        get => _selectedCurrency;
        set
        {
            _selectedCurrency = value;
            OnPropertyChanged();
        }
    }

    private string _searchQuery;
    public string SearchQuery
    {
        get => _searchQuery;
        set
        {
            if (_searchQuery != value)
            {
                _searchQuery = value;
                OnPropertyChanged();
                FilterCurrencies();
            }
        }
    }

    public MainViewModel()
    {
        _cryptoService = new CoinGeckoService();
        LoadCurrenciesAsync();
    }

    private async void LoadCurrenciesAsync()
    {
        try
        {
            var currencies = await _cryptoService.GetTopCurrenciesAsync(10);

            Currencies.Clear();
            FilteredCurrencies.Clear();

            foreach (var currency in currencies)
            {
                Currencies.Add(currency);
                FilteredCurrencies.Add(currency);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Помилка завантаження валют: " + ex.Message);
        }
    }

    private void FilterCurrencies()
    {
        if (string.IsNullOrWhiteSpace(SearchQuery))
        {
            // Якщо пошук порожній — повертаємо повний список
            FilteredCurrencies.Clear();
            foreach (var currency in Currencies)
                FilteredCurrencies.Add(currency);
        }
        else
        {
            var filtered = Currencies
                .Where(c => c.Name.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase) ||
                            c.Symbol.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase))
                .ToList();

            FilteredCurrencies.Clear();
            foreach (var c in filtered)
                FilteredCurrencies.Add(c);
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }


}
