namespace aoc2023_day01
{
    public class Puzzle2
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
                for (int i = 0; i < line.Length; i++)
                {
                    if (char.IsDigit(line[i]))
                    {
                        firstDigit = int.Parse(line[i].ToString());
                        break;
                    }
                    var digitFromText = GetDigitFromText(line, i);
                    if (digitFromText.HasValue)
                    {
                        firstDigit = digitFromText.Value;
                        break;
                    }
                }
                for (int i = line.Length - 1; i >= 0; i--)
                {
                    if (char.IsDigit(line[i]))
                    {
                        lastDigit = int.Parse(line[i].ToString());
                        break;
                    }
                    var digitFromText = GetDigitFromText(line, i);
                    if (digitFromText.HasValue)
                    {
                        lastDigit = digitFromText.Value;
                        break;
                    }
                }

                sum += firstDigit * 10 + lastDigit;
            }

            return sum;
        }

        private static int? GetDigitFromText(string text, int text2startIndex)
        {
            foreach (var digit in _digitDictionary)
            {
                if (AreSubstringsEqual(digit.Key, text, text2startIndex))
                {
                    return digit.Value;
                }
            }

            return null;
        }

        private static bool AreSubstringsEqual(string text1, string text2, int text2startIndex)
        {
            for (int i = 0; i < text1.Length; i++)
            {
                if (text2startIndex + i >= text2.Length || text1[i] != text2[text2startIndex + i])
                {
                    return false;
                }
            }

            return true;
        }

        private static Dictionary<string, int> _digitDictionary = new Dictionary<string, int>()
        {
            { "one", 1 },
            { "two", 2 },
            { "three", 3 },
            { "four", 4 },
            { "five", 5 },
            { "six", 6 },
            { "seven", 7 },
            { "eight", 8 },
            { "nine", 9 },
        };
    }
}
