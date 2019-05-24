using System;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    public interface IRequester
    {
        Task<decimal> RequestAsync(string currencyCode1, string currencyCode2);
    }
}
