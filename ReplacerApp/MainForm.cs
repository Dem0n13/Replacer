﻿using System;
using System.Collections.Generic;
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

namespace Dem0n13.Replacer.App
{
    public partial class MainForm : Form
    {
        private LocalizationManager _localizationManager;

        public MainForm()
        {
            InitializeComponent();
            InitializeLocalization();
            var asmName = Assembly.GetExecutingAssembly().GetName();
            Text = string.Format("{0} v.{1}", asmName.Name, asmName.Version);
            SwitchStage(ReplacerStages.FilesSelection);
            //var context = TaskScheduler.FromCurrentSynchronizationContext();
            _replacerTaskManager = new ReplacerTaskManager(TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void InitializeLocalization()
        {
            _localizationManager = new LocalizationManager("Language");
            _localizationManager.ApplyResource(FileSelectionCaption, "Text", "FileSelectionCaption");
            _localizationManager.ApplyResource(ChooseFilesBtn, "Text", "SelectFiles");
            _localizationManager.ApplyResource(OpenFileListBtn, "Text", "OpenFileList");
            _localizationManager.ApplyResource(FileListCaption, "Text", "FileListCaption");
            _localizationManager.ApplyResource(FileListBox, "Text", "EmptyFileList");
            _localizationManager.ApplyResource(ClearFileListBtn, "Text", "ClearFileList");
            _localizationManager.ApplyResource(SaveFileListBtn, "Text", "SaveFileList");
            _localizationManager.ApplyResource(RegexStageBtn, "Text", "Next");
        }

        #region Navigation

        private void SwitchStage(ReplacerStages stage)
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
                    if (_localizationManager.HasResource(FileListBox, "Text"))
                    {
                        _localizationManager.CleanResource(FileListBox, "Text");
                        FileListBox.Clear();

                        _localizationManager.ApplyResource(ChooseFilesBtn, "Text", "AddFiles");
                    }

                    foreach (var fileName in fileDialog.FileNames)
                    {
                        var textFile = new TextFile(fileName);
                        _inputFiles.Add(textFile);
                        FileListBox.AppendText(textFile + Environment.NewLine);
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
            
            _localizationManager.ApplyResource(ChooseFilesBtn, "Text", "SelectFiles");
            _localizationManager.ApplyResource(FileListBox, "Text", "EmptyFileList");
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
            SwitchStage(ReplacerStages.RegexInput);
        }

        #endregion

        #region RegexInput

        private void FileSelectionStageBtnClick(object sender, EventArgs e)
        {
            SwitchStage(ReplacerStages.FilesSelection);
        }


        private ReplacerTaskManager _replacerTaskManager;

        private void PreviewStageBtnClick(object sender, EventArgs e)
        {
            if (RegExpBox.Text.Length == 0)
            {
                MessageBox.Show(_localizationManager.GetString("EmptyRegex"),
                                _localizationManager.GetString("EmptyRegexCaption"),
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            SwitchStage(ReplacerStages.Preview);
            _replacerTaskManager.ProgressChanged += ReplacerTaskManagerOnProgressChanged;

            _replacerTaskManager.Tasks.Clear();
            _replacerTaskManager.Tasks.Add(new ReplacerTask(_inputFiles, RegExpBox.Text, ReplacementBox.Text));
            _replacerTaskManager.RunAll();
        }

        private void ReplacerTaskManagerOnProgressChanged(object sender, ManagerProgressChangedEventArgs args)
        {
            LogBox.AppendText(string.Format("{0}: {1}", args.CurrentItem, args.ProgressPercentage));
        }

        #endregion

        private void CancelBtnClick(object sender, EventArgs e)
        {
            SwitchStage(ReplacerStages.RegexInput);
        }
    }
}
