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
            var_global.simpleNumbersList = new List<BigInteger>();
            Form1.generateSimpleNumbers(2147483645); // макс для Int32 = 2 147 483 647

        }


        // Проверка числа на простоту методом пробных делений и решета эратосфена
        static public void generateSimpleNumbers(BigInteger n)
        {

            var_global.simpleNumbersList.Clear();

            // Заполнили список числами от 2 до корня из n
            for (Int32 i = 2; i <= n; i++)
            {
                var_global.simpleNumbersList.Add(i);
            }

            // Оставили в списке только простые числа от 2 до корня из n
            for (Int32 i = 0; i < var_global.simpleNumbersList.Count; i++)
            {
                for (Int32 k = i + 1; k < var_global.simpleNumbersList.Count; k++)
                {
                    if (var_global.simpleNumbersList[k] % var_global.simpleNumbersList[i] == 0)
                    {
                        var_global.simpleNumbersList.RemoveAt(k);
                        k--;
                    }
                }
            }

        }
    }
}
