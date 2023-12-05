namespace aoc2023_day02
{
    public class Puzzle2
    {
        public static int GetSumOfIdsGamesPossible(string fileName)
        {
            return GetSumOfIdsGamesPossible(File.ReadAllLines(fileName));
        }

        public static int GetSumOfIdsGamesPossible(string[] strings)
        {
            var games = strings.Select(x => Game.Parse(x)).ToList();

            var powers = new Dictionary<int, int>();

            foreach (var game in games)
            {
                var maxRed = game.Sets.Max(x => x.Red);
                var maxGreen = game.Sets.Max(x => x.Green);
                var maxBlue = game.Sets.Max(x => x.Blue);

                powers.Add(game.Id, maxRed * maxGreen * maxBlue);
            }

            var sum = powers.Select(x => x.Value).Sum();
            return sum;
        }
    }
}
