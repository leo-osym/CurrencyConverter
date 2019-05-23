using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    public class Timer
    {
        public bool isRunning = false;
        public bool reload = false;
        public delegate void TimerDelegate();
        public event TimerDelegate onTimeReached;

        public async Task RunTimer(int period)
        {
            for (int t = 0; t < period + 1;)
            {
                if (isRunning)
                {
                    await Task.Delay(500);
                    t += 500;
                }
                if (isRunning && t == period)
                {
                    if (!reload)
                    {
                        onTimeReached();
                        t = 0;
                    }
                }
                if (reload)
                {
                    reload = false;
                    t = 0;
                }
                if (!isRunning)
                {
                    break;
                }
            }
        }
    }
}
