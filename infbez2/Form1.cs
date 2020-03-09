using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Numerics;
using System.IO;
using System.Collections;


namespace infbez2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // При загрузке формы
        private void Form1_Load(object sender, EventArgs e)
        {
            // Выделили память под список простых чисел
            global.simpleNumbersList = new List<Int32>();
            // Считали простые числа с файла
            alg.loadSimpleNumber("prime_numbers.txt");
        }

        // кнопка ГЕНЕРИРОВАТЬ
        private void btn_generate_Click(object sender, EventArgs e)
        {
            // Ждущий курсор и неактивное окно на время генерации
            this.txt_sequence.Text = "";
            test_neutral_show();
            this.Cursor = Cursors.WaitCursor;
            this.Enabled = false;

            global.sequence =  alg.RSA_algorithm((Int32)this.txt_seqLength.Value);
            txt_sequence.Text = global.sequence;
            if (autotest.Checked == true)
            {
                btn_test_Click(null, null);
            }

            // Обычный курсор
            this.Enabled = true;
            this.Cursor = Cursors.Arrow; ;
            
        }

        // галочка автопроверка тестами
        private void autotest_CheckedChanged(object sender, EventArgs e)
        {
            if(autotest.Checked == true)
            {
                btn_test_Click(null, null);
            }
        }

        // кнопка ПРОВЕРИТЬ ТЕСТАМИ
        private void btn_test_Click(object sender, EventArgs e)
        {
            // Если последовательность не пустая и длина не меньше минимальной
            if (global.sequence.Length >= txt_seqLength.Minimum)
            {
                global.test1 = alg.test1_frequency(global.sequence);
                global.test2 = alg.test2_SameBits(global.sequence);
                global.test3 = alg.test3_arbitrary_deviations(global.sequence);
                test_result_show(); // показать результаты тестов
            }
        }

        // Копировать последовательность в буфер обмена
        private void btn_copy_in_buffer_Click(object sender, EventArgs e)
        {
            if(txt_sequence.Text.Length >= txt_seqLength.Minimum)
                Clipboard.SetText(txt_sequence.Text);
        }

        // функция: отобразить результаты тестов
        private void test_result_show()
        {
            if(global.test1 == true)
            {
                label_test1_result.Text = "Успешно";
                label_test1_result.ForeColor = Color.Green;
            }
            else
            {
                label_test1_result.Text = "Не пройден";
                label_test1_result.ForeColor = Color.Red;
            }
            if (global.test2 == true)
            {
                label_test2_result.Text = "Успешно";
                label_test2_result.ForeColor = Color.Green;
            }
            else
            {
                label_test2_result.Text = "Не пройден";
                label_test2_result.ForeColor = Color.Red;
            }
            if (global.test3 == true)
            {
                label_test3_result.Text = "Успешно";
                label_test3_result.ForeColor = Color.Green;
            }
            else
            {
                label_test3_result.Text = "Не пройден";
                label_test3_result.ForeColor = Color.Red;
            }
        }

        // функция: отображает нейтральные результаты
        private void test_neutral_show()
        {
            label_test1_result.Text = "Нет результата";
            label_test2_result.Text = "Нет результата";
            label_test3_result.Text = "Нет результата";
            label_test1_result.ForeColor = Color.Black;
            label_test2_result.ForeColor = Color.Black;
            label_test3_result.ForeColor = Color.Black;
        }
    }
}
