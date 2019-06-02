using System;

namespace C18_Ex01_05
{
    public class Program
    {
        public static void Main()
        {
            analysisNumber();
        }

        private static void analysisNumber()
        {
            string numberToAnalysis = receiveNumberToAnalysis();
            int biggestDigit = biggestDigitInNumber(numberToAnalysis);
            int smallestDigit = smallestDigitInNumber(numberToAnalysis);
            int countEvenDigits = evenDigitsInNumber(numberToAnalysis);
            int numberOfSmallerDigitsThenUnityDigit = smallerDigitsThenUnityDigit(numberToAnalysis);
            printStatistics(biggestDigit, smallestDigit, countEvenDigits, numberOfSmallerDigitsThenUnityDigit);
        }

        private static string receiveNumberToAnalysis()
        {
            string numberToAnalysis = string.Empty;
            bool isValidInput = false;
            int fixLengthOfNumber = 7;

            while (!isValidInput)
            {
                Console.WriteLine(string.Format("Please enter a number (must be {0} digits)", fixLengthOfNumber));
                numberToAnalysis = Console.ReadLine();
                isValidInput = checkNumberWithFixedLength(numberToAnalysis, fixLengthOfNumber);
                if (!isValidInput)
                {
                    Console.WriteLine("Wrong input try again...");
                }
            }

            return numberToAnalysis;
        }

        private static bool checkNumberWithFixedLength(string i_NumberStr, int i_LengthToCheck)
        {
            bool isValidInput = true;

            if (i_NumberStr.Length != i_LengthToCheck)
            {
                isValidInput = false;
            }
            else
            {
                foreach (char currentCharToCheck in i_NumberStr)
                {
                    if (!char.IsDigit(currentCharToCheck))
                    {
                        isValidInput = false;
                        break;
                    }
                }
            }

            return isValidInput;
        }

        private static int biggestDigitInNumber(string i_Number)
        {
            char maxDigit = '0';

            foreach (char currentCharToCheck in i_Number)
            {
                if (currentCharToCheck > maxDigit)
                {
                    maxDigit = currentCharToCheck;
                }
            }

            return int.Parse(maxDigit.ToString());
        }

        private static int smallestDigitInNumber(string i_Number)
        {
            char minDigit = '9';

            foreach (char currentCharToCheck in i_Number)
            {
                if (currentCharToCheck < minDigit)
                {
                    minDigit = currentCharToCheck;
                }
            }

            return int.Parse(minDigit.ToString());
        }

        private static int evenDigitsInNumber(string i_Number)
        {
            int countEven = 0;

            foreach (char charCurrent in i_Number)
            {
                int currentDigit;
                if (int.TryParse(charCurrent.ToString(), out currentDigit))
                {
                    if (currentDigit % 2 == 0)
                    {
                        countEven++;
                    }
                }
            }

            return countEven;
        }

        private static int smallerDigitsThenUnityDigit(string i_Number)
        {
            char unityDigit = i_Number[i_Number.Length - 1];
            int countSmallerDigits = 0;

            foreach (char currentCharToCheck in i_Number)
            {
                if (currentCharToCheck < unityDigit)
                {
                    countSmallerDigits++;
                }
            }

            return countSmallerDigits;
        }

        private static void printStatistics(int i_BiggestDigit, int i_SmallestDigit, int i_EvenDigits, int i_SmallerDigitsThenUnityDigit)
        {
            Console.WriteLine("Statistics:");
            Console.WriteLine(string.Format("The biggest digit is: {0}", i_BiggestDigit));
            Console.WriteLine(string.Format("The smallest digit is: {0}", i_SmallestDigit));
            Console.WriteLine(string.Format("The number of even digits is: {0}", i_EvenDigits));
            Console.WriteLine(string.Format("The number of digits that smaller then the unity digit is: {0}", i_SmallerDigitsThenUnityDigit));
        }
    }
}