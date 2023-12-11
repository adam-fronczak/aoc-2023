namespace aoc2023_day05
{
    public class Map
    {
        public IList<Mapping> Mappings { get; set; } = [];

        public long MapValue(long value)
        {
            foreach (var mapping in Mappings)
            {
                var newValue = mapping.Map(value);
                if (newValue.HasValue)
                {
                    return newValue.Value;
                }
            }

            return value;
        }

        public IList<SeedRange> MapRange(IList<SeedRange> ranges)
        {
            var mappedRanges = new List<SeedRange>();
            var inputRanges = ranges;
            var newInputRanges = new List<SeedRange>();

            foreach (var mapping in Mappings)
            {
                foreach (var inputRange in inputRanges)
                {
                    var mappingResult = mapping.Map(inputRange);
                    mappedRanges.AddRange(mappingResult.Mapped);
                    newInputRanges.AddRange(mappingResult.NotMapped);
                }

                inputRanges = newInputRanges.DistinctBy(x => new { x.Start, x.Length }).ToList();
                newInputRanges = new List<SeedRange>();
            }

            mappedRanges.AddRange(inputRanges);

            return mappedRanges;
        }
    }
}
