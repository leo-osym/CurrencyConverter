using System;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    public class Interactor : IInteractor
    {
        private IRequester _requester;
        private Timer timer;
        private string lastCurrencyType1;
        private string lastCurrencyType2;
        private decimal lastCourse = -1;
        private bool timerIsOver = false;
        public string LastTimeUpdated { get; private set; }

        public Interactor(IRequester requester)
        {
            _requester = requester;
            timer = new Timer();
            timer.IsRunning = true;
            timer.onTimeReached += () => timerIsOver = true;
        }

        public async Task<string> GetCourse(string atr1, string atr2, string value)
        {
            if ((atr1 == lastCurrencyType1 && atr2 == lastCurrencyType2 && timerIsOver) 
                || (atr1 != lastCurrencyType1 || atr2 != lastCurrencyType2))
            {
                lastCourse = await _requester.RequestAsync(atr1, atr2);
                timerIsOver = false;
                LastTimeUpdated = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            }

            decimal decimalValue;
            if ( lastCourse >= 0 && decimal.TryParse(value, out decimalValue))
            {
                return (lastCourse * decimalValue).ToString();
            }
            else
            {
                return "Error!";
            }
        }
    }
}
