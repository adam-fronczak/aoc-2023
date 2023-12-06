
namespace aoc2023_day03
{
    public class Map
    {
        private Spot[,] Spots { get; set; } = new Spot[0,0];

        /// <summary>
        /// Successfully generate by Copilot in 90%
        /// </summary>
        /// <param name="lines"></param>
        /// <returns></returns>
        public static Map Parse(string[] lines)
        {
            var map = new Map();
            map.Spots = new Spot[lines.Length, lines[0].Length];

            for (var y = 0; y < lines.Length; y++)
            {
                for (var x = 0; x < lines[y].Length; x++)
                {
                    var spot = new Spot();
                    spot.Character = lines[y][x];
                    spot.BlockSize = 1;
                    map.Spots[y, x] = spot;
                }
            }

            map.SetNumbers();
            map.SetAdjacency();
            map.SetNumberAdjacency();
            return map;
        }

        public int GetSum()
        {
            int sum = 0;
            for (var y = 0; y < this.Spots.GetLength(0); y++)
            {
                for (var x = 0; x < this.Spots.GetLength(1); x++)
                {
                    var spot = Spots[y, x];
                    if (spot.Number != null)
                    {
                        if (spot.isSymbolAdjacent)
                        {
                            sum += spot.Number.Value;
                        }
                    }
                }
            }

            return sum;
        }

        public int GetGearsSum()
        {
            int sum = 0;
            for (var y = 0; y < this.Spots.GetLength(0); y++)
            {
                for (var x = 0; x < this.Spots.GetLength(1); x++)
                {
                    var spot = Spots[y, x];
                    if (spot.NumbersAdjacent.Count == 2)
                    {
                        sum += spot.NumbersAdjacent[0].Number.Value * spot.NumbersAdjacent[1].Number.Value;
                    }
                }
            }

            return sum;
        }

        private void SetNumbers()
        {
            for (var y = 0; y < this.Spots.GetLength(0); y++)
            {
                Spot? currentSpot = null;
                for (var x = 0; x < this.Spots.GetLength(1); x++)
                {
                    var spot = Spots[y, x];
                    var number = char.IsAsciiDigit(spot.Character) ? (int?)int.Parse(spot.Character.ToString()) : null;
                    if (number != null)
                    {
                        if (currentSpot == null)
                        {
                            spot.Number = number;
                            currentSpot = spot;
                        }
                        else
                        {
                            currentSpot.Number = currentSpot.Number * 10 + number;
                            currentSpot.BlockSize++;
                        }
                    }
                    else
                    {
                        currentSpot = null;
                    }
                }
            }
        }

        private void SetAdjacency()
        {
            for (var y = 0; y < this.Spots.GetLength(0); y++)
            {
                for (var x = 0; x < this.Spots.GetLength(1); x++)
                {
                    var spot = Spots[y, x];
                    if (spot.Number != null)
                    {
                        if (SafeGetSpot(y, x - 1).IsSymbol)
                        {
                            spot.isSymbolAdjacent = true;
                        }

                        if (SafeGetSpot(y, x + spot.BlockSize).IsSymbol)
                        {
                            spot.isSymbolAdjacent = true;
                        }

                        for (int i = -1; i <= spot.BlockSize; i++)
                        {
                            if (SafeGetSpot(y - 1, x + i).IsSymbol)
                            {
                                spot.isSymbolAdjacent = true;
                            }
                            if (SafeGetSpot(y + 1, x + i).IsSymbol)
                            {
                                spot.isSymbolAdjacent = true;
                            }
                        }
                    }
                }
            }
        }

        private void SetNumberAdjacency()
        {
            for (var y = 0; y < this.Spots.GetLength(0); y++)
            {
                for (var x = 0; x < this.Spots.GetLength(1); x++)
                {
                    var spot = Spots[y, x];
                    if (spot.Character == '*')
                    {
                        AddUniqueIfNotNull(spot.NumbersAdjacent, GetNumberFromPosition(y, x - 1));
                        AddUniqueIfNotNull(spot.NumbersAdjacent, GetNumberFromPosition(y, x + 1));

                        for (int i = -1; i <= 1; i++)
                        {
                            AddUniqueIfNotNull(spot.NumbersAdjacent, GetNumberFromPosition(y - 1, x + i));
                            AddUniqueIfNotNull(spot.NumbersAdjacent, GetNumberFromPosition(y + 1, x + i));
                        }
                    }
                }
            }
        }

        private void AddUniqueIfNotNull(IList<Spot> list, Spot? value)
        {
            if (value != null)
            {
                if (!list.Contains(value))
                {
                    list.Add(value);
                }
            }
        }

        private Spot? GetNumberFromPosition(int y, int x)
        {
            if (y < 0 || y >= this.Spots.GetLength(0) || x < 0 || x >= this.Spots.GetLength(1))
            {
                return null;
            }

            var spot = Spots[y, x];
            if (spot.Number != null)
            {
                return spot;
            }

            if (spot.IsDigit)
            {
                return GetNumberFromPosition(y, x - 1);
            }

            return null;
        }

        private static Spot PlaceHolderSpot = new Spot() { Character = '.' };

        private Spot SafeGetSpot(int y, int x)
        {
            if (y < 0 || y >= this.Spots.GetLength(0) || x < 0 || x >= this.Spots.GetLength(1))
            {
                return PlaceHolderSpot;
            }

            return Spots[y, x];
        }
    }
}
