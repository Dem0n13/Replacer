using System.Text.RegularExpressions;

namespace Dem0n13.Replacer.Lib
{
    public class TextMatch
    {
        /// <summary>
        /// Самообновляемые координаты совпадения
        /// </summary>
        public TextListneningCoordinate Coordinate { get; private set; }

        /// <summary>
        /// Длина совпадения
        /// </summary>
        public int Length { get; private set; }

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

        public TextMatch(Match match, Text text)
        {
            Coordinate = new TextListneningCoordinate(match.Index, text);
            Success = match.Success;
            Length = match.Length;
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