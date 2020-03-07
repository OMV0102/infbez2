﻿using System;
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
            global.simpleNumbersList = new List<Int32>();
            alg.loadSimpleNumber("prime_numbers.txt");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String str =  alg.RSA_algorithm(10000);
            bool test1 = alg.test_frequency(str);

            
        }
    }
}
