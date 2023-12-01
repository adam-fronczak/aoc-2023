using aoc2023_day01;

namespace TestProject
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var sum = Puzzle1.GetCalibrationSum(["1abc2",
                "pqr3stu8vwx",
                "a1b2c3d4e5f",
                "treb7uchet"]);

            Assert.Equal(142, sum);
        }

        [Fact]
        public void Result1()
        {
            var sum = Puzzle1.GetCalibrationSum("input1.txt");
            Assert.Equal(55816, sum);
        }

        [Fact]
        public void Test2()
        {
            var sum = Puzzle2.GetCalibrationSum(["two1nine",
                "eightwothree",
                "abcone2threexyz",
                "xtwone3four",
                "4nineeightseven2",
                "zoneight234",
                "7pqrstsixteen"]);

            Assert.Equal(281, sum);
        }

        [Fact]
        public void Result2()
        {
            var sum = Puzzle2.GetCalibrationSum("input1.txt");
            Assert.Equal(54980, sum);
        }
    }
}