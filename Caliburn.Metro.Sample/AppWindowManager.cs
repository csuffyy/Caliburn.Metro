using System.ComponentModel.Composition;
using Caliburn.Micro;
using Caliburn.ReactiveUI.Metro;
using MahApps.Metro.Controls;

namespace Caliburn.Metro.Sample
{
    [Export(typeof(IWindowManager))]
    public class AppWindowManager : MetroWindowManager
    {
        public override MetroWindow CreateCustomWindow(object view, bool viewIsMetroWindow)
        {
            if (viewIsMetroWindow)
            {
                return view as MainWindowContainer;
            }

            return new MainWindowContainer
            {
                Content = view
            };
        }
    }
}