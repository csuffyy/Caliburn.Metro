﻿using Caliburn.Micro;
using System.ComponentModel.Composition;
using System.Dynamic;
using System.Reactive.Linq;
using System.Windows;
using Caliburn.ReactiveUI;
using ReactiveUI;

namespace Caliburn.Metro.Sample
{
    [Export(typeof(AppViewModel))]
    //public class AppViewModel : PropertyChangedBase, IHaveDisplayName
    public class AppViewModel : ReactiveScreen
    {
        private readonly IWindowManager windowManager;

        [ImportingConstructor]
        public AppViewModel(IWindowManager windowManager)
        {
            DisplayName = "Caliburn Metro Sample";
            this.windowManager = windowManager;
        }

        public void OpenWindow()
        {
            dynamic settings = new ExpandoObject();
            settings.WindowStartupLocation = WindowStartupLocation.Manual;

            //windowManager.ShowWindow(new AppViewModel(windowManager), null, settings);
            //windowManager.ShowPopup(new AppViewModel(windowManager), null, settings);
            //windowManager.ShowDialog(new AppViewModel(windowManager), null, settings);

            windowManager.ShowDialog(new AppViewModel(windowManager));
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

            //set
            //{
            //    isSettingsFlyoutOpen = value;
            //    NotifyOfPropertyChange();
            //}
        }
    }
}