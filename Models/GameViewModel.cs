namespace blackjackgame.Models
{
    public class GameViewModel
    {
        public List<Card> playerhand { get; set; }
        public List<Card> dealerhand { get; set; }
        public int dealerval { get; set; }
        public int playerval { get; set; }
        public bool dealerwin { get; set; }
        public bool dealerbust { get; set; }
        public bool playerwin { get; set; }
        public bool playerbust { get; set; }
        public bool draw { get; set; }
        public bool gamestart { get; set; }

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
            if(dealerval == 21)
            {
                dealerwin = true;
            }
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
