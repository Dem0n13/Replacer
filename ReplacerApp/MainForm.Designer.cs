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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
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
            resources.ApplyResources(this.FilesChooserBtn, "FilesChooserBtn");
            this.FilesChooserBtn.Name = "FilesChooserBtn";
            this.FilesChooserBtn.UseVisualStyleBackColor = true;
            this.FilesChooserBtn.Click += new System.EventHandler(this.OpenFilesBtnClick);
            // 
            // RegExpBox
            // 
            resources.ApplyResources(this.RegExpBox, "RegExpBox");
            this.RegExpBox.Name = "RegExpBox";
            // 
            // FilePathBox
            // 
            resources.ApplyResources(this.FilePathBox, "FilePathBox");
            this.FilePathBox.Name = "FilePathBox";
            // 
            // ReplaceBox
            // 
            resources.ApplyResources(this.ReplaceBox, "ReplaceBox");
            this.ReplaceBox.Name = "ReplaceBox";
            // 
            // checkBox1
            // 
            resources.ApplyResources(this.checkBox1, "checkBox1");
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // LogBox
            // 
            resources.ApplyResources(this.LogBox, "LogBox");
            this.LogBox.Name = "LogBox";
            // 
            // PreviewBtn
            // 
            resources.ApplyResources(this.PreviewBtn, "PreviewBtn");
            this.PreviewBtn.Name = "PreviewBtn";
            this.PreviewBtn.UseVisualStyleBackColor = true;
            this.PreviewBtn.Click += new System.EventHandler(this.PreviewBtnClick);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // LaunchBtn
            // 
            resources.ApplyResources(this.LaunchBtn, "LaunchBtn");
            this.LaunchBtn.Name = "LaunchBtn";
            this.LaunchBtn.UseVisualStyleBackColor = true;
            this.LaunchBtn.Click += new System.EventHandler(this.LaunchBtnClick);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))));
            this.label3.Name = "label3";
            // 
            // RegexStageBtn
            // 
            resources.ApplyResources(this.RegexStageBtn, "RegexStageBtn");
            this.RegexStageBtn.Name = "RegexStageBtn";
            this.RegexStageBtn.UseVisualStyleBackColor = true;
            this.RegexStageBtn.Click += new System.EventHandler(this.RegexStageBtnClick);
            // 
            // FilesSelectionStageLayout
            // 
            this.FilesSelectionStageLayout.Controls.Add(this.tableLayoutPanel1);
            resources.ApplyResources(this.FilesSelectionStageLayout, "FilesSelectionStageLayout");
            this.FilesSelectionStageLayout.Name = "FilesSelectionStageLayout";
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.RegexStageBtn, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.FileListBox, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.FilesChooserBtn, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.OpenFileListBtn, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Controls.Add(this.ClearFileListBtn);
            this.flowLayoutPanel1.Controls.Add(this.SaveFileListBtn);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // ClearFileListBtn
            // 
            resources.ApplyResources(this.ClearFileListBtn, "ClearFileListBtn");
            this.ClearFileListBtn.Name = "ClearFileListBtn";
            this.ClearFileListBtn.UseVisualStyleBackColor = true;
            this.ClearFileListBtn.Click += new System.EventHandler(this.ClearFilelistBtnClick);
            // 
            // SaveFileListBtn
            // 
            resources.ApplyResources(this.SaveFileListBtn, "SaveFileListBtn");
            this.SaveFileListBtn.Name = "SaveFileListBtn";
            this.SaveFileListBtn.UseVisualStyleBackColor = true;
            this.SaveFileListBtn.Click += new System.EventHandler(this.SaveFilelistBtnClick);
            // 
            // FileListBox
            // 
            resources.ApplyResources(this.FileListBox, "FileListBox");
            this.FileListBox.Name = "FileListBox";
            this.FileListBox.ReadOnly = true;
            // 
            // OpenFileListBtn
            // 
            resources.ApplyResources(this.OpenFileListBtn, "OpenFileListBtn");
            this.OpenFileListBtn.Name = "OpenFileListBtn";
            this.OpenFileListBtn.UseVisualStyleBackColor = true;
            this.OpenFileListBtn.Click += new System.EventHandler(this.OpenFilelistBtnClick);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
            this.Name = "MainForm";
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

