using System;

namespace ConsoleApp1
{
    class Program
    {
        static int[,] genArray(int rows, int cols, int min = -10, int max = 11)
        {
            int[,] arr = new int[rows, cols];
            for (int i = 0; i < arr.GetLength(0); i++)
                for (int j = 0; j < arr.GetLength(1); j++)
                    arr[i, j] = random.Next(min, max);
            return arr;
        }

        static Random random = new Random();
        static void Main(string[] args)
        {

            Matrix m1 = new Matrix(genArray(3, 4));
            Matrix m2 = new Matrix(genArray(1, 5));
            Console.WriteLine(m1);
            Console.WriteLine(m1.transpose());
            Console.Read();
        }
    }
}
