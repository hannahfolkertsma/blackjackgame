using blackjackgame.Models;
using Microsoft.AspNetCore.Mvc;

namespace blackjackgame.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public static Game blackjack = new Game();
        public GameViewModel viewmodel = new GameViewModel();
        public const int WIN_VALUE = 21;

        
        public IActionResult Index()
        {
            return View("Index", viewmodel);
        }
        

        [HttpPost]
        public ActionResult Start()
        {
            blackjack = new Game();
            //game start
            //draw the player's first card
            blackjack.player.Add(blackjack.drawCard());
            //draw the dealer's first card
            blackjack.dealer.Add(blackjack.drawCard());
            //draw the player's second card
            blackjack.player.Add(blackjack.drawCard());
            //check if the dealer draws a natural - if so, the card is played face up immediately
            blackjack.dealer.Add(blackjack.drawCard());
            if (blackjack.calculateTotal(blackjack.dealer) != WIN_VALUE)
            {

                blackjack.dealer[1].hide();
            }

            //populate the viewmodel and return to the view
            viewmodel.update(blackjack.player, blackjack.dealer, blackjack.calculateTotal(blackjack.player), blackjack.calculateTotal(blackjack.dealer));

            return View("Index", viewmodel);


        }

        // Add a card to the player's hand and update the viewmodel with the new data
        // returns the updated viewmodel to the view
        [HttpPost]
        public ActionResult Hit()
        {
            bool playerbust = false;
            bool dealerwin = false;
            blackjack.player.Add(blackjack.drawCard());
            if(blackjack.calculateTotal(blackjack.player) > WIN_VALUE) 
            { 
                playerbust = true; 
                dealerwin = true;
            }
            viewmodel.update(blackjack.player, blackjack.dealer, blackjack.calculateTotal(blackjack.player), blackjack.calculateTotal(blackjack.dealer), dealerwin, dealerbust:false, playerwin:false, playerbust, draw:false);
            return View("Index", viewmodel);


        }


        // Handle end of game actions and determine winner
        // returns the updated viewmodel to the view
        [HttpPost]
        public ActionResult Stand()
        {
            // turn over the dealer's hidden card
            blackjack.dealer[1].show();
            // dealer draws until their hand value exceeds 17
            while (blackjack.calculateTotal(blackjack.dealer) < 17)
            {
                blackjack.dealer.Add(blackjack.drawCard());
            }
            // determine win 
            int dealerval = blackjack.calculateTotal(blackjack.dealer);
            int playerval = blackjack.calculateTotal(blackjack.player);
            bool dealerwin = false;
            bool playerwin = false;
            bool draw = false;
            bool dealerbust = false;
            if (dealerval < WIN_VALUE)
            {
                if (dealerval > playerval)
                {
                    dealerwin = true; 
                }
                else if (playerval > dealerval)
                {
                    playerwin = true; 
                }
                // if neither of the above expressions are true, then it is a draw.
                else
                {
                    draw = true;
                }
            }
            else if(dealerval > WIN_VALUE){
                dealerbust = true;
                playerwin = true;
            }
            else // if the dealer draws up to 21 - check for a draw
            {
                if(dealerval != playerval)
                {
                    dealerwin = true;
                }
                else
                {
                    draw = true;
                }

            }
            viewmodel.update(blackjack.player, blackjack.dealer, playerval, dealerval, dealerwin, dealerbust, playerwin, playerbust: false, draw);
            return View("Index", viewmodel);


        }
    }
}
