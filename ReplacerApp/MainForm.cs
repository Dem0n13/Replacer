using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Security.Permissions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dem0n13.LocalizationLibrary;
using Dem0n13.Replacer.App.Properties;
using Dem0n13.Replacer.Library;
using Dem0n13.Replacer.Library.Tasks;
using Dem0n13.Replacer.Library.Utils;
using System.ComponentModel;
using System.Resources;
using LocalizationLibrary;
using Task = Dem0n13.Replacer.Library.Tasks.Task;

namespace Dem0n13.Replacer.App
{
    public partial class MainForm : Form
    {
        private LocalizationManager _localizationManager;
        private TaskManager _taskManager;
        private Progress _progress;
        private List<string> _logBoxSource = new List<string>(); 

        public MainForm()
        {
            InitializeComponent();
            InitializeLocalization();
            var asmName = Assembly.GetExecutingAssembly().GetName();
            Text = string.Format("{0} v.{1}", asmName.Name, asmName.Version);
        }

        private void InitializeLocalization()
        {
            _localizationManager = new LocalizationManager("Language");
            _localizationManager.ApplyResource(lblFileSelection, "Text", "FileSelectionCaption");
            _localizationManager.ApplyResource(btnChooseFiles, "Text", "SelectFiles");
            _localizationManager.ApplyResource(btnOpenFileList, "Text", "OpenFileList");
            _localizationManager.ApplyResource(lblFileList, "Text", "FileListCaption");
            _localizationManager.ApplyResource(boxFileList, "Text", "EmptyFileList");
            _localizationManager.ApplyResource(btnClearFileList, "Text", "ClearFileList");
            _localizationManager.ApplyResource(btnSaveFileList, "Text", "SaveFileList");
            _localizationManager.ApplyResource(btnRegexStageNext, "Text", "RegexStageNext");

            _localizationManager.ApplyResource(btnFileSelectionStagePrev, "Text", "FileSelectionStagePrev");

            _localizationManager.ApplyResource(btnRegexStagePrev, "Text", "RegexStagePrev");
            _localizationManager.ApplyResource(btnCancel, "Text", "Cancel");
        }

        private void MainFormLoad(object sender, EventArgs e)
        {
            SwitchUIStage(ReplacerStages.FilesSelection);
            _progress = new Progress();
            _progress.ProgressChanged += ProgressOnProgressChanged;
            _taskManager = new TaskManager(_progress);
        }

        #region Navigation

        private void SwitchUIStage(ReplacerStages stage)
        {
            Control visibleLayout = null;
            switch (stage)
            {
                case ReplacerStages.FilesSelection:
                    visibleLayout = FilesSelectionStageLayout;
                    break;
                case ReplacerStages.RegexInput:
                    visibleLayout = RegexStageLayout;
                    break;
                case ReplacerStages.Preview:
                    visibleLayout = PreviewStageLayout;
                    _localizationManager.ApplyResource(btnCancel, "Text", "Cancel");
                    btnCancel.Enabled = true;
                    _localizationManager.ApplyResource(btnRegexStagePrev, "Text", "RegexStagePrev");
                    btnRegexStagePrev.Enabled = false;
                    break;
                case ReplacerStages.Replacing:
                    //break;
                default:
                    //visibleLayout = FilesSelectionStageLayout;
                    break;
            }
            foreach (var controlObj in Controls)
            {
                var control = controlObj as Control;
                if (control == null) continue;

                if (control.Name.Contains("StageLayout"))
                {
                    control.Visible = control == visibleLayout;
                }
            }
        }

        #endregion

        #region FilesPickerPath

        private readonly List<TextFile> _inputFiles = new List<TextFile>();

        private void OpenFilesBtnClick(object sender, EventArgs e)
        {
            using (var fileDialog = new OpenFileDialog { Multiselect = true })
            {
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (_localizationManager.HasResource(boxFileList, "Text"))
                    {
                        _localizationManager.CleanResource(boxFileList, "Text");
                        boxFileList.Clear();

                        _localizationManager.ApplyResource(btnChooseFiles, "Text", "AddFiles");
                    }

                    foreach (var fileName in fileDialog.FileNames)
                    {
                        var textFile = new TextFile(fileName);
                        _inputFiles.Add(textFile);
                        boxFileList.AppendText(textFile + Environment.NewLine);
                    }
                }
            }
        }

