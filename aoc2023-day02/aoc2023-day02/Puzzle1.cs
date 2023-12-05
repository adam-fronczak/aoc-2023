namespace aoc2023_day02
{
    public class Puzzle1
    {
        public static int GetSumOfIdsGamesPossible(string fileName)
        {
            return GetSumOfIdsGamesPossible(File.ReadAllLines(fileName));
        }

        public static int GetSumOfIdsGamesPossible(string[] strings)
        {
            var games = strings.Select(x => Game.Parse(x)).ToList();

            var invalids = new List<int>();


            foreach (var game in games)
            {
                foreach (var set in game.Sets)
                {
                    if (set.Red > MaxRed)
                    {
                        invalids.Add(game.Id);
                        continue;
                    }
                    if (set.Green > MaxGreen)
                    {
                        invalids.Add(game.Id);
                        continue;
                    }
                    if (set.Blue > MaxBlue)
                    {
                        invalids.Add(game.Id);
                        continue;
                    }
                }
            }

            var sum = games.Select(x => x.Id).Except(invalids).Sum();
            return sum;
        }

        private const int MaxRed = 12;
        private const int MaxGreen = 13;
        private const int MaxBlue = 14;
    }
}
