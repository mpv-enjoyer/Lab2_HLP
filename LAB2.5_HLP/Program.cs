using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB2._5_HLP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const short matrix_size = 25;
            short[] left = new short[matrix_size * matrix_size];
            short[] right = new short[matrix_size * matrix_size];
            for (int i = 0; i < matrix_size * matrix_size; i++) //Пример заполнения матриц
            {
                left[i] = (short)(i%19);
                right[i] = (short)((i + 5) % 15);
            }
            for (int i = 0; i < matrix_size * matrix_size; i++)
            {
                if (i % matrix_size == 0)
                {
                    Console.WriteLine();
                }
                Console.Write(left[i] + " ");
            }
            Console.WriteLine();
            for (int j = 0; j < matrix_size * matrix_size; j++)
            {
                if (j % matrix_size == 0)
                {
                    Console.WriteLine();
                }
                Console.Write(right[j] + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
            int[] result = new int[matrix_size * matrix_size];
            for (int i = 0; i < matrix_size; i++)
            {
                for (int j = 0; j < matrix_size; j++)
                {
                    int output_sum = 0;
                    for (int k = 0; k < matrix_size; k++)
                    {
                        output_sum += left[i * matrix_size + k] * right[j + k * matrix_size];
                    }
                    result[i * matrix_size + j] = output_sum;
                    Console.Write(output_sum + ", ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
