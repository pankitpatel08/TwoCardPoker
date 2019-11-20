using System;
using System.Collections.Generic;
using System.Linq;

namespace PockerBusinessLogic
{
    public class WinningCombinations
    {
        /// <summary>
        /// Straight Flush, 2 cards of sequential rank, same suit
        /// </summary>
        /// <param name="cardsinHand"></param>
        /// <returns></returns>
        public static bool StraightFlushCheck(List<Cards> cardsinHand)
        {
            //2 cards of sequential rank, same suit
            if (FlushCheck(cardsinHand))
            {
                int firstCard = PockerSolvingMethods.GetCardByRank(Convert.ToString(cardsinHand[0].rank));
                int secondCard = PockerSolvingMethods.GetCardByRank(Convert.ToString(cardsinHand[1].rank));
                if ((firstCard - secondCard) == 1 || (firstCard - secondCard) == -1)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Flush, 2 cards, same suit
        /// </summary>
        /// <param name="cardsInHand"></param>
        /// <returns></returns>
        public static bool FlushCheck(List<Cards> cardsInHand)
        {
            //2 cards, same suit
            if (cardsInHand.All(s => s.suit == cardsInHand[0].suit))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Straight, 2 cards of sequential rank, different suit
        /// </summary>
        /// <param name="cardsInHand"></param>
        /// <returns></returns>
        public static bool StraightCheck(List<Cards> cardsInHand)
        {
            //2 cards of sequential rank, different suit
            if (!FlushCheck(cardsInHand))
            {
                int firstCard = PockerSolvingMethods.GetCardByRank(Convert.ToString(cardsInHand[0].rank));
                int secondCard = PockerSolvingMethods.GetCardByRank(Convert.ToString(cardsInHand[1].rank));
                if ((firstCard - secondCard) == 1 || (firstCard - secondCard) == -1)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// High Card Rank
        /// </summary>
        /// <param name="cardsInHand"></param>
        /// <returns></returns>
        public static string GetHighCardRank(List<Cards> cardsInHand)
        {
            int firstCard = PockerSolvingMethods.GetCardByRank(Convert.ToString(cardsInHand[0].rank));
            int secondCard = PockerSolvingMethods.GetCardByRank(Convert.ToString(cardsInHand[1].rank));
            if (firstCard > secondCard)
                return Convert.ToString(cardsInHand[0].rank);
            else
                return Convert.ToString(cardsInHand[1].rank);
        }

        /// <summary>
        /// Pair Check with Same Rank in Cards
        /// </summary>
        /// <param name="cardsInHand"></param>
        /// <returns></returns>
        public static bool PairCheck(List<Cards> cardsInHand)
        {
            if (cardsInHand.All(s => s.rank == cardsInHand[0].rank))
            {
                return true;
            }
            return false;
        }
    }
}
