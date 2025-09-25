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
        public bool gamestart = true;

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
            gamestart = false;
        }
        public GameViewModel(List<Card> player, List<Card> dealer, int p, int d) {
            playerhand = player;
            dealerhand = dealer;
            playerval = p;
            dealerval = d;
            gamestart = true;

            if(playerval > 21)
            {
                playerbust = true;
                dealerwin = true;
            }
            else if(dealerval > 21)
            {
                dealerbust = true;
                playerwin = true;
            }
            if(playerwin && dealerwin)
            {
                draw = true;
            }
            // if none off the above are true, there is no determined winner yet
        }

        public GameViewModel(List<Card> playerhand, List<Card> dealerhand, int dealerval, int playerval, bool dealerwin, bool dealerbust, bool playerwin, bool draw)
        {
            this.dealerhand = dealerhand;
            this.playerhand = playerhand;
            this.playerval = playerval;
            this.dealerval = dealerval;
            this.dealerwin = dealerwin;
            this.dealerbust = dealerbust;
            this.playerwin = playerwin;
            this.draw = draw;
            this.gamestart = true;
        }
    }
}
