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

        private void btn_generate_Click(object sender, EventArgs e)
        {
            // Ждущий курсор и неактивное окно на время генерации
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

        private void autotest_CheckedChanged(object sender, EventArgs e)
        {
            if(autotest.Checked == true)
            {
                btn_test_Click(null, null);
            }
        }

        private void btn_test_Click(object sender, EventArgs e)
        {
            if (global.sequence.Length >= txt_seqLength.Value)
            {
                global.test1 = alg.test1_frequency(global.sequence);
                global.test2 = alg.test2_SameBits(global.sequence);
                global.test3 = alg.test3_arbitrary_deviations(global.sequence);
            }
        }
    }
}
