using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using Dem0n13.Replacer.Lib;

namespace Dem0n13.Replacer.App
{
    public partial class MainForm : Form
    {
        private TextFile _inputFile;

        private Text _inputText;
        private RegexProcessor _regex;
        private List<TextMatch> _matches;
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
            _inputText = new Text(_inputFile.ReadText());
            LogBox.AppendText("Файл загружен" + Environment.NewLine);

            _regex = new RegexProcessor(RegExpBox.Text);
            LogBox.AppendText("Регулярное выражение собрано" + Environment.NewLine);

            _replacement = new Replacement(ReplaceBox.Text);
            if (_replacement.Immutable)
                LogBox.AppendText("Строка замены собрана" + Environment.NewLine);

            _matches = _regex.Matches(_inputText);
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
            foreach (var textMatch in _matches)
            {
                _inputText.Replace(textMatch, _replacement.Build(textMatch));
            }

            _inputFile.WriteText(_inputText.PlainText);
        }
    }
}
