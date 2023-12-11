using aoc2023_day05;

namespace TestProject
{
    public class PuzzleTest
    {
        [Fact]
        public void Test1()
        {
            var sum = Puzzle.GetMinimumSeedNumber("input1.txt");
            Assert.Equal(35, sum);
        }

        [Fact]
        public void Result1()
        {
            var sum = Puzzle.GetMinimumSeedNumber("input2.txt");
            Assert.Equal(457535844, sum);
        }

        [Fact]
        public void Test2()
        {
            var sum = Puzzle.GetMinimumRangeNumber("input1.txt");
            Assert.Equal(46, sum);
        }

        [Fact]
        public void Result2()
        {
            var sum = Puzzle.GetMinimumRangeNumber("input2.txt");
            Assert.Equal(41222968, sum);
        }
    }
}