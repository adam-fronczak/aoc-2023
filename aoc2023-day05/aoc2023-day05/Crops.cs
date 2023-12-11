using System.Diagnostics;

namespace aoc2023_day05
{
    public class Crops
    {
        private IList<long> seeds = [];
        private IList<SeedRange> seedRanges = [];
        private IList<Map> maps = new List<Map>();

        public Crops(string[] lines)
        {
            seeds = lines[0].Trim().Split(' ').Skip(1).Select(long.Parse).ToList();
            for (int i = 0; i < seeds.Count; i += 2)
            {
                var seedsRange = new SeedRange(seeds[i], seeds[i + 1]);
                seedRanges.Add(seedsRange);
            }

            Map currentMappingCollection = null;
            foreach (var line in lines.Skip(2))
            {
                if (line.Length <= 2)
                {
                    continue;
                }

                if (line.Contains(":"))
                {
                    currentMappingCollection = new Map();
                    maps.Add(currentMappingCollection);
                    continue;
                }

                currentMappingCollection.Mappings.Add(Mapping.Parse(line));
            }
        }

        public IList<long> MapSeeds()
        {
            var mappedSeeds = seeds.ToList();

            foreach (var map in maps)
            {
                mappedSeeds = mappedSeeds.Select(map.MapValue).ToList();
            }

            return mappedSeeds;
        }

        public IList<SeedRange> MapRanges()
        {
            IList<SeedRange> mappedRanges = seedRanges.ToList();
            int mapNumber = 0;

            foreach (var map in maps)
            {
                Trace.WriteLine("Map " + mapNumber);
                mappedRanges = map.MapRange(mappedRanges);
                mapNumber++;
            }

            return mappedRanges;
        }

        public long GetMinimumSeedNumber()
        {
            return MapSeeds().Min();
        }

        public long GetMinimumRangeNumber()
        {
            var finalRanges = MapRanges();
            return finalRanges.Min(x => x.Start);
        }
    }
}
