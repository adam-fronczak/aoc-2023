namespace aoc2023_day04
{
    public class Deck
    {
        public IList<Card> Cards { get; set; } = [];

        public static Deck Parse(string[] lines)
        {
            var deck = new Deck();
            deck.Cards = lines.Select(Card.Parse).ToList();

            return deck;
        }

        public int GetWinningSum()
        {
            return Cards.Sum(c => c.GetWinningSum());
        }

        public int GetRecurrentWinningSum()
        {
            var numberOfCards = new int[Cards.Count];
            for (int i = 0; i < numberOfCards.Length; i++)
            {
                numberOfCards[i] = 1;
            }

            for (int i = 0; i < Cards.Count; i++)
            {
                if (numberOfCards[i] == 0)
                    break;

                var card = Cards[i];
                var winningSum = card.GetWinningCardsCount();
                for (int j = 1; j <= winningSum; j++)
                {
                    numberOfCards[i + j] += numberOfCards[i];
                }
            }

            var sum = numberOfCards.Sum();
            return sum;
        }
    }
}
