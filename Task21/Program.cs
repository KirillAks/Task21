using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task21
{
    class Program
    {
        /*Имеется пустой участок земли (двумерный массив) и план сада, который необходимо реализовать.
        Эту задачу выполняют два садовника, которые не хотят встречаться друг с другом.
        Первый садовник начинает работу с верхнего левого угла сада и перемещается слева направо, сделав ряд, он спускается вниз.
        Второй садовник начинает работу с нижнего правого угла сада и перемещается снизу вверх, сделав ряд, он перемещается влево.
        Если садовник видит, что участок сада уже выполнен другим садовником, он идет дальше. Садовники должны работать параллельно.
        Создать многопоточное приложение, моделирующее работу садовников.*/

        static int n;
        static int m;
        static int[,] area;
        static void Main(string[] args)
        {
            Console.WriteLine("Введите целое число n");
            n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите целое число m");
            m = Convert.ToInt32(Console.ReadLine());
            area = new int[n, m];

            ThreadStart threadStart1 = new ThreadStart(Gardner1);
            Thread thread1 = new Thread(threadStart1);
            thread1.Start();

            ThreadStart threadStart2 = new ThreadStart(Gardner2);
            Thread thread2 = new Thread(threadStart2);
            thread2.Start();

            thread1.Join();
            thread2.Join();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(area[i, j] + " ");
                }
                Console.WriteLine();
            }
                        
            Console.ReadKey();
        }
        static void Gardner1()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (area[i, j] == 0)
                        area[i, j] = 1;
                    Thread.Sleep(1);
                }
            }
        }
        static void Gardner2()
        {
            for (int i = m-1; i > 0; i--)
            {
                for (int j = n-1; j > 0; j--)
                {
                    if (area[j, i] == 0)
                        area[j, i] = 2;
                    Thread.Sleep(1);
                }
            }
        }        
    }
}
