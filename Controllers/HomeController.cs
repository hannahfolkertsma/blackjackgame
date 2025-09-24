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
            //check if the dealer draws a natural - if so, the card is played face up immediately
            Random random = new Random();
            int index = random.Next(blackjack.deck.Count);
            Card pickedCard = blackjack.deck[index];
            if(blackjack.calculateTotal(new List<Card>() { blackjack.dealer[0], pickedCard }) == 21)
            {
                blackjack.dealer.Add(pickedCard);
            }
            else
            {
                blackjack.dealer.Add(new Card(CardNames.BACK, "BACK.png", 0));
            }
            //draw two cards for the player
            blackjack.player.Add(blackjack.drawCard());
            blackjack.player.Add(blackjack.drawCard());

            int playerval = blackjack.calculateTotal(blackjack.player);
            int dealerval = blackjack.calculateTotal(blackjack.dealer);

            //populate the viewmodel and return to the view
            viewmodel = new GameViewModel(blackjack.player, blackjack.dealer, blackjack.calculateTotal(blackjack.player), blackjack.calculateTotal(blackjack.dealer));

            return View("Index", viewmodel);


        }

        // Add a card to the player's hand and update the viewmodel with the new data
        // returns the updated viewmodel to the view
        [HttpPost]
        public ActionResult Hit()
        {
            blackjack.player.Add(blackjack.drawCard());
            viewmodel = new GameViewModel(blackjack.player, blackjack.dealer, blackjack.calculateTotal(blackjack.player), blackjack.calculateTotal(blackjack.dealer));
            return View("Index", viewmodel);


        }

        // Handle end of game actions and determine winner
        // returns the updated viewmodel to the view
        [HttpPost]
        public ActionResult Stand()
        {
            blackjack.dealer.Remove(blackjack.dealer[1]);
            blackjack.dealer.Add(blackjack.drawCard());
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
