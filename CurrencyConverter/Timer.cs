using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    public class Timer
    {
        public bool IsRunning = false;
        public delegate void TimerDelegate();
        public event TimerDelegate onTimeReached;

        public async Task RunTimer(int period)
        {
            for (int t = 0; t < period + 1;)
            {
                if (IsRunning)
                {
                    await Task.Delay(500);
                    t += 500;
                }
                if (IsRunning && t == period)
                {
                    onTimeReached();
                    t = 0;
                }
                if (!IsRunning)
                {
                    break;
                }

            }
        }

    }
}
