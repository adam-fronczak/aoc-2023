namespace aoc2023_day05
{
    public class SeedRange
    {
        public long Start { get; set; }
        public long Length { get; set; }
        public long End => Start + Length - 1;

        public SeedRange(long start, long length)
        {
            this.Start = start;
            this.Length = length;
        }
    }
}
