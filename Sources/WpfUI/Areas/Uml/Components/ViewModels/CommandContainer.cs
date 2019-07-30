using System.IO;
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
        public CommandsViewData Commands { get; private set; }

        public CommandContainer(IShapeDisplayService shapeDisplayService)
        {
            _shapeDisplayService = shapeDisplayService;
        }

        public Task InitializeAsync(ComponentsViewModel context)
        {
            _context = context;
            Commands = new CommandsViewData(CreateEmptyComponent);
            return Task.CompletedTask;
        }

        private readonly IShapeDisplayService _shapeDisplayService;

        private ComponentsViewModel _context;

        private ViewModelCommand CreateEmptyComponent
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
    }
}