using System.Data;
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
        public void update(List<Card> player, List<Card> dealer, int playerval, int dealerval) {
            this.playerhand = player;
            this.dealerhand = dealer;
            this.playerval = playerval;
            this.dealerval = dealerval;
            gamestart = true;
        }

        public void update(List<Card> playerhand, List<Card> dealerhand, int playerval, int dealerval, bool dealerwin, bool dealerbust, bool playerwin, bool playerbust, bool draw)
        {
            this.dealerhand = dealerhand;
            this.playerhand = playerhand;
            this.playerval = playerval;
            this.dealerval = dealerval;
            this.dealerwin = dealerwin;
            this.dealerbust = dealerbust;
            this.playerwin = playerwin;
            this.playerbust = playerbust;

            this.draw = draw;
            this.gamestart = true;
        }

    }
}
