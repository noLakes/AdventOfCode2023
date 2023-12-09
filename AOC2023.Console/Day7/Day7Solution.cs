using AOC2023.Console.Helpers;

namespace AOC2023.Console.Day7;

public class Day7Solution : ISolution
{
    public int Day => 7;

    public static readonly List<char> cardOrder = new List<char>()
    {
        '2', '3', '4', '5', '6', '7', '8', '9', 'T', 'J', 'Q', 'K', 'A'
    };

    public enum HandType
    {
        HighCard, OnePair, TwoPair, ThreeOfAKind, FullHouse, FourOfAKind, FiveOfAKind
    };

    public string Solve(string[] input)
    {
        input = new string[]
        {
            "32T3K 765",
            "T55J5 684",
            "KK677 28",
            "KTJJT 220",
            "QQQJA 483"
        };
        
        return SolvePart1(input);
    }

    private string SolvePart1(string[] input)
    {
        Dictionary<HandType, List<Hand>> hands = new Dictionary<HandType, List<Hand>>();

        foreach (var line in input)
        {
            var hand = new Hand(line.Split(" ")[0], int.Parse(line.Split(" ")[1]));
            if (!hands.ContainsKey(hand.type)) hands[hand.type] = new List<Hand>();
            hands[hand.type].Add(hand);
            
            System.Console.WriteLine($"Hand: {hand.cards} / Type: {hand.type} / Bet: {hand.bet}");
        }
        
        // all you need to do to test now is:
        // sort lists
        // join lists in desc order from fiveOfKind => highCard
        // calculate bets
        
        return $"s";
    }
    
    private struct Hand : IComparable<Hand>
    {
        public string cards;
        public HandType type;
        public int bet;
        public int[] highCardValues = new int[5];

        public Hand(string cards, int bet)
        {
            this.cards = cards;
            this.bet = bet;
            DetermineType();
            DetermineHighCardValue();
        }

        private void DetermineType()
        {
            var cardCount = CountCards();
            type = cardCount switch
            {
                (1, 5) => HandType.FiveOfAKind,
                (2, 4) => HandType.FourOfAKind,
                (2, 3) => HandType.FullHouse,
                (3, 3) => HandType.ThreeOfAKind,
                (3, 2) => HandType.TwoPair,
                (4, 2) => HandType.OnePair,
                _ => HandType.HighCard
            };
        }
        
        private (int, int) CountCards()
        {
            var data = new Dictionary<char, int>();

            foreach (var card in cards)
            {
                if (!data.ContainsKey(card)) data[card] = 1;
                else data[card]++;
            }

            return (data.Keys.Count, data.Values.Max());
        }

        private void DetermineHighCardValue()
        {
            for (var i = 0; i < cards.Length; i++)
            {
                highCardValues[i] = cardOrder.IndexOf(cards[i]);
            }
        }

        public int CompareTo(Hand other)
        {
            for (var i = 0; i < cards.Length -1; i++)
            {
                var cardOrderComparison = highCardValues[i].CompareTo(other.highCardValues[i]);
                if (cardOrderComparison != 0) return cardOrderComparison;
            }

            return highCardValues[^1].CompareTo(other.highCardValues[^1]);
        }
    }
    
}