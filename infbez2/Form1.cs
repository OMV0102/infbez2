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



            Form1.loadSimpleNumber("prime_numbers1.txt");
            Form1.generateSimpleNumbers(4001000); // макс для Int32 = 2 147 483 647
            Form1.saveSimpleNumber("prime_numbers2.txt");

        }


        // Генерация простых чисел до n надежным перебором
        static public void generateSimpleNumbers(BigInteger n)
        {
            //var_global.simpleNumbersList.Clear();

            BigInteger simpleCount = 0;
            bool flag;
            BigInteger start = 2;
            if (var_global.simpleNumbersList.Count() > 1)
                start = var_global.simpleNumbersList.Max() + 1;

            // Заполнили список числами от 2 до корня из n
            for (BigInteger i = start; i < n; i++)
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


        public static void saveSimpleNumber(String filename)
        {
            String fullPath = Application.StartupPath + "\\" + filename;
            int N = var_global.simpleNumbersList.Count();
            StreamWriter sw = new StreamWriter(fullPath, false, Encoding.UTF8);

            for (int i = 0; i < N; i++)
                sw.WriteLine(var_global.simpleNumbersList[i]);

            sw.Close();
        }

        public static void loadSimpleNumber(String filename)
        {
            String fullPath = Application.StartupPath + "\\" + filename;
            if (File.Exists(fullPath) == true)
            {

                int N = var_global.simpleNumbersList.Count();
                StreamReader sr = new StreamReader(fullPath, Encoding.UTF8);
                String str = "";
                BigInteger num = 0;
                while (sr.EndOfStream == false)
                {
                    str = sr.ReadLine();
                    if (BigInteger.TryParse(str, out num) == true)
                        var_global.simpleNumbersList.Add(num);
                }

                sr.Close();
            }
        }
    }
}
