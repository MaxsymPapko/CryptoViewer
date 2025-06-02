using System.Collections.Generic;
using System.Threading.Tasks;
using CryptoViewer.Models;

namespace CryptoViewer.Services
{
    public interface ICryptoService
    {
        Task<List<Currency>> GetTopCurrenciesAsync(int count);
    }
}