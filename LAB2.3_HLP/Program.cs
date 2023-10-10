using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LAB2._3_HLP
{
    internal class Program
    {
        static int[] generate_array(int len, Random rng)
        {
            int[] array = new int[len];
            for (int i = 0; i < len; i++)
            {
                array[i] = rng.Next(1000);
            }
            return array;
        }
        static bool sum_array(int[] left, int[] right, out int[] output)
        {
            if (left.Length != right.Length)
            {
                output = new int[0];
                return false;
            }
            output = new int[left.Length];
            for (int i = 0; i < left.Length; i++)
            {
                output[i] = left[i] + right[i];
            }
            return true;
        }
        static int[] multiply_array(int[] array, int num)
        {
            int[] output = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                output[i] = array[i] * num;
            }
            return output;
        }
        static bool match_array(int[] left, int[] right, out bool[] output)
        {
            bool full_match = true;
            int min_len = Math.Min(left.Length, right.Length);
            output = new bool[min_len];
            for (int i = 0; i < min_len; i++)
            {
                if (left[i] != right[i])
                {
                    output[i] = false;
                    full_match = false;
                }
                else
                {
                    output[i] = true;
                }
            }
            return full_match;
        }
        static void print_array<T>(T[] array, string label = "")
        {
            Console.Write(label + " [ ");
            foreach (T num in array)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine("]");
        }
        static int[] quicksort_array(int[] array)
        {
            if (array.Length == 0)
            {
                return array;
            }
            int separator = array[array.Length - 1];
            Array.Resize(ref array, array.Length - 1);
            int left_size = 0;
            int right_size = 0;
            foreach (int num in array)
            {
                if (num <= separator) left_size++;
                if (num >  separator) right_size++;
            }
            int[] left = new int[left_size];
            int[] right = new int[right_size];
            int left_id = 0;
            int right_id = 0;
            foreach (int num in array)
            {
                if (num <= separator)
                {
                    left[left_id] = num;
                    left_id++;
                }
                if (num > separator)
                {
                    right[right_id] = num;
                    right_id++;
                }
            }
            int[] output = new int[array.Length + 1];
            quicksort_array(right).CopyTo(output, 0);
            output[right_size] = separator;
            quicksort_array(left).CopyTo(output, right_size + 1);
            return output;
        }
        static int min_array(int[] array)
        {
            if (array == null) throw new InvalidOperationException();
            int min = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < min) min = array[i];
            }
            return min;
        }
        static int max_array(int[] array)
        {
            if (array == null) throw new InvalidOperationException();
            int min = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > min) min = array[i];
            }
            return min;
        }
        static float average_array(int[] array)
        {
            float sum = 0;
            foreach (int item in array)
            {
                sum += item;
            }
            sum = sum / array.Length;
            return sum;
        }
        static void Main(string[] args)
        {
            Random rng = new Random();
            int[] arr = generate_array(6, rng);
            print_array(arr, "Generated array");
            print_array(quicksort_array(arr), "Sorted array");
            print_array(multiply_array(arr, 4), "Multiplied by 4");
            Console.WriteLine("Max " + max_array(arr));
            Console.WriteLine("Min " + min_array(arr));
            Console.WriteLine("Average " + average_array(arr));
            int[] arr2 = generate_array(6, rng);
            arr2[1] = arr[1];
            arr2[4] = arr[4]; //Добавляем одинаковые элементы для сравнения
            print_array(arr2, "Second array");
            bool[] match;
            match_array(arr, arr2, out match);
            print_array(match, "Match");
            int[] sum;
            sum_array(arr, arr2, out sum);
            print_array(sum, "Sum");
            Console.ReadKey();
        }
    }
}
