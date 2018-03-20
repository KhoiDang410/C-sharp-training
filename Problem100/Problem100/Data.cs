using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem100
{
    class Data :CalculateData
    {
        public Data(string input)
        {
            MaxValue = 0;
            index = input.IndexOf(" ");
            numberi = input.Substring(0, index);
            numberj = input.Substring(index + 1);
            firstNumber = Int32.Parse(numberi);
            secondNumber = Int32.Parse(numberj);
            Calculate(firstNumber, secondNumber);
        }
        public int MaxValue { get; private set; }
        private string input { get; set; }
        private int index { get; set; }
        private string numberi { get;  set; }
        private string numberj { get;  set; }
        public int firstNumber { get; private set; }
        public int secondNumber { get; private set; }
        List<int> total = new List<int>();
        //Calculate the cycle of each number from i to j including i and j
        private void Calculate(int i, int j)
        {
            for (var n = i; n <= j; n++)
            {
                total.Add(cycleCount(n));
            }

            // Pick the number has maximum cycle
            foreach (int number in total)
            {
                MaxValue = Math.Max(MaxValue, number);
            }
        }

        // Count the cycle of any number
        private int cycleCount(int number)
        {
            int cycle = 0;
            while (number != 1)
            {
                if (IsOdd(number))
                {

                    number = 3 * number + 1;
                }
                else
                {

                    number = number / 2;
                }
                cycle++;
            }
            cycle++;
            return cycle;
        }
        private bool IsOdd(int number)
        {
            return number % 2 == 1 ? true : false;
        }
        public void WriteResult(int firstNumber, int secondNumber, int maxValue)
        {
            Console.WriteLine($"{firstNumber} {secondNumber} {maxValue}");
        }
    }


}
