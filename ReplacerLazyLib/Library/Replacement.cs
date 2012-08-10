using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Dem0n13.Replacer.LazyLibrary;

namespace Dem0n13.Replacer.Library
{
    public class Replacement
    {
        private Dictionary<Node<LazySubstring>, int> _groupsLinks = new Dictionary<Node<LazySubstring>, int>();
        private static readonly Regex Numbers = new Regex("\\d+", RegexOptions.Compiled);
        private LazyString _parcedWorkingCopy = new LazyString();
        private string _replacementString;

        public Replacement()
        {
            _replacementString = string.Empty;
            _parcedWorkingCopy.Append(new LazySubstring());
        }

        public Replacement(string replacementString)
        {
            if (replacementString == null)
                throw new ArgumentNullException("replacementString", "Строка замены не может быть равна null");

            _replacementString = replacementString;
            Parse(replacementString);
        }

        private void Parse(string pattern)
        {
            var buffer = new StringBuilder();   // буфер-накопитель
            var prevEscapeChar = false;         // признак экранирования предыдущим символом

            var currentLength = 0;

            for (int i = 0; i < pattern.Length; i++)
            {
                // если символ экранирован
                if (prevEscapeChar)
                {
                    // обратная ссылка
                    if (Char.IsDigit(pattern[i]))
                    {
                        currentLength--; // убираем последний \

                        // записываем накопленный буфер 
                        if (currentLength > 0) _parcedWorkingCopy.Append(new LazySubstring(pattern, i - currentLength - 1, currentLength));
                        currentLength = 0;

                        // получаем номер группы
                        var match = Numbers.Match(pattern, i);
                        var groupNum = Convert.ToInt32(match.Value);

                        // записываем и связываем номер группы с рабочей копией
                        _parcedWorkingCopy.Append(new LazySubstring(pattern, i - 1, match.Length + 1));
                        _groupsLinks.Add(_parcedWorkingCopy.Last, groupNum);

                        i += match.Length - 1;
                    }
                    else
                    {
                        // другой экранированный символ
                        currentLength++;
                    }
                    prevEscapeChar = false;
                }
                else
                {
                    if (pattern[i].Equals('\\'))
                        prevEscapeChar = true;

                    // любой символ - увеличиваем длину слова
                    currentLength++;
                }
            }

            if (currentLength != 0) _parcedWorkingCopy.Append(new LazySubstring(pattern, pattern.Length - currentLength, currentLength));
        }

        public LazyString CreateCopyWithGroups(RelatedMatch match)
        {
            if (match != null)
            {
                foreach (var link in _groupsLinks)
                {
                    if (match.Groups[link.Value].Success)
                    {
                        link.Key.Value = new LazySubstring(match.Groups[link.Value].Value);
                    }
                }
            }
            return _parcedWorkingCopy.CreateCopy();
        }

        public override string ToString()
        {
            return _replacementString;
        }
    }
}
