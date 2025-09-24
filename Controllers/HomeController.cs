using blackjackgame.Models;
using Microsoft.AspNetCore.Mvc;

namespace blackjackgame.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public static Game blackjack = new Game();
        public GameViewModel viewmodel = new GameViewModel();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            GameViewModel viewModel = new GameViewModel();
            return View("Index", viewModel);
        }


        [HttpPost]
        public ActionResult Start()
        {
            blackjack = new Game();
            //game start
            //draw two cards for the dealer - only display one,and hide total
            blackjack.dealer.Add(blackjack.drawCard());
            blackjack.dealer.Add(blackjack.drawCard());
            //draw two cards for the player
            blackjack.player.Add(blackjack.drawCard());
            blackjack.player.Add(blackjack.drawCard());

            int playerval = blackjack.calculateTotal(blackjack.player);
            int dealerval = blackjack.calculateTotal(blackjack.dealer);

            if (dealerval < 17) { blackjack.dealer.Add(blackjack.drawCard()); };
            dealerval = blackjack.calculateTotal(blackjack.dealer);

            viewmodel = new GameViewModel(blackjack.player, blackjack.dealer, blackjack.calculateTotal(blackjack.player), blackjack.calculateTotal(blackjack.dealer));

            //if either pulls 21, end game
            //if (playerval == 21 || dealerval == 21) { return; }

            //if not, continue:
            //player select "hit" or "stand"
            // if hit, deal and update

            //if dealer total < 17

            return View("Index", viewmodel);


        }

        [HttpPost]
        public ActionResult Hit()
        {
            blackjack.player.Add(blackjack.drawCard());
            viewmodel = new GameViewModel(blackjack.player, blackjack.dealer, blackjack.calculateTotal(blackjack.player), blackjack.calculateTotal(blackjack.dealer));
            return View("Index", viewmodel);


        }

        [HttpPost]
        public ActionResult Stand()
        {
            // dealer draws until their hand value exceeds 17
            while(blackjack.calculateTotal(blackjack.dealer) < 17)
            {

                blackjack.dealer.Add(blackjack.drawCard());
            }
            // determine win 
            int dealerval = blackjack.calculateTotal(blackjack.dealer);
            int playerval = blackjack.calculateTotal(blackjack.player);
            if(dealerval < 21)
            {
                if(dealerval > playerval){
                    dealerval = 21; //the dealer win condition will be set to true when the model updates
                }
                else if(playerval > dealerval)
                {
                    playerval = 21; //the player win condition will be set to true when the model updates
                }
                // if neither of the above expressions are true, then it is a draw. This is handled in the viewmodel. 
            }

            viewmodel = new GameViewModel(blackjack.player, blackjack.dealer, playerval, dealerval);
            return View("Index", viewmodel);

        }
    }
}
