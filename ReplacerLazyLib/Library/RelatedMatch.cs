using System.Text.RegularExpressions;

namespace Dem0n13.Replacer.Library
{
    public class RelatedMatch : RelatedLocation
    {
        /// <summary>
        /// Успешность совпадения
        /// </summary>
        public bool Success { get; private set; }

        /// <summary>
        /// Группы в совпадении
        /// </summary>
        public GroupCollection Groups { get; private set; }

        /// <summary>
        /// Возвращает всю строку-совпадение
        /// </summary>
        public string FullMatchString
        {
            get { return Groups[0].Value; } // Groups всегда содержит как минимум 1 элемент
        }

        public RelatedMatch(Match match)
        {
            StartIndex = match.Index;
            Length = match.Length;
            Success = match.Success;
            Groups = match.Groups;
        }

        public new string ToString()
        {
            if (Success)
                if (Groups.Count > 1)
                    return string.Format("Success: {0} groups", Groups.Count);
                else
                    return "Success: " + FullMatchString;
            return "Fail";
        }
    }
}