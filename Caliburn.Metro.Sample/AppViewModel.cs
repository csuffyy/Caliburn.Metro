﻿using System;
using Caliburn.Micro;
using System.ComponentModel.Composition;
using System.Dynamic;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Caliburn.Metro.Sample
{
    [Export(typeof(AppViewModel))]
    public class AppViewModel : ReactiveScreen
    {
        private readonly IWindowManager windowManager;

        [ImportingConstructor]
        public AppViewModel(IWindowManager windowManager)
        {
            DisplayName = "Caliburn Metro Sample";
            Name = "Hello";

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

        public async Task OpenSettings()
        {
            await Task.Delay(20);

            IsSettingsFlyoutOpen = true;
            Name = "lzy";
        }

        [Reactive]
        public bool IsSettingsFlyoutOpen { get; set; }

        [Reactive]
        public string Name { get; set; }
    }
}