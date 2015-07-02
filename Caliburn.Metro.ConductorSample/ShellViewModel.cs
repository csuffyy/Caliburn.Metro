using Caliburn.Micro;
using Caliburn.ReactiveUI;

namespace Caliburn.Metro.ConductorSample
{
    public class ShellViewModel : ReactiveConductor<IScreen>.Collection.OneActive
    {
        int count = 1;

        private readonly TabViewModel item = new TabViewModel { DisplayName = "Tab 0 " };

        public ShellViewModel()
        {
            DisplayName = "ReactiveConductor Demo";

            ActivateItem(item);
        }

        public void OpenTab()
        {
            ActivateItem(new TabViewModel
            {
                DisplayName = "Tab " + count++
            });
        }
    }
}