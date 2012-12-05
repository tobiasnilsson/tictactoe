//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using Ninject.Modules;
//using TicTacToe.Common.Interfaces;
//using TicTacToe.Common.Repositories;

//namespace TicTacToe.WebUI.Modules
//{
//    public class NinjectLoader : NinjectModule
//    {
//        public override void Load()
//        {
//            Bind<IPlayerRepository>().To<PlayerRepository>().WithConstructorArgument("playerAssemblyDir", @"C:\Users\Tobias Nilsson\Documents\GitHub\tictactoe\Players");
//        }
//    }
//}