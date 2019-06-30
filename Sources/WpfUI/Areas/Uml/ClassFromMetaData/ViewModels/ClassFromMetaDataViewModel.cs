using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Components.CommandBars.ViewData;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;

namespace Mmu.DrawIoBuddy.WpfUI.Areas.Uml.ClassFromMetaData.ViewModels
{
    public class ClassFromMetaDataViewModel : ViewModelBase, INavigatableViewModel, IInitializableViewModel
    {
        private readonly CommandContainer _commandContainer;
        private string _drawIoOutput;
        private string _metaData;

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

        public string HeadingDescription => "Create Class from MetaData";

        public string MetaData
        {
            get => _metaData;
            set
            {
                if (_metaData != value)
                {
                    _metaData = value;
                    OnPropertyChanged();
                }
            }
        }

        public string NavigationDescription => "Class From MetaData";
        public int NavigationSequence => 2;

        public ClassFromMetaDataViewModel(CommandContainer commandContainer)
        {
            _commandContainer = commandContainer;
        }

        public async Task InitializeAsync(params object[] initParams)
        {
            await _commandContainer.InitializeAsync(this);
        }
    }
}