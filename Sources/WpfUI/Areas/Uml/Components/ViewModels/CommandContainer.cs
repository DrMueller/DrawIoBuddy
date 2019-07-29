using System.Threading.Tasks;
using Mmu.DrawIoBuddy.DrawIoGateway.Areas.DrawingElements.Models.Shapes.Uml;
using Mmu.DrawIoBuddy.DrawIoGateway.Areas.DrawingElements.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Commands;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Components.CommandBars.ViewData;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.ViewModelCommands;

namespace Mmu.DrawIoBuddy.WpfUI.Areas.Uml.Components.ViewModels
{
    public class CommandContainer : IViewModelCommandContainer<ComponentsViewModel>
    {
        private readonly IShapeDisplayService _shapeDisplayService;

        private ComponentsViewModel _context;

        public CommandsViewData Commands { get; private set; }

        private ViewModelCommand CreateEmptyContent
        {
            get
            {
                return new ViewModelCommand(
                    "Create empty Component",
                    new RelayCommand(() =>
                    {
                        var component = new Component();
                        var drawIoString = _shapeDisplayService.CreateDisplayString(component);
                        _context.DrawIoOutput = drawIoString.EncodeString();
                    }));
            }
        }

        public CommandContainer(IShapeDisplayService shapeDisplayService)
        {
            _shapeDisplayService = shapeDisplayService;
        }

        public Task InitializeAsync(ComponentsViewModel context)
        {
            _context = context;
            Commands = new CommandsViewData(CreateEmptyContent);
            return Task.CompletedTask;
        }
    }
}