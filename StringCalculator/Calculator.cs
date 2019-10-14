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
        
        private string[] GetDelimiters(string numbers)
        {
            List<string> delimiters = new List<string> { ",", "\n" };

            if (numbers.StartsWith("//"))
            {
                //The inputted delimiter(s) will be broken from the list by a new line char
                string[] inputDelimiterBreaker = new string[] { "\n" };

                //The inputted delimiter(s) will be split by a closing square bracket char
                string[] inputDelimiterSplitter = new string[] { "]" };
                //break the string by the newline char and take the first split
                string inputDelimiterBase = numbers.Split(inputDelimiterBreaker, 0)[0];
                string delimiterWithoutSlashes = Regex.Replace(inputDelimiterBase, @"\/\/", "");
                string[] additionalDelimiters = delimiterWithoutSlashes.Split(inputDelimiterSplitter, 0);
                foreach(string delimiter in additionalDelimiters)
                {
                    string delimiterWithoutBracket = Regex.Replace(delimiter, @"\[", "");
                    if(delimiterWithoutBracket != "") delimiters.Add(delimiterWithoutBracket);
                }
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
            List<int> negatives = new List<int>();
            foreach (string number in numbersFromList)
            {
                int latestNumber = GetIntegerFromString(number);
                if(latestNumber < 0)
                {
                    negatives.Add(latestNumber);
                }
                count = count + latestNumber;
            }

            if(negatives.Any())
            {
                throw new Exception($"Negatives not allowed: {String.Join(",", negatives)}");
            }

            return count;
        }

        private int GetIntegerFromString(string number)
        {
            int numberToReturn;
            if (Int32.TryParse(number, out numberToReturn))
            {
                if(numberToReturn > 1000)
                {
                    numberToReturn = 0;
                }
                return numberToReturn;
            }
            else
            {
                throw new Exception("Value was not a number");
            }
        }
    }
}
