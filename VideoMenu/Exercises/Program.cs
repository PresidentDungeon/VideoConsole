using System;
using System.Reflection.Metadata.Ecma335;

namespace Exercises
{
    class Program
    {
        private int AbsoluteValue(int value)
        {
            return (value > 0) ? value : 0 - value;
        }

        private int Devisible(int number1, int number2)
        {
            if(number1%2 == 0 && number2%2 == 0 || number1%3 == 0 && number2%3 == 0)
            {
                return number1 * number2;
            }

            return number1 + number2;
        }

        private bool Uppercase(string word)
        {
            return word.Equals(word.ToUpper());
        }

        private bool IfGreaterThan(params int[] values)
        {
            return (values[0] * values[1] > values[2] || values[0] + values[1] > values[2]) ? true : false;
        }

        private bool IsEven(int value)
        {
            return value % 2 == 0;
        }

        private bool SortedAscended(params int[] values)
        {

            for (int i = 0; i < values.Length-1; i++)
            {
                if(values[i] > values[i + 1])
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsNeighbour(string word)
        {
            return (word[0] == word[1] + 1 || word[0] == word[1] - 1 || word[2] == word[1] + 1 || word[2] == word[1] - 1) ? true : false;
        }

        private string PNZ(int value)
        {
            if (value > 0)
            {
                return "POSITIVE";
            }
            else if(value < 0)
            {
                return "NEGATIVE";
            }
            return "ZERO";
        }

        private bool IsLeapYear(int year)
        {
            if (year % 4 == 0 && year % 100 != 0 || year % 400 == 0) 
            {
                return true;
            }
            return false;
        }


        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.PNZ(5));
            Console.ReadLine();
        }
    }
}
