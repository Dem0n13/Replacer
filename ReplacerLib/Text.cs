using System;
using System.Diagnostics;
using System.Text;

namespace Dem0n13.Replacer.Lib
{
    public class Text
    {
        public string PlainText { get; private set; }
        public event EventHandler<LengthChangedEventArgs> LengthChanged;
        private readonly StringBuilder _builder;

        public Text(string text)
        {
            PlainText = text;
            _builder = new StringBuilder(PlainText);
        }

        /// <summary>
        /// Изменить текст заменой совпадения на собранную строку замены
        /// </summary>
        /// <param name="match">Совпадение</param>
        /// <param name="replacement">Собранная строка замены</param>
        public void Replace(TextMatch match, string replacement)
        {
            if (!match.Success) return;

            Debug.Assert(match.Coordinate.Index + match.Length <= PlainText.Length, "Подстрока выходит за границу строки");
            
            var oldLength = PlainText.Length;

            /*
             * Оригинальная строка: С1+С2+С3
             * Результат: С1+С2'+С3
             */
            _builder.Length = 0;
            _builder.Append(PlainText.Substring(0, match.Coordinate.Index));
            _builder.Append(replacement);
            if (match.Coordinate.Index + match.Length < PlainText.Length)
                _builder.Append(PlainText.Substring(match.Coordinate.Index + match.Length));

            PlainText = _builder.ToString();

            // оповещаем об изменении длины
            if (oldLength != PlainText.Length)
            {
                var e = new LengthChangedEventArgs(oldLength, PlainText.Length, match.Coordinate.Index + match.Length);
                OnLengthChanged(e);
            }
        }

        private void OnLengthChanged(LengthChangedEventArgs e)
        {
            var handler = LengthChanged;
            if (handler != null) handler(this, e);
        }
    }
}
