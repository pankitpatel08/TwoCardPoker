namespace PockerBusinessLogic
{
    public class PockerEnum
    {
        public enum Suit
        {
            Diamonds = 1,
            Hearts = 2,
            Clubs = 3,
            Spades = 4,
        }

        public enum Rank
        {
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8,
            Nine = 9,
            Ten = 10,
            J = 11, //Jack
            Q = 12, //Queen
            K = 13, //King
            A = 14, //Ace
        }

        public enum PockerWinning
        {
            StraightFlush = 5,
            Flush = 4,
            Straight = 3,
            Pair = 2,
            HighCard = 0,
        }
    }
}