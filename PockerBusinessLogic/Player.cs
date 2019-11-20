using System.Collections.Generic;

namespace PockerBusinessLogic
{
    public class Player
    {
        Deck playerDeck = new Deck();
        public List<Cards> hand = new List<Cards>();

        /// <summary>
        /// Generate the Cards
        /// </summary>
        /// <returns></returns>
        public List<Cards> GenerateCards()
        {
            for (int i = 0; i < 2; i++)
            {
                Cards c = playerDeck.DealCards();
                hand.Add(c);
            }
            return hand;
        }
    }
}
