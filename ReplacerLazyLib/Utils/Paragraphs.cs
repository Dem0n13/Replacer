using System;
using System.Collections.Generic;

namespace Dem0n13.Replacer.Library.Utils
{
    /// <summary>
    /// Класс-генератор коллекций строк, разделенных по переносу
    /// </summary>
    /// <typeparam name="T">Тип коллекции строк, унаследованной от <see cref="T:System.Collections.ICollection"/></typeparam>
    [Obsolete]
    public static class Paragraphs<T> where T : ICollection<string>, new()
    {
        /// <summary>
        /// Создать коллекцию строк, разделенных по переносу
        /// </summary>
        /// <param name="input">Исходный текст</param>
        /// <param name="newLine">Строка - платформозафисимый перенос</param>
        /// <returns>Коллекция строк</returns>
        public static T Create(ref string input, string newLine)
        {
            var result = new T();

            var startIndex = 0;
            var index = input.IndexOf(newLine, StringComparison.Ordinal);

            while (index != -1)
            {
                result.Add(input.Substring(startIndex, index - startIndex + newLine.Length));
                startIndex = index + newLine.Length;
                index = input.IndexOf(newLine, startIndex, StringComparison.Ordinal);
            }
            
            // дозапись последней строки
            if (startIndex < input.Length)
                result.Add(input.Substring(startIndex, input.Length - startIndex));

            return result;
        }
    }
}