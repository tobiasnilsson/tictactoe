using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject.Modules;
using TicTacToe.Common.Interfaces;
using TicTacToe.Common.Repositories;
using TicTacToe.WebUI.Models;
using TicTacToe.WebUI.Test;

namespace TicTacToe.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly ITest _test;

        public HomeController()
        {
            _playerRepository = new PlayerRepository(@"C:\Users\Tobias Nilsson\Documents\GitHub\tictactoe\Players");
        }

        public HomeController(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public HomeController(ITest test)
        {
            this._test = test;
        }

        public ActionResult Index()
        {
            var model = new IndexModel {Players = _playerRepository.GetPlayers()};

            ViewBag.Message = "Spela spel!"; 
            ViewBag.Title = "Spela";
            ViewBag.PlayersTitle = "Spelare";

            return View(model);
        }

    }

}
