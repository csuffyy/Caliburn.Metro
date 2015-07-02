using System.Windows;
using Caliburn.Micro;

namespace Caliburn.ReactiveUI.Metro
{
    public class CaliburnBootstrapper<TRootViewModel> : BootstrapperBase
    {
        public CaliburnBootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<TRootViewModel>();
        }
    }
}