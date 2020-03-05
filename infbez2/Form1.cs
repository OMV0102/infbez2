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
            var_global.simpleNumbersList = new List<BigInteger>() {2, 3, 5,7 ,11, 13, 17, 19, 23, 29 , 31, 37 , 41, 43, 47, 53,
                                                                   59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 107, 109, 113,
                                                                   127, 131, 137, 139, 149, 151, 163,167, 173, 179, 181, 191, 193,
                                                                   197, 199, 211, 223, 227, 229, 233, 239, 241, 251, 257, 263, 269,
                                                                   271, 277, 281, 283, 293, 307, 311, 313, 317, 331, 337, 347, 349, 353};
            
            Form1.generateSimpleNumbers(2147483647); // макс для Int32 = 2 147 483 647

        }


        // Проверка числа на простоту методом пробных делений и решета эратосфена
        static public void generateSimpleNumbers(BigInteger n)
        {
            //BigInteger n_sqrt = 10000 * (BigInteger)Math.Sqrt((Double) n);
            BigInteger n_sqrt = 1500000;


            //var_global.simpleNumbersList.Clear();

            BigInteger simpleCount = 0;
            bool flag;
            BigInteger start = var_global.simpleNumbersList.Max() + 1;
            // Заполнили список числами от 2 до корня из n
            for (BigInteger i = start; i < n_sqrt; i++)
            {
                simpleCount = var_global.simpleNumbersList.Count;
                flag = true;
                for (int k = 0; flag == true && k < simpleCount; k++)
                    if(i % var_global.simpleNumbersList[k] == 0) 
                    {
                        flag = false;
                    }
                    
                if (flag == true)
                    var_global.simpleNumbersList.Add(i);
            }
        }
    }
}
