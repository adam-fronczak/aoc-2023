namespace aoc2023_day04
{
    public class Puzzle
    {
        public static int GetDeckSum(string fileName)
        {
            var deck = Deck.Parse(File.ReadAllLines(fileName));
            return deck.GetWinningSum();
        }

        public static int GetRecurrentWinningSum(string fileName)
        {
            var deck = Deck.Parse(File.ReadAllLines(fileName));
            return deck.GetRecurrentWinningSum();
        }
    }
}
