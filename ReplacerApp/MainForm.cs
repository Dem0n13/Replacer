using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using Dem0n13.Replacer.Library;
using Dem0n13.Replacer.Library.Utils;

namespace Dem0n13.Replacer.App
{
    public partial class MainForm : Form
    {
        private TextFile _inputFile;

        private TextReplacer _replacer;
        private RegexProcessor _regex;
        private List<RelatedMatch> _matches;
        private Replacement _replacement;

        public MainForm()
        {
            InitializeComponent();
        }

        private void OpenFilesBtnClick(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                _inputFile = new TextFile(fileDialog.FileName);
                FilePathBox.Text = _inputFile.ToString();
            }
        }

        private void PreviewBtnClick(object sender, EventArgs e)
        {
            var sw = new Stopwatch();

            sw.Restart();
            _replacer = new TextReplacer(_inputFile.ReadText());
            LogBox.AppendText("Файл загружен" + Environment.NewLine);
            LogBox.AppendText(sw.ElapsedTicks + Environment.NewLine);

            sw.Restart();
            _regex = new RegexProcessor(RegExpBox.Text);
            LogBox.AppendText("Регулярное выражение собрано" + Environment.NewLine);

            _replacement = new Replacement(ReplaceBox.Text);
            LogBox.AppendText(sw.ElapsedTicks + Environment.NewLine);

            sw.Restart();
            _matches = _regex.Matches(_replacer);
            LogBox.AppendText(sw.ElapsedTicks + Environment.NewLine);
            if (_matches[0].Success)
            {
                LogBox.AppendText(_matches.Count + " совпадений" + Environment.NewLine);
                LaunchBtn.Enabled = true;
            }
            else
            {
                LogBox.AppendText("0 совпадений" + Environment.NewLine);
                LaunchBtn.Enabled = false;
            }
        }

        private void LaunchBtnClick(object sender, EventArgs e)
        {
            var sw = new Stopwatch();
            var sw1 = new Stopwatch();

            foreach (var textMatch in _matches)
            {
                sw.Start();
                var replacementStr = _replacement.CreateCopyWithGroups(textMatch);
                sw.Stop();
                sw1.Start();
                _replacer.Replace(textMatch, replacementStr);
                sw1.Stop();
            }

            LogBox.AppendText(sw.ElapsedTicks.ToString() + Environment.NewLine);
            LogBox.AppendText(sw1.ElapsedTicks.ToString() + Environment.NewLine);
            _inputFile.WriteText(_replacer.BuildResult());
        }
    }
}
