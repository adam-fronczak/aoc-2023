namespace aoc2023_day05
{
    public class Puzzle
    {
        public static long GetMinimumSeedNumber(string fileName)
        {
            var crops = new Crops(File.ReadAllLines(fileName));
            return crops.GetMinimumSeedNumber();
        }

        public static long GetMinimumRangeNumber(string fileName)
        {
            var crops = new Crops(File.ReadAllLines(fileName));
            return crops.GetMinimumRangeNumber();
        }
    }
}
