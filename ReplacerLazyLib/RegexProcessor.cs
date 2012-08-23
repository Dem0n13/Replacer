﻿using System.Collections.Generic;
using System.Text.RegularExpressions;

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

        public RelatedMatch RelatedMatch(TextReplacer textReplacer, int startIndex)
        {
            return new RelatedMatch(_regex.Match(textReplacer.BuildResult(), startIndex), textReplacer);
        }

        public List<RelatedMatch> RelatedMatches(TextReplacer text)
        {
            var result = new List<RelatedMatch>();
            var m = RelatedMatch(text, 0);
            while (m.Success)
            {
                result.Add(m);
                m = RelatedMatch(text, m.StartIndex + m.Length);
            }
            if (result.Count == 0) result.Add(m);
            return result;
        }
    }
}
