using System;
using System.Linq;

namespace MDK2LABA8
{
    class Program
    {
        static void Main(string[] args)
        {

            RunTests();

            Console.WriteLine("\nНажмите любую клавишу, чтобы выйти...");
            Console.ReadKey();
        }


        public static double InchesToCm(double inches)
        {
            if (inches < 0) return -1;
            return inches * 2.54;
        }

        public static int IsEven(int number)
        {
            return (number % 2 == 0) ? 1 : 0;
        }


        public static int GetMax(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0) return -999;
            int max = numbers[0];
            foreach (int n in numbers)
            {
                if (n > max) max = n;
            }
            return max;
        }


        public static int GetRemainder(int a, int b)
        {
            if (b == 0) return -1;
            return a % b;
        }


        public static double CalculateBank(double sum)
        {
            if (sum < 0) return -1;

            double percent;
            if (sum < 100) percent = 0.05;
            else if (sum <= 200) percent = 0.07;
            else percent = 0.10;

            return sum + (sum * percent);
        }

        public static void RunTests()
        {
            Console.WriteLine("=== ОТЧЕТ ПО ТЕСТОВЫМ СЦЕНАРИЯМ ===\n");

            void Check(string testName, object actual, object expected)
            {
             
                Console.WriteLine($"{testName}:");
                Console.WriteLine($"  - Ожидаемый результат: {expected}");
                Console.WriteLine($"  - Фактический результат: {actual}");
                Console.WriteLine("------------------------------------------");
            }

            Check("Конвертация (10 дюймов)", InchesToCm(10), 25.4);
            Check("Конвертация (ошибка: -5)", InchesToCm(-5), -1);

            Check("Четность числа (4)", IsEven(4), 1);
            Check("Четность числа (7)", IsEven(7), 0);

            Check("Поиск максимума {1, 5, 3}", GetMax(new int[] { 1, 5, 3 }), 5);
            Check("Поиск максимума (ошибка: пустой массив)", GetMax(new int[] { }), -999);

            Check("Остаток (10 / 3)", GetRemainder(10, 3), 1);
            Check("Остаток (ошибка: деление на 0)", GetRemainder(10, 0), -1);

            Check("Вклад < 100 (сумма 50)", CalculateBank(50), 52.5);
            Check("Вклад 100-200 (сумма 150)", CalculateBank(150), 160.5);
            Check("Вклад > 200 (сумма 300)", CalculateBank(300), 330);
            Check("Вклад (ошибка: отрицательная сумма)", CalculateBank(-10), -1);
        }
    }
}