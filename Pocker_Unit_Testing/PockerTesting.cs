using Microsoft.VisualStudio.TestTools.UnitTesting;
using PockerBusinessLogic;
using System.Collections.Generic;

namespace Pocker_Unit_Testing
{
    [TestClass]
    public class PockerTesting
    {
        [TestMethod]
        public void TestPockerWinner()
        {
            Player pl = new Player();
            List<Player> lstPlayerHands = new List<Player>();

            // Add Cards in List
            List<Cards> player1Cards = new List<Cards>();
            player1Cards.Add(new Cards(PockerEnum.Suit.Spades, PockerEnum.Rank.A));
            player1Cards.Add(new Cards(PockerEnum.Suit.Diamonds, PockerEnum.Rank.J));
            pl.hand.AddRange(player1Cards);
            lstPlayerHands.Add(pl);

            pl = new Player();
            List<Cards> player2Cards = new List<Cards>();
            player2Cards.Add(new Cards(PockerEnum.Suit.Hearts, PockerEnum.Rank.Four));
            player2Cards.Add(new Cards(PockerEnum.Suit.Hearts, PockerEnum.Rank.Nine));
            pl.hand.AddRange(player2Cards);
            lstPlayerHands.Add(pl);

            Dictionary<string, int> dict = PockerSolvingMethods.ShowHands(lstPlayerHands);
            string winnerName = PockerSolvingMethods.GetWinnerName(dict);

            // Comparison of expected value with input values
            Assert.AreEqual("Player2", winnerName);
        }

        /// <summary>
        /// 2 cards, same suit
        /// </summary>
        [TestMethod]
        public void TestFlush()
        {
            // Add Cards in List
            List<Cards> playerCards = new List<Cards>();
            playerCards.Add(new Cards(PockerEnum.Suit.Hearts, PockerEnum.Rank.A));
            playerCards.Add(new Cards(PockerEnum.Suit.Hearts, PockerEnum.Rank.J));

            // Check whether Function works appropriately or not
            bool isFlush = WinningCombinations.FlushCheck(playerCards);//, out score);

            // Check Equality with output and input values
            Assert.AreEqual(true, isFlush);
        }

        /// <summary>
        /// 2 cards of sequential rank, same suit
        /// </summary>
        [TestMethod]
        public void TestStraightFlush()
        {
            // Add Cards in List
            List<Cards> playerCards = new List<Cards>();
            playerCards.Add(new Cards(PockerEnum.Suit.Diamonds, PockerEnum.Rank.A));
            playerCards.Add(new Cards(PockerEnum.Suit.Diamonds, PockerEnum.Rank.K));

            // Check whether Function works appropriately or not
            bool isFlush = WinningCombinations.StraightFlushCheck(playerCards);//, out score);

            // Check Equality with output and input values
            Assert.AreEqual(true, isFlush);
        }

        /// <summary>
        /// 2 cards of sequential rank, different suit
        /// </summary>
        [TestMethod]
        public void TestStraight()
        {
            // Add Cards in List
            List<Cards> playerCards = new List<Cards>();
            playerCards.Add(new Cards(PockerEnum.Suit.Hearts, PockerEnum.Rank.Five));
            playerCards.Add(new Cards(PockerEnum.Suit.Spades, PockerEnum.Rank.Four));

            // Check whether Function works appropriately or not
            bool isFlush = WinningCombinations.StraightCheck(playerCards);

            // Check Equality with output and input values
            Assert.AreEqual(true, isFlush);
        }

        /// <summary>
        /// 2 cards, different rank, suit and not in sequence. Highest card wins
        /// </summary>
        [TestMethod]
        public void TestHighCard()
        {
            // Add Cards in List
            List<Cards> playerCards = new List<Cards>();
            playerCards.Add(new Cards(PockerEnum.Suit.Clubs, PockerEnum.Rank.Q));
            playerCards.Add(new Cards(PockerEnum.Suit.Diamonds, PockerEnum.Rank.Seven));

            // Check whether Function works appropriately or not, would be returned high card value "Q"
            string highCard = WinningCombinations.GetHighCardRank(playerCards);

            // Check Equality with output and input values
            Assert.AreEqual("Q", highCard);
        }

        /// <summary>
        /// 2 cards of same rank
        /// </summary>
        [TestMethod]
        public void TestPair()
        {
            // Add Cards in List
            List<Cards> playerCards = new List<Cards>();
            playerCards.Add(new Cards(PockerEnum.Suit.Clubs, PockerEnum.Rank.Three));
            playerCards.Add(new Cards(PockerEnum.Suit.Hearts, PockerEnum.Rank.Three));

            // Check whether Function works appropriately or not
            bool isPair = WinningCombinations.PairCheck(playerCards);

            // Check Equality with output and input values
            Assert.AreEqual(true, isPair);
        }

        /// <summary>
        /// Check 2 cards Type
        /// </summary>
        [TestMethod]
        public void TestHandType()
        {
            // Add Cards in List
            List<Cards> playerCards = new List<Cards>();
            playerCards.Add(new Cards(PockerEnum.Suit.Spades, PockerEnum.Rank.Ten));
            playerCards.Add(new Cards(PockerEnum.Suit.Diamonds, PockerEnum.Rank.Ten));

            // Check whether Function works appropriately or not
            int handValue = PockerSolvingMethods.DetermineHand(playerCards);

            // Both Cards have same Rank, Return value must be Pair, 2
            Assert.AreEqual(2, handValue);
        }


        /// <summary>
        /// Check Card Rank
        /// </summary>
        [TestMethod]
        public void TestCardRank()
        {
            // Check whether Function works appropriately or not
            int cardValue = PockerSolvingMethods.GetCardByRank("A");

            Assert.AreEqual(14, cardValue);
        }

        /// <summary>
        /// Test Winner Name Function
        /// </summary>
        [TestMethod]
        public void TestGetWinnerName()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            dict.Add("Player1", 1);
            dict.Add("Player2", 4);
            dict.Add("Player3", 3);
            dict.Add("Player4", 2);
            // Check whether Function works appropriately or not
            string winnerName = PockerSolvingMethods.GetWinnerName(dict);

            Assert.AreEqual("Player2", winnerName);
        }
    }
}
