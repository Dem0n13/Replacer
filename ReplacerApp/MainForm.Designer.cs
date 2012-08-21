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
            this.FilesChooserBtn = new System.Windows.Forms.Button();
            this.RegExpBox = new System.Windows.Forms.TextBox();
            this.FilePathBox = new System.Windows.Forms.TextBox();
            this.ReplaceBox = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.LogBox = new System.Windows.Forms.TextBox();
            this.PreviewBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LaunchBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.RegexStageBtn = new System.Windows.Forms.Button();
            this.FilesSelectionStageLayout = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.ClearFileListBtn = new System.Windows.Forms.Button();
            this.SaveFileListBtn = new System.Windows.Forms.Button();
            this.FileListBox = new System.Windows.Forms.TextBox();
            this.OpenFileListBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.FilesSelectionStageLayout.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // FilesChooserBtn
            // 
            this.FilesChooserBtn.AutoSize = true;
            this.FilesChooserBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.FilesChooserBtn.Location = new System.Drawing.Point(5, 36);
            this.FilesChooserBtn.Margin = new System.Windows.Forms.Padding(5);
            this.FilesChooserBtn.Name = "FilesChooserBtn";
            this.FilesChooserBtn.Size = new System.Drawing.Size(175, 27);
            this.FilesChooserBtn.TabIndex = 0;
            this.FilesChooserBtn.Text = "Select the files from drive...";
            this.FilesChooserBtn.UseVisualStyleBackColor = true;
            this.FilesChooserBtn.Click += new System.EventHandler(this.OpenFilesBtnClick);
            // 
            // RegExpBox
            // 
            this.RegExpBox.Font = new System.Drawing.Font("Consolas", 12F);
            this.RegExpBox.Location = new System.Drawing.Point(470, 70);
            this.RegExpBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RegExpBox.Multiline = true;
            this.RegExpBox.Name = "RegExpBox";
            this.RegExpBox.Size = new System.Drawing.Size(230, 280);
            this.RegExpBox.TabIndex = 1;
            // 
            // FilePathBox
            // 
            this.FilePathBox.Location = new System.Drawing.Point(470, 10);
            this.FilePathBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.FilePathBox.Name = "FilePathBox";
            this.FilePathBox.Size = new System.Drawing.Size(450, 25);
            this.FilePathBox.TabIndex = 2;
            // 
            // ReplaceBox
            // 
            this.ReplaceBox.Font = new System.Drawing.Font("Consolas", 12F);
            this.ReplaceBox.Location = new System.Drawing.Point(710, 70);
            this.ReplaceBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ReplaceBox.Multiline = true;
            this.ReplaceBox.Name = "ReplaceBox";
            this.ReplaceBox.Size = new System.Drawing.Size(230, 280);
            this.ReplaceBox.TabIndex = 3;
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
            this.LogBox.Location = new System.Drawing.Point(950, 150);
            this.LogBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LogBox.Multiline = true;
            this.LogBox.Name = "LogBox";
            this.LogBox.Size = new System.Drawing.Size(230, 200);
            this.LogBox.TabIndex = 5;
            // 
            // PreviewBtn
            // 
            this.PreviewBtn.Location = new System.Drawing.Point(950, 70);
            this.PreviewBtn.Name = "PreviewBtn";
            this.PreviewBtn.Size = new System.Drawing.Size(230, 30);
            this.PreviewBtn.TabIndex = 6;
            this.PreviewBtn.Text = "Поиск совпадений";
            this.PreviewBtn.UseVisualStyleBackColor = true;
            this.PreviewBtn.Click += new System.EventHandler(this.PreviewBtnClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(470, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Регулярное выражение для поиска";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(710, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Выражение замены";
            // 
            // LaunchBtn
            // 
            this.LaunchBtn.Enabled = false;
            this.LaunchBtn.Location = new System.Drawing.Point(950, 110);
            this.LaunchBtn.Name = "LaunchBtn";
            this.LaunchBtn.Size = new System.Drawing.Size(230, 30);
            this.LaunchBtn.TabIndex = 9;
            this.LaunchBtn.Text = "Замена совпадений";
            this.LaunchBtn.UseVisualStyleBackColor = true;
            this.LaunchBtn.Click += new System.EventHandler(this.LaunchBtnClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))));
            this.label3.Location = new System.Drawing.Point(5, 5);
            this.label3.Margin = new System.Windows.Forms.Padding(5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(235, 21);
            this.label3.TabIndex = 11;
            this.label3.Text = "1. Select the files for proccessing";
            // 
            // RegexStageBtn
            // 
            this.RegexStageBtn.AutoSize = true;
            this.RegexStageBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.RegexStageBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.RegexStageBtn.Location = new System.Drawing.Point(392, 421);
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
            this.FilesSelectionStageLayout.Size = new System.Drawing.Size(472, 453);
            this.FilesSelectionStageLayout.TabIndex = 13;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.RegexStageBtn, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.FileListBox, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.FilesChooserBtn, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.OpenFileListBtn, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(472, 453);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.ClearFileListBtn);
            this.flowLayoutPanel1.Controls.Add(this.SaveFileListBtn);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 376);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(466, 37);
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
            this.FileListBox.Location = new System.Drawing.Point(3, 135);
            this.FileListBox.Multiline = true;
            this.FileListBox.Name = "FileListBox";
            this.FileListBox.ReadOnly = true;
            this.FileListBox.Size = new System.Drawing.Size(466, 235);
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 110);
            this.label4.Margin = new System.Windows.Forms.Padding(5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(176, 17);
            this.label4.TabIndex = 16;
            this.label4.Text = "Current files for proccessing:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 453);
            this.Controls.Add(this.FilesSelectionStageLayout);
            this.Controls.Add(this.LaunchBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PreviewBtn);
            this.Controls.Add(this.LogBox);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.ReplaceBox);
            this.Controls.Add(this.FilePathBox);
            this.Controls.Add(this.RegExpBox);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(480, 480);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Replacer";
            this.FilesSelectionStageLayout.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button FilesChooserBtn;
        private System.Windows.Forms.TextBox RegExpBox;
        private System.Windows.Forms.TextBox FilePathBox;
        private System.Windows.Forms.TextBox ReplaceBox;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox LogBox;
        private System.Windows.Forms.Button PreviewBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button LaunchBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button RegexStageBtn;
        private System.Windows.Forms.Panel FilesSelectionStageLayout;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button ClearFileListBtn;
        private System.Windows.Forms.Button SaveFileListBtn;
        private System.Windows.Forms.Button OpenFileListBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox FileListBox;
    }
}

