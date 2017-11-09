namespace USB
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
            this.devicesBox = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ejectBtn = new System.Windows.Forms.Button();
            this.infoLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // devicesBox
            // 
            this.devicesBox.Location = new System.Drawing.Point(12, 31);
            this.devicesBox.Name = "devicesBox";
            this.devicesBox.Size = new System.Drawing.Size(191, 140);
            this.devicesBox.TabIndex = 0;
            this.devicesBox.UseCompatibleStateImageBehavior = false;
            this.devicesBox.View = System.Windows.Forms.View.List;
            this.devicesBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.devicesBox_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "USB devices:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(218, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Device info:";
            // 
            // ejectBtn
            // 
            this.ejectBtn.Enabled = false;
            this.ejectBtn.Location = new System.Drawing.Point(128, 177);
            this.ejectBtn.Name = "ejectBtn";
            this.ejectBtn.Size = new System.Drawing.Size(75, 23);
            this.ejectBtn.TabIndex = 4;
            this.ejectBtn.Text = "Eject";
            this.ejectBtn.UseVisualStyleBackColor = true;
            this.ejectBtn.Click += new System.EventHandler(this.ejectBtn_Click);
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Location = new System.Drawing.Point(221, 32);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(0, 13);
            this.infoLabel.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(221, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 212);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.ejectBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.devicesBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView devicesBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ejectBtn;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.Label label3;
    }
}

