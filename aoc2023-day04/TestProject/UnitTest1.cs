using aoc2023_day04;

namespace TestProject
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var sum = Puzzle.GetDeckSum("input1.txt");
            Assert.Equal(13, sum);
        }

        [Fact]
        public void Result1()
        {
            var sum = Puzzle.GetDeckSum("input2.txt");
            Assert.Equal(27059, sum);
        }

        [Fact]
        public void Test2()
        {
            var sum = Puzzle.GetRecurrentWinningSum("input1.txt");
            Assert.Equal(30, sum);
        }

        [Fact]
        public void Result2()
        {
            var sum = Puzzle.GetRecurrentWinningSum("input2.txt");
            Assert.Equal(5744979, sum);
        }
    }
}