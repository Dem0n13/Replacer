using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Dem0n13.Replacer.Lib
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

        public TextMatch Match(Text text, int startIndex)
        {
            return new TextMatch(_regex.Match(text.PlainText, startIndex), text);
        }

        public List<TextMatch> Matches(Text text)
        {
            var result = new List<TextMatch>();
            var m = Match(text, 0);
            while (m.Success)
            {
                result.Add(m);
                m = Match(text, m.Coordinate.Index + m.Length);
            }
            if (result.Count == 0) result.Add(m);
            return result;
        }
    }
}
