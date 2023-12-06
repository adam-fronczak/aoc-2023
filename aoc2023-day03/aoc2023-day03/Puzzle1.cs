namespace aoc2023_day03
{
    public class Puzzle1
    {
        public static int GetPartsSum(string fileName)
        {
            var map = Map.Parse(File.ReadAllLines(fileName));
            return map.GetSum();
        }
    }
}
