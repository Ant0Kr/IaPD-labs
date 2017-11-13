namespace DeviceManager
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
            this.infoBox = new System.Windows.Forms.RichTextBox();
            this.offBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.deviceBox = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // infoBox
            // 
            this.infoBox.Location = new System.Drawing.Point(402, 34);
            this.infoBox.Name = "infoBox";
            this.infoBox.ReadOnly = true;
            this.infoBox.Size = new System.Drawing.Size(369, 328);
            this.infoBox.TabIndex = 1;
            this.infoBox.Text = "";
            // 
            // offBtn
            // 
            this.offBtn.Enabled = false;
            this.offBtn.Location = new System.Drawing.Point(12, 368);
            this.offBtn.Name = "offBtn";
            this.offBtn.Size = new System.Drawing.Size(88, 23);
            this.offBtn.TabIndex = 2;
            this.offBtn.Text = "Switch Off/On";
            this.offBtn.UseVisualStyleBackColor = true;
            this.offBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Devices:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(244, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(399, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Device info:";
            // 
            // deviceBox
            // 
            this.deviceBox.FullRowSelect = true;
            this.deviceBox.Location = new System.Drawing.Point(16, 34);
            this.deviceBox.MultiSelect = false;
            this.deviceBox.Name = "deviceBox";
            this.deviceBox.Size = new System.Drawing.Size(380, 328);
            this.deviceBox.TabIndex = 6;
            this.deviceBox.TileSize = new System.Drawing.Size(350, 30);
            this.deviceBox.UseCompatibleStateImageBehavior = false;
            this.deviceBox.View = System.Windows.Forms.View.Tile;
            this.deviceBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.deviceBox_MouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 403);
            this.Controls.Add(this.deviceBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.offBtn);
            this.Controls.Add(this.infoBox);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox infoBox;
        private System.Windows.Forms.Button offBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView deviceBox;
    }
}

