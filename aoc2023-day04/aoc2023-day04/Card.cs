namespace aoc2023_day04
{
    public class Card
    {
        public int Id { get; set; }
        public IList<int> WinningNumbers { get; set; } = [];
        public IList<int> YourNumbers { get; set; } = [];

        public static Card Parse(string lines)
        {
            var parts = lines.Split('|', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            var tokens1 = parts[0].Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            var tokens2 = parts[1].Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            var card = new Card();
            card.Id = int.Parse(tokens1[1].Replace(":", ""));
            card.WinningNumbers = tokens1.Skip(2).Select(int.Parse).ToList();
            card.YourNumbers = tokens2.Select(int.Parse).ToList();

            return card;
        }

        public int GetWinningSum()
        {
            WinningNumbers = YourNumbers.Intersect(WinningNumbers).ToList();
            if (WinningNumbers.Count > 0)
            {
                return (int) Math.Pow(2, WinningNumbers.Count - 1);
            }

            return 0;
        }

        public int GetWinningCardsCount()
        {
            WinningNumbers = YourNumbers.Intersect(WinningNumbers).ToList();
            return WinningNumbers.Count;
        }
    }
}
