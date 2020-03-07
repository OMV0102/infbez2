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
        public static String RSA_algorithm(Int32 m) 
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
        // проверяет, что последовательность равномерно распределенная
        // Возвращает true, если тест пройден, иначе false
        public static bool test1_frequency(String sequence)
        {
            bool result = false; // результат теста
            Int32 n = sequence.Length; // длина последовательности
            Int32 Sn = 0; // сумма элементов последовательности
            double S = 0.0; // статистика S

            // ШАГ 1 и 2
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

            // ШАГ 3
            S = Math.Abs(Sn) / Math.Sqrt(n); // посчитали статистику S

            // ШАГ 4
            if (S <= global.a) // Если статистика S меньше уровня значимости
                result = true; // Тест пройден

            global.test1_S = S;
            return result;
        }

        // Тест на последовательность одинаковы бит 
        //    проверяет, является ли кол-во цепочек 0 и 1 разной длины
        //    примерно приближенна к кол-ву в истинно случайной послед.
        // Возвращает true, если тест пройден, иначе false
        public static bool test2_SameBits(String sequence)
        {
            bool result = false; // результат теста
            Int32 n = sequence.Length; // длина последовательности
            Double nd = Convert.ToDouble(n); //Длина последовательности Double 
            Double p = 0.0; // Частота встречаемости 1
            Double Vn;
            double S = 0.0; // статистика S

            // ШАГ 1
            // вычисляем p - частоту встречаемости 1
            for (int i = 0; i < n; i++) 
            {
                if (sequence[i] == '1')
                    p += 1.0;
            }
            p /= p / Convert.ToDouble(n);

            // ШАГ 2
            // Вычисляется значение Vn
            Vn = 1.0;
            for(int i = 0; i < n-1; i++)
            {
                if (sequence[i] != sequence[i]) // если два смежных бита разные
                    Vn += 1.0; // прибавляем единицу, иначе ноль
            }

            // ШАГ 3
            // Вычисляется статистика S
            S = Math.Abs(Vn - 2.0 * n * p * (1 - p)); // Посчитали числитель
            S /= 2.0 * Math.Sqrt(2.0 * n) * p * (1.0 - p); // Поделили на знаменатель

            // ШАГ 4
            if (S <= global.a) // Если статистика S меньше уровня значимости
                result = true; // Тест пройден

            global.test2_S = S;
            return result;
        }

        // Расширенный тест на произвольные отклонения 
        //    определяет отклонения от ожидаемого числа посещений
        //    различных состояний при произвольном обходе
        // Возвращает true, если тест пройден, иначе false
        public static bool test3_arbitrary_deviations(String sequence)
        {
            bool result = false; // результат теста
            Int32 n = sequence.Length; // длина последовательности
            Double nd = Convert.ToDouble(n); //Длина последовательности в Double 
            Int32[] x = new Int32[n]; // Измененная последовательность
            Int32[] S = new Int32[n+2]; // новая последовательность 
            Int32 k = 0; // Количество 0 в оследовательности S
            Double L = 0.0; // Значение L в 4 шаге
            Int32[] j = new Int32[18] // j-ые состояния
                { -9, -8, -7, -6, -5, -4, -3, -2, -1, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Int32[] ej = new Int32[18]  // ej показывает сколько раз состоянии j встречается в последовательности S
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
            double[] Yj = new double[18] // Статистики для каждого состояния j
                {0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0};

            // ШАГ 1
            // Заполняем последовательность по новому
            // Все нули меняем на -1
            for (int i = 0; i < n; i++)
            {
                if (sequence[i] == '1')
                    x[i] = 1;
                else if (sequence[i] == '0')
                    x[i] = -1;
            }

            // ШАГ 2 и 3
            // Вычисляем новую последовательность
            S[0] = 0;
            S[n+1] = 0;
            for(int i = 1; i < n+1; i++)
            {
                S[i] = S[i - 1] + x[i - 1];
            }

            // ШАГ 4 
            // считаем k = количество нулей в последовательности S
            // считаем L = k - 1
            for(int i = 0; i < n + 2; i++)
            {
                if (S[i] == 0)
                    k++;
            }
            L = Convert.ToDouble(k-1);

            // ШАГ 5
            // вычисляется ej - сколько раз появляется состояние j в последовательности S
            for (int i = 0; i < n + 2; i++)
            {
                switch (S[i])
                {
                    case (-9): ej[0]++; break;
                    case (-8): ej[1]++; break;
                    case (-7): ej[2]++; break;
                    case (-6): ej[3]++; break;
                    case (-5): ej[4]++; break;
                    case (-4): ej[5]++; break;
                    case (-3): ej[6]++; break;
                    case (-2): ej[7]++; break;
                    case (-1): ej[8]++; break;
                    case (1): ej[9]++; break;
                    case (2): ej[10]++; break;
                    case (3): ej[11]++; break;
                    case (4): ej[12]++; break;
                    case (5): ej[13]++; break;
                    case (6): ej[14]++; break;
                    case (7): ej[15]++; break;
                    case (8): ej[16]++; break;
                    case (9): ej[17]++; break;
                    default: break;
                }
            }

            // ШАГ 6
            // Вычисляются 18шт статистик для каждого состояния j
            for(int i = 0; i < 18; i++)
            {
                Yj[i] = Math.Abs(Convert.ToDouble(ej[i])-L); // Числитель |ej - L|
                Yj[i] /= Math.Sqrt(2.0 * L * (4.0 * Math.Abs(Convert.ToDouble(j[i])) - 2.0)); // Делим на знаменатель sqrt(2L(4|j|-2))
            }

            // ШАГ 7
            // Проверяем, что все 18шт статистик Yj меньше/равны уровня значимости
            // Если хоть одна больше, тест не пройден
            result = true;
            for(int i = 0; result == true && i < 18; i++)
            {
                if (Yj[i] > global.a)
                    result = false;
            }

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
        static public double a = 1.82138636; // допустимый уровень значимости в тесте
        static public String sequence; // Сгенерированная последовательность бит
        static public bool test1; // Результат выполнения 1 теста
        static public bool test2; // Результат выполнения 2 теста
        static public bool test3; // Результат выполнения 3 теста
        static public double test1_S; // Значение статистики S в 1 тесте
        static public double test2_S; // Значение статистики S в 2 тесте
        static public double test3_S; // Значение статистики S в 3 тесте
    }
}
