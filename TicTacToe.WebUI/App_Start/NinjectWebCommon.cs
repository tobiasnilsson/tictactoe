using System.Web.Routing;
using Microsoft.AspNet.SignalR;
using Ninject.Planning.Bindings;
using TicTacToe.Common;
using TicTacToe.Common.Factories;
using TicTacToe.Common.Interfaces;
using TicTacToe.Common.Repositories;

[assembly: WebActivator.PreApplicationStartMethod(typeof(TicTacToe.WebUI.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(TicTacToe.WebUI.App_Start.NinjectWebCommon), "Stop")]

namespace TicTacToe.WebUI.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Modules;
    using TicTacToe.WebUI.Managers;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
            
            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            //Binding with parameterless constructor
            kernel.Bind<IDiscColorManager>().To<DiscColorManager>();
            kernel.Bind<IBoardFactory>().To<BoardFactory>();

            //Binding with constructor accepting a string parameter
            kernel.Bind<IPlayerRepository>().To<PlayerRepository>().WithConstructorArgument("playerAssemblyDir", System.Web.Hosting.HostingEnvironment.MapPath("~/Players"));
            kernel.Bind<IWinnerCheckerFactory>().To<WinnerCheckerFactory>();

            //Binding with constructor accepting three parameters of interface type
            kernel.Bind<IGameManager>().To<GameManager>()
                  .WithConstructorArgument("playerFactory", ctx => ctx.Kernel.Get<IPlayerRepository>())
                  .WithConstructorArgument("boardFactory", ctx => ctx.Kernel.Get<IBoardFactory>())
                  .WithConstructorArgument("winnerCheckerFactory", ctx => ctx.Kernel.Get<IWinnerCheckerFactory>());
            
            RouteTable.Routes.MapHubs(new NinjectSignalRDependencyResolver(kernel));
        }        
    }
}
