using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB2._6_HLP
{
    internal class Program
    {
        static int[] Input_ints(string name)
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
            bool result = false;
            int[] input = Input_ints("input N elements: ");
            int N = input.Length;
            for (int i = 1; i < N; i++)
            {
                int temp = input[i] - input[i - 1];
                if (Math.Abs(temp) == 1)
                {
                    result = true;
                    break;
                }
            }
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
