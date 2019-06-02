using System;
using System.Text;

namespace C18_Ex01_03
{
    public class Program
    {
        public static void Main()
        {
            printDinamicHourglass();
        }

        private static void printDinamicHourglass()
        {
            int clockHeight = reciveHourglassHeight();
            string hourglass = buildHourglass(clockHeight);
            Console.WriteLine(hourglass);
        }

        private static int reciveHourglassHeight()
        {
            int hourglassHeight = 0;
            bool goodInput = false;

            while (!goodInput)
            {
                Console.WriteLine("Please enter the height of the hourglass (must be a number)");
                string input = Console.ReadLine();
                goodInput = tryConvertValidInput(input, out hourglassHeight);
            }

            return hourglassHeight;
        }

        private static bool tryConvertValidInput(string i_Input, out int o_HourglassHeight)
        {
            bool goodInput = int.TryParse(i_Input, out o_HourglassHeight);

            if (goodInput && o_HourglassHeight > 0)
            {
                if (o_HourglassHeight % 2 == 0)
                {
                    o_HourglassHeight++;
                }
            }

            return goodInput;
        }

        private static string buildHourglass(int i_ClockHeight)
        {
            StringBuilder hourglass = new StringBuilder();

            for (int currentRow = 0; currentRow < i_ClockHeight; currentRow++)
            {
                hourglass.Append(C18_Ex01_02.Program.BuildSingleRow(currentRow, i_ClockHeight));
            }

            return hourglass.ToString();
        }
    }
}
