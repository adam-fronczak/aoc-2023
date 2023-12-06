namespace aoc2023_day03
{
    public class Spot
    {
        public char Character { get; set; }
        public int? Number { get; set; }
        public int BlockSize { get; set; } = 1;
        public bool IsSymbol 
        { 
            get
            {
                return !IsDigit && Character != '.'; 
            } 
        }

        public bool IsDigit
        {
            get
            {
                return char.IsAsciiDigit(Character); 
            } 
        }

        public bool isSymbolAdjacent { get; set; }
        public IList<Spot> NumbersAdjacent { get; set; } = [];
    }
}
