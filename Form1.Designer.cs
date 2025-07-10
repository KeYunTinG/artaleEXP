namespace expTool
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            info = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            間隔時間 = new TextBox();
            label2 = new Label();
            label3 = new Label();
            每分鐘經驗 = new Label();
            每十分鐘經驗 = new Label();
            升級倒數 = new Label();
            label1 = new Label();
            label4 = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // info
            // 
            info.AutoSize = true;
            info.Location = new Point(12, 117);
            info.Name = "info";
            info.Size = new Size(29, 15);
            info.TabIndex = 0;
            info.Text = "info";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(6, 35);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(39, 23);
            textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(68, 35);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(44, 23);
            textBox2.TabIndex = 2;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(136, 35);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 3;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(261, 35);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(100, 23);
            textBox4.TabIndex = 4;
            // 
            // button1
            // 
            button1.Location = new Point(222, 113);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 5;
            button1.Text = "擷取畫面";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(303, 113);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 6;
            button2.Text = "開始計算";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // 間隔時間
            // 
            間隔時間.Location = new Point(286, 162);
            間隔時間.MaxLength = 10;
            間隔時間.Name = "間隔時間";
            間隔時間.Size = new Size(24, 23);
            間隔時間.TabIndex = 7;
            間隔時間.Text = "1";
            間隔時間.Leave += 間隔時間_Leave;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(222, 165);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 8;
            label2.Text = "間隔時間:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(316, 165);
            label3.Name = "label3";
            label3.Size = new Size(28, 15);
            label3.TabIndex = 9;
            label3.Text = "min";
            // 
            // 每分鐘經驗
            // 
            每分鐘經驗.AutoSize = true;
            每分鐘經驗.Location = new Point(124, 147);
            每分鐘經驗.Name = "每分鐘經驗";
            每分鐘經驗.Size = new Size(0, 15);
            每分鐘經驗.TabIndex = 10;
            // 
            // 每十分鐘經驗
            // 
            每十分鐘經驗.AutoSize = true;
            每十分鐘經驗.Location = new Point(136, 176);
            每十分鐘經驗.Name = "每十分鐘經驗";
            每十分鐘經驗.Size = new Size(0, 15);
            每十分鐘經驗.TabIndex = 11;
            // 
            // 升級倒數
            // 
            升級倒數.AutoSize = true;
            升級倒數.Location = new Point(112, 203);
            升級倒數.Name = "升級倒數";
            升級倒數.Size = new Size(0, 15);
            升級倒數.TabIndex = 12;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 147);
            label1.Name = "label1";
            label1.Size = new Size(70, 15);
            label1.TabIndex = 13;
            label1.Text = "每分鐘經驗:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 176);
            label4.Name = "label4";
            label4.Size = new Size(82, 15);
            label4.TabIndex = 14;
            label4.Text = "每十分鐘經驗:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 203);
            label5.Name = "label5";
            label5.Size = new Size(58, 15);
            label5.TabIndex = 15;
            label5.Text = "升級倒數:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(403, 232);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label1);
            Controls.Add(升級倒數);
            Controls.Add(每十分鐘經驗);
            Controls.Add(每分鐘經驗);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(間隔時間);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(info);
            Name = "Form1";
            Text = "阿泰噁經驗計算";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label info;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Button button1;
        private Button button2;
        private TextBox 間隔時間;
        private Label label2;
        private Label label3;
        private Label 每分鐘經驗;
        private Label 每十分鐘經驗;
        private Label 升級倒數;
        private Label label1;
        private Label label4;
        private Label label5;
    }
}
