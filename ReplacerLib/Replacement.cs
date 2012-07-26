﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Dem0n13.Replacer.Lib
{
    public class Replacement
    {
        public bool Immutable;
        private readonly List<object> _parsedString;
        private string _lastBuilt;
        private static readonly Regex Numbers = new Regex("\\d+", RegexOptions.Compiled);

        public Replacement()
        {
            Immutable = true;
            _lastBuilt = string.Empty;
        }

        public Replacement(string replacementString)
        {
            if (replacementString == null)
                throw new ArgumentNullException("replacementString", "Строка замены не может быть равна null");

            _parsedString = Parse(replacementString);

            _lastBuilt = Build(null);
            if (_lastBuilt != null)
                Immutable = true;
        }

        private static List<object> Parse(string pattern)
        {
            var result = new List<object>();
            var buffer = new StringBuilder();   // буфер-накопитель
            var prevEscapeChar = false;         // признак экранирования предыдущим символом

            for (var i = 0; i < pattern.Length; i++)
            {
                // если символ экранирован
                if (prevEscapeChar)
                {
                    // обратная ссылка
                    if (Char.IsDigit(pattern[i]))
                    {
                        // получаем номер группы
                        var match = Numbers.Match(pattern, i);

                        // записываем накопленный буфер и номер группы
                        if (buffer.Length != 0) result.Add(buffer.ToString());
                        buffer.Clear();

                        result.Add(Convert.ToInt32(match.Value));
                        i += match.Length - 1;
                    }
                    else
                    {
                        buffer.Append("\\").Append(pattern[i]);
                    }
                    prevEscapeChar = false;
                }
                else
                {
                    if (pattern[i].Equals('\\'))
                        prevEscapeChar = true;
                    else
                        buffer.Append(pattern[i]);
                }
            }

            if (buffer.Length != 0) result.Add(buffer.ToString());

            return result;
        }
        
        public string Build(TextMatch match)
        {
            // предотвращение повторной сборки неизменяемого выражения
            if (Immutable) return _lastBuilt;

            var buffer = new StringBuilder();

            foreach (var obj in _parsedString)
            {
                if (obj is string) // строка - переписываем без изменений
                {
                    buffer.Append(obj);
                }
                else if (obj is int) // номер группы
                {
                    var groupIndex = (int)obj;

                    if (match != null && match.Groups[groupIndex].Success)
                    {
                        buffer.Append(match.Groups[groupIndex].Value);
                    }
                    else
                    {
                        if (groupIndex < 10)
                            return null;
                        buffer.Append("\\").Append(groupIndex);
                    }
                }
            }

            return _lastBuilt = buffer.ToString();
        }
    }
}