using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB2._1_HLP
{
    internal class Program
    {
        static int input_int(string name)
        {
            int a;
            do
            {
                Console.Write(name);
            }
            while
            (!(int.TryParse(Console.ReadLine(), out a)));
            return a;
        }
        static int[] input_ints(string name)
        {
            int[] input;
            bool parse_successful;
            do
            {
                parse_successful = true;
                Console.Write(name);
                string[] input_array = Console.ReadLine().Split(' ');
                input = new int[input_array.Length];
                for (int i = 0; i < input_array.Length; i++)
                {
                    parse_successful = int.TryParse(input_array[i], out input[i]);
                    if (!parse_successful)
                    {
                        break;
                    }
                }
            }
            while (!parse_successful);
            return input;
        }
        static void Main(string[] args)
        {
            int[] input = input_ints("Input N elements: ");
            int N = input.Length;
            int[] input_2 = input_ints("Input M elements: ");
            int M = input_2.Length;
            int K;
            do
            {
                K = input_int("Input K: ");
            }
            while (K >= N);
            Array.Resize(ref input, N + M);
            Array.Copy(input, K, input, K + M, N - K);
            Array.Copy(input_2, 0, input, K, M);
            foreach (int num in input)
            {
                Console.WriteLine(num);
            }
            Console.ReadKey();
        }
    }
}
