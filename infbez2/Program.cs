using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Numerics;
using System.IO;
using System.Text;
using System.Collections;

namespace infbez2
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    public static class alg // Основной класс с методами
    {
        // Генерация простых чисел до n надежным перебором
        static public void generateSimpleNumbers(BigInteger n)
        {
            //var_global.simpleNumbersList.Clear();

            BigInteger simpleCount = 0;
            bool flag;
            Int32 start = 2;
            if (global.simpleNumbersList.Count() > 1)
                start = global.simpleNumbersList.Max() + 1;

            // Заполнили список числами от 2 до корня из n
            for (Int32 i = start; i < n; i++)
            {
                simpleCount = global.simpleNumbersList.Count;
                flag = true;
                for (int k = 0; flag == true && k < simpleCount; k++)
                    if (i % global.simpleNumbersList[k] == 0)
                    {
                        flag = false;
                    }

                if (flag == true)
                    global.simpleNumbersList.Add(i);
            }
        }

        // сохранение простых чисел в файл из списка
        public static void saveSimpleNumber(String filename)
        {
            String fullPath = Application.StartupPath + "\\" + filename;
            int N = global.simpleNumbersList.Count();
            StreamWriter sw = new StreamWriter(fullPath, false, Encoding.UTF8);

            for (int i = 0; i < N; i++)
                sw.WriteLine(global.simpleNumbersList[i]);

            sw.Close();
        }

        // загрузка уже найденных простых чисел из файла в список
        public static void loadSimpleNumber(String filename)
        {
            String fullPath = Application.StartupPath + "\\" + filename;
            if (File.Exists(fullPath) == true) // Если фай по пути существует
            {
                // Создали поток для считывания
                StreamReader sr = new StreamReader(fullPath, Encoding.UTF8);
                String str = "";
                Int32 num = 0;
                while (sr.EndOfStream == false) // Считываем пока поток не пуст
                {
                    str = sr.ReadLine(); //Считали строку с числом
                    // Преобразовали из строки в число
                    if (Int32.TryParse(str, out num) == true)
                        global.simpleNumbersList.Add(num);
                }

                sr.Close();
            }
        }

        // RSA алгоритм генерирует последовательность битов заданной длиной m
        public static String RSA_algorithm(int m) 
        {
            String result_str = "";

            Int64 p, q; // 2 различных больших простых числа
            Int64 N; // Число N = p*q 
            Int64 f_n; // значение ф(N) функции Эйлера
            Int32 k = 0; // Степень k случайно выбираемая на 2 шаге
            BigInteger u0 =0 ; // случайное стартовое значение
            BigInteger ui = 0, u_prev = 0; //текущее значение и предыдущее сгенерированное
            Int32 min = 78500, max = global.simpleNumbersList.Count; // ИНДЕКСЫ границ генерации числа
            global.rng = new RNGCryptoServiceProvider(); // Выделили память под генератор случайных чисел
            p = 0;
            // ШАГ 1 - Сгенировали случайные числа
            p = global.simpleNumbersList[(Int32)alg.PRNG(min, max)];
            q = global.simpleNumbersList[(Int32)alg.PRNG(min, max)];
            N = p * q;
            f_n = (p - 1) * (q - 1);

            // ШАГ 2 - Выбор случайного числа k взаимно простого с ф(N)
            //         Взаимно простое, то есть нет общих делителей у k и ф(N)
            //         Лучше выбирать k сразу простым числом (у простого всего 2 делителя)
            do
            {
                int max_index = 0;
                int index;
                // Если значение функции эйлера больше или равно, чем последний эл. списка с простыми числами
                if (global.simpleNumbersList[global.simpleNumbersList.Count - 1] <= f_n)
                    max_index = global.simpleNumbersList.Count - 1; // то макс и будет последний элемент
                else
                    max_index = alg.getIndexFromList(f_n) - 1; // иначе простое число меньшее значения функции Эйлера

                index = Convert.ToInt32(alg.PRNG(0, max_index)); // Сгенерировали случайно индекс
                k = global.simpleNumbersList[index]; // По индексу выбрали простое число для k

            } while (alg.GCD(k, f_n) != 1); // Ищем k, пока НОД не = 1

            // ШАГ 3 - Выбор случайного стартового 1 < u0 < N-1
            u0 = alg.PRNG(2, N-1);

            // ШАГ 4 Формирование бит последовательности
            string temp = "";

            u_prev = u0;  //для 0 итерации 

            for(int i = 0; i < m; i++) // Цикл генерации
            {
                ui = BigInteger.ModPow(u_prev, k, N); // (u_prev^k) mod N

                // Перевели ui в биты
                temp = string.Concat(ui.ToByteArray().Select(b => Convert.ToString(b, 2).PadLeft(8, '0')).Reverse());
                result_str += temp[temp.Length-1];  // Запомнили младший бит

                u_prev = ui; // u[i] становиться u[i-1]
            }

            global.rng.Dispose(); // Освободили память от ГПСЧ
            return result_str; // Строка с генерированной последовательностью длиной m
        }

        // Частотный тест сгенерированной последовательности
        // проверяет, что последовательность является случайной
        // Возвращает true, если тест пройден, иначе false
        public static bool test_frequency(String sequence)
        {
            bool result = false; // результат теста
            Int32 n = sequence.Length; // длина последовательности
            Int32 Sn = 0; // сумма элементов последовательности
            double S = 0.0;

            // Складываем элементы последовательности
            for(int i = 0; i < n; i++)
            {
                if(sequence[i] == '1') // Если единица - прибавляем
                {
                    Sn += 1;
                }
                else if (sequence[i] == '0') // Если ноль - отнимаем
                {
                    Sn -= 1;
                }
            }

            S = Math.Abs(Sn) / Math.Sqrt(n); // посчитали статистику S

            if (S <= 1.82138636) // Если статистика S меньше границы
                result = true; // Тест пройден


            return result;
        }

        // Генератор случайного числа
        //       min включается в промежуток, max НЕ включается
        //       Использовать ТОЛЬКО , если выделена память для global.rng
        //       min обязательно меньше max
        public static Int64 PRNG(Int64 min, Int64 max)
        {
            Int64 result = 0;
            if (global.rng != null || min < max)
            {
                byte[] b = new byte[7]; // Место под 7 байт числа
                global.rng.GetBytes(b); // Сгенерировали случайны байты
                BitArray bits = new BitArray(b); // Байты в биты
                result = alg.binToDec(bits); // Из битов в число 
                result = result % (max - min) + min; // Сделади число в нужном промежутке
                
            }
            return result;
        }

        // перевод из двоичного числа (биты) в число десятичное 
        // Используется в PRNG
        public static Int64 binToDec(BitArray bits_in)
        {
            BitArray b = new BitArray(bits_in);
            Int64 result = 0;
            int N = b.Length;
            for (int i = N - 1; i >= 0; i--)
            {
                if (b[i] == true)
                {
                    result += Convert.ToInt64(Math.Pow(2, N - 1 - i));
                }
            }
            return result;
        }

        // Поиск НОД двух чисел
        // Используется в 2 шаге алгоритма RSA
        static public Int64 GCD(Int64 a, Int64 b)
        {
            while (b != 0)
            {
                Int64 t = b;
                b = a % b;
                a = t;
            }
            return a;
        }

        // Бинарный поиск, индекс по элементу в списке простых чисел или ближайший индекс сверху
        // Используется в 2 шаге алгоритма RSA
        public static int getIndexFromList(Int64 num)
        {
            int start = 0;
            int end = global.simpleNumbersList.Count;

            while (start < end)
            {
                int half = (end + start) / 2;
                if (global.simpleNumbersList[half] == num) return half;
                if (global.simpleNumbersList[half] < num) start = half + 1;
                else end = half - 1;
            }
            while (start < global.simpleNumbersList.Count)
                if (global.simpleNumbersList[start] > num) return start;
                else start++;
            return -1;
        }
    }


    static public class global
    {
        static public List<Int32> simpleNumbersList; // Список с простыми числами
        static public RNGCryptoServiceProvider rng; // объект класса генератора псевдослучайных чисел
    }
}
