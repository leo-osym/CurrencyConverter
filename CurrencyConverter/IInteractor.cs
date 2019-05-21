using System;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    public interface IInteractor
    {
        Task<decimal> GetCourse(string atr1, string atr2, decimal value);
    }
}
