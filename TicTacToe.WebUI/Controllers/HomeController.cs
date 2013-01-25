using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject.Modules;
using TicTacToe.Common.Interfaces;
using TicTacToe.Common.Repositories;
using TicTacToe.WebUI.Decorators;
using TicTacToe.WebUI.Managers;
using TicTacToe.WebUI.Models;

namespace TicTacToe.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IPlayerRepository _playerRepository;
        private IDiscColorManager _discColorManager;
        
        public HomeController(IPlayerRepository playerRepository, IDiscColorManager discColorManager)
        {
            _playerRepository = playerRepository;
            _discColorManager = discColorManager;
        }

        public ActionResult Index()
        {
            //Read up on lifecycle management in ninject (scoping ) since we dont want several instances of player repo

            var players = _playerRepository.GetPlayers();

            var model = new IndexModel
                {
                    Players = players.Select(p => new ColoredPlayer(p) { RgbColor = _discColorManager.GetDiscColor(p.Name[0]) })
                };

            ViewBag.Message = "Play game!";
            ViewBag.Title = "Play";
            ViewBag.PlayersTitle = "Players";

            return View(model);
        }

        public RedirectToRouteResult ClearColors()
        {
            _discColorManager.ClearDiscColors();

            return RedirectToAction("Index");
        }
    }

}
