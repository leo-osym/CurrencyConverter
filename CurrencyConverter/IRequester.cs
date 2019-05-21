using System;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    public interface IRequester
    {
        Task<decimal> RequestAsync(string atr1, string atr2);
    }
}
