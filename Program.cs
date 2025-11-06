using System;

// Двумерные массивы и рекурсия
// - Задача: Пользователь вводит с клавиатуры M чисел
// Посчитайте, сколько чисел больше 0 ввёл пользователь
// - Задача: Напишите программу, которая найдёт точку пересечения двух прямых, заданных уравнениями y = k1 * x + b1, y = k2 * x + b2
// значения b1, k1, b2 и k2 задаются пользователем
// - Задача: Написать перевод десятичного числа в двоичное, используя рекурсию
// - Задача: На вход подаётся поговорка “без труда не выловишь и рыбку из пруда”
// Используя рекурсию, подсчитайте, сколько в поговорке гласных букв
// - Задача: Дано число N
// Используя только операцию деления и рекурсию, определите, что оно является степенью числа 3

namespace Arrays2DAndRecursion
{
   internal class Program
   {
      static void Main()
      {
         Console.WriteLine("-----------------------------------------------------");
         Console.WriteLine("Определение введенного количества положительных чисел");
         Console.WriteLine("-----------------------------------------------------");
         Console.WriteLine("Введите количество чисел:");
         int m = Convert.ToInt32(Console.ReadLine());
         int[] table = new int[m];
         // Метод заполнения массива случайными целыми числами
         void FillArray(int[] matrix)
         {
            Random chance = new Random();
            int i = 0;
            while (i < matrix.Length)
            {
               matrix[i] = chance.Next(-999, 1000);
               i++;
            }
         }

         // Метод распечатки массива
         void PrintArray(int[] grid)
         {
            int s = 0;
            Console.Write("[");
            while (s < grid.Length)
            {
               if (s == grid.Length - 1)
               {
                  Console.Write(grid[s] + "");
               }
               else
               {
                  Console.Write(grid[s] + ", ");
               }

               s++;
            }

            Console.WriteLine("]");
         }

         // Метод распечатки массива
         void OutputtingArray(int[] cluster)
         {
            int s = 0;
            Console.Write("[");
            while (s < cluster.Length)
            {
               if (s == cluster.Length - 1)
               {
                  Console.Write(cluster[s] + "");
               }
               else
               {
                  Console.Write(cluster[s] + ", ");
               }

               s++;
            }

            Console.WriteLine("]");
         }

         // Метод поиска чисел больше нуля
         void ZeroArray(int[] range)
         {
            int count = 0;
            int i = 0;
            while (i < range.Length)
            {
               if (range[i] > 0)
               {
                  count++;
               }
               i++;
            }

            Console.WriteLine("Количество чисел > 0 = " + count);
         }

         FillArray(table);
         PrintArray(table);
         ZeroArray(table);

         Console.WriteLine("----------------------------------------");
         Console.WriteLine("Нахождение точки пересечения двух прямых");
         Console.WriteLine("----------------------------------------");
         Console.Write("Введите k1: ");
         double k1 = Convert.ToDouble(Console.ReadLine());
         Console.Write("Введите b1: ");
         double b1 = Convert.ToDouble(Console.ReadLine());
         Console.Write("Введите k2: ");
         double k2 = Convert.ToDouble(Console.ReadLine());
         Console.Write("Введите b2: ");
         double b2 = Convert.ToDouble(Console.ReadLine());

         PointIntersection(k1, b1, k2, b2);
         // Метод нахождения точки пересечения прямых
         void PointIntersection(double k1, double b1, double k2, double b2)
         {
            if (k1 == k2)
            {
               Console.WriteLine("Графики не пересекаются");
            }
            else
            {
               double x = (b2 - b1) / (k1 - k2);
               double y = k1 * x + b1;
               Console.WriteLine("Точка пересечения: [" + x + "; " + y + "]");
            }
         }

         Console.WriteLine("------------------------------------");
         Console.WriteLine("Перевод десятичного числа в двоичное");
         Console.WriteLine("------------------------------------");
         Console.WriteLine("Введите десятичное число:");
         int number = Convert.ToInt32(Console.ReadLine());
         // Метод перевода десятичного числа в двоичный
         string Dvcod(int number)
         {
            while (number >= 1)
            {
               string dvFigura1;
               dvFigura1 = Convert.ToString(number % 2);
               return Dvcod(number / 2) + dvFigura1;
            }

            return "";
         }

         Dvcod(number);
         Console.WriteLine("Десятичное число " + number + " = Двоичному числу " + Dvcod(number));

         Console.WriteLine("-------------------");
         Console.WriteLine("Расчет гласных букв");
         Console.WriteLine("-------------------");
         string str = "без труда не выловишь и рыбку из пруда";
         int pos = 0;

         int SearchSymbol(string str, int pos = 0)
         {
            char[] glasnie = { 'а', 'о', 'и', 'е', 'ё', 'э', 'ы', 'у', 'ю', 'я', 'А', 'О', 'И', 'Е', 'Ё', 'Э', 'Ы', 'У', 'Ю', 'Я' };
            int count = 0;
            if (pos < str.Length)
            {
               for (int j = 0; j < glasnie.Length; j++)
               {
                  if (glasnie[j] == str[pos])
                  {
                     count++;
                  }
               }

               pos++;
               return count + SearchSymbol(str, pos);
            }

            return 0;
         }

         Console.WriteLine("Количество гласных букв в тексте: " + str + " = " + SearchSymbol(str));
      }

      public static bool IsPowerOfThree(int n)
      {
         if (n < 1)
            return false;
         if (n == 1)
            return true;
         if (n % 3 != 0)
            return false;
         return IsPowerOfThree(n / 3);
      }
   }
}