using System;

namespace C18_Ex01_04
{
    public class Program
    {
        public static void Main()
        {
            stringAnalysis();
        }

        private static void stringAnalysis()
        {
            bool isEven = true;
            bool isSeriesOfLetters = true;
            ulong numberToAnalysis = 0;
            int numberOfLowerCase = 0;

            string stringToAnalysis = receiveStringToAnalysis();
            bool isPalindrome = checkPalindrome(stringToAnalysis);
            bool isNumber = checkIsNumber(stringToAnalysis);
            if (isNumber)
            {
                numberToAnalysis = ulong.Parse(stringToAnalysis);
                isEven = checkIsEven(numberToAnalysis);
            }
            else
            {
                isSeriesOfLetters = checkIsSeriesOfLetters(stringToAnalysis);
                if (isSeriesOfLetters)
                {
                    numberOfLowerCase = countLowerCase(stringToAnalysis);
                }
            }

            printAnalysis(isPalindrome, isNumber, isEven, isSeriesOfLetters, numberOfLowerCase);
        }

        private static string receiveStringToAnalysis()
        {
            string stringToAnalyasis = string.Empty;
            bool isValidString = false;

            while (!isValidString)
            {
                Console.WriteLine("Please enter a string (must be only 10 digits or letters)");
                stringToAnalyasis = Console.ReadLine();
                if ((stringToAnalyasis.Length == 10) && (checkIsNumber(stringToAnalyasis) || checkIsSeriesOfLetters(stringToAnalyasis)))
                {
                    isValidString = true;
                }
                else
                {
                    Console.WriteLine("Wrong input, try again...");
                }
            }

            return stringToAnalyasis;
        }

        private static bool checkPalindrome(string i_StringToAnalysis)
        {
            bool isPalindrome = true;
            int start = 0, end = i_StringToAnalysis.Length - 1;

            while (start < end)
            {
                if (i_StringToAnalysis[start] != i_StringToAnalysis[end])
                {
                    isPalindrome = false;
                    break;
                }

                start++;
                end--;
            }

            return isPalindrome;
        }

        private static bool checkIsNumber(string i_StringToAnalyasis)
        {
            bool isNumber = true;

            foreach (char currentCharToCheck in i_StringToAnalyasis)
            {
                if (!char.IsDigit(currentCharToCheck))
                {
                    isNumber = false;
                    break;
                }
            }

            return isNumber;
        }

        private static bool checkIsEven(ulong i_NumberToAnalysis)
        {
            return (i_NumberToAnalysis % 2) == 0;
        }

        private static bool checkIsSeriesOfLetters(string i_StringToAnalyasis)
        {
            bool isWord = true;

            foreach (char currentCharToCheck in i_StringToAnalyasis)
            {
                if (!char.IsLetter(currentCharToCheck))
                {
                    isWord = false;
                    break;
                }
            }

            return isWord;
        }

        private static int countLowerCase(string i_StringToAnalysis)
        {
            int countLowerLetter = 0;

            foreach (char currenCharToCheck in i_StringToAnalysis)
            {
                if (char.IsLower(currenCharToCheck))
                {
                    countLowerLetter++;
                }
            }

            return countLowerLetter;
        }

        private static void printAnalysis(bool i_IsPalindrome, bool i_IsNumber, bool i_IsEven, bool i_IsWord, int i_NumberOfLowerCase)
        {
            Console.WriteLine("The Analysis:");
            if (i_IsPalindrome)
            {
                Console.WriteLine("The String is Palindrome");
            }
            else
            {
                Console.WriteLine("The String is not Palindrome");
            }

            if (i_IsNumber)
            {
                if (i_IsEven)
                {
                    Console.WriteLine("The String is an even number");
                }
                else
                {
                    Console.WriteLine("The String is an odd number");
                }
            }
            else if (i_IsWord)
            {
                Console.WriteLine("The String is a word");
                {
                    Console.WriteLine(string.Format("The number of lower case letters is: {0}", i_NumberOfLowerCase));
                }
            }
        }
    }
}
