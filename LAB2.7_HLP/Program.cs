using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB2._7_HLP
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
        static void Sum_to_null(ref int[] array)
        {
            var len = array.Length;
            if (len == 0 || len == 1) return;
            if (array[1] == 0) array[1] = array[0];
            for (int i = 2; i < len; i++)
            {
                if (array[i] == 0) array[i] = array[i - 1] + array[i - 2];
            }
            return;
        }
        static void Main(string[] args)
        {
            int[] input = Input_ints("Input N elements: ");
            var N = input.Length;
            Sum_to_null(ref input);
            for (int i = 0; i < N; i++)
            {
                Console.Write(input[i] + " ");
            }
            Console.ReadKey();
        }
    }
}
