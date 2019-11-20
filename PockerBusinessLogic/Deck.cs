using System;
using System.Collections.Generic;
using System.Linq;

namespace PockerBusinessLogic
{
    public class Deck
    {
        private static Random random = new Random();
        public static List<Cards> cardDeck = new List<Cards>();

        public Deck()
        {
            var cardSuits = Enum.GetValues(typeof(PockerEnum.Suit)).Cast<PockerEnum.Suit>();
            var cardRanks = Enum.GetValues(typeof(PockerEnum.Rank)).Cast<PockerEnum.Rank>();

            var allCombinations = from suit in cardSuits
                                  from rank in cardRanks
                                  select new Cards(suit, rank);
            cardDeck = allCombinations.ToList();
        }

        /// <summary>
        /// Suffle Card as per the input
        /// </summary>
        /// <param name="timesToShuffle"></param>
        public void ShuffleCards(int timesToShuffle)
        {
            Cards temp;
            int cardToShuffle1, cardToShuffle2;

            for (int x = 0; x < timesToShuffle; x++)
            {
                cardToShuffle1 = random.Next(cardDeck.Count());
                cardToShuffle2 = random.Next(cardDeck.Count());
                temp = cardDeck[cardToShuffle1];

                cardDeck[cardToShuffle1] = cardDeck[cardToShuffle2];
                cardDeck[cardToShuffle2] = temp;
            }
        }

        /// <summary>
        /// Random No Generator method
        /// </summary>
        /// <param name="index">Total Count</param>
        /// <returns></returns>
        private static int RandomNoGenerator(int index)
        {
            return random.Next(index);
        }

        /// <summary>
        /// Deal the random cards
        /// </summary>
        /// <returns></returns>
        public Cards DealCards()
        {
            int x = RandomNoGenerator(cardDeck.Count());
            Cards dealHand = cardDeck[x];
            cardDeck.RemoveAt(x);
            return dealHand;
        }
    }
}
