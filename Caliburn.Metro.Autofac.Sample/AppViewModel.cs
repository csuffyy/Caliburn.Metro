using Caliburn.Micro;
using System.Dynamic;
using System.Windows;

namespace Caliburn.Metro.Autofac.Sample
{
    public class AppViewModel : PropertyChangedBase, IHaveDisplayName
    {
        private readonly IWindowManager windowManager;
        public AppViewModel(IWindowManager windowManager)
        {
            DisplayName = "Caliburn Metro Autofac Sample";
            this.windowManager = windowManager;
        }

        public string DisplayName { get; set; }

        public void OpenWindow()
        {
            dynamic settings = new ExpandoObject();
            settings.WindowStartupLocation = WindowStartupLocation.Manual;

            windowManager.ShowWindow(new AppViewModel(windowManager), null, settings);
        }

        public void OpenSettings()
        {
            IsSettingsFlyoutOpen = true;
        }

        private bool isSettingsFlyoutOpen;

        public bool IsSettingsFlyoutOpen
        {
            get { return isSettingsFlyoutOpen; }
            set
            {
                isSettingsFlyoutOpen = value;
                NotifyOfPropertyChange(() => IsSettingsFlyoutOpen);
            }
        }
    }
}