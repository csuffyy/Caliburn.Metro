using Caliburn.Micro;

namespace Caliburn.ReactiveUI.Metro
{
    public class CaliburnMetroAutofacBootstrapper<TRootModel> : AutofacBootstrapper<TRootModel>
    {
        protected override void ConfigureBootstrapper()
        {
            AutoSubscribeEventAggegatorHandlers = false;
            CreateWindowManager = () => (IWindowManager)new MetroWindowManager();
            CreateEventAggregator = () => (IEventAggregator)new EventAggregator();

            EnforceNamespaceConvention = true;
            ViewModelBaseType = typeof(System.ComponentModel.INotifyPropertyChanged);
        }
    }
}