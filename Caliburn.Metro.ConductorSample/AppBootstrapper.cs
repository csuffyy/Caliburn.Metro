using System.Reflection;
using System.Windows;
using Autofac;
using Caliburn.Micro;

namespace Caliburn.Metro.ConductorSample
{
    //方式1：
    //public class AppBootstrapper : CaliburnMetroMefBootstrapper<ShellViewModel>
    //{
    //}

    //方式2：
    //public class AppBootstrapper : AutofacBootstrapper<ShellViewModel>
    //{
    //    protected override void ConfigureContainer(ContainerBuilder builder)
    //    {
    //        var assembly = Assembly.GetExecutingAssembly();
    //        builder.RegisterAssemblyTypes(assembly)
    //            .Where(item => item.Name.EndsWith("ViewModel") && item.IsAbstract == false)
    //            .AsSelf()
    //            .SingleInstance();
    //    }
    //}

    //方式3：
    //public class AppBootstrapper : BootstrapperBase
    //{
    //    public AppBootstrapper()
    //    {
    //        Initialize();
    //    }

    //    protected override void OnStartup(object sender, StartupEventArgs e)
    //    {
    //        DisplayRootViewFor<ShellViewModel>();
    //    }
    //}

    //方式4：
    public class AppBootstrapper : CaliburnBootstrapper<ShellViewModel>
    {
    }
}
