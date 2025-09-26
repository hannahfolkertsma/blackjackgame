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


    }
}
