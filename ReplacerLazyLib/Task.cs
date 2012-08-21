using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using Dem0n13.Replacer.Library.Utils;

namespace Dem0n13.Replacer.Library
{
    public class Task
    {
        private readonly TextFile[] _files;
        private readonly TextReplacer[] _textReplacer;
        private RegexProcessor _regexProcessor;
        private Replacement _replacement;
        public event EventHandler ProgressChanged;

        private void OnProgressChanged(EventArgs e)
        {
            var handler = ProgressChanged;
            if (handler != null) handler(this, e);
        }

        public Task(IEnumerable<TextFile> files, string regularExpression,
                    string replacementExpression, object options = null)
        {
            _regexProcessor = new RegexProcessor(regularExpression);
            _replacement = new Replacement(replacementExpression);
            _textReplacer = new TextReplacer[_files.Length];
            _files = files.ToArray();
        }

        private void Run()
        {
            for (var i = 0; i < _files.Length; i++)
            {
                RunFile(i);
            }
        }

        private void RunFile(int i)
        {
            LoadFile(i);
            // Match
            // replace
            // save
        }

        private bool LoadFile(int i)
        {
            try
            {
                var str = _files[i].ReadText();
                var replacer = new TextReplacer(str);
                lock (_textReplacer) _textReplacer[i] = replacer;
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
            
        }
    }
}
