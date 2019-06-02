using System;

// $G$ THE-001 (-3) The explanation for the file being an assembly is lacking. The file is an assembly because it can be analysed by ILDASM.

namespace C18_Ex01_01
{

    // $G$ RUL-004 (-20) Wrong zip name format / folder name format.
    public class Program
    {
        public static void Main()
        {
            valueAndStatisticsOfBinarySeries();
        }

        private static void valueAndStatisticsOfBinarySeries()
        {
            string[] binarySeriesArray = receiveBinarySeries();
            int[] convertedNumbers = convertFromBinaryToDecimalArray(binarySeriesArray);
            printDecimalNumbers(convertedNumbers);
            calculateAndPrintStatistics(binarySeriesArray, convertedNumbers);
        }

        private static string[] receiveBinarySeries()
        {
            int sizeOfArray = 3;
            int receiveNumbersUntilNow = 0;
            int indexOfcurrentCell = 0;
            string[] receiveBinarySeries = new string[sizeOfArray];

            while (receiveNumbersUntilNow < sizeOfArray)
            {
                Console.WriteLine("Please enter a binary number with 9 digits: (and than press enter)");
                string currentSeriesToCheck = Console.ReadLine().Trim();
                if (currentSeriesToCheck.Length == 9 && isBinarySeries(currentSeriesToCheck))
                {
                    receiveBinarySeries[indexOfcurrentCell++] = currentSeriesToCheck;
                    receiveNumbersUntilNow++;
                }
                else
                {
                    Console.WriteLine("wrong input...");
                }
            }

            return receiveBinarySeries;
        }

        private static bool isBinarySeries(string i_CurrentSeriesToCheck)
        {
            bool isBinary = true;
            foreach (char currenCharToCheck in i_CurrentSeriesToCheck)
            {
                if (!(currenCharToCheck.Equals('0') || currenCharToCheck.Equals('1')))
                {
                    isBinary = false;
                    break;
                }
            }

            return isBinary;
        }

        private static int[] convertFromBinaryToDecimalArray(string[] i_BinarySeriesArray)
        {
            int[] convertedArray = new int[i_BinarySeriesArray.Length];
            int currentIndex = 0;

            foreach (string currentBinaryString in i_BinarySeriesArray)
            {
                convertedArray[currentIndex++] = binaryToDecimal(currentBinaryString);
            }

            return convertedArray;
        }

        private static int binaryToDecimal(string i_BinaryString)
        {
            int decimalNumber = 0;
            char[] charArray = i_BinaryString.ToCharArray();

            for (int i = 0; i < i_BinaryString.Length; i++)
            {
                if (charArray[i].Equals('1'))
                {
                    decimalNumber += (int)Math.Pow(2, i_BinaryString.Length - i - 1);
                }
            }

            return decimalNumber;
        }

        private static void printDecimalNumbers(int[] i_ConvertedNumbers)
        {
            Console.WriteLine("The decimal numbers are:");
            for (int i = 0; i < i_ConvertedNumbers.Length; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, i_ConvertedNumbers[i]);
            }
        }

        private static void calculateAndPrintStatistics(string[] binarySeriesArray, int[] convertedNumbers)
        {
            double averageOfZeros = averageNumberOfCustomCharInStringArray(binarySeriesArray, '0');
            double averageOfOnes = averageNumberOfCustomCharInStringArray(binarySeriesArray, '1');
            int numberOfPowerOfTwo = numberOfPowerOfTwoInBinaryArray(binarySeriesArray);
            int numberOfDecreasingSeries = numberOfDecreasingSeriesInDecimalArray(convertedNumbers);
            double average = averageInArray(convertedNumbers);
            printStatistics(averageOfZeros, averageOfOnes, numberOfPowerOfTwo, numberOfDecreasingSeries, average);
        }

        private static double averageNumberOfCustomCharInStringArray(string[] i_StringArray, char i_CustomChar)
        {
            double sumOfCustomChar = 0;

            foreach (string currentString in i_StringArray)
            {
                sumOfCustomChar += numberOfCustomChar(currentString, i_CustomChar);
            }

            return sumOfCustomChar / i_StringArray.Length;
        }

        private static double numberOfCustomChar(string i_String, char i_Char)
        {
            double counterChar = 0;

            foreach (char currentCharToCheck in i_String)
            {
                if (currentCharToCheck.Equals(i_Char))
                {
                    counterChar++;
                }
            }

            return counterChar;
        }

        private static int numberOfPowerOfTwoInBinaryArray(string[] i_BinarySeriesArray)
        {
            int counterForPowerOfTwo = 0;

            foreach (string currentStringToCheck in i_BinarySeriesArray)
            {
                if (isPowerOfTwo(currentStringToCheck))
                {
                    counterForPowerOfTwo++;
                }
            }

            return counterForPowerOfTwo;
        }

        private static bool isPowerOfTwo(string i_StringToCheck) ///number is power of two just if only one bit is '1'
        {
            int numberOfOne = 0;

            foreach (char currentChar in i_StringToCheck)
            {
                if (currentChar.Equals('1'))
                {
                    numberOfOne++;
                }
            }

            return numberOfOne == 1;
        }

        private static int numberOfDecreasingSeriesInDecimalArray(int[] i_ConvertedNumbers)
        {
            int numberDecreasingSeries = 0;

            for (int i = 0; i < i_ConvertedNumbers.Length; i++)
            {
                if (isDecreasingSeries(i_ConvertedNumbers[i]))
                {
                    numberDecreasingSeries++;
                }
            }

            return numberDecreasingSeries;
        }

        private static bool isDecreasingSeries(int i_NumberDecimal)
        {
            int currentDigitToCheck = 0;
            bool isDecreasing = true;

            while (i_NumberDecimal != 0)
            {
                currentDigitToCheck = i_NumberDecimal % 10;
                i_NumberDecimal /= 10;
                if ((i_NumberDecimal != 0) && (!(currentDigitToCheck < i_NumberDecimal % 10)))
                {
                    isDecreasing = false;
                    break;
                }
            }

            return isDecreasing;
        }

        private static double averageInArray(int[] i_ConvertedNumbers)
        {
            double sumAllNumberes = 0;

            for (int i = 0; i < i_ConvertedNumbers.Length; i++)
            {
                sumAllNumberes += i_ConvertedNumbers[i];
            }

            return sumAllNumberes / i_ConvertedNumbers.Length;
        }

        private static void printStatistics(double i_AverageOfZeros, double i_AverageOfOnes, int i_NumberOfPowerOfTwo, int i_NumberOfDecreasingSeries, double i_Average)
        {
            Console.WriteLine("Statistics:");
            Console.WriteLine(string.Format("The average number of zeros in the binary series is: {0:F3}", i_AverageOfZeros));
            Console.WriteLine(string.Format("The average number of ones in the binary series is: {0:F3}", i_AverageOfOnes));
            Console.WriteLine(string.Format("The number of series is power of two is: {0}", i_NumberOfPowerOfTwo));
            Console.WriteLine(string.Format("The number of decreasing series is: {0}", i_NumberOfDecreasingSeries));
            Console.WriteLine(string.Format("The average is: {0:F3}", i_Average));
        }
    }
}
