using System;
using System.Timers;
using NLog;

namespace Dem0n13.Replacer.Library.Tasks
{
    internal class ActionRepeater
    {
        public readonly Logger Log = LogManager.GetCurrentClassLogger();
        private readonly Timer _timer = new Timer(DefaultRefresherPeriod);
        private const double DefaultRefresherPeriod = 250.0;
        private const double MaxRefresherPeriod = 4000.0;
        private readonly Action _action;

        public ActionRepeater(Action action)
        {
            if (action == null) throw new ArgumentNullException("action");
            _action = action;
        }

        public void Start(bool initialStart)
        {
            Log.Debug("Start");
            _timer.Elapsed += OnTimerElapsed;
            if (initialStart) OnTimerElapsed(null, null);
            _timer.Start();
        }

        public void Stop(bool lastStart)
        {
            _timer.Elapsed -= OnTimerElapsed;
            _timer.Stop();
            if (lastStart) OnTimerElapsed(null, null);
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            //Log.Debug("OnTimerElapsed");
            _action();
        }

        public void IncPeriod()
        {
            var newValue = _timer.Interval * 2.0;
            if (newValue > MaxRefresherPeriod) return;
            _timer.Interval = newValue;
        }

        public void DecPeriod()
        {
            var newValue = _timer.Interval / 2.0;
            if (newValue < DefaultRefresherPeriod) return;
            _timer.Interval = newValue;
        }
    }
}
