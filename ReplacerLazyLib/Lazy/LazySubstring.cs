using System;

namespace Dem0n13.Replacer.Library.Lazy
{
    /// <summary>
    /// Класс, представляет неизменяемую "ленивую" подстроку,
    /// которая собирается только явным образом при помощи
    /// метода <see cref="BuildToString"/>
    /// </summary>
    public class LazySubstring
    {
        #region private fields

        private string _built;

        #endregion

        /// <summary>
        /// Строка-источник подстроки
        /// </summary>
        public string Source { get; private set; }

        /// <summary>
        /// Индекс начала подстроки
        /// </summary>
        public int StartIndex { get; private set; }

        /// <summary>
        /// Длина подстроки
        /// </summary>
        public int Length { get; private set; }

        /// <summary>
        /// Создает новую пустую подстроку
        /// </summary>
        public LazySubstring() : this(string.Empty)
        {
        }

        /// <summary>
        /// Создает новую подстроку из целой строки
        /// </summary>
        /// <param name="source">Строка-источник</param>
        /// <exception cref="ArgumentNullException">Строка-источник не может быть равен null</exception>
        public LazySubstring(string source) : this(source, 0, source.Length)
        {
        }

        /// <summary>
        /// Создает новую подстроку на основе строки
        /// </summary>
        /// <param name="source">Строка-источник</param>
        /// <param name="startIndex">Индекс начала подстроки</param>
        /// <exception cref="ArgumentOutOfRangeException">Подстрока должна лежать внутри строки</exception>
        /// <exception cref="ArgumentNullException">Строка-источник не может быть равен null</exception>
        public LazySubstring(string source, int startIndex)
            : this(source, startIndex, source.Length - startIndex)
        {
        }

        /// <summary>
        /// Создает новую подстроку на основе строки
        /// </summary>
        /// <param name="source">Строка-источник</param>
        /// <param name="startIndex">Индекс начала подстроки</param>
        /// <param name="length">Длина подстроки</param>
        /// <exception cref="ArgumentOutOfRangeException">Подстрока должна лежать внутри строки</exception>
        /// <exception cref="ArgumentNullException">Строка-источник не может быть равен null</exception>
        public LazySubstring(string source, int startIndex, int length)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (startIndex < 0 || length < 0 || startIndex + length > source.Length)
                throw new ArgumentOutOfRangeException();

            Source = source;
            StartIndex = startIndex;
            Length = length;
            if (startIndex == 0 && length == source.Length)
                _built = source;
        }

        /// <summary>
        /// Создает построку на основе существующей подстроки
        /// </summary>
        /// <param name="startIndex">Индекс начала новой подстроки относительно индекса начала существующей подстроки</param>
        /// <returns>Возвращает новую подстроку</returns>
        public LazySubstring Substring(int startIndex)
        {
            return new LazySubstring(Source, StartIndex + startIndex);
        }

        /// <summary>
        /// Создает построку на основе существующей подстроки
        /// </summary>
        /// <param name="startIndex">Индекс начала новой подстроки относительно индекса начала существующей подстроки</param>
        /// <param name="length">Длина новой подстроки</param>
        /// <returns>Возвращает новую подстроку</returns>
        public LazySubstring Substring(int startIndex, int length)
        {
            return new LazySubstring(Source, StartIndex + startIndex, length);
        }

        /// <summary>
        /// Однократно собирает ленивую подстроку в реальный экзепляр строки.
        /// При повторном вызове возвращает собранное ранее представление
        /// </summary>
        /// <returns>Собранная строка</returns>
        public string BuildToString()
        {
            return _built ?? (_built = ToString());
        }

        public override string ToString()
        {
            return Source.Substring(StartIndex, Length);
        }
    }
}
