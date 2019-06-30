using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Components.CommandBars.ViewData;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;

namespace Mmu.DrawIoBuddy.WpfUI.Areas.Decoding.ViewModels
{
    public class DecodingViewModel : ViewModelBase, INavigatableViewModel, IInitializableViewModel
    {
        private readonly CommandContainer _commandContainer;
        private string _decodedText;
        private string _encodedText;
        public CommandsViewData Commands => _commandContainer.Commands;

        public string DecodedText
        {
            get => _decodedText;
            set
            {
                if (_decodedText != value)
                {
                    _decodedText = value;
                    OnPropertyChanged();
                }
            }
        }

        public string EncodedText
        {
            get => _encodedText;
            set
            {
                if (_encodedText != value)
                {
                    _encodedText = value;
                    OnPropertyChanged();
                }
            }
        }

        public string HeadingDescription => "Web Decoding";
        public string NavigationDescription => "Decoding";
        public int NavigationSequence => 1;

        public DecodingViewModel(CommandContainer commandContainer)
        {
            _commandContainer = commandContainer;
        }

        public async Task InitializeAsync(params object[] initParams)
        {
            await _commandContainer.InitializeAsync(this);
        }
    }
}