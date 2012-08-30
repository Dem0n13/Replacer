using System;
using System.Diagnostics;
using System.Timers;

namespace Dem0n13.Replacer.Library.Tasks
{
    internal class ActionRepeater
    {
        private readonly Timer _timer = new Timer(DefaultRefresherPeriod);
        private const double DefaultRefresherPeriod = 250.0;
        private const double MaxRefresherPeriod = 10000.0;
        private readonly Action _action;
        private readonly Stopwatch _sw = new Stopwatch();

        public ActionRepeater(Action action)
        {
            if (action == null) throw new ArgumentNullException("action");
            _action = action;
        }

        public void Start(bool initialStart)
        {
            _sw.Start();
            _timer.Elapsed += OnTimerElapsed;
            if (initialStart) OnTimerElapsed(null, null);
            _timer.Start();
        }

        public void Stop(bool lastStart)
        {
            _timer.Elapsed -= OnTimerElapsed;
            _timer.Stop();
            if (lastStart) OnTimerElapsed(null, null);
            _sw.Stop();
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            Debug.WriteLine("TimerEvent: " + _sw.Elapsed);
            _action();
        }

        public void TimeIncrement()
        {
            var newValue = _timer.Interval * 2.0;
            if (newValue > MaxRefresherPeriod) return;
            _timer.Interval = newValue;
        }

        public void TimeDecrement()
        {
            var newValue = _timer.Interval / 2.0;
            if (newValue < DefaultRefresherPeriod) return;
            _timer.Interval = newValue;
        }
    }
}
