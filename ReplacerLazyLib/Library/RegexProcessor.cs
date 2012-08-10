using System.Collections.Generic;
using System.Text.RegularExpressions;
//using Dem0n13.Replacer.LazyLibrary;

namespace Dem0n13.Replacer.Library
{
    /// <summary>
    /// 
    /// </summary>
    public class RegexProcessor
    {
        private readonly Regex _regex;
        
        public RegexProcessor(string pattern)
        {
            // TODO обработка исключений
            _regex = new Regex(pattern, RegexOptions.Compiled | RegexOptions.Singleline);
        }

        public RelatedMatch Match(TextReplacer text, int startIndex)
        {
            return new RelatedMatch(_regex.Match(text.BuildResult(), startIndex));
        }

        public List<RelatedMatch> Matches(TextReplacer text)
        {
            var result = new List<RelatedMatch>();
            var m = Match(text, 0);
            while (m.Success)
            {
                result.Add(m);
                m = Match(text, m.StartIndex + m.Length);
            }
            if (result.Count == 0) result.Add(m);
            return result;
        }
    }
}
