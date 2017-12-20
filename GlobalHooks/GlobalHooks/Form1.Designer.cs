namespace GlobalHooks
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.logCheckBox = new System.Windows.Forms.CheckBox();
            this.hideCheckBox = new System.Windows.Forms.CheckBox();
            this.prtCheckBox = new System.Windows.Forms.CheckBox();
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.confirmBtn = new System.Windows.Forms.Button();
            this.pathLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // logCheckBox
            // 
            this.logCheckBox.AutoSize = true;
            this.logCheckBox.Location = new System.Drawing.Point(12, 35);
            this.logCheckBox.Name = "logCheckBox";
            this.logCheckBox.Size = new System.Drawing.Size(76, 17);
            this.logCheckBox.TabIndex = 0;
            this.logCheckBox.Text = "Enable log";
            this.logCheckBox.UseVisualStyleBackColor = true;
            // 
            // hideCheckBox
            // 
            this.hideCheckBox.AutoSize = true;
            this.hideCheckBox.Location = new System.Drawing.Point(12, 58);
            this.hideCheckBox.Name = "hideCheckBox";
            this.hideCheckBox.Size = new System.Drawing.Size(48, 17);
            this.hideCheckBox.TabIndex = 1;
            this.hideCheckBox.Text = "Hide";
            this.hideCheckBox.UseVisualStyleBackColor = true;
            // 
            // prtCheckBox
            // 
            this.prtCheckBox.AutoSize = true;
            this.prtCheckBox.Location = new System.Drawing.Point(12, 12);
            this.prtCheckBox.Name = "prtCheckBox";
            this.prtCheckBox.Size = new System.Drawing.Size(116, 17);
            this.prtCheckBox.TabIndex = 2;
            this.prtCheckBox.Text = "Enable Prt sc hook";
            this.prtCheckBox.UseVisualStyleBackColor = true;
            // 
            // numericUpDown
            // 
            this.numericUpDown.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown.Location = new System.Drawing.Point(203, 12);
            this.numericUpDown.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.Size = new System.Drawing.Size(83, 20);
            this.numericUpDown.TabIndex = 3;
            this.numericUpDown.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(153, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "File size";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(153, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Email";
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(156, 58);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(188, 20);
            this.emailTextBox.TabIndex = 6;
            // 
            // confirmBtn
            // 
            this.confirmBtn.Location = new System.Drawing.Point(139, 132);
            this.confirmBtn.Name = "confirmBtn";
            this.confirmBtn.Size = new System.Drawing.Size(75, 23);
            this.confirmBtn.TabIndex = 7;
            this.confirmBtn.Text = "Confirm";
            this.confirmBtn.UseVisualStyleBackColor = true;
            this.confirmBtn.Click += new System.EventHandler(this.confirmBtn_Click);
            // 
            // pathLabel
            // 
            this.pathLabel.AutoSize = true;
            this.pathLabel.Location = new System.Drawing.Point(12, 116);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(0, 13);
            this.pathLabel.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 90);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Pick derictory";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 167);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pathLabel);
            this.Controls.Add(this.confirmBtn);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown);
            this.Controls.Add(this.prtCheckBox);
            this.Controls.Add(this.hideCheckBox);
            this.Controls.Add(this.logCheckBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox logCheckBox;
        private System.Windows.Forms.CheckBox hideCheckBox;
        private System.Windows.Forms.CheckBox prtCheckBox;
        private System.Windows.Forms.NumericUpDown numericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Button confirmBtn;
        private System.Windows.Forms.Label pathLabel;
        private System.Windows.Forms.Button button1;
    }
}

