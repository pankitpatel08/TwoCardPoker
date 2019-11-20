using static PockerBusinessLogic.PockerEnum;

namespace PockerBusinessLogic
{
    public class Cards
    {
        public Suit suit;
        public Rank rank;
        public Cards(Suit s, Rank n)
        {
            suit = s;
            rank = n;
        }
    }
}
