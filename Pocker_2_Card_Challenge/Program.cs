using PockerBusinessLogic;
using System;
using System.Collections.Generic;

namespace Pocker_2_Card_Challenge
{
    public class Program
    {
        private static string totalRound = "";
        private static string totalPlayer = "";
        private static string shuffleNo = "";
        private static Deck deck = new Deck();
        private static Dictionary<string, int> winnerDict = new Dictionary<string, int>();
        private static string winnerName = string.Empty;
        private static bool isPlayAgain = false;

        static void Main(string[] args)
        {
            Console.Title = "Poker";
            Console.WriteLine("Welcome to Two(2) Card Poker Challenge");

            PlayAgain:
            try
            {
                GetPlayer();
                GetRound();

                Console.WriteLine("------------------------------------");
                Console.Write("\n");

                // Looping for total round of Poker
                for (int countRound = 1; countRound <= Convert.ToInt32(totalRound); countRound++)
                {
                    Console.WriteLine("--------");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Round {0}", countRound);
                    Console.ResetColor();
                    Console.WriteLine("--------");

                    GetShuffleNumber();

                    deck.ShuffleCards(Convert.ToInt32(shuffleNo));
                    Console.WriteLine("--------");

                    List<Player> lstplayer = new List<Player>();
                    for (int countPlayer = 1; countPlayer <= Convert.ToInt32(totalPlayer); countPlayer++)
                    {
                        Player player = new Player();
                        //Deal cards
                        player.GenerateCards();
                        lstplayer.Add(player);
                    }

                    // Show Player Hands and Return Dictionary with Score
                    winnerDict = PockerSolvingMethods.ShowHands(lstplayer, isPlayAgain);
                    isPlayAgain = false;
                    // Return WinnerName with higher Score
                    winnerName = PockerSolvingMethods.GetWinnerName(winnerDict);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("After Round {0}, the Winner is {1}", countRound, winnerName);
                    Console.WriteLine("-----------------------------------------------------------------------------\n");
                    Console.ResetColor();
                }

                Console.ForegroundColor = ConsoleColor.DarkGray;
                //Find OverAll Winner
                winnerName = PockerSolvingMethods.GetWinnerName(winnerDict);
                Console.WriteLine(winnerName + " won the Poker! Cheers!");

                //Play Again Message
                Console.WriteLine("Play Again? 'Y' to continue or 'Anykey' to exit");
                Console.ResetColor();
                string playAgain = Console.ReadLine();
                Console.WriteLine("\n");
                Console.ResetColor();
                // If Y then Jump to PlayAgain otherwise Exit
                if (playAgain.ToUpper() == "Y")
                {
                    ResetVariables();
                    isPlayAgain = true;
                    goto PlayAgain;
                }
                else
                    Console.ReadLine();
            }
            catch (InvalidOperationException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Operation: ", ex.Message);
                Console.ResetColor();
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: ", ex.Message);
                Console.ResetColor();
                Console.ReadLine();
            }
        }

        /// <summary>
        /// If PlayAgain then variable needs to be initialized again
        /// </summary>
        private static void ResetVariables()
        {
            try
            {
                totalRound = "";
                totalPlayer = "";
                shuffleNo = "";
                deck = new Deck();
                winnerDict = new Dictionary<string, int>();
                winnerName = string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get No of Suffle
        /// </summary>
        private static void GetShuffleNumber()
        {
            try
            {
                Console.WriteLine("How many times do you want to Shuffle Cards?");
                shuffleNo = Console.ReadLine();

                while (!IsNumber(Convert.ToString(shuffleNo)))
                {
                    Console.WriteLine("Enter valid number of Shuffle");
                    shuffleNo = Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Check String is Number of not
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private static bool IsNumber(string num)
        {
            bool isNumber = false;
            try
            {
                int i = 0;
                string s = num;
                isNumber = int.TryParse(s, out i);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isNumber;
        }

        /// <summary>
        /// Get No of Player from Input
        /// </summary>
        private static void GetPlayer()
        {
            try
            {
                Console.WriteLine("Enter number of Players (2-6)");
                totalPlayer = Console.ReadLine();

                // Number of Player Input
                while (!IsNumber(Convert.ToString(totalPlayer)) || Convert.ToInt32(totalPlayer) > 6 || Convert.ToInt32(totalPlayer) < 2)
                {
                    Console.WriteLine("Enter valid number of Players");
                    totalPlayer = Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get No of Round(s) from Input  
        /// </summary>
        private static void GetRound()
        {
            try
            {
                Console.WriteLine("Enter number of Rounds (2-5)");
                totalRound = Console.ReadLine();

                // Number of Round Input
                while (!IsNumber(Convert.ToString(totalRound)) || Convert.ToInt32(totalRound) > 5 || Convert.ToInt32(totalRound) < 2)
                {
                    Console.WriteLine("Enter valid number of Rounds");
                    totalRound = Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
