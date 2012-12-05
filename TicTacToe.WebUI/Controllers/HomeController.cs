using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicTacToe.Common.Interfaces;
using TicTacToe.Common.Repositories;
using TicTacToe.WebUI.Models;

namespace TicTacToe.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPlayerRepository _playerRepository;

        //public HomeController()
        //{
        //    _playerRepository = new PlayerRepository(@"C:\Users\Tobias Nilsson\Documents\GitHub\tictactoe\Players");
            
        //}

        public HomeController(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public ActionResult Index()
        {
            var model = new IndexModel();
            model.Players = _playerRepository.GetPlayers();

            ViewBag.Message = "Spela spel!";

            return View(model);
        }

    }
}
