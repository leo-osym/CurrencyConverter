using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CurrencyConverter.Test
{
    [TestFixture]
    public class TimerTest
    {
        private Timer timer;

        [SetUp]
        public void SetUp()
        {
            timer = new Timer();
            timer.isRunning = true;
        }

        [Test]
        public void TestGetCurrentFloor()
        {
            timer = new Timer();
            timer.isRunning = true;
            timer.onTimeReached += TimerHandler;
            timer.RunTimer(5000);

            lock (this)
            {
                if (!Monitor.Wait(this, 6000)) Assert.Fail("Event did not arrive in time.");
            }
        }

        private void TimerHandler()
        {
            lock (this)
            {
                Monitor.Pulse(this);
            }
        }
    }
}
