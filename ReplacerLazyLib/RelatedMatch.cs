﻿using System.Text.RegularExpressions;
using Dem0n13.Replacer.Library.Utils;

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

        public RelatedMatch(Match match, TextLengthChanger owner = null)
        {
            StartIndex = match.Index;
            Length = match.Length;
            Success = match.Success;
            Groups = match.Groups;
            if (owner != null) SetOwner(owner);
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