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
            this.txt_sequence = new System.Windows.Forms.RichTextBox();
            this.btn_test = new System.Windows.Forms.Button();
            this.btn_copy_in_buffer = new System.Windows.Forms.Button();
            this.label_test1_result = new System.Windows.Forms.Label();
            this.label_test2_result = new System.Windows.Forms.Label();
            this.label_test3_result = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.autotest = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.txt_seqLength)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_generate
            // 
            this.btn_generate.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_generate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_generate.FlatAppearance.BorderSize = 2;
            this.btn_generate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_generate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_generate.Location = new System.Drawing.Point(405, 12);
            this.btn_generate.Name = "btn_generate";
            this.btn_generate.Size = new System.Drawing.Size(208, 70);
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
            this.txt_seqLength.Location = new System.Drawing.Point(232, 48);
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
            100,
            0,
            0,
            0});
            // 
            // txt_sequence
            // 
            this.txt_sequence.DetectUrls = false;
            this.txt_sequence.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txt_sequence.Location = new System.Drawing.Point(12, 93);
            this.txt_sequence.Name = "txt_sequence";
            this.txt_sequence.ReadOnly = true;
            this.txt_sequence.Size = new System.Drawing.Size(616, 260);
            this.txt_sequence.TabIndex = 3;
            this.txt_sequence.TabStop = false;
            this.txt_sequence.Text = "";
            // 
            // btn_test
            // 
            this.btn_test.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_test.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_test.FlatAppearance.BorderSize = 2;
            this.btn_test.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_test.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_test.Location = new System.Drawing.Point(12, 359);
            this.btn_test.Name = "btn_test";
            this.btn_test.Size = new System.Drawing.Size(217, 45);
            this.btn_test.TabIndex = 4;
            this.btn_test.TabStop = false;
            this.btn_test.Text = "Проверка тестами";
            this.btn_test.UseVisualStyleBackColor = false;
            this.btn_test.Click += new System.EventHandler(this.btn_test_Click);
            // 
            // btn_copy_in_buffer
            // 
            this.btn_copy_in_buffer.BackColor = System.Drawing.SystemColors.Control;
            this.btn_copy_in_buffer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_copy_in_buffer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_copy_in_buffer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_copy_in_buffer.Location = new System.Drawing.Point(558, 352);
            this.btn_copy_in_buffer.Name = "btn_copy_in_buffer";
            this.btn_copy_in_buffer.Size = new System.Drawing.Size(71, 35);
            this.btn_copy_in_buffer.TabIndex = 5;
            this.btn_copy_in_buffer.TabStop = false;
            this.btn_copy_in_buffer.Text = "Copy";
            this.btn_copy_in_buffer.UseVisualStyleBackColor = false;
            this.btn_copy_in_buffer.Click += new System.EventHandler(this.btn_copy_in_buffer_Click);
            // 
            // label_test1_result
            // 
            this.label_test1_result.AutoSize = true;
            this.label_test1_result.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_test1_result.ForeColor = System.Drawing.Color.Black;
            this.label_test1_result.Location = new System.Drawing.Point(401, 438);
            this.label_test1_result.Name = "label_test1_result";
            this.label_test1_result.Size = new System.Drawing.Size(151, 24);
            this.label_test1_result.TabIndex = 6;
            this.label_test1_result.Text = "Нет результата";
            // 
            // label_test2_result
            // 
            this.label_test2_result.AutoSize = true;
            this.label_test2_result.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_test2_result.ForeColor = System.Drawing.Color.Black;
            this.label_test2_result.Location = new System.Drawing.Point(401, 495);
            this.label_test2_result.Name = "label_test2_result";
            this.label_test2_result.Size = new System.Drawing.Size(151, 24);
            this.label_test2_result.TabIndex = 7;
            this.label_test2_result.Text = "Нет результата";
            // 
            // label_test3_result
            // 
            this.label_test3_result.AutoSize = true;
            this.label_test3_result.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_test3_result.ForeColor = System.Drawing.Color.Black;
            this.label_test3_result.Location = new System.Drawing.Point(401, 556);
            this.label_test3_result.Name = "label_test3_result";
            this.label_test3_result.Size = new System.Drawing.Size(151, 24);
            this.label_test3_result.TabIndex = 8;
            this.label_test3_result.Text = "Нет результата";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 48);
            this.label1.TabIndex = 9;
            this.label1.Text = "Длини генерируемой последовательности = ";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label2.Location = new System.Drawing.Point(191, 436);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 28);
            this.label2.TabIndex = 10;
            this.label2.Text = "Частотный тест";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label3.Location = new System.Drawing.Point(73, 478);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(279, 54);
            this.label3.TabIndex = 11;
            this.label3.Text = "Тест на последовательность одинаковых бит";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label4.Location = new System.Drawing.Point(73, 547);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(279, 58);
            this.label4.TabIndex = 12;
            this.label4.Text = "Расширенный тест на произвольные отклоненения";
            // 
            // autotest
            // 
            this.autotest.AutoSize = true;
            this.autotest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.autotest.FlatAppearance.BorderSize = 2;
            this.autotest.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.autotest.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.autotest.Location = new System.Drawing.Point(265, 367);
            this.autotest.Name = "autotest";
            this.autotest.Size = new System.Drawing.Size(245, 29);
            this.autotest.TabIndex = 13;
            this.autotest.Text = "Автопроверка тестами";
            this.autotest.UseVisualStyleBackColor = true;
            this.autotest.CheckedChanged += new System.EventHandler(this.autotest_CheckedChanged);
            // 
            // Form1
            // 
            this.AcceptButton = this.btn_generate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(642, 614);
            this.Controls.Add(this.autotest);
            this.Controls.Add(this.txt_sequence);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_test3_result);
            this.Controls.Add(this.label_test2_result);
            this.Controls.Add(this.label_test1_result);
            this.Controls.Add(this.btn_copy_in_buffer);
            this.Controls.Add(this.btn_test);
            this.Controls.Add(this.txt_seqLength);
            this.Controls.Add(this.btn_generate);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.RichTextBox txt_sequence;
        private System.Windows.Forms.Button btn_test;
        private System.Windows.Forms.Button btn_copy_in_buffer;
        private System.Windows.Forms.Label label_test1_result;
        private System.Windows.Forms.Label label_test2_result;
        private System.Windows.Forms.Label label_test3_result;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox autotest;
    }
}

