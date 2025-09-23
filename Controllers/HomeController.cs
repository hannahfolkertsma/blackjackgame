using blackjack.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Numerics;
using System.Text.Json;
using System.Transactions;

namespace blackjackgame.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Start()
        {
            Game blackjack = new Game();
            //game start
            //draw two cards for the dealer - only display one,and hide total
            blackjack.dealer.Add(blackjack.drawCard());
            blackjack.dealer.Add(blackjack.drawCard());
            //draw two cards for the player
            blackjack.player.Add(blackjack.drawCard());
            blackjack.player.Add(blackjack.drawCard());

            int playerval = blackjack.calculateTotal(blackjack.player);
            int dealerval = blackjack.calculateTotal(blackjack.dealer);

            var viewmodel = new GameViewModel(blackjack.dealer, blackjack.player, dealerval, playerval);

            //if either pulls 21, end game
            //if (playerval == 21 || dealerval == 21) { return; }

            //if not, continue:
            //player select "hit" or "stand"
            // if hit, deal and update

            //if dealer total < 17
            if (dealerval < 17) { blackjack.dealer.Add(blackjack.drawCard()); };

            return View("Index");


        }

        [HttpPost]
        public string getImageURL(Card c)
        {
            return c.image;
        }
    }
}
