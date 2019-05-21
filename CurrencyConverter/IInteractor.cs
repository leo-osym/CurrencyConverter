using System;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    public interface IInteractor
    {
        Task<string> GetCourse(string atr1, string atr2, string value);
    }
}
