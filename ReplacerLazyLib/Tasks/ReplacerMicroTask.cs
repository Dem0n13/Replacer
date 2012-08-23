using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Dem0n13.Replacer.Library.Utils;

namespace Dem0n13.Replacer.Library.Tasks
{
    internal class ReplacerMicroTask
    {
        #region Perfomance
        public static readonly Dictionary<MicroTaskStates, long> PerfomanceVector =
            Enum.GetValues(typeof(MicroTaskStates)).Cast<MicroTaskStates>().ToDictionary(o => o, o => 0L);
        #endregion

        public static readonly MicroTaskStates[] StatesArray =
            Enum.GetValues(typeof (MicroTaskStates)).Cast<MicroTaskStates>().ToArray();
        private readonly TextFile _file;
        private readonly RegexProcessor _regex;
        private readonly Replacement _replacement;
        private readonly int _id;
        private static int _counter;

        private double _searchedTextPercentage;
        public MicroTaskStates State { get; private set; }
        public double Percentage
        {
            get
            {
                switch (State)
                {
                    case MicroTaskStates.None:
                        return 0.0;
                    case MicroTaskStates.Reading:
                        return 10.0;
                    case MicroTaskStates.Searching:
                        return 10.0 + 60.0*_searchedTextPercentage;
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
        public bool Immutable { get; private set; }
        
        public ReplacerMicroTask(TextFile textFile, RegexProcessor regexProcessor, Replacement replacement)
        {
            _file = textFile;
            _regex = regexProcessor;
            _replacement = replacement;
            _id = Interlocked.Increment(ref _counter);
            Debug.WriteLine("new MicroTask_" + _id);
        }

        public void Run()
        {
            if (Immutable) return;

            var sw = Stopwatch.StartNew();

            State = MicroTaskStates.Reading; //Debug.WriteLine("MicroTask_" + _id + ": " + State);
            var text = _file.ReadText();
            var replacer = new TextReplacer(text);

            lock (PerfomanceVector) PerfomanceVector[State] += sw.ElapsedTicks;
            sw.Restart();

            State = MicroTaskStates.Searching; //Debug.WriteLine("MicroTask_" + _id + ": " + State);
            var matches = new List<RelatedMatch>();
            var m = _regex.RelatedMatch(text, 0, replacer);
            while (m.Success)
            {
                _searchedTextPercentage = (double) (m.StartIndex + m.Length)/text.Length;
                //Console.WriteLine(_searchedTextPercentage);
                matches.Add(m);
                m = _regex.RelatedMatch(text, m.StartIndex + m.Length, replacer);
            }
            if (matches.Count == 0) matches.Add(m);

            if (!matches[0].Success)
            {
                Immutable = true;
                State = MicroTaskStates.Complete; //Debug.WriteLine("MicroTask_" + _id + ": " + State);
                return;
            }

            lock (PerfomanceVector) PerfomanceVector[State] += sw.ElapsedTicks;
            sw.Restart();

            State = MicroTaskStates.Replacing; //Debug.WriteLine("MicroTask_" + _id + ": " + State);
            foreach (var relatedMatch in matches)
                replacer.Replace(relatedMatch, _replacement.CreateCopyWithGroups(relatedMatch));

            lock (PerfomanceVector) PerfomanceVector[State] += sw.ElapsedTicks;
            sw.Restart();

            State = MicroTaskStates.BuildingResult; //Debug.WriteLine("MicroTask_" + _id + ": " + State);
            var result = replacer.BuildResult();

            lock (PerfomanceVector) PerfomanceVector[State] += sw.ElapsedTicks;
            sw.Restart();

            State = MicroTaskStates.SavingResult; //Debug.WriteLine("MicroTask_" + _id + ": " + State);
            //TODO _file.WriteText(result);

            lock (PerfomanceVector) PerfomanceVector[State] += sw.ElapsedTicks;
            sw.Stop();

            State = MicroTaskStates.Complete; //Debug.WriteLine("MicroTask_" + _id + ": " + State);
        }
    }
}
