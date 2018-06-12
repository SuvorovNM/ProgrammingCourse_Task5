using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            bool OK = true;
            int i, j,n;
            string str;
            //Создание квадратной матрицы
            do
            {
                if (!OK) Console.WriteLine("Ошибка ввода");
                //Проверка на корректность ввода
                Console.WriteLine("Введите размерность матрицы (n>=2):");
                str = Console.ReadLine();
                OK = Int32.TryParse(str, out n);
            } while (!OK||n<2);//Пока не введено целое число>= 2
            int[,] matr = new int[n, n];//Инициализация исходной матрицы
            int[,] newmatr = new int[n-1,n-1];//Инициализация полученной матрицы
            //Ввод i и j, по координатам которых нужно удалить i-тую строку и j-тый столбец
            do
            {
                if (!OK) Console.WriteLine("Ошибка ввода");
                Console.WriteLine("Введите координату X:");
                str = Console.ReadLine();
                OK = Int32.TryParse(str, out i);
            } while (!OK||i>n||i<=0);
            do
            {
                if (!OK) Console.WriteLine("Ошибка ввода");
                Console.WriteLine("Введите координату Y:");
                str = Console.ReadLine();
                OK = Int32.TryParse(str, out j);
            } while (!OK || j > n || j <= 0);
            Random rng = new Random();
            Console.WriteLine("Исходная матрица: ");
            //Заполнение исходной матрицы случайными числами
            for (int k = 0; k < n; k++)
            { 
                for (int t = 0; t < n; t++)
                { 
                    matr[k, t] = rng.Next(0, 1000);
                    Console.Write(matr[k,t]+" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Полученная матрица: ");
            //Новая матрица - соединенные 4 части старой, разделенные i-той строкой и j-тым столбцом
            for (int k = 0; k < i - 1; k++)
            {
                //Левая верхняя часть
                for (int t = 0; t < j - 1; t++)
                {
                    newmatr[k, t] = matr[k, t];
                }
                //Левая нижняя часть
                for (int t = j; t < n; t++)
                {
                    newmatr[k,t-1] = matr[k, t];
                }
            }
            for (int k = i; k < n; k++)
            {
                //Правая верхняя часть
                for (int t = 0; t < j - 1; t++)
                {
                    newmatr[k-1, t] = matr[k, t];
                }
                //Правая нижняя часть
                for (int t = j; t < n; t++)
                {
                    newmatr[k-1, t - 1] = matr[k, t];
                }
            }
            //Вывод полученной матрицы
            for (int k = 0; k < n-1; k++)
            {
                for (int t = 0; t < n-1; t++)
                {
                    Console.Write(newmatr[k, t] + " ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