        private void OpenFilelistBtnClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ClearFilelistBtnClick(object sender, EventArgs e)
        {
            _inputFiles.Clear();
            
            _localizationManager.ApplyResource(btnChooseFiles, "Text", "SelectFiles");
            _localizationManager.ApplyResource(boxFileList, "Text", "EmptyFileList");
        }

        private void SaveFilelistBtnClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void RegexStageBtnClick(object sender, EventArgs e)
        {
            if (_inputFiles.Count == 0)
            {
                MessageBox.Show(_localizationManager.GetString("EmptyFileList"),
                                _localizationManager.GetString("EmptyFileListCaption"),
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SwitchUIStage(ReplacerStages.RegexInput);
        }

        #endregion

        #region RegexInput

        private void FileSelectionStageBtnClick(object sender, EventArgs e)
        {
            SwitchUIStage(ReplacerStages.FilesSelection);
        }

        private void PreviewStageBtnClick(object sender, EventArgs e)
        {
            if (RegExpBox.Text.Length == 0)
            {
                MessageBox.Show(_localizationManager.GetString("EmptyRegex"),
                                _localizationManager.GetString("EmptyRegexCaption"),
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            SwitchUIStage(ReplacerStages.Preview);

            _taskManager.Tasks.Clear();
            _taskManager.Tasks.Add(new Task(_inputFiles, RegExpBox.Text, ReplacementBox.Text));
            _taskManager.RunAllAsync();
        }

        private void ProgressOnProgressChanged(object sender, ManagerProgressChangedEventArgs args)
        {
            if (!_taskManager.Busy)
            {
                btnRegexStagePrev.Enabled = true;
                _localizationManager.ApplyResource(btnCancel, "Text", "Ready");
                _logBoxSource.Add(_localizationManager.GetString("Ready"));
            }
            else
            {
                var vector = args.UserState as Dictionary<MicroTaskStates, int>;
                if (vector != null)
                {
                    var logOffset = 8 * args.TaskIndex;
                    barTask.Value = args.ProgressPercentage;
                    lblTaskBar.Text = string.Format(" Task {1}/{2}: {0}%", barTask.Value, args.TaskIndex + 1,
                                                    _taskManager.Tasks.Count);
                    barSummary.Value = args.ProgressPercentage / _taskManager.Tasks.Count;
                    lblSummaryBar.Text = string.Format("Total: {0}%", barSummary.Value);
                    if (LogBox.Lines.Length < logOffset + 1)
                    {
                        _logBoxSource.AddRange(new[] { "", "", "", "", "", "", "", "" });
                    }
                    _logBoxSource[logOffset] = "Task " + (args.TaskIndex + 1);
                    for (var i = 1; i < MicroTaskStatesHelper.StatesArray.Length; i++)
                    {
                        _logBoxSource[i + logOffset] = string.Format("{0}: {1}/{2}",
                                                                     MicroTaskStatesHelper.StatesArray[i],
                                                                     vector[MicroTaskStatesHelper.StatesArray[i]],
                                                                     vector[MicroTaskStates.None]);
                    }
                }
            }
            LogBox.Lines = _logBoxSource.ToArray();
        }

        #endregion

        private void BtnPrevRegexStageClick(object sender, EventArgs e)
        {
            if (!_taskManager.Busy)
                SwitchUIStage(ReplacerStages.RegexInput);
        }

        private void BtnCancelClick(object sender, EventArgs e)
        {
            if (_taskManager.Busy)
            {
                if (MessageBox.Show(_localizationManager.GetString("RestoreBackupQuestion"),
                                    _localizationManager.GetString("RestoreBackupQuestionCaption"),
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                    MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    _taskManager.CancelAsync();
                else
                    _taskManager.StopAsync();
                _localizationManager.ApplyResource(btnCancel, "Text", "Cancellation");
                btnCancel.Enabled = false;
            }
            else if (MessageBox.Show(_localizationManager.GetString("CancelQuestion"),
                                     _localizationManager.GetString("CancelQuestionCaption"),
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                _taskManager.CancelAsync();
                _localizationManager.ApplyResource(btnCancel, "Text", "Cancellation");
                btnCancel.Enabled = false;
            }
        }
    }
}
