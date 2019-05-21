using System;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    public class Interactor : IInteractor
    {
        private IRequester _requester;

        public Interactor(IRequester requester)
        {
            _requester = requester;
        }

        public async Task<string> GetCourse(string atr1, string atr2, string value)
        {
            decimal course = await _requester.RequestAsync(atr1, atr2);
            decimal decimalValue;

            if ( course != -1 && decimal.TryParse(value, out decimalValue))
            {
                return (course * decimalValue).ToString();
            }
            else
            {
                return "Error!";
            }
        }
    }
}
