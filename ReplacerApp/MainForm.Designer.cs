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
            this.ChooseFilesBtn = new System.Windows.Forms.Button();
            this.RegExpBox = new System.Windows.Forms.TextBox();
            this.ReplacementBox = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.LogBox = new System.Windows.Forms.TextBox();
            this.PreviewBtn = new System.Windows.Forms.Button();
            this.RegExpCaption = new System.Windows.Forms.Label();
            this.ReplacementCaption = new System.Windows.Forms.Label();
            this.LaunchBtn = new System.Windows.Forms.Button();
            this.FileSelectionCaption = new System.Windows.Forms.Label();
            this.RegexStageBtn = new System.Windows.Forms.Button();
            this.FilesSelectionStageLayout = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.ClearFileListBtn = new System.Windows.Forms.Button();
            this.SaveFileListBtn = new System.Windows.Forms.Button();
            this.FileListBox = new System.Windows.Forms.TextBox();
            this.OpenFileListBtn = new System.Windows.Forms.Button();
            this.FileListCaption = new System.Windows.Forms.Label();
            this.RegexStageLayout = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.FileSelectionStageBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.PreviewStageBtn = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.PossibleMatchesCaption = new System.Windows.Forms.GroupBox();
            this.PossibleReplacesCaption = new System.Windows.Forms.GroupBox();
            this.FilesSelectionStageLayout.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.RegexStageLayout.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ChooseFilesBtn
            // 
            this.ChooseFilesBtn.AutoSize = true;
            this.ChooseFilesBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ChooseFilesBtn.Location = new System.Drawing.Point(5, 36);
            this.ChooseFilesBtn.Margin = new System.Windows.Forms.Padding(5);
            this.ChooseFilesBtn.Name = "ChooseFilesBtn";
            this.ChooseFilesBtn.Size = new System.Drawing.Size(175, 27);
            this.ChooseFilesBtn.TabIndex = 0;
            this.ChooseFilesBtn.Text = "Select the files from drive...";
            this.ChooseFilesBtn.UseVisualStyleBackColor = true;
            this.ChooseFilesBtn.Click += new System.EventHandler(this.OpenFilesBtnClick);
            // 
            // RegExpBox
            // 
            this.RegExpBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RegExpBox.Font = new System.Drawing.Font("Consolas", 12F);
            this.RegExpBox.Location = new System.Drawing.Point(5, 66);
            this.RegExpBox.Margin = new System.Windows.Forms.Padding(5);
            this.RegExpBox.Multiline = true;
            this.RegExpBox.Name = "RegExpBox";
            this.RegExpBox.Size = new System.Drawing.Size(281, 171);
            this.RegExpBox.TabIndex = 1;
            // 
            // ReplacementBox
            // 
            this.ReplacementBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReplacementBox.Font = new System.Drawing.Font("Consolas", 12F);
            this.ReplacementBox.Location = new System.Drawing.Point(337, 66);
            this.ReplacementBox.Margin = new System.Windows.Forms.Padding(5);
            this.ReplacementBox.Multiline = true;
            this.ReplacementBox.Name = "ReplacementBox";
            this.ReplacementBox.Size = new System.Drawing.Size(282, 171);
            this.ReplacementBox.TabIndex = 3;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(1030, 20);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(138, 21);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "Блокировать файл";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // LogBox
            // 
            this.LogBox.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.LogBox.Location = new System.Drawing.Point(670, 170);
            this.LogBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LogBox.Multiline = true;
            this.LogBox.Name = "LogBox";
            this.LogBox.Size = new System.Drawing.Size(230, 200);
            this.LogBox.TabIndex = 5;
            // 
            // PreviewBtn
            // 
            this.PreviewBtn.Location = new System.Drawing.Point(710, 70);
            this.PreviewBtn.Name = "PreviewBtn";
            this.PreviewBtn.Size = new System.Drawing.Size(230, 30);
            this.PreviewBtn.TabIndex = 6;
            this.PreviewBtn.Text = "Поиск совпадений";
            this.PreviewBtn.UseVisualStyleBackColor = true;
            this.PreviewBtn.Click += new System.EventHandler(this.PreviewBtnClick);
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
            this.ReplacementCaption.Location = new System.Drawing.Point(337, 36);
            this.ReplacementCaption.Margin = new System.Windows.Forms.Padding(5);
            this.ReplacementCaption.Name = "ReplacementCaption";
            this.ReplacementCaption.Size = new System.Drawing.Size(149, 20);
            this.ReplacementCaption.TabIndex = 8;
            this.ReplacementCaption.Text = "Выражение замены";
            // 
            // LaunchBtn
            // 
            this.LaunchBtn.Enabled = false;
            this.LaunchBtn.Location = new System.Drawing.Point(700, 120);
            this.LaunchBtn.Name = "LaunchBtn";
            this.LaunchBtn.Size = new System.Drawing.Size(230, 30);
            this.LaunchBtn.TabIndex = 9;
            this.LaunchBtn.Text = "Замена совпадений";
            this.LaunchBtn.UseVisualStyleBackColor = true;
            this.LaunchBtn.Click += new System.EventHandler(this.LaunchBtnClick);
            // 
            // FileSelectionCaption
            // 
            this.FileSelectionCaption.AutoSize = true;
            this.FileSelectionCaption.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.FileSelectionCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))));
            this.FileSelectionCaption.Location = new System.Drawing.Point(5, 5);
            this.FileSelectionCaption.Margin = new System.Windows.Forms.Padding(5);
            this.FileSelectionCaption.Name = "FileSelectionCaption";
            this.FileSelectionCaption.Size = new System.Drawing.Size(235, 21);
            this.FileSelectionCaption.TabIndex = 11;
            this.FileSelectionCaption.Text = "1. Select the files for proccessing";
            // 
            // RegexStageBtn
            // 
            this.RegexStageBtn.AutoSize = true;
            this.RegexStageBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.RegexStageBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.RegexStageBtn.Location = new System.Drawing.Point(544, 410);
            this.RegexStageBtn.Margin = new System.Windows.Forms.Padding(5);
            this.RegexStageBtn.MinimumSize = new System.Drawing.Size(75, 0);
            this.RegexStageBtn.Name = "RegexStageBtn";
            this.RegexStageBtn.Size = new System.Drawing.Size(75, 27);
            this.RegexStageBtn.TabIndex = 12;
            this.RegexStageBtn.Text = "Next";
            this.RegexStageBtn.UseVisualStyleBackColor = true;
            this.RegexStageBtn.Click += new System.EventHandler(this.RegexStageBtnClick);
            // 
            // FilesSelectionStageLayout
            // 
            this.FilesSelectionStageLayout.Controls.Add(this.tableLayoutPanel1);
            this.FilesSelectionStageLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FilesSelectionStageLayout.Location = new System.Drawing.Point(0, 0);
            this.FilesSelectionStageLayout.Name = "FilesSelectionStageLayout";
            this.FilesSelectionStageLayout.Size = new System.Drawing.Size(624, 442);
            this.FilesSelectionStageLayout.TabIndex = 13;
            this.FilesSelectionStageLayout.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.RegexStageBtn, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.FileListBox, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.ChooseFilesBtn, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.OpenFileListBtn, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.FileListCaption, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.FileSelectionCaption, 0, 0);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(624, 442);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.ClearFileListBtn);
            this.flowLayoutPanel1.Controls.Add(this.SaveFileListBtn);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 365);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(618, 37);
            this.flowLayoutPanel1.TabIndex = 19;
            // 
            // ClearFileListBtn
            // 
            this.ClearFileListBtn.AutoSize = true;
            this.ClearFileListBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClearFileListBtn.Location = new System.Drawing.Point(5, 5);
            this.ClearFileListBtn.Margin = new System.Windows.Forms.Padding(5);
            this.ClearFileListBtn.Name = "ClearFileListBtn";
            this.ClearFileListBtn.Size = new System.Drawing.Size(89, 27);
            this.ClearFileListBtn.TabIndex = 18;
            this.ClearFileListBtn.Text = "Clear file list";
            this.ClearFileListBtn.UseVisualStyleBackColor = true;
            this.ClearFileListBtn.Click += new System.EventHandler(this.ClearFilelistBtnClick);
            // 
            // SaveFileListBtn
            // 
            this.SaveFileListBtn.AutoSize = true;
            this.SaveFileListBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SaveFileListBtn.Enabled = false;
            this.SaveFileListBtn.Location = new System.Drawing.Point(104, 5);
            this.SaveFileListBtn.Margin = new System.Windows.Forms.Padding(5);
            this.SaveFileListBtn.MinimumSize = new System.Drawing.Size(75, 0);
            this.SaveFileListBtn.Name = "SaveFileListBtn";
            this.SaveFileListBtn.Size = new System.Drawing.Size(86, 27);
            this.SaveFileListBtn.TabIndex = 17;
            this.SaveFileListBtn.Text = "Save file list";
            this.SaveFileListBtn.UseVisualStyleBackColor = true;
            this.SaveFileListBtn.Click += new System.EventHandler(this.SaveFilelistBtnClick);
            // 
            // FileListBox
            // 
            this.FileListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FileListBox.Location = new System.Drawing.Point(3, 138);
            this.FileListBox.Multiline = true;
            this.FileListBox.Name = "FileListBox";
            this.FileListBox.ReadOnly = true;
            this.FileListBox.Size = new System.Drawing.Size(618, 221);
            this.FileListBox.TabIndex = 19;
            this.FileListBox.Text = "Список пока пуст...\r\nВыберите файлы или откройте ранее сохраненный список.";
            // 
            // OpenFileListBtn
            // 
            this.OpenFileListBtn.AutoSize = true;
            this.OpenFileListBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.OpenFileListBtn.Enabled = false;
            this.OpenFileListBtn.Location = new System.Drawing.Point(5, 73);
            this.OpenFileListBtn.Margin = new System.Windows.Forms.Padding(5);
            this.OpenFileListBtn.Name = "OpenFileListBtn";
            this.OpenFileListBtn.Size = new System.Drawing.Size(174, 27);
            this.OpenFileListBtn.TabIndex = 15;
            this.OpenFileListBtn.Text = "Open saved file list (.rlist)...";
            this.OpenFileListBtn.UseVisualStyleBackColor = true;
            this.OpenFileListBtn.Click += new System.EventHandler(this.OpenFilelistBtnClick);
            // 
            // FileListCaption
            // 
            this.FileListCaption.AutoSize = true;
            this.FileListCaption.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FileListCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))));
            this.FileListCaption.Location = new System.Drawing.Point(5, 110);
            this.FileListCaption.Margin = new System.Windows.Forms.Padding(5);
            this.FileListCaption.Name = "FileListCaption";
            this.FileListCaption.Size = new System.Drawing.Size(196, 20);
            this.FileListCaption.TabIndex = 16;
            this.FileListCaption.Text = "Current files for proccessing:";
            // 
            // RegexStageLayout
            // 
            this.RegexStageLayout.Controls.Add(this.tableLayoutPanel2);
            this.RegexStageLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RegexStageLayout.Location = new System.Drawing.Point(0, 0);
            this.RegexStageLayout.Name = "RegexStageLayout";
            this.RegexStageLayout.Size = new System.Drawing.Size(624, 442);
            this.RegexStageLayout.TabIndex = 14;
            this.RegexStageLayout.Visible = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.FileSelectionStageBtn, 0, 5);
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
            this.tableLayoutPanel2.Size = new System.Drawing.Size(624, 442);
            this.tableLayoutPanel2.TabIndex = 14;
            // 
            // FileSelectionStageBtn
            // 
            this.FileSelectionStageBtn.AutoSize = true;
            this.FileSelectionStageBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.FileSelectionStageBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.FileSelectionStageBtn.Location = new System.Drawing.Point(5, 409);
            this.FileSelectionStageBtn.Margin = new System.Windows.Forms.Padding(5);
            this.FileSelectionStageBtn.MinimumSize = new System.Drawing.Size(75, 0);
            this.FileSelectionStageBtn.Name = "FileSelectionStageBtn";
            this.FileSelectionStageBtn.Size = new System.Drawing.Size(75, 28);
            this.FileSelectionStageBtn.TabIndex = 17;
            this.FileSelectionStageBtn.Text = "Prev";
            this.FileSelectionStageBtn.UseVisualStyleBackColor = true;
            this.FileSelectionStageBtn.Click += new System.EventHandler(this.FileSelectionStageBtnClick);
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
            this.label3.Size = new System.Drawing.Size(235, 21);
            this.label3.TabIndex = 12;
            this.label3.Text = "1. Select the files for proccessing";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(301, 71);
            this.label4.Margin = new System.Windows.Forms.Padding(10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 161);
            this.label4.TabIndex = 13;
            this.label4.Text = ">";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PreviewStageBtn
            // 
            this.PreviewStageBtn.AutoSize = true;
            this.PreviewStageBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PreviewStageBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.PreviewStageBtn.Location = new System.Drawing.Point(544, 409);
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
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 381);
            this.flowLayoutPanel2.MinimumSize = new System.Drawing.Size(20, 20);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(618, 20);
            this.flowLayoutPanel2.TabIndex = 15;
            // 
            // PossibleMatchesCaption
            // 
            this.PossibleMatchesCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PossibleMatchesCaption.Location = new System.Drawing.Point(5, 247);
            this.PossibleMatchesCaption.Margin = new System.Windows.Forms.Padding(5);
            this.PossibleMatchesCaption.MinimumSize = new System.Drawing.Size(20, 20);
            this.PossibleMatchesCaption.Name = "PossibleMatchesCaption";
            this.PossibleMatchesCaption.Size = new System.Drawing.Size(281, 126);
            this.PossibleMatchesCaption.TabIndex = 16;
            this.PossibleMatchesCaption.TabStop = false;
            this.PossibleMatchesCaption.Text = "groupBox1";
            // 
            // PossibleReplacesCaption
            // 
            this.PossibleReplacesCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PossibleReplacesCaption.Location = new System.Drawing.Point(337, 247);
            this.PossibleReplacesCaption.Margin = new System.Windows.Forms.Padding(5);
            this.PossibleReplacesCaption.MinimumSize = new System.Drawing.Size(20, 20);
            this.PossibleReplacesCaption.Name = "PossibleReplacesCaption";
            this.PossibleReplacesCaption.Size = new System.Drawing.Size(282, 126);
            this.PossibleReplacesCaption.TabIndex = 18;
            this.PossibleReplacesCaption.TabStop = false;
            this.PossibleReplacesCaption.Text = "groupBox1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.RegexStageLayout);
            this.Controls.Add(this.FilesSelectionStageLayout);
            this.Controls.Add(this.LaunchBtn);
            this.Controls.Add(this.PreviewBtn);
            this.Controls.Add(this.LogBox);
            this.Controls.Add(this.checkBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Replacer";
            this.FilesSelectionStageLayout.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.RegexStageLayout.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ChooseFilesBtn;
        private System.Windows.Forms.TextBox RegExpBox;
        private System.Windows.Forms.TextBox ReplacementBox;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox LogBox;
        private System.Windows.Forms.Button PreviewBtn;
        private System.Windows.Forms.Label RegExpCaption;
        private System.Windows.Forms.Label ReplacementCaption;
        private System.Windows.Forms.Button LaunchBtn;
        private System.Windows.Forms.Label FileSelectionCaption;
        private System.Windows.Forms.Button RegexStageBtn;
        private System.Windows.Forms.Panel FilesSelectionStageLayout;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button ClearFileListBtn;
        private System.Windows.Forms.Button SaveFileListBtn;
        private System.Windows.Forms.Button OpenFileListBtn;
        private System.Windows.Forms.Label FileListCaption;
        private System.Windows.Forms.TextBox FileListBox;
        private System.Windows.Forms.Panel RegexStageLayout;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button PreviewStageBtn;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.GroupBox PossibleMatchesCaption;
        private System.Windows.Forms.Button FileSelectionStageBtn;
        private System.Windows.Forms.GroupBox PossibleReplacesCaption;
    }
}

