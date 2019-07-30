using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Components.CommandBars.ViewData;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;

namespace Mmu.DrawIoBuddy.WpfUI.Areas.Uml.Components.ViewModels
{
    public class ComponentsViewModel : ViewModelBase, INavigatableViewModel, IInitializableViewModel
    {
        private readonly CommandContainer _commandContainer;
        private string _drawIoOutput;
        public CommandsViewData Commands => _commandContainer.Commands;

        public string DrawIoOutput
        {
            get => _drawIoOutput;
            set
            {
                if (_drawIoOutput != value)
                {
                    _drawIoOutput = value;
                    OnPropertyChanged();
                }
            }
        }

        public string HeadingDescription => "Components";
        public string NavigationDescription => "Components";
        public int NavigationSequence => 2;

        public ComponentsViewModel(CommandContainer commandContainer)
        {
            _commandContainer = commandContainer;
        }

        public async Task InitializeAsync(params object[] initParams)
        {
            await _commandContainer.InitializeAsync(this);
        }
    }
}