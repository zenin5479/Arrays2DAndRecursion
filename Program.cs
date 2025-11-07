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
            int j = 0;
            Console.Write("[");
            while (j < grid.Length)
            {
               if (j == grid.Length - 1)
               {
                  Console.Write(grid[j] + "");
               }
               else
               {
                  Console.Write(grid[j] + ", ");
               }

               j++;
            }

            Console.WriteLine("]");
         }

         // Метод поиска чисел больше нуля
         void ZeroArray(int[] range)
         {
            int count = 0;
            int k = 0;
            while (k < range.Length)
            {
               if (range[k] > 0)
               {
                  count++;
               }
               k++;
            }

            Console.WriteLine("Количество чисел > 0 = " + count);
         }

         FillArray(table);
         PrintArray(table);
         ZeroArray(table);

         Console.WriteLine("----------------------------------------");
         Console.WriteLine("Нахождение точки пересечения двух прямых");
         Console.WriteLine("----------------------------------------");
         Console.Write("Введите b1: ");
         double b1 = Convert.ToDouble(Console.ReadLine());
         Console.Write("Введите k1: ");
         double k1 = Convert.ToDouble(Console.ReadLine());
         Console.Write("Введите b2: ");
         double b2 = Convert.ToDouble(Console.ReadLine());
         Console.Write("Введите k2: ");
         double k2 = Convert.ToDouble(Console.ReadLine());
         // Метод нахождения точки пересечения прямых
         void PointIntersection(double kOne, double bOne, double kTwo, double bTwo)
         {
            // Сравниваем значения double используя метод CompareTo(Double) 
            if (kOne.CompareTo(kTwo) == 0)
            {
               Console.WriteLine("Графики не пересекаются");
            }
            else
            {
               double x = (bTwo - bOne) / (kOne - kTwo);
               double y = kOne * x + bOne;
               //Console.Write("Точка пересечения: [{0:f2}; {1:f2}]", x, y);
               Console.WriteLine("Точка пересечения: [{0:f}; {1:f}]", x, y);
               //Console.WriteLine("Точка пересечения: [{0}; {1}]", x, y);
            }

            //// Сравниваем значения double используя метод Equals(Double)
            //if (kOne.Equals(kTwo))
            //{
            //   Console.WriteLine("Графики не пересекаются");
            //}
            //else
            //{
            //   double x = (bTwo - bOne) / (kOne - kTwo);
            //   double y = kOne * x + bOne;
            //   //Console.Write("Точка пересечения: [{0:f2}; {1:f2}]", x, y);
            //   Console.WriteLine("Точка пересечения: [{0:f}; {1:f}]", x, y);
            //   //Console.WriteLine("Точка пересечения: [{0}; {1}]", x, y);
            //}
         }

         PointIntersection(k1, b1, k2, b2);

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
               int j = 0;
               while (j < glasnie.Length)
               {
                  if (glasnie[j] == str[pos])
                  {
                     count++;
                  }

                  j++;
               }

               pos++;
               return count + SearchSymbol(str, pos);
            }

            return 0;
         }

         Console.WriteLine("Количество гласных букв в тексте: " + str + " = " + SearchSymbol(str));

         
         
         bool IsPowerOfThree(int n)
         {
            if (n < 1)
            {
               return false;
            }

            if (n == 1)
            {
               return true;
            }

            if (n % 3 != 0)
            {
               return false;
            }

            return IsPowerOfThree(n / 3);
         }

         int r = 0;
         bool jjk= IsPowerOfThree(r);
      }

     
   }
}