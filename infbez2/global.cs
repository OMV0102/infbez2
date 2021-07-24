using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace infbez2
{
    // Класс с основными переменными
    static public class global
    {
        static public List<Int32> simpleNumbersList; // Список с простыми числами
        static public String filename = "prime_numbers.txt";
        static public String fullpath = Application.StartupPath + "\\" + global.filename;
        static public RNGCryptoServiceProvider rng; // объект класса генератора псевдослучайных чисел
        static public double a = 1.82138636; // допустимый уровень значимости в тесте
        static public String sequence = ""; // Сгенерированная последовательность бит

        static public bool test1; // Результат выполнения 1 теста
        static public bool test2; // Результат выполнения 2 теста
        static public bool test3; // Результат выполнения 3 теста
        static public double test1_S; // Значение статистики S в 1 тесте
        static public double test2_S; // Значение статистики S в 2 тесте
        static public double test3_S; // Значение статистики S в 3 тесте
    }
}
