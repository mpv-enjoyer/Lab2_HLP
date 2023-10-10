using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB2._4_HLP
{

    internal class Program
    {
        static int[] input_ints(string name, int count)
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
            while (!parse_successful || input.Length!=count);
            return input;
        }
        static bool[] input_bool(string name, int count)
        {
            bool[] input;
            bool parse_successful;
            do
            {
                parse_successful = true;
                Console.Write(name);
                string[] input_array = Console.ReadLine().Split(' ');
                input = new bool[input_array.Length];
                for (int i = 0; i < input_array.Length; i++)
                {
                    int parsed_int;
                    parse_successful = int.TryParse(input_array[i], out parsed_int);
                    if (!parse_successful)
                    {
                        break;
                    }
                    else
                    {
                        input[i] = (parsed_int != 0);
                    }
                }
            }
            while (!parse_successful || input.Length != count);
            return input;
        }
        static void Main(string[] args)
        {
            int[] sizes = input_ints("n m: ", 2);
            int n = sizes[0];
            int m = sizes[1];
            bool[,] sold = new bool[n, m];
            for (int i = 0; i < n; i++)
            {
                bool[] temp = input_bool($"{i + 1} row: ", m);
                for (int j = 0; j < m; j++)
                {
                    sold.SetValue(temp[j], i, j);
                }
            }
            int want_free;
            string temp_input;
            do
            {
                Console.Write("seats: ");
                temp_input = Console.ReadLine();
            }
            while (!int.TryParse(temp_input, out want_free));
            int suggested_row = -1;
            for (int i = 0; i < n && suggested_row == -1; i++)
            {
                int counter = 0;
                for (int j = 0; j < m; j++)
                {
                    if (sold[i, j]) counter = 0;
                    else counter++;
                    if (counter == want_free)
                    {
                        suggested_row = i + 1;
                        break;
                    }
                }
            }
            Console.WriteLine($"Output row: {suggested_row}");
            Console.ReadKey();
        }
    }
}
