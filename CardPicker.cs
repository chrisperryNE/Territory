using System;
namespace Territory
{
    public class CardPicker
    {
        static Random random = new Random();

        public static string[] Cards(int numberOfCards)
        {
            numberOfCards = 52;
            string[] pickedCards = new string[numberOfCards];
            for (int i = 0; i < numberOfCards; i++)
            {
                pickedCards[i] = RandomValue() + " of " + RandomSuit();
            }
            return pickedCards;


        }


        public static string RandomValue()
        {

            int value = random.Next(1, 14);
            if (value == 1) return "Ace";
            if (value == 11) return "Jack";
            if (value == 12) return "Queen";
            if (value == 13) return "King";
            return value.ToString();

        }

        private static string RandomSuit()
        {
            // get a random number from 1 to 4
            int value = random.Next(1, 5);
            // if it's 1 return the string Spades
            if (value == 1) return "Spades";
            // if it's 1 return the string Hearts
            if (value == 2) return "Hearts";
            // if it's 1 return the string Clubs
            if (value == 3) return "Clubs";
            // if we haven't returned yet, return the string Diamonds
            return "Diamonds";
        }







        //    static string[] cards;

        //    static CardPicker()
        //    {
        //        BuildDeck();
        //    }

        //    public static void BuildDeck()
        //    {

        //        cards = new string[52];

        //        Console.WriteLine("*********** Shuffling deck...");
        //        string[] suits = { "spades", "hearts", "clubs", "diamonds" };
        //        int cardCounter = 0;

        //        for (int cardVal = 1; cardVal <= 13; cardVal++)
        //        {
        //            foreach (string cardSuit in suits)
        //            {
        //                string cardName;
        //                switch (cardVal)
        //                {
        //                    case 1:
        //                        cardName = "A";
        //                        break;
        //                    case 11:
        //                        cardName = "J";
        //                        break;
        //                    case 12:
        //                        cardName = "Q";
        //                        break;
        //                    case 13:
        //                        cardName = "K";
        //                        break;
        //                    default:
        //                        cardName = cardVal.ToString().PadLeft(2, '0');
        //                        break;
        //                }

        //                // cards[cardCounter] = cardName + " of " + cardSuit;
        //                cards[cardCounter] = "card_" + cardSuit + "_" + cardName + ".png";
        //                cardCounter++;
        //            }
        //        }
        //    }

        //    public static string[] PickSomeCards(int numberOfCards)
        //    {
        //        if (numberOfCards <= cards.Length)
        //        {
        //            string[] pickedCards = new string[numberOfCards];
        //            for (int i = 0; i < numberOfCards; i++)
        //            {
        //                pickedCards[i] = RandomCard();
        //            }
        //            return pickedCards;
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }

        //    private static string RandomCard()
        //    {
        //        int cardNum = random.Next(0, cards.Length);
        //        string picked = cards[cardNum];
        //        cards = cards.Where(e => e != picked).ToArray();
        //        return picked;
        //    }

        //    // remove a specific card from the deck as if it had been dealt
        //    public static void RemoveCard(string picked)
        //    {
        //        cards = cards.Where(e => e != picked).ToArray();
        //    }

        //    // accessor for the class's card data that we need elswhere
        //    public static int CountCards()
        //    {
        //        return cards.Length;
        //    }
        //}
    }
}
