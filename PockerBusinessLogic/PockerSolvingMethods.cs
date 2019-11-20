using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PockerBusinessLogic
{
    public class PockerSolvingMethods
    {
        static Dictionary<string, int> winnerDict = new Dictionary<string, int>();
        static Dictionary<string, int> highCardDict = new Dictionary<string, int>();
        static bool isAllHighCard = true; // if both the cards have HighCard Combination

        /// <summary>
        /// Show Individual Player Hands Card and add winners in Dictionary
        /// </summary>
        /// <param name="lstPlayerHands"></param>
        /// <returns>Dictionary with Score added</returns>
        public static Dictionary<string, int> ShowHands(List<Player> lstPlayerHands, bool isPlayAgain = false)
        {
            isAllHighCard = true;
            //High Card Dictionary, to find the winner in case of High Cards Combination
            highCardDict = new Dictionary<string, int>();
            if (isPlayAgain)
                winnerDict = new Dictionary<string, int>();

            // Handle high card calculation between two hands:
            for (int i = 0; i < Convert.ToInt32(lstPlayerHands.Count); i++)
            {
                Console.Write("Player " + (i + 1) + " Cards: { ");
                Console.ResetColor();
                Console.OutputEncoding = Encoding.UTF8;
                Console.Write(lstPlayerHands[i].hand[0].rank + " of " + lstPlayerHands[i].hand[0].suit + " (" + CardSign(Convert.ToString(lstPlayerHands[i].hand[0].suit)) + ")");
                Console.Write(", ");
                Console.Write(lstPlayerHands[i].hand[1].rank + " of " + lstPlayerHands[i].hand[1].suit + " (" + CardSign(Convert.ToString(lstPlayerHands[i].hand[1].suit)) + ")");
                Console.OutputEncoding = Encoding.Default;
                Console.Write(" }, ");

                // Check Player Cards
                string key = "Player" + Convert.ToInt32(i + 1);
                int score = DetermineHand(lstPlayerHands[i].hand);
                string name = Enum.GetName(typeof(PockerEnum.PockerWinning), score);
                Console.Write("Hand Ranks: [ " + name + " ]; \n");

                if (score == 0 && isAllHighCard)
                {
                    string highCard = WinningCombinations.GetHighCardRank(lstPlayerHands[i].hand);
                    int rankValue = GetCardByRank(highCard);
                    highCardDict.Add(key, rankValue);
                }
                else
                {
                    //If no high card combination then variable false 
                    isAllHighCard = false;
                }

                if (winnerDict.ContainsKey(key))
                {
                    winnerDict[key] += score;
                }
                else
                {
                    winnerDict.Add(key, score);
                }
            }

            CheckHighCard();
            PrintRoundWinner();
            return winnerDict;
        }

        /// <summary>
        /// Print the winners name after current Round
        /// </summary>
        private static void PrintRoundWinner()
        {
            Console.Write("------------------------------------\n");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Score Card\n");
            Console.ResetColor();
            Console.Write("------------------------------------\n");
            foreach (var item in winnerDict)
            {
                Console.Write("After current Round, {0} Score : {1} \n", item.Key, item.Value);
            }
            Console.Write("------------------------------------\n");
        }

        /// <summary>
        /// All High Card Then Add Score "1"
        /// </summary>
        private static void CheckHighCard()
        {
            string highCardWinner = "";
            if (isAllHighCard)
            {
                highCardWinner = GetWinnerName(highCardDict);
                winnerDict[highCardWinner] += 1;
            }
        }

        /// <summary>
        /// Return Card Sign
        /// </summary>
        /// <param name="cardSuit"></param>
        /// <returns>Sign of Card</returns>
        private static string CardSign(string cardSuit)
        {
            switch (cardSuit.ToUpper())
            {
                case Constants.Spades:
                    return "♠";
                case Constants.Clubs:
                    return "♣";
                case Constants.Hearts:
                    return "♥";
                case Constants.Diamonds:
                    return "♦";
            }
            return "";
        }

        /// <summary>
        /// Get the winner name from the Dictionary, Higher number of Rounds winner will be the winner of Pocker Game
        /// </summary>
        /// <param name="dict">Dictionary</param>
        /// <returns>Winner Name from Dict</returns>
        public static string GetWinnerName(Dictionary<string, int> dict)
        {
            var temp = from entry in dict orderby entry.Value descending select entry;
            var list = temp.ToList();
            return list[0].Key;
        }

        /// <summary>
        /// Check the card Combination
        /// </summary>
        /// <param name="playerHand"></param>
        /// <returns>Integer Value of Hand Type</returns>
        public static int DetermineHand(List<Cards> playerHand)
        {
            if (WinningCombinations.StraightFlushCheck(playerHand))
                return (int)PockerEnum.PockerWinning.StraightFlush; // 5;StraightFlush

            if (WinningCombinations.FlushCheck(playerHand))
                return (int)PockerEnum.PockerWinning.Flush;// 4;Flush

            if (WinningCombinations.StraightCheck(playerHand))
                return (int)PockerEnum.PockerWinning.Straight;// 3;Straight

            if (WinningCombinations.PairCheck(playerHand))
                return (int)PockerEnum.PockerWinning.Pair;// 2;Pair

            return (int)PockerEnum.PockerWinning.HighCard;// 0;HighCard
        }

        /// <summary>
        /// Get the Rank of Card
        /// </summary>
        /// <param name="rank"></param>
        /// <returns>Integer value of Rank</returns>
        public static int GetCardByRank(string rank)
        {
            return (int)Enum.Parse(typeof(PockerEnum.Rank), rank);
        }
    }
}
