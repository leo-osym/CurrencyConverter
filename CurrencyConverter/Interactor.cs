using System;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    public class Interactor : IInteractor
    {
        private IRequester _requester;
        private Timer timer;

        private decimal lastCourse = 0;
        public string LastTimeUpdated { get; private set; }

        private string lastCurrencyType1 = null;
        private string lastCurrencyType2 = null;

        private bool timerIsOver = false;

        public Interactor(IRequester requester)
        {
            _requester = requester;
            timer = new Timer();
            timer.isRunning = true;
            timer.RunTimer(10000);
            timer.onTimeReached += () => timerIsOver = true;
        }

        public async Task<decimal> GetCourse(string currencyCode1, string currencyCode2, decimal value)
        {
            if ((currencyCode1 == lastCurrencyType1 && currencyCode2 == lastCurrencyType2 && timerIsOver)
                || (currencyCode1 != lastCurrencyType1 || currencyCode2 != lastCurrencyType2))
            {
                lastCurrencyType1 = currencyCode1;
                lastCurrencyType2 = currencyCode2;

                lastCourse = await _requester.RequestAsync(currencyCode1, currencyCode2);
                timerIsOver = false;
                timer.reload = true;
                LastTimeUpdated = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            }
               

            if (lastCourse >= 0)
            {
                return lastCourse * value;
            }
            else
            {
                return -1;
            }
        }
    }
}
