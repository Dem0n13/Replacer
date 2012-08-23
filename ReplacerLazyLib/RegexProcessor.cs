using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading;
using Dem0n13.Replacer.Library.Utils;

namespace Dem0n13.Replacer.Library
{
    /// <summary>
    /// 
    /// </summary>
    public class RegexProcessor
    {
        private readonly Regex _regex;
        public static long PerfomanceCounter;
        
        public RegexProcessor(string pattern)
        {
            // TODO обработка исключений
            _regex = new Regex(pattern, RegexOptions.Compiled | RegexOptions.Singleline);
        }

        public RelatedMatch RelatedMatch(string text, int startIndex, TextLengthChanger owner = null)
        {
            var sw = Stopwatch.StartNew();
            var match = _regex.Match(text, startIndex);
            Interlocked.Add(ref PerfomanceCounter, sw.ElapsedTicks);
            return new RelatedMatch(match, owner);
        }

        public List<RelatedMatch> RelatedMatches(string text, TextLengthChanger owner = null)
        {
            var result = new List<RelatedMatch>();
            var m = RelatedMatch(text, 0, owner);
            while (m.Success)
            {
                result.Add(m);
                m = RelatedMatch(text, m.StartIndex + m.Length, owner);
            }
            if (result.Count == 0) result.Add(m);
            return result;
        }
    }
}
