using aoc2023_day03;

namespace TestProject
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var sum = Puzzle1.GetPartsSum("input1.txt");
            Assert.Equal(4361, sum);
        }

        [Fact]
        public void Result1()
        {
            var sum = Puzzle1.GetPartsSum("input2.txt");
            Assert.Equal(536576, sum);
        }

        [Fact]
        public void Test2()
        {
            var sum = Puzzle2.GetGearsSum("input1.txt");
            Assert.Equal(467835, sum);
        }

        [Fact]
        public void Result2()
        {
            var sum = Puzzle2.GetGearsSum("input2.txt");
            Assert.Equal(75741499, sum);
        }
    }
}