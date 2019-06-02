using System;
using System.Text;

namespace C18_Ex01_02
{
    public class Program
    {
        public static void Main()
        {
            printHourglass();
        }

        private static void printHourglass()
        {
            string hourglass = buildHourglass();
            Console.WriteLine(hourglass);
        }

        private static string buildHourglass()
        {
            StringBuilder hourglass = new StringBuilder();
            int clockHeight = 5;

            for (int currentRow = 0; currentRow < clockHeight; currentRow++)
            {
                hourglass.Append(BuildSingleRow(currentRow, clockHeight));
            }

            return hourglass.ToString();
        }

        public static string BuildSingleRow(int currentRow, int clockHeight)
        {
            int numberOfAsterisks = calculateNumberOfAsterisks(currentRow, clockHeight);
            int numberOfSpaces = (clockHeight - numberOfAsterisks) / 2;
            StringBuilder row = new StringBuilder();

            for (int i = 0; i < numberOfSpaces; i++)
            {
                row.Append(" ");
            }

            for (int i = 0; i < numberOfAsterisks; i++)
            {
                row.Append("*");
            }

            return row.Append(System.Environment.NewLine).ToString();
        }

        private static int calculateNumberOfAsterisks(int i_Indexrow, int i_ClockHeight)
        {
            int middleRow = i_ClockHeight / 2;
            int distanceFromMiddle = Math.Abs(i_Indexrow - middleRow);

            return (distanceFromMiddle * 2) + 1;
        }
    }
}
