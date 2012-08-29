namespace Dem0n13.Replacer.App
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnChooseFiles = new System.Windows.Forms.Button();
            this.RegExpBox = new System.Windows.Forms.TextBox();
            this.ReplacementBox = new System.Windows.Forms.TextBox();
            this.LogBox = new System.Windows.Forms.TextBox();
            this.RegExpCaption = new System.Windows.Forms.Label();
            this.ReplacementCaption = new System.Windows.Forms.Label();
            this.lblFileSelection = new System.Windows.Forms.Label();
            this.btnRegexStageNext = new System.Windows.Forms.Button();
            this.FilesSelectionStageLayout = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClearFileList = new System.Windows.Forms.Button();
            this.btnSaveFileList = new System.Windows.Forms.Button();
            this.boxFileList = new System.Windows.Forms.TextBox();
            this.btnOpenFileList = new System.Windows.Forms.Button();
            this.lblFileList = new System.Windows.Forms.Label();
            this.RegexStageLayout = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnFileSelectionStagePrev = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.PreviewStageBtn = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.PossibleMatchesCaption = new System.Windows.Forms.GroupBox();
            this.PossibleReplacesCaption = new System.Windows.Forms.GroupBox();
            this.PreviewStageLayout = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.barTask = new System.Windows.Forms.ProgressBar();
            this.barSummary = new System.Windows.Forms.ProgressBar();
            this.lblSummaryBar = new System.Windows.Forms.Label();
            this.lblTaskBar = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRegexStagePrev = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.FilesSelectionStageLayout.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.RegexStageLayout.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.PreviewStageLayout.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnChooseFiles
            // 
            this.btnChooseFiles.AutoSize = true;
            this.btnChooseFiles.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnChooseFiles.Location = new System.Drawing.Point(5, 36);
            this.btnChooseFiles.Margin = new System.Windows.Forms.Padding(5);
            this.btnChooseFiles.Name = "btnChooseFiles";
            this.btnChooseFiles.Size = new System.Drawing.Size(175, 27);
            this.btnChooseFiles.TabIndex = 0;
            this.btnChooseFiles.Text = "Select the files from drive...";
            this.btnChooseFiles.UseVisualStyleBackColor = true;
            this.btnChooseFiles.Click += new System.EventHandler(this.OpenFilesBtnClick);
            // 
            // RegExpBox
            // 
            this.RegExpBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RegExpBox.Font = new System.Drawing.Font("Consolas", 12F);
            this.RegExpBox.Location = new System.Drawing.Point(5, 66);
            this.RegExpBox.Margin = new System.Windows.Forms.Padding(5);
            this.RegExpBox.Multiline = true;
            this.RegExpBox.Name = "RegExpBox";
            this.RegExpBox.Size = new System.Drawing.Size(411, 279);
            this.RegExpBox.TabIndex = 1;
            this.RegExpBox.Text = "bookmark(\\d+?\")(.+?)bookmark\\1";
            // 
            // ReplacementBox
            // 
            this.ReplacementBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReplacementBox.Font = new System.Drawing.Font("Consolas", 12F);
            this.ReplacementBox.Location = new System.Drawing.Point(467, 66);
            this.ReplacementBox.Margin = new System.Windows.Forms.Padding(5);
            this.ReplacementBox.Multiline = true;
            this.ReplacementBox.Name = "ReplacementBox";
            this.ReplacementBox.Size = new System.Drawing.Size(411, 279);
            this.ReplacementBox.TabIndex = 3;
            this.ReplacementBox.Text = "b\\1\\2b\\1";
            // 
            // LogBox
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.LogBox, 3);
            this.LogBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogBox.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.LogBox.Location = new System.Drawing.Point(5, 36);
            this.LogBox.Margin = new System.Windows.Forms.Padding(5);
            this.LogBox.Multiline = true;
            this.LogBox.Name = "LogBox";
            this.LogBox.Size = new System.Drawing.Size(622, 346);
            this.LogBox.TabIndex = 5;
            // 
            // RegExpCaption
            // 
            this.RegExpCaption.AutoSize = true;
            this.RegExpCaption.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RegExpCaption.Location = new System.Drawing.Point(5, 36);
            this.RegExpCaption.Margin = new System.Windows.Forms.Padding(5);
            this.RegExpCaption.Name = "RegExpCaption";
            this.RegExpCaption.Size = new System.Drawing.Size(255, 20);
            this.RegExpCaption.TabIndex = 7;
            this.RegExpCaption.Text = "Регулярное выражение для поиска";
            // 
            // ReplacementCaption
            // 
            this.ReplacementCaption.AutoSize = true;
            this.ReplacementCaption.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ReplacementCaption.Location = new System.Drawing.Point(467, 36);
            this.ReplacementCaption.Margin = new System.Windows.Forms.Padding(5);
            this.ReplacementCaption.Name = "ReplacementCaption";
            this.ReplacementCaption.Size = new System.Drawing.Size(149, 20);
            this.ReplacementCaption.TabIndex = 8;
            this.ReplacementCaption.Text = "Выражение замены";
            // 
            // lblFileSelection
            // 
            this.lblFileSelection.AutoSize = true;
            this.lblFileSelection.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblFileSelection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))));
            this.lblFileSelection.Location = new System.Drawing.Point(5, 5);
            this.lblFileSelection.Margin = new System.Windows.Forms.Padding(5);
            this.lblFileSelection.Name = "lblFileSelection";
            this.lblFileSelection.Size = new System.Drawing.Size(235, 21);
            this.lblFileSelection.TabIndex = 11;
            this.lblFileSelection.Text = "1. Select the files for proccessing";
            // 
            // btnRegexStageNext
            // 
            this.btnRegexStageNext.AutoSize = true;
            this.btnRegexStageNext.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRegexStageNext.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnRegexStageNext.Location = new System.Drawing.Point(803, 598);
            this.btnRegexStageNext.Margin = new System.Windows.Forms.Padding(5);
            this.btnRegexStageNext.MinimumSize = new System.Drawing.Size(75, 0);
            this.btnRegexStageNext.Name = "btnRegexStageNext";
            this.btnRegexStageNext.Size = new System.Drawing.Size(75, 27);
            this.btnRegexStageNext.TabIndex = 12;
            this.btnRegexStageNext.Text = "Next";
            this.btnRegexStageNext.UseVisualStyleBackColor = true;
            this.btnRegexStageNext.Click += new System.EventHandler(this.RegexStageBtnClick);
            // 
            // FilesSelectionStageLayout
            // 
            this.FilesSelectionStageLayout.Controls.Add(this.tableLayoutPanel1);
            this.FilesSelectionStageLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FilesSelectionStageLayout.Location = new System.Drawing.Point(0, 0);
            this.FilesSelectionStageLayout.Name = "FilesSelectionStageLayout";
            this.FilesSelectionStageLayout.Size = new System.Drawing.Size(883, 630);
            this.FilesSelectionStageLayout.TabIndex = 13;
            this.FilesSelectionStageLayout.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnRegexStageNext, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.boxFileList, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnChooseFiles, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnOpenFileList, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblFileList, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblFileSelection, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(883, 630);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.btnClearFileList);
            this.flowLayoutPanel1.Controls.Add(this.btnSaveFileList);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 553);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(877, 37);
            this.flowLayoutPanel1.TabIndex = 19;
            // 
            // btnClearFileList
            // 
            this.btnClearFileList.AutoSize = true;
            this.btnClearFileList.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClearFileList.Location = new System.Drawing.Point(5, 5);
            this.btnClearFileList.Margin = new System.Windows.Forms.Padding(5);
            this.btnClearFileList.Name = "btnClearFileList";
            this.btnClearFileList.Size = new System.Drawing.Size(89, 27);
            this.btnClearFileList.TabIndex = 18;
            this.btnClearFileList.Text = "Clear file list";
            this.btnClearFileList.UseVisualStyleBackColor = true;
            this.btnClearFileList.Click += new System.EventHandler(this.ClearFilelistBtnClick);
            // 
            // btnSaveFileList
            // 
            this.btnSaveFileList.AutoSize = true;
            this.btnSaveFileList.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSaveFileList.Enabled = false;
            this.btnSaveFileList.Location = new System.Drawing.Point(104, 5);
            this.btnSaveFileList.Margin = new System.Windows.Forms.Padding(5);
            this.btnSaveFileList.MinimumSize = new System.Drawing.Size(75, 0);
            this.btnSaveFileList.Name = "btnSaveFileList";
            this.btnSaveFileList.Size = new System.Drawing.Size(86, 27);
            this.btnSaveFileList.TabIndex = 17;
            this.btnSaveFileList.Text = "Save file list";
            this.btnSaveFileList.UseVisualStyleBackColor = true;
            this.btnSaveFileList.Click += new System.EventHandler(this.SaveFilelistBtnClick);
            // 
            // boxFileList
            // 
            this.boxFileList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.boxFileList.Location = new System.Drawing.Point(3, 138);
            this.boxFileList.Multiline = true;
            this.boxFileList.Name = "boxFileList";
            this.boxFileList.ReadOnly = true;
            this.boxFileList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.boxFileList.Size = new System.Drawing.Size(877, 409);
            this.boxFileList.TabIndex = 19;
            this.boxFileList.Text = "Список пока пуст...\r\nВыберите файлы или откройте ранее сохраненный список.";
            // 
            // btnOpenFileList
            // 
            this.btnOpenFileList.AutoSize = true;
            this.btnOpenFileList.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOpenFileList.Enabled = false;
            this.btnOpenFileList.Location = new System.Drawing.Point(5, 73);
            this.btnOpenFileList.Margin = new System.Windows.Forms.Padding(5);
            this.btnOpenFileList.Name = "btnOpenFileList";
            this.btnOpenFileList.Size = new System.Drawing.Size(174, 27);
            this.btnOpenFileList.TabIndex = 15;
            this.btnOpenFileList.Text = "Open saved file list (.rlist)...";
            this.btnOpenFileList.UseVisualStyleBackColor = true;
            this.btnOpenFileList.Click += new System.EventHandler(this.OpenFilelistBtnClick);
            // 
            // lblFileList
            // 
            this.lblFileList.AutoSize = true;
            this.lblFileList.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFileList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))));
            this.lblFileList.Location = new System.Drawing.Point(5, 110);
            this.lblFileList.Margin = new System.Windows.Forms.Padding(5);
            this.lblFileList.Name = "lblFileList";
            this.lblFileList.Size = new System.Drawing.Size(196, 20);
            this.lblFileList.TabIndex = 16;
            this.lblFileList.Text = "Current files for proccessing:";
            // 
            // RegexStageLayout
            // 
            this.RegexStageLayout.Controls.Add(this.tableLayoutPanel2);
            this.RegexStageLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RegexStageLayout.Location = new System.Drawing.Point(0, 0);
            this.RegexStageLayout.Name = "RegexStageLayout";
            this.RegexStageLayout.Size = new System.Drawing.Size(883, 630);
            this.RegexStageLayout.TabIndex = 14;
            this.RegexStageLayout.Visible = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btnFileSelectionStagePrev, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.RegExpBox, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.RegExpCaption, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.ReplacementCaption, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.ReplacementBox, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.label4, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.PreviewStageBtn, 2, 5);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel2, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.PossibleMatchesCaption, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.PossibleReplacesCaption, 2, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.14286F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.85714F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(883, 630);
            this.tableLayoutPanel2.TabIndex = 14;
            // 
            // btnFileSelectionStagePrev
            // 
            this.btnFileSelectionStagePrev.AutoSize = true;
            this.btnFileSelectionStagePrev.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnFileSelectionStagePrev.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnFileSelectionStagePrev.Location = new System.Drawing.Point(5, 597);
            this.btnFileSelectionStagePrev.Margin = new System.Windows.Forms.Padding(5);
            this.btnFileSelectionStagePrev.MinimumSize = new System.Drawing.Size(75, 0);
            this.btnFileSelectionStagePrev.Name = "btnFileSelectionStagePrev";
            this.btnFileSelectionStagePrev.Size = new System.Drawing.Size(75, 28);
            this.btnFileSelectionStagePrev.TabIndex = 17;
            this.btnFileSelectionStagePrev.Text = "Prev";
            this.btnFileSelectionStagePrev.UseVisualStyleBackColor = true;
            this.btnFileSelectionStagePrev.Click += new System.EventHandler(this.FileSelectionStageBtnClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label3, 3);
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))));
            this.label3.Location = new System.Drawing.Point(5, 5);
            this.label3.Margin = new System.Windows.Forms.Padding(5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(384, 21);
            this.label3.TabIndex = 12;
            this.label3.Text = "2. Input the regular expression and replacement string";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(431, 71);
            this.label4.Margin = new System.Windows.Forms.Padding(10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 269);
            this.label4.TabIndex = 13;
            this.label4.Text = ">";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PreviewStageBtn
            // 
            this.PreviewStageBtn.AutoSize = true;
            this.PreviewStageBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PreviewStageBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.PreviewStageBtn.Location = new System.Drawing.Point(803, 597);
            this.PreviewStageBtn.Margin = new System.Windows.Forms.Padding(5);
            this.PreviewStageBtn.MinimumSize = new System.Drawing.Size(75, 0);
            this.PreviewStageBtn.Name = "PreviewStageBtn";
            this.PreviewStageBtn.Size = new System.Drawing.Size(75, 28);
            this.PreviewStageBtn.TabIndex = 14;
            this.PreviewStageBtn.Text = "Next";
            this.PreviewStageBtn.UseVisualStyleBackColor = true;
            this.PreviewStageBtn.Click += new System.EventHandler(this.PreviewStageBtnClick);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.SetColumnSpan(this.flowLayoutPanel2, 3);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 569);
            this.flowLayoutPanel2.MinimumSize = new System.Drawing.Size(20, 20);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(877, 20);
            this.flowLayoutPanel2.TabIndex = 15;
            // 
            // PossibleMatchesCaption
            // 
            this.PossibleMatchesCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PossibleMatchesCaption.Location = new System.Drawing.Point(5, 355);
            this.PossibleMatchesCaption.Margin = new System.Windows.Forms.Padding(5);
            this.PossibleMatchesCaption.MinimumSize = new System.Drawing.Size(20, 20);
            this.PossibleMatchesCaption.Name = "PossibleMatchesCaption";
            this.PossibleMatchesCaption.Size = new System.Drawing.Size(411, 206);
            this.PossibleMatchesCaption.TabIndex = 16;
            this.PossibleMatchesCaption.TabStop = false;
            this.PossibleMatchesCaption.Text = "PossibleMatchesCaption";
            // 
            // PossibleReplacesCaption
            // 
            this.PossibleReplacesCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PossibleReplacesCaption.Location = new System.Drawing.Point(467, 355);
            this.PossibleReplacesCaption.Margin = new System.Windows.Forms.Padding(5);
            this.PossibleReplacesCaption.MinimumSize = new System.Drawing.Size(20, 20);
            this.PossibleReplacesCaption.Name = "PossibleReplacesCaption";
            this.PossibleReplacesCaption.Size = new System.Drawing.Size(411, 206);
            this.PossibleReplacesCaption.TabIndex = 18;
            this.PossibleReplacesCaption.TabStop = false;
            this.PossibleReplacesCaption.Text = "PossibleReplacesCaption";
            // 
            // PreviewStageLayout
            // 
            this.PreviewStageLayout.Controls.Add(this.tableLayoutPanel3);
            this.PreviewStageLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PreviewStageLayout.Location = new System.Drawing.Point(0, 0);
            this.PreviewStageLayout.Name = "PreviewStageLayout";
            this.PreviewStageLayout.Size = new System.Drawing.Size(883, 630);
            this.PreviewStageLayout.TabIndex = 15;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.btnCancel, 2, 2);
            this.tableLayoutPanel3.Controls.Add(this.btnRegexStagePrev, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.LogBox, 0, 1);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(632, 453);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.barTask, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.barSummary, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.lblSummaryBar, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.lblTaskBar, 0, 2);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(85, 387);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 4;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.Size = new System.Drawing.Size(462, 66);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // barTask
            // 
            this.barTask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.barTask.Location = new System.Drawing.Point(3, 53);
            this.barTask.Name = "barTask";
            this.barTask.Size = new System.Drawing.Size(456, 10);
            this.barTask.Step = 1;
            this.barTask.TabIndex = 1;
            // 
            // barSummary
            // 
            this.barSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.barSummary.Location = new System.Drawing.Point(3, 20);
            this.barSummary.Name = "barSummary";
            this.barSummary.Size = new System.Drawing.Size(456, 10);
            this.barSummary.Step = 1;
            this.barSummary.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.barSummary.TabIndex = 0;
            // 
            // lblSummaryBar
            // 
            this.lblSummaryBar.AutoSize = true;
            this.lblSummaryBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSummaryBar.Location = new System.Drawing.Point(3, 0);
            this.lblSummaryBar.Name = "lblSummaryBar";
            this.lblSummaryBar.Size = new System.Drawing.Size(456, 17);
            this.lblSummaryBar.TabIndex = 2;
            this.lblSummaryBar.Text = "label2";
            // 
            // lblTaskBar
            // 
            this.lblTaskBar.AutoSize = true;
            this.lblTaskBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTaskBar.Location = new System.Drawing.Point(3, 33);
            this.lblTaskBar.Name = "lblTaskBar";
            this.lblTaskBar.Size = new System.Drawing.Size(456, 17);
            this.lblTaskBar.TabIndex = 3;
            this.lblTaskBar.Text = "label5";
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnCancel.Location = new System.Drawing.Point(552, 421);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(5);
            this.btnCancel.MinimumSize = new System.Drawing.Size(75, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 27);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
            // 
            // btnRegexStagePrev
            // 
            this.btnRegexStagePrev.AutoSize = true;
            this.btnRegexStagePrev.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRegexStagePrev.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnRegexStagePrev.Location = new System.Drawing.Point(5, 421);
            this.btnRegexStagePrev.Margin = new System.Windows.Forms.Padding(5);
            this.btnRegexStagePrev.MinimumSize = new System.Drawing.Size(75, 0);
            this.btnRegexStagePrev.Name = "btnRegexStagePrev";
            this.btnRegexStagePrev.Size = new System.Drawing.Size(75, 27);
            this.btnRegexStagePrev.TabIndex = 18;
            this.btnRegexStagePrev.Text = "btnCancel";
            this.btnRegexStagePrev.UseVisualStyleBackColor = true;
            this.btnRegexStagePrev.Click += new System.EventHandler(this.BtnPrevRegexStageClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel3.SetColumnSpan(this.label1, 3);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))));
            this.label1.Location = new System.Drawing.Point(5, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(622, 21);
            this.label1.TabIndex = 13;
            this.label1.Text = "3. Replacing...";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 630);
            this.Controls.Add(this.PreviewStageLayout);
            this.Controls.Add(this.FilesSelectionStageLayout);
            this.Controls.Add(this.RegexStageLayout);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Replacer";
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.FilesSelectionStageLayout.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.RegexStageLayout.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.PreviewStageLayout.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnChooseFiles;
        private System.Windows.Forms.TextBox RegExpBox;
        private System.Windows.Forms.TextBox ReplacementBox;
        private System.Windows.Forms.TextBox LogBox;
        private System.Windows.Forms.Label RegExpCaption;
        private System.Windows.Forms.Label ReplacementCaption;
        private System.Windows.Forms.Label lblFileSelection;
        private System.Windows.Forms.Button btnRegexStageNext;
        private System.Windows.Forms.Panel FilesSelectionStageLayout;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnClearFileList;
        private System.Windows.Forms.Button btnSaveFileList;
        private System.Windows.Forms.Button btnOpenFileList;
        private System.Windows.Forms.Label lblFileList;
        private System.Windows.Forms.TextBox boxFileList;
        private System.Windows.Forms.Panel RegexStageLayout;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button PreviewStageBtn;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.GroupBox PossibleMatchesCaption;
        private System.Windows.Forms.Button btnFileSelectionStagePrev;
        private System.Windows.Forms.GroupBox PossibleReplacesCaption;
        private System.Windows.Forms.Panel PreviewStageLayout;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button btnRegexStagePrev;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.ProgressBar barTask;
        private System.Windows.Forms.ProgressBar barSummary;
        private System.Windows.Forms.Label lblSummaryBar;
        private System.Windows.Forms.Label lblTaskBar;
    }
}

