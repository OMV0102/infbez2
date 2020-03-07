namespace infbez2
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
            this.btn_generate = new System.Windows.Forms.Button();
            this.txt_seqLength = new System.Windows.Forms.NumericUpDown();
            this.autotest = new System.Windows.Forms.CheckBox();
            this.txt_sequence = new System.Windows.Forms.RichTextBox();
            this.btn_test = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.txt_seqLength)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_generate
            // 
            this.btn_generate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_generate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_generate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_generate.Location = new System.Drawing.Point(309, 80);
            this.btn_generate.Name = "btn_generate";
            this.btn_generate.Size = new System.Drawing.Size(167, 43);
            this.btn_generate.TabIndex = 0;
            this.btn_generate.TabStop = false;
            this.btn_generate.Text = "Генерировать";
            this.btn_generate.UseVisualStyleBackColor = true;
            this.btn_generate.Click += new System.EventHandler(this.btn_generate_Click);
            // 
            // txt_seqLength
            // 
            this.txt_seqLength.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txt_seqLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txt_seqLength.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.txt_seqLength.Location = new System.Drawing.Point(135, 44);
            this.txt_seqLength.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.txt_seqLength.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.txt_seqLength.Name = "txt_seqLength";
            this.txt_seqLength.Size = new System.Drawing.Size(120, 31);
            this.txt_seqLength.TabIndex = 1;
            this.txt_seqLength.TabStop = false;
            this.txt_seqLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_seqLength.ThousandsSeparator = true;
            this.txt_seqLength.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // autotest
            // 
            this.autotest.AutoSize = true;
            this.autotest.Checked = true;
            this.autotest.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autotest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.autotest.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.autotest.Location = new System.Drawing.Point(523, 88);
            this.autotest.Name = "autotest";
            this.autotest.Size = new System.Drawing.Size(128, 29);
            this.autotest.TabIndex = 2;
            this.autotest.TabStop = false;
            this.autotest.Text = "Авто-тест";
            this.autotest.UseVisualStyleBackColor = true;
            this.autotest.CheckedChanged += new System.EventHandler(this.autotest_CheckedChanged);
            // 
            // txt_sequence
            // 
            this.txt_sequence.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txt_sequence.Location = new System.Drawing.Point(81, 168);
            this.txt_sequence.Name = "txt_sequence";
            this.txt_sequence.ReadOnly = true;
            this.txt_sequence.Size = new System.Drawing.Size(782, 258);
            this.txt_sequence.TabIndex = 3;
            this.txt_sequence.TabStop = false;
            this.txt_sequence.Text = "";
            // 
            // btn_test
            // 
            this.btn_test.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_test.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_test.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_test.Location = new System.Drawing.Point(65, 105);
            this.btn_test.Name = "btn_test";
            this.btn_test.Size = new System.Drawing.Size(217, 45);
            this.btn_test.TabIndex = 4;
            this.btn_test.TabStop = false;
            this.btn_test.Text = "Проверка тестами";
            this.btn_test.UseVisualStyleBackColor = true;
            this.btn_test.Click += new System.EventHandler(this.btn_test_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.btn_generate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(924, 512);
            this.Controls.Add(this.btn_test);
            this.Controls.Add(this.txt_sequence);
            this.Controls.Add(this.autotest);
            this.Controls.Add(this.txt_seqLength);
            this.Controls.Add(this.btn_generate);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RSA";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txt_seqLength)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_generate;
        private System.Windows.Forms.NumericUpDown txt_seqLength;
        private System.Windows.Forms.CheckBox autotest;
        private System.Windows.Forms.RichTextBox txt_sequence;
        private System.Windows.Forms.Button btn_test;
    }
}

