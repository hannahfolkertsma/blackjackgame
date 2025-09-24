using System.Diagnostics.Eventing.Reader;

namespace blackjackgame.Models
{
    public class GameViewModel
    {
        public List<Card> playerhand = new List<Card>();
        public List<Card> dealerhand = new List<Card>();
        public int dealerval = 0;
        public int playerval = 0;
        public bool dealerwin = false;
        public bool dealerbust = false;
        public bool playerwin = false;
        public bool playerbust = false;
        public bool draw = false;

        public GameViewModel()
        {
            playerhand = new List<Card>();
            dealerhand = new List<Card>();
            dealerval = 0;
            playerval = 0;
            playerbust = false;
            playerwin = false;
            dealerbust = false;
            dealerwin = false;
            draw = false;
        }
        public GameViewModel(List<Card> player, List<Card> dealer, int p, int d) {
            playerhand = player;
            dealerhand = dealer;
            playerval = p;
            dealerval = d;

            if(playerval > 21)
            {
                playerbust = true;
            }
            else if(playerval == 21)
            {
                playerwin = true;
            }
            else if(dealerval > 21)
            {
                dealerbust = true;
            }
            else if(dealerval == 21)
            {
                dealerwin = true;
            }
            else if(playerval == dealerval)
            {
                draw = true;
            }
            // if none off the above are true, there is no determined winner yet
        }



    }
}
