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
            do
            {
                Console.WriteLine("Введите размерность матрицы:");
                str = Console.ReadLine();
                OK = Int32.TryParse(str, out n);
            } while (!OK||n<2);
            int[,] matr = new int[n, n];
            int[,] newmatr = new int[n-1,n-1];
            do
            {
                Console.WriteLine("Введите координату X:");
                str = Console.ReadLine();
                OK = Int32.TryParse(str, out i);
            } while (!OK||i>n||i<=0);
            do
            {
                Console.WriteLine("Введите координату Y:");
                str = Console.ReadLine();
                OK = Int32.TryParse(str, out j);
            } while (!OK || j > n || j <= 0);
            Random rng = new Random();
            Console.WriteLine("Исходная матрица: ");
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
            for (int k = 0; k < i - 1; k++)
            {
                for (int t = 0; t < j - 1; t++)
                {
                    newmatr[k, t] = matr[k, t];
                }
                for (int t = j; t < n; t++)
                {
                    newmatr[k,t-1] = matr[k, t];
                }
            }
            for (int k = i; k < n; k++)
            {
                for (int t = 0; t < j - 1; t++)
                {
                    newmatr[k-1, t] = matr[k, t];
                }
                for (int t = j; t < n; t++)
                {
                    newmatr[k-1, t - 1] = matr[k, t];
                }
            }
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
