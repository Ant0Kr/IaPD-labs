namespace CDBurn
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.filesListBox = new System.Windows.Forms.ListBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.addFileButton = new System.Windows.Forms.Button();
            this.cdDriverComboBox = new System.Windows.Forms.ComboBox();
            this.usedSpaceBar = new System.Windows.Forms.ProgressBar();
            this.burnButton = new System.Windows.Forms.Button();
            this.checkDiskButton = new System.Windows.Forms.Button();
            this.usedSpaceLabel = new System.Windows.Forms.Label();
            this.discSizeLabel = new System.Windows.Forms.Label();
            this.removeFileButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // filesListBox
            // 
            this.filesListBox.FormattingEnabled = true;
            this.filesListBox.Location = new System.Drawing.Point(12, 41);
            this.filesListBox.Name = "filesListBox";
            this.filesListBox.Size = new System.Drawing.Size(573, 225);
            this.filesListBox.TabIndex = 0;
            this.filesListBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FilesListBoxMouseClick);
            this.filesListBox.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.FilesListBoxFormat);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.Multiselect = true;
            // 
            // addFileButton
            // 
            this.addFileButton.Enabled = false;
            this.addFileButton.Location = new System.Drawing.Point(428, 10);
            this.addFileButton.Name = "addFileButton";
            this.addFileButton.Size = new System.Drawing.Size(75, 23);
            this.addFileButton.TabIndex = 1;
            this.addFileButton.Text = "Add file";
            this.addFileButton.UseVisualStyleBackColor = true;
            this.addFileButton.Click += new System.EventHandler(this.AddFileButtonClick);
            // 
            // cdDriverComboBox
            // 
            this.cdDriverComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cdDriverComboBox.FormattingEnabled = true;
            this.cdDriverComboBox.Location = new System.Drawing.Point(12, 10);
            this.cdDriverComboBox.Name = "cdDriverComboBox";
            this.cdDriverComboBox.Size = new System.Drawing.Size(213, 21);
            this.cdDriverComboBox.TabIndex = 2;
            this.cdDriverComboBox.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.CdDriverComboBoxFormat);
            // 
            // usedSpaceBar
            // 
            this.usedSpaceBar.Location = new System.Drawing.Point(12, 285);
            this.usedSpaceBar.Name = "usedSpaceBar";
            this.usedSpaceBar.Size = new System.Drawing.Size(573, 44);
            this.usedSpaceBar.TabIndex = 3;
            // 
            // burnButton
            // 
            this.burnButton.Enabled = false;
            this.burnButton.Location = new System.Drawing.Point(509, 335);
            this.burnButton.Name = "burnButton";
            this.burnButton.Size = new System.Drawing.Size(75, 33);
            this.burnButton.TabIndex = 4;
            this.burnButton.Text = "Burn";
            this.burnButton.UseVisualStyleBackColor = true;
            this.burnButton.Click += new System.EventHandler(this.BurnButtonClick);
            // 
            // checkDiskButton
            // 
            this.checkDiskButton.Location = new System.Drawing.Point(231, 10);
            this.checkDiskButton.Name = "checkDiskButton";
            this.checkDiskButton.Size = new System.Drawing.Size(75, 23);
            this.checkDiskButton.TabIndex = 5;
            this.checkDiskButton.Text = "Status";
            this.checkDiskButton.UseVisualStyleBackColor = true;
            this.checkDiskButton.Click += new System.EventHandler(this.CheckDiskButtonClick);
            // 
            // usedSpaceLabel
            // 
            this.usedSpaceLabel.AutoSize = true;
            this.usedSpaceLabel.Location = new System.Drawing.Point(471, 269);
            this.usedSpaceLabel.Name = "usedSpaceLabel";
            this.usedSpaceLabel.Size = new System.Drawing.Size(32, 13);
            this.usedSpaceLabel.TabIndex = 10;
            this.usedSpaceLabel.Text = "0 MB";
            // 
            // discSizeLabel
            // 
            this.discSizeLabel.AutoSize = true;
            this.discSizeLabel.Location = new System.Drawing.Point(527, 269);
            this.discSizeLabel.Name = "discSizeLabel";
            this.discSizeLabel.Size = new System.Drawing.Size(32, 13);
            this.discSizeLabel.TabIndex = 11;
            this.discSizeLabel.Text = "0 MB";
            // 
            // removeFileButton
            // 
            this.removeFileButton.Enabled = false;
            this.removeFileButton.Location = new System.Drawing.Point(509, 10);
            this.removeFileButton.Name = "removeFileButton";
            this.removeFileButton.Size = new System.Drawing.Size(75, 23);
            this.removeFileButton.TabIndex = 13;
            this.removeFileButton.Text = "Remove file";
            this.removeFileButton.UseVisualStyleBackColor = true;
            this.removeFileButton.Click += new System.EventHandler(this.RemoveFileButtonClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(509, 269);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "/";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 378);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.removeFileButton);
            this.Controls.Add(this.discSizeLabel);
            this.Controls.Add(this.usedSpaceLabel);
            this.Controls.Add(this.checkDiskButton);
            this.Controls.Add(this.burnButton);
            this.Controls.Add(this.usedSpaceBar);
            this.Controls.Add(this.cdDriverComboBox);
            this.Controls.Add(this.addFileButton);
            this.Controls.Add(this.filesListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "CDBurn";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox filesListBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button addFileButton;
        private System.Windows.Forms.ComboBox cdDriverComboBox;
        private System.Windows.Forms.ProgressBar usedSpaceBar;
        private System.Windows.Forms.Button burnButton;
        private System.Windows.Forms.Button checkDiskButton;
        private System.Windows.Forms.Label usedSpaceLabel;
        private System.Windows.Forms.Label discSizeLabel;
        private System.Windows.Forms.Button removeFileButton;
        private System.Windows.Forms.Label label4;
    }
}

