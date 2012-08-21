using System;
using System.IO;

namespace Dem0n13.Replacer.Library.Utils
{
    public class TextFile
    {
        private readonly string _filePath;
        private readonly string _fileName;
        private readonly string _fileExtension;

        public string NewLine { get; set; }

        public string FullPath
        {
            get { return Path.Combine(_filePath, _fileName + _fileExtension); }
        }

        public TextFile(string path/* TODO опции */)
        {
            var fileName = Path.GetFileName(path);
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentException("Invalid file path","path");

            _fileName = Path.GetFileNameWithoutExtension(fileName);
            _fileExtension = Path.GetExtension(fileName);
            _filePath = Path.GetFullPath(path).Remove(path.Length - fileName.Length);

            NewLine = null;
        }
        
        /// <summary>
        /// Получает текст, содержащийся в источнике
        /// </summary>
        /// <returns>Текст</returns>
        public string ReadText()
        {
            // считываем текст из файла
            var text = File.ReadAllText(FullPath);

            // получаем первую строку
            string firstLine;
            using (var reader = new StringReader(text))
            {
                firstLine = reader.ReadLine();
            }
            if (string.IsNullOrEmpty(firstLine)) firstLine = string.Empty;

            // получаем перенос на новую строку
            if (text.Length > firstLine.Length)
            {
                switch (text[firstLine.Length])
                {
                    case '\r':
                        NewLine = "\r";
                        if (text.Length > firstLine.Length + 2 && text[firstLine.Length + 1].Equals('\n'))
                            NewLine = "\r\n";
                        else
                            NewLine = "\r";
                        break;
                    case '\n':
                        NewLine = "\n";
                        break;
                    default:
                        throw new NotSupportedException("Файлы с таким переносом не поддерживаются");
                }
            }
            else
            {
                NewLine = Environment.NewLine;
            }
            
            return text;
        }

        /// <summary>
        /// Записыпает текст в приемник
        /// </summary>
        /// <param name="text">Текст для записи</param>
        public void WriteText(string text)
        {
            // backup
            File.Copy(FullPath, Path.Combine(_filePath, _fileName + DateTime.Now.Ticks + _fileExtension));

            File.WriteAllText(FullPath, text);
        }

        public override string ToString()
        {
            return FullPath;
        }
    }
}