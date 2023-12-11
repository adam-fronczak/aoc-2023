namespace aoc2023_day05
{
    public class MappingResult
    {
        public IList<SeedRange> NotMapped { get; set; } = new List<SeedRange>();
        public IList<SeedRange> Mapped { get; set; } = new List<SeedRange>();
    }
}
