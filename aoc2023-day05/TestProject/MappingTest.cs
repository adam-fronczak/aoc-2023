using aoc2023_day05;

namespace TestProject
{
    public class MappingTest
    {
        Mapping mapping = new Mapping(1100, 100, 200);

        [Fact]
        public void Test1()
        {
            var result = mapping.Map(new SeedRange(100, 200));
            Assert.Equal(1, result.Mapped.Count);
            Assert.Equal(0, result.NotMapped.Count);
            Assert.Equal(1100, result.Mapped[0].Start);
            Assert.Equal(200, result.Mapped[0].Length);
        }

        [Fact]
        public void Test2()
        {
            var result = mapping.Map(new SeedRange(50, 50));
            Assert.Equal(0, result.Mapped.Count);
            Assert.Equal(1, result.NotMapped.Count);
            Assert.Equal(50, result.NotMapped[0].Start);
            Assert.Equal(50, result.NotMapped[0].Length);
        }

        [Fact]
        public void Test3()
        {
            var result = mapping.Map(new SeedRange(2000, 50));
            Assert.Equal(0, result.Mapped.Count);
            Assert.Equal(1, result.NotMapped.Count);
            Assert.Equal(2000, result.NotMapped[0].Start);
            Assert.Equal(50, result.NotMapped[0].Length);
        }

        [Fact]
        public void Test4()
        {
            var result = mapping.Map(new SeedRange(80, 50));
            Assert.Equal(1, result.Mapped.Count);
            Assert.Equal(1, result.NotMapped.Count);
            Assert.Equal(80, result.NotMapped[0].Start);
            Assert.Equal(20, result.NotMapped[0].Length);
            Assert.Equal(1100, result.Mapped[0].Start);
            Assert.Equal(30, result.Mapped[0].Length);
        }

        [Fact]
        public void Test5()
        {
            var result = mapping.Map(new SeedRange(280, 50));
            Assert.Equal(1, result.Mapped.Count);
            Assert.Equal(1, result.NotMapped.Count);
            Assert.Equal(300, result.NotMapped[0].Start);
            Assert.Equal(30, result.NotMapped[0].Length);
            Assert.Equal(1280, result.Mapped[0].Start);
            Assert.Equal(20, result.Mapped[0].Length);
        }

        [Fact]
        public void Test6()
        {
            var result = mapping.Map(new SeedRange(80, 300));
            Assert.Equal(1, result.Mapped.Count);
            Assert.Equal(2, result.NotMapped.Count);
            Assert.Equal(80, result.NotMapped[0].Start);
            Assert.Equal(20, result.NotMapped[0].Length);
            Assert.Equal(300, result.NotMapped[1].Start);
            Assert.Equal(80, result.NotMapped[1].Length);
            Assert.Equal(1100, result.Mapped[0].Start);
            Assert.Equal(200, result.Mapped[0].Length);
        }
    }
}
