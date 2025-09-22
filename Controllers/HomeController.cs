using System.Diagnostics;
using System.Transactions;
using System.Text.Json;
using blackjack.Models;
using blackjackgame.Models;
using Microsoft.AspNetCore.Mvc;

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
        public JsonResult Start()
        {
            Game blackjack = new Game();
            blackjack.play();

            return Json("playing");

        }
    }
}
