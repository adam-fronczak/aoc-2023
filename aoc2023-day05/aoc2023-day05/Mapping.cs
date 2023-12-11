namespace aoc2023_day05
{
    public class Mapping
    {
        public long SourceStart { get; set; }
        public long DestinationStart { get; set; }
        public long Length { get; set; }
        public long SourceEnd => SourceStart + Length - 1;

        public Mapping(long destinationStart, long sourceStart, long length)
        {
            SourceStart = sourceStart;
            DestinationStart = destinationStart;
            Length = length;
        }

        public static Mapping Parse(string line)
        {
            var parts = line.Split(' ');
            return new Mapping(long.Parse(parts[0]), long.Parse(parts[1]), long.Parse(parts[2]));
        }

        public long? Map(long sourceValue)
        {
            if (sourceValue >= SourceStart && sourceValue < SourceStart + Length)
            {
                return sourceValue - SourceStart + DestinationStart;
            }

            return null;
        }

        public MappingResult Map(SeedRange inputRange)
        {
            var result = new MappingResult();

            if (inputRange.End < SourceStart || inputRange.Start > SourceEnd)
            {
                result.NotMapped.Add(inputRange);
            }
            else if (inputRange.Start >= SourceStart && inputRange.End <= SourceEnd)
            {
                result.Mapped.Add(new SeedRange(DestinationStart + inputRange.Start - SourceStart, inputRange.Length));
            }

            else if (inputRange.Start < SourceStart && inputRange.End > SourceEnd)
            {
                result.NotMapped.Add(new SeedRange(inputRange.Start, SourceStart - inputRange.Start));
                result.Mapped.Add(new SeedRange(DestinationStart, Length));
                result.NotMapped.Add(new SeedRange(SourceEnd + 1, inputRange.End - SourceEnd));
            }
            else if (inputRange.Start < SourceStart && inputRange.End <= SourceEnd)
            {
                result.NotMapped.Add(new SeedRange(inputRange.Start, SourceStart - inputRange.Start));
                result.Mapped.Add(new SeedRange(DestinationStart, inputRange.Length - (SourceStart - inputRange.Start)));
            }
            else if (inputRange.Start >= SourceStart && inputRange.End > SourceEnd)
            {
                result.Mapped.Add(new SeedRange(DestinationStart + inputRange.Start - SourceStart, Length - (inputRange.Start - SourceStart)));
                result.NotMapped.Add(new SeedRange(SourceEnd + 1, inputRange.Length - (Length - (inputRange.Start - SourceStart))));
            }

            return result;
        }
    }
}
