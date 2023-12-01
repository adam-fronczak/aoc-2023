namespace aoc2023_day01
{
    public class Puzzle1
    {
        public static int GetCalibrationSum(string fileName)
        {
            return GetCalibrationSum(File.ReadAllLines(fileName));
        }

        public static int GetCalibrationSum(string[] lines)
        {
            int sum = 0;
            int firstDigit = 0;
            int lastDigit = 0;
            foreach (var line in lines)
            {
                for (int i=0; i<line.Length; i++)
                {
                    if (char.IsDigit(line[i]))
                    {
                        firstDigit = int.Parse(line[i].ToString());
                        break;
                    }
                }
                for (int i = line.Length-1; i >= 0; i--)
                {
                    if (char.IsDigit(line[i]))
                    {
                        lastDigit = int.Parse(line[i].ToString());
                        break;
                    }
                }

                sum += firstDigit * 10 + lastDigit;
            }

            return sum;
        }
    }
}
