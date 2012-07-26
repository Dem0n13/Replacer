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
            this.OpenFilesBtn = new System.Windows.Forms.Button();
            this.RegExpBox = new System.Windows.Forms.TextBox();
            this.FilePathBox = new System.Windows.Forms.TextBox();
            this.ReplaceBox = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.LogBox = new System.Windows.Forms.TextBox();
            this.PreviewBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LaunchBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // OpenFilesBtn
            // 
            this.OpenFilesBtn.Location = new System.Drawing.Point(470, 10);
            this.OpenFilesBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.OpenFilesBtn.Name = "OpenFilesBtn";
            this.OpenFilesBtn.Size = new System.Drawing.Size(87, 30);
            this.OpenFilesBtn.TabIndex = 0;
            this.OpenFilesBtn.Text = "OpenFilesBtn";
            this.OpenFilesBtn.UseVisualStyleBackColor = true;
            this.OpenFilesBtn.Click += new System.EventHandler(this.OpenFilesBtnClick);
            // 
            // RegExpBox
            // 
            this.RegExpBox.Font = new System.Drawing.Font("Consolas", 12F);
            this.RegExpBox.Location = new System.Drawing.Point(10, 70);
            this.RegExpBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RegExpBox.Multiline = true;
            this.RegExpBox.Name = "RegExpBox";
            this.RegExpBox.Size = new System.Drawing.Size(230, 280);
            this.RegExpBox.TabIndex = 1;
            // 
            // FilePathBox
            // 
            this.FilePathBox.Location = new System.Drawing.Point(10, 10);
            this.FilePathBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.FilePathBox.Name = "FilePathBox";
            this.FilePathBox.Size = new System.Drawing.Size(450, 25);
            this.FilePathBox.TabIndex = 2;
            // 
            // ReplaceBox
            // 
            this.ReplaceBox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ReplaceBox.Location = new System.Drawing.Point(250, 70);
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
            this.checkBox1.Location = new System.Drawing.Point(570, 20);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(138, 21);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "Блокировать файл";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // LogBox
            // 
            this.LogBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LogBox.Location = new System.Drawing.Point(490, 150);
            this.LogBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LogBox.Multiline = true;
            this.LogBox.Name = "LogBox";
            this.LogBox.Size = new System.Drawing.Size(230, 200);
            this.LogBox.TabIndex = 5;
            // 
            // PreviewBtn
            // 
            this.PreviewBtn.Location = new System.Drawing.Point(490, 70);
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
            this.label1.Location = new System.Drawing.Point(10, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Регулярное выражение для поиска";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(250, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Выражение замены";
            // 
            // LaunchBtn
            // 
            this.LaunchBtn.Enabled = false;
            this.LaunchBtn.Location = new System.Drawing.Point(490, 110);
            this.LaunchBtn.Name = "LaunchBtn";
            this.LaunchBtn.Size = new System.Drawing.Size(230, 30);
            this.LaunchBtn.TabIndex = 9;
            this.LaunchBtn.Text = "Замена совпадений";
            this.LaunchBtn.UseVisualStyleBackColor = true;
            this.LaunchBtn.Click += new System.EventHandler(this.LaunchBtnClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 361);
            this.Controls.Add(this.LaunchBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PreviewBtn);
            this.Controls.Add(this.LogBox);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.ReplaceBox);
            this.Controls.Add(this.FilePathBox);
            this.Controls.Add(this.RegExpBox);
            this.Controls.Add(this.OpenFilesBtn);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "Replacer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OpenFilesBtn;
        private System.Windows.Forms.TextBox RegExpBox;
        private System.Windows.Forms.TextBox FilePathBox;
        private System.Windows.Forms.TextBox ReplaceBox;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox LogBox;
        private System.Windows.Forms.Button PreviewBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button LaunchBtn;
    }
}

