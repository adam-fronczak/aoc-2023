using aoc2023_day02;

namespace TestProject
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var sum = Puzzle1.GetSumOfIdsGamesPossible(["Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
                "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
                "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
                "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
                "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green"]);

            Assert.Equal(8, sum);
        }

        [Fact]
        public void Result1()
        {
            var sum = Puzzle1.GetSumOfIdsGamesPossible("input1.txt");
            Assert.Equal(2204, sum);
        }

        [Fact]
        public void Test2()
        {
            var sum = Puzzle2.GetSumOfIdsGamesPossible(["Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
                "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
                "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
                "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
                "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green"]);

            Assert.Equal(2286, sum);
        }

        [Fact]
        public void Result2()
        {
            var sum = Puzzle2.GetSumOfIdsGamesPossible("input1.txt");
            Assert.Equal(71036, sum);
        }
    }
}