using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Linq;
using System.Threading;
using Dem0n13.Replacer.Library.Utils;

namespace Dem0n13.Replacer.Library
{
    internal class MicroTask
    {
        public static readonly MicroTaskStates[] StatesArray =
            Enum.GetValues(typeof (MicroTaskStates)).Cast<MicroTaskStates>().ToArray();
        private readonly TextFile _file;
        private readonly RegexProcessor _regex;
        private readonly Replacement _replacement;
        private readonly int _id;
        private static int _counter;

        public MicroTaskStates State { get; private set; }
        public bool Immutable { get; private set; }
        
        public MicroTask(TextFile textFile, RegexProcessor regexProcessor, Replacement replacement)
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
            
            //State = MicroTaskStates.Reading; Debug.WriteLine("MicroTask_" + _id + ": " + State);
            var replacer = new TextReplacer(_file.ReadText());

            State = MicroTaskStates.Searching; //Debug.WriteLine("MicroTask_" + _id + ": " + State);
            var matches = _regex.RelatedMatches(replacer);

            if (!matches[0].Success)
            {
                Immutable = true;
                State = MicroTaskStates.Complete;
                //Debug.WriteLine("MicroTask_" + _id + ": " + State);
                return;
            }

            State = MicroTaskStates.Replacing; //Debug.WriteLine("MicroTask_" + _id + ": " + State);
            foreach (var relatedMatch in matches)
                replacer.Replace(relatedMatch, _replacement.CreateCopyWithGroups(relatedMatch));

            State = MicroTaskStates.BuildingResult; //Debug.WriteLine("MicroTask_" + _id + ": " + State);
            var result = replacer.BuildResult();

            State = MicroTaskStates.SavingResult; //Debug.WriteLine("MicroTask_" + _id + ": " + State);
            //TODO _file.WriteText(result);

            State = MicroTaskStates.Complete; //Debug.WriteLine("MicroTask_" + _id + ": " + State);
        }
        /*
        public override string ToString()
        {
            switch (State)
            {
                case MicroTaskStates.None:
                    break;
                case MicroTaskStates.Reading:
                    break;
                case MicroTaskStates.Searching:
                    break;
                case MicroTaskStates.Replacing:
                    break;
                case MicroTaskStates.BuildingResult:
                    break;
                case MicroTaskStates.SavingResult:
                    break;
                case MicroTaskStates.Complete:
                    break;
                case MicroTaskStates.Immutable:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }*/
    }
}
