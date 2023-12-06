namespace aoc2023_day03
{
    public class Puzzle2
    {
        public static int GetGearsSum(string fileName)
        {
            var map = Map.Parse(File.ReadAllLines(fileName));
            return map.GetGearsSum();
        }
    }
}
