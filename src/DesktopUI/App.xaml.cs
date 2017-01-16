using Autofac;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Sample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule(new InMemoryStorageModule());
            containerBuilder.RegisterModule(new CoreModule());
            containerBuilder.RegisterType<MainWindow>();
            containerBuilder.RegisterType<MainWindowViewModel>();
            var container = containerBuilder.Build();

            MainWindow = container.Resolve<MainWindow>();
            MainWindow.Show();
        }
    }
}
