using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB2._2_HLP
{
    internal class Program
    {
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
            var input = input_ints("Input N elements: ");
            int N = input.Length;
            Array.Resize(ref input, N + 1);
            for (int i = 0; i < N / 2; i++)
            {
                input[N] = input[i];
                input[i] = input[(N / 2) + (N % 2) + i];
                input[(N / 2) + (N % 2) + i] = input[N];
            }
            Array.Resize(ref input, N);
            foreach (int num in input)
            {
                Console.WriteLine(num);
            }
            Console.ReadKey();
        }
    }
}
