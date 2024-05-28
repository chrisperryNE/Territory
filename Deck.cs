using System;
namespace TerritoryClasses
{
    public class Deck
    {
        private static Deck instance;
        public static Deck Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Deck();
                }
                return instance;
            }
        }

        private List<Tuple<string, int>> cards = new List<Tuple<string, int>>();
        public List<Tuple<string, int>> shuffledcards = new List<Tuple<string, int>>();

        public Deck()
        {
            cards.Clear();
            cards.Add(new Tuple<string, int>("A♠", 1));
            cards.Add(new Tuple<string, int>("2♠", 2));
            cards.Add(new Tuple<string, int>("3♠", 3));
            cards.Add(new Tuple<string, int>("4♠", 4));
            cards.Add(new Tuple<string, int>("5♠", 5));
            cards.Add(new Tuple<string, int>("6♠", 6));
            cards.Add(new Tuple<string, int>("7♠", 7));
            cards.Add(new Tuple<string, int>("8♠", 8));
            cards.Add(new Tuple<string, int>("9♠", 9));
            cards.Add(new Tuple<string, int>("10♠", 10));
            cards.Add(new Tuple<string, int>("J♠", 10));
            cards.Add(new Tuple<string, int>("Q♠", 10));
            cards.Add(new Tuple<string, int>("K♠", 10));
            cards.Add(new Tuple<string, int>("A♣", 1));
            cards.Add(new Tuple<string, int>("2♣", 2));
            cards.Add(new Tuple<string, int>("3♣", 3));
            cards.Add(new Tuple<string, int>("4♣", 4));
            cards.Add(new Tuple<string, int>("5♣", 5));
            cards.Add(new Tuple<string, int>("6♣", 6));
            cards.Add(new Tuple<string, int>("7♣", 7));
            cards.Add(new Tuple<string, int>("8♣", 8));
            cards.Add(new Tuple<string, int>("9♣", 9));
            cards.Add(new Tuple<string, int>("10♣", 10));
            cards.Add(new Tuple<string, int>("J♣", 10));
            cards.Add(new Tuple<string, int>("Q♣", 10));
            cards.Add(new Tuple<string, int>("K♣", 10));
            cards.Add(new Tuple<string, int>("A♥", 1));
            cards.Add(new Tuple<string, int>("2♥", 2));
            cards.Add(new Tuple<string, int>("3♥", 3));
            cards.Add(new Tuple<string, int>("4♥", 4));
            cards.Add(new Tuple<string, int>("5♥", 5));
            cards.Add(new Tuple<string, int>("6♥", 6));
            cards.Add(new Tuple<string, int>("7♥", 7));
            cards.Add(new Tuple<string, int>("8♥", 8));
            cards.Add(new Tuple<string, int>("9♥", 9));
            cards.Add(new Tuple<string, int>("10♥", 10));
            cards.Add(new Tuple<string, int>("J♥", 10));
            cards.Add(new Tuple<string, int>("Q♥", 10));
            cards.Add(new Tuple<string, int>("K♥", 10));
            cards.Add(new Tuple<string, int>("A♦", 1));
            cards.Add(new Tuple<string, int>("2♦", 2));
            cards.Add(new Tuple<string, int>("3♦", 3));
            cards.Add(new Tuple<string, int>("4♦", 4));
            cards.Add(new Tuple<string, int>("5♦", 5));
            cards.Add(new Tuple<string, int>("6♦", 6));
            cards.Add(new Tuple<string, int>("7♦", 7));
            cards.Add(new Tuple<string, int>("8♦", 8));
            cards.Add(new Tuple<string, int>("9♦", 9));
            cards.Add(new Tuple<string, int>("10♦", 10));
            cards.Add(new Tuple<string, int>("J♦", 10));
            cards.Add(new Tuple<string, int>("Q♦", 10));
            cards.Add(new Tuple<string, int>("K♦", 10));

        
            Random r = new Random();
            int rand;
            for (int i = 0; i < 52; i++)
            {
                rand = r.Next(0, cards.Count);
                shuffledcards.Add(cards[rand]);
            }
        }


        public static void ResetInstance()
        {
            instance = null;
        }

    }
}

