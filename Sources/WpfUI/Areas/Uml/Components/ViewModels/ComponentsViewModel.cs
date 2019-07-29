using System;
using System.Threading.Tasks;
using Mmu.DrawIoBuddy.DrawIoGateway.Areas.DrawingElements.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Components.CommandBars.ViewData;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;

namespace Mmu.DrawIoBuddy.WpfUI.Areas.Uml.Components.ViewModels
{
    public class ComponentsViewModel : ViewModelBase, INavigatableViewModel, IInitializableViewModel
    {
        private readonly CommandContainer _commandContainer;

        public string NavigationDescription => "Components";

        public int NavigationSequence => 2;

        public string HeadingDescription => "Components";

        public CommandsViewData Commands => _commandContainer.Commands;

        private string _drawIoOutput;

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