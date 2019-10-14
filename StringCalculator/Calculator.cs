using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class Calculator
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers)) return 0;

            string[] delimiters = GetDelimiters(numbers);

            string finalList = RemoveDelimiterSpecification(numbers);
            
            return CountFromList(finalList, delimiters);
        }

        private int GetIntegerFromString(string number)
        {
            int numberToReturn;
            if (Int32.TryParse(number, out numberToReturn))
            {
                return numberToReturn;
            }
            else
            {
                throw new Exception("Value was not a number");
            }
        }

        private string[] GetDelimiters(string numbers)
        {
            List<string> delimiters = new List<string> { ",", "\n" };

            if (numbers.StartsWith("//"))
            {
                //The inputted delimiter will be split from the list by a new line char
                string[] inputDelimiterBreaker = new string[] { "\n" };
                //break the string by the newline char and take the first split
                string[] test = numbers.Split(inputDelimiterBreaker, 0);
                string inputDelimiterBase = numbers.Split(inputDelimiterBreaker, 0)[0];
                delimiters.Add(Regex.Replace(inputDelimiterBase, @"\/\/", ""));
            }

            string[] finalDelimiterList = delimiters.ToArray<string>();
            return finalDelimiterList;
        }

        private string RemoveDelimiterSpecification(string numbers)
        {
            if (numbers.StartsWith("//"))
            {
                string correctedList = Regex.Replace(numbers, "//(.+?)\n", "");
                return correctedList;
            }
            else return numbers;
        }

        private int CountFromList(string list, string[] delimiters)
        {
            string[] numbersFromList = list.Split(delimiters, 0);

            int count = 0;
            foreach (string number in numbersFromList)
            {
            }

            return count;
        }
    }
}
