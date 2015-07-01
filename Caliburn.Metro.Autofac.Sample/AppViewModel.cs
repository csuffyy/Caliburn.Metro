using Caliburn.Micro;
using System.Dynamic;
using System.Windows;
using Caliburn.ReactiveUI;
using ReactiveUI;

namespace Caliburn.Metro.Autofac.Sample
{
    public class AppViewModel : ReactiveScreen
    {
        public AppViewModel()
        {
            DisplayName = "Caliburn Metro Autofac Sample";
        }

        /// <summary>
        /// 通过属性注入的方式获取实例
        /// </summary>
        public IWindowManager WindowManager { get; set; }

        public void OpenWindow()
        {
            dynamic settings = new ExpandoObject();
            settings.WindowStartupLocation = WindowStartupLocation.Manual;

            WindowManager.ShowDialog(new AppViewModel(), null, settings);
        }

        public void OpenSettings()
        {
            IsSettingsFlyoutOpen = true;
        }

        private bool isSettingsFlyoutOpen;

        public bool IsSettingsFlyoutOpen
        {
            get { return isSettingsFlyoutOpen; }
            set { this.RaiseAndSetIfChanged(ref isSettingsFlyoutOpen, value); }
        }
    }
}