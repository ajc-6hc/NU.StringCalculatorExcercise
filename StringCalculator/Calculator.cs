using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class Calculator
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers)) return 0;

            string[] delimiters = new string[] {",","\n"};
            string[] numbersFromList = numbers.Split(delimiters, 0);
            int count = 0;

            foreach(string number in numbersFromList)
            {
                count = count + GetIntegerFromString(number);
            }
            return count;
        }

        private int GetIntegerFromString(string number)
        {
            int numberToReturn;
            if(Int32.TryParse(number, out numberToReturn))
            {
                return numberToReturn;
            }
            else
            {
                throw new Exception("Value was not a number");
            }
        }
    }
}
