using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Dem0n13.Replacer.Library.Utils;

namespace Dem0n13.Replacer.Library.Tasks
{
    internal class MicroTask
    {
        private readonly TextFile _file;
        private readonly RegexProcessor _regex;
        private readonly Replacement _replacement;
        private readonly object _busy = new object();

        #region private statistics

        // накопители статистики
        private readonly object _syncStat = new object();
        private double _currentStagePercentage;
        private int _replacesCount;
        private bool _updated;
        private MicroTaskStates _state;
        
        // внутренние акцессоры к статистике
        private int ReplacesCount
        {
            get { return _replacesCount; }
            set
            {
                lock (_syncStat)
                {
                    _replacesCount = value;
                    _updated = true;
                }
            }
        }

        private MicroTaskStates State
        {
            get { return _state; }
            set
            {
                lock (_syncStat)
                {
                    _currentStagePercentage = 0.0;
                    _state = value;
                    _updated = true;
                }
            }
        }

        private double CurrentStagePercentage
        {
            get { return _currentStagePercentage; }
            set
            {
                lock (_syncStat)
                {
                    _currentStagePercentage = value;
                    _updated = true;
                }
            }
        }

        private double Percentage
        {
            get
            {
                switch (_state)
                {
                    case MicroTaskStates.None:
                        return 0.0;
                    case MicroTaskStates.Reading:
                        return 10.0;
                    case MicroTaskStates.Searching:
                        return 10.0 + 60.0 * CurrentStagePercentage;
                    case MicroTaskStates.Replacing:
                        return 70.0;
                    case MicroTaskStates.BuildingResult:
                        return 80.0;
                    case MicroTaskStates.SavingResult:
                        return 90.0;
                    case MicroTaskStates.Complete:
                        return 100.0;
                    default:
                        return 0.0;
                }
            }
        }

        #endregion

        /// <summary>
        /// Показывает, происходили ли изменения в статистике 
        /// со времени последнего доступа
        /// </summary>
        public bool Updated
        {
            get { lock (_syncStat) return _updated; }
        }

        public MicroTaskStatistics GetStatistics()
        {
            lock (_syncStat)
            {
                _updated = false;
                return new MicroTaskStatistics
                    {
                        Percentage = Percentage,
                        ReplacesCount = ReplacesCount,
                        State = State
                    };
            }
        }

        public bool Immutable { get; private set; }

        public MicroTask(TextFile textFile, RegexProcessor regexProcessor, Replacement replacement)
        {
            _file = textFile;
            _regex = regexProcessor;
            _replacement = replacement;
        }

        public void Run(CancellationToken cancellationToken)
        {
            lock (_busy)
            {
                if (Immutable) return;

                if (cancellationToken.IsCancellationRequested) return;
                State = MicroTaskStates.Reading;
                var text = _file.ReadText();
                var replacer = new TextReplacer(text);

                if (cancellationToken.IsCancellationRequested) return;
                State = MicroTaskStates.Searching;
                var matches = new List<RelatedMatch>();
                var m = _regex.RelatedMatch(text, 0, replacer);
                while (m.Success)
                {
                    CurrentStagePercentage = (double)(m.StartIndex + m.Length) / text.Length;
                    matches.Add(m);
                    if (cancellationToken.IsCancellationRequested) return;
                    m = _regex.RelatedMatch(text, m.StartIndex + m.Length, replacer);
                }
                if (matches.Count == 0) matches.Add(m);

                if (cancellationToken.IsCancellationRequested) return;

                if (!matches[0].Success)
                {
                    Immutable = true;
                    State = MicroTaskStates.Complete;
                    return;
                }

                State = MicroTaskStates.Replacing;
                foreach (var relatedMatch in matches)
                    replacer.Replace(relatedMatch, _replacement.CreateCopyWithGroups(relatedMatch));

                State = MicroTaskStates.BuildingResult;
                var result = replacer.BuildResult();
                ReplacesCount += matches.Count;

                if (cancellationToken.IsCancellationRequested) return;
                State = MicroTaskStates.SavingResult;
                //TODO _file.WriteText(result);

                State = MicroTaskStates.Complete;
            }
        }

        public void Cancel()
        {
            lock (_busy)
            {
                Debug.WriteLine("mCancel()");
                if (State == MicroTaskStates.Complete)
                    _file.RestoreBackup();
                State = MicroTaskStates.None;
            }
        } 
    }
}