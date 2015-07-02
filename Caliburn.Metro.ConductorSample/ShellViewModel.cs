using Caliburn.Micro;
using Caliburn.ReactiveUI;

namespace Caliburn.Metro.ConductorSample
{
    public class ShellViewModel : ReactiveConductor<IScreen>.Collection.OneActive
    {
        int count = 1;

        public void OpenTab()
        {
            ActivateItem(new TabViewModel
            {
                DisplayName = "Tab " + count++
            });
        }
    }
}